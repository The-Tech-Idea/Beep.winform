using System;
using System.Collections.Generic;

namespace KOC.DHUB3.Models.WellData
{
   
    public class PortableMultiRate
    {
        public string UWI;
        public Nullable<DateTime> START_TIME { get; set; }
        public string END_TIME { get; set; }
        public string FLOW_P_NO { get; set; }
        public string WellSTRING { get; set; }
        public string RESR_ID { get; set; }


        public string DURATION { get; set; }
        public string CONTRACTOR { get; set; }
        public string REPORT_NUMBER { get; set; }
        public string T_FLOW_PERIOD { get; set; }
        public string ACTIVITY_TYPE { get; set; }
        public string ACTUAL_CHOKE { get; set; }
        public string C_PRESS { get; set; }
        public string T_PRESS { get; set; }
        public string WHT { get; set; }
        public string FLP { get; set; }

        public string CRITICAL_FLOW { get; set; }
        public string F_DURATION { get; set; }
        public string TEST_CHOKE { get; set; }
        public string CHOKE_LC { get; set; }
        public string CHOKE_RC { get; set; }
        public string CHOKE_LT { get; set; }
        public string CHOKE_RT { get; set; }
        public string LEFT_CHOKE_SIZE { get; set; }
        public string RIGHT_CHOKE_SIZE { get; set; }
        public string LIQUID_RATE { get; set; }
        public string WATER_RATE { get; set; }
        public string REMARKS { get; set; }
        public string WATER_CUT { get; set; }
        public string TOTAL_GOR { get; set; }
        public string GAS_RATE { get; set; }
        public string HP_GOR { get; set; }
        public string SEP_PRESS { get; set; }
        public string SEP_TEMP { get; set; }
        public string LP_GOR { get; set; }
        public string FORMATION_GOR { get; set; }
        public string TOTAL_GLR { get; set; }
        public string INJECTION_GLR { get; set; }
        public string API { get; set; }
        public string SPECIFIC_GRAVITY { get; set; }
        public string SHRINKAGE_FACTOR { get; set; }
        public string WATER_SALINITY { get; set; }
        public string WELL_COMPLETION_S;
    }

    [Serializable()]
    public class PortableData
    {
        public int TEST_STAGE_S;
        public int OIL_FIELD_OPERATION_S;
        public int Well_Completion_s { get; set; }
        public Nullable<DateTime> start_time { get; set; }
        public string TEST_TYPE { get; set; }
        public int TEST_RATE { get; set; }
        public int WC { get; set; }
        public int GOR { get; set; }
        public int WHP { get; set; }
        public int FLP { get; set; }
        public int OILRATE { get; set; }
        public int GASRATE { get; set; }
        public string LEFT_CHOKE_SIZE { get; set; }
        public string RIGHT_CHOKE_SIZE { get; set; }
        public string CHOKE { get; set; }
        public PortableData()
        {
        }
    }

    [Serializable()]
    public class WaterCutData
    {
        public int WELL_COMPLETION_S;
        public string UWI { get; set; }
        public string FACILITY_TYPE { get; set; }
        public string ACTIVITY_TYPE { get; set; }
        public string ACTIVITY_NAME { get; set; }
        public Nullable<DateTime>  START_TIME { get; set; }
        public int? LIQUID_RATE { get; set; }
        public int? CASING_PRESSURE { get; set; }
        public int? TUBING_PRESSURE { get; set; }
        public int? FLOW_LINE_PRESSURE { get; set; }
        public string LEFT_CHOKE_SIZE { get; set; }
        public string RIGHT_CHOKE_SIZE { get; set; }
        public int WATER_RATE { get; set; }
        public int nominal_water_cut { get; set; }
        public int SALT { get; set; }
        public string TEST_TYPE { get; set; }
        public WaterCutData()
        {
        }
    }

    [Serializable()]
    public class DCSData
    {
        public int TEST_STAGE_S;
        public int OIL_FIELD_OPERATION_S;
        public Nullable<DateTime> start_time { get; set; }
        public string TEST_TYPE { get; set; }
        public int TEST_RATE { get; set; }
        public int WC { get; set; }
        public int GOR { get; set; }
        public int WHP { get; set; }
        public int FLP { get; set; }
        public int OILRATE { get; set; }
        public string LEFT_CHOKE_SIZE { get; set; }
        public string RIGHT_CHOKE_SIZE { get; set; }
        public string CHOKE { get; set; }
        public DCSData()
        {
        }
        public string BUSINESS_ASSOC_ID { get; set; }
    }

