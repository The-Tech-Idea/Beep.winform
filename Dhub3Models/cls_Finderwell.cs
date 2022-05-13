using System;
using System.Collections.Generic;

namespace KOC.DHUB3.Models
{
    
    public class cls_Finderwell
    {
        #region Properties
        // Public Property WCS As   Integer
        public List<StatusCls> StatusHistory { get; set; } = new List<StatusCls>();
        public List<StatusCls> ESPStatusHistory { get; set; } = new List<StatusCls>();
        public List<cls_file_lib> Files { get; set; }
        public List<WellAllowedcls> AllowedHistory { get; set; } = new List<WellAllowedcls>();
        public List<WellSlotCls> SlotHistory { get; set; } = new List<WellSlotCls>();
        public List<WellHeadercls> HeaderHistory { get; set; } = new List<WellHeadercls>();
        public List<PortableData> PortableDataList { get; set; } = new List<PortableData>();
        public List<PortableMultiRate> PortableMutliRateDataList { get; set; } = new List<PortableMultiRate>();
        public List<WaterCutData> WaterCutDataList { get; set; } = new List<WaterCutData>();
        public List<DCSData> DCSDataList { get; set; } = new List<DCSData>();
        public List<FluidAnalysisData> FluidAnalysisDataList { get; set; } = new List<FluidAnalysisData>();
        public List<TestStageData> TestStageDataList { get; set; } = new List<TestStageData>();
        public List<WellLiftMethodcls> LiftMethods { get; set; } = new List<WellLiftMethodcls>();
        public List<FBHPclassreport> FBHPList { get; set; } = new List<FBHPclassreport>();
        public List<FBHPclassreport> SBHPList { get; set; } = new List<FBHPclassreport>();
        public List<WellSCADAcls> SCADAHistory { get; set; } = new List<WellSCADAcls>();
        // Public Property RTTodayPerformace As New List(Of KOC_OPC_DATA)
        public List<Workoverclassreport> WorkoverList { get; set; } = new List<Workoverclassreport>();
        public List<cls_portable_vs_dcs_report> portable_vs_dcsHistory { get; set; } = new List<cls_portable_vs_dcs_report>();
        public List<cls_GC_ChokeChange_data> ChokeChangeDataList { get; set; } = new List<cls_GC_ChokeChange_data>();
        public List<cls_survillanceclassreport> rep_survillance_report { get; set; } = new List<cls_survillanceclassreport>();
        public List<cls_ots_dm_al_stopstart_events> rep_survillance_ALMS_StartStopreport { get; set; } = new List<cls_ots_dm_al_stopstart_events>();
        public List<cls_rigactivityreport> rep_RigAcivities_report { get; set; } = new List<cls_rigactivityreport>();
        public List<cls_ESP_DAILY_READING_report> rep_ESP_Reading_report { get; set; } = new List<cls_ESP_DAILY_READING_report>();
        public List<cls_prepostdata> rep_prepost_data_report { get; set; } = new List<cls_prepostdata>();
        public List<cls_image_arh> ListofImages { get; set; } = new List<cls_image_arh>();
        public List<cls_opc_unit_tag> OPC_DATA { get; set; } = new List<cls_opc_unit_tag>();
       
        public List<HistoryDailyData> Production_history { get; set; } = new List<HistoryDailyData>();
        public List<cls_Wide_workover> Wide_WorkOver_report { get; set; } = new List<cls_Wide_workover>();
        // Public Property ProductionBA As New List(Of ProductionPeriodData)
        // Public Property ProductionHistory As New List(Of cls_proddata)

