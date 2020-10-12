using squittal.MatchReportPlanetmans.Models.Planetside;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace squittal.MatchReportPlanetmans.Services.Planetside
{
    public interface IZoneService
    {
        Task<IEnumerable<Zone>> GetAllZones();
        Task SetupZonesMapAsync();
    }
}