    [Serializable()]
    public class FluidAnalysisData
    {
        public int well_completion_s;
        public string uwi { get; set; }
        public string facility_type { get; set; }
        public Nullable<DateTime> wc_dt { get; set; }
        public string reservoir_id { get; set; }
        public Nullable<DateTime> start_time { get; set; }
        public int oil_field_operation_s { get; set; }
        public int pressure { get; set; }
        public int temperature { get; set; }
        public int api_gravity { get; set; }
        public int specific_gravity { get; set; }
        public int SALT { get; set; }
        public int SULPHUR { get; set; }
        public FluidAnalysisData()
        {
        }
    }

    [Serializable()]
    public class TestStageData
    {
        public int TEST_STAGE_S;
        public int OIL_FIELD_OPERATION_S;
        public DateTime? starttime { get; set; }
        public string TEST_TYPE { get; set; }
        public string TEST_RATE { get; set; }
        public int? WC { get; set; }
        public int? GOR { get; set; }
        public int? WHP { get; set; }
        public int? FLP { get; set; }
        public string LEFT_CHOKE_SIZE { get; set; }
        public string RIGHT_CHOKE_SIZE { get; set; }
        public string CHOKE { get; set; }
        public int WELL_COMPLETION_S { get; set; }
        public string UWI { get; set; }
        public TestStageData()
        {
        }
    }

    [Serializable()]
    public class StatusCls
    {
        public string status_type { get; set; }
        public string reason { get; set; }
        public Nullable<DateTime> start_time { get; set; }
        public int oil_field_operation_s;
        public int facility_status_s;
        public string NewStatus;
        public string NewStatusCode;
        public string NewStatusReason;
        public DateTime NewDate;
        public StatusCls()
        {
        }
    }

    [Serializable()]
    public class WellBasicDatacls
    {
        public WellBasicDatacls()
        {
        }
        public int well_completion_s { get; set; }
        public string uwi { get; set; }
        public string stringID { get; set; }
        public string string_name { get; set; }
        public string facility_type { get; set; }
        public string reservoir { get; set; }
        public int string_s { get; set; }
        public Nullable<DateTime> wc_start_time { get; set; }
    }

    [Serializable()]
    public class WellAllowedcls
    {
        public decimal liquid_volume { get; set; }
        public Nullable<DateTime> start_time { get; set; }
        public WellAllowedcls()
        {
        }
    }

    [Serializable()]
    public class WellLiftMethodcls
    {
        public string status_type { get; set; }
        public string Description { get; set; }
        public Nullable<DateTime> start_time { get; set; }
        public string NewLiftMethod { get; set; }
        public string NewDate { get; set; }
        public WellLiftMethodcls()
        {
        }
    }

    [Serializable()]
    public class WellSlotCls
    {
        public WellSlotCls()
        {
        }
        public int general_port_s { get; set; }
        public Nullable<DateTime> start_time { get; set; }
        public string facility_id { get; set; }
        public int slot_gp_s;
        public int port_connection_s;
        public string NewSlot = "";
        public Nullable<DateTime> NewDate;
    }

    [Serializable()]
    public class WellHeadercls
    {
        public Nullable<DateTime> start_time { get; set; }
        public string facility_id { get; set; }
        public int surface_facility_s { get; set; }
        public int port_connection_s { get; set; }
        public string NewHeader { get; set; }
        public Nullable<DateTime> NewDate { get; set; }
        public WellHeadercls()
        {
        }
    }

    [Serializable()]
    public class WellSCADAcls
    {
        public int oil_field_operation_s { get; set; }
        public Nullable<DateTime> start_time { get; set; }

        public WellSCADAcls()
        {
        }
    }

    [Serializable()]
    public class gasinjdata
    {
        public string uwi { get; set; }
        public string starttime { get; set; }
        public string reservoir_id { get; set; }
        public string Facilitystring { get; set; }
        public string inj_rate { get; set; }
        public string inj_pressure { get; set; }
        public string time_on_line { get; set; }
        public string mf_pressure { get; set; }
        public string dis_pressure { get; set; }
        public gasinjdata()
        {
        }
    }

    [Serializable()]
    public class FBHPclassreport
    {
        public int CONTAINING_ACT_S;
        public string ACTIVITY_TYPE { get; set; }
        public DateTime START_TIME { get; set; }
        public double EXTRAPOLATED_PRESSURE { get; set; }
        public double PRESSURE_DATUM { get; set; }
        public double PRESSURE { get; set; }
        public double depth { get; set; }
        public double GRADIENT { get; set; }
        public decimal TEMPERATURE { get; set; }
        public string DESCRIPTION { get; set; }
        public int WELL_COMPLETION_S;
        public string FACILITY_TYPE { get; set; }
        public string FACILITY_ID { get; set; }
        public FBHPclassreport()
        {
        }
    }