        public List<IPRPoints> IPR { get; set; } = new List<IPRPoints>();
        public List<Decline_Case> DeclineCases { get; set; } = new List<Decline_Case>();
        public List<cls_ba> rep_ba { get; set; } = new List<cls_ba>();
        public string EDM_ID = "";
        public string MYSTATUS { get; set; } = "";
        public int STATUSIDX { get; set; } = 0;
        public string ESP_STATUS { get; set; } = "";
        public string ESP_STATUS_REASON { get; set; } = "";
        public DateTime ESP_STATUS_DATE { get; set; }
        public decimal OPC_KEY { get; set; }
        public string PPDM_WCS_UWI { get; set; } = "";
        public string FACILITY_TYPE { get; set; } = "";
        public string WCC_STATUS { get; set; } = "";
        public string FACILITY_ID { get; set; } = "";
        public int WELL_COMPLETION_S { get; set; }
        public string RESERVOIR_NAME { get; set; } = "";
        public string LAYER_NAME { get; set; } = "";
        public string FIELD_NAME { get; set; } = "";
        public string AREA { get; set; } = "";
        public string CR_STATUS { get; set; } = "";
        public decimal TVD { get; set; }
        public DateTime Spud_Date { get; set; }
        public int KBE { get; set; }
        public DateTime COMP_DATE { get; set; }
        public int DRILLERS_TD { get; set; }
        public string ZONES { get; set; } = "";
        public int GROUND_ELEVATION { get; set; }
        public int PLUGBACK_TD { get; set; }
        public int PORTABLE_TEST_STAGE_S { get; set; }
        public int DCS_TEST_STAGE_S { get; set; }
        public int SBHP_TEST_STAGE_S { get; set; }
        public int FBHP_TEST_STAGE_S { get; set; }
        public string PORTABLE_GC { get; set; } = "";
        public int PORTABLE_WHP { get; set; }
        public decimal PORTABLE_LIQUID_RATE { get; set; }
        public string PORTABLE_WH_CHOKE_SIZE { get; set; } = "";
        public int PORTABLE_FLOWSTATION_PRESS { get; set; }
        public string PORTABLE_GOR_REMARKS { get; set; } = "";
        public int PORTABLE_FLOW_LINE_PRESSURE { get; set; }
        public int PORTABLE_AVG_GAS_RATE { get; set; }
        public int PORTABLE { get; set; }
        public DateTime PORTABLE_DATE { get; set; }
        public string DCS_GC { get; set; } = "";
        public int DCS { get; set; }
        public DateTime DCS_DATE { get; set; }
        public int DCS_WHP { get; set; }
        public int DCS_LIQUID_RATE { get; set; }
        public string DCS_WH_CHOKE_SIZE { get; set; } = "";
        public int DCS_FLOWSTATION_PRESS { get; set; }
        public string DCS_GOR_REMARKS { get; set; } = "";
        public int DCS_FLOW_LINE_PRESSURE { get; set; }
        public int DCS_AVG_GAS_RATE { get; set; }
        public int WATER_CUT { get; set; }
        public DateTime WATER_CUT_DATE { get; set; }
        public int WATER_CUT_WHP { get; set; }
        public int WATER_CUT_FLP { get; set; }
        public string GC_CHK_GC { get; set; } = "";
        public string GC_CHK { get; set; } = "";
        public int GC_CHK_WHP { get; set; }
        public int GC_CHK_FLP { get; set; }
        public DateTime GC_CHK_DATE { get; set; }
        public string GC_PRESS_GC { get; set; } = "";
        public string GC_PRESS_CHK { get; set; } = "";
        public int GC_PRESS_WHP { get; set; }
        public int GC_PRESS_FLP { get; set; }
        public DateTime GC_PRESS_DATE { get; set; }
        public int H2S { get; set; }
        public int OIL_API { get; set; }
        public int SALT { get; set; }
        public int ALLOWABLE { get; set; }
        public decimal POTENIAL { get; set; }
        public string SBHP_REMARKS { get; set; } = "";
        public int SBHP_PRESSURE { get; set; }
        public int SBHP_PRESSURE_DATUM { get; set; }
        public int SBHP_TEMPERATURE { get; set; }
        public DateTime SBHP_DATE { get; set; }
        public int SBHP_GRADIANT { get; set; }
        public decimal FBHP_PRESSURE { get; set; }
        public decimal FBHP_TEMPERATURE { get; set; }
        public DateTime FBHP_DATE { get; set; }
        public int FBHP_PRESSURE_DATUM { get; set; }
        public string FBHP_DEPTH { get; set; } = "";
        public string FBHP_REMARKS { get; set; } = "";
        public int FBHP_GRADIANT { get; set; }
        public string UWI { get; set; } = "";
        public string HEADER { get; set; } = "";
        public string SLOT { get; set; } = "";
        public string CURRENT_GC { get; set; } = "";
        public int PORTABLE_WATER_CUT { get; set; }
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public string FACILITY_NAME { get; set; } = "";
        public string STATUS_TYPE { get; set; } = "";
        public DateTime STATUS_DATE { get; set; }
        public string STATUS_DESCRIPTION { get; set; } = "";
        public string STATUS_REASON { get; set; } = "";
        public int PROD_7 { get; set; }
        public int PROD_6 { get; set; }
        public int PROD_5 { get; set; }
        public int PROD_4 { get; set; }
        public int PROD_3 { get; set; }
        public int PROD_2 { get; set; }
        public int PROD_1 { get; set; }
        public int PROD_WATER_7 { get; set; }
        public int PROD_WATER_6 { get; set; }
        public int PROD_WATER_5 { get; set; }
        public int PROD_WATER_4 { get; set; }
        public int PROD_WATER_3 { get; set; }
        public int PROD_WATER_2 { get; set; }
        public int PROD_WATER_1 { get; set; }
        public int PROD_GAS_7 { get; set; }
        public int PROD_GAS_6 { get; set; }
        public int PROD_GAS_5 { get; set; }
        public int PROD_GAS_4 { get; set; }
        public int PROD_GAS_3 { get; set; }
        public int PROD_GAS_2 { get; set; }
        public int PROD_GAS_1 { get; set; }
        public string INJ { get; set; } = "";
        public int PRODUCING { get; set; } = 0;
        public int DCS_GOR_BEFORE { get; set; }
        public int PORTABLE_GOR_BEFORE { get; set; }
        public int SBHP_PRESSURE_BEFORE { get; set; }
        public int FBHP_PRESSURE_BEFORE { get; set; }
        public int WATERCUT_BEFORE { get; set; }
        public string CHOKE_BEFORE { get; set; } = "";
        public int MONTH_7 { get; set; }
        public int MONTH_6 { get; set; }
        public int MONTH_5 { get; set; }
        public int MONTH_4 { get; set; }
        public int MONTH_3 { get; set; }
        public int MONTH_2 { get; set; }
        public int MONTH_1 { get; set; }
        public decimal LIQUID_RATE { get; set; }
        public DateTime LIQUID_RATE_DATE { get; set; }
        public string CHOKE { get; set; } = "";
        public DateTime CHOKE_DATE { get; set; }
        public string ESP { get; set; } = "";
        public decimal DCS_OILRATE { get; set; }
        public decimal PORTABLE_OILRATE { get; set; }
        public decimal WC_OILRATE { get; set; }
        public decimal PRESSURE_OILRATE { get; set; }
        public decimal CHOKECHANGE_OILRATE { get; set; }
        public int MONTH_12 { get; set; }
        public int MONTH_11 { get; set; }
        public int MONTH_10 { get; set; }
        public int MONTH_09 { get; set; }
        public int MONTH_08 { get; set; }
        public int PROD_GAS_08 { get; set; }
        public int PROD_GAS_09 { get; set; }
        public int PROD_GAS_10 { get; set; }
        public int PROD_GAS_11 { get; set; }
        public int PROD_GAS_12 { get; set; }
        public int PROD_WATER_08 { get; set; }
        public int PROD_WATER_09 { get; set; }
        public int PROD_WATER_10 { get; set; }
        public int PROD_WATER_11 { get; set; }
        public int PROD_WATER_12 { get; set; }
        public int PROD_08 { get; set; }
        public int PROD_09 { get; set; }
        public int PROD_10 { get; set; }
        public int PROD_11 { get; set; }
        public int PROD_12 { get; set; }
        public string PROD_DATE_12 { get; set; } = "";
        public string PROD_DATE_11 { get; set; } = "";
        public string PROD_DATE_10 { get; set; } = "";
        public string PROD_DATE_09 { get; set; } = "";
        public string PROD_DATE_08 { get; set; } = "";
        public string PROD_DATE_07 { get; set; } = "";
        public string PROD_DATE_06 { get; set; } = "";
        public string PROD_DATE_05 { get; set; } = "";
        public string PROD_DATE_04 { get; set; } = "";
        public string PROD_DATE_03 { get; set; } = "";
        public string PROD_DATE_02 { get; set; } = "";
        public string PROD_DATE_01 { get; set; } = "";
        public decimal LATEST_GOR { get; set; }
        public DateTime LATEST_GOR_DATE { get; set; }
        public DateTime LATEST_WC_DATE { get; set; }
        public int LATEST_WC { get; set; }
        public decimal LATEST_OIL_RATE { get; set; }
        public decimal LATEST_WATER_RATE { get; set; }
        public int LATEST_HRS { get; set; }
        public decimal LATEST_PROD_RATE { get; set; }
        public decimal LATEST_GAS_RATE { get; set; }
        public DateTime LAST_PROD_DATE { get; set; }
        public decimal BEFORE_LIQUID_RATE { get; set; }
        public int PORTABLE_WC { get; set; }
        public int DCS_WC { get; set; }
        public int LATEST_WHP { get; set; }
        public int LATEST_FLP { get; set; }
        public string DRYORNOT { get; set; } = "";
        public string MFL { get; set; } = "";
        public int LATEST_SULFUR { get; set; }
        public DateTime LATEST_SULFUR_DT { get; set; }
        public string FIELD_CODE { get; set; } = "";
        public int LATEST_INJ_RATE { get; set; }
        public decimal BOPD { get; set; }
        public decimal BWPD { get; set; }
        public decimal WHP { get; set; }
        public decimal WHT { get; set; }
        public string GASINJ { get; set; } = "";
        public int F_AVG_BOPD { get; set; }
        public int F_AVG_BWIPD { get; set; }
        public int F_AVG_BWPD { get; set; }
        public int F_GET_CUM_OIL { get; set; }
        public int F_GET_CUM_WAT { get; set; }
        public int F_PAT_INJ { get; set; }
        public int F_PAT_PROD { get; set; }
        public string ORSTATUS { get; set; } = "";
        public string RESERVOIR_ID { get; set; } = "";
        public string LF { get; set; } = "";
        public string LFFixed { get; set; } = "";
        public string LF_DESCR { get; set; } = "";

