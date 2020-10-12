using static squittal.MatchReportPlanetmans.Data.DbContextHelper;

namespace squittal.MatchReportPlanetmans.Data
{
    public interface IDbContextHelper
    {
        DbContextFactory GetFactory();
    }
}