    [Serializable()]
    public class Workoverclassreport
    {
        public int TEST_STAGE_S;
        public int OIL_FIELD_OPERATION_S;

        public string TEST_TYPE { get; set; }
        public int TEST_RATE { get; set; }
        public int WC { get; set; }
        public int GOR { get; set; }
        public int WHP { get; set; }
        public int FLP { get; set; }
        public int OILRATE { get; set; }
        public string LEFT_CHOKE_SIZE { get; set; }
        public string RIGHT_CHOKE_SIZE { get; set; }
        public string CHOKE { get; set; }
        public string ACTIVITY_ID { get; set; }
        public DateTime START_TIME { get; set; }
        public DateTime END_TIME { get; set; }
        public string OPERATION_PURPOSE { get; set; }
        public string Objective { get; set; }
        public int WorkoverExist { get; set; } = 0;
        public DateTime ReadingDate { get; set; }
        public bool PostWorkoverReportExist { get; set; } = false;
        public int PostWorkoverReportid { get; set; }
        public Workoverclassreport()
        {
        }
    }

    [Serializable()]
    public class cls_ESP_DAILY_READING_report
    {
        public string WELL { get; set; } = "";
        public string GC { get; set; } = "";
        public Nullable<DateTime> INSTALLATION_DATE { get; set; }
        public Nullable<int> WELL_COMPLETION_S { get; set; }
        public Nullable<DateTime> READING_DATE_TIME { get; set; }
        public Nullable<DateTime> RECORD_ENTRY_DATE_TIME { get; set; }
        public Nullable<decimal> PI { get; set; }
        public Nullable<decimal> PD { get; set; }
        public Nullable<decimal> WHP { get; set; }
        public Nullable<decimal> TI { get; set; }
        public Nullable<decimal> TM { get; set; }
        public Nullable<decimal> FLP { get; set; }
        public Nullable<decimal> CURRENT_A { get; set; }
        public Nullable<decimal> CURRENT_B { get; set; }
        public Nullable<decimal> CURRENT_C { get; set; }
        public Nullable<decimal> VOLTAGE_AB { get; set; }
        public Nullable<decimal> VOLTAGE_BC { get; set; }
        public Nullable<decimal> VOLTAGE_CA { get; set; }
        public Nullable<decimal> FREQUENCY { get; set; }
        public Nullable<decimal> VIBRATION { get; set; }
        public string TANK_LEVEL { get; set; } = "";
        public string REMARKS { get; set; } = "";
        public string RECORD_STATUS { get; set; } = "";

        public cls_ESP_DAILY_READING_report()
        {
        }
    }

    [Serializable()]
    public class cls_WellActivitiescategories
    {
        public int CAT_ID { get; set; }
        public string CAT_NAME { get; set; }
        public int PARENT_ID { get; set; }
        public string CAT_TYPE { get; set; }
        public string CAT_APP { get; set; }
        public string CAT_ROOT { get; set; }
        public string AREA { get; set; }
        public cls_WellActivitiescategories()
        {
        }
    }