        public DateTime START_TIME { get; set; }
        public DateTime END_TIME { get; set; }
        public int CONDENS7 { get; set; }
        public int CONDENS6 { get; set; }
        public int CONDENS5 { get; set; }
        public int CONDENS4 { get; set; }
        public int CONDENS3 { get; set; }
        public int CONDENS2 { get; set; }
        public int CONDENS1 { get; set; }
        public int NODE_X { get; set; }
        public int NODE_Y { get; set; }
        public decimal LATITUDE { get; set; }
        public decimal LONGITUDE { get; set; }
        public string SCADA { get; set; } = "";

        // ---
        // portable Data
        // ---
        public double SALINITY { get; set; }
        public double SHRINKAGE_FACTOR { get; set; }
        public double GAS_SPECIFIC_GRAVITY { get; set; }
        public double WATER_SPECIFIC_GRAVITY { get; set; }
        public double BSW { get; set; }
        public double CO2 { get; set; }
        public double H2S_IN_OIL { get; set; }
        public double H2S_IN_GAS { get; set; }
        public double CHLORIDE { get; set; }
        public double CURRENT_ESP { get; set; }
        public double ESP_PI { get; set; }
        public double CURRENT_PCP { get; set; }
        public double FREQUENCY { get; set; }
        public double RPM { get; set; }
        public double PCP_DISCHARGE_PRESS { get; set; }
        public double PCP_INTAKE_TEMP { get; set; }
        public double PCP_MOTOR_TEMP { get; set; }
        public double PCP_TORQUE { get; set; }
        public double ESP_FREQUENCY { get; set; }
        public double ESP_DISCHARGE_PRESS { get; set; }
        public double ESP_INTAKE_TEMP { get; set; }
        public double ESP_MOTOR_TEMP { get; set; }
        public double ESP_TORQUE { get; set; }
        public double ESP_VOLTAGE { get; set; }
        public double ESP_SRP { get; set; }
        public double GAS_LIFT_PRESSURE { get; set; }
        public double GAS_LIFT_RATE { get; set; }
        public double GAS_LIFT_TEMP { get; set; }
        public double GAS_LIFT_CHOKE { get; set; }
        // -----
        public string stringID { get; set; } = "";
        public string string_name { get; set; } = "";
        public int string_s { get; set; }
        public DateTime HeaderDate { get; set; }
        public DateTime SlotDate { get; set; }
        // Public Property ESPStatus As String = ""
        // Public Property ESPStatusReason As String = ""
        // Public Property ESPStatusDate As  Date
        public DateTime AllowableDate { get; set; }
        public clsLocation Location { get; set; }
        public string WELL_OWNERSHIP { get; set; }
        public DateTime? WELL_OWNERSHIP_DATE { get; set; }

