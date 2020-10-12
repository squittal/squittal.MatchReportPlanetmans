using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace squittal.MatchReportPlanetmans.Services
{
    public interface ISqlScriptRunner
    {
        void RunSqlDirectoryScripts(string directoryName);
        void RunSqlScript(string fileName);
    }
}
