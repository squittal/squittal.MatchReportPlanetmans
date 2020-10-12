using System;
using System.Threading;
using System.Threading.Tasks;

namespace squittal.MatchReportPlanetmans.Data
{
    public interface IDbSeeder
    {
        Task SeedDatabase(CancellationToken cancellationToken);
    }
}