        #region NEW VALUES
        public string NewLiftMethod { get; set; } = "";
        public string NewLiftMethodDate { get; set; } = "";
        public string NewStatus { get; set; } = "";
        public string NewStatusCode { get; set; } = "";
        public string NewStatusReason { get; set; } = "";
        public DateTime NewStatusDate { get; set; }
        public string NewSlot { get; set; } = "";
        public DateTime NewSlotDate { get; set; }
        public string NewHeader { get; set; } = "";
        public DateTime NewHeaderDate { get; set; }

        #endregion
        #endregion

        public cls_Finderwell()
        {
        }
        public cls_Finderwell(int pWcs, string puwi)
        {
            WELL_COMPLETION_S = pWcs;

            UWI = puwi;

        }
    }

    [Serializable()]
    public class PortableMultiRate
    {
        public string UWI;
        public string START_TIME { get; set; }
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
        public DateTime? start_time { get; set; }
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
        public object UWI { get; set; }
        public object FACILITY_TYPE { get; set; }
        public object ACTIVITY_TYPE { get; set; }
        public object ACTIVITY_NAME { get; set; }
        public object START_TIME { get; set; }
        public object LIQUID_RATE { get; set; }
        public object CASING_PRESSURE { get; set; }
        public object TUBING_PRESSURE { get; set; }
        public object FLOW_LINE_PRESSURE { get; set; }
        public object LEFT_CHOKE_SIZE { get; set; }
        public object RIGHT_CHOKE_SIZE { get; set; }
        public object WATER_RATE { get; set; }
        public object nominal_water_cut { get; set; }
        public object SALT { get; set; }
        public object TEST_TYPE { get; set; }
        public WaterCutData()
        {

        }
    }

