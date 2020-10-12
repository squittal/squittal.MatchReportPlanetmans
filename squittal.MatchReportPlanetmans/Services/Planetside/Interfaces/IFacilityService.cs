using squittal.MatchReportPlanetmans.Models.Planetside;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace squittal.MatchReportPlanetmans.Services.Planetside
{
    public interface IFacilityService
    {
        Task SetUpScrimmableMapRegionsAsync();
        Task<IEnumerable<MapRegion>> GetScrimmableMapRegionsAsync();
    }
}
