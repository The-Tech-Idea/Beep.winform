using System;
using System.Collections.Generic;
using System.Text;

namespace KOC.DHUB3.Models
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
