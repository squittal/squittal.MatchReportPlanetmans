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
    public class ZoneService : IZoneService
    {
        private readonly IDbContextHelper _dbContextHelper;
        private readonly ILogger<ZoneService> _logger;

        private ConcurrentDictionary<int, Zone> ZonesMap { get; set; } = new ConcurrentDictionary<int, Zone>();
        private readonly SemaphoreSlim _mapSetUpSemaphore = new SemaphoreSlim(1);
        
        public ZoneService(IDbContextHelper dbContextHelper, ILogger<ZoneService> logger)
        {
            _dbContextHelper = dbContextHelper;
            _logger = logger;
        }

        public async Task<IEnumerable<Zone>> GetAllZones()
        {
            if (ZonesMap.Count == 0 || !ZonesMap.Any())
            {
                await SetupZonesMapAsync();
            }

            return ZonesMap.Values.ToList();
        }

        public async Task SetupZonesMapAsync()
        {
            await _mapSetUpSemaphore.WaitAsync();

            try
            {
                using var factory = _dbContextHelper.GetFactory();
                var dbContext = factory.GetDbContext();

                var storeZones = await dbContext.Zones.ToListAsync();

                foreach (var zoneId in ZonesMap.Keys)
                {
                    if (!storeZones.Any(z => z.Id == zoneId))
                    {
                        ZonesMap.TryRemove(zoneId, out var removedZone);
                    }
                }

                foreach (var zone in storeZones)
                {
                    if (ZonesMap.ContainsKey(zone.Id))
                    {
                        ZonesMap[zone.Id] = zone;
                    }
                    else
                    {
                        ZonesMap.TryAdd(zone.Id, zone);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error setting up Zones Map: {ex}");
            }
            finally
            {
                _mapSetUpSemaphore.Release();
            }
        }
    }
}
