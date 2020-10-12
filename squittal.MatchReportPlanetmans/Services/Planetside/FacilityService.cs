using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using squittal.MatchReportPlanetmans.Data;
using squittal.MatchReportPlanetmans.Models.Planetside;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace squittal.MatchReportPlanetmans.Services.Planetside
{
    public class FacilityService : IFacilityService
    {
        private readonly IDbContextHelper _dbContextHelper;
        private readonly ILogger<FacilityService> _logger;

        private ConcurrentDictionary<int, MapRegion> ScrimmableFacilityMapRegionsMap { get; set; } = new ConcurrentDictionary<int, MapRegion>();
        private readonly SemaphoreSlim _mapSetUpSemaphore = new SemaphoreSlim(1);

        public FacilityService(IDbContextHelper dbContextHelper, ILogger<FacilityService> logger)
        {
            _dbContextHelper = dbContextHelper;
            _logger = logger;
        }

        public async Task<IEnumerable<MapRegion>> GetScrimmableMapRegionsAsync()
        {
            if (ScrimmableFacilityMapRegionsMap.Count == 0 || !ScrimmableFacilityMapRegionsMap.Any())
            {
                await SetUpScrimmableMapRegionsAsync();
            }

            return GetScrimmableMapRegions();
        }

        private IEnumerable<MapRegion> GetScrimmableMapRegions()
        {
            return ScrimmableFacilityMapRegionsMap.Values.ToList();
        }

        public async Task SetUpScrimmableMapRegionsAsync()
        {
            var realZones = new List<int> { 2, 4, 6, 8 };
            var scrimFacilityTypes = new List<int> { 5, 6}; // Small Outpost, Large Outpost

            await _mapSetUpSemaphore.WaitAsync();

            try
            {
                using var factory = _dbContextHelper.GetFactory();
                var dbContext = factory.GetDbContext();

                var storeRegions = await dbContext.MapRegions
                                                    .Where(region => realZones.Contains(region.ZoneId)
                                                                        && scrimFacilityTypes.Contains(region.FacilityTypeId))
                                                    .ToListAsync();

                foreach (var facilityId in ScrimmableFacilityMapRegionsMap.Keys)
                {
                    if (!storeRegions.Any(r => r.FacilityId == facilityId))
                    {
                        ScrimmableFacilityMapRegionsMap.TryRemove(facilityId, out var removedItem);
                    }
                }

                foreach (var region in storeRegions)
                {
                    if (ScrimmableFacilityMapRegionsMap.ContainsKey(region.FacilityId))
                    {
                        ScrimmableFacilityMapRegionsMap[region.FacilityId] = region;
                    }
                    else
                    {
                        ScrimmableFacilityMapRegionsMap.TryAdd(region.FacilityId, region);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error setting up Scrimmable Map Regions Map: {ex}");
            }
            finally
            {
                _mapSetUpSemaphore.Release();
            }
        }
    }
}
