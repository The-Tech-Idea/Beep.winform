using KOC.DHUB3.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dhub3.DataServices
{
    public interface IDataRepo
    {
      
        string DataSourcename { get; }
     
        List<cls_FinderField> FieldDataList { get; set; }
        List<cls_FinderGC> GCListDataList { get; set; }
        string pEnd_date { get; set; }
        string pStart_date { get; set; }
        List<cls_RESERVOIR_LIST> ReservoirList { get; set; }
        string SelectedCompletions { get; set; }
        string SelectedWells { get; set; }
        List<WELL_LATEST_DATA> WellLatestList { get; set; }

        cls_gc_chokechange_data_2 CompletionChokeChange_byTestDate(int v_wcs, string testdate);
        cls_Comp_oper_status CompletionsOperationalStatus(int v_wcs);
        int Completion_Allowed(int v_wcs);
        cls_outvaluewithdate Completion_BeanStatus(int v_wcs);
        cls_outvaluewithdate Completion_Choke_left(int v_wcs);
        cls_outvaluewithdate Completion_Choke_Right(int v_wcs);
        cls_outvaluewithdate Completion_Concentration_Fluids(int v_wcs, string Material_type);
        cls_outvaluewithdate Completion_GOR(int v_wcs);
        cls_outvaluewithdate Completion_GOR_AfterStartDate(int v_wcs);
        string Completion_LiftingMethod(int v_wcs);
        cls_outvaluewithdate Completion_LiquidRate(int v_wcs);
        cls_outvaluewithdate Completion_LiquidRate_AfterStartDate(int v_wcs);
        IEnumerable<cls_portable_vs_dcs_report> Completion_PortablevsDCS(int v_wcs);
        cls_outvaluewithdate Completion_WaterCut(int v_wcs);
        cls_outvaluewithdate Completion_WaterCut_AfterStartDate(int v_wcs);
        cls_whp_flp_date Completion_Whp_Flp(int v_wcs);
        IEnumerable<WellAllowedcls> GetAllowed(int WCS);
        IEnumerable<cls_ots_dm_al_stopstart_events> GetALMStartStopdata(string pUWI);
        IEnumerable<cls_ba> GetBAData(int v_wcs);
        IEnumerable<WELL_TREE> GetCurrentWellTree(string puwi);
        IEnumerable<WELL_TREE> GetCurrentWellTree_NotActive(string puwi);
        IEnumerable<WELL_TREE> GetCurrentWellTree_WO_DATE(string puwi, string pend_date);
        IEnumerable<CasePortableData> GetDCAAvgPortableTestDataForArea(string AreaCode);
        IEnumerable<CasePortableData> GetDCAavgPortableTestDataForArea2YearsAgo(string AreaCode);
        CasePortableData GetDCAFromWellLatestDataPortableTestDataForArea(string AreaCode, int wcs);
        CasePortableData GetDCAFromWellLatestDataPortableTestDataForField(string FieldCode, int wcs);
        IEnumerable<CasePortableData> GetDCAMaxPortableTestDataForArea2YearsAgo(string AreaCode);
        IEnumerable<CasePortableData> GetDCAMaxPortableTestDataForField2YearsAgo(string FieldCode);
        IEnumerable<CasePortableData> GetDCAMinFromWellLatestDataPortableTestDataForArea(string AreaCode);
        IEnumerable<CasePortableData> GetDCAMinPortableTestDataForArea(string AreaCode);
        IEnumerable<CasePortableData> GetDCAPortableTestData(int wcs);
        IEnumerable<CasePortableData> GetDCAPortableTestDataForArea(string AreaCode);
        IEnumerable<CasePortableData> GetDCAPortableTestDataForField(string FLD_CODE);
        IEnumerable<DCSData> GetDCSTestData(int wcs);
        string GetESP(int UWI);
        IEnumerable<StatusCls> GetESPStatus(int WCS);
        List<WELL_LATEST_DATA> GetFacilityWells(string pFacilityId);
        IEnumerable<FBHPclassreport> GetFBHPData(int wcs);
        IEnumerable<FBHPclassreport> GetFBHPDataForFieldandRes(string FldID, string resid);
        List<WELL_LATEST_DATA> GetFieldWells(string pfldid);
        IEnumerable<FluidAnalysisData> GetFuildAnalysis(int wcs);
        IEnumerable<cls_WellCurrentGC> GetGCWELL(int pwcs);
        IEnumerable<WellHeadercls> GetHeader(int string_s);
        IEnumerable<WellLiftMethodcls> GetLiftMethod(int WCS);
        string GetMFL(int v_wcs);
        IEnumerable<cls_survillanceclassreport> GetOTSALMSEventsdata(string pUWI);
        IEnumerable<PortableData> GetPortableTestData(int wcs);
        IEnumerable<PortableMultiRate> GetPortableTestMultiRateData(int wcs);
        IEnumerable<cls_proddata> GetProdData(string puwi, int pwcs, int pmonths);
        IEnumerable<FBHPclassreport> GetSBHPData(int wcs);
        IEnumerable<FBHPclassreport> GetSBHPDataForFieldandRes(string FldID, string resid);
        IEnumerable<WellSCADAcls> GetSCADA(int WCS);
        IEnumerable<WellSlotCls> GetSlot(int string_s);
        IEnumerable<StatusCls> GetStatus(int WCS);
        IEnumerable<StatusCls> GetStatusatDate(int WCS, string pdate);
        IEnumerable<TestStageData> GetTestStageData(int wcs);
        IEnumerable<WaterCutData> GetWaterCutTestData(int wcs);
        WELL_LATEST_DATA GetWell(int pwell_completion_id);
        WELL_LATEST_DATA GetWell(string puwi);
        IEnumerable<WellBasicDatacls> GetWellBasicInfo(string pUWI);
        string GetWellDeviation(string puwi);
        IEnumerable<WELL_DIR_SRVY_PTS> GetWellDirSRVYPTS(string puwi);
        IEnumerable<cls_ESP_DAILY_READING_report> GetWellESPReadingData(string puwi);
        IEnumerable<cls_ESP_DAILY_READING_report> GetWellESPReadingData(string puwi, string startdate, string enddate);
        cls_prepostdata GetWellPrePostData(int v_wcs, string pdate, string cond);
        IEnumerable<cls_rigactivityreport> GetWellRigActivitesfordata(string pUWI);
        IEnumerable<cls_survillanceclassreport> GetWellSurvillancedata(string pUWI);
        IEnumerable<WELL_TREE> GetWellTree_w_EndDate(string puwi, string pend_date);
        IEnumerable<WELL_TREE> GetWellTree_w_FacilityType(string puwi, string pFACILITY_TYPE);
        Task<IEnumerable<T>> LoadData<T>(string querystring, object parameters);
        double ScalarOutDiaTubing(string puwi);
        string String_Connection_Header(int string_S);
        string String_Connection_Slot(int string_S, string pSchema);
    }
}