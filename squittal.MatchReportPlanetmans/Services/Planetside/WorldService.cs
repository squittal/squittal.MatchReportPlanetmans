using squittal.MatchReportPlanetmans.Models.Planetside;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using squittal.MatchReportPlanetmans.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System;
using System.Threading;

namespace squittal.MatchReportPlanetmans.Services.Planetside
{
    public class WorldService : IWorldService
    {
        private readonly IDbContextHelper _dbContextHelper;
        private readonly ILogger<WorldService> _logger;

        private ConcurrentDictionary<int, World> WorldsMap { get; set; } = new ConcurrentDictionary<int, World>();
        private readonly SemaphoreSlim _mapSetUpSemaphore = new SemaphoreSlim(1);


        public WorldService(IDbContextHelper dbContextHelper, ILogger<WorldService> logger)
        {
            _dbContextHelper = dbContextHelper;
            _logger = logger;
        }


        public async Task<IEnumerable<World>> GetAllWorldsAsync()
        {
            if (WorldsMap.Count == 0 || !WorldsMap.Any())
            {
                await SetUpWorldsMap();
            }

            return GetAllWorlds();
        }

        private IEnumerable<World> GetAllWorlds()
        {
            return WorldsMap.Values.ToList();
        }

        public async Task SetUpWorldsMap()
        {
            await _mapSetUpSemaphore.WaitAsync();

            try
            {
                using var factory = _dbContextHelper.GetFactory();
                var dbContext = factory.GetDbContext();

                var storeWorlds = await dbContext.Worlds.Where(z => z.Id != 25).ToListAsync(); // RIP Briggs

                foreach (var worldId in WorldsMap.Keys)
                {
                    if (!storeWorlds.Any(r => r.Id == worldId))
                    {
                        WorldsMap.TryRemove(worldId, out var removedWorld);
                    }
                }

                foreach (var world in storeWorlds)
                {
                    if (WorldsMap.ContainsKey(world.Id))
                    {
                        WorldsMap[world.Id] = world;
                    }
                    else
                    {
                        WorldsMap.TryAdd(world.Id, world);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error setting up Worlds Map: {ex}");
            }
            finally
            {
                _mapSetUpSemaphore.Release();
            }
        }

        public static bool IsJaegerWorldId(int worldId)
        {
            return worldId == 19;
        }
    }
}
