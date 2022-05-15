using System;

namespace KOC.DHUB3.Models
{
    public class cls_cd_rig
    {
        public string RIG_ID { get; set; }
        public double BOP_PRESS_RATING { get; set; }
        public string CONTRACTOR_ID { get; set; }
        public double AIR_GAP { get; set; }
        public string APPROVALS { get; set; }
        public string BOP_SYSTEM_SIZE { get; set; }
        public double BULK_MUD_CAP { get; set; }
        public double DRILL_WATER_CAP { get; set; }
        public double FUEL_CAP { get; set; }
        public string REMARKS { get; set; }
        public double BULK_CEMENT_CAPACITY { get; set; }
        public double LIQUID_MUD_CAP { get; set; }
        public double DEFAULT_ELEVATION { get; set; }
        public string CEMENT_UNIT { get; set; }
        public string DEFAULT_ELEV_NAME { get; set; }
        public double POTABLE_WATER_CAP { get; set; }
        public string CRANE_TYPE { get; set; }
        public double DRILL_DEPTH_RATING { get; set; }
        public double WATER_DEPTH_RATING { get; set; }
        public string IS_READONLY { get; set; }
        public string IS_OFFSHORE { get; set; }
        public double NUM_CRANES { get; set; }
        public string RIG_CLASS { get; set; }
        public string FLARE_DESCRIPTION { get; set; }
        public string RIG_NAME { get; set; }
        public string RIG_OWNER { get; set; }
        public string RIG_NO { get; set; }
        public string GANTRY_DESCRIPTION { get; set; }
        public string GENERATOR { get; set; }
        public string RIG_TYPE { get; set; }
        public double VDL_MAX { get; set; }
        public double HEAVE_MAX { get; set; }
        public double VDL_STORM { get; set; }
        public double WELLS_DRILLED { get; set; }
        public string IS_AZIMUTHING { get; set; }
        public DateTime CREATE_DATE { get; set; }
        public string MAIN_ENGINE { get; set; }
        public string CREATE_USER_ID { get; set; }
        public string CREATE_APP_ID { get; set; }
        public DateTime UPDATE_DATE { get; set; }
        public string UPDATE_USER_ID { get; set; }
        public double MOTION_COMPENSATION_MIN { get; set; }
        public string UPDATE_APP_ID { get; set; }
        public double MOTION_COMPENSATION_MAX { get; set; }
        public double MOTION_COMPENSATION_STROKE { get; set; }
        public double NUM_DERRICKS { get; set; }
        public double DERRICK_HEIGHT { get; set; }
        public double NUM_THRUSTERS { get; set; }
        public string DERRICK_TYPE { get; set; }
        public string REGISTRATION { get; set; }
        public double DERRICK_RATING { get; set; }
        public string RIG_MANUFACTURER { get; set; }
        public double DERRICK_WIND_CAPACITY { get; set; }
        public double PIPE_STAND_LENGTH { get; set; }
        public string DRIVE_TYPE { get; set; }
        public string RIG_YEAR { get; set; }
        public string DRIVE_TYPE_DESCRIPTION { get; set; }
        public string PIPE_HANDLING_SYSTEM { get; set; }
        public string ROTARY_SYSTEM_MAKE { get; set; }
        public string ROTARY_SYSTEM_MODEL { get; set; }
        public double ROTARY_SYSTEM_OPENING_SIZE { get; set; }
        public double ROTARY_SYSTEM_RATING { get; set; }
        public double ROTARY_SYSTEM_TORQUE { get; set; }
        public string ROTARY_SYSTEM_TYPE { get; set; }
        public double SWIVEL_RATING { get; set; }
        public string SWIVEL_TYPE { get; set; }
        public string BRAKE_DESCRIPTION { get; set; }
        public string DRAW_WORKS_MOTOR { get; set; }
        public double DRAW_WORKS_POWER { get; set; }
        public string DRAW_WORKS_TYPE { get; set; }
        public double DRILL_LINE_RATING { get; set; }
        public double DRILL_LINE_SIZE { get; set; }
        public double HOOK_RATING { get; set; }
        public string HOOK_TYPE { get; set; }
        public double NUM_BLOCK_LINES { get; set; }
        public double BLOCK_RATING { get; set; }
        public double BLOCK_WEIGHT { get; set; }
        public double MAX_HOOK_LOAD { get; set; }
        public string SCR_SYSTEM { get; set; }
        public string MOORING_SYSTEM { get; set; }
        public string MOORING_SYSTEM_CODE { get; set; }
        public string RIG_MOORING_SYSTEM { get; set; }
        public DateTime START_DATE { get; set; }
        public DateTime END_DATE { get; set; }
        public string RIG_TYPE_CODE { get; set; }
        public cls_cd_rig()
        {

        }
    }

