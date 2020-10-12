using System.Threading;
using System.Threading.Tasks;

namespace squittal.MatchReportPlanetmans.Data
{
    public interface IApplicationDataLoader
    {
        Task OnApplicationStartup(CancellationToken cancellationToken);
        Task OnApplicationShutdown(CancellationToken cancellationToken);
    }
}
