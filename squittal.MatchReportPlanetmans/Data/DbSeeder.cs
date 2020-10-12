using Microsoft.Extensions.Logging;
using squittal.MatchReportPlanetmans.Services;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace squittal.MatchReportPlanetmans.Data
{
    public class DbSeeder : IDbSeeder
    {
        private readonly ISqlScriptRunner _sqlScriptRunner;
        private readonly ILogger<DbSeeder> _logger;

        public DbSeeder(
            ISqlScriptRunner sqlScriptRunner,
            ILogger<DbSeeder> logger
        )
        {
            _sqlScriptRunner = sqlScriptRunner;
            _logger = logger;
        }

        public async Task SeedDatabase(CancellationToken cancellationToken)
        {
            try
            {
                List<Task> TaskList = new List<Task>();

                await Task.WhenAll(TaskList);

                _sqlScriptRunner.RunSqlDirectoryScripts("Views");

                cancellationToken.ThrowIfCancellationRequested();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to seed database: {ex}");
            }
        }
    }
}