    [Serializable()]
    public class cls_well_activities_report
    {
        public int ID { get; set; }
        public string UWI { get; set; }
        public string RIG_OR_RIGLESS { get; set; }
        public string ACTIVITY_TYPE { get; set; }
        public string ACTIVITY_DETAIL { get; set; }
        public DateTime DATE_COMPLETED { get; set; }
        public int AAIOR { get; set; }
        public int COST { get; set; }
        public int EFFECIENCY { get; set; }
        public int PRODUCTIONWEDGE { get; set; }
        public string AREA { get; set; }
        public string FIELD { get; set; }
        public string GC { get; set; }
        public string RESERVOIR { get; set; }
        public string ENTERED_BY { get; set; }
        public DateTime ENTERED_DATE { get; set; }
        public string F_YEAR { get; set; }
        public string JOB_STATUS { get; set; }
        public string RESPE { get; set; }
        public string OBJECTIVE { get; set; }
        public string PRod_STRING { get; set; }
        public string RELEASELETTER { get; set; }
        public string HEADER { get; set; }
        public int PRIORITY { get; set; }
        public string PRODUCTION_TYPE { get; set; }
        public int BOPD { get; set; }
        public string PROGRAM { get; set; }
        public int PORTABLE { get; set; }
        public string TARGETZONE { get; set; }
        public string COMMENTS { get; set; }
        public string REPORT_TYPE { get; set; }
        public DateTime START_DATE { get; set; }
        public string RIG { get; set; }
        public string NEXTWELL { get; set; }
        public DateTime REPORT_DATE { get; set; }
        public int OTS_JOB_ID { get; set; }
        public DateTime TEST_COMPLETE_DATE { get; set; }
        public int HOPPER_SHORT_TERM { get; set; }
        public int HOPPER_LONG_TERM { get; set; }
        public DateTime CONNECTION_DATE { get; set; }
        public int ACTIVITY_TYPE_ID { get; set; }
        public int IS_CURRENT_ACTIVITY { get; set; }
        public int IS_IN_EVALUATION { get; set; }
        public string WELL_COMPLETION_S { get; set; }
        public DateTime ACTIVITY_PLAN_DATE { get; set; }
        public int DECLINE_RATE { get; set; }
        public DateTime ACTIVITY_START_DATE { get; set; }
        public DateTime ACTIVITY_COMPLETE_PLAN_DATE { get; set; }
        public int COMPLETION_STATUS_ESTIMATE { get; set; }
        public int BOPD_RESTORE { get; set; }
        public string WELL_TYPE { get; set; }
        public string APPROVAL_STATUS { get; set; }
        public string ACTIVITY_PARENT1 { get; set; }
        public string ACTIVITY_PARENT2 { get; set; }
        public string SUB_ACTIVITY { get; set; }
        public DateTime FLOWLINE_LAID_DATE { get; set; }
        public int X_COORDINATE { get; set; }
        public int Y_COORDINATE { get; set; }
        public DateTime ORIGINAL_PLAN_START_DATE { get; set; }
        public DateTime COST_DATE { get; set; }
        public string COST_SOURCE { get; set; }
        public DateTime PLAN_CONNECTION_DATE { get; set; }
        public int GAS_GAIN { get; set; }
        public int GAS_RESTORE { get; set; }
        public cls_well_activities_report()
        {
        }
    }

    [Serializable()]
    public class cls_image_arh
    {
        public string picimage { get; set; }
        public string PicType { get; set; }

        public cls_image_arh()
        {
        }
    }

    [Serializable()]
    public class cls_opc_unit_tag
    {
        public string WELL_NAME { get; set; }
        public decimal WELL_KEY { get; set; }
        public decimal AQ_TIME { get; set; }
        public DateTime ACQUISITION_DATE { get; set; }
        public decimal DATA_VALUE { get; set; }
        public string TAG_NAME { get; set; }
        public string TAG_DESC { get; set; }
        public cls_opc_unit_tag()
        {
        }
    }

    [Serializable()]
    public class cls_opc_tags_data
    {
        public List<cls_opc_unit_tag> IA_MOTOR { get; set; } = new List<cls_opc_unit_tag>();
        public List<cls_opc_unit_tag> IB_MOTOR { get; set; } = new List<cls_opc_unit_tag>();
        public List<cls_opc_unit_tag> IC_MOTOR { get; set; } = new List<cls_opc_unit_tag>();
        public List<cls_opc_unit_tag> VAB_MOTOR { get; set; } = new List<cls_opc_unit_tag>();
        public List<cls_opc_unit_tag> VBC_MOTOR { get; set; } = new List<cls_opc_unit_tag>();
        public List<cls_opc_unit_tag> VCA_MOTOR { get; set; } = new List<cls_opc_unit_tag>();
        public List<cls_opc_unit_tag> POWER_FACTOR { get; set; } = new List<cls_opc_unit_tag>();
        public List<cls_opc_unit_tag> VOLT_UNBAL { get; set; } = new List<cls_opc_unit_tag>();
        public List<cls_opc_unit_tag> CUR_UNBAL { get; set; } = new List<cls_opc_unit_tag>();
        public List<cls_opc_unit_tag> INTAKE_PRESSURE { get; set; } = new List<cls_opc_unit_tag>();
        public List<cls_opc_unit_tag> DISCH_PRESSURE { get; set; } = new List<cls_opc_unit_tag>();
        public List<cls_opc_unit_tag> INTAKE_TEMP { get; set; } = new List<cls_opc_unit_tag>();
        public List<cls_opc_unit_tag> MOTOR_TEMP { get; set; } = new List<cls_opc_unit_tag>();
        public List<cls_opc_unit_tag> THP { get; set; } = new List<cls_opc_unit_tag>();
        public List<cls_opc_unit_tag> FLP { get; set; } = new List<cls_opc_unit_tag>();
        public List<cls_opc_unit_tag> CHP { get; set; } = new List<cls_opc_unit_tag>();
        public List<cls_opc_unit_tag> GD { get; set; } = new List<cls_opc_unit_tag>();
        public List<cls_opc_unit_tag> H2S { get; set; } = new List<cls_opc_unit_tag>();
        public List<cls_opc_unit_tag> FL_m3_hr_1 { get; set; } = new List<cls_opc_unit_tag>();
        public List<cls_opc_unit_tag> FL_m3_hr_2 { get; set; } = new List<cls_opc_unit_tag>();
        public List<cls_opc_unit_tag> FL_m3_hr_3 { get; set; } = new List<cls_opc_unit_tag>();
        public List<cls_opc_unit_tag> UPST_PR_1 { get; set; } = new List<cls_opc_unit_tag>();
        public List<cls_opc_unit_tag> UPST_PR_2 { get; set; } = new List<cls_opc_unit_tag>();
        public cls_opc_tags_data()
        {
        }
    }