    [Serializable()]
    public class DCSData
    {
        public int TEST_STAGE_S;
        public int OIL_FIELD_OPERATION_S;
        public DateTime? start_time { get; set; }
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
        public DateTime? wc_dt { get; set; }
        public string reservoir_id { get; set; }
        public DateTime? start_time { get; set; }
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
        public object TEST_STAGE_S;
        public object OIL_FIELD_OPERATION_S;
        public object starttime { get; set; }
        public object TEST_TYPE { get; set; }
        public object TEST_RATE { get; set; }
        public object WC { get; set; }
        public object GOR { get; set; }
        public object WHP { get; set; }
        public object FLP { get; set; }
        public object LEFT_CHOKE_SIZE { get; set; }
        public object RIGHT_CHOKE_SIZE { get; set; }
        public object CHOKE { get; set; }
        public object WELL_COMPLETION_S { get; set; }
        public object UWI { get; set; }
        public TestStageData()
        {

        }
    }

    [Serializable()]
    public class StatusCls
    {
        public string status_type { get; set; }
        public string reason { get; set; }
        public DateTime? start_time { get; set; }
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
        public DateTime? wc_start_time { get; set; }
    }

    [Serializable()]
    public class WellAllowedcls
    {
        public decimal liquid_volume { get; set; }
        public DateTime? start_time { get; set; }
        public WellAllowedcls()
        {

        }
    }

    [Serializable()]
    public class WellLiftMethodcls
    {
        public string status_type { get; set; }
        public string Description { get; set; }
        public DateTime? start_time { get; set; }
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
        public DateTime? start_time { get; set; }
        public string facility_id { get; set; }
        public int slot_gp_s;
        public int port_connection_s;
        public string NewSlot = "";
        public DateTime? NewDate;
    }

    [Serializable()]
    public class WellHeadercls
    {
        public DateTime? start_time { get; set; }
        public string facility_id { get; set; }
        public int surface_facility_s { get; set; }
        public int port_connection_s { get; set; }
        public string NewHeader { get; set; }
        public DateTime? NewDate { get; set; }
        public WellHeadercls()
        {

        }
    }

    [Serializable()]
    public class WellSCADAcls
    {
        public int oil_field_operation_s { get; set; }
        public DateTime? start_time { get; set; }

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
        public DateTime? INSTALLATION_DATE { get; set; }
        public int? WELL_COMPLETION_S { get; set; }
        public DateTime? READING_DATE_TIME { get; set; }
        public DateTime? RECORD_ENTRY_DATE_TIME { get; set; }
        public decimal? PI { get; set; }
        public decimal? PD { get; set; }
        public decimal? WHP { get; set; }
        public decimal? TI { get; set; }
        public decimal? TM { get; set; }
        public decimal? FLP { get; set; }
        public decimal? CURRENT_A { get; set; }
        public decimal? CURRENT_B { get; set; }
        public decimal? CURRENT_C { get; set; }
        public decimal? VOLTAGE_AB { get; set; }
        public decimal? VOLTAGE_BC { get; set; }
        public decimal? VOLTAGE_CA { get; set; }
        public decimal? FREQUENCY { get; set; }
        public decimal? VIBRATION { get; set; }
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
        public DateTime? updatedate { get; set; }

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
        public DateTime? updatedate { get; set; }

    }
}