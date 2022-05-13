using System;
using System.Collections.Generic;


namespace KOC.DHUB3.Models
{

    [Serializable()]
    public class cls_FinderGC
    {

        public string GC { get; set; } = "";
        public string GC_finder_ID { get; set; } = "";
        public string facility_id { get; set; }
        public int Surface_Facility_s { get; set; }
        public string pEnd_date { get; set; }
        public string pSchema { get; set; }
        public string facility_name { get; set; }

        public List<cls_file_lib> Files { get; set; }
        public List<cls_beancheckreport> rep_BeanCheck_report { get; set; } = new List<cls_beancheckreport>();
        public List<cls__header_input_report> rep_HeaderInput_report { get; set; } = new List<cls__header_input_report>();
        public List<cls_Well_Data_monthly_report> rep_Well_Data_monthly_report { get; set; } = new List<cls_Well_Data_monthly_report>();
        public List<cls_Well_closeOpen_Report_GC> rep_Well_CloseOpen_Report { get; set; } = new List<cls_Well_closeOpen_Report_GC>();
        public List<cls_GC_ChokeChange_data> rep_ChockChange_report { get; set; } = new List<cls_GC_ChokeChange_data>();
        public List<cls_well_test_stats> rep_WellTest_statistics_report { get; set; } = new List<cls_well_test_stats>();
        public List<cls_report_well_rerouting> rep_Well_rerouting_report { get; set; } = new List<cls_report_well_rerouting>();
        public List<cls_incommer_report_staging> rep_Incommer_SLOT_report { get; set; } = new List<cls_incommer_report_staging>();
        public List<cls_scale_insp_report> rep_Inspection_report { get; set; } = new List<cls_scale_insp_report>();
        public List<cls_survillanceclassreport> rep_survillance_report { get; set; } = new List<cls_survillanceclassreport>();
        public List<cls_wellsList> rep_newoldConnectedWells_report { get; set; } = new List<cls_wellsList>();
        public List<cls_rigactivityreport> rep_RigAcivities_report { get; set; } = new List<cls_rigactivityreport>();
        public List<cls_lastCloseOpenEvent> rep_lastcloseopen_report { get; set; } = new List<cls_lastCloseOpenEvent>();
        public List<cls_lastProductiondatareport> rep_lastproduction_report { get; set; } = new List<cls_lastProductiondatareport>();
        public List<cls_gc_allocation_report> rep_allocation_report { get; set; } = new List<cls_gc_allocation_report>();
        public List<cls_chockchange_report> rep_lastChokeChange_report { get; set; } = new List<cls_chockchange_report>();
        public List<cls_gcproductionreport> rep_Last30Daysproduction_report { get; set; } = new List<cls_gcproductionreport>();
        // Public Property rep_ProductionPeriods As New List(Of ProductionPeriodData)
        // Public Property rep_ProductionBA As New List(Of GCProductionData)
        public List<ddpheater_daily_report> rep_ddpheater_daily_report { get; set; } = new List<ddpheater_daily_report>();
        public List<ddptrain_daily_report> rep_ddptrain_daily_report { get; set; } = new List<ddptrain_daily_report>();
        public List<cru_daily_report> rep_cru_daily_report { get; set; } = new List<cru_daily_report>();
        public List<gc_daily_report> rep_gc_daily_report { get; set; } = new List<gc_daily_report>();
        public List<cls_survillanceclassreport> rep_survillanceclassreport { get; set; } = new List<cls_survillanceclassreport>();
        public List<cls_Wide_workover> Wide_WorkOver_report { get; set; } = new List<cls_Wide_workover>();
        
        public string w_list = "";
        public string Area { get; set; }
        public List<SurfaceFacility> GC_IN_SURFACE_FACILITY { get; set; } = new List<SurfaceFacility>();
        public List<GeneralPort> GC_IN_INOUTSTOCKPORTS { get; set; } = new List<GeneralPort>();
        public List<cls_Finderwell> ConnectedWells { get; set; } = new List<cls_Finderwell>();
       
