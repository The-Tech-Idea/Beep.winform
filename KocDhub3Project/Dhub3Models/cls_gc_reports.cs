using System;
using System.Collections.Generic;

namespace KOC.DHUB3.Models
{

    [Serializable()]
    public class cls_gc_reports
    {
        public string pGC { get; set; }
        public string pStart_date { get; set; }
        public string pEnd_date { get; set; }
        public string pSchema { get; set; }



        public cls_gc_reports()
        {

        }
    }

    [Serializable()]
    public class cls_outvaluewithdate
    {
        public string outvalue { get; set; }
        public string outdate { get; set; }
        public cls_outvaluewithdate()
        {

        }
    }

    [Serializable()]
    public class cls_whp_flp_date
    {
        public string whp { get; set; }
        public string flp { get; set; }
        public string start_time { get; set; }
        public cls_whp_flp_date()
        {

        }
    }

    [Serializable()]
    public class cls_beancheckreport
    {
        public string GC { get; set; }
        public string uwi { get; set; }
        public string facility_type { get; set; }
        public string Start_Time { get; set; }
        public string Choke_Side { get; set; }
        public string choke_status { get; set; }
        public string action_on_choke { get; set; }
        public string description { get; set; }
        public string inserted_by { get; set; }
        public bool RefershFlag = false;
        public cls_beancheckreport()
        {

        }
    }

    [Serializable()]
    public class cls_tmpBGLAB_Salt_In_Crude
    {

        public string GC { get; set; }
        public int Surface_Facility_s { get; set; }
        public string Facility_Id { get; set; }
        public int Stream_S { get; set; }
        public int oil_field_operation_S { get; set; }
        public string st_time { get; set; }
        public int General_Port_s { get; set; }
        public string Nick_Name { get; set; }
        public int Fluid_analysis_s { get; set; }
        public string Shift { get; set; }
        public string Remarks { get; set; }
        public string Salt { get; set; }
        public string BSW { get; set; }
        public string H2S { get; set; }
        public string Api { get; set; }
        public bool RefershFlag = false;
        public cls_tmpBGLAB_Salt_In_Crude()
        {

        }
    }

    [Serializable()]
    public class cls_incommer_report_staging
    {
        public string gc { get; set; }
        public int well_completion_s { get; set; }
        public string uwi { get; set; }
        public string facility_name { get; set; }
        public string facility_type { get; set; }
        public string mfl { get; set; }
        public string allowable { get; set; }
        public string reservoir { get; set; }
        public string header { get; set; }
        public string slot { get; set; }
        public string Current_Rate { get; set; }
        public string close_rate { get; set; }
        public string status { get; set; }
        public string status_date { get; set; }
        public string q_date { get; set; }
        public string start_time { get; set; }
        public string end_time { get; set; }
        public string choke { get; set; }
        public string whp { get; set; }
        public string flp { get; set; }
        public string salt { get; set; }
        public string wc { get; set; }
        public string wc_date { get; set; }
        public bool RefershFlag = false;
        public cls_incommer_report_staging()
        {

        }
    }

    [Serializable()]
    public class cls__header_input_report
    {
        public string gc { get; set; }
        public int well_completion_s { get; set; }
        public string uwi { get; set; }
        public string facility_name { get; set; }
        public string facility_type { get; set; }
        public string reservoir { get; set; }
        public string header { get; set; }
        public string slot { get; set; }
        public string mfl { get; set; }
        public string allowable { get; set; }
        public string Current_Rate { get; set; }
        public string close_rate { get; set; }
        public string status { get; set; }
        public string status_date { get; set; }
        public string Run_date;
        public string start_time { get; set; }
        public string end_time { get; set; }
        public string choke { get; set; }
        public string whp { get; set; }
        public string flp { get; set; }
        public string WHP_FLP_DATE { get; set; }
        public string salt { get; set; }
        public string h2s { get; set; }
        public string wc { get; set; }
        public string wc_date { get; set; }
        public string api_gravity { get; set; }
        public string api_date { get; set; }
        public bool RefershFlag = false;
        public cls__header_input_report()
        {

        }
    }

    [Serializable()]
    public class cls_completion_on_header
    {
        public string well_completion_s { get; set; }
        public int string_s { get; set; }
        public string uwi { get; set; }
        public string facility_type { get; set; }
        public string facility_name { get; set; }
        public string reservoir_id { get; set; }
        public string start_time { get; set; }
        public string end_time { get; set; }

        public cls_completion_on_header()
        {

        }

    }

    [Serializable()]
    public class cls_gc_Headers
    {
        public int surface_facility_s { get; set; }
        public string hdr { get; set; }
        public string gc { get; set; }
        public cls_gc_Headers()
        {

        }
    }

