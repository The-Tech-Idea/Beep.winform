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
;




        public List<cls_hr_lov> Rep_ListofFiles { get; set; } = new List<cls_hr_lov>();
        public List<cls_gcproductionreport> Stat_gcproduction_report { get; set; } = new List<cls_gcproductionreport>();
        public List<cls_lastProductiondatareport> Stat_lastProductiondata_report { get; set; } = new List<cls_lastProductiondatareport>();
        public List<cls_rigactivityreport> Stat_rigactivityreport { get; set; } = new List<cls_rigactivityreport>();
        public List<cls_survillanceclassreport> Stat_survillanceclass_report { get; set; } = new List<cls_survillanceclassreport>();
        public List<cls_lastCloseOpenEvent> Stat_lastCloseOpenEvent_report { get; set; } = new List<cls_lastCloseOpenEvent>();
        public List<cls_chockchange_report> Stat_chockchange_report { get; set; } = new List<cls_chockchange_report>();
        public List<cls_Area_Stat> Stat_Capacity_Area_Report { get; set; } = new List<cls_Area_Stat>();
        public List<cls_Area_Stat> Hist_Capacity_Area_Report { get; set; } = new List<cls_Area_Stat>();
        // Dashboard
        public List<cls_survillanceclassreport> Stat_survillanceclass_reportStats { get; set; } = new List<cls_survillanceclassreport>();
        public List<cls_survillanceclassreport> Stat_survillanceclass_reportStatsContractorstats { get; set; } = new List<cls_survillanceclassreport>();
        public List<cls_lastCloseOpenEvent> Stat_lastCloseOpenEvent_reportdataStatsbyField { get; set; } = new List<cls_lastCloseOpenEvent>();
        public List<cls_lastCloseOpenEvent> Stat_lastCloseOpenEvent_reportdataStatsbyres { get; set; } = new List<cls_lastCloseOpenEvent>();
        public List<cls_chockchange_report> Stat_chockchange_reportStats { get; set; } = new List<cls_chockchange_report>();
        public List<cls_ProductionPerLF> stat_ProductionPerFieldBasedonLF { get; set; }
        public List<cls_ProductionPerLF> stat_ProductionPerFacilityBasedonLF { get; set; }
        public List<cls_ProductionForField> stat_FieldProductionHist { get; set; } = new List<cls_ProductionForField>();
        // ---------------------------------------------------------------------------
        public string[] Dateformats = new[] { "M/d/yyyy h:mm:ss tt", "M/d/yyyy h:mm tt", "MM/dd/yyyy hh:mm:ss", "M/d/yyyy h:mm:ss", "M/d/yyyy hh:mm tt", "M/d/yyyy hh tt", "M/d/yyyy h:mm", "M/d/yyyy h:mm", "MM/dd/yyyy hh:mm", "M/dd/yyyy hh:mm", "MM/d/yyyy HH:mm:ss.ffffff" };

    }
}
