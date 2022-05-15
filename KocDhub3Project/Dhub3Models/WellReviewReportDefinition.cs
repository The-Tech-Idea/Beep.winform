using KOC.DHUB3.Models;
using KOC.DHUB3.Models.WellData;
using KocSharedLib.KocClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOC.DHUB3.Models
{
    public class WellReviewReportDefinition
    {
        public WellReviewReportDefinition()
        {

        }
        public WELL_LATEST_DATA WellData { get; set; }
        public IEnumerable<WELL_TESTS> Tests { get; set; }
        public IEnumerable<WELL_HISTORY> Comments { get; set; }
        public WELL_TREE SchematicData { get; set; }
        public List<StatusCls> StatusHistory { get; set; } = new List<StatusCls>();
        public List<StatusCls> ESPStatusHistory { get; set; } = new List<StatusCls>();
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
        public List<Workoverclassreport> WorkoverList { get; set; } = new List<Workoverclassreport>();
        public List<cls_ots_dm_al_stopstart_events> rep_survillance_ALMS_StartStopreport { get; set; } = new List<cls_ots_dm_al_stopstart_events>();
    }
}
