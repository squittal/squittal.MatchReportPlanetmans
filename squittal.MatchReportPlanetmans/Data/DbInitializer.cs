using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace squittal.MatchReportPlanetmans.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {

            using (var context = new PlanetmansDbContext(
                serviceProvider.GetRequiredService<
                DbContextOptions<PlanetmansDbContext>>()))
            {
                context.Database.Migrate();
                return;
            }
        }
    }
}
