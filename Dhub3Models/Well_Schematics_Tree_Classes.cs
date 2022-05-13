using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOC.DHUB3.Models
{
    

    public class cls_well_completion
    {
        public int WELL_COMPLETION_S { get; set; }
        public int PARENT_WELL_COMPLETION_S { get; set; }
        public string FACILITY_TYPE { get; set; }
        public string UWI { get; set; }
        public int RESERVOIR_S { get; set; }
        public string RESERVOIR_ID { get; set; }
        public int STRING_S { get; set; }
        public string CURRENT_STATUS { get; set; }
        public string EXISTENCE_TYPE { get; set; }
        public string FACILITY_NAME { get; set; }
        public string FACILITY_ID { get; set; }
        public string CATALOG_NUMBER { get; set; }
        public string DESCRIPTION { get; set; }
        public DateTime? START_TIME { get; set; }
        public DateTime? END_TIME { get; set; }
        public int DURATION { get; set; }
        public string COMPLETION_OBJECTIVE { get; set; }
        public int PRODUCTIVITY_INDEX { get; set; }
        public int OPERATING_PRESS { get; set; }
        public int OPERATING_TEMP { get; set; }
        public int TOP_DEPTH { get; set; }
        public int BOTTOM_DEPTH { get; set; }
        public int LENGTH { get; set; }
        public int INNER_DIAMETER { get; set; }
        public int OUTER_DIAMETER { get; set; }
        public int SHOT_ANGLE { get; set; }
        public int SHOT_COUNT { get; set; }
        public int SHOT_DENSITY { get; set; }
        public int SHOT_DIAMETER { get; set; }
        public int SHOT_LENGTH { get; set; }
        public int SHOT_PHASE { get; set; }
        public int FILL_HEIGHT { get; set; }
        public int GRAVEL_SIZE { get; set; }
        public int SCREEN_DIAMETER { get; set; }
        public int SLOT_LENGTH { get; set; }
        public int SLOT_WIDTH { get; set; }
        public int SHOT_PER_UOM { get; set; }
        public DateTime? CURRENT_STATUS_DATE { get; set; }
        public int WH_PRESS_BEFORE { get; set; }
        public int WH_PRESS_AFTER { get; set; }
        public string GUN_SIZE { get; set; }
        public string GUN_TYPE { get; set; }
        public int PERF_BALANCE_PRESS { get; set; }
        public int LOG_TRACE_ID { get; set; }
        public string COMP_FLUID_TYPE { get; set; }
        public int COMP_FLUID_DENSITY { get; set; }
        public int PLUGBACK_DEPTH { get; set; }
        public int PERCENTAGE { get; set; }
        public string REMARKS { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime? LAST_UPDATE { get; set; }
        public DateTime? INSERT_DATE { get; set; }
        public string INSERTED_BY { get; set; }
        public int SDAT_LABEL { get; set; }
        public string STRUCTURE_POSITION { get; set; }
        public cls_well_completion()
        {
        }
    }

    public class cls_facility_cases
    {
        public int DOWNHOLE_FACILITY_S { get; set; }
        public string FACILITY_TYPE { get; set; }
        public string UWI { get; set; }
        public string LAYER_NAME { get; set; }
        public string LAYER_TYPE { get; set; }
        public int STRAT_SCOPE_ID { get; set; }
        public string CURRENT_STATUS { get; set; }
        public string EXISTENCE_TYPE { get; set; }
        public string FACILITY_NAME { get; set; }
        public string FACILITY_ID { get; set; }
        public string CATALOG_NUMBER { get; set; }
        public string DESCRIPTION { get; set; }
        public DateTime? START_TIME { get; set; }
        public DateTime? END_TIME { get; set; }
        public int DURATION { get; set; }
        public int STORAGE_CAPACITY { get; set; }
        public int OPERATING_PRESS { get; set; }
        public int OPERATING_TEMP { get; set; }
        public int POWER_CONSUMPTION { get; set; }
        public int TOP_DEPTH { get; set; }
        public int BOTTOM_DEPTH { get; set; }
        public int LENGTH { get; set; }
        public int INNER_DIAMETER { get; set; }
        public int OUTER_DIAMETER { get; set; }
        public string DATA_SOURCE { get; set; }
        public int WEIGHT { get; set; }
        public string GRADE { get; set; }
        public string COMPANY { get; set; }
        public string CONNECTION { get; set; }
        public string USAGE { get; set; }
        public string SIZE_DESC { get; set; }
        public int RESOLUTION { get; set; }
        public string REMARKS { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime? LAST_UPDATE { get; set; }
        public string COUPLING_TYPE { get; set; }
        public DateTime? INSERT_DATE { get; set; }
        public string INSERTED_BY { get; set; }
        public int SDAT_LABEL { get; set; }
        public int BOREHOLE_SEGMENT_SET_S { get; set; }
        public string facility_super_type { get; set; }

        public cls_facility_cases()
        {
        }
    }

    public class cls_well_tree
    {
        public int ID { get; set; }
        public int PARENTID { get; set; }
        public string UWI { get; set; }
        public string FACILITY_TYPE { get; set; }
        public DateTime? START_TIME { get; set; }
        public DateTime? END_TIME { get; set; }
        public string ACTIVE { get; set; }
        public int INSERTBY { get; set; }
        public DateTime? INSERTDATE { get; set; }
        public int UPDATEBY { get; set; }
        public DateTime? UPDATEDATE { get; set; }
        public int FACILITY_KEY { get; set; }
        public string FACILITY_NAME { get; set; }
        public string DEFINITION { get; set; }
        public int TOP { get; set; }
        public int BOTTOM { get; set; }
        public string GRADE { get; set; }
        public int WEIGHT { get; set; }
        public int INNER_DIAMETER { get; set; }
        public int OUTER_DIAMETER { get; set; }
        public string STATUS { get; set; }
        public DateTime? WO_DATE { get; set; }
        public cls_well_tree()
        {
        }
    }

    public class cls_well_hdr
    {
        public int Drillers_td { get; set; }
        public string crstatus { get; set; }
        public int KB_elevation { get; set; }
    }

}