    [Serializable()]
    public class cls_ba
    {
        public string FIELD_CODE { get; set; }
        public double TOTOIL { get; set; }
        public double TOTWater { get; set; }
        public double TOTGAS { get; set; }
        public DateTime proddate { get; set; }
        public double ba_wc { get; set; }
        public double lq { get; set; }
        public int WELL_COMPLETION_S { get; set; }
        public cls_ba()
        {
        }
    }

    [Serializable()]
    public class cls_proddata
    {
        public double DAY { get; set; }
        public double FBHP { get; set; }
        public double FLP { get; set; }
        public string GCID { get; set; }
        public double GOR { get; set; }
        public double HRS { get; set; }
        public double MON { get; set; }
        public double OIL_RATE { get; set; }
        public double SBHP { get; set; }
        public string UWI { get; set; }
        public double WATER_RATE { get; set; }
        public double WC { get; set; }
        public double WCS { get; set; }
        public double YR { get; set; }
        public cls_proddata()
        {
        }
    }

    [Serializable()]
    public class cls_prepostdata
    {
        public int Completion_No { get; set; }
        public string Entered_Date { get; set; }
        public string Liquid_rate { get; set; }
        public string GOR { get; set; }
        public string WC { get; set; }
        public string SBHP { get; set; }
        public string WHP { get; set; }
        public string FBHP { get; set; }
        public string PI { get; set; }
        public string Perf { get; set; }
        public string ESP_TYPE { get; set; }
        public string CHOKE { get; set; }
        public cls_prepostdata()
        {
        }
    }

    [Serializable()]
    public class cls_WellCurrentGC
    {
        public string GC { get; set; }
        public string uwi { get; set; }
        public string FACILITY_TYPE { get; set; }
        public string STRING_NAME { get; set; }
        public string RESERVOIR { get; set; }
        public string ZONE { get; set; }
        public string start_time { get; set; }
        public string end_time { get; set; }
        public string created_by { get; set; }
        public string create_date { get; set; }
        public string updated_by { get; set; }
        public string last_update { get; set; }
        public int surface_facility_s { get; set; }
        public int port_connection_s { get; set; }
        public int string_s { get; set; }
        public int well_completion_s { get; set; }
        public int reservoir_s { get; set; }
        public string wc_start_time { get; set; }
        public string wc_end_time { get; set; }


        public cls_WellCurrentGC()
        {
        }
    }

    [Serializable()]
    public class cls_ots_dm_al_stopstart_events
    {
        public string uwi { get; set; }
        public DateTime start_time { get; set; }
        public int StopStart { get; set; }
        public string Remarks { get; set; }
        public string Wstring { get; set; }



        public cls_ots_dm_al_stopstart_events()
        {
        }
    }

    public class cls_ProductionPerLF
    {
        public cls_ProductionPerLF()
        {
        }
        public string RESERVOIR_ID { get; set; }
        public string FIELD_CODE { get; set; }
        public double BOPD { get; set; }
        public double BWPD { get; set; }
        public string STATUS { get; set; }
        public double Potential { get; set; }
        public string LF { get; set; }
        public int PRODUCING { get; set; } = 0;
        public Nullable<DateTime> updatedate { get; set; }
    }

    public class cls_ProductionForField
    {
        public cls_ProductionForField()
        {
        }
        public string RESERVOIR_ID { get; set; }
        public string FIELD_CODE { get; set; }
        public double ActualBOPD { get; set; }
        public double ActualBWPD { get; set; }
        public double lossBOPD { get; set; }
        public double lossBWPD { get; set; }
        public double IdealBOPD { get; set; }
        public string STATUS { get; set; }
        public double ActualPotential { get; set; }
        public double lossPotential { get; set; }
        public string LF { get; set; }
        public int PRODUCING { get; set; } = 0;
        public Nullable<DateTime> updatedate { get; set; }
    }

}