    [Serializable()]
    public class cls_gc_slots
    {
        public int surface_facility_s { get; set; }
        public int general_port_s { get; set; }
        public string slot { get; set; }
        public string gc { get; set; }
        public cls_gc_slots()
        {

        }
    }

    [Serializable()]
    public class cls_Comp_oper_status
    {
        public string status_type { get; set; }
        public string reason { get; set; }
        public DateTime? start_time { get; set; }
        public int? oil_field_operation_s;
        public int? facility_status_s;
        public cls_Comp_oper_status()
        {

        }
    }

    public class cls_well_data_monthly_report_connected_wells
    {
        public cls_well_data_monthly_report_connected_wells()
        {

        }
        public int well_completion_s { get; set; }
        public string uwi { get; set; }
        public string facility_type { get; set; }
        public string reservoir { get; set; }
        public DateTime? start_time { get; set; }
        public DateTime? end_time { get; set; }
        public string gc { get; set; }
        public string facility_name { get; set; }
        public int PORT_CONNECTION_S { get; set; }
        public int surface_facility_s { get; set; }
        public int string_s { get; set; }
    }

    [Serializable()]
    public class cls_Well_Data_monthly_report
    {
        public string uwi { get; set; }
        public string facility_type { get; set; }
        public string reservoir { get; set; }
        public string status { get; set; }
        public string reason_code { get; set; }
        public string choke_l { get; set; }
        public string choke_r { get; set; }
        public string choke { get; set; }
        public string choke_actual { get; set; }
        public string ch_date { get; set; }
        public string header_id { get; set; }
        public string slot_id { get; set; }
        public string mfl { get; set; }
        public string allowed { get; set; }
        public int? production { get; set; }
        public int? gor { get; set; }
        public string gor_date { get; set; }
        public int d1 { get; set; }
        public int d2 { get; set; }
        public int d3 { get; set; }
        public int d4 { get; set; }
        public int d5 { get; set; }
        public int d6 { get; set; }
        public int d7 { get; set; }
        public int d8 { get; set; }
        public int d9 { get; set; }
        public int d10 { get; set; }
        public int d11 { get; set; }
        public int d12 { get; set; }
        public int d13 { get; set; }
        public int d14 { get; set; }
        public int d15 { get; set; }
        public int d16 { get; set; }
        public int d17 { get; set; }
        public int d18 { get; set; }
        public int d19 { get; set; }
        public int d20 { get; set; }
        public int d21 { get; set; }
        public int d22 { get; set; }
        public int d23 { get; set; }
        public int d24 { get; set; }
        public int d25 { get; set; }
        public int d26 { get; set; }
        public int d27 { get; set; }
        public int d28 { get; set; }
        public int d29 { get; set; }
        public int d30 { get; set; }
        public int d31 { get; set; }
        public int? whp { get; set; }
        public int? flp { get; set; }
        public int? salt { get; set; }
        public int? wc { get; set; }
        public string wc_date { get; set; }
        public int well_completion_s { get; set; }
        public string status_date { get; set; }
        public string last_test_date { get; set; }
        public string activity_state { get; set; }
        public string facility_name { get; set; }
        public string choke_bean_status { get; set; }
        public string choke_bean_date { get; set; }
        public string LIFT_METHOD { get; set; }
        public List<HistoryDailyData> ProductionHistory { get; set; } = new List<HistoryDailyData>();
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string gc { get; set; }
        public int String_s { get; set; }
        public bool RefershFlag = false;
        public int mm;
        public int yyyy;


        public cls_Well_Data_monthly_report()
        {

        }

    }

    [Serializable()]
    public class cls_Well_closeOpen_Report_GC
    {

        public string uwi { get; set; }
        public string facility_type { get; set; }
        public string status_type { get; set; }
        public string start_time { get; set; }
        public string reason { get; set; }
        public string today { get; set; }
        public bool RefershFlag = false;
        public cls_Well_closeOpen_Report_GC()
        {

        }
    }

    [Serializable()]
    public class cls_GC_ChokeChange_data
    {
        public string gc { get; set; }
        public string uwi { get; set; }
        public int well_completion_s { get; set; }
        public string string_name { get; set; }
        public string reservoir { get; set; }
        public DateTime start_time { get; set; }
        public string From_left_choke_size { get; set; }
        public string From_right_choke_size { get; set; }
        public string left_choke_size { get; set; }
        public string right_choke_size { get; set; }
        public string created_by { get; set; }
        public string create_date { get; set; }
        public bool RefershFlag = false;
        public cls_GC_ChokeChange_data()
        {

        }
    }

