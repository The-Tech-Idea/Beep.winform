using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOC.DHUB3.Models.Analysis
{
    public class IPRPoints
    {
        public int VogelFlowRate { get; set; }
        public int WigginsFlowRate { get; set; }
        public int StandingsFlowRate { get; set; }
        public int FetkovichsFlowRate { get; set; }
        public int KlinsClarkFlowRate { get; set; }
        public int Pressure { get; set; }
    }
}
