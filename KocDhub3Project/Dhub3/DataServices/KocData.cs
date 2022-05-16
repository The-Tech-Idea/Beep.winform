using KOC.DHUB3.Analysis;
using KOC.DHUB3.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTechIdea.Beep;


namespace KOC.DHUB3.DataServices
{
    public class KocData
    {
        IDMEEditor DMEditor { get; set; }
        public KocData(IDMEEditor pDMEditor)
        {
            DMEditor = pDMEditor;

        }

        public string GC { get; set; }
        public string pStart_date { get; set; }
        public string pEnd_date { get; set; }
        public string pSchema { get; set; } = "KOC";
        public List<cls_file_lib> Files { get; set; }

        public List<cls_FinderGC> GCListDataList { get; set; } = new List<cls_FinderGC>();
        public List<cls_FinderField> FieldDataList { get; set; } = new List<cls_FinderField>();
        public List<cls_Finderwell> WellLatestDataList { get; set; } = new List<cls_Finderwell>();

        public DataTable PlannedWellsDataTable { get; set; } = new DataTable();
        public DataTable GISWellsDataTable { get; set; } = new DataTable();
        public DataTable WellLatestDataTable { get; set; } = new DataTable();

        // Public Property RTWells As New List(Of KOC_OPC_WELLS)
        public List<cls_ESP_DAILY_READING_report> ESPReadings { get; set; } = new List<cls_ESP_DAILY_READING_report>();
        public DataTable ContourTB { get; set; } = new DataTable();
        public DataTable ReservoirList { get; set; } = new DataTable();
        public DataTable LayerList { get; set; } = new DataTable();
        public List<Reservoir> Q8ReservoirList { get; set; } = new List<Reservoir>();
        public List<Layer> Q8LayerList { get; set; } = new List<Layer>();

        public List<cls_FinderGC> MyFacilityList { get; set; } = new List<cls_FinderGC>();
        public List<cls_FinderField> MyFIELDList { get; set; } = new List<cls_FinderField>();
        public List<cls_Finderwell> MyWellLatestDataList { get; set; } = new List<cls_Finderwell>();
        public List<Reservoir> MyRservoirList { get; set; } = new List<Reservoir>();
        public List<Layer> MyLayerList { get; set; } = new List<Layer>();



        public Dashboard DashBoards { get; set; }
        public string SelectedWells { get; set; } = "";
        public string SelectedCompletions { get; set; } = "";





        // ---------------------------------------------------------------------------
        public string[] Dateformats = new[] { "M/d/yyyy h:mm:ss tt", "M/d/yyyy h:mm tt", "MM/dd/yyyy hh:mm:ss", "M/d/yyyy h:mm:ss", "M/d/yyyy hh:mm tt", "M/d/yyyy hh tt", "M/d/yyyy h:mm", "M/d/yyyy h:mm", "MM/dd/yyyy hh:mm", "M/dd/yyyy hh:mm", "MM/d/yyyy HH:mm:ss.ffffff" };

    }
}
