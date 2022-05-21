using System;

namespace KOC.DHUB3.Models
{
    public class WELL_DIR_SRVY_PTS
    {
        public WELL_DIR_SRVY_PTS()
        {

        }
        public double MD { get; set; }
        public double TVD { get; set; }
        public double inclination { get; set; }
        public double DEVIATION_ANGLE { get; set; }
        public double AZIMUTH { get; set; }
        public double DX { get; set; }
        public double DY { get; set; }
    }

    public class WellDeviation
    {
        public WellDeviation()
        {

        }

        public string Divation { get; set; }
    }

    public class WrokOver_History
    {
        public WrokOver_History()
        {

        }
        public DateTime? END_DATE { get; set; }
        public string OBJECTIVE { get; set; }
        public string OPERATION_PURPOSE { get; set; }
        public string RIG { get; set; }
        public DateTime? SPUD_DATE { get; set; }
        public string UWI { get; set; }
        public string WORKOVER_NO { get; set; }
        public string Divation { get; set; }
    }

    public class WellTree
    {
        public WellTree()
        {

        }
        public string ID { get; set; }
        public string UWI { get; set; }
        public string FACILITY_KEY { get; set; }
        public string FACILITY_NAME { get; set; }
        public string DEFINITION { get; set; }
        public DateTime? TOP { get; set; }
        public string BOTTOM { get; set; }
        public string GRADE { get; set; }
        public string WEIGHT { get; set; }
        public string INNER_DIAMETER { get; set; }
        public string OUTER_DIAMETER { get; set; }
        public string PARENTID { get; set; }
        public DateTime? START_TIME { get; set; }
        public DateTime? END_TIME { get; set; }
        public string STATUS { get; set; }
        public DateTime? UPDATEDATE { get; set; }
        public string UPDATEBY { get; set; }
        public string ACTIVE { get; set; }
        public string INSERTBY { get; set; }
        public DateTime? INSERTDATE { get; set; }

    }
    // ACTIVE, BOTTOM, DEFINITION, END_TIME, FACILITY_KEY, FACILITY_NAME, FACILITY_TYPE, GRADE, ID, INNER_DIAMETER, INSERTBY, INSERTDATE, OUTER_DIAMETER, PARENTID, START_TIME, STATUS, TOP, UPDATEBY, UPDATEDATE, UWI, WEIGHT
    public class KOC_WELL_V
    {
        public KOC_WELL_V()
        {

        }
        public string ASSET { get; set; }
        public string FIELD { get; set; }
        public string GC { get; set; }
        public string UWI { get; set; }
        public string FACILITY_NAME { get; set; }
        public string RESERVOIR_ID { get; set; }
        public string WCS { get; set; }
        public string WELL_TYPE { get; set; }
        public string MATERIAL { get; set; }
        public string FLOW_DIRECTION { get; set; }
        public string LIFE_PHASE { get; set; }
        public string COMPLETION { get; set; }
        public string CONNECTION { get; set; }
        public string LIFT_METHOD { get; set; }
        public string OPERATION { get; set; }
        public DateTime? OPERATION_STATUS_DATE { get; set; }
        public string OPERATION_STATUS_REASON { get; set; }
    }
}
// 