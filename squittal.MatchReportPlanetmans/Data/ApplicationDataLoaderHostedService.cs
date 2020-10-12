using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace squittal.MatchReportPlanetmans.Data
{
    public class ApplicationDataLoaderHostedService : IHostedService
    {
        private readonly IApplicationDataLoader _appLoader;

        public ApplicationDataLoaderHostedService(IApplicationDataLoader appLoader)
        {
            _appLoader = appLoader;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return _appLoader.OnApplicationStartup(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return _appLoader.OnApplicationShutdown(cancellationToken);
        }
    }
}