    public class cls_cd_well
    {
        public string WELL_ID { get; set; }
        public string SITE_ID { get; set; }
        public string TIGHT_GROUP_ID { get; set; }
        public double ACTIVE_UI_UNITSYS_ID { get; set; }
        public double COORD_TYPE { get; set; }
        public string API_NO { get; set; }
        public string BATTERY { get; set; }
        public string REMARKS { get; set; }
        public string COMPLETION_WELL_ID { get; set; }
        public string IS_OFFSHORE { get; set; }
        public string DATUM_NAME { get; set; }
        public string GEO_DESCRIPTION { get; set; }
        public double GEO_LATITUDE { get; set; }
        public double GEO_LONGITUDE { get; set; }
        public string GEO_OFFSET_REFERENCE { get; set; }
        public double GEO_OFFSET_EAST { get; set; }
        public double GEO_OFFSET_NORTH { get; set; }
        public string IS_PLATFORM { get; set; }
        public string IS_SUBSEA { get; set; }
        public string SLOT_NAME { get; set; }
        public DateTime SPUD_DATE { get; set; }
        public string LOC_COUNTY { get; set; }
        public string REASON { get; set; }
        public string LOC_COUNTRY { get; set; }
        public double USE_SLOT_AS_REFERENCE { get; set; }
        public string LOC_STATE { get; set; }
        public string WELL_COMMON_NAME { get; set; }
        public string IS_READONLY { get; set; }
        public string WELL_DESC { get; set; }
        public double SLOT_EW { get; set; }
        public string WELL_GEOMETRY { get; set; }
        public double SLOT_NS { get; set; }
        public string TARGET_FORMATION { get; set; }
        public string WELL_LEGAL_NAME { get; set; }
        public double SLOT_RADIAL_ERROR { get; set; }
        public string UNIT_SET_ON_CREATE { get; set; }
        public double WELLHEAD_DEPTH { get; set; }
        public double WATER_DEPTH { get; set; }
        public double WELL_NET_INT { get; set; }
        public double CONVERGENCE { get; set; }
        public string WELL_OPERATOR { get; set; }
        public string WELL_DESC_ALTERNATE { get; set; }
        public string WELL_PURPOSE { get; set; }
        public string WELL_UWI { get; set; }
        public double WELL_WORKING_INT { get; set; }
        public DateTime CREATE_DATE { get; set; }
        public string WELL_OPERATOR_ORIGINAL { get; set; }
        public string WELL_UWI_TYPE { get; set; }
        public string CREATE_USER_ID { get; set; }
        public string CREATE_APP_ID { get; set; }
        public DateTime UPDATE_DATE { get; set; }
        public double SCALE_FACTOR { get; set; }
        public string UPDATE_USER_ID { get; set; }
        public string UPDATE_APP_ID { get; set; }
        public double WRP_AZIMUTH { get; set; }
        public double WRP_EW { get; set; }
        public double WRP_INCLINATION { get; set; }
        public double WRP_MD { get; set; }
        public double WRP_NS { get; set; }
        public double WRP_OFFSET { get; set; }
        public double WRP_TVD { get; set; }
        public string REDRILL_NO { get; set; }
        public double MAASP_A { get; set; }
        public double MAASP_B { get; set; }
        public double MAASP_C { get; set; }
        public string IS_H2S_PRESENT { get; set; }
        public string IS_LSA_PRESENT { get; set; }
        public string IS_PROJECT_READONLY { get; set; }
        public string IS_CO2_PRESENT { get; set; }
        public string REDRILL_PREV_WELL_ID { get; set; }
        public string PREVIOUS_WELL_NAME { get; set; }
        public string IS_MULTILATERAL { get; set; }
        public string IS_LAKE_DRILLED { get; set; }
        public double LAKE_HEIGHT { get; set; }
        public double MAASP_D { get; set; }
        public string LAHEE_CLASS { get; set; }
        public string FIELD_NAME { get; set; }
        public string PUMPER_ROUTE { get; set; }
        public string WELL_DIRECTIONS { get; set; }
        public string BATTERY_DIRECTIONS { get; set; }
        public DateTime CONDUCTOR_INSTALL_DATE { get; set; }
        public string LEASE_TYPE { get; set; }
        public string FIELD_NUMBER { get; set; }
        public string USER_DEFINED_1 { get; set; }
        public string USER_DEFINED_2 { get; set; }
        public string USER_DEFINED_3 { get; set; }
        public string USER_DEFINED_4 { get; set; }
        public string USER_DEFINED_5 { get; set; }
        public string USER_DEFINED_6 { get; set; }
        public string USER_DEFINED_7 { get; set; }
        public string USER_DEFINED_8 { get; set; }
        public string USER_DEFINED_9 { get; set; }
        public string USER_DEFINED_10 { get; set; }
        public string USER_DEFINED_11 { get; set; }
        public string USER_DEFINED_12 { get; set; }
        public DateTime USER_DEFINED_DATE_1 { get; set; }
        public DateTime USER_DEFINED_DATE_2 { get; set; }
        public DateTime USER_DEFINED_DATE_3 { get; set; }
        public DateTime USER_DEFINED_DATE_4 { get; set; }
        public DateTime USER_DEFINED_DATE_5 { get; set; }
        public cls_cd_well()
        {

        }
    }

