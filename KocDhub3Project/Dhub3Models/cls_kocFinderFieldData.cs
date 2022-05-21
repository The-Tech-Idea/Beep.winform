using System;
using System.Collections.Generic;
using System.Data;



namespace KOC.DHUB3.Models
{

    public class cls_kocFieldData
    {
        public string GC { get; set; }
        public string pStart_date { get; set; }
        public string pEnd_date { get; set; }
        public string pSchema { get; set; } = "KOC";
        public List<cls_file_lib> Files { get; set; }
        public List<cls_FinderGC> GCListDataList { get; set; } = new List<cls_FinderGC>();
        public List<cls_FinderField> FieldDataList { get; set; } = new List<cls_FinderField>();
        public DataTable PlannedWellsDataTable { get; set; } = new DataTable();
        public DataTable GISWellsDataTable { get; set; } = new DataTable();
        public DataTable WellLatestDataTable { get; set; } = new DataTable();
        public List<cls_Finderwell> WellLatestDataList { get; set; } = new List<cls_Finderwell>();
        // Public Property RTWells As New List(Of KOC_OPC_WELLS)
        public List<cls_ESP_DAILY_READING_report> ESPReadings { get; set; } = new List<cls_ESP_DAILY_READING_report>();
      

        public DataTable ContourTB { get; set; } = new DataTable();
        public DataTable ReservoirList { get; set; } = new DataTable();
        public DataTable LayerList { get; set; } = new DataTable();
        public string SelectedWells { get; set; } = "";
        public string SelectedCompletions { get; set; } = "";


        public cls_kocFieldData()
        {
        }
       
        public class cls_fieldrep
        {
            public string Field_code { get; set; }
            public string Field_name { get; set; }

        }
    }
}