using System;
using System.Collections.Generic;


namespace KOC.DHUB3.Models
{

  
    public class cls_Dashboard_data
    {

        public string FieldID { get; set; } = "";
        public string GCID { get; set; } = "";
        public string PPDMUWI { get; set; } = "";
        public string myUWI { get; set; } = "";
        public int WCS { get; set; } = 0;
        public string Wells { get; set; } = "";
        public string pStart_date { get; set; } = "";
        public string pEnd_date { get; set; } = "";
        public string Area { get; set; } = "";
        public string Res { get; set; } = "";
        public string Layer { get; set; } = "";
        public WELL_LATEST_DATA HighestH2SWell { get; set; } = new WELL_LATEST_DATA();
        public WELL_LATEST_DATA HighestAPIWell { get; set; } = new WELL_LATEST_DATA();
        public WELL_LATEST_DATA LowestAPIWell { get; set; } = new WELL_LATEST_DATA();
        public WELL_LATEST_DATA HighestSaltWell { get; set; } = new WELL_LATEST_DATA();
        public int TotalNoofESPWells { get; set; }
        public int TotalNoofINJWells { get; set; } // X for 
        public int TotalNoofGASINJWells { get; set; } // N for not

        public WELL_LATEST_DATA MaxTVDWell { get; set; } = new WELL_LATEST_DATA();
        public WELL_LATEST_DATA MinTVDWell { get; set; } = new WELL_LATEST_DATA();
        public WELL_LATEST_DATA MaxSulferDWell { get; set; } = new WELL_LATEST_DATA();
        public List<cls_stat_esp_failures_hist> ESP_Failures_hist { get; set; } = new List<cls_stat_esp_failures_hist>();
        public List<cls_stat_production_hist> Prod_hist { get; set; } = new List<cls_stat_production_hist>();
     

        public string DashType { get; set; } = "";

        public WELL_LATEST_DATA maxwellv { get; set; } = new WELL_LATEST_DATA();
        public WELL_LATEST_DATA minwellv { get; set; } = new WELL_LATEST_DATA();

        public WELL_LATEST_DATA maxWaterwellv { get; set; } = new WELL_LATEST_DATA();
        public WELL_LATEST_DATA minWaterwellv { get; set; } = new WELL_LATEST_DATA();

        public List<WELL_LATEST_DATA> top10maxwellv { get; set; } = new List<WELL_LATEST_DATA>();
        public List<WELL_LATEST_DATA> top10minwellv { get; set; } = new List<WELL_LATEST_DATA>();

        public List<WELL_LATEST_DATA> top10maxWaterwellv { get; set; } = new List<WELL_LATEST_DATA>();
        public List<WELL_LATEST_DATA> top10minWaterwellv { get; set; } = new List<WELL_LATEST_DATA>();

        public cls_Dashbaord_productionTotal ProductionTotal { get; set; } = new cls_Dashbaord_productionTotal();
        public List<cls_Dashbaord_productionTotalListValues> ProductionList { get; set; } = new List<cls_Dashbaord_productionTotalListValues>();
     

        public List<cls_Dashbaord_productionTotalListValues> ESPStatusList { get; set; } = new List<cls_Dashbaord_productionTotalListValues>();

        public cls_Dashboard_data()
        {

        }

    }

    [Serializable()]
    public class cls_DashboardList
    {
        public Dictionary<string, cls_Dashboard_data> DashBoards { get; set; } = new Dictionary<string, cls_Dashboard_data>();
        public cls_DashboardList()
        {

        }
    }

    public class cls_Dashbaord_productionTotal
    {
        public decimal Oil { get; set; }
        public decimal Water { get; set; }
        public decimal Gas { get; set; }
        public cls_Dashbaord_productionTotal()
        {

        }
    }

    public class cls_Dashbaord_productionTotalListValues
    {
        public string TypeName { get; set; }
        public int Production { get; set; }
        public System.Drawing.Color Color { get; set; }


        public cls_Dashbaord_productionTotalListValues()
        {

        }
        public cls_Dashbaord_productionTotalListValues(string pTypeName, int pProduction)
        {
            TypeName = pTypeName;
            Production = pProduction;
        }
        public cls_Dashbaord_productionTotalListValues(string pTypeName, int pProduction, System.Drawing.Color pcolor)
        {
            TypeName = pTypeName;
            Production = pProduction;
            Color = pcolor;
        }
    }

    public class cls_stat_production_hist
    {
        public int BOPD { get; set; }
        public int BWPD { get; set; }
        public string AREA { get; set; }
        public string FIELD_CODE { get; set; }
        public string CURRENT_GC { get; set; }
        public string RESERVOIR_ID { get; set; }
        public string ZONES { get; set; }
        public string LF { get; set; }
        public string MONTHYEAR { get; set; }
        public cls_stat_production_hist()
        {

        }
    }

    public class cls_stat_esp_failures_hist
    {
        public int FAILURES { get; set; }
        public string AREA { get; set; }
        public string FIELD_CODE { get; set; }
        public string CURRENT_GC { get; set; }
        public string RESERVOIR_ID { get; set; }
        public string ZONES { get; set; }
        public string MONTHYEAR { get; set; }
        public string TYPENAME { get; set; }
        public cls_stat_esp_failures_hist()
        {

        }
    }
}