    [Serializable()]
    public class cls_gc_chokechange_data_2
    {
        public string left_choke_size { get; set; }
        public string right_choke_size { get; set; }
        public string start_time { get; set; }
        public cls_gc_chokechange_data_2()
        {

        }
    }

    [Serializable()]
    public class cls_well_test_stats
    {
        public string uwi { get; set; }
        public string facility_type { get; set; }
        public string reservoir { get; set; }
        public string test_name { get; set; }
        public int Total_no_of_Tests { get; set; }
        public string RejectedTests { get; set; }
        public string today { get; set; }
        public bool RefershFlag = false;
        public cls_well_test_stats()
        {

        }
    }

    [Serializable()]
    public class cls_report_well_rerouting
    {

        public string WELL { get; set; }
        public string COMPLETION { get; set; }
        public string reservoir { get; set; }
        public string ZONE { get; set; }
        public string From_gc { get; set; }
        public string to_gc { get; set; }
        public string start_time { get; set; }
        public string end_time { get; set; }
        public string updated_by { get; set; }
        public string DATE_UPDATED { get; set; }
        public bool RefershFlag = false;
        // Public Property start_rep As String
        // Public Property end_rep As String
        // Public Property today As String
        public cls_report_well_rerouting()
        {

        }

    }

    [Serializable()]
    public class cls_scale_insp_report
    {
        public string GC { get; set; }
        public string uwi { get; set; }
        public string facility_type { get; set; }
        public string Start_Time { get; set; }
        public string Choke_Side { get; set; }
        public string choke_status { get; set; }
        public string action_on_choke { get; set; }
        public string description { get; set; }
        public string inserted_by { get; set; }
        public bool RefershFlag = false;
        public cls_scale_insp_report()
        {

        }

    }

    [Serializable()]
    public class cls_portable_vs_dcs_report
    {
        public string starttime { get; set; }
        public int DCSLQ { get; set; }
        public int DCSWC { get; set; }
        public int PortLQ { get; set; }
        public int PortWC { get; set; }
        public int TotalGor { get; set; }
        public string pStatus { get; set; }
        public bool RefershFlag = false;
        public cls_portable_vs_dcs_report()
        {

        }
    }

    [Serializable()]
    public class cls_survillanceclassreport
    {
        public string WellName { get; set; }
        public int? wc_s;
        public string service_status { get; set; }
        public string contractor { get; set; }
        public string GC { get; set; }
        public string pString { get; set; }
        public string Zone { get; set; }
        public string Requester_email { get; set; }
        public string Requester_koc_no { get; set; }
        public DateTime? service_status_date { get; set; }
        public DateTime? Requested_date { get; set; }
        public DateTime? Planned_date { get; set; }
        public string main_job_type { get; set; }
        public string service_remarks { get; set; }
        public string service_Type { get; set; }
        public string Objective { get; set; }
        public int cnt { get; set; }

        // Public Property uwi As String
        public DateTime start_time { get; set; }
        public int StopStart { get; set; }
        public string Remarks { get; set; }
        public string Wstring { get; set; }
        public cls_survillanceclassreport()
        {

        }

    }

    [Serializable()]
    public class cls_rigactivityreport
    {
        public string RIG_NAME { get; set; }
        public string WELLNAME { get; set; }
        public DateTime DATE_REPORT { get; set; }
        public string status_type { get; set; }
        public string DDR_REPORT { get; set; }
        public string DAYS_ON_LOCATION { get; set; }
        public string DAYS_FROM_SPUD { get; set; }
        public string NEXT_LOC { get; set; }
        public cls_rigactivityreport()
        {

        }
    }

    [Serializable()]
    public class cls_lastCloseOpenEvent
    {

        public string uwi { get; set; }
        public string reservoir { get; set; }
        public string facility_type { get; set; }
        public string status_type { get; set; }
        public DateTime event_time { get; set; }
        public string reason { get; set; }
        public int cnt { get; set; }
        public string field { get; set; }
        public double WC { get; set; }
        public double GOR { get; set; }
        public double LQ { get; set; }

        public cls_lastCloseOpenEvent()
        {

        }
    }

    [Serializable]
    public class cls_gc_allocation_report
    {
        public int DAY { get; set; }
        public double FBHP { get; set; }
        public double FLP { get; set; }
        public string GCID { get; set; }
        public double GOR { get; set; }
        public int HRS { get; set; }
        public double LQ { get; set; }
        public int MON { get; set; }
        public double OIL_RATE { get; set; }
        public double SBHP { get; set; }
        public string UWI { get; set; }
        public double WATER_RATE { get; set; }
        public double WC { get; set; }
        public int WCS { get; set; }
        public string WHP { get; set; }
        public string WHT { get; set; }
        public int YR { get; set; }
        public string PPDM_UWI { get; set; }
        public DateTime TheDate { get; set; }

