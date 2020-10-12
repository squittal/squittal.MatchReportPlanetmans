using Microsoft.Extensions.Logging;
using squittal.ScrimPlanetmans.Services.Planetside;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace squittal.ScrimPlanetmans.Data
{
    public class ApplicationDataLoader : IApplicationDataLoader
    {
        private readonly IItemCategoryService _itemCategoryService;
        private readonly IFacilityService _facilityService;
        private readonly IWorldService _worldService;
        private readonly IZoneService _zoneService;
        private readonly IDbSeeder _dbSeeder;
        private readonly ILogger<ApplicationDataLoader> _logger;


        public ApplicationDataLoader(
            IItemCategoryService itemCategoryService,
            IFacilityService facilityService,
            IWorldService worldService,
            IZoneService zoneService,
            IDbSeeder dbSeeder,
            ILogger<ApplicationDataLoader> logger)
        {
            _itemCategoryService = itemCategoryService;
            _facilityService = facilityService;
            _worldService = worldService;
            _zoneService = zoneService;
            _dbSeeder = dbSeeder;
            _logger = logger;
        }

        public async Task OnApplicationStartup(CancellationToken cancellationToken)
        {
            try
            {
                await _dbSeeder.SeedDatabase(cancellationToken);

                cancellationToken.ThrowIfCancellationRequested();

                List<Task> TaskList = new List<Task>();

                var weaponCategoriesListTask = _itemCategoryService.SetUpWeaponCategoriesListAsync();
                TaskList.Add(weaponCategoriesListTask);

                var scrimmableMapRegionsTask = _facilityService.SetUpScrimmableMapRegionsAsync();
                TaskList.Add(scrimmableMapRegionsTask);

                var worldsMapTask = _worldService.SetUpWorldsMap();
                TaskList.Add(worldsMapTask);

                var zonesTask = _zoneService.SetupZonesMapAsync();
                TaskList.Add(zonesTask);

                await Task.WhenAll(TaskList);

                cancellationToken.ThrowIfCancellationRequested();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed loading application data: {ex}");
            }
        }

        public async Task OnApplicationShutdown(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
    }
}