        public bool RefershFlag = false;
        public List<ProductionCalculationData> CalculatedProduction { get; set; } = new List<ProductionCalculationData>();
        public bool RefershFlag_rep_BeanCheck_report = false;
        public bool RefershFlag_rep_HeaderInput_report = false;
        public bool RefershFlag_rep_Well_Data_monthly_report = false;
        public bool RefershFlag_rep_Well_CloseOpen_Report = false;
        public bool RefershFlag_rep_ChockChange_report = false;
        public bool RefershFlag_rep_WellTest_statistics_report = false;
        public bool RefershFlag_rep_Well_rerouting_report = false;
        public bool RefershFlag_rep_Incommer_SLOT_report = false;
        public bool RefershFlag_rep_Inspection_report = false;


        public cls_FinderGC(string GCID)
        {
            GC = GCID;

        }
        public cls_FinderGC()
        {

        }
        // This method is called by the Set accessor of each property. 
        // The CallerMemberName attribute that is applied to the optional propertyName 
        // parameter causes the property name of the caller to be substituted as an argument. 




    }

    [Serializable()]
    public class Reservoir
    {
        public string Reservoir_ID { get; set; }
        public string Reservoir_Name { get; set; }

        public Reservoir()
        {

        }
    }

    [Serializable()]
    public class Layer
    {
        public string RESERVOIR_ID { get; set; }
        public string Layer_Name { get; set; }

        public Layer()
        {

        }
    }

    [Serializable()]
    public class SurfaceFacility
    {
        public string FACILITY_ID { get; set; }
        public string FACILITY_TYPE { get; set; }
        public int SURFACE_FACILITY_S { get; set; }
        public DateTime? END_TIME { get; set; }
        public SurfaceFacility()
        {

        }
    }

    [Serializable()]
    public class GeneralPort
    {
        public string FACILITY_ID { get; set; }
        public string FACILITY_TYPE { get; set; }
        public int GENERAL_PORT_S { get; set; }
        public DateTime? END_TIME { get; set; }
        public GeneralPort()
        {

        }
    }

    [Serializable()]
    public class ddpheater_daily_report
    {
        public string CATALOG { get; set; }
        public int DDP_S { get; set; }
        public int HEATER { get; set; }
        public int ID { get; set; }
        public DateTime ISSUEDATE { get; set; }

        public ddpheater_daily_report()
        {

        }
    }

    [Serializable()]
    public class ddptrain_daily_report
    {
        public string CATALOG { get; set; }
        public int DDP_S { get; set; }
        public int ID { get; set; }
        public DateTime ISSUEDATE { get; set; }
        public int SALTPTB { get; set; }
        public int TRAINCIRCULATION { get; set; }
        public int TRAINPROCESS { get; set; }

        public ddptrain_daily_report()
        {

        }
    }

    [Serializable()]
    public class cru_daily_report
    {
        public string AREA { get; set; }
        public int BBLS { get; set; }
        public string CRU_ID { get; set; }
        public string GC_ID { get; set; }
        public int HRS { get; set; }
        public int ID { get; set; }
        public DateTime ISSUEDATE { get; set; }
        public string REMARKS { get; set; }

        public cru_daily_report()
        {

        }
    }

    [Serializable()]
    public class gc_daily_report
    {
        public int API { get; set; }
        public int API_H { get; set; }
        public int API_L { get; set; }
        public int API_M { get; set; }
        public int DISPATCHES { get; set; }
        public int DISPATCHES_H { get; set; }
        public int DISPATCHES_L { get; set; }
        public int DISPATCHES_M { get; set; }
        public string GCNO { get; set; }
        public DateTime ISSUEDATE { get; set; }
        public string OPERATOR_ID { get; set; }
        public int PUMPHR1 { get; set; }
        public int PUMPHR2 { get; set; }
        public int PUMPHR3 { get; set; }
        public int PUMPHR4 { get; set; }
        public int PUMP_VSM_HRS1 { get; set; }
        public int PUMP_VSM_HRS2 { get; set; }
        public int PUMP_VSM_HRS3 { get; set; }
        public int PUMP_VSM_HRS4 { get; set; }
        public string REMARKS { get; set; }
        public int SALT { get; set; }
        public int SALT_H { get; set; }
        public int SALT_L { get; set; }
        public int SALT_M { get; set; }
        public int STOCK { get; set; }
        public int STOCK_H { get; set; }
        public int STOCK_L { get; set; }
        public int STOCK_M { get; set; }
        public int SURFACE_FACILITY_S { get; set; }

        public gc_daily_report()
        {

        }
    }
}