    public class cls_current_operation_rig
    {
        public string team { get; set; }
        public string Rig_id;
        public string rig_name { get; set; }
        public DateTime startdate { get; set; }
        public cls_current_operation_rig()
        {

        }
    }

    public class cls_Rig_operation_event
    {
        public string WELL_ID { get; set; }
        public string UWI { get; set; }
        public DateTime RECDATE { get; set; }
        public string TEAM { get; set; }
        public string TEAMTYPE { get; set; }
        public DateTime STARTDATE { get; set; }
        public double ESTDATE { get; set; }
        public double PASSDAYS { get; set; }
        public string RIGNAME { get; set; }
        public string OBJECTIVE { get; set; }
        public string WON { get; set; }


        public cls_Rig_operation_event()
        {

        }
    }

    public class cls_rig_spud
    {
        public string Well_id { get; set; }
        public string UWI { get; set; }
        public DateTime spudDate { get; set; }

    }

    public class cls_Drilling_team_Rig
    {
        public string Rig { get; set; }
        public string Team { get; set; }
        public cls_Drilling_team_Rig()
        {

        }
    }

    public class cls_downhole_equip
    {
        public string UWI { get; set; }
        public string PID { get; set; }
        public string WELL_ID { get; set; }
        public string WELLBORE_ID { get; set; }
        public DateTime INITIALDATE { get; set; }
        public DateTime FINALDATE { get; set; }
        public string EQUIPTYPE { get; set; }
        public double TOPDEPTH { get; set; }
        public double BOTTOMDEPTH { get; set; }
        public double OUTERDIAM { get; set; }
        public double INNERDIAM { get; set; }
        public double OFFSET { get; set; }
        public string DESCRIPTION { get; set; }
        public string REMARK { get; set; }
    }

    public class cls_deviation_survey
    {
        public string UWI { get; set; }
        public double SEQ_NO { get; set; }
        public double REAL_MD { get; set; }
        public double MD { get; set; }
        public double TVD { get; set; }
        public double DELTANS { get; set; }
        public double DELTAEW { get; set; }
        public double AZIMUTH { get; set; }
        public double INCLINATION { get; set; }
        public cls_deviation_survey()
        {

        }
    }
}