        public cls_gc_allocation_report()
        {

        }
    }

    [Serializable()]
    public class cls_lastProductiondatareport
    {

        public DateTime start_time { get; set; }
        public DateTime end_time { get; set; }
        public int flowing_completions { get; set; }
        public int wetoil { get; set; }
        public int dryoil { get; set; }
        public decimal gc_factor { get; set; }
        public int EffWaterProduction { get; set; }
        public int OilProduction { get; set; }
        public int DISPATCH { get; set; }

        public cls_lastProductiondatareport()
        {

        }
    }

    [Serializable()]
    public class cls_wellsList
    {
        public cls_wellsList()
        {

        }
        public string uwi { get; set; }

    }

    [Serializable()]
    public class cls_chockchange_report
    {

        public string uwi { get; set; }
        public string string_name { get; set; }
        public string Reservoir { get; set; }
        public DateTime test_date { get; set; }
        public string lc_o { get; set; }
        public string rc_o { get; set; }
        public string lc_n { get; set; }
        public string rc_n { get; set; }
        public cls_chockchange_report()
        {

        }
        // "select gc,uwi ""Well Name"",string_name ""String"",reservoir ""Reservoir"",test_date ""Change Date"",lc_o ""Old L-Chk"",rc_o ""Old R-Chk"", lc_n ""New L-Chk"",rc_n ""New R-Chk"" from koc.chokechange where gc='" + QID + "'  and DATE_ENTERED between to_date('" + QDate + "','DD-MM-YYYY')-1 and to_date('" + QDate + "','DD-MM-YYYY') +1"
    }

    [Serializable()]
    public class cls_gcproductionreport
    {
        public DateTime start_time { get; set; }
        public decimal flowing_completions { get; set; }
        public decimal EFFLUENT_WATER_PRODUCED { get; set; }
        public decimal WASH_WATER_CONS { get; set; }
        // Public Property EFFLUENT_WATER_PRODUCED-    Public Property WASH_WATER_CONS
        public decimal SEPERATED_WATER
        {
            get
            {
                return EFFLUENT_WATER_PRODUCED - WASH_WATER_CONS;
            }

        }

        public decimal DISPOSED_TO_PIT { get; set; }
        // ,pd.EFFLUENT_WATER_PRODUCED-pd.DISPOSED_TO_PIT
        public decimal WaterInjected
        {
            get
            {
                return EFFLUENT_WATER_PRODUCED - DISPOSED_TO_PIT;
            }
        }

        public decimal oilvol { get; set; }
        public decimal wetoil { get; set; }
        public decimal dryoil { get; set; }
        public decimal dispatch { get; set; }


        public cls_gcproductionreport()
        {

        }
    }
    // Public Class CalculatedProductionHistory
    // Public Property CalculatedProduction As New List(Of ProductionCalculationData)
    // Public Sub New()

    // End Sub
    // End Class
    [Serializable()]
    public class ProductionCalculationData
    {
        public string GC { get; set; }
        public int WCS { get; set; }
        public string uwi { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public List<HistoryDailyData> ProdData { get; set; } = new List<HistoryDailyData>();
        public ProductionCalculationData()
        {

        }
    }

    public class TotalProdData
    {
        public TotalProdData()
        {

        }
        public string GC { get; set; }
        public string FieldID { get; set; }
        public string Reservoir { get; set; }
        public int DayoftheMonth { get; set; }
        public int Monthofyear { get; set; }
        public int Year { get; set; }
        public DateTime TheDate { get; set; }
        public double Oil { get; set; }
        public double Water { get; set; }
        public double Gas { get; set; }
        public double LossLQ { get; set; }

    }

    [Serializable()]
    public class HistoryDailyData
    {
        public HistoryDailyData()
        {

        }

        public string GC { get; set; }
        public int WCS { get; set; }
        public string uwi { get; set; }
        public string PPDM_WCS_UWI { get; set; }
        public string facility_type { get; set; }
        public string reservoir { get; set; }
        public int DayoftheMonth { get; set; }
        public int Monthofyear { get; set; }
        public int Year { get; set; }
        public double GOR { get; set; }
        public double WC { get; set; }
        public double LQ { get; set; }
        public double LossLQ { get; set; }

        public double RunningHrs { get; set; }
        public double Oil { get; set; }
        public double Water { get; set; }
        public double Gas { get; set; }
        public string header_id { get; set; }
        public string slot_id { get; set; }
        public DateTime TheDate { get; set; }
        // Public Property lsCloseOpen As New List(Of cls_lastCloseOpenEvent)

    }
}