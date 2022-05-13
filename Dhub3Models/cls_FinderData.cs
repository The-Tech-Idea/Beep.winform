using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Objects;
using System.IO;
using System.Linq;
using static System.Math;

namespace KOC.DHUB3.Models
{

    public class Cls_FinderDataList
    {

        public event ShowWellEventHandler ShowWell;

        public delegate void ShowWellEventHandler(cls_Finderwell Well);
        public event ShowFacilityEventHandler ShowFacility;

        public delegate void ShowFacilityEventHandler(cls_FinderGC GC);
        public event ShowFieldEventHandler ShowField;

        public delegate void ShowFieldEventHandler(cls_FinderField Fld);

        public global::KocConfig.Config KocConfig { get; set; }
        public global::KocConfig.FinderModelEntity FinderModelcls { get; set; }
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
        public List<PRO_FACILITY> PRo_Facilities { get; set; }
        public OracleDataTable ContourTB { get; set; } = new OracleDataTable();
        public OracleDataTable ReservoirList { get; set; } = new OracleDataTable();
        public OracleDataTable LayerList { get; set; } = new OracleDataTable();
        public List<Reservoir> Q8ReservoirList { get; set; } = new List<Reservoir>();
        public List<Layer> Q8LayerList { get; set; } = new List<Layer>();

        public List<cls_FinderGC> MyFacilityList { get; set; } = new List<cls_FinderGC>();
        public List<cls_FinderField> MyFIELDList { get; set; } = new List<cls_FinderField>();
        public List<cls_Finderwell> MyWellLatestDataList { get; set; } = new List<cls_Finderwell>();
        public List<Reservoir> MyRservoirList { get; set; } = new List<Reservoir>();
        public List<Layer> MyLayerList { get; set; } = new List<Layer>();



        public cls_dashboard DashBoards { get; set; }
        public string SelectedWells { get; set; } = "";
        public string SelectedCompletions { get; set; } = "";
        // Dim Tmp_long_lat As New List(Of TMP_LONGLAT)
        public event DataFetchStageEventHandler DataFetchStage;

        public delegate void DataFetchStageEventHandler(string mess);

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

        // ----- RaiseEvents
        public void RaiseEventShowWell(cls_Finderwell pWellClass)
        {
            ShowWell?.Invoke(pWellClass);

        }
        public void RaiseEventShowFacility(cls_FinderGC pGCClass)
        {
            ShowFacility?.Invoke(pGCClass);

        }
        public void RaiseEventShowField(cls_FinderField pFLDClass)
        {
            ShowField?.Invoke(pFLDClass);

        }
        // - Rig Data
        public List<cls_current_operation_rig> Current_Rig_Operation { get; set; } = new List<cls_current_operation_rig>();
        public List<cls_cd_rig> Rigs { get; set; } = new List<cls_cd_rig>();
        // ----- Rig 


        #region Well Schematics
        public DataTable GetWELL_DIR_SRVY_PTS(string puwi)
        {
            var tb = new DataTable();
            List<WELL_DIR_SRVY_PTS> a = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<WELL_DIR_SRVY_PTS>("SELECT        t.MD, t.TVD, t.MD - t.TVD AS inclination, t.DEVIATION_ANGLE, t.AZIMUTH, t.DX, t.DY  " + "     From KOC.WELL_DIR_SRVY_HDR tt INNER Join  " + "        KOC.WELL_DIR_SRVY_PTS t ON tt.UWI = t.UWI And tt.DIR_SRVY_ID = t.DIR_SRVY_ID  " + " Where (tt.PREFERRED_FLAG = 'Y') AND (tt.UWI ='" + puwi + "'", default).ToList;
            tb = ToDataTable(a);
            return tb;
        }
        public DataTable GetWellDeviation(string puwi)
        {
            var tb = new DataTable();
            List<WellDeviation> a = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<WellDeviation>(" Select Case when (NVL(max(t.tvd),1)/NVL(max(T.md),1))>0.95 then 'VERTICAL' else 'HORIZONTAL' end Divation   " + "     From koc.well_dir_srvy_hdr  tt, koc.well_dir_srvy_pts t   " + "     Where tt.preferred_flag = 'Y' and tt.uwi='" + puwi + "' and tt.uwi=t.uwi and tt.dir_srvy_id=t.DIR_SRVY_ID", default).ToList;
            tb = ToDataTable(a);
            return tb;

        }
        public DataTable GetWorkOver(string puwi)
        {
            var tb = new DataTable();
            List<WrokOver_History> a = KocConfig.DhubContext.ExecuteStoreQuery<WrokOver_History>(" SELECT        END_DATE, OBJECTIVE, OPERATION_PURPOSE, RIG, SPUD_DATE, UWI, WORKOVER_NO  " + "  From WORKOVER_HISTORY  " + "  WHERE        (UWI ='" + puwi + "'  Order BY END_DATE DESC", default).ToList;
            tb = ToDataTable(a);
            return tb;

        }
        public DataTable GetWellTree(string puwi)
        {
            var tb = new DataTable();

            List<WellTree> a = KocConfig.DhubContext.ExecuteStoreQuery<WellTree>(" select * " + " FROM WELL_TREE where uwi='" + puwi + "'", default).ToList;
            tb = ToDataTable(a);
            return tb;

        }
        public DataTable GetWellTreeFType(string puwi, string FACILITY_TYPE)
        {
            var tb = new DataTable();

            List<WellTree> a = KocConfig.DhubContext.ExecuteStoreQuery<WellTree>(" select * " + "    FROM WELL_TREE where uwi='" + puwi + "' and (ACTIVE = 'Y') AND (FACILITY_TYPE =" + FACILITY_TYPE + "' ) AND (END_TIME IS NULL) ORDER BY TOP, OUTER_DIAMETER DESC", default).ToList;
            tb = ToDataTable(a);
            return tb;

        }

        public DataTable GetWellTreeWODate(string puwi, string end_date)
        {
            var tb = new DataTable();

            List<WellTree> a = KocConfig.DhubContext.ExecuteStoreQuery<WellTree>(" select * " + "   FROM WELL_TREE where uwi='" + puwi + "' and (ACTIVE = 'Y') And (START_TIME = to_date('" + end_date + "', 'dd/mm/yyyy'))  ORDER BY TOP, OUTER_DIAMETER DESC", default).ToList;
            tb = ToDataTable(a);
            return tb;

        }

        public DataTable GetWellTreeWorkover(string puwi, string end_date)
        {
            var tb = new DataTable();

            List<WellTree> a = KocConfig.DhubContext.ExecuteStoreQuery<WellTree>(" SELECT     * " + "   FROM            WELL_TREE " + "   WHERE ((UWI = '" + puwi + "') AND (START_TIME <= to_date('" + end_date + "', 'dd/mm/yyyy')) AND (END_TIME > to_date('" + end_date + "', 'dd/mm/yyyy'))) OR" + "    ((UWI = '" + puwi + "') And (START_TIME <= to_date('" + end_date + "', 'dd/mm/yyyy')) AND (END_TIME IS NULL)) OR" + "    ((UWI = '" + puwi + "') And (START_TIME <= to_date('" + end_date + "', 'dd/mm/yyyy')) AND END_TIME = to_date('" + end_date + "', 'dd/mm/yyyy') AND (FACILITY_TYPE = 'PERF') AND (STATUS='CLOSED')) OR" + "    ((UWI ='" + puwi + "') And (FACILITY_TYPE = 'UWI'))    ORDER BY TOP, OUTER_DIAMETER DESC", default).ToList;
            tb = ToDataTable(a);
            return tb;

        }
        // 
        public DataTable GetWellTreeWorkoverRPT(string puwi, string end_date)
        {
            var tb = new DataTable();

            List<WellTree> a = KocConfig.DhubContext.ExecuteStoreQuery<WellTree>(" select * " + "   FROM WELL_TREE   WHERE        (UWI = '" + puwi + "') AND (START_TIME <= to_date('" + end_date + "', 'dd/mm/yyyy')) AND (END_TIME > to_date('" + end_date + "', 'dd/mm/yyyy')) OR " + "    (UWI = '" + puwi + "') And (START_TIME <= to_date('" + end_date + "', 'dd/mm/yyyy')) AND (END_TIME IS NULL) OR " + "    ((UWI = '" + puwi + "') And (START_TIME <= to_date('" + end_date + "', 'dd/mm/yyyy')) AND END_TIME = to_date('" + end_date + "', 'dd/mm/yyyy') AND  " + "     (FACILITY_TYPE = 'PERF') AND (STATUS = 'CLOSED')) OR " + "    (UWI = '" + puwi + "') And (FACILITY_TYPE = 'UWI')" + "  ORDER BY FACILITY_KEY)", default).ToList;
            tb = ToDataTable(a);
            return tb;

        }
        public DataTable GetWellTreeWorkoverRPTDescr(string puwi, string end_date)
        {
            var tb = new DataTable();

            List<WellTree> a = KocConfig.DhubContext.ExecuteStoreQuery<WellTree>(" select ACTIVE, BOTTOM, DEFINITION, END_TIME, to_number(decode(FACILITY_TYPE, 'CASING', - 1, 'LINER', - 1 ,'LINER TIE-BACK', -1 , 'PERF', - 1, 'UWI', - 1, 'COMPLETION', - 1, " + " 'WB', - 1, 'SUSPENDED_OFF_BOTTOM', - 1,'B',-1,'T',-1,'T0',-1,'T1',-1,'T2',-1,'TL',-1,'TL0',-1,'TL1',-1,'TS',-1, TOP)) AS FACILITY_KEY, FACILITY_NAME, FACILITY_TYPE, GRADE, ID, INNER_DIAMETER, INSERTBY, " + "   INSERTDATE, OUTER_DIAMETER, PARENTID, START_TIME, TOP, UPDATEBY, UPDATEDATE, UWI, WEIGHT, STATUS  " + "   FROM WELL_TREE   WHERE        (UWI = '" + puwi + "') AND (START_TIME <= to_date('" + end_date + "', 'dd/mm/yyyy')) AND (END_TIME > to_date('" + end_date + "', 'dd/mm/yyyy')) OR " + "    (UWI = '" + puwi + "') And (START_TIME <= to_date('" + end_date + "', 'dd/mm/yyyy')) AND (END_TIME IS NULL) OR " + "    ((UWI = '" + puwi + "') And (START_TIME <= to_date('" + end_date + "', 'dd/mm/yyyy')) AND END_TIME = to_date('" + end_date + "', 'dd/mm/yyyy') AND  " + "     (FACILITY_TYPE = 'PERF') AND (STATUS = 'CLOSED')) OR " + "    (UWI = '" + puwi + "') And (FACILITY_TYPE = 'UWI')" + "  ORDER BY FACILITY_KEY DESC)", default).ToList;
            tb = ToDataTable(a);
            return tb;

        }
        public DataTable GetWellTreeCasing(string puwi)
        {
            var tb = new DataTable();

            List<WellTree> a = KocConfig.DhubContext.ExecuteStoreQuery<WellTree>(" select * " + "   FROM WELL_TREE   (UWI = '" + puwi + "') AND (ACTIVE = 'Y') AND (END_TIME IS NULL) AND (FACILITY_TYPE = 'CASING') AND (rownum < 2) ORDER BY BOTTOM DESC", default).ToList;
            tb = ToDataTable(a);
            return tb;

        }

        public DataTable GetWellTreePerfByWorkover(string puwi, string end_date)
        {
            var tb = new DataTable();

            List<WellTree> a = KocConfig.DhubContext.ExecuteStoreQuery<WellTree>(" select * " + "   FROM WELL_TREE   (UWI = '" + puwi + "') And (START_TIME <= to_date('" + end_date + "', 'dd/mm/yyyy')) AND END_TIME <= to_date('" + end_date + "', 'dd/mm/yyyy') AND (FACILITY_TYPE = 'PERF') AND (STATUS='CLOSED')", default).ToList;
            tb = ToDataTable(a);
            return tb;

        }

        public object GetKOCWELLV(string puwi)
        {
            var tb = new DataTable();
            List<KOC_WELL_V> a = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<KOC_WELL_V>("Select * from finderweb.koc_well_v " + "  where UWI='" + puwi + "'", default).ToList;
            tb = ToDataTable(a);
            return tb;

        }
        #endregion
        #region HR_LOV
        public List<cls_hr_lov> GetHRLOVByType(string LOVTYPE, string pkocno)
        {
            return KocConfig.DhubContext.ExecuteStoreQuery<cls_hr_lov>("Select a.*,'DB' UPDATED from hr_lov a where a.lov_type='" + LOVTYPE + "' and a.kocno='" + pkocno + "'", default).ToList;

        }
        public List<cls_hr_lov> GetHRLOVByCode(string LOVCODE, string pkocno)
        {
            return KocConfig.DhubContext.ExecuteStoreQuery<cls_hr_lov>("Select a.*,'DB' UPDATED  from hr_lov  a where a.lov_CODE='" + LOVCODE + "'and a.kocno='" + pkocno + "'", default).ToList;

        }
        public int InsertHRLOV(cls_hr_lov hrlov)
        {
            int retval = 0;
            if (hrlov.ID <= 0)
            {
                hrlov.ID = KocConfig.DhubContext.ExecuteStoreQuery<int>("select HR_QUALIFICATIONS_MAP_HDR_SEQ.nextval  from dual", default).FirstOrDefault;
            }
            string insertstr = "insert into hr_lov (id,kocno,lov_code,lov_type,lov_name_ara,lov_name_eng,parentid,teamcode,grpcode,description,active) values (" + hrlov.ID + ",'" + hrlov.KOCNO + "','" + hrlov.LOV_CODE + "','" + hrlov.LOV_TYPE + "','" + hrlov.LOV_NAME_ARA + "','" + hrlov.LOV_NAME_ENG + "','" + hrlov.PARENTID + "','" + hrlov.TEAMCODE + "','" + hrlov.GRPCODE + "','" + hrlov.DESCRIPTION + "','" + hrlov.ACTIVE + "')";
            try
            {
                KocConfig.DhubContext.ExecuteStoreCommand(insertstr);
                hrlov.Updated = "YES";
            }

            catch (Exception ex)
            {
                retval = 1;
            }

            return retval;
        }
        public List<cls_hr_lov> ProcessDirectorytoHRLOV(string DirPath, int parentID = 0)
        {
            var xDir = new cls_hr_lov();
            xDir.ID = KocConfig.DhubContext.ExecuteStoreQuery<int>("select HR_QUALIFICATIONS_MAP_HDR_SEQ.nextval  from dual", default).FirstOrDefault;
            xDir.LOV_CODE = "DIR";
            xDir.LOV_TYPE = "PERSONALFOLDER";
            xDir.TEAMCODE = KocConfig.UserInfo.TeamCode;
            xDir.KOCNO = KocConfig.UserInfo.KOCNO;
            xDir.DESCRIPTION = DirPath;
            xDir.LOV_NAME_ENG = new DirectoryInfo(DirPath).Name;
            xDir.LOV_NAME_ARA = new DirectoryInfo(DirPath).Name;
            xDir.Updated = "NEW";
            if (parentID > 0)
            {
                xDir.PARENTID = parentID;
            }
            else
            {
                xDir.PARENTID = 0;
            }
            Rep_ListofFiles.Add(xDir);
            // Process the list of files found in the directory.
            var fileEntries = Directory.GetFiles(DirPath);
            foreach (string fileName in fileEntries)
            {
                // ProcessFile(fileName)
                var xfILE = new cls_hr_lov();
                xfILE.ID = KocConfig.DhubContext.ExecuteStoreQuery<int>("select HR_QUALIFICATIONS_MAP_HDR_SEQ.nextval  from dual", default).FirstOrDefault;
                xfILE.LOV_CODE = "FILE";
                xfILE.LOV_TYPE = "PERSONALFOLDER";
                xfILE.TEAMCODE = KocConfig.UserInfo.TeamCode;
                xfILE.KOCNO = KocConfig.UserInfo.KOCNO;
                xfILE.DESCRIPTION = DirPath;
                xfILE.LOV_NAME_ENG = Path.GetFileName(fileName);
                xfILE.LOV_NAME_ARA = Path.GetFileName(fileName);
                xfILE.PARENTID = xDir.ID;
                xfILE.Updated = "NEW";
                Rep_ListofFiles.Add(xfILE);



            }
            // Recurse into subdirectories of this directory.
            var subdirectoryEntries = Directory.GetDirectories(DirPath);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectorytoHRLOV(subdirectory, xDir.ID);

            return Rep_ListofFiles;
        }
        #endregion
        public void Get_History_Capacity_Area_report(string Aread_ID, string fromdate)
        {

            Hist_Capacity_Area_Report = KocConfig.DhubContext.ExecuteStoreQuery<cls_Area_Stat>("Select sum(Floor(a.LIQUID_RATE * (1 - a.LATEST_WC / 100))) As  BOPD, sum(Floor(a.LIQUID_RATE * (a.LATEST_WC / 100))) As BWPD, AREA, FIELD_CODE, CURRENT_GC gc, RESERVOIR_ID, trunc(updatedate) updatedate " + " from well_latest_data_hist a" + " where AREA Is Not null " + " And area Not in ('NZ','OK') and status_type='OPEN'" + " and  trunc(updatedate) >=trunc(to_date('" + fromdate + " 05:00:00" + "', 'dd-mm-yyyy HH24:MI:SS'))" + " and  trunc(updatedate) <trunc(sysdate)" + " group by area,field_code,current_gc,reservoir_id,trunc(updatedate)", default).ToList;
            // Return Stat_Capacity_Area_Report
        }
        public void Get_Capacity_Area_report(string Aread_ID)
        {
            Stat_Capacity_Area_Report = KocConfig.DhubContext.ExecuteStoreQuery<cls_Area_Stat>("select sum(floor(a.LIQUID_RATE * (1 - a.LATEST_WC / 100))) as  BOPD,sum(floor(a.LIQUID_RATE * (a.LATEST_WC / 100))) as BWPD,area,field_code,current_gc gc,reservoir_id " + " from well_latest_data a" + " where AREA Is Not null " + " and area not in ('NZ','OK') and status_type='OPEN' and (a.LIQUID_RATE is not null or a.LIQUID_RATE>0)" + " group by area,field_code,current_gc,reservoir_id", default).ToList;
            // Return Stat_Capacity_Area_Report
        }
        public List<cls_current_operation_rig> Get_Current_Rig_Operations(string FromDate)
        {
            // Dim ls As New List(Of cls_current_operation_rig)
            Current_Rig_Operation = KocConfig.EDMContext.ExecuteStoreQuery<cls_current_operation_rig>("SELECT   distinct team, rig_name, startdate  " + " FROM (SELECT   a.well_legal_name UWI,  " + "               MAX (b.date_report) EventDate,  " + "              c.event_team team, c.event_type TeamType, " + "              c.date_ops_start startdate,  " + "               c.estimated_days ESTDate,  " + "               to_Date('dd/mm/yyyy'," + FromDate + " ) - c.date_ops_start PassDays,  " + "               d.rig_name, c.event_objective_1 Objective,  " + " c.event_objective_2 WON  " + "        FROM EDMADMIN.dm_daily b,  " + "                EDMADMIN.dm_event c,  " + "                EDMADMIN.CD_WELL_SOURCE a ,  " + "               EDMADMIN.cd_site_source e,  " + "              EDMADMIN.dm_report_journal f,  " + "  EDMADMIN.cd_rig d " + "    WHERE(((b.date_report >= to_Date('dd/mm/yyyy'," + FromDate + " )))) " + "         AND (    (    c.well_id = b.well_id  " + "                     AND c.event_id = b.event_id  " + "                   )  " + "             AND (a.well_id = c.well_id)  " + "               AND (cd_site.site_id = cd_well.site_id)  " + "              AND (f.report_journal_id =  " + "   b.report_journal_id) " + "              AND (a.well_id = f.well_id)  " + "              AND (    c.well_id = f.well_id  " + "                   AND c.event_id = f.event_id)  " + "              AND (d.rig_id = f.rig_id) )  " + "   GROUP BY a.well_legal_name,  " + "            c.event_team,  " + "            c.event_type,  " + "             c.date_ops_start,  " + "            c.estimated_days,  " + "            cd_rig.rig_name,  " + "            c.event_objective_1,  " + "            c.event_objective_2)  " + "    WHERE startdate >=to_Date('dd/mm/yyyy'," + FromDate + " ) " + " ORDER BY 1 ASC").ToList;
            return Current_Rig_Operation;

        }
        // ---------------------------------------------------------------------------

        // Public Property WellLatestDataList As New List(Of cls_Finderwell)
        // Public Sub GetPlannedWells()
        // Dim tp As New Devart.Data.Oracle.OracleDataAdapter("Select  * from Well_activites where activity_type='New Well'", DirectCast(KocConfig.ImprodFinderWebconn.StoreConnection, EntityClient.EntityConnection).StoreConnection)

        // Try

        // tp.Fill(PlannedWellsDataTable)

        // Catch ex As Exception

        // End Try

        // End Sub
        // 33	IA_MOTOR	CurrentA
        // 34	IB_MOTOR	Current B
        // 35	IC_MOTOR	Current C
        // 36	VAB_MOTOR	Voltage AB
        // 37	VBC_MOTOR	Voltage BC
        // 38	VCA_MOTOR	Voltage CA
        // 39	POWER_FACTOR	Power Factor (%)
        // 40	VOLT_UNBAL	Voltage Unbalance
        // 41	CUR_UNBAL	Current Unbalance
        // 42	INTAKE_PRESSURE	Intake Pressure
        // 43	DISCH_PRESSURE	Discharge Pressure
        // 44	INTAKE_TEMP	Intake Temperature
        // 45	MOTOR_TEMP	Motor Temperature
        // 46	THP	Tubing Head Pressure
        // 47	FLP	Flowline Pressure
        // 48	CHP	Casing Head Pressure
        // 49	GD	Gas Detector
        // 50	H2S	H2S Detector
        // 51	FL_m3_hr_1	Injection Rate 1
        // 52	FL_m3_hr_2	Injection Rate 2
        // 53	FL_m3_hr_3	Injection Rate 3
        // 54	UPST_PR_1	Upstream Pressure 1
        // 55	UPST_PR_2	Upstream Pressure 2
        public void GetESPWells()
        {

            try
            {


                ESPReadings = KocConfig.DhubContext.ExecuteStoreQuery<cls_ESP_DAILY_READING_report>("select WELL,GC,INSTALLATION_DATE,WELL_COMPLETION_S,READING_DATE_TIME,RECORD_ENTRY_DATE_TIME,PI,PD,WHP,TI,TM,FLP,CURRENT_A,CURRENT_B,CURRENT_C,VOLTAGE_AB, VOLTAGE_BC, VOLTAGE_CA, FREQUENCY, VIBRATION, TANK_LEVEL, REMARKS,RECORD_STATUS from ESP_DAILY_READINGS where pi is not null order by reading_date_time asc").ToList; // and reading_date_time between to_date('" + startdate + "','dd-mm-yyyy') and to_date('" + enddate + "','dd-mm-yyyy')
                foreach (cls_Finderwell w in WellLatestDataList.Where(y => y.ESP == "Y"))
                {
                    string u = w.UWI;
                    w.rep_ESP_Reading_report = ESPReadings.Where(x => (x.WELL ?? "") == (u ?? "")).ToList();
                }
            }
            // Dim listofopcWells As List(Of KOC_OPC_WELLS) = KocConfig.RTContext.KOC_OPC_WELLS.ToList

            // For Each i As cls_Finderwell In WellLatestDataList
            // Dim puwi As String = i.UWI
            // i.OPC_KEY = listofopcWells.Where(Function(x) x.WELL_NAME = puwi).FirstOrDefault.WELL_KEY
            // 'If i.OPC_KEY > 0 Then
            // '    i.OPC_DATA.Add(New cls_opc_tags_data)
            // '    i.OPC_DATA(0).IA_MOTOR = From x In KocConfig.RTContext.KOC_OPC_DATA Where x.WELL_KEY = i.OPC_KEY And x.TAG_KEY = 33 Select x Order By X.AQ_TIME Descending Take 100
            // '    i.OPC_DATA(0).IB_MOTOR = From x In KocConfig.RTContext.KOC_OPC_DATA Where x.WELL_KEY = i.OPC_KEY And x.TAG_KEY = 34 Select x Order By X.AQ_TIME Descending Take 100
            // '    i.OPC_DATA(0).IC_MOTOR = From x In KocConfig.RTContext.KOC_OPC_DATA Where x.WELL_KEY = i.OPC_KEY And x.TAG_KEY = 35 Select x Order By X.AQ_TIME Descending Take 100
            // '    i.OPC_DATA(0).VAB_MOTOR = From x In KocConfig.RTContext.KOC_OPC_DATA Where x.WELL_KEY = i.OPC_KEY And x.TAG_KEY = 36 Select x Order By X.AQ_TIME Descending Take 100
            // '    i.OPC_DATA(0).VBC_MOTOR = From x In KocConfig.RTContext.KOC_OPC_DATA Where x.WELL_KEY = i.OPC_KEY And x.TAG_KEY = 37 Select x Order By X.AQ_TIME Descending Take 100
            // '    i.OPC_DATA(0).VCA_MOTOR = From x In KocConfig.RTContext.KOC_OPC_DATA Where x.WELL_KEY = i.OPC_KEY And x.TAG_KEY = 38 Select x Order By X.AQ_TIME Descending Take 100
            // '    i.OPC_DATA(0).POWER_FACTOR = From x In KocConfig.RTContext.KOC_OPC_DATA Where x.WELL_KEY = i.OPC_KEY And x.TAG_KEY = 39 Select x Order By X.AQ_TIME Descending Take 100
            // '    i.OPC_DATA(0).VOLT_UNBAL = From x In KocConfig.RTContext.KOC_OPC_DATA Where x.WELL_KEY = i.OPC_KEY And x.TAG_KEY = 40 Select x Order By X.AQ_TIME Descending Take 100
            // '    i.OPC_DATA(0).CUR_UNBAL = From x In KocConfig.RTContext.KOC_OPC_DATA Where x.WELL_KEY = i.OPC_KEY And x.TAG_KEY = 41 Select x Order By X.AQ_TIME Descending Take 100
            // '    i.OPC_DATA(0).INTAKE_PRESSURE = From x In KocConfig.RTContext.KOC_OPC_DATA Where x.WELL_KEY = i.OPC_KEY And x.TAG_KEY = 42 Select x Order By X.AQ_TIME Descending Take 100
            // '    i.OPC_DATA(0).DISCH_PRESSURE = From x In KocConfig.RTContext.KOC_OPC_DATA Where x.WELL_KEY = i.OPC_KEY And x.TAG_KEY = 43 Select x Order By X.AQ_TIME Descending Take 100
            // '    i.OPC_DATA(0).INTAKE_TEMP = From x In KocConfig.RTContext.KOC_OPC_DATA Where x.WELL_KEY = i.OPC_KEY And x.TAG_KEY = 44 Select x Order By X.AQ_TIME Descending Take 100
            // '    i.OPC_DATA(0).MOTOR_TEMP = From x In KocConfig.RTContext.KOC_OPC_DATA Where x.WELL_KEY = i.OPC_KEY And x.TAG_KEY = 45 Select x Order By X.AQ_TIME Descending Take 100
            // '    i.OPC_DATA(0).THP = From x In KocConfig.RTContext.KOC_OPC_DATA Where x.WELL_KEY = i.OPC_KEY And x.TAG_KEY = 46 Select x Order By X.AQ_TIME Descending Take 100
            // '    i.OPC_DATA(0).FLP = From x In KocConfig.RTContext.KOC_OPC_DATA Where x.WELL_KEY = i.OPC_KEY And x.TAG_KEY = 47 Select x Order By X.AQ_TIME Descending Take 100
            // '    i.OPC_DATA(0).CHP = From x In KocConfig.RTContext.KOC_OPC_DATA Where x.WELL_KEY = i.OPC_KEY And x.TAG_KEY = 48 Select x Order By X.AQ_TIME Descending Take 100
            // '    i.OPC_DATA(0).GD = From x In KocConfig.RTContext.KOC_OPC_DATA Where x.WELL_KEY = i.OPC_KEY And x.TAG_KEY = 49 Select x Order By X.AQ_TIME Descending Take 100
            // '    i.OPC_DATA(0).H2S = From x In KocConfig.RTContext.KOC_OPC_DATA Where x.WELL_KEY = i.OPC_KEY And x.TAG_KEY = 50 Select x Order By X.AQ_TIME Descending Take 100
            // '    i.OPC_DATA(0).FL_m3_hr_1 = From x In KocConfig.RTContext.KOC_OPC_DATA Where x.WELL_KEY = i.OPC_KEY And x.TAG_KEY = 51 Select x Order By X.AQ_TIME Descending Take 100
            // '    i.OPC_DATA(0).FL_m3_hr_2 = From x In KocConfig.RTContext.KOC_OPC_DATA Where x.WELL_KEY = i.OPC_KEY And x.TAG_KEY = 52 Select x Order By X.AQ_TIME Descending Take 100
            // '    i.OPC_DATA(0).FL_m3_hr_3 = From x In KocConfig.RTContext.KOC_OPC_DATA Where x.WELL_KEY = i.OPC_KEY And x.TAG_KEY = 53 Select x Order By X.AQ_TIME Descending Take 100
            // '    i.OPC_DATA(0).UPST_PR_1 = From x In KocConfig.RTContext.KOC_OPC_DATA Where x.WELL_KEY = i.OPC_KEY And x.TAG_KEY = 54 Select x Order By X.AQ_TIME Descending Take 100
            // '    i.OPC_DATA(0).UPST_PR_2 = From x In KocConfig.RTContext.KOC_OPC_DATA Where x.WELL_KEY = i.OPC_KEY And x.TAG_KEY = 55 Select x Order By X.AQ_TIME Descending Take 100

            // 'End If


            // Next
            catch (Exception ex)
            {

            }
        }
        // Public Sub GetTmpLongLat()
        // Try
        // Tmp_long_lat = KocConfig.DhubContext.TMP_LONGLAT.ToList
        // Catch ex As Exception

        // End Try

        // End Sub
        public void GetPROFacility()
        {
            PRo_Facilities = KocConfig.DhubContext.PRO_FACILITY.ToList;
        }
        public void GetGISWellLatestDataTable(string pArea)
        {
            var tp = new Devart.Data.Oracle.OracleDataAdapter("Select   distinct UWI,x,y,LONGITUDE,LATITUDE,FIELD_CODE from WELL_LATEST_DATA a where decode('" + pArea + "','ALL',area,'" + pArea + "')=area ", KocConfig.DhubDatabaseConnection); // ,a.facility_type as mystring

            try
            {
                tp.Fill(GISWellsDataTable);
            }
            // For Each i As DataRow In GISWellsDataTable.Rows
            // ' If IsDBNull(i.Item("PPDM_WCS_UWI")) Then
            // 'i.Item("PPDM_WCS_UWI") = i.Item("UWI") & "-" & i.Item("FACILITY_NAME") & "-" & i.Item("FACILITY_ID") & "-" & i.Item("RESERVOIR_ID")
            // ''End If
            // Select Case i.Item("CR_STATUS")
            // Case "Oil Well"
            // Case "Injector-Water"
            // Case "Suspended"
            // Case ""


            // End Select
            // 'If (i.Item("FACILITY_TYPE").ToString.StartsWith("I") Or i.Item("FACILITY_NAME").ToString.StartsWith("I")) Then

            // '    i.Item("MYSTATUS") = "INJECTOR"

            // 'ElseIf (i.Item("ESP").ToString <> "Y") Then
            // '    If i.Item("STATUS_TYPE").ToString.Length > 0 Then
            // '        i.Item("MYSTATUS") = i.Item("STATUS_TYPE")
            // '    Else
            // '        i.Item("MYSTATUS") = "CLOSE"


            // '    End If
            // 'ElseIf i.Item("ESP").ToString = "Y" Then
            // '    If (i.Item("ESP_STATUS").ToString.Length > 0) And (i.Item("ESP_STATUS").ToString <> "NONE") Then
            // '        i.Item("MYSTATUS") = i.Item("ESP_STATUS")
            // '    Else
            // '        If i.Item("STATUS_TYPE").ToString.Length > 0 Then
            // '            i.Item("MYSTATUS") = i.Item("STATUS_TYPE")
            // '        Else
            // '            i.Item("MYSTATUS") = "CLOSE"


            // '        End If
            // '    End If

            // 'Else
            // '    i.Item("MYSTATUS") = "CLOSE"
            // ' End If
            // 'Dim GPS_C As New GPS
            // 'Dim lat As New GPS.Coordinate(i.Item("LATITUDE"), GPS.CoordinateType.Latitude)
            // 'Dim lng As New GPS.Coordinate(i.Item("LONGITUDE"), GPS.CoordinateType.Longitude)
            // 'Dim utm As New GPS.UTM(lat, lng)


            // 'KocConfig.ConvertFromUTMtoLATLONG(i.Item("Y"), i.Item("X"))
            // Try
            // i.Item("LONGITUDE") = Tmp_long_lat.Where(Function(x) x.UWI = i.Item("UWI")).First.LON 'Convert.ToDecimal(KocConfig.Longitude)
            // i.Item("LATITUDE") = Tmp_long_lat.Where(Function(x) x.UWI = i.Item("UWI")).First.LAT 'Convert.ToDecimal(KocConfig.Latitude)
            // Catch ex As Exception

            // End Try

            // Next

            catch (Exception ex)
            {

            }
        }
        public void GetWellLatestDataTable(string pArea = "")
        {
            OracleDataAdapter tp;
            if (pArea.Length > 0)
            {
                tp = new Devart.Data.Oracle.OracleDataAdapter("Select  decode(a.MYSTATUS,'OPEN',0,'CLOSE',1,'INJECTOR',4,'ESP OPEN',2,'ESP CLOSE',3,1) StatusIDX, a.*,round(a.LIQUID_RATE * (1 - a.LATEST_WC / 100)) as  BOPD, round(a.LIQUID_RATE * (a.LATEST_WC / 100)) as BWPD,a.facility_type as mystring, round(a.LIQUID_RATE * (1 - a.LATEST_WC / 100)/1000) as BOPDLite,decode(LF_DESCR,'NATURALLY_FLOWING','NF',LF_DESCR) LFFixed,decode(status_type,'OPEN',1,0) PRODUCING from WELL_LATEST_DATA a  where   decode('" + pArea + "','ALL',area,'" + pArea + "')=area", KocConfig.DhubDatabaseConnection);
            }
            else
            {
                tp = new Devart.Data.Oracle.OracleDataAdapter("Select  decode(a.MYSTATUS,'OPEN',0,'CLOSE',1,'INJECTOR',4,'ESP OPEN',2,'ESP CLOSE',3,1) StatusIDX, a.*,round(a.LIQUID_RATE * (1 - a.LATEST_WC / 100)) as  BOPD, round(a.LIQUID_RATE * (a.LATEST_WC / 100)) as BWPD,a.facility_type as mystring, round(a.LIQUID_RATE * (1 - a.LATEST_WC / 100)/1000) as BOPDLite,decode(LF_DESCR,'NATURALLY_FLOWING','NF',LF_DESCR) LFFixed,decode(status_type,'OPEN',1,0) PRODUCING from WELL_LATEST_DATA a ", KocConfig.DhubDatabaseConnection);
            } // wcc_status='OPEN' and


            try
            {
                tp.Fill(WellLatestDataTable);
            }
            // For Each i As DataRow In WellLatestDataTable.Rows
            // ' If IsDBNull(i.Item("PPDM_WCS_UWI")) Then
            // i.Item("PPDM_WCS_UWI") = i.Item("UWI") & "-" & i.Item("FACILITY_NAME") & "-" & i.Item("FACILITY_ID") & "-" & i.Item("RESERVOIR_ID")
            // 'End If
            // If (i.Item("FACILITY_TYPE").ToString.StartsWith("I") Or i.Item("FACILITY_NAME").ToString.StartsWith("I")) Then

            // i.Item("MYSTATUS") = "INJECTOR"

            // ElseIf (i.Item("ESP").ToString <> "Y") Then
            // If i.Item("STATUS_TYPE").ToString.Length > 0 Then
            // i.Item("MYSTATUS") = i.Item("STATUS_TYPE")
            // Else
            // i.Item("MYSTATUS") = "CLOSE"


            // End If
            // ElseIf i.Item("ESP").ToString = "Y" Then
            // If (i.Item("ESP_STATUS").ToString.Length > 0) And (i.Item("ESP_STATUS").ToString <> "NONE") Then
            // i.Item("MYSTATUS") = i.Item("ESP_STATUS")
            // Else
            // If i.Item("STATUS_TYPE").ToString.Length > 0 Then
            // i.Item("MYSTATUS") = i.Item("STATUS_TYPE")
            // Else
            // i.Item("MYSTATUS") = "CLOSE"


            // End If
            // End If

            // Else
            // i.Item("MYSTATUS") = "CLOSE"
            // End If
            // 'Dim GPS_C As New GPS
            // 'Dim lat As New GPS.Coordinate(i.Item("LATITUDE"), GPS.CoordinateType.Latitude)
            // 'Dim lng As New GPS.Coordinate(i.Item("LONGITUDE"), GPS.CoordinateType.Longitude)
            // 'Dim utm As New GPS.UTM(lat, lng)


            // 'KocConfig.ConvertFromUTMtoLATLONG(i.Item("Y"), i.Item("X"))
            // Try
            // i.Item("LONGITUDE") = Tmp_long_lat.Where(Function(x) x.UWI = i.Item("UWI")).First.LON 'Convert.ToDecimal(KocConfig.Longitude)
            // i.Item("LATITUDE") = Tmp_long_lat.Where(Function(x) x.UWI = i.Item("UWI")).First.LAT 'Convert.ToDecimal(KocConfig.Latitude)
            // Catch ex As Exception

            // End Try

            // Next

            catch (Exception ex)
            {

            }
        }
        public List<cls_Finderwell> GetWellLatestDataForGCAtDate(string TheDate, string GCID)
        {
            var x = new List<cls_Finderwell>();
            try
            {

                x = KocConfig.DhubContext.ExecuteStoreQuery<cls_Finderwell>("select a.*,round(a.LIQUID_RATE * (1 - a.LATEST_WC / 100),0) as  BOPD,round(a.ALLOWABLE -round(a.LIQUID_RATE),0) as POTENIAL, round(a.LIQUID_RATE * (a.LATEST_WC / 100),0) as BWPD, decode(a.MYSTATUS,'OPEN',0,'CLOSE',1,'INJECTOR',4,'ESP OPEN',2,'ESP CLOSE',3,1) StatusIDX,decode(LF_DESCR,'NATURALLY_FLOWING','NF',LF_DESCR) LFFixed,decode(status_type,'OPEN',1,0) PRODUCING from WELL_LATEST_DATA_hist a where  updatedate=to_date('" + TheDate + "','dd/mm/yyyy') and Current_gc='" + GCID + "' ").ToList; // LAYER_NAME is not null and RESERVOIR_ID is not null and
            }



            catch (Exception ex)
            {
            }
            return x;
        }
        public List<cls_Finderwell> GetWellLatestDataClassForAll(string pField_Code = "", string pArea = "")
        {
            var x = new List<cls_Finderwell>();
            try
            {
                if (string.IsNullOrEmpty(pField_Code))
                {
                    x = KocConfig.DhubContext.ExecuteStoreQuery<cls_Finderwell>("select a.*,round(a.LIQUID_RATE * (1 - a.LATEST_WC / 100),0) as  BOPD,round(a.ALLOWABLE -round(a.LIQUID_RATE),0) as POTENIAL, round(a.LIQUID_RATE * (a.LATEST_WC / 100),0) as BWPD, decode(a.MYSTATUS,'OPEN',0,'CLOSE',1,'INJECTOR',4,'ESP OPEN',2,'ESP CLOSE',3,1) StatusIDX,decode(LF_DESCR,'NATURALLY_FLOWING','NF',LF_DESCR) LFFixed,decode(status_type,'OPEN',1,0) PRODUCING from WELL_LATEST_DATA a where   field_code is not null and decode('" + pArea + "','ALL',area,'" + pArea + "')=area ").ToList; // LAYER_NAME is not null and RESERVOIR_ID is not null and
                }


                else
                {
                    x = KocConfig.DhubContext.ExecuteStoreQuery<cls_Finderwell>("select a.*,round(a.LIQUID_RATE * (1 - a.LATEST_WC / 100),0) as  BOPD,round(a.ALLOWABLE -round(a.LIQUID_RATE ),0) as POTENIAL, round(a.LIQUID_RATE * (a.LATEST_WC / 100),0) as BWPD , decode(a.MYSTATUS,'OPEN',0,'CLOSE',1,'INJECTOR',4,'ESP OPEN',2,'ESP CLOSE',3,1) StatusIDX,decode(LF_DESCR,'NATURALLY_FLOWING','NF',LF_DESCR) LFFixed,decode(status_type,'OPEN',1,0) PRODUCING from WELL_LATEST_DATA a where  field_code is not null and field_code='" + pField_Code + "'").ToList; // LAYER_NAME is not null and RESERVOIR_ID is not null and
                    WellLatestDataList.RemoveAll(y => (y.FIELD_CODE ?? "") == (pField_Code ?? ""));
                }

                WellLatestDataList = x;
            }
            catch (Exception ex)
            {
            }
            return x;
        }
        public void UpdateWellStatusForAllALMS()
        {
            foreach (cls_Finderwell w in WellLatestDataList.Where(x => x.ESP == "Y").ToList())
            {
                cls_ots_dm_al_stopstart_events ls;
                ls = KocConfig.OTSContext.ExecuteStoreQuery<cls_ots_dm_al_stopstart_events>("Select distinct uwi,  datetime start_time , stopstart, remarks ,wstring  from OTS_DM_al_stopstart_events where uwi ='" + w.UWI + "'  order by 2 desc").Take(1).FirstOrDefault;
                if (ls == null == false)
                {
                    w.STATUS_TYPE = Conversions.ToString(Interaction.IIf(ls.StopStart == 1, "CLOSE", "OPEN"));
                    w.STATUSIDX = Conversions.ToInteger(Interaction.IIf(ls.StopStart == 1, 2, 1));
                    w.STATUS_REASON = ls.Remarks;
                    w.STATUS_DATE = ls.start_time;

                }
            }
        }
        public void UpdateWellStatusForFieldFromALMS(string pField_Code)
        {
            foreach (cls_Finderwell w in WellLatestDataList.Where(x => (x.FIELD_CODE ?? "") == (pField_Code ?? "")).Where(x => x.ESP == "Y").ToList())
            {
                cls_ots_dm_al_stopstart_events ls;
                ls = KocConfig.OTSContext.ExecuteStoreQuery<cls_ots_dm_al_stopstart_events>("Select distinct uwi,  datetime start_time , stopstart, remarks ,wstring  from OTS_DM_al_stopstart_events where uwi =" + w.UWI + "'  order by 2 desc").Take(1).FirstOrDefault;
                if (ls == null == false)
                {
                    w.STATUS_TYPE = Conversions.ToString(Interaction.IIf(ls.StopStart == 1, "CLOSE", "OPEN"));
                    w.STATUSIDX = Conversions.ToInteger(Interaction.IIf(ls.StopStart == 1, 2, 1));
                    w.STATUS_REASON = ls.Remarks;
                    w.STATUS_DATE = ls.start_time;

                }
            }
        }
        public List<cls_Finderwell> GetWellLatestDataTableForGc(string pGCID)
        {
            var x = new List<cls_Finderwell>();
            try
            {
                x = WellLatestDataList.Where(y => (y.CURRENT_GC ?? "") == (pGCID ?? "")).ToList();
                return x;
            }
            catch (Exception ex)
            {
            }
            return x;
        }
        public List<cls_Finderwell> GetWellLatestDataTableForField(string pField_ID, bool pRefesh = false)
        {

            try
            {
                if (pRefesh)
                {
                    GetWellLatestDataClassForAll(pField_ID);

                }
            }

            catch (Exception ex)
            {

            }
            return WellLatestDataList.Where(y => (y.FIELD_CODE ?? "") == (pField_ID ?? "")).ToList();

        }
        public cls_FinderGC GetGCBasicDetailsInfo(string pGCID, bool prefreshFlag)
        {
            cls_FinderGC gcx;
            gcx = GetGC(pGCID);
            try
            {
                if (prefreshFlag == false)
                {
                    gcx.RefershFlag = true;
                    gcx.ConnectedWells = new List<cls_Finderwell>(); // GetFieldBasicInfo(fldid)
                                                                     // For Each pw As cls_Finderwell In WellLatestDataList
                                                                     // If pw.CURRENT_GC = gcx.GC Then
                                                                     // gcx.GC_IN_INOUTSTOCKPORTS = GetGCPorts(gcx)
                                                                     // gcx.GC_IN_SURFACE_FACILITY = GetGCFacilities(gcx)
                    gcx.ConnectedWells = GetWellLatestDataTableForGc(pGCID);
                    // End If

                    // Next
                }
            }
            catch (Exception ex)
            {
                // DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message & "- Error Field ", "DH2")
            }
            GetGC(pGCID).ConnectedWells = gcx.ConnectedWells;
            GetGC(pGCID).RefershFlag = gcx.RefershFlag;
            return gcx;
        }
        public cls_FinderField GetFieldBasicInfo(string Field_Code, bool prefreshFlag)
        {
            cls_FinderField fieldx;
            fieldx = GetField(Field_Code);
            try
            {
                if (prefreshFlag == true)
                {
                    fieldx.RefershFlag = true;
                    fieldx.ConnectedWells = new List<cls_Finderwell>(); // GetFieldBasicInfo(fldid)
                                                                        // For Each pw As cls_Finderwell In WellLatestDataList
                                                                        // If pw.FIELD_CODE = fieldx.Field_Code Then
                                                                        // GetWellInfo(pw)
                    fieldx.ConnectedWells = GetWellLatestDataTableForField(Field_Code);

                    // End If

                    // Next
                }
            }
            catch (Exception ex)
            {
                // DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message & "- Error Field ", "DH2")
            }
            foreach (cls_Finderwell w in fieldx.ConnectedWells)
            {
                SelectedWells += "," + w.UWI;
                SelectedCompletions += "," + w.WELL_COMPLETION_S;

            }
            // GetField(Field_Code).ConnectedWells = fieldx.ConnectedWells
            // GetField(Field_Code).RefershFlag = fieldx.RefershFlag
            return fieldx;
        }
        public cls_FinderGC GetGC(string pGCID)
        {
            foreach (cls_FinderGC GCx in GCListDataList)
            {
                if ((GCx.GC ?? "") == (pGCID ?? ""))
                {

                    return GCx;
                    return default;

                }

            }
            return null;
        }
        public cls_FinderField GetField(string pField_Code)
        {
            foreach (cls_FinderField Fieldx in FieldDataList)
            {
                SelectedWells = "";
                SelectedCompletions = "";
                if ((Fieldx.Field_Code ?? "") == (pField_Code ?? ""))
                {


                    return Fieldx;
                    return default;

                }

            }
            return null;
        }
        public void getGcList()
        {
            List<cls_FinderGC> gcsid = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_FinderGC>("  select decode(facility_id, 'GC50', 'EPF-50','GC120', 'EPF-120', facility_id) gc,facility_id , surface_facility_s,operator_id area,facility_name from koc.surface_facility where facility_type = 'GATHERING CENTER'  and current_status='OPEN'  order by facility_id").ToList;
            foreach (cls_FinderGC gcid in gcsid)
            {
                var gcx = new cls_FinderGC();
                // gcx = ReadGCJsonXML(gcid.GC)

                // If IsNothing(gcx) Then
                gcx = new cls_FinderGC();
                gcx.Surface_Facility_s = gcid.Surface_Facility_s;
                gcx.Area = gcid.Area;
                if (gcx.Area == "SEK" | gcx.Area == "EK")
                {
                    gcx.Area = "SK";
                }
                gcx.GC_finder_ID = gcid.GC;
                gcx.facility_id = gcid.facility_id;
                gcx.facility_name = gcid.facility_name;
                gcx.GC = gcid.facility_id;
                gcx.ConnectedWells = new List<cls_Finderwell>();
                // gcx.GC_IN_INOUTSTOCKPORTS = GetGCPorts(gcx)
                // gcx.GC_IN_SURFACE_FACILITY = GetGCFacilities(gcx)
                // If IsNothing(gcx.ConnectedWells) = False Then
                // For Each pw As cls_Finderwell In WellLatestDataList
                // If pw.CURRENT_GC = gcx.GC Then
                // '   GetWellInfo(pw)
                // gcx.ConnectedWells.Add(pw)
                // End If

                // Next


                // WriteGCJsonXML(gcx)
                // End If
                GCListDataList.Add(gcx);
            }
        }
        public void GetFieldReservoirList(string FieldCode)
        {
            string QueryResFinder = "select distinct RESERVOIR_NAME,RESERVOIR_ID from finderweb.well_latest_data where field_code='" + FieldCode + "' and RESERVOIR_ID is not null and RESERVOIR_NAME is not null";
            ReservoirList = new OracleDataTable();
            ReservoirList.SelectCommand = new Devart.Data.Oracle.OracleCommand(QueryResFinder, KocConfig.FinderModelEntities.KOCconn.StoreConnection);
            ReservoirList.Fill();
            Q8ReservoirList = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<Reservoir>("select distinct RESERVOIR_NAME,RESERVOIR_ID from finderweb.well_latest_data where field_code='" + FieldCode + "' and RESERVOIR_ID is not null and RESERVOIR_NAME is not null", default).ToList;

        }
        public List<Reservoir> GetFieldReservoirListFunc(string FieldCode)
        {
            string QueryResFinder = "select distinct RESERVOIR_NAME,RESERVOIR_ID from finderweb.well_latest_data where field_code='" + FieldCode + "'";
            var reslist = new List<Reservoir>();
            reslist = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<Reservoir>("select distinct RESERVOIR_NAME,RESERVOIR_ID from finderweb.well_latest_data where field_code='" + FieldCode + "' and RESERVOIR_ID is not null and RESERVOIR_NAME is not null ", default).ToList;
            return reslist;
        }

        public List<Layer> GetFieldLayerListFunc(string FieldCode)
        {
            string QueryResFinder = "select distinct LAYER_NAME from finderweb.well_latest_data where field_code='" + FieldCode + "'";
            List<Layer> LayerList;
            LayerList = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<Layer>("select distinct LAYER_NAME,RESERVOIR_ID from finderweb.well_latest_data where field_code='" + FieldCode + "' and RESERVOIR_ID is not null and LAYER_NAME is not null ", default).ToList;
            return LayerList;
        }
        public void GetAllReservoirList()
        {
            string QueryResFinder = "select distinct RESERVOIR_NAME,RESERVOIR_ID from finderweb.well_latest_data ";
            ReservoirList = new OracleDataTable();
            ReservoirList.SelectCommand = new Devart.Data.Oracle.OracleCommand(QueryResFinder, KocConfig.FinderModelEntities.KOCconn.StoreConnection);
            ReservoirList.Fill();
            Q8ReservoirList = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<Reservoir>("select distinct RESERVOIR_NAME,RESERVOIR_ID from finderweb.well_latest_data ", default).ToList;

        }
        public void GetFieldLayerList(string FieldCode)
        {
            string QueryResFinder = "select distinct LAYER_NAME from finderweb.well_latest_data where field_code='" + FieldCode + "'";
            LayerList = new OracleDataTable();
            LayerList.SelectCommand = new Devart.Data.Oracle.OracleCommand(QueryResFinder, KocConfig.FinderModelEntities.KOCconn.StoreConnection);
            LayerList.Fill();
            Q8LayerList = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<Layer>("select distinct LAYER_NAME,RESERVOIR_ID from finderweb.well_latest_data where field_code='" + FieldCode + "' and RESERVOIR_ID is not null and LAYER_NAME is not null", default).ToList;

        }
        public DataTable GetWellContourList4Area(string pArea, ref string ResName, string ValueField, string ValueDateField, string othercond = "")
        {
            var tb = new DataTable();
            string QueryContFinder = "";
            try
            {
                if (othercond.Length > 0)
                {
                    othercond = othercond + " and ";
                }

                QueryContFinder = "select distinct  uwi,UWI||'-'||FACILITY_NAME||'-'||facILITY_type||'-'||RESERVOIR_id as PPDM_WCS_UWI,well_completion_s,LONGITUDE,LATITUDE," + ValueField + " VALUE from well_latest_data where " + othercond + " (Area='" + pArea + "')  and (" + ValueDateField + " is not null) and (" + ValueField + " is not null) and (" + ValueField + " > 0)  "; // group by  uwi,UWI||'('||RESERVOIR_id||'-'||facILITY_type||')', LATITUDE  ,LONGITUDE  ," & ValueField ' & "," & ValueDateField


                // ResName = ""

                // End If
                // If LayerName.Length > 0 Then
                // QueryContFinder = "select distinct uwi, UWI||'('||RESERVOIR_id||'-'||facILITY_type||')' as PPDM_WCS_UWI,LATITUDE  ,LONGITUDE,max(" & ValueDateField & ")," & ValueDateField & "," & ValueField & " VALUE from finderweb.well_latest_data where " & othercond & " field_code='" & FieldCode & "'  and " & ValueDateField & "  is not null and " & ValueField & " is not null  group by  uwi,UWI||'('||RESERVOIR_id||'-'||facILITY_type||')', LATITUDE  ,LONGITUDE  ," & ValueField & "," & ValueDateField
                // Else
                // QueryContFinder = "select distinct  uwi,UWI||'-'||FACILITY_NAME||'-'||facILITY_type||'-'||RESERVOIR_id as PPDM_WCS_UWI,well_completion_s,X,Y," & ValueField & " VALUE from finderweb.well_latest_data where " & othercond & " (field_code='" & FieldCode & "')  and (" & ValueDateField & " is not null) and (" & ValueField & " is not null) and (" & ValueField & " > 0) and (X is not  null) and (Y is  not null) " ' group by  uwi,UWI||'('||RESERVOIR_id||'-'||facILITY_type||')', LATITUDE  ,LONGITUDE  ," & ValueField ' & "," & ValueDateField
                // ' End If
                // ContourTB = WellLatestDataTable.Select(othercond & " field_code='" & FieldCode & "'  and " & ValueDateField & " is not null and " & ValueField & " is not null and LONGITUDE is not null and LATITUDE  is not null").CopyToDataTable
                ContourTB = new OracleDataTable();
                ContourTB.SelectCommand = new Devart.Data.Oracle.OracleCommand(QueryContFinder, KocConfig.DhubDatabaseConnection);
                ContourTB.Fill();
            }

            // For Each r As DataRow In ContourTB.Rows

            // Dim myuwi As String = ""
            // myuwi = r.Item("UWI").ToString
            // Try
            // r.Item("LONGITUDE") = Tmp_long_lat.Where(Function(t) t.UWI = myuwi).First.LON 'Convert.ToDecimal(SimpleConfig.Longitude)
            // r.Item("LATITUDE") = Tmp_long_lat.Where(Function(t) t.UWI = myuwi).First.LAT 'Convert.ToDecimal(SimpleConfig.Latitude)
            // Catch ex As Exception

            // End Try
            // Next
            // Dim rows() As DataRow = ContourTB.Select("LONGITUDE is null or LATITUDE is null")
            // For Each r As DataRow In rows
            // ContourTB.Rows.Remove(r)
            // Next
            catch (Exception ex)
            {
                Interaction.MsgBox("DHUB 2 :" + ex.Message, MsgBoxStyle.Critical, "Error in Loading Contour Data");
            }
            return tb;
        }
        public DataTable GetWellContourListForField(ref string FieldCode, string ValueField, string ValueDateField, string othercond = "")
        {
            var tb = new DataTable();
            string QueryContFinder = "";
            try
            {
                if (othercond.Length > 0)
                {
                    othercond = othercond + " and ";
                }
                if (ValueField == "LATEST_WC")
                {
                    QueryContFinder = "select distinct  uwi,UWI||'-'||FACILITY_NAME||'-'||facILITY_type||'-'||RESERVOIR_id as PPDM_WCS_UWI,well_completion_s,LONGITUDE,LATITUDE,decode(sign(LATEST_WC-1),-1,Latest_WC*100,LAtest_WC)  VALUE,decode(sign(LATEST_WC-1),-1,Latest_WC*100,LAtest_WC) LATEST_WC  from well_latest_data where " + othercond + " (field_code='" + FieldCode + "')  and (" + ValueDateField + " is not null) and (" + ValueField + " is not null) and (" + ValueField + " > 0)  "; // group by  uwi,UWI||'('||RESERVOIR_id||'-'||facILITY_type||')', LATITUDE  ,LONGITUDE  ," & ValueField ' & "," & ValueDateField
                }
                else
                {
                    QueryContFinder = "select distinct  uwi,UWI||'-'||FACILITY_NAME||'-'||facILITY_type||'-'||RESERVOIR_id as PPDM_WCS_UWI,well_completion_s,LONGITUDE,LATITUDE,LATEST_OIL_RATE,LIQUID_RATE,WHP,H2S,LATEST_FLP,LATEST_GOR,LATEST_SULFUR," + ValueField + " VALUE from well_latest_data where " + othercond + " (field_code='" + FieldCode + "')  and (" + ValueDateField + " is not null) and (" + ValueField + " is not null) and (" + ValueField + " > 0)  ";
                } // group by  uwi,UWI||'('||RESERVOIR_id||'-'||facILITY_type||')', LATITUDE  ,LONGITUDE  ," & ValueField ' & "," & ValueDateField



                // ResName = ""

                // End If
                // If LayerName.Length > 0 Then
                // QueryContFinder = "select distinct uwi, UWI||'('||RESERVOIR_id||'-'||facILITY_type||')' as PPDM_WCS_UWI,LATITUDE  ,LONGITUDE,max(" & ValueDateField & ")," & ValueDateField & "," & ValueField & " VALUE from finderweb.well_latest_data where " & othercond & " field_code='" & FieldCode & "'  and " & ValueDateField & "  is not null and " & ValueField & " is not null  group by  uwi,UWI||'('||RESERVOIR_id||'-'||facILITY_type||')', LATITUDE  ,LONGITUDE  ," & ValueField & "," & ValueDateField
                // Else
                // QueryContFinder = "select distinct  uwi,UWI||'-'||FACILITY_NAME||'-'||facILITY_type||'-'||RESERVOIR_id as PPDM_WCS_UWI,well_completion_s,X,Y," & ValueField & " VALUE from finderweb.well_latest_data where " & othercond & " (field_code='" & FieldCode & "')  and (" & ValueDateField & " is not null) and (" & ValueField & " is not null) and (" & ValueField & " > 0) and (X is not  null) and (Y is  not null) " ' group by  uwi,UWI||'('||RESERVOIR_id||'-'||facILITY_type||')', LATITUDE  ,LONGITUDE  ," & ValueField ' & "," & ValueDateField
                // ' End If
                // ContourTB = WellLatestDataTable.Select(othercond & " field_code='" & FieldCode & "'  and " & ValueDateField & " is not null and " & ValueField & " is not null and LONGITUDE is not null and LATITUDE  is not null").CopyToDataTable
                ContourTB = new OracleDataTable();
                ContourTB.SelectCommand = new Devart.Data.Oracle.OracleCommand(QueryContFinder, KocConfig.DhubDatabaseConnection);
                ContourTB.Fill();
                return ContourTB;
            }
            // For Each r As DataRow In ContourTB.Rows

            // Dim myuwi As String = ""
            // myuwi = r.Item("UWI").ToString
            // Try
            // r.Item("LONGITUDE") = Tmp_long_lat.Where(Function(t) t.UWI = myuwi).First.LON 'Convert.ToDecimal(SimpleConfig.Longitude)
            // r.Item("LATITUDE") = Tmp_long_lat.Where(Function(t) t.UWI = myuwi).First.LAT 'Convert.ToDecimal(SimpleConfig.Latitude)
            // Catch ex As Exception

            // End Try
            // Next
            // Dim rows() As DataRow = ContourTB.Select("LONGITUDE is null or LATITUDE is null")
            // For Each r As DataRow In rows
            // ContourTB.Rows.Remove(r)
            // Next
            catch (Exception ex)
            {
                Interaction.MsgBox("DHUB 2 :" + ex.Message, MsgBoxStyle.Critical, "Error in Loading Contour Data");
            }
            return ContourTB;
        }
        public DataTable GetWellContourListForReservoir(string ReservoirID, ref string ResName, string ValueField, string ValueDateField, string othercond = "")
        {
            var tb = new DataTable();
            string QueryContFinder = "";
            try
            {
                if (othercond.Length > 0)
                {
                    othercond = othercond + " and ";
                }
                if (ValueField == "LATEST_WC")
                {
                    QueryContFinder = "select distinct  uwi,UWI||'-'||FACILITY_NAME||'-'||facILITY_type||'-'||RESERVOIR_id as PPDM_WCS_UWI,well_completion_s,LONGITUDE,LATITUDE,decode(sign(LATEST_WC-1),-1,Latest_WC*100,LAtest_WC)  VALUE,decode(sign(LATEST_WC-1),-1,Latest_WC*100,LAtest_WC) LATEST_WC,CO2,SBHP_PRESSURE  from well_latest_data where " + othercond + " (Reservoir_ID='" + ReservoirID + "')  and (" + ValueDateField + " is not null) and (" + ValueField + " is not null) and (" + ValueField + " > 0)  "; // group by  uwi,UWI||'('||RESERVOIR_id||'-'||facILITY_type||')', LATITUDE  ,LONGITUDE  ," & ValueField ' & "," & ValueDateField
                }
                else
                {
                    QueryContFinder = "select distinct  uwi,UWI||'-'||FACILITY_NAME||'-'||facILITY_type||'-'||RESERVOIR_id as PPDM_WCS_UWI,well_completion_s,LONGITUDE,LATITUDE,LATEST_OIL_RATE,LIQUID_RATE,WHP,H2S,LATEST_FLP,LATEST_GOR,LATEST_SULFUR," + ValueField + " VALUE,CO2,SBHP_PRESSURE from well_latest_data where " + othercond + " (Reservoir_ID='" + ReservoirID + "')  and (" + ValueDateField + " is not null) and (" + ValueField + " is not null) and (" + ValueField + " > 0)  ";
                } // group by  uwi,UWI||'('||RESERVOIR_id||'-'||facILITY_type||')', LATITUDE  ,LONGITUDE  ," & ValueField ' & "," & ValueDateField



                // ResName = ""

                // End If
                // If LayerName.Length > 0 Then
                // QueryContFinder = "select distinct uwi, UWI||'('||RESERVOIR_id||'-'||facILITY_type||')' as PPDM_WCS_UWI,LATITUDE  ,LONGITUDE,max(" & ValueDateField & ")," & ValueDateField & "," & ValueField & " VALUE from finderweb.well_latest_data where " & othercond & " field_code='" & FieldCode & "'  and " & ValueDateField & "  is not null and " & ValueField & " is not null  group by  uwi,UWI||'('||RESERVOIR_id||'-'||facILITY_type||')', LATITUDE  ,LONGITUDE  ," & ValueField & "," & ValueDateField
                // Else
                // QueryContFinder = "select distinct  uwi,UWI||'-'||FACILITY_NAME||'-'||facILITY_type||'-'||RESERVOIR_id as PPDM_WCS_UWI,well_completion_s,X,Y," & ValueField & " VALUE from finderweb.well_latest_data where " & othercond & " (field_code='" & FieldCode & "')  and (" & ValueDateField & " is not null) and (" & ValueField & " is not null) and (" & ValueField & " > 0) and (X is not  null) and (Y is  not null) " ' group by  uwi,UWI||'('||RESERVOIR_id||'-'||facILITY_type||')', LATITUDE  ,LONGITUDE  ," & ValueField ' & "," & ValueDateField
                // ' End If
                // ContourTB = WellLatestDataTable.Select(othercond & " field_code='" & FieldCode & "'  and " & ValueDateField & " is not null and " & ValueField & " is not null and LONGITUDE is not null and LATITUDE  is not null").CopyToDataTable
                ContourTB = new OracleDataTable();
                ContourTB.SelectCommand = new Devart.Data.Oracle.OracleCommand(QueryContFinder, KocConfig.DhubDatabaseConnection);
                ContourTB.Fill();
                return ContourTB;
            }

            catch (Exception ex)
            {
                Interaction.MsgBox("DHUB 2 :" + ex.Message, MsgBoxStyle.Critical, "Error in Loading Contour Data");
            }
            return ContourTB;
        }
        public void GetReservoirList(string FieldCode)
        {

            string QueryResFinder = "select distinct RESERVOIR_NAME,RESERVOIR_ID from well_latest_data where field_code='" + FieldCode + "'";
            string QueryResPPDM = "select distinct POOL_NAME,POOL_ID from POOL  where field_id='" + FieldCode + "'";
            ReservoirList = new OracleDataTable();

            ReservoirList.SelectCommand = new Devart.Data.Oracle.OracleCommand(QueryResPPDM, KocConfig.Finderconn);

            ReservoirList.Fill();
        }
        public void GetFieldList()
        {
            List<cls_fieldrep> fieldsid = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_fieldrep>("select Field_code,field_name from koc.Field_hdr").ToList;
            foreach (var fldid in fieldsid)
            {
                var fieldx = new cls_FinderField();
                // fieldx = ReadFieldJsonXML(fldid)
                // If IsNothing(fieldx) Then
                fieldx = new cls_FinderField();
                fieldx.Field_Code = fldid.Field_code;
                fieldx.Field_Name = fldid.Field_name;
                fieldx.ConnectedWells = new List<cls_Finderwell>(); // GetFieldBasicInfo(fldid)
                string FieldArea;
                FieldArea = KocConfig.DhubContext.ExecuteStoreQuery<string>("  select distinct area from well_latest_data where field_code='" + fieldx.Field_Code + "'").FirstOrDefault;
                if (FieldArea == "SEK")
                {
                    FieldArea = "SK";
                }
                fieldx.ReservoirList = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<Reservoir>("select distinct RESERVOIR_NAME,RESERVOIR_ID from finderweb.well_latest_data where field_code='" + fieldx.Field_Code + "'", default).ToList;
                fieldx.LayerList = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<Layer>("select distinct LAYER_NAME,RESERVOIR_ID from finderweb.well_latest_data where field_code='" + fieldx.Field_Code + "'", default).ToList;


                fieldx.Area = FieldArea;
                FieldDataList.Add(fieldx);
            }
        }
        public List<cls_ProductionPerLF> GetFieldProductionPerLFResCloseOpen(string pFieldID, string Status = "")
        {
            if (string.IsNullOrEmpty(Status))
            {
                return KocConfig.DhubContext.ExecuteStoreQuery<cls_ProductionPerLF>("Select  sum(round(a.LIQUID_RATE * (1 - a.LATEST_WC / 100),0)) as  BOPD,sum(round(a.ALLOWABLE -round(a.LIQUID_RATE),0)) as Potential, sum(round(a.LIQUID_RATE * (a.LATEST_WC / 100),0)) as BWPD,decode(LF_DESCR,'NATURALLY_FLOWING','NF',LF_DESCR) LF,reservoir_id    from well_latest_Data  a where field_code ='" + pFieldID + "'   group by decode(LF_DESCR,'NATURALLY_FLOWING','NF',LF_DESCR) ,reservoir_id").ToList;
            }
            else
            {
                return KocConfig.DhubContext.ExecuteStoreQuery<cls_ProductionPerLF>("Select  sum(round(a.LIQUID_RATE * (1 - a.LATEST_WC / 100),0)) as  BOPD,sum(round(a.ALLOWABLE -round(a.LIQUID_RATE),0)) as Potential, sum(round(a.LIQUID_RATE * (a.LATEST_WC / 100),0)) as BWPD,decode(LF_DESCR,'NATURALLY_FLOWING','NF',LF_DESCR) LF,reservoir_id    from well_latest_Data  a where field_code ='" + pFieldID + "'  and status_type=decode('" + Status + "',null,status_type,'" + Status + "') group by decode(LF_DESCR,'NATURALLY_FLOWING','NF',LF_DESCR) ,reservoir_id").ToList;
            }

        }
        public List<cls_ProductionPerLF> GetFieldProductionPerLFResCloseOpen(string pFieldID, string resid, string Status = "")
        {
            return KocConfig.DhubContext.ExecuteStoreQuery<cls_ProductionPerLF>("Select  sum(round(a.LIQUID_RATE * (1 - a.LATEST_WC / 100),0)) as  BOPD,sum(round(a.ALLOWABLE -round(a.LIQUID_RATE),0)) as Potential, sum(round(a.LIQUID_RATE * (a.LATEST_WC / 100),0)) as BWPD,decode(LF_DESCR,'NATURALLY_FLOWING','NF',LF_DESCR) LF,status_type status,reservoir_id    from well_latest_Data  a where field_code ='" + pFieldID + "'  and reservoir_id='" + resid + "' and status_type=decode('" + Status + "',null,status_type,'" + Status + "')  group by decode(LF_DESCR,'NATURALLY_FLOWING','NF',LF_DESCR) ,status_type ,reservoir_id").ToList;
        }

        public List<cls_ProductionPerLF> GetFieldProductionPerRes(string pFieldID, string Status = "")
        {
            return KocConfig.DhubContext.ExecuteStoreQuery<cls_ProductionPerLF>("Select  sum(round(a.LIQUID_RATE * (1 - a.LATEST_WC / 100),0)) as  BOPD,sum(round(a.ALLOWABLE -round(a.LIQUID_RATE),0)) as Potential, sum(round(a.LIQUID_RATE * (a.LATEST_WC / 100),0)) as BWPD,reservoir_id  from well_latest_Data  a where field_code ='" + pFieldID + "' and status_type=decode('" + Status + "',null,status_type,'" + Status + "') group by reservoir_id ").ToList;
        }
        public List<cls_ProductionPerLF> GetFieldProductionPerRes(string pFieldID, string resid, string Status = "")
        {
            return KocConfig.DhubContext.ExecuteStoreQuery<cls_ProductionPerLF>("Select  sum(round(a.LIQUID_RATE * (1 - a.LATEST_WC / 100),0)) as  BOPD,sum(round(a.ALLOWABLE -round(a.LIQUID_RATE),0)) as Potential, sum(round(a.LIQUID_RATE * (a.LATEST_WC / 100),0)) as BWPD,reservoir_id  from well_latest_Data  a where field_code ='" + pFieldID + "' and status_type=decode('" + Status + "',null,status_type,'" + Status + "') and reservoir_id='" + resid + "' group by reservoir_id ").ToList;
        }
        public List<cls_ProductionPerLF> GetFieldProductionPerLF(string pFieldID, string Status = "")
        {
            return KocConfig.DhubContext.ExecuteStoreQuery<cls_ProductionPerLF>("Select  sum(round(a.LIQUID_RATE * (1 - a.LATEST_WC / 100),0)) as  BOPD,sum(round(a.ALLOWABLE -round(a.LIQUID_RATE),0)) as Potential, sum(round(a.LIQUID_RATE * (a.LATEST_WC / 100),0)) as BWPD,decode(LF_DESCR,'NATURALLY_FLOWING','NF',LF_DESCR) LF  from well_latest_Data  a where field_code ='" + pFieldID + "' and status_type=decode('" + Status + "',null,status_type,'" + Status + "') group by decode(LF_DESCR,'NATURALLY_FLOWING','NF',LF_DESCR) ").ToList;
        }
        public List<cls_ProductionPerLF> GetFieldProductionPerLF(string pFieldID, string resid, string Status = "")
        {
            return KocConfig.DhubContext.ExecuteStoreQuery<cls_ProductionPerLF>("Select  sum(round(a.LIQUID_RATE * (1 - a.LATEST_WC / 100),0)) as  BOPD,sum(round(a.ALLOWABLE -round(a.LIQUID_RATE),0)) as Potential, sum(round(a.LIQUID_RATE * (a.LATEST_WC / 100),0)) as BWPD,decode(LF_DESCR,'NATURALLY_FLOWING','NF',LF_DESCR) LF    from well_latest_Data  a where field_code ='" + pFieldID + "'  and reservoir_id='" + resid + "' and status_type=decode('" + Status + "',null,status_type,'" + Status + "')   group by decode(LF_DESCR,'NATURALLY_FLOWING','NF',LF_DESCR) ").ToList;
        }
        public List<cls_ProductionPerLF> GetProductionCalcHistForFieldAll(string pfieldID)
        {
            return KocConfig.DhubContext.ExecuteStoreQuery<cls_ProductionPerLF>("Select  sum(round(a.LIQUID_RATE * (1 - a.LATEST_WC / 100),0)) as  BOPD," + "sum(Round(a.ALLOWABLE - Round(a.LIQUID_RATE), 0)) As Potential," + "sum(round(a.LIQUID_RATE * (a.LATEST_WC / 100),0)) as BWPD," + "decode(LF_DESCR,'NATURALLY_FLOWING','NF',LF_DESCR) LF," + "a.status_type status, a.reservoir_id, a.field_code, updatedate " + "from well_latest_Data_hist a " + "where  STATUS_TYPE in ('OPEN','CLOSE') " + "And updatedate >=SYSDATE - 30 " + "And  a.field_code='" + pfieldID + "'" + "group by decode(LF_DESCR,'NATURALLY_FLOWING','NF',LF_DESCR) ,a.status_type ,a.reservoir_id  ,a.field_code,updatedate " + "order by updatedate,a.field_code,a.reservoir_id ,status_type asc", default).ToList;

        }
        public List<cls_ProductionPerLF> GetProductionCalcHistForFieldLF(string pfieldID)
        {
            return KocConfig.DhubContext.ExecuteStoreQuery<cls_ProductionPerLF>("Select  sum(round(a.LIQUID_RATE * (1 - a.LATEST_WC / 100),0)) as  BOPD," + "sum(Round(a.ALLOWABLE - Round(a.LIQUID_RATE), 0)) As Potential," + "sum(round(a.LIQUID_RATE * (a.LATEST_WC / 100),0)) as BWPD," + "decode(LF_DESCR,'NATURALLY_FLOWING','NF',LF_DESCR) LF," + "a.status_type status, a.field_code, updatedate " + "from well_latest_Data_hist a " + "where  STATUS_TYPE in ('OPEN','CLOSE') " + "And updatedate >=SYSDATE - 30 " + "And  a.field_code='" + pfieldID + "'" + "group by decode(LF_DESCR,'NATURALLY_FLOWING','NF',LF_DESCR) ,a.status_type  ,a.field_code,updatedate " + "order by updatedate,a.field_code,status_type asc", default).ToList;

        }
        public List<cls_ProductionPerLF> GetProductionCalcHistForFielByRes(string pfieldID)
        {
            return KocConfig.DhubContext.ExecuteStoreQuery<cls_ProductionPerLF>("Select  sum(round(a.LIQUID_RATE * (1 - a.LATEST_WC / 100),0)) as  BOPD," + "sum(Round(a.ALLOWABLE - Round(a.LIQUID_RATE), 0)) As Potential," + "sum(round(a.LIQUID_RATE * (a.LATEST_WC / 100),0)) as BWPD," + "a.status_type status, a.reservoir_id, a.field_code, updatedate " + "from well_latest_Data_hist a " + "where  STATUS_TYPE in ('OPEN','CLOSE') " + "And updatedate >=SYSDATE - 30 " + "And  a.field_code='" + pfieldID + "'" + "group by a.status_type ,a.reservoir_id  ,a.field_code,updatedate " + "order by updatedate,a.field_code,a.reservoir_id ,status_type asc", default).ToList;

        }
        public List<cls_ProductionPerLF> GetProductionCalcHistForField(string pfieldID)
        {
            return KocConfig.DhubContext.ExecuteStoreQuery<cls_ProductionPerLF>("Select  sum(round(a.LIQUID_RATE * (1 - a.LATEST_WC / 100),0)) as  BOPD," + "sum(Round(a.ALLOWABLE - Round(a.LIQUID_RATE), 0)) As Potential," + "sum(round(a.LIQUID_RATE * (a.LATEST_WC / 100),0)) as BWPD," + "a.status_type status,  a.field_code, updatedate " + "from well_latest_Data_hist a " + "where  STATUS_TYPE in ('OPEN','CLOSE') " + "And updatedate >=SYSDATE - 30 " + "And  a.field_code='" + pfieldID + "'" + "group by a.status_type ,a.field_code,updatedate " + "order by updatedate,a.field_code,status_type asc", default).ToList;

        }
        public List<cls_ProductionForField> GetProdHistForField(string pfieldID)
        {
            return KocConfig.DhubContext.ExecuteStoreQuery<cls_ProductionForField>("Select  sum(round(a.LIQUID_RATE * (1 - a.LATEST_WC / 100),0)) as  ActualBOPD, " + "sum(Round(a.ALLOWABLE - Round(a.LIQUID_RATE), 0)) As ActualPotential, " + "sum(round(a.LIQUID_RATE * (a.LATEST_WC / 100),0)) as ActualBWPD, a.field_code, a.updatedate , " + " sum(round(b.LIQUID_RATE * (1 - b.LATEST_WC / 100),0)) as  LossBOPD, " + "sum(Round(b.ALLOWABLE - Round(b.LIQUID_RATE), 0)) As LossPotential, " + "sum(round(b.LIQUID_RATE * (b.LATEST_WC / 100),0)) as LossBWPD, " + " sum(round(a.LIQUID_RATE * (1 - a.LATEST_WC / 100),0))+sum(round(b.LIQUID_RATE * (1 - b.LATEST_WC / 100),0)) IdealBopd " + "from well_latest_Data_hist a ,well_latest_Data_hist b " + "where  a.STATUS_TYPE in ('OPEN')  " + "And  a.updatedate <=SYSDATE - 30  " + "and  b.STATUS_TYPE in ('CLOSE')  " + "And  b.updatedate <=SYSDATE - 30  " + "And  a.field_code='" + pfieldID + "'" + "And  b.field_code='" + pfieldID + "'" + "and b.updatedate=a.updatedate " + "group by a.field_code,a.updatedate " + "order by a.updatedate,a.field_code asc", default).ToList;

        }
        public List<cls_ProductionPerLF> GetProdHistForField(string pfieldID, string resid)
        {
            return KocConfig.DhubContext.ExecuteStoreQuery<cls_ProductionPerLF>("Select  sum(round(a.LIQUID_RATE * (1 - a.LATEST_WC / 100),0)) as  ActualBOPD, " + "sum(Round(a.ALLOWABLE - Round(a.LIQUID_RATE), 0)) As ActualPotential, " + "sum(round(a.LIQUID_RATE * (a.LATEST_WC / 100),0)) as ActualBWPD, a.field_code, a.updatedate ,a.reservoir_id " + " sum(round(b.LIQUID_RATE * (1 - b.LATEST_WC / 100),0)) as  LossBOPD, " + "sum(Round(b.ALLOWABLE - Round(b.LIQUID_RATE), 0)) As LossPotential, " + "sum(round(b.LIQUID_RATE * (b.LATEST_WC / 100),0)) as LossBWPD, " + " sum(round(a.LIQUID_RATE * (1 - a.LATEST_WC / 100),0))+sum(round(b.LIQUID_RATE * (1 - b.LATEST_WC / 100),0)) IdealBopd " + "from well_latest_Data_hist a ,well_latest_Data_hist b " + "where  a.STATUS_TYPE in ('OPEN')  " + "And  a.updatedate <=SYSDATE - 30  " + "and  b.STATUS_TYPE in ('CLOSE')  " + "And  b.updatedate <=SYSDATE - 30  " + "And  a.field_code='" + pfieldID + "'" + "And  b.field_code='" + pfieldID + "'" + "And  a.reservoir_id='" + resid + "'" + "And  b.reservoir_id='" + resid + "'" + "and b.updatedate=a.updatedate " + "group by a.field_code,a.updatedate,a.reservoir_id " + "order by a.updatedate,a.field_code asc", default).ToList;

        }

        #region Wide Queries
        public List<cls_Wide_workover> GetWideWorkoverforField(string pFieldID)
        {
            string str = "select 'Water Action Date'	WaterActionDate" + "'Water Available'	WaterAvailable" + "'Well Budget Name'	WellBudgetName" + "'Well Budget Year'	WellBudgetYear" + "'Well Objective'	WellObjective" + "'Well Profile Target'	WellProfileTarget" + "'Connection Type'	ConnectionType" + "'Program Ready'	ProgramReady" + "'WS Remarks'	WSRemarks" + "'Exp Gas Gain (MSCFPD)2'	ExpGasGainMSCFPD2" + "'Exp Gas Restore (MSCFPD')	ExpGasRestoreMSCFPD" + "'Expected Hookup Date'	ExpectedHookupDate" + "'Expected Open Date'	ExpectedOpenDate" + "'Exp Gas Gain and Restore'	ExpGasGainandRestore" + "'Exp Water Gain and Restore'	ExpWaterGainandRestore" + "'Scheduled Finish Date'	ScheduledFinishDate" + "'Scheduled Start Date'	ScheduledStartDate" + "'Gain Restore Difference'	GainRestoreDifference" + "'Gas Rate Before (MSCFPD)'	GasRateBeforeMSCFPD" + "'Movement Duration'	MovementDuration" + "'Operational Duration Overrun'	OperationalDurationOverrun" + "'Rig Related Comments'	RigRelatedComments" + "'Tested Gas Rate After'	TestedGasRateAfter" + "'Rig Drilling Category'	RigDrillingCategory" + "'Rig Category'	RigCategory" + "'Field (Original)'	FieldOriginal" + "'Drilling/WO Type (Original)'	DrillingWOTypeOriginal" + "'Reservoir (Original)'	ReservoirOriginal" + "'Completion Type (Original)'	CompletionTypeOriginal" + "'Trajectory Type (Original)'	TrajectoryTypeOriginal" + "'Well Objective (Original)'	WellObjectiveOriginal" + "'Workover No.'	WorkoverNo" + "'Completion Activity Exists'	CompletionActivityExists" + "'GP Remarks'	GPRemarks" + "'PO Remarks'	PORemarks" + "'Program Status'	ProgramStatus" + "'Location Constraints Feedback'	LocationConstraintsFeedback" + "'Location Feedback'	LocationFeedback" + "'Rigless Job Requested Date'	RiglessJobRequestedDate" + "'Rigless Job FD Plan Date'	RiglessJobFDPlanDate" + "'Rigless Job WS Plan Date'	RiglessJobWSPlanDate" + "'Rigless Job Requester'	RiglessJobRequester" + "'Rigless Job Zone'	RiglessJobZone" + "'Rigless Job Well String'	RiglessJobWellString" + "'Rigless Job Service Name'	RiglessJobServiceName" + "'Rigless Job Service Category'	RiglessJobServiceCategory" + "'Rigless Job Request Status'	RiglessJobRequestStatus" + "'Rigless Job Request ID'	RiglessJobRequestID" + "'Rigless Job Contractor Code'	RiglessJobContractorCode" + "'Rep Tested Oil Rate Gain'	RepTestedOilRateGain" + "'Rep Oil Rate Before'	RepOilRateBefore" + "'Rep Water Rate Before'	RepWaterRateBefore" + "'Rep GOR Before (SCF/STB)'	RepGORBeforeSCFSTB" + "'Rep Tested Oil Rate After'	RepTestedOilRateAfter" + "'Rep Tested Water Rate After'	RepTestedWaterRateAfter" + "'Rep Tested GOR (SCF/STB)'	RepTestedGORSCFSTB" + "'Rep Tested Rate After Date'	RepTestedRateAfterDate" + "'Activity No'	ActivityNo" + "'ASSET'	ASSET" + "'UWI'	UWI" + "'Operational Status'	OperationalStatus" + "'Activity'	Activity" + "'Sub Activity'	SubActivity" + "'Actual Finish Date'	ActualFinishDate" + "'Actual Hookup Date'	ActualHookupDate" + "'Actual Open Date'	ActualOpenDate" + "'Actual Spud Date'	ActualSpudDate" + "'Actual Start Date'	ActualStartDate" + "'AL Equipment Status'	ALEquipmentStatus" + "'Artifical Lift Contractor'	ArtificalLiftContractor" + "'Completion Type'	CompletionType" + "'Additional Well Details'	AdditionalWellDetails" + "'Construction Action Date'	ConstructionActionDate" + "'Construction Complete'	ConstructionComplete" + "'Coring Required'	CoringRequired" + "'Created Date'	CreatedDate" + "'Drilling Eng. Remarks'	DrillingEngRemarks" + "'Drilling Ops. Remarks'	DrillingOpsRemarks" + "'Drilling/WO Type'	DrillingWOType" + "'Drill Pipe Required'	DrillPipeRequired" + "'Dual Compl Rig Required'	DualComplRigRequired" + "'Easting'	Easting" + "'A/L Required'	ALRequired" + "'AL Equiment Available Date'	ALEquimentAvailableDate" + "'Exp Hookup to Open'	ExpHookuptoOpen" + "'Exp Release to Hookup'	ExpReleasetoHookup" + "'Exp Prior to Start'	ExpPriortoStart" + "'Exp Gas Gain (MCSFPD)1'	ExpGasGainMCSFPD1" + "'Exp Gas Restore (MCSFPD)'	ExpGasRestoreMCSFPD" + "'Exp GOR (STF/STB)'	ExpGORSTFSTB" + "'Exp Water Restore (BWPD)'	ExpWaterRestoreBWPD" + "'Schedule Duration (Days)'	ScheduleDurationDays" + "'Expected Oil Gain (BOPD)'	ExpectedOilGainBOPD" + "'Expected Water Gain (BWPD)'	ExpectedWaterGainBWPD" + "'Exp Oil Gain and Restore'	ExpOilGainandRestore" + "'Exp Oil Restore'	ExpOilRestore" + "'FD Estimated Schedule Duration'	FDEstimatedScheduleDuration" + "'FD Remarks'	FDRemarks" + "'Field'	Field" + "'Flowline Contractor'	FlowlineContractor" + "'Gain Restore Difference Reason'	GainRestoreDifferenceReason" + "'GC Area'	GCArea" + "'GC (Target)'	GCTarget" + "'GOR Before (SCF/STB)'	GORBeforeSCFSTB" + "'GP_Maintenance'	GP_Maintenance" + "'Header (HP/LP)'	HeaderHPLP" + "'Location Clearance Date'	LocationClearanceDate" + "'Location Constraint Date'	LocationConstraintDate" + "'Location Constraint Details'	LocationConstraintDetails" + "'Location Constraint'	LocationConstraint" + "'Location Ready'	LocationReady" + "'Location Released'	LocationReleased" + "'Material Available'	MaterialAvailable" + "'Material Pending for Wells'	MaterialPendingforWells" + "'Material Pending for Workovers'	MaterialPendingforWorkovers" + "'Material Status'	MaterialStatus" + "'Material Available Date'	MaterialAvailableDate" + "'MOCApprovedDate'	MOCApprovedDate" + "'MOCRemarks'	MOCRemarks" + "'MOCRequestedDate'	MOCRequestedDate" + "'MOC Status'	MOCStatus" + "'Moc Type'	MocType" + "'Modified Date'	ModifiedDate" + "'Movement Duration Reason'	MovementDurationReason" + "'No of Tests'	NoofTests" + "'Northing'	Northing" + "'Objectives'	Objectives" + "'Operational Duration Reason'	OperationalDurationReason" + "'PDDP Complete'	PDDPComplete" + "'Planned Well Completion'	PlannedWellCompletion" + "'2PP Complete'	2PPComplete" + "'Oil Rate Before (BOPD)'	OilRateBeforeBOPD" + "'Water Rate Before (BWPD')	WaterRateBeforeBWPD" + "'Profile Locked'	ProfileLocked" + "'Project'	Project" + "'Activity Quarter'	ActivityQuarter" + "'Release Action Date'	ReleaseActionDate" + "'Reservoir'	Reservoir" + "'Rig Expiry Date'	RigExpiryDate" + "'Tracking'	Tracking" + "'Rig HP'	RigHP" + "'Rig Status' RigStatus" + "'Rig HP Required'	RigHPRequired" + "'Rig Name'	RigName" + "'Rig Schedule Well Name'	RigScheduleWellName" + "'Rotation Required'	RotationRequired" + "'Sequence'	Sequence" + "'Slot'	Slot" + "'System (Wet/Dry)'	SystemWetDry" + "'Program Submitted'	ProgramSubmitted" + "'JOB NOT COMPLETE SUSPENDED'	JOBNOTCOMPLETESUSPENDED" + "'MOC Request'	MOCRequest" + "'Casing Policy'	CasingPolicy" + "'DIMS No'	DIMSNo" + "'Tested GOR (SCF/STB)'	TestedGORSCFSTB" + "'Tested Oil Rate Gain (BOPD)'	TestedOilRateGainBOPD" + "'Tested Rate After Date'	TestedRateAfterDate" + "'Tested Oil Rate After (BOPD)'	TestedOilRateAfterBOPD" + "'Tested Water Rate After (BWPD)'	TestedWaterRateAfterBWPD	from finderweb.wide_workover where field='" + pFieldID + "'";

            return KocConfig.DhubContext.ExecuteStoreQuery<cls_Wide_workover>(str, default).ToList;
        }
        public List<cls_Wide_workover> GetWideWorkoverforUWI(string puwi)
        {
            string str = "select 'Water Action Date'	WaterActionDate" + "'Water Available'	WaterAvailable" + "'Well Budget Name'	WellBudgetName" + "'Well Budget Year'	WellBudgetYear" + "'Well Objective'	WellObjective" + "'Well Profile Target'	WellProfileTarget" + "'Connection Type'	ConnectionType" + "'Program Ready'	ProgramReady" + "'WS Remarks'	WSRemarks" + "'Exp Gas Gain (MSCFPD)2'	ExpGasGainMSCFPD2" + "'Exp Gas Restore (MSCFPD')	ExpGasRestoreMSCFPD" + "'Expected Hookup Date'	ExpectedHookupDate" + "'Expected Open Date'	ExpectedOpenDate" + "'Exp Gas Gain and Restore'	ExpGasGainandRestore" + "'Exp Water Gain and Restore'	ExpWaterGainandRestore" + "'Scheduled Finish Date'	ScheduledFinishDate" + "'Scheduled Start Date'	ScheduledStartDate" + "'Gain Restore Difference'	GainRestoreDifference" + "'Gas Rate Before (MSCFPD)'	GasRateBeforeMSCFPD" + "'Movement Duration'	MovementDuration" + "'Operational Duration Overrun'	OperationalDurationOverrun" + "'Rig Related Comments'	RigRelatedComments" + "'Tested Gas Rate After'	TestedGasRateAfter" + "'Rig Drilling Category'	RigDrillingCategory" + "'Rig Category'	RigCategory" + "'Field (Original)'	FieldOriginal" + "'Drilling/WO Type (Original)'	DrillingWOTypeOriginal" + "'Reservoir (Original)'	ReservoirOriginal" + "'Completion Type (Original)'	CompletionTypeOriginal" + "'Trajectory Type (Original)'	TrajectoryTypeOriginal" + "'Well Objective (Original)'	WellObjectiveOriginal" + "'Workover No.'	WorkoverNo" + "'Completion Activity Exists'	CompletionActivityExists" + "'GP Remarks'	GPRemarks" + "'PO Remarks'	PORemarks" + "'Program Status'	ProgramStatus" + "'Location Constraints Feedback'	LocationConstraintsFeedback" + "'Location Feedback'	LocationFeedback" + "'Rigless Job Requested Date'	RiglessJobRequestedDate" + "'Rigless Job FD Plan Date'	RiglessJobFDPlanDate" + "'Rigless Job WS Plan Date'	RiglessJobWSPlanDate" + "'Rigless Job Requester'	RiglessJobRequester" + "'Rigless Job Zone'	RiglessJobZone" + "'Rigless Job Well String'	RiglessJobWellString" + "'Rigless Job Service Name'	RiglessJobServiceName" + "'Rigless Job Service Category'	RiglessJobServiceCategory" + "'Rigless Job Request Status'	RiglessJobRequestStatus" + "'Rigless Job Request ID'	RiglessJobRequestID" + "'Rigless Job Contractor Code'	RiglessJobContractorCode" + "'Rep Tested Oil Rate Gain'	RepTestedOilRateGain" + "'Rep Oil Rate Before'	RepOilRateBefore" + "'Rep Water Rate Before'	RepWaterRateBefore" + "'Rep GOR Before (SCF/STB)'	RepGORBeforeSCFSTB" + "'Rep Tested Oil Rate After'	RepTestedOilRateAfter" + "'Rep Tested Water Rate After'	RepTestedWaterRateAfter" + "'Rep Tested GOR (SCF/STB)'	RepTestedGORSCFSTB" + "'Rep Tested Rate After Date'	RepTestedRateAfterDate" + "'Activity No'	ActivityNo" + "'ASSET'	ASSET" + "'UWI'	UWI" + "'Operational Status'	OperationalStatus" + "'Activity'	Activity" + "'Sub Activity'	SubActivity" + "'Actual Finish Date'	ActualFinishDate" + "'Actual Hookup Date'	ActualHookupDate" + "'Actual Open Date'	ActualOpenDate" + "'Actual Spud Date'	ActualSpudDate" + "'Actual Start Date'	ActualStartDate" + "'AL Equipment Status'	ALEquipmentStatus" + "'Artifical Lift Contractor'	ArtificalLiftContractor" + "'Completion Type'	CompletionType" + "'Additional Well Details'	AdditionalWellDetails" + "'Construction Action Date'	ConstructionActionDate" + "'Construction Complete'	ConstructionComplete" + "'Coring Required'	CoringRequired" + "'Created Date'	CreatedDate" + "'Drilling Eng. Remarks'	DrillingEngRemarks" + "'Drilling Ops. Remarks'	DrillingOpsRemarks" + "'Drilling/WO Type'	DrillingWOType" + "'Drill Pipe Required'	DrillPipeRequired" + "'Dual Compl Rig Required'	DualComplRigRequired" + "'Easting'	Easting" + "'A/L Required'	ALRequired" + "'AL Equiment Available Date'	ALEquimentAvailableDate" + "'Exp Hookup to Open'	ExpHookuptoOpen" + "'Exp Release to Hookup'	ExpReleasetoHookup" + "'Exp Prior to Start'	ExpPriortoStart" + "'Exp Gas Gain (MCSFPD)1'	ExpGasGainMCSFPD1" + "'Exp Gas Restore (MCSFPD)'	ExpGasRestoreMCSFPD" + "'Exp GOR (STF/STB)'	ExpGORSTFSTB" + "'Exp Water Restore (BWPD)'	ExpWaterRestoreBWPD" + "'Schedule Duration (Days)'	ScheduleDurationDays" + "'Expected Oil Gain (BOPD)'	ExpectedOilGainBOPD" + "'Expected Water Gain (BWPD)'	ExpectedWaterGainBWPD" + "'Exp Oil Gain and Restore'	ExpOilGainandRestore" + "'Exp Oil Restore'	ExpOilRestore" + "'FD Estimated Schedule Duration'	FDEstimatedScheduleDuration" + "'FD Remarks'	FDRemarks" + "'Field'	Field" + "'Flowline Contractor'	FlowlineContractor" + "'Gain Restore Difference Reason'	GainRestoreDifferenceReason" + "'GC Area'	GCArea" + "'GC (Target)'	GCTarget" + "'GOR Before (SCF/STB)'	GORBeforeSCFSTB" + "'GP_Maintenance'	GP_Maintenance" + "'Header (HP/LP)'	HeaderHPLP" + "'Location Clearance Date'	LocationClearanceDate" + "'Location Constraint Date'	LocationConstraintDate" + "'Location Constraint Details'	LocationConstraintDetails" + "'Location Constraint'	LocationConstraint" + "'Location Ready'	LocationReady" + "'Location Released'	LocationReleased" + "'Material Available'	MaterialAvailable" + "'Material Pending for Wells'	MaterialPendingforWells" + "'Material Pending for Workovers'	MaterialPendingforWorkovers" + "'Material Status'	MaterialStatus" + "'Material Available Date'	MaterialAvailableDate" + "'MOCApprovedDate'	MOCApprovedDate" + "'MOCRemarks'	MOCRemarks" + "'MOCRequestedDate'	MOCRequestedDate" + "'MOC Status'	MOCStatus" + "'Moc Type'	MocType" + "'Modified Date'	ModifiedDate" + "'Movement Duration Reason'	MovementDurationReason" + "'No of Tests'	NoofTests" + "'Northing'	Northing" + "'Objectives'	Objectives" + "'Operational Duration Reason'	OperationalDurationReason" + "'PDDP Complete'	PDDPComplete" + "'Planned Well Completion'	PlannedWellCompletion" + "'2PP Complete'	2PPComplete" + "'Oil Rate Before (BOPD)'	OilRateBeforeBOPD" + "'Water Rate Before (BWPD')	WaterRateBeforeBWPD" + "'Profile Locked'	ProfileLocked" + "'Project'	Project" + "'Activity Quarter'	ActivityQuarter" + "'Release Action Date'	ReleaseActionDate" + "'Reservoir'	Reservoir" + "'Rig Expiry Date'	RigExpiryDate" + "'Tracking'	Tracking" + "'Rig HP'	RigHP" + "'Rig Status' RigStatus" + "'Rig HP Required'	RigHPRequired" + "'Rig Name'	RigName" + "'Rig Schedule Well Name'	RigScheduleWellName" + "'Rotation Required'	RotationRequired" + "'Sequence'	Sequence" + "'Slot'	Slot" + "'System (Wet/Dry)'	SystemWetDry" + "'Program Submitted'	ProgramSubmitted" + "'JOB NOT COMPLETE SUSPENDED'	JOBNOTCOMPLETESUSPENDED" + "'MOC Request'	MOCRequest" + "'Casing Policy'	CasingPolicy" + "'DIMS No'	DIMSNo" + "'Tested GOR (SCF/STB)'	TestedGORSCFSTB" + "'Tested Oil Rate Gain (BOPD)'	TestedOilRateGainBOPD" + "'Tested Rate After Date'	TestedRateAfterDate" + "'Tested Oil Rate After (BOPD)'	TestedOilRateAfterBOPD" + "'Tested Water Rate After (BWPD)'	TestedWaterRateAfterBWPD	from finderweb.wide_workover where uwi='" + puwi + "'";

            return KocConfig.DhubContext.ExecuteStoreQuery<cls_Wide_workover>(str, default).ToList;
        }
        public List<cls_Wide_workover> GetWideWorkoverforGC(string pGC)
        {
            string str = "select 'Water Action Date'	WaterActionDate" + "'Water Available'	WaterAvailable" + "'Well Budget Name'	WellBudgetName" + "'Well Budget Year'	WellBudgetYear" + "'Well Objective'	WellObjective" + "'Well Profile Target'	WellProfileTarget" + "'Connection Type'	ConnectionType" + "'Program Ready'	ProgramReady" + "'WS Remarks'	WSRemarks" + "'Exp Gas Gain (MSCFPD)2'	ExpGasGainMSCFPD2" + "'Exp Gas Restore (MSCFPD')	ExpGasRestoreMSCFPD" + "'Expected Hookup Date'	ExpectedHookupDate" + "'Expected Open Date'	ExpectedOpenDate" + "'Exp Gas Gain and Restore'	ExpGasGainandRestore" + "'Exp Water Gain and Restore'	ExpWaterGainandRestore" + "'Scheduled Finish Date'	ScheduledFinishDate" + "'Scheduled Start Date'	ScheduledStartDate" + "'Gain Restore Difference'	GainRestoreDifference" + "'Gas Rate Before (MSCFPD)'	GasRateBeforeMSCFPD" + "'Movement Duration'	MovementDuration" + "'Operational Duration Overrun'	OperationalDurationOverrun" + "'Rig Related Comments'	RigRelatedComments" + "'Tested Gas Rate After'	TestedGasRateAfter" + "'Rig Drilling Category'	RigDrillingCategory" + "'Rig Category'	RigCategory" + "'Field (Original)'	FieldOriginal" + "'Drilling/WO Type (Original)'	DrillingWOTypeOriginal" + "'Reservoir (Original)'	ReservoirOriginal" + "'Completion Type (Original)'	CompletionTypeOriginal" + "'Trajectory Type (Original)'	TrajectoryTypeOriginal" + "'Well Objective (Original)'	WellObjectiveOriginal" + "'Workover No.'	WorkoverNo" + "'Completion Activity Exists'	CompletionActivityExists" + "'GP Remarks'	GPRemarks" + "'PO Remarks'	PORemarks" + "'Program Status'	ProgramStatus" + "'Location Constraints Feedback'	LocationConstraintsFeedback" + "'Location Feedback'	LocationFeedback" + "'Rigless Job Requested Date'	RiglessJobRequestedDate" + "'Rigless Job FD Plan Date'	RiglessJobFDPlanDate" + "'Rigless Job WS Plan Date'	RiglessJobWSPlanDate" + "'Rigless Job Requester'	RiglessJobRequester" + "'Rigless Job Zone'	RiglessJobZone" + "'Rigless Job Well String'	RiglessJobWellString" + "'Rigless Job Service Name'	RiglessJobServiceName" + "'Rigless Job Service Category'	RiglessJobServiceCategory" + "'Rigless Job Request Status'	RiglessJobRequestStatus" + "'Rigless Job Request ID'	RiglessJobRequestID" + "'Rigless Job Contractor Code'	RiglessJobContractorCode" + "'Rep Tested Oil Rate Gain'	RepTestedOilRateGain" + "'Rep Oil Rate Before'	RepOilRateBefore" + "'Rep Water Rate Before'	RepWaterRateBefore" + "'Rep GOR Before (SCF/STB)'	RepGORBeforeSCFSTB" + "'Rep Tested Oil Rate After'	RepTestedOilRateAfter" + "'Rep Tested Water Rate After'	RepTestedWaterRateAfter" + "'Rep Tested GOR (SCF/STB)'	RepTestedGORSCFSTB" + "'Rep Tested Rate After Date'	RepTestedRateAfterDate" + "'Activity No'	ActivityNo" + "'ASSET'	ASSET" + "'UWI'	UWI" + "'Operational Status'	OperationalStatus" + "'Activity'	Activity" + "'Sub Activity'	SubActivity" + "'Actual Finish Date'	ActualFinishDate" + "'Actual Hookup Date'	ActualHookupDate" + "'Actual Open Date'	ActualOpenDate" + "'Actual Spud Date'	ActualSpudDate" + "'Actual Start Date'	ActualStartDate" + "'AL Equipment Status'	ALEquipmentStatus" + "'Artifical Lift Contractor'	ArtificalLiftContractor" + "'Completion Type'	CompletionType" + "'Additional Well Details'	AdditionalWellDetails" + "'Construction Action Date'	ConstructionActionDate" + "'Construction Complete'	ConstructionComplete" + "'Coring Required'	CoringRequired" + "'Created Date'	CreatedDate" + "'Drilling Eng. Remarks'	DrillingEngRemarks" + "'Drilling Ops. Remarks'	DrillingOpsRemarks" + "'Drilling/WO Type'	DrillingWOType" + "'Drill Pipe Required'	DrillPipeRequired" + "'Dual Compl Rig Required'	DualComplRigRequired" + "'Easting'	Easting" + "'A/L Required'	ALRequired" + "'AL Equiment Available Date'	ALEquimentAvailableDate" + "'Exp Hookup to Open'	ExpHookuptoOpen" + "'Exp Release to Hookup'	ExpReleasetoHookup" + "'Exp Prior to Start'	ExpPriortoStart" + "'Exp Gas Gain (MCSFPD)1'	ExpGasGainMCSFPD1" + "'Exp Gas Restore (MCSFPD)'	ExpGasRestoreMCSFPD" + "'Exp GOR (STF/STB)'	ExpGORSTFSTB" + "'Exp Water Restore (BWPD)'	ExpWaterRestoreBWPD" + "'Schedule Duration (Days)'	ScheduleDurationDays" + "'Expected Oil Gain (BOPD)'	ExpectedOilGainBOPD" + "'Expected Water Gain (BWPD)'	ExpectedWaterGainBWPD" + "'Exp Oil Gain and Restore'	ExpOilGainandRestore" + "'Exp Oil Restore'	ExpOilRestore" + "'FD Estimated Schedule Duration'	FDEstimatedScheduleDuration" + "'FD Remarks'	FDRemarks" + "'Field'	Field" + "'Flowline Contractor'	FlowlineContractor" + "'Gain Restore Difference Reason'	GainRestoreDifferenceReason" + "'GC Area'	GCArea" + "'GC (Target)'	GCTarget" + "'GOR Before (SCF/STB)'	GORBeforeSCFSTB" + "'GP_Maintenance'	GP_Maintenance" + "'Header (HP/LP)'	HeaderHPLP" + "'Location Clearance Date'	LocationClearanceDate" + "'Location Constraint Date'	LocationConstraintDate" + "'Location Constraint Details'	LocationConstraintDetails" + "'Location Constraint'	LocationConstraint" + "'Location Ready'	LocationReady" + "'Location Released'	LocationReleased" + "'Material Available'	MaterialAvailable" + "'Material Pending for Wells'	MaterialPendingforWells" + "'Material Pending for Workovers'	MaterialPendingforWorkovers" + "'Material Status'	MaterialStatus" + "'Material Available Date'	MaterialAvailableDate" + "'MOCApprovedDate'	MOCApprovedDate" + "'MOCRemarks'	MOCRemarks" + "'MOCRequestedDate'	MOCRequestedDate" + "'MOC Status'	MOCStatus" + "'Moc Type'	MocType" + "'Modified Date'	ModifiedDate" + "'Movement Duration Reason'	MovementDurationReason" + "'No of Tests'	NoofTests" + "'Northing'	Northing" + "'Objectives'	Objectives" + "'Operational Duration Reason'	OperationalDurationReason" + "'PDDP Complete'	PDDPComplete" + "'Planned Well Completion'	PlannedWellCompletion" + "'2PP Complete'	TwoPPComplete" + "'Oil Rate Before (BOPD)'	OilRateBeforeBOPD" + "'Water Rate Before (BWPD')	WaterRateBeforeBWPD" + "'Profile Locked'	ProfileLocked" + "'Project'	Project" + "'Activity Quarter'	ActivityQuarter" + "'Release Action Date'	ReleaseActionDate" + "'Reservoir'	Reservoir" + "'Rig Expiry Date'	RigExpiryDate" + "'Tracking'	Tracking" + "'Rig HP'	RigHP" + "'Rig Status' RigStatus" + "'Rig HP Required'	RigHPRequired" + "'Rig Name'	RigName" + "'Rig Schedule Well Name'	RigScheduleWellName" + "'Rotation Required'	RotationRequired" + "'Sequence'	Sequence" + "'Slot'	Slot" + "'System (Wet/Dry)'	SystemWetDry" + "'Program Submitted'	ProgramSubmitted" + "'JOB NOT COMPLETE SUSPENDED'	JOBNOTCOMPLETESUSPENDED" + "'MOC Request'	MOCRequest" + "'Casing Policy'	CasingPolicy" + "'DIMS No'	DIMSNo" + "'Tested GOR (SCF/STB)'	TestedGORSCFSTB" + "'Tested Oil Rate Gain (BOPD)'	TestedOilRateGainBOPD" + "'Tested Rate After Date'	TestedRateAfterDate" + "'Tested Oil Rate After (BOPD)'	TestedOilRateAfterBOPD" + "'Tested Water Rate After (BWPD)'	TestedWaterRateAfterBWPD	from finderweb.wide_workover where 'GC Area'='" + pGC + "'";

            return KocConfig.DhubContext.ExecuteStoreQuery<cls_Wide_workover>(str, default).ToList;
        }
        #endregion
        #region MS XML W/R
        public void WriteFieldXML(ref cls_FinderField pField)
        {
            var writer = new System.Xml.Serialization.XmlSerializer(typeof(cls_FinderField));
            var file = new StreamWriter(My.MyProject.Application.Info.DirectoryPath + @"\" + pField.Field_Code + ".xml");
            writer.Serialize(file, pField);
            file.Close();
        }
        public bool ReadFieldXML(ref cls_FinderField pgc, string Field_Code)
        {
            var reader = new System.Xml.Serialization.XmlSerializer(typeof(cls_FinderField));
            StreamReader file;
            try
            {
                file = new StreamReader(My.MyProject.Application.Info.DirectoryPath + @"\" + Field_Code + ".xml");
                pgc = (cls_FinderField)reader.Deserialize(file);

                return true;
            }
            catch (IOException ex)
            {
                return false;
            }



        }
        public void WriteGCXML(ref cls_FinderGC pgc)
        {
            var writer = new System.Xml.Serialization.XmlSerializer(typeof(cls_FinderGC));
            var file = new StreamWriter(My.MyProject.Application.Info.DirectoryPath + @"\" + pgc.GC + ".xml");
            writer.Serialize(file, pgc);
            file.Close();
        }
        public bool ReadGCXML(ref cls_FinderGC pgc, string GCID)
        {
            var reader = new System.Xml.Serialization.XmlSerializer(typeof(cls_FinderGC));
            StreamReader file;
            try
            {
                file = new StreamReader(My.MyProject.Application.Info.DirectoryPath + @"\" + GCID + ".xml");
                pgc = (cls_FinderGC)reader.Deserialize(file);
                return true;
            }
            catch (IOException ex)
            {
                return false;
            }



        }
        #endregion
        #region JSON Read and Write
        // Public Sub WriteFieldJsonXML(ByRef pField As cls_FinderField)
        // Dim file As New System.IO.StreamWriter(My.Application.Info.DirectoryPath & "\" & pField.Field_Code & ".xml")
        // Dim serializer = New JsonSerializer()
        // serializer.Serialize(file, pField)
        // file.Close()
        // End Sub
        // Public Function ReadFieldJsonXML(Field_Code As String) As cls_FinderField
        // Dim file As System.IO.StreamReader
        // Dim pField As cls_FinderField
        // Try
        // file = New System.IO.StreamReader(My.Application.Info.DirectoryPath & "\" & Field_Code & ".xml")
        // Dim serializer = New JsonSerializer
        // pField = serializer.Deserialize(file, GetType(cls_FinderField))
        // Return pField
        // Catch ex As IOException
        // Return Nothing
        // End Try
        // End Function
        public void WriteWellsJsonXML(ref cls_Finderwell Puwi)
        {
            var file = new StreamWriter(My.MyProject.Application.Info.DirectoryPath + @"\" + Puwi.UWI + ".xml");
            var serializer = new JsonSerializer();
            serializer.Serialize(file, Puwi);
            file.Close();
        }
        public cls_Finderwell ReadWellJsonXML(string Puwi)
        {
            StreamReader file;
            cls_Finderwell Puwicls;
            try
            {
                file = new StreamReader(My.MyProject.Application.Info.DirectoryPath + @"\" + Puwi + ".xml");
                var serializer = new JsonSerializer();
                Puwicls = (cls_Finderwell)serializer.Deserialize(file, typeof(cls_Finderwell));
                return Puwicls;
            }
            catch (IOException ex)
            {
                return null;
            }
        }
        public void WriteFieldJsonXML(ref cls_FinderField pField)
        {
            var file = new StreamWriter(My.MyProject.Application.Info.DirectoryPath + @"\" + pField.Field_Code + ".xml");
            var serializer = new JsonSerializer();
            serializer.Serialize(file, pField);
            file.Close();
        }
        public cls_FinderField ReadFieldJsonXML(string Field_Code)
        {
            StreamReader file;
            cls_FinderField pField;
            try
            {
                file = new StreamReader(My.MyProject.Application.Info.DirectoryPath + @"\" + Field_Code + ".xml");
                var serializer = new JsonSerializer();
                pField = (cls_FinderField)serializer.Deserialize(file, typeof(cls_FinderField));
                return pField;
            }
            catch (IOException ex)
            {
                return null;
            }
        }
        public void WriteGCJsonXML(ref cls_FinderGC pgc)
        {
            var writer = new System.Xml.Serialization.XmlSerializer(typeof(cls_FinderGC));
            var file = new StreamWriter(My.MyProject.Application.Info.DirectoryPath + @"\" + pgc.GC + ".xml");
            var serializer = new JsonSerializer();
            serializer.Serialize(file, pgc);
            file.Close();
        }
        public cls_FinderGC ReadGCJsonXML(string pGCID)
        {
            cls_FinderGC pgc;
            StreamReader file;
            try
            {
                file = new StreamReader(My.MyProject.Application.Info.DirectoryPath + @"\" + pGCID + ".xml");
                var serializer = new JsonSerializer();
                pgc = (cls_FinderGC)serializer.Deserialize(file, typeof(cls_FinderGC));
                return pgc;
            }
            catch (IOException ex)
            {
                return null;
            }
        }
        public bool SerializeJSON<T>(string pfilename, T obj)
        {
            bool retval = true;
            try
            {
                using (var file__1 = File.CreateText(pfilename))
                {
                    var serializer = new JsonSerializer();
                    serializer.Serialize(file__1, obj);
                }
                retval = true;
            }
            catch (Exception ex)
            {
                retval = false;
            }

            return retval;
        }
        public bool DeSerializeJSON(string pfilename, ref object obj)
        {
            bool retval = true;
            try
            {
                using (var file__1 = File.OpenText(pfilename))
                {
                    var serializer = new JsonSerializer();
                    obj = serializer.Deserialize(file__1, obj.GetType());
                }
                retval = true;
            }
            catch (Exception ex)
            {
                retval = false;
            }

            return retval;
        }
        #endregion
        #region Fetch Gc Data
        public List<GeneralPort> GetGCPorts(ref cls_FinderGC pgcx)
        {
            int FacilityS = pgcx.Surface_Facility_s;
            var ls = new List<GeneralPort>();
            try
            {
                List<KOCFinder.FinderDBKOCModel.GENERAL_PORT> xyports = (from ports in KocConfig.FinderModelEntities.KocContext.GENERAL_PORT
                                                                         where ports.SURFACE_FACILITY_S == FacilityS
                                                                         select ports).ToList;
                foreach (KOCFinder.FinderDBKOCModel.GENERAL_PORT pr in xyports)
                {
                    var px = new GeneralPort();
                    px.GENERAL_PORT_S = pr.GENERAL_PORT_S;
                    px.FACILITY_ID = pr.FACILITY_ID;
                    px.FACILITY_TYPE = pr.FACILITY_TYPE;
                    ls.Add(px);
                }
                return ls;
            }

            catch (Exception ex)
            {
                return null;
            }
        }
        public List<SurfaceFacility> GetGCFacilities(ref cls_FinderGC pgcx)
        {
            int FacilityS = pgcx.Surface_Facility_s;
            var ls = new List<SurfaceFacility>();
            try
            {
                List<FACILITY_COMPOSITION> xypump = (from r in KocConfig.FinderModelEntities.KocContext.FACILITY_COMPOSITION
                                                     where r.WHOLE_SURFACE_FACILITY_S == FacilityS
                                                     select r).ToList;
                foreach (FACILITY_COMPOSITION yx in xypump)
                {
                    decimal compkey = yx.PART_SURFACE_FACILITY_S;
                    List<KOCFinder.FinderDBKOCModel.SURFACE_FACILITY> xyz = (from r1 in KocConfig.FinderModelEntities.KocContext.SURFACE_FACILITY
                                                                             where r1.SURFACE_FACILITY_S == compkey & r1.END_TIME.HasValue == false
                                                                             select r1).ToList;
                    foreach (KOCFinder.FinderDBKOCModel.SURFACE_FACILITY sr in xyz)
                    {
                        var px = new SurfaceFacility();
                        px.SURFACE_FACILITY_S = sr.SURFACE_FACILITY_S;
                        px.FACILITY_ID = sr.FACILITY_ID;
                        px.FACILITY_TYPE = sr.FACILITY_TYPE;
                        ls.Add(px);
                    }
                }
                return ls;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion
        #region Fetch Well Data Functions
        public List<cls_proddata> GetProductionHist(cls_Finderwell pwell, int WCS, int mm, int yyyy)
        {
            return KocConfig.DhubContext.ExecuteStoreQuery<cls_proddata>("select * from well_latest_runninghours Where  WCS =" + WCS + " And YR =" + yyyy + " And MON =" + mm).ToList;
        }
        public cls_Finderwell GetWellInfo(ref cls_Finderwell pwell)
        {
            string uwi = pwell.UWI;
            int wcs = pwell.WELL_COMPLETION_S;
            int? string_s = pwell.string_s;
            try
            {
                pwell.AllowedHistory = GetAllowed(wcs);
                if (pwell.AllowedHistory.Count > 0)
                {
                    pwell.ALLOWABLE = (int)Round(pwell.AllowedHistory[0].liquid_volume);
                    pwell.AllowableDate = (DateTime)pwell.AllowedHistory[0].start_time;
                }
            }


            catch (Exception ex)
            {
                // DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message & "- Error Fetching GetAllowed", "Facility Studio")
            }
            if ((object)string_s == null == false)
            {
                try
                {
                    pwell.HeaderHistory = GetHeader((int)string_s);
                    if (pwell.HeaderHistory.Count > 0)
                    {
                        pwell.HEADER = pwell.HeaderHistory[0].facility_id;
                        pwell.HeaderDate = (DateTime)pwell.HeaderHistory[0].start_time;

                    }
                }
                catch (Exception ex)
                {
                    // 'DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message & "- Error Fetching GetHeader", "Facility Studio")
                }
            }
            try
            {
                pwell.ESP_STATUS = GetESP(Conversions.ToInteger(uwi));
            }

            catch (Exception ex)
            {
                // DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message & "- Error Fetching GetESP", "Facility Studio")
            }
            try
            {
                pwell.ESPStatusHistory = GetESPStatus(wcs);
                if (pwell.ESPStatusHistory.Count > 0)
                {
                    pwell.ESP_STATUS = pwell.ESPStatusHistory[0].status_type;
                    pwell.ESP_STATUS_REASON = pwell.ESPStatusHistory[0].reason;
                    pwell.ESP_STATUS_DATE = (DateTime)pwell.ESPStatusHistory[0].start_time;
                }
            }


            catch (Exception ex)
            {
                // DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message & "- Error Fetching GetESPStatus", "Facility Studio")
            }
            try
            {
                pwell.LiftMethods = GetLiftMethod(wcs);
                pwell.LF = "";
                if (pwell.LiftMethods.Count > 0)
                {
                    pwell.LF = pwell.LiftMethods[0].Description;

                }
            }
            catch (Exception ex)
            {
                // DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message & "- Error Fetching GetLiftMethod", "Facility Studio")
            }
            if ((object)string_s == null == false)
            {
                try
                {
                    pwell.SlotHistory = GetSlot((int)string_s);
                    if (pwell.SlotHistory.Count > 0)
                    {
                        pwell.LF = pwell.LiftMethods[0].Description;
                        pwell.LF_DESCR = pwell.LiftMethods[0].Description;
                    }
                }
                catch (Exception ex)
                {
                    // 'DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message & "- Error Fetching GetSlot", "Facility Studio")
                }
            }
            try
            {
                pwell.StatusHistory = GetStatus(wcs);
                if (pwell.StatusHistory.Count > 0)
                {
                    pwell.STATUS_TYPE = pwell.StatusHistory[0].status_type;
                    pwell.START_TIME = (DateTime)pwell.StatusHistory[0].start_time;
                    pwell.STATUS_REASON = pwell.StatusHistory[0].reason;


                }
            }
            catch (Exception ex)
            {
                // DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message & "- Error Fetching GetStatus", "Facility Studio")
            }
            try
            {
                pwell.SCADAHistory = GetSCADA(wcs);
                pwell.SCADA = "";
                if (pwell.SCADAHistory.Count > 0)
                {
                    pwell.SCADA = Conversions.ToString(pwell.SCADAHistory[0].start_time.Value);
                }
            }
            catch (Exception ex)
            {
                // DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message & "- Error Fetching GetSCADA", "Facility Studio")
            }
            return pwell;
        }
        public cls_Finderwell GetWell(string Puwi)
        {
            return WellLatestDataList.Where(x => (x.UWI ?? "") == (Puwi ?? "")).FirstOrDefault();
        }
        public List<WELL_LATEST_DATA> GetWellLatestData(ref cls_Finderwell pwell, int WCS)
        {
            var dr = new List<WELL_LATEST_DATA>();
            try
            {
                var Parameters = new Devart.Data.Oracle.OracleParameter("wcs", WCS);
                dr = KocConfig.DhubContext.ExecuteStoreQuery<DhubEntities.WELL_LATEST_DATA>("SELECT *  FROM well_latest_data  wHERE well_completion_s = :wcs", Parameters).ToList;
                if (dr == null == false)
                {
                    // Filling Values
                    try
                    {
                        pwell.FACILITY_TYPE = dr[0].FACILITY_TYPE;
                        pwell.WCC_STATUS = dr[0].WCC_STATUS;
                        pwell.FACILITY_ID = dr[0].FACILITY_ID;
                        pwell.WELL_COMPLETION_S = dr[0].WELL_COMPLETION_S;
                        pwell.RESERVOIR_NAME = dr[0].RESERVOIR_NAME;
                        pwell.LAYER_NAME = dr[0].LAYER_NAME;
                        pwell.FIELD_NAME = dr[0].FIELD_NAME;
                        pwell.AREA = dr[0].AREA;
                        pwell.CR_STATUS = dr[0].CR_STATUS;
                        pwell.KBE = dr[0].KBE.GetValueOrDefault;
                        pwell.COMP_DATE = dr[0].COMP_DATE.GetValueOrDefault;
                        pwell.DRILLERS_TD = dr[0].DRILLERS_TD.GetValueOrDefault;
                        pwell.ZONES = dr[0].ZONES;
                        pwell.GROUND_ELEVATION = dr[0].GROUND_ELEVATION.GetValueOrDefault;
                        pwell.PLUGBACK_TD = dr[0].PLUGBACK_TD.GetValueOrDefault;
                        pwell.PORTABLE_TEST_STAGE_S = dr[0].PORTABLE_TEST_STAGE_S.GetValueOrDefault;
                        pwell.DCS_TEST_STAGE_S = dr[0].DCS_TEST_STAGE_S.GetValueOrDefault;
                        pwell.SBHP_TEST_STAGE_S = dr[0].SBHP_TEST_STAGE_S.GetValueOrDefault;
                        pwell.FBHP_TEST_STAGE_S = dr[0].FBHP_TEST_STAGE_S.GetValueOrDefault;
                        pwell.PORTABLE_GC = dr[0].PORTABLE_GC;
                        pwell.PORTABLE_WHP = dr[0].PORTABLE_WHP.GetValueOrDefault;
                        pwell.PORTABLE_LIQUID_RATE = dr[0].PORTABLE_LIQUID_RATE.GetValueOrDefault;
                        pwell.PORTABLE_WH_CHOKE_SIZE = dr[0].PORTABLE_WH_CHOKE_SIZE;
                        pwell.PORTABLE_FLOWSTATION_PRESS = dr[0].PORTABLE_FLOWSTATION_PRESS.GetValueOrDefault;
                        pwell.PORTABLE_GOR_REMARKS = dr[0].PORTABLE_GOR_REMARKS;
                        pwell.PORTABLE_FLOW_LINE_PRESSURE = dr[0].PORTABLE_FLOW_LINE_PRESSURE.GetValueOrDefault;
                        pwell.PORTABLE_AVG_GAS_RATE = dr[0].PORTABLE_AVG_GAS_RATE.GetValueOrDefault;
                        pwell.PORTABLE = dr[0].PORTABLE.GetValueOrDefault;
                        pwell.PORTABLE_DATE = dr[0].PORTABLE_DATE.GetValueOrDefault;
                        pwell.DCS_GC = dr[0].DCS_GC;
                        pwell.DCS = dr[0].DCS.GetValueOrDefault;
                        pwell.DCS_DATE = dr[0].DCS_DATE.GetValueOrDefault;
                        pwell.DCS_WHP = dr[0].DCS_WHP.GetValueOrDefault;
                        pwell.DCS_LIQUID_RATE = dr[0].DCS_LIQUID_RATE.GetValueOrDefault;
                        pwell.DCS_WH_CHOKE_SIZE = dr[0].DCS_WH_CHOKE_SIZE;
                        pwell.DCS_FLOWSTATION_PRESS = dr[0].DCS_FLOWSTATION_PRESS.GetValueOrDefault;
                        pwell.DCS_GOR_REMARKS = dr[0].DCS_GOR_REMARKS;
                        pwell.DCS_FLOW_LINE_PRESSURE = dr[0].DCS_FLOW_LINE_PRESSURE.GetValueOrDefault;
                        pwell.DCS_AVG_GAS_RATE = dr[0].DCS_AVG_GAS_RATE.GetValueOrDefault;
                        pwell.WATER_CUT = dr[0].WATER_CUT.GetValueOrDefault;
                        pwell.WATER_CUT_DATE = dr[0].WATER_CUT_DATE.GetValueOrDefault;
                        pwell.WATER_CUT_WHP = dr[0].WATER_CUT_WHP.GetValueOrDefault;
                        pwell.WATER_CUT_FLP = dr[0].WATER_CUT_FLP.GetValueOrDefault;
                        pwell.GC_CHK_GC = dr[0].GC_CHK_GC;
                        pwell.GC_CHK = dr[0].GC_CHK;
                        pwell.GC_CHK_WHP = dr[0].GC_CHK_WHP.GetValueOrDefault;
                        pwell.GC_CHK_FLP = dr[0].GC_CHK_FLP.GetValueOrDefault;
                        pwell.GC_CHK_DATE = dr[0].GC_CHK_DATE.GetValueOrDefault;
                        pwell.GC_PRESS_GC = dr[0].GC_PRESS_GC;
                        pwell.GC_PRESS_CHK = dr[0].GC_PRESS_CHK;
                        pwell.GC_PRESS_WHP = dr[0].GC_PRESS_WHP.GetValueOrDefault;
                        pwell.GC_PRESS_FLP = dr[0].GC_PRESS_FLP.GetValueOrDefault;
                        pwell.GC_PRESS_DATE = dr[0].GC_PRESS_DATE.GetValueOrDefault;
                        pwell.H2S = dr[0].H2S.GetValueOrDefault;
                        pwell.OIL_API = dr[0].OIL_API.GetValueOrDefault;
                        pwell.SALT = dr[0].SALT.GetValueOrDefault;
                        pwell.ALLOWABLE = dr[0].ALLOWABLE.GetValueOrDefault;
                        pwell.SBHP_REMARKS = dr[0].SBHP_REMARKS;
                        pwell.SBHP_PRESSURE = dr[0].SBHP_PRESSURE.GetValueOrDefault;
                        pwell.SBHP_PRESSURE_DATUM = dr[0].SBHP_PRESSURE_DATUM.GetValueOrDefault;
                        pwell.SBHP_DATE = dr[0].SBHP_DATE.GetValueOrDefault;
                        pwell.SBHP_GRADIANT = dr[0].SBHP_GRADIANT.GetValueOrDefault;
                        pwell.FBHP_PRESSURE = dr[0].FBHP_PRESSURE.GetValueOrDefault;
                        pwell.FBHP_DATE = dr[0].FBHP_DATE.GetValueOrDefault;
                        pwell.FBHP_PRESSURE_DATUM = dr[0].FBHP_PRESSURE_DATUM.GetValueOrDefault;
                        pwell.FBHP_DEPTH = dr[0].FBHP_DEPTH;
                        pwell.FBHP_REMARKS = dr[0].FBHP_REMARKS;
                        pwell.FBHP_GRADIANT = dr[0].FBHP_GRADIANT.GetValueOrDefault;
                        pwell.UWI = dr[0].UWI;
                        pwell.HEADER = dr[0].HEADER;
                        pwell.SLOT = dr[0].SLOT;
                        pwell.CURRENT_GC = dr[0].CURRENT_GC;
                        pwell.PORTABLE_WATER_CUT = dr[0].PORTABLE_WATER_CUT.GetValueOrDefault;
                        pwell.X = dr[0].X.GetValueOrDefault;
                        pwell.Y = dr[0].Y.GetValueOrDefault;
                        try
                        {
                            pwell.FACILITY_NAME = dr[0].FACILITY_NAME;
                            pwell.STATUS_TYPE = dr[0].STATUS_TYPE;
                            pwell.STATUS_DATE = dr[0].STATUS_DATE.GetValueOrDefault;
                            pwell.STATUS_DESCRIPTION = dr[0].STATUS_DESCRIPTION;
                            pwell.STATUS_REASON = dr[0].STATUS_REASON;
                        }
                        catch (Exception ex)
                        {

                        }

                        pwell.PROD_7 = dr[0].PROD_7.GetValueOrDefault;
                        pwell.PROD_6 = dr[0].PROD_6.GetValueOrDefault;
                        pwell.PROD_5 = dr[0].PROD_5.GetValueOrDefault;
                        pwell.PROD_4 = dr[0].PROD_4.GetValueOrDefault;
                        pwell.PROD_3 = dr[0].PROD_3.GetValueOrDefault;
                        pwell.PROD_2 = dr[0].PROD_2.GetValueOrDefault;
                        pwell.PROD_1 = dr[0].PROD_1.GetValueOrDefault;
                        pwell.PROD_WATER_7 = dr[0].PROD_WATER_7.GetValueOrDefault;
                        pwell.PROD_WATER_6 = dr[0].PROD_WATER_6.GetValueOrDefault;
                        pwell.PROD_WATER_5 = dr[0].PROD_WATER_5.GetValueOrDefault;
                        pwell.PROD_WATER_4 = dr[0].PROD_WATER_4.GetValueOrDefault;
                        pwell.PROD_WATER_3 = dr[0].PROD_WATER_3.GetValueOrDefault;
                        pwell.PROD_WATER_2 = dr[0].PROD_WATER_2.GetValueOrDefault;
                        pwell.PROD_WATER_1 = dr[0].PROD_WATER_1.GetValueOrDefault;
                        pwell.PROD_GAS_7 = dr[0].PROD_GAS_7.GetValueOrDefault;
                        pwell.PROD_GAS_6 = dr[0].PROD_GAS_6.GetValueOrDefault;
                        pwell.PROD_GAS_5 = dr[0].PROD_GAS_5.GetValueOrDefault;
                        pwell.PROD_GAS_4 = dr[0].PROD_GAS_4.GetValueOrDefault;
                        pwell.PROD_GAS_3 = dr[0].PROD_GAS_3.GetValueOrDefault;
                        pwell.PROD_GAS_2 = dr[0].PROD_GAS_2.GetValueOrDefault;
                        pwell.PROD_GAS_1 = dr[0].PROD_GAS_1.GetValueOrDefault;
                        pwell.INJ = dr[0].INJ;
                        pwell.DCS_GOR_BEFORE = dr[0].DCS_GOR_BEFORE.GetValueOrDefault;
                        pwell.PORTABLE_GOR_BEFORE = dr[0].PORTABLE_GOR_BEFORE.GetValueOrDefault;
                        pwell.SBHP_PRESSURE_BEFORE = dr[0].SBHP_PRESSURE_BEFORE.GetValueOrDefault;
                        pwell.FBHP_PRESSURE_BEFORE = dr[0].FBHP_PRESSURE_BEFORE.GetValueOrDefault;
                        pwell.WATERCUT_BEFORE = dr[0].WATERCUT_BEFORE.GetValueOrDefault;
                        pwell.CHOKE_BEFORE = dr[0].CHOKE_BEFORE;
                        pwell.MONTH_7 = dr[0].MONTH_7.GetValueOrDefault;
                        pwell.MONTH_6 = dr[0].MONTH_6.GetValueOrDefault;
                        pwell.MONTH_5 = dr[0].MONTH_5.GetValueOrDefault;
                        pwell.MONTH_4 = dr[0].MONTH_4.GetValueOrDefault;
                        pwell.MONTH_3 = dr[0].MONTH_3.GetValueOrDefault;
                        pwell.MONTH_2 = dr[0].MONTH_2.GetValueOrDefault;
                        pwell.MONTH_1 = dr[0].MONTH_1.GetValueOrDefault;
                        pwell.LIQUID_RATE = dr[0].LIQUID_RATE.GetValueOrDefault;
                        pwell.LIQUID_RATE_DATE = dr[0].LIQUID_RATE_DATE.GetValueOrDefault;
                        pwell.CHOKE = dr[0].CHOKE;
                        pwell.CHOKE_DATE = dr[0].CHOKE_DATE.GetValueOrDefault;
                        pwell.ESP = dr[0].ESP;
                        pwell.DCS_OILRATE = dr[0].DCS_OILRATE.GetValueOrDefault;
                        pwell.PORTABLE_OILRATE = dr[0].PORTABLE_OILRATE.GetValueOrDefault;
                        pwell.WC_OILRATE = dr[0].WC_OILRATE.GetValueOrDefault;
                        pwell.PRESSURE_OILRATE = dr[0].PRESSURE_OILRATE.GetValueOrDefault;
                        pwell.CHOKECHANGE_OILRATE = dr[0].CHOKECHANGE_OILRATE.GetValueOrDefault;
                        pwell.MONTH_12 = dr[0].MONTH_12.GetValueOrDefault;
                        pwell.MONTH_11 = dr[0].MONTH_11.GetValueOrDefault;
                        pwell.MONTH_10 = dr[0].MONTH_10.GetValueOrDefault;
                        pwell.MONTH_09 = dr[0].MONTH_09.GetValueOrDefault;
                        pwell.MONTH_08 = dr[0].MONTH_08.GetValueOrDefault;
                        pwell.PROD_GAS_08 = dr[0].PROD_GAS_08.GetValueOrDefault;
                        pwell.PROD_GAS_09 = dr[0].PROD_GAS_09.GetValueOrDefault;
                        pwell.PROD_GAS_10 = dr[0].PROD_GAS_10.GetValueOrDefault;
                        pwell.PROD_GAS_11 = dr[0].PROD_GAS_11.GetValueOrDefault;
                        pwell.PROD_GAS_12 = dr[0].PROD_GAS_12.GetValueOrDefault;
                        pwell.PROD_WATER_08 = dr[0].PROD_WATER_08.GetValueOrDefault;
                        pwell.PROD_WATER_09 = dr[0].PROD_WATER_09.GetValueOrDefault;
                        pwell.PROD_WATER_10 = dr[0].PROD_WATER_10.GetValueOrDefault;
                        pwell.PROD_WATER_11 = dr[0].PROD_WATER_11.GetValueOrDefault;
                        pwell.PROD_WATER_12 = dr[0].PROD_WATER_12.GetValueOrDefault;
                        pwell.PROD_08 = dr[0].PROD_08.GetValueOrDefault;
                        pwell.PROD_09 = dr[0].PROD_09.GetValueOrDefault;
                        pwell.PROD_10 = dr[0].PROD_10.GetValueOrDefault;
                        pwell.PROD_11 = dr[0].PROD_11.GetValueOrDefault;
                        pwell.PROD_12 = dr[0].PROD_12.GetValueOrDefault;
                        pwell.PROD_DATE_12 = dr[0].PROD_DATE_12;
                        pwell.PROD_DATE_11 = dr[0].PROD_DATE_11;
                        pwell.PROD_DATE_10 = dr[0].PROD_DATE_10;
                        pwell.PROD_DATE_09 = dr[0].PROD_DATE_09;
                        pwell.PROD_DATE_08 = dr[0].PROD_DATE_08;
                        pwell.PROD_DATE_07 = dr[0].PROD_DATE_07;
                        pwell.PROD_DATE_06 = dr[0].PROD_DATE_06;
                        pwell.PROD_DATE_05 = dr[0].PROD_DATE_05;
                        pwell.PROD_DATE_04 = dr[0].PROD_DATE_04;
                        pwell.PROD_DATE_03 = dr[0].PROD_DATE_03;
                        pwell.PROD_DATE_02 = dr[0].PROD_DATE_02;
                        pwell.PROD_DATE_01 = dr[0].PROD_DATE_01;
                        pwell.LATEST_GOR = dr[0].LATEST_GOR.GetValueOrDefault;
                        pwell.LATEST_GOR_DATE = dr[0].LATEST_GOR_DATE.GetValueOrDefault;
                        pwell.LATEST_WC_DATE = dr[0].LATEST_WC_DATE.GetValueOrDefault;
                        pwell.LATEST_WC = dr[0].LATEST_WC.GetValueOrDefault;
                        pwell.LATEST_OIL_RATE = dr[0].LATEST_OIL_RATE.GetValueOrDefault;
                        pwell.LATEST_WATER_RATE = dr[0].LATEST_WATER_RATE.GetValueOrDefault;
                        pwell.LATEST_HRS = dr[0].LATEST_HRS.GetValueOrDefault;
                        pwell.LATEST_PROD_RATE = dr[0].LATEST_PROD_RATE.GetValueOrDefault;
                        pwell.LATEST_GAS_RATE = dr[0].LATEST_GAS_RATE.GetValueOrDefault;
                        pwell.LAST_PROD_DATE = dr[0].LAST_PROD_DATE.GetValueOrDefault;
                        pwell.BEFORE_LIQUID_RATE = dr[0].BEFORE_LIQUID_RATE.GetValueOrDefault;
                        pwell.PORTABLE_WC = dr[0].PORTABLE_WC.GetValueOrDefault;
                        pwell.DCS_WC = dr[0].DCS_WC.GetValueOrDefault;
                        pwell.LATEST_WHP = dr[0].LATEST_WHP.GetValueOrDefault;
                        pwell.LATEST_FLP = dr[0].LATEST_FLP.GetValueOrDefault;
                        pwell.DRYORNOT = dr[0].DRYORNOT;
                        pwell.MFL = dr[0].MFL;
                        pwell.LATEST_SULFUR = dr[0].LATEST_SULFUR.GetValueOrDefault;
                        pwell.LATEST_SULFUR_DT = dr[0].LATEST_SULFUR_DT.GetValueOrDefault;
                        pwell.FIELD_CODE = dr[0].FIELD_CODE;
                        pwell.LATEST_INJ_RATE = dr[0].LATEST_INJ_RATE.GetValueOrDefault;
                        pwell.GASINJ = dr[0].GASINJ;
                        pwell.F_AVG_BOPD = dr[0].F_AVG_BOPD.GetValueOrDefault;
                        pwell.F_AVG_BWIPD = dr[0].F_AVG_BWIPD.GetValueOrDefault;
                        pwell.F_AVG_BWPD = dr[0].F_AVG_BWPD.GetValueOrDefault;
                        pwell.F_GET_CUM_OIL = dr[0].F_GET_CUM_OIL.GetValueOrDefault;
                        pwell.F_GET_CUM_WAT = dr[0].F_GET_CUM_WAT.GetValueOrDefault;
                        pwell.F_PAT_INJ = dr[0].F_PAT_INJ.GetValueOrDefault;
                        pwell.F_PAT_PROD = dr[0].F_PAT_PROD.GetValueOrDefault;
                        pwell.ORSTATUS = dr[0].ORSTATUS;
                        pwell.RESERVOIR_ID = dr[0].RESERVOIR_ID;
                        pwell.LF = dr[0].LF;
                        pwell.LF_DESCR = dr[0].LF_DESCR;
                        pwell.START_TIME = dr[0].START_TIME.GetValueOrDefault;
                        pwell.END_TIME = dr[0].END_TIME.GetValueOrDefault;
                        pwell.CONDENS7 = dr[0].CONDENS7.GetValueOrDefault;
                        pwell.CONDENS6 = dr[0].CONDENS6.GetValueOrDefault;
                        pwell.CONDENS5 = dr[0].CONDENS5.GetValueOrDefault;
                        pwell.CONDENS4 = dr[0].CONDENS4.GetValueOrDefault;
                        pwell.CONDENS3 = dr[0].CONDENS3.GetValueOrDefault;
                        pwell.CONDENS2 = dr[0].CONDENS2.GetValueOrDefault;
                        pwell.CONDENS1 = dr[0].CONDENS1.GetValueOrDefault;
                        pwell.NODE_X = dr[0].NODE_X.GetValueOrDefault;
                        pwell.NODE_Y = dr[0].NODE_Y.GetValueOrDefault;
                        pwell.LATITUDE = dr[0].LATITUDE.GetValueOrDefault;
                        pwell.LONGITUDE = dr[0].LONGITUDE.GetValueOrDefault;
                        pwell.SCADA = dr[0].SCADA;
                        pwell.string_s = dr[0].STRING_S;
                    }
                    catch (Exception ex)
                    {

                    }

                }
                return dr;
            }
            catch (Exception ex)
            {
                // DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message & "- Error Fetching well latest data", "Facility Studio")
            }
            return null;
        }
        public List<WellSCADAcls> GetSCADA(int WCS)
        {
            var dr = new List<WellSCADAcls>();
            try
            {
                var Parameters = new Devart.Data.Oracle.OracleParameter("wcs", WCS);
                dr = FinderModelcls.KocContext.ExecuteStoreQuery<WellSCADAcls>("SELECT oil_field_operation_s,start_time FROM koc.oil_field_operation ofo WHERE ofo.activity_type='SCADA_INSTALL' AND ofo.well_completion_s= :wcs AND ofo.end_time is null", Parameters).ToList;


                return dr;
            }
            catch (Exception ex)
            {
                // DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message & "- Error Fetching scada", "Facility Studio")
            }
            return null;
        }
        public List<WellHeadercls> GetHeader(int string_s)
        {
            var dr = new List<WellHeadercls>();
            try
            {
                var Parameters = new Devart.Data.Oracle.OracleParameter("string_s", string_s);
                dr = FinderModelcls.KocContext.ExecuteStoreQuery<WellHeadercls>("SELECT pc.start_time, sf.facility_id, sf.surface_facility_s, pc.port_connection_s " + "   FROM koc.port_connection pc, koc.surface_facility sf" + "   WHERE sf.facility_type = 'HEADER'" + "   AND sf.surface_facility_s = pc.to_surface_facility_s" + "   AND pc.end_time IS NULL " + "   AND pc.from_downhole_facility_s = :string_s " + "  ORDER BY pc.start_time DESC", Parameters).ToList;


                return dr;
            }
            catch (Exception ex)
            {
                // DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message & "- Error Fetching header", "Facility Studio")
            }
            return null;
        }
        public List<WellSlotCls> GetSlot(int string_s)
        {
            var dr = new List<WellSlotCls>();
            try
            {
                var Parameters = new Devart.Data.Oracle.OracleParameter("string_s", string_s);
                dr = FinderModelcls.KocContext.ExecuteStoreQuery<WellSlotCls>("  SELECT gp.general_port_s, pc.start_time, sf.facility_id, gp_s.general_port_s slot_gp_s, pc.port_connection_s " + "    FROM koc.general_port gp, koc.general_port gp_s, koc.port_connection pc, koc.surface_facility sf " + "   WHERE sf.facility_type (+) = 'INCOMMER' " + "    AND sf.surface_facility_s (+) = gp_s.surface_facility_s " + "    AND gp_s.general_port_s (+) = pc.to_port_s " + "    AND pc.end_time (+) IS NULL " + "    AND pc.from_port_s (+) = gp.general_port_s " + "    AND gp.downhole_facility_s = :string_s " + " ORDER BY pc.start_time DESC", Parameters).ToList;


                return dr;
            }
            catch (Exception ex)
            {
                // DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message & "- Error Fetching slot", "Facility Studio")
            }
            return null;
        }
        public List<WellLiftMethodcls> GetLiftMethod(int WCS)
        {
            List<WellLiftMethodcls> dr;
            try
            {
                var Parameters = new Devart.Data.Oracle.OracleParameter("wcs", WCS);
                dr = FinderModelcls.KocContext.ExecuteStoreQuery<WellLiftMethodcls>("  SELECT fs.status_type, rfs.description, ofo.start_time" + " FROM koc.oil_field_operation ofo, koc.facility_status fs, codes.r_facility_status rfs " + " WHERE rfs.source_type = 'LIFT_METHOD' " + "   AND rfs.type = fs.status_type " + "   AND fs.start_oil_field_operation_s = ofo.oil_field_operation_s " + "   AND ofo.activity_type = 'LIFT_METHOD_CHANGE' " + "  AND ofo.well_completion_s = :wcs " + " ORDER BY ofo.start_time DESC", Parameters).ToList;


                return dr;
            }
            catch (Exception ex)
            {
                // DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message & "- Error Fetching lift method", "Facility Studio")
            }
            return null;
        }
        public string GetESP(int UWI)
        {
            string dr;
            try
            {
                var Parameters = new Devart.Data.Oracle.OracleParameter("uwi", UWI);
                dr = FinderModelcls.KocContext.ExecuteStoreQuery<string>(" SELECT decode(facility_type,'ESP_SYSTEM','Y',null) ESP FROM koc.downhole_facility  WHERE UWI = :uwi  AND facility_type = 'ESP_SYSTEM'  AND end_time is null", Parameters).FirstOrDefault;

                return dr;
            }
            catch (Exception ex)
            {
                // 'DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message & "- Error Fetching esp", "Facility Studio")
            }
            return null;
        }
        public List<WellAllowedcls> GetAllowed(int WCS)
        {
            var dr = new List<WellAllowedcls>();
            try
            {
                var Parameters = new Devart.Data.Oracle.OracleParameter("wcs", WCS);
                dr = FinderModelcls.KocContext.ExecuteStoreQuery<WellAllowedcls>("  select liquid_volume,start_time  from koc.daily_production_data " + "  where daily_production_hdr_s in  " + "	(select daily_production_hdr_s from koc.daily_production_hdr  " + "	  where well_completion_s = :wcs   " + "		AND  ACTIVITY_TYPE 	= 'ALLOWED'  " + "		AND  MATERIAL_TYPE 	= 'OIL'  " + "		AND  FLOW_DIR_TYPE 	= 'PRODUCTION'  " + "		AND  STATE_TYPE 	= 'STANDARD'  " + "		AND  EXISTENCE_TYPE 	= 'ACTUAL'  ) order by start_time desc", Parameters).ToList;



                return dr;
            }
            catch (Exception ex)
            {
                // DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message & "- Error Fetching allowed", "Facility Studio")
            }
            return null;
        }
        public List<StatusCls> GetESPStatus(int WCS)
        {
            var dr = new List<StatusCls>();
            try
            {
                var Parameters = new Devart.Data.Oracle.OracleParameter("wcs", WCS);
                dr = FinderModelcls.KocContext.ExecuteStoreQuery<StatusCls>("SELECT fs.status_type, fs.reason, ofo.start_time, ofo.oil_field_operation_s, fs.facility_status_s " + " FROM koc.oil_field_operation ofo, koc.facility_status fs " + "  WHERE fs.start_oil_field_operation_s = ofo.oil_field_operation_s " + " AND ofo.activity_type = 'ESP_STATUS_CHANGE' " + " AND ofo.well_completion_s = :wcs " + " ORDER BY ofo.start_time DESC", Parameters).ToList;




                return dr;
            }
            catch (Exception ex)
            {
                // DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message & "- Error Fetching esp status", "Facility Studio")
            }
            return null;
        }
        public List<StatusCls> GetStatus(int WCS)
        {
            var dr = new List<StatusCls>();
            try
            {
                var Parameters = new Devart.Data.Oracle.OracleParameter("wcs", WCS);
                dr = FinderModelcls.KocContext.ExecuteStoreQuery<StatusCls>("SELECT fs.status_type, fs.reason, ofo.start_time, ofo.oil_field_operation_s, fs.facility_status_s " + " FROM koc.oil_field_operation ofo, koc.facility_status fs " + "  WHERE fs.start_oil_field_operation_s = ofo.oil_field_operation_s " + " AND ofo.activity_type = 'FACILITY_STATUS_CHANGE' " + " AND ofo.well_completion_s = :wcs " + " ORDER BY ofo.start_time DESC", Parameters).ToList;



                return dr;
            }
            catch (Exception ex)
            {
                // DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message & "- Error Fetching Status", "Facility Studio")
            }
            return null;
        }
        public List<StatusCls> GetStatusatDate(int WCS, string pdate)
        {
            var dr = new List<StatusCls>();
            try
            {
                var Parameters = new Devart.Data.Oracle.OracleParameter("wcs", WCS);
                dr = FinderModelcls.KocContext.ExecuteStoreQuery<StatusCls>("SELECT fs.status_type, fs.reason, ofo.start_time, ofo.oil_field_operation_s, fs.facility_status_s " + " FROM koc.oil_field_operation ofo, koc.facility_status fs " + "  WHERE fs.start_oil_field_operation_s = ofo.oil_field_operation_s " + " AND ofo.activity_type = 'FACILITY_STATUS_CHANGE'" + " and  ofo.start_time <=to_date('" + pdate + " 05:00:00" + "', 'dd-mm-yyyy HH24:MI:SS')" + " AND ofo.well_completion_s = :wcs " + " ORDER BY ofo.start_time DESC", Parameters).ToList;



                return dr;
            }
            catch (Exception ex)
            {
                // DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message & "- Error Fetching Status", "Facility Studio")
            }
            return null;
        }
        public List<cls_WellCurrentGC> GetGCWELL(int pwcs)
        {
            var dr = new List<cls_WellCurrentGC>();
            try
            {
                dr = FinderModelcls.KocContext.ExecuteStoreQuery<cls_WellCurrentGC>("select sf.facility_id   GC , wc.uwi                       UWI ," + " wc.facility_type   FACILITY_TYPE ," + " substr(wc.facility_name,1,12)   STRING_NAME," + " re.reservoir_id        RESERVOIR ," + " substr(koc_pack.get_zones(wc.well_completion_s),1,40) ZONE," + " pc.start_time                    ," + " pc.end_time                      ," + " pc.created_by                    ," + " pc.create_date                   ," + " pc.updated_by                    ," + " pc.last_update                   ," + " sf.surface_facility_s            ," + " pc.port_connection_s             ," + " wc.string_s                      ," + " wc.well_completion_s             ," + " wc.reservoir_s                   ," + " wc.start_time      WC_START_TIME ," + " wc.end_time WC_END_TIME" + " from" + " port_connection pc,surface_facility sf,well_completion wc,reservoir re" + " where " + "     pc.connection_type          = 'BA-NETWORK'" + " and pc.to_surface_facility_s    = sf.surface_facility_s" + " and pc.from_downhole_facility_s = wc.string_s" + " and wc.well_completion_s =" + pwcs + " and wc.reservoir_s(+)           = re.reservoir_s order by pc.start_time desc", default).ToList;

                return dr;
            }
            catch (Exception ex)
            {
                // DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message & "- Error Fetching Basic Info", "Facility Studio")
            }
            return null;
        }
        public List<WellBasicDatacls> GetWellBasicInfo(string UWI)
        {
            var dr = new List<WellBasicDatacls>();
            try
            {
                var Parameters = new Devart.Data.Oracle.OracleParameter("uwi", UWI);
                dr = FinderModelcls.KocContext.ExecuteStoreQuery<WellBasicDatacls>("SELECT well_completion_s, uwi, DECODE(facility_type, 'TUBING', 'T', 'CASING', 'C', 'BOTH', 'B', 'TUBING LONG', 'TL', 'TUBING SHORT', 'TS') stringid,string_name, facility_type, reservoir, string_s, wc_start_time " + "     FROM koc.koc_gc_well " + "  AND end_time IS NULL AND wc_end_time IS NULL" + "  AND uwi LIKE NVL(:uwi, '%') " + "  ORDER BY uwi, facility_type", Parameters).ToList;
                // "  WHERE surface_facility_s = :GC_S" &

                // "  AND facility_type LIKE NVL(:blk_gc.compl, '%')" &





                return dr;
            }
            catch (Exception ex)
            {
                // DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message & "- Error Fetching Basic Info", "Facility Studio")
            }
            return null;
        }
        public List<PortableData> GetPortableTestData(int wcs)
        {
            return KocConfig.DhubContext.ExecuteStoreQuery<PortableData>("SELECT    well_completion_S,   START_TIME, TEST_TYPE,  TEST_RATE, WC, GOR, WHP, FLP,  ROUND(test_rate * (1 - WC / 100) ) AS OILRATE, ROUND(GOR*test_rate/1000,3)  AS GASRATE," + " LEFT_CHOKE_SIZE, RIGHT_CHOKE_SIZE, CHOKE " + " FROM well_tests_v1 " + " WHERE     (TEST_TYPE in ('PORTABLE GOR MULTIRATE','PORTABLE')  ) AND (WELL_COMPLETION_S= " + wcs + ") and gor is not null " + "    ORDER BY start_time DESC").ToList;
        }
        public List<PortableMultiRate> GetPortableTestMultiRateData(int wcs)
        {
            return KocConfig.EsearchContext.ExecuteStoreQuery<PortableMultiRate>("SELECT   UWI, STRING WellSTRING, RESR_ID, START_TIME, END_TIME, DURATION, CONTRACTOR, REPORT_NUMBER, T_FLOW_PERIOD, ACTIVITY_TYPE, " + " ACTUAL_CHOKE, C_PRESS, T_PRESS, WHT, FLP, FLOW_P_NO, CRITICAL_FLOW, F_DURATION, TEST_CHOKE, CHOKE_LC, CHOKE_RC, CHOKE_LT, " + " CHOKE_RT, LEFT_CHOKE_SIZE, RIGHT_CHOKE_SIZE, LIQUID_RATE, WATER_RATE, REMARKS, WATER_CUT, TOTAL_GOR, GAS_RATE, HP_GOR, " + " SEP_PRESS, SEP_TEMP, LP_GOR, FORMATION_GOR, TOTAL_GLR, INJECTION_GLR, API, SPECIFIC_GRAVITY, SHRINKAGE_FACTOR, " + "  WATER_SALINITY, WELL_COMPLETION_S" + " FROM  finderweb.PORTABLE_MULTRATE_V " + " WHERE    WELL_COMPLETION_S= " + wcs + " " + "    ORDER BY start_time,FLOW_P_NO DESC").ToList;
        }
        public List<CasePortableData> GetDCAPortableTestData(int wcs)
        {
            return KocConfig.DhubContext.ExecuteStoreQuery<CasePortableData>("SELECT  well_completion_S,   TEST_STAGE_S, OIL_FIELD_OPERATION_S, START_TIME, TEST_TYPE,  TEST_RATE, WC, GOR, WHP, FLP,  ROUND(test_rate * (1 - WC / 100) ) AS OILRATE,  " + " LEFT_CHOKE_SIZE, RIGHT_CHOKE_SIZE, CHOKE " + " FROM well_tests_v1 " + " WHERE     (TEST_TYPE in ('PORTABLE GOR MULTIRATE','PORTABLE')  ) AND (WELL_COMPLETION_S= " + wcs + ") and gor is not null " + "    ORDER BY start_time DESC").ToList;
        }
        public List<CasePortableData> GetDCAPortableTestDataForField(string FLD_CODE)
        {
            return KocConfig.DhubContext.ExecuteStoreQuery<CasePortableData>("SELECT   b.ppdm_WCS_UWI uwi, b.well_completion_S,  a.TEST_STAGE_S, a.OIL_FIELD_OPERATION_S, a.START_TIME, a.TEST_TYPE,  a.TEST_RATE, a.WC, a.GOR, a.WHP, a.FLP,  ROUND(a.test_rate * (1 - a.WC / 100) ) AS test_rate,  " + " a.LEFT_CHOKE_SIZE, a.RIGHT_CHOKE_SIZE, a.CHOKE,b.area,b.field_code " + " FROM well_tests_v1 a,well_latest_data b " + " WHERE    (a.well_completion_s=b.well_completion_s)and b.wcc_status='OPEN'  and  (TEST_TYPE in ('PORTABLE GOR MULTIRATE','PORTABLE')  ) AND (b.field_code= '" + FLD_CODE + "') and gor is not null " + "    ORDER BY start_time DESC").ToList;
        }
        public List<CasePortableData> GetDCAPortableTestDataForArea(string AreaCode)
        {
            return KocConfig.DhubContext.ExecuteStoreQuery<CasePortableData>("SELECT b.ppdm_WCS_UWI uwi, b.well_completion_S a.start_time ,   a.TEST_STAGE_S, a.OIL_FIELD_OPERATION_S, a.START_TIME, a.TEST_TYPE,  a.TEST_RATE, a.WC, a.GOR, a.WHP, a.FLP,  ROUND(a.test_rate * (1 - a.WC / 100) ) AS test_rate,  " + " a.LEFT_CHOKE_SIZE, a.RIGHT_CHOKE_SIZE, a.CHOKE,b.area,b.field_code " + " FROM well_tests_v1 a,well_latest_data b " + " WHERE    (a.WELL_COMPLETION_S=b.WELL_COMPLETION_S) and  b.wcc_status='OPEN' and  (TEST_TYPE in ('PORTABLE GOR MULTIRATE','PORTABLE')  ) AND (decode('" + AreaCode + "','ALL','ALL',b.area)= '" + AreaCode + "') and gor is not null " + "    ORDER BY start_time DESC").ToList;
        }
        public List<CasePortableData> GetDCAMaxPortableTestDataForArea2YearsAgo(string AreaCode)
        {
            return KocConfig.DhubContext.ExecuteStoreQuery<CasePortableData>("SELECT    ppdm_WCS_UWI uwi,well_completion_S, ADD_MONTHS(SYSDATE,-24)   start_time, ROUND(max( GET_WCS_LIQUID_RATE_NOB4(B.WELL_COMPLETION_S,ADD_MONTHS(SYSDATE,-24)) * (1 - GET_WCS_WATER_CUT_nob4(B.WELL_COMPLETION_S,ADD_MONTHS(SYSDATE,-24)) / 100)))  AS test_rate     " + " FROM  well_latest_data b   where  (decode('" + AreaCode + "','ALL','ALL',b.area)= '" + AreaCode + "')" + "   group by ADD_MONTHS(SYSDATE,-24),well_completion_S,ppdm_WCS_UWI  having ROUND( max(GET_WCS_LIQUID_RATE_NOB4(B.WELL_COMPLETION_S,ADD_MONTHS(SYSDATE,-24)) * (1 - GET_WCS_WATER_CUT_nob4(B.WELL_COMPLETION_S,ADD_MONTHS(SYSDATE,-24)) / 100))) >0  ORDER BY ROUND(max( GET_WCS_LIQUID_RATE_NOB4(B.WELL_COMPLETION_S,ADD_MONTHS(SYSDATE,-24)) * (1 - GET_WCS_WATER_CUT_nob4(B.WELL_COMPLETION_S,ADD_MONTHS(SYSDATE,-24)) / 100))) DESC  ").ToList;
        }

        public List<CasePortableData> GetDCAMaxPortableTestDataForField2YearsAgo(string FieldCode)
        {
            return KocConfig.DhubContext.ExecuteStoreQuery<CasePortableData>("SELECT    ppdm_WCS_UWI uwi,well_completion_S, ADD_MONTHS(SYSDATE,-24)   start_time, ROUND(max( GET_WCS_LIQUID_RATE_NOB4(B.WELL_COMPLETION_S,ADD_MONTHS(SYSDATE,-24)) * (1 - GET_WCS_WATER_CUT_nob4(B.WELL_COMPLETION_S,ADD_MONTHS(SYSDATE,-24)) / 100)))  AS test_rate     " + " FROM  well_latest_data b  where FIELD_CODE='" + FieldCode + "'" + "   group by ADD_MONTHS(SYSDATE,-24),well_completion_S,ppdm_WCS_UWI  having ROUND( max(GET_WCS_LIQUID_RATE_NOB4(B.WELL_COMPLETION_S,ADD_MONTHS(SYSDATE,-24)) * (1 - GET_WCS_WATER_CUT_nob4(B.WELL_COMPLETION_S,ADD_MONTHS(SYSDATE,-24)) / 100))) >0  ORDER BY ROUND(max( GET_WCS_LIQUID_RATE_NOB4(B.WELL_COMPLETION_S,ADD_MONTHS(SYSDATE,-24)) * (1 - GET_WCS_WATER_CUT_nob4(B.WELL_COMPLETION_S,ADD_MONTHS(SYSDATE,-24)) / 100))) DESC  ").ToList;
        }
        public List<CasePortableData> GetDCAMinPortableTestDataForArea(string AreaCode)
        {
            return KocConfig.DhubContext.ExecuteStoreQuery<CasePortableData>("SELECT    ppdm_WCS_UWI uwi,well_completion_S, ADD_MONTHS(SYSDATE,-24)   start_time, ROUND(min( GET_WCS_LIQUID_RATE_NOB4(B.WELL_COMPLETION_S,ADD_MONTHS(SYSDATE,-24)) * (1 - GET_WCS_WATER_CUT_nob4(B.WELL_COMPLETION_S,ADD_MONTHS(SYSDATE,-24)) / 100)))  AS test_rate     " + " FROM  well_latest_data b  " + "   group by ADD_MONTHS(SYSDATE,-24),well_completion_S,ppdm_WCS_UWI  having ROUND( min(GET_WCS_LIQUID_RATE_NOB4(B.WELL_COMPLETION_S,ADD_MONTHS(SYSDATE,-24)) * (1 - GET_WCS_WATER_CUT_nob4(B.WELL_COMPLETION_S,ADD_MONTHS(SYSDATE,-24)) / 100))) >0  ORDER BY ROUND(min( GET_WCS_LIQUID_RATE_NOB4(B.WELL_COMPLETION_S,ADD_MONTHS(SYSDATE,-24)) * (1 - GET_WCS_WATER_CUT_nob4(B.WELL_COMPLETION_S,ADD_MONTHS(SYSDATE,-24)) / 100))) asc  ").ToList;
        }
        public List<CasePortableData> GetDCAMinFromWellLatestDataPortableTestDataForArea(string AreaCode)
        {
            return KocConfig.DhubContext.ExecuteStoreQuery<CasePortableData>("SELECT       min(LATEST_OIL_RATE) AS test_rate,sysdate  start_time,well_completion_S  " + " FROM well_latest_data b  " + " WHERE    (decode('" + AreaCode + "','ALL','ALL',b.area)= '" + AreaCode + "') and  wcc_status='OPEN' And LATEST_OIL_RATE is not null  and LATEST_OIL_RATE>0 " + "   group by sysdate,well_completion_S   ").ToList;
        }
        public CasePortableData GetDCAFromWellLatestDataPortableTestDataForArea(string AreaCode, int wcs)
        {
            return KocConfig.DhubContext.ExecuteStoreQuery<CasePortableData>("SELECT       round(LATEST_OIL_RATE) AS test_rate,  sysdate start_time,well_completion_S  " + " FROM well_latest_data b  " + " WHERE    (decode('" + AreaCode + "','ALL','ALL',b.area)= '" + AreaCode + "') and  wcc_status='OPEN' And LATEST_OIL_RATE is not null   and LATEST_OIL_RATE>0 and well_completion_s=" + wcs + " " + "      ").FirstOrDefault;
        }
        public CasePortableData GetDCAFromWellLatestDataPortableTestDataForField(string FieldCode, int wcs)
        {
            return KocConfig.DhubContext.ExecuteStoreQuery<CasePortableData>("SELECT       round(LATEST_OIL_RATE) AS test_rate,  sysdate start_time,well_completion_S  " + " FROM well_latest_data b  " + " WHERE    field_code= '" + FieldCode + "' and LATEST_OIL_RATE is not null   wcc_status='OPEN' And and LATEST_OIL_RATE>0 and well_completion_s=" + wcs).FirstOrDefault;
        }
        public List<CasePortableData> GetDCAavgPortableTestDataForArea2YearsAgo(string AreaCode)
        {
            return KocConfig.DhubContext.ExecuteStoreQuery<CasePortableData>("SELECT     ADD_MONTHS(SYSDATE,-24)   start_time, ROUND( avg(GET_WCS_LIQUID_RATE_NOB4(B.WELL_COMPLETION_S,ADD_MONTHS(SYSDATE,-24)) * (1 - GET_WCS_WATER_CUT_nob4(B.WELL_COMPLETION_S,ADD_MONTHS(SYSDATE,-24)) / 100)))  AS test_rate     " + " FROM  well_latest_data b  " + "    group by   ADD_MONTHS(SYSDATE,-24)  having ROUND( avg(GET_WCS_LIQUID_RATE_NOB4(B.WELL_COMPLETION_S,ADD_MONTHS(SYSDATE,-24)) * (1 - GET_WCS_WATER_CUT_nob4(B.WELL_COMPLETION_S,ADD_MONTHS(SYSDATE,-24)) / 100))) >0  ").ToList;
        }
        public List<CasePortableData> GetDCAAvgPortableTestDataForArea(string AreaCode)
        {
            return KocConfig.DhubContext.ExecuteStoreQuery<CasePortableData>("SELECT     ROUND(avg (LATEST_OIL_RATE )) AS test_rate,sysdate  start_time    " + " FROM well_latest_data b  " + " WHERE    (decode('" + AreaCode + "','ALL','ALL',b.area)= '" + AreaCode + "') and LATEST_OIL_RATE is not null  and LATEST_OIL_RATE>0 " + "    group by   sysdate    ").ToList;

            // group by a.start_time ,b.PPDM_WCS_UWI
        }
        public List<WaterCutData> GetWaterCutTestData(int wcs)
        {
            return KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<WaterCutData>("SELECT DISTINCT WT.WELL_COMPLETION_S, WT.UWI, WT.FACILITY_TYPE,  WT.ACTIVITY_TYPE, WT.ACTIVITY_NAME, WT.START_TIME, WT.LIQUID_RATE, WT.CASING_PRESSURE, WT.TUBING_PRESSURE, WT.FLOW_LINE_PRESSURE, WT.LEFT_CHOKE_SIZE, WT.RIGHT_CHOKE_SIZE, WT.WATER_RATE,pp.nominal_water_cut, GET_WCS_SALT_uwi(WT.UWI, TO_CHAR(WT.START_TIME, 'dd/mm/yyyy')) AS SALT, PP.ACTIVITY_TYPE AS TEST_TYPE FROM FINDERWEB.TEST_STAGE WT ,FINDERWEB.PERIODIC_PRODUCTION(PP) WHERE     (PP.ACTIVITY_TYPE = 'WATER_CUT') AND (PP.PREFERRED_FLAG = 'Y') AND  (WT.WELL_COMPLETION_S =" + wcs + ") AND  WT.TEST_STAGE_S = PP.TEST_STAGE_S ORDER BY WT.START_TIME DESC").ToList;
        }
        public List<DCSData> GetDCSTestData(int wcs)
        {
            // 
            return KocConfig.DhubContext.ExecuteStoreQuery<DCSData>("SELECT     TEST_STAGE_S, OIL_FIELD_OPERATION_S, START_TIME, TEST_TYPE, TEST_RATE, WC, GOR, WHP, FLP,  ROUND(test_rate * (100 - WC / 100) ) AS OILRATE,  " + " LEFT_CHOKE_SIZE, RIGHT_CHOKE_SIZE, CHOKE " + " FROM well_tests_v1 " + " WHERE     (TEST_TYPE ='DCS' ) AND (WELL_COMPLETION_S= " + wcs + ")  " + "    ORDER BY start_time DESC").ToList;
        }
        public List<FluidAnalysisData> GetFuildAnalysis(int wcs)
        {
            return KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<FluidAnalysisData>(" SELECT DISTINCT wc.well_completion_s, wc.uwi, wc.facility_type, wc.start_time wc_dt, rs.reservoir_id, fa.start_time, fa.oil_field_operation_s, fa.pressure, fa.temperature,fs.api_gravity, fs.specific_gravity,SUM(DECODE(mc.component_material_type, 'SALT', mc.concentration)) SALT, SUM(DECODE(mc.component_material_type, 'SULPHUR', mc.concentration)) SULPHUR  FROM koc.well_completion wc, koc.reservoir rs, koc.fluid_analysis fa,koc.fluid_analysis fa1,koc.fluid_state_pty fs,koc.material_composition mc, koc.fluid_analysis fa2   WHERE (wc.reservoir_s = rs.reservoir_s) AND fa.well_completion_s = wc.well_completion_s  and fs.project_fluid_analysis_s = fa1.fluid_analysis_s AND fa1.oil_field_operation_s = fa.oil_field_operation_s AND fa.activity_type IN ('FLUID_ANALYSIS', 'SALT_CONTENT', 'SULPHUR_CONTENT_OF_OIL', 'SPECIFIC_GRAVITY_OF_OIL') AND fa1.oil_field_operation_s IS NOT NULL AND fs.api_gravity IS NOT NULL  AND fs.material_type = 'GAS'  and mc.component_material_type IN ('SALT', 'SULPHUR')  AND mc.project_fluid_analysis_s = fa2.fluid_analysis_s AND fa2.oil_field_operation_s = fa.oil_field_operation_s AND fa2.activity_type IN ('FLUID_ANALYSIS', 'SALT_CONTENT', 'SULPHUR_CONTENT_OF_OIL') AND fa2.start_time = fa.start_time AND fa2.well_completion_s = fa.well_completion_s AND wc.well_completion_s =" + wcs + "  GROUP BY fa.start_time, fa.oil_field_operation_s, wc.well_completion_s, wc.uwi, wc.facility_type, wc.start_time,  rs.reservoir_id, fa.start_time, fa.oil_field_operation_s, fa.pressure, fa.temperature, fs.api_gravity, fs.specific_gravity  HAVING count(*)  = 1  ORDER BY wc.uwi, fa.start_time desc").ToList;
        }
        public List<TestStageData> GetTestStageData(int wcs)
        {
            return KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<TestStageData>("SELECT    START_TIME as starttime, TEST_TYPE, TEST_RATE, WC, GOR, WHP, FLP, LEFT_CHOKE_SIZE, RIGHT_CHOKE_SIZE, CHOKE, WELL_COMPLETION_S, UWI   FROM FINDERWEB.WELL_TESTS_V1  WHERE        (TEST_TYPE ='DCS') AND (WELL_COMPLETION_S = " + wcs + ") ORDER BY START_TIME desc").ToList;

        }
        public List<FBHPclassreport> GetFBHPDataForFieldandRes(string FldID, string resid)
        {
            var x = new List<FBHPclassreport>();
            x = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<FBHPclassreport>("  a.start_time,a.pressure,a.temperature,a.depth,b.PPDM_WCS_UWI,b.RESERVOIR_ID from koc.test_stage@FINDERWEB_ORB_DBLINK a,well_latest_data b " + " where a.activity_type='FBHP'" + " and a.well_completion_s=b.well_completion_s" + "  b.field_id = '" + FldID + "'" + "  b.reservoir_id = '" + resid + "'" + "  ORDER BY a.START_TIME desc").ToList;

            return x;

        }
        public List<FBHPclassreport> GetSBHPDataForFieldandRes(string FldID, string resid)
        {
            var x = new List<FBHPclassreport>();
            x = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<FBHPclassreport>("  a.start_time,a.pressure,a.temperature,a.depth,b.PPDM_WCS_UWI,b.RESERVOIR_ID from koc.test_stage@FINDERWEB_ORB_DBLINK a,well_latest_data b " + " where a.activity_type='SBHP'" + " and a.well_completion_s=b.well_completion_s" + "  b.field_id = '" + FldID + "'" + "  b.reservoir_id = '" + resid + "'" + "  ORDER BY a.START_TIME desc").ToList;

            return x;

        }
        public List<FBHPclassreport> GetFBHPData(int wcs)
        {
            var x = new List<FBHPclassreport>();
            x = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<FBHPclassreport>("SELECT   ofo.uwi, ofo.start_time, ofo.activity_type, ofo.activity_name," + "          ofo.existence_type, ts.state_type, tsum.stabilized_flow_period," + "      ts.DEPTH, ts.pressure, ta.pressure_datum," + "        ta.extrapolated_pressure, ta.gradient, ts.static_gradient," + "        ts.temperature, ts.casing_pressure, ts.tubing_pressure," + "       ts.well_head_temp, ts.preffered_flag, ofo.SOURCE," + "       eu.description gauge_number, eu.equipment_role, eu.equipment_type," + "       ofo.business_assoc_id, ofo.operation_number, ofo.engineer," + "      ofo.remarks, koc.wellcalc.tvdepth (ofo.uwi, ts.DEPTH) depth_tvd," + "       CASE" + "           WHEN (  koc.wellcalc.tvdepth (ofo.uwi, ts.DEPTH)" + "                - LAG (koc.wellcalc.tvdepth (ofo.uwi, ts.DEPTH)) OVER (PARTITION BY ofo.oil_field_operation_s ORDER BY DEPTH ASC)" + "               ) > 0" + "            THEN ROUND" + "                    ((  (  pressure- LAG (pressure) OVER (PARTITION BY ofo.oil_field_operation_s ORDER BY DEPTH ASC))/( koc.wellcalc.tvdepth (ofo.uwi, ts.DEPTH) - LAG (koc.wellcalc.tvdepth (ofo.uwi, ts.DEPTH)) OVER (PARTITION BY ofo.oil_field_operation_s ORDER BY DEPTH ASC))),3 )" + "          ELSE NULL" + "        END gradient_tvd," + "         ts.remarks ts_remarks, ofo.oil_field_operation_s," + "          ofo.well_completion_s, ofo.insert_date, ofo.inserted_by," + "         ofo.last_update, ofo.updated_by" + "    FROM koc.oil_field_operation ofo," + "         koc.test_summary tsum," + "         koc.test_stage ts," + "        koc.test_analysis ta," + " koc.equipment_used eu" + " WHERE ofo.activity_type ='FBHP' " + " AND ofo.oil_field_operation_s = tsum.containing_act_s(+)" + " AND ofo.well_completion_s = " + wcs + " AND ofo.oil_field_operation_s = ts.containing_act_s(+)" + " And ofo.oil_field_operation_s = ta.containing_act_s(+)" + " AND ofo.oil_field_operation_s = eu.oil_field_operation_s(+)").ToList;

            return x;

        }
        public List<FBHPclassreport> GetSBHPData(int wcs)
        {
            var x = new List<FBHPclassreport>();
            x = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<FBHPclassreport>("SELECT   ofo.uwi, ofo.start_time, ofo.activity_type, ofo.activity_name," + "          ofo.existence_type, ts.state_type, tsum.stabilized_flow_period," + "      ts.DEPTH, ts.pressure, ta.pressure_datum," + "        ta.extrapolated_pressure, ta.gradient, ts.static_gradient," + "        ts.temperature, ts.casing_pressure, ts.tubing_pressure," + "       ts.well_head_temp, ts.preffered_flag, ofo.SOURCE," + "       eu.description gauge_number, eu.equipment_role, eu.equipment_type," + "       ofo.business_assoc_id, ofo.operation_number, ofo.engineer," + "      ofo.remarks, koc.wellcalc.tvdepth (ofo.uwi, ts.DEPTH) depth_tvd," + "       CASE" + "           WHEN (  koc.wellcalc.tvdepth (ofo.uwi, ts.DEPTH)" + "                - LAG (koc.wellcalc.tvdepth (ofo.uwi, ts.DEPTH)) OVER (PARTITION BY ofo.oil_field_operation_s ORDER BY DEPTH ASC)" + "               ) > 0" + "            THEN ROUND" + "                    ((  (  pressure- LAG (pressure) OVER (PARTITION BY ofo.oil_field_operation_s ORDER BY DEPTH ASC))/( koc.wellcalc.tvdepth (ofo.uwi, ts.DEPTH) - LAG (koc.wellcalc.tvdepth (ofo.uwi, ts.DEPTH)) OVER (PARTITION BY ofo.oil_field_operation_s ORDER BY DEPTH ASC))),3 )" + "          ELSE NULL" + "        END gradient_tvd," + "         ts.remarks ts_remarks, ofo.oil_field_operation_s," + "          ofo.well_completion_s, ofo.insert_date, ofo.inserted_by," + "         ofo.last_update, ofo.updated_by" + "    FROM koc.oil_field_operation ofo," + "         koc.test_summary tsum," + "         koc.test_stage ts," + "        koc.test_analysis ta," + " koc.equipment_used eu" + " WHERE ofo.activity_type ='SBHP' " + " AND ofo.oil_field_operation_s = tsum.containing_act_s(+)" + " AND ofo.well_completion_s = " + wcs + " AND ofo.oil_field_operation_s = ts.containing_act_s(+)" + " And ofo.oil_field_operation_s = ta.containing_act_s(+)" + " AND ofo.oil_field_operation_s = eu.oil_field_operation_s(+)").ToList;
            return x;


        }
        public List<Workoverclassreport> GetWorkoverDataFromStartwithLQWCGOR(string p_uwi, int wcs)
        {
            var x = new List<Workoverclassreport>();
            var p = new List<Workoverclassreport>();
            p = KocConfig.DhubContext.ExecuteStoreQuery<Workoverclassreport>("SELECT       START_TIME, TEST_TYPE,  TEST_RATE, WC, GOR, WHP, FLP,  ROUND(test_rate * (100 - WC / 100) ) AS OILRATE,  " + " LEFT_CHOKE_SIZE, RIGHT_CHOKE_SIZE, CHOKE " + " FROM well_tests_v1 " + " WHERE     (TEST_TYPE in ('PORTABLE GOR MULTIRATE','PORTABLE')  ) AND (WELL_COMPLETION_S= " + wcs + ") and gor is not null " + "    ORDER BY start_time DESC").ToList;
            x = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<Workoverclassreport>("SELECT     OFO.ACTIVITY_ID, OFO.START_TIME, OFO.END_TIME, OFO.OPERATION_PURPOSE " + " FROM         koc.OIL_FIELD_OPERATION OFO " + " WHERE      (OFO.ACTIVITY_TYPE = 'WORKOVER') AND (OFO.UWI ='" + p_uwi + "')  " + "                      " + " order by ofo.start_time asc").ToList;
            foreach (Workoverclassreport Y in x)
            {
                // ------------------------------------------------
                string wostart = Y.START_TIME.Day + "-" + Y.START_TIME.Month + "-" + Y.START_TIME.Year;
                string woend = Y.END_TIME.Day + "-" + Y.END_TIME.Month + "-" + Y.END_TIME.Year;
                PortableData pr = KocConfig.DhubContext.ExecuteStoreQuery<PortableData>("SELECT       START_TIME, TEST_TYPE,  TEST_RATE, WC, GOR, WHP, FLP,  ROUND(test_rate * (100 - WC / 100) ) AS OILRATE,  " + " LEFT_CHOKE_SIZE, RIGHT_CHOKE_SIZE, CHOKE " + " FROM well_tests_v1 " + " WHERE   start_time<=to_date('" + wostart + "','dd/mm/yyyy') and  (TEST_TYPE in ('PORTABLE GOR MULTIRATE','PORTABLE')  ) AND (WELL_COMPLETION_S= " + wcs + ") and gor is not null " + "    ORDER BY start_time DESC").FirstOrDefault;
                pStart_date = Conversions.ToString(pr.start_time.Value);
                Y.TEST_RATE = pr.TEST_RATE;
                Y.CHOKE = pr.CHOKE;
                Y.FLP = pr.FLP;
                Y.GOR = pr.GOR;
                Y.WC = pr.WC;
                Y.WHP = pr.WHP;
                Y.TEST_TYPE = pr.TEST_TYPE;
                // pStart_date = wostart
                // Dim dx As New cls_outvaluewithdate
                // dx = Completion_GOR(wcs)
                // If IsNothing(dx) = False Then
                // Y.BeforeGOR = dx.outvalue
                // End If
                // pStart_date = woend
                // dx = New cls_outvaluewithdate
                // dx = Completion_GOR_AfterStartDate(wcs)
                // If IsNothing(dx) = False Then
                // Y.AfterGOR = dx.outvalue
                // End If
                // '------------------------------------------------
                // '------------------------------------------------
                // pStart_date = wostart
                // dx = New cls_outvaluewithdate
                // dx = Completion_WaterCut(wcs)
                // If IsNothing(dx) = False Then
                // Y.BeforeWC = dx.outvalue
                // End If
                // pStart_date = woend
                // dx = New cls_outvaluewithdate
                // dx = Completion_WaterCut_AfterStartDate(wcs)
                // If IsNothing(dx) = False Then
                // Y.AfterWC = dx.outvalue
                // End If
                // ------------------------------------------------
                // ------------------------------------------------
                // pStart_date = wostart
                // dx = New cls_outvaluewithdate
                // dx = Completion_LiquidRate(wcs)
                // If IsNothing(dx) = False Then
                // Y.BeforeLQ = dx.outvalue
                // End If
                // pStart_date = woend
                // dx = New cls_outvaluewithdate
                // dx = Completion_LiquidRate_AfterStartDate(wcs)
                // If IsNothing(dx) = False Then
                // Y.afterLQ = dx.outvalue
                // End If
                FD_COMP_RP_HDR postjob;
                // Dim WO_NUMBER As String
                string woid = Y.ACTIVITY_ID;
                postjob = (from t in KocConfig.DhubContext.FD_COMP_RP_HDR
                           where t.WO_NUMBER == woid
                           select t).FirstOrDefault;
                if (postjob == null == false)
                {
                    Y.PostWorkoverReportid = postjob.ID;
                    Y.PostWorkoverReportExist = true;
                }
                else
                {
                    Y.PostWorkoverReportExist = false;
                }
                // ------------------------------------------------
                p.Add(Y);
            }
            return p;
        }
        public List<Workoverclassreport> GetWorkoverData(string p_uwi, int wcs)
        {
            var x = new List<Workoverclassreport>();
            var p = new List<Workoverclassreport>();
            p = KocConfig.DhubContext.ExecuteStoreQuery<Workoverclassreport>("SELECT       START_TIME, TEST_TYPE,  TEST_RATE, WC, GOR, WHP, FLP,  ROUND(test_rate * (100 - WC / 100) ) AS OILRATE,  " + " LEFT_CHOKE_SIZE, RIGHT_CHOKE_SIZE, CHOKE " + " FROM well_tests_v1 " + " WHERE     (TEST_TYPE in ('PORTABLE GOR MULTIRATE','PORTABLE')  ) AND (WELL_COMPLETION_S= " + wcs + ") and gor is not null " + "    ORDER BY start_time DESC").ToList;
            x = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<Workoverclassreport>("SELECT     OFO.ACTIVITY_ID, OFO.START_TIME, OFO.END_TIME, OFO.OPERATION_PURPOSE, NOTE1.DESCRIPTION AS OBJECTIVE " + " FROM         koc.OIL_FIELD_OPERATION OFO, koc.OIL_FIELD_OPERATION_NOTE NOTE1 " + " WHERE     OFO.OIL_FIELD_OPERATION_S = NOTE1.OIL_FIELD_OPERATION_S AND (OFO.ACTIVITY_TYPE = 'WORKOVER') AND (OFO.UWI ='" + p_uwi + "') AND " + "                     (NOTE1.ATTRIBUTE = 'OBJECTIVE') " + " order by ofo.start_time asc").ToList;
            for (int r = 0, loopTo = x.Count - 1; r <= loopTo; r++)
            {
                // ------------------------------------------------
                var y = new Workoverclassreport();
                y = x[r];
                var y1 = new Workoverclassreport();

                string wostart = y.START_TIME.Day + "-" + y.START_TIME.Month + "-" + y.START_TIME.Year;
                string woend = y.END_TIME.Day + "-" + y.END_TIME.Month + "-" + y.END_TIME.Year;
                PortableData pr = KocConfig.DhubContext.ExecuteStoreQuery<PortableData>("SELECT       START_TIME, TEST_TYPE,  TEST_RATE, WC, GOR, WHP, FLP,  ROUND(test_rate * (100 - WC / 100) ) AS OILRATE,  " + " LEFT_CHOKE_SIZE, RIGHT_CHOKE_SIZE, CHOKE " + " FROM well_tests_v1 " + " WHERE   trunc(start_time)<to_date('" + wostart + "','dd-mm-yyyy') and (TEST_TYPE in ('PORTABLE GOR MULTIRATE','PORTABLE')  ) AND (WELL_COMPLETION_S= " + wcs + ") and gor is not null " + "    ORDER BY start_time DESC").FirstOrDefault;
                if (pr == null == false)
                {

                    y.TEST_RATE = pr.TEST_RATE;
                    y.CHOKE = pr.CHOKE;
                    y.FLP = pr.FLP;
                    y.GOR = pr.GOR;
                    y.WC = pr.WC;
                    y.WHP = pr.WHP;
                    y.TEST_TYPE = pr.TEST_TYPE;
                    y.WorkoverExist = pr.TEST_RATE;

                }


                PortableData pr1 = KocConfig.DhubContext.ExecuteStoreQuery<PortableData>("SELECT       START_TIME, TEST_TYPE,  TEST_RATE, WC, GOR, WHP, FLP,  ROUND(test_rate * (100 - WC / 100) ) AS OILRATE,  " + " LEFT_CHOKE_SIZE, RIGHT_CHOKE_SIZE, CHOKE " + " FROM well_tests_v1 " + " WHERE   trunc(start_time)>to_date('" + wostart + "','dd-mm-yyyy') and (TEST_TYPE in ('PORTABLE GOR MULTIRATE','PORTABLE')  ) AND (WELL_COMPLETION_S= " + wcs + ") and gor is not null " + "    ORDER BY start_time asc").FirstOrDefault;
                if (pr1 == null == false)
                {
                    if (r < x.Count - 1)
                    {
                        if (x[r + 1].START_TIME is var arg2 && pr1.start_time is { } arg1 && arg1 > arg2)
                        {
                            y1.START_TIME = y.END_TIME;
                            y1.TEST_RATE = 0;
                            y1.CHOKE = 0.ToString();
                            y1.FLP = 0;
                            y1.GOR = 0;
                            y1.WC = 0;
                            y1.WHP = 0;

                            y1.WorkoverExist = 0;
                            y1.ACTIVITY_ID = "End of Activity";
                            y1.OPERATION_PURPOSE = "";
                            y1.TEST_TYPE = "End of Activity";
                        }
                        else
                        {
                            y1.START_TIME = y.END_TIME;
                            y1.TEST_RATE = pr1.TEST_RATE;
                            y1.CHOKE = pr1.CHOKE;
                            y1.FLP = pr1.FLP;
                            y1.GOR = pr1.GOR;
                            y1.WC = pr1.WC;
                            y1.WHP = pr1.WHP;
                            y1.TEST_TYPE = pr1.TEST_TYPE;
                            y1.WorkoverExist = pr1.TEST_RATE;
                            y1.ACTIVITY_ID = "End of Activity";
                            y1.OPERATION_PURPOSE = "";
                        }
                    }
                    else
                    {
                        y1.START_TIME = y.END_TIME;
                        y1.TEST_RATE = pr1.TEST_RATE;
                        y1.CHOKE = pr1.CHOKE;
                        y1.FLP = pr1.FLP;
                        y1.GOR = pr1.GOR;
                        y1.WC = pr1.WC;
                        y1.WHP = pr1.WHP;
                        y1.TEST_TYPE = pr1.TEST_TYPE;
                        y1.WorkoverExist = pr1.TEST_RATE;
                        y1.ACTIVITY_ID = "End of Activity";
                        y1.OPERATION_PURPOSE = "";

                    }


                }

                // Dim dx As New cls_outvaluewithdate
                // dx = Completion_GOR(wcs)
                // If IsNothing(dx) = False Then
                // Y.BeforeGOR = dx.outvalue
                // End If
                // pStart_date = woend
                // dx = New cls_outvaluewithdate
                // dx = Completion_GOR_AfterStartDate(wcs)
                // If IsNothing(dx) = False Then
                // Y.AfterGOR = dx.outvalue
                // End If
                // '------------------------------------------------
                // '------------------------------------------------
                // pStart_date = wostart
                // dx = New cls_outvaluewithdate
                // dx = Completion_WaterCut(wcs)
                // If IsNothing(dx) = False Then
                // Y.BeforeWC = dx.outvalue
                // End If
                // pStart_date = woend
                // dx = New cls_outvaluewithdate
                // dx = Completion_WaterCut_AfterStartDate(wcs)
                // If IsNothing(dx) = False Then
                // Y.AfterWC = dx.outvalue
                // End If
                // '------------------------------------------------
                // '------------------------------------------------
                // pStart_date = wostart
                // dx = New cls_outvaluewithdate
                // dx = Completion_LiquidRate(wcs)
                // If IsNothing(dx) = False Then
                // Y.BeforeLQ = dx.outvalue
                // End If
                // pStart_date = woend
                // dx = New cls_outvaluewithdate
                // dx = Completion_LiquidRate_AfterStartDate(wcs)
                // If IsNothing(dx) = False Then
                // Y.afterLQ = dx.outvalue
                // End If

                FD_COMP_RP_HDR postjob;
                // Dim WO_NUMBER As String
                string woid = y.ACTIVITY_ID;
                postjob = (from t in KocConfig.DhubContext.FD_COMP_RP_HDR
                           where t.WO_NUMBER == woid
                           select t).FirstOrDefault;
                if (postjob == null == false)
                {
                    y.PostWorkoverReportid = postjob.ID;
                    y.PostWorkoverReportExist = true;
                }
                else
                {
                    y.PostWorkoverReportExist = false;
                }
                p.Add(y);
                p.Add(y1);
                // ------------------------------------------------
            }
            // Dim outp As New List(Of Workoverclassreport)
            var outp = (from i in p
                        orderby i.START_TIME
                        select i).ToList();
            return outp;
        }
        // cls_ots_dm_al_stopstart_events
        public List<cls_survillanceclassreport> GetOTSALMSEventsdata(string pUWI)
        {
            var ls = new List<cls_survillanceclassreport>();
            ls = KocConfig.OTSContext.ExecuteStoreQuery<cls_survillanceclassreport>("Select distinct distinct a.well WellName,  a.service_status , a.contractor, a.service_status_date , a.main_job_type , a.service_remarks ,  b.datetime ALM_start_time , b.stopstart, b.remarks ALM_remarks   from OTS_DM_ACTIVITIES_HISTORY a,OTS_DM_al_stopstart_events b where a.well=b.uwi and b.uwi like '" + pUWI + "'  order by service_status_date").ToList;
            WellLatestDataList.Where(o => (o.UWI ?? "") == (pUWI ?? "")).FirstOrDefault().rep_survillance_report = ls;
            return ls;
        }
        public List<cls_ots_dm_al_stopstart_events> GetALMStartStopdata(string pUWI)
        {
            var ls = new List<cls_ots_dm_al_stopstart_events>();
            ls = KocConfig.OTSContext.ExecuteStoreQuery<cls_ots_dm_al_stopstart_events>("Select distinct uwi,  datetime start_time , stopstart, remarks ,wstring  from OTS_DM_al_stopstart_events where uwi like '" + pUWI + "'  order by 2").ToList;
            WellLatestDataList.Where(o => (o.UWI ?? "") == (pUWI ?? "")).FirstOrDefault().rep_survillance_ALMS_StartStopreport = ls;
            return ls;
        }
        public List<cls_survillanceclassreport> GetWellSurvillancedata(string pUWI)
        {
            var ls = new List<cls_survillanceclassreport>();
            ls = KocConfig.OTSContext.ExecuteStoreQuery<cls_survillanceclassreport>("Select distinct well WellName,  service_status , contractor, service_status_date , main_job_type , service_remarks  from OTS_DM_ACTIVITIES_HISTORY where well like '" + pUWI + "'  order by 1").ToList;
            WellLatestDataList.Where(o => (o.UWI ?? "") == (pUWI ?? "")).FirstOrDefault().rep_survillance_report = ls;
            return ls;
        }
        public List<cls_rigactivityreport> GetWellRigActivitesfordata(string pUWI)
        {
            var ls = new List<cls_rigactivityreport>();
            // GetNewOldConnectedWells(pGC)
            ls = KocConfig.EDMContext.ExecuteStoreQuery<cls_rigactivityreport>("SELECT R.RIG_NAME,CW.WELL_COMMON_NAME WellName,D.DATE_REPORT,D.STATUS status_type,D.COMMENT_SUMMARY DDR_REPORT,D.DAYS_ON_LOCATION,D.DAYS_FROM_SPUD,D.TREE_CONDITION NEXT_LOC FROM EDMADMIN.DM_DAILY D,EDMADMIN.CD_WELL_SOURCE  CW,EDMADMIN.CD_RIG R,  EDMADMIN.dm_report_journal RJ WHERE D.WELL_ID= CW.WELL_ID    AND R.RIG_ID= RJ.RIG_ID AND D.REPORT_JOURNAL_ID=RJ.REPORT_JOURNAL_ID   and cw.WELL_COMMON_NAME = '" + pUWI + "' ORDER BY 2,3 DESC").ToList;
            WellLatestDataList.Where(o => (o.UWI ?? "") == (pUWI ?? "")).FirstOrDefault().rep_RigAcivities_report = ls;
            return ls;
        }
        public List<cls_ESP_DAILY_READING_report> GetWellESPReadingData(string puwi)
        {
            var ls = new List<cls_ESP_DAILY_READING_report>();
            ls = KocConfig.OTSContext.ExecuteStoreQuery<cls_ESP_DAILY_READING_report>("select WELL,GC,INSTALLATION_DATE,WELL_COMPLETION_S,READING_DATE_TIME,RECORD_ENTRY_DATE_TIME,PI,PD,WHP,TI,TM,FLP,CURRENT_A,CURRENT_B,CURRENT_C,VOLTAGE_AB, VOLTAGE_BC, VOLTAGE_CA, FREQUENCY, VIBRATION, TANK_LEVEL, REMARKS from OTS_DM_ESP_LAST_DAILY_READINGS where well = '" + puwi + "'  order by reading_date_time asc").ToList; // and reading_date_time between to_date('" + startdate + "','dd-mm-yyyy') and to_date('" + enddate + "','dd-mm-yyyy')
            WellLatestDataList.Where(o => (o.UWI ?? "") == (puwi ?? "")).FirstOrDefault().rep_ESP_Reading_report = ls;
            return ls;
        }
        public List<cls_ESP_DAILY_READING_report> GetWellESPReadingData(string puwi, string startdate, string enddate)
        {
            var ls = new List<cls_ESP_DAILY_READING_report>();
            ls = KocConfig.OTSContext.ExecuteStoreQuery<cls_ESP_DAILY_READING_report>("select WELL,GC,INSTALLATION_DATE,WELL_COMPLETION_S,READING_DATE_TIME,RECORD_ENTRY_DATE_TIME,PI,PD,WHP,TI,TM,FLP,CURRENT_A,CURRENT_B,CURRENT_C,VOLTAGE_AB, VOLTAGE_BC, VOLTAGE_CA, FREQUENCY, VIBRATION, TANK_LEVEL, REMARKS from OTS_DM_ESP_DAILY_READINGS where well = '" + puwi + "' and pi is not null and reading_date_time between '" + startdate + "' and '" + enddate + "' order by reading_date_time asc").ToList; // 
            WellLatestDataList.Where(o => (o.UWI ?? "") == (puwi ?? "")).FirstOrDefault().rep_ESP_Reading_report = ls;
            return ls;
        }

        public ObjectSet<WELL_ACTIVITIES> GetWellActivitesFromWEP(string puwi)
        {
            return KocConfig.DhubContext.WELL_ACTIVITIES.Where(x => Operators.ConditionalCompareObjectEqual(x.UWI, puwi, false));

        }
        public WELL_ACTIVITIES GetWellActivityFromWEP(string pid)
        {
            return KocConfig.DhubContext.WELL_ACTIVITIES.Where(x => Operators.ConditionalCompareObjectEqual(x.ID, pid, false)).FirstOrDefault;

        }
        public ObjectSet<WELL_ACTIVITIES> GetAreaActivitiesFromWEP(string pAreaID)
        {
            return KocConfig.DhubContext.WELL_ACTIVITIES.Where(x => Operators.ConditionalCompareObjectEqual(x.AREA, pAreaID, false));

        }
        public ObjectSet<WELL_ACTIVITIES> GetCurrentAreaActivitiesFromWEP(string pAreaID)
        {
            return KocConfig.DhubContext.WELL_ACTIVITIES.Where(x => Operators.AndObject(Operators.ConditionalCompareObjectEqual(x.AREA, pAreaID, false), Operators.OrObject(Operators.ConditionalCompareObjectNotEqual(x.JOB_STATUS, "COMPLETED", false), x.JOB_STATUS is DBNull == true)));

        }
        public List<cls_ba> GetBAData(int v_wcs)
        {
            return KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_ba>("SELECT     FIELD_CODE, OIL_VOLUME AS TOTOIL, WATER_VOLUME AS TOTWater, GAS_VOLUME AS TOTGAS,PRODUCTION_DATE " + "      AS proddate, finderweb.GET_WCS_WATER_CUT(WELL_COMPLETION_S,   " + "     to_char(PRODUCTION_DATE,'dd/mm/yyyy')) AS WC," + "    decode(WATER_VOLUME,0,0,(WATER_VOLUME   / (WATER_VOLUME + OIL_VOLUME))*100) AS ba_wc, finderweb.GET_WCS_LIQUID_RATE(WELL_COMPLETION_S,  to_char(PRODUCTION_DATE,'dd/mm/yyyy')) AS lq, " + " WELL_COMPLETION_S FROM koc.KOC_MONTHLY_OWG_SNAP   WHERE WELL_COMPLETION_S =" + v_wcs + " ORDER BY PRODUCTION_DATE").ToList;
        }
        public List<cls_proddata> GetProdData(string puwi, int pwcs, int pmonths)
        {
            return KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_proddata>("select     TO_CHAR(d.start_time,'YYYY/MM')   LASTMONTH,  " + "     round(sum(decode(material_type,'OIL',d.liquid_volume))) oil ,   " + "     round(sum(decode(material_type ,'GAS',d.GAS_volume))) gas,  " + "     round(sum(decode(material_type, 'WATER',d.liquid_volume))) water  " + "      from " + "     koc.monthly_production_hdr  h,  " + "         koc.MONTHLY_PRODUCTION_DATA d, " + "        koc.WELL_COMPLETION w, " + "         koc.RESERVOIR      rr    where " + "          d.monthly_production_hdr_s = h.monthly_production_hdr_s  " + "     and h.well_completion_s=w.well_completion_s  " + "     and h.flow_dir_type='PRODUCTION'  " + "     and h.activity_Type='ALLOCATED'  " + "     and rr.reservoir_s=w.reservoir_s  " + "     and w.uwi='" + puwi + "'" + "     and h.well_completion_s=" + pwcs + "     and  trunc(d.start_time) >= trunc(add_months(sysdate,-1 * " + pmonths + "))  " + "      Group by    TO_CHAR(d.start_time,'YYYY/MM')     order by 1 asc").ToList;
        }
        public cls_prepostdata GetWellPrePostData(int v_wcs, string pdate, string cond)
        {
            return KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_prepostdata>(" SELECT  " + v_wcs + "  AS Completion_No, ' " + pdate + "'  AS Entered_Date,  finderweb.GET_PREPOST_WCS_BHP(" + v_wcs + ",  to_date('" + pdate + "','dd/mm/yyyy')   , 'FBHP',  '" + cond + "' ) AS FBHP,  finderweb.Get_PREPOST_Wcs_Perf(" + v_wcs + ",  to_date('" + pdate + "','dd/mm/yyyy')   ,  '" + cond + "' ) AS Perf,  finderweb.GET_PREPOST_WCS_CHOKE(" + v_wcs + ",  to_date('" + pdate + "','dd/mm/yyyy')   , '" + cond + "' ) AS CHOKE,  finderweb.Get_PREPOST_Wcs_PI(" + v_wcs + ",  to_date('" + pdate + "','dd/mm/yyyy')   ,  '" + cond + "' ) AS PI,  finderweb.GET_PREPOST_ESP_TYPE(" + v_wcs + ",  to_date('" + pdate + "','dd/mm/yyyy')   ,  '" + cond + "' ) AS ESP_TYPE,  finderweb.GET_PREPOST_WCS_LQ_RATE(" + v_wcs + ",  to_date('" + pdate + "','dd/mm/yyyy')   ,  '" + cond + "' ) AS Liquid_rate,  finderweb.GET_PREPOST_WCS_GOR(" + v_wcs + ",  to_date('" + pdate + "','dd/mm/yyyy')   ,  '" + cond + "' ) AS GOR,  finderweb.GET_PREPOST_WCS_WATER_CUT(" + v_wcs + ",  to_date('" + pdate + "','dd/mm/yyyy')   ,  '" + cond + "' ) AS WC,  finderweb.GET_PREPOST_WCS_BHP(" + v_wcs + ",  to_date('" + pdate + "','dd/mm/yyyy')   , 'SBHP',  '" + cond + "' ) AS SBHP,   finderweb.GET_PREPOST_WCS_WHP(" + v_wcs + ", to_date('" + pdate + "','dd/mm/yyyy')   ,  '" + cond + "' ) AS WHP  FROM DUAL").FirstOrDefault;
        }
        #region Well Data Misc Fetch Routines
        public cls_outvaluewithdate Completion_GOR(int v_wcs)
        {
            cls_outvaluewithdate mat;
            mat = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_outvaluewithdate>("  select  NOMINAL_GOR outvalue,pp.start_Time outdate" + " from koc.periodic_productIon  pp " + "    where " + "      activity_type      =  'TOTAL_GOR'" + " and               pp.well_Completion_s=" + v_wcs + " " + " and               preferred_flag='Y'" + " and               NOMINAL_GOR is not null" + " and               pp.start_Time <=to_date('" + pStart_date + "','dd/mm/yyyy')" + " Order by     start_time desc").FirstOrDefault;
            return mat;


        }
        public cls_outvaluewithdate Completion_GOR_AfterStartDate(int v_wcs)
        {
            cls_outvaluewithdate mat;
            mat = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_outvaluewithdate>("  select  NOMINAL_GOR outvalue,pp.start_Time outdate" + " from koc.periodic_productIon  pp " + "    where " + "      activity_type      =  'TOTAL_GOR'" + " and               pp.well_Completion_s=" + v_wcs + " " + " and               preferred_flag='Y'" + " and               NOMINAL_GOR is not null" + " and               pp.start_Time >to_date('" + pStart_date + "','dd/mm/yyyy')+1" + " Order by     start_time asc").FirstOrDefault;
            return mat;


        }
        public cls_Comp_oper_status CompletionsOperationalStatus(int v_wcs)
        {
            var x = new List<cls_Comp_oper_status>();
            x = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_Comp_oper_status>(" SELECT ofo.start_time, fs.status_type,fs.reason " + " FROM koc_staging.s_oil_field_operation ofo, koc_staging.s_facility_status fs " + "     WHERE(fs.start_oil_field_operation_s = ofo.oil_field_operation_s) " + "AND ofo.activity_type = 'FACILITY_STATUS_CHANGE'" + "AND ofo.start_time < TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1" + "AND ofo.well_completion_s = " + v_wcs + " " + "ORDER BY ofo.start_time DESC").ToList;

            return x.FirstOrDefault();

        }
        public string String_Connection_Slot(int string_S)
        {
            string slot;
            slot = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<string>("SELECT sf.facility_id " + " FROM " + pSchema + ".surface_facility sf, " + pSchema + ".general_port gp_sf, " + pSchema + ".port_connection pc, " + pSchema + ".general_port gp_wc " + " WHERE sf.facility_type = 'INCOMMER'" + " AND sf.surface_facility_s = gp_sf.surface_facility_s" + " AND gp_sf.general_port_s = pc.to_port_s " + " AND (pc.end_time IS NULL OR pc.end_time > TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1) " + " AND pc.start_time < TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1" + " AND pc.from_port_s = gp_wc.general_port_s" + " AND gp_wc.downhole_facility_s = " + string_S + " " + " ORDER BY pc.start_time DESC").FirstOrDefault;
            return slot;
        }
        public cls_outvaluewithdate Completion_LiquidRate(int v_wcs)
        {
            cls_outvaluewithdate lq;
            lq = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_outvaluewithdate>("SELECT ofo.start_time outdate, round(ts.liquid_rate) outvalue " + " FROM koc_staging.s_oil_field_operation ofo, koc_staging.s_test_stage ts" + "     WHERE ts.liquid_rate Is Not NULL " + " AND ts.containing_act_s = ofo.oil_field_operation_s" + " AND ofo.start_time < TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1" + " AND ofo.activity_type = 'TEST'" + " AND ofo.well_completion_s = " + v_wcs + " " + "   UNION " + " SELECT ofo.start_time outdate, round(ts.liquid_rate) outvalue " + " FROM koc.oil_field_operation ofo, koc.test_stage ts" + " WHERE ts.liquid_rate IS NOT NULL" + " AND ts.containing_act_s = ofo.oil_field_operation_s" + " AND ofo.start_time < TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1" + " AND ofo.activity_type = 'TEST'" + " AND ofo.well_completion_s = " + v_wcs + " " + " ORDER BY 1 DESC").FirstOrDefault;
            return lq;
        }
        public cls_outvaluewithdate Completion_LiquidRate_AfterStartDate(int v_wcs)
        {
            cls_outvaluewithdate lq;
            lq = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_outvaluewithdate>("SELECT ofo.start_time outdate, round(ts.liquid_rate) outvalue " + " FROM koc_staging.s_oil_field_operation ofo, koc_staging.s_test_stage ts" + "     WHERE(ts.liquid_rate Is Not NULL)" + " AND ts.containing_act_s = ofo.oil_field_operation_s" + " AND ofo.start_time > TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1" + " AND ofo.activity_type = 'TEST'" + " AND ofo.well_completion_s = " + v_wcs + " " + "   UNION " + " SELECT ofo.start_time outdate, round(ts.liquid_rate) outvalue " + " FROM koc.oil_field_operation ofo, koc.test_stage ts" + " WHERE ts.liquid_rate IS NOT NULL" + " AND ts.containing_act_s = ofo.oil_field_operation_s" + " AND ofo.start_time > TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1" + " AND ofo.activity_type = 'TEST'" + " AND ofo.well_completion_s = " + v_wcs + " " + " ORDER BY 1 asc").FirstOrDefault;
            return lq;
        }
        public cls_outvaluewithdate Completion_Concentration_Fluids(int v_wcs, string Material_type)
        {
            cls_outvaluewithdate mat;
            mat = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_outvaluewithdate>("SELECT mc.concentration outvalue, ofo.start_time outdate" + " FROM koc_staging.s_oil_field_operation ofo, koc_staging.s_fluid_analysis fa, koc_staging.s_material_composition mc " + " WHERE mc.component_material_type = '" + Material_type.ToUpper() + "'" + "  AND mc.concentration IS NOT NULL" + " AND mc.project_fluid_analysis_s = fa.fluid_analysis_s" + " AND fa.oil_field_operation_s = ofo.oil_field_operation_s" + " AND ofo.start_time < TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1" + "    AND ofo.activity_type = 'TEST'" + "    AND ofo.well_completion_s =" + v_wcs + " " + "        UNION" + "  SELECT mc.concentration outvalue, ofo.start_time outdate" + "  FROM koc.oil_field_operation ofo, koc.fluid_analysis fa, koc.material_composition mc" + "  WHERE mc.component_material_type = '" + Material_type.ToUpper() + "'" + "    AND mc.concentration IS NOT NULL" + "    AND mc.project_fluid_analysis_s = fa.fluid_analysis_s" + "    AND fa.oil_field_operation_s = ofo.oil_field_operation_s" + " AND ofo.start_time < TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1" + " AND ofo.activity_type = 'TEST'" + " AND ofo.well_completion_s = " + v_wcs + " " + " ORDER BY 2 DESC").FirstOrDefault;
            return mat;

        }
        public cls_outvaluewithdate Completion_WaterCut(int v_wcs)
        {
            cls_outvaluewithdate wc;
            wc = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_outvaluewithdate>("SELECT pp.nominal_water_cut outvalue , ofo.start_time outdate" + "  FROM koc_staging.s_oil_field_operation ofo, koc_staging.s_test_stage ts, koc_staging.s_periodic_production pp" + " WHERE pp.activity_type = 'WATER_CUT'" + " AND pp.nominal_water_cut IS NOT NULL" + " AND pp.test_stage_s = ts.test_stage_s" + " AND ts.containing_act_s = ofo.oil_field_operation_s" + " AND ofo.start_time < TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1" + " AND ofo.activity_type = 'TEST'" + " AND ofo.well_completion_s = " + v_wcs + " " + "    UNION " + " SELECT pp.nominal_water_cut outvalue , ofo.start_time outdate " + " FROM koc.oil_field_operation ofo, koc.test_stage ts, koc.periodic_production pp" + " WHERE pp.activity_type = 'WATER_CUT'" + " AND pp.nominal_water_cut IS NOT NULL" + " AND pp.test_stage_s = ts.test_stage_s" + " AND ts.containing_act_s = ofo.oil_field_operation_s" + " AND ofo.start_time < TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1" + " AND ofo.activity_type = 'TEST'" + " AND ofo.well_completion_s = " + v_wcs + " " + " ORDER BY 2 DESC").FirstOrDefault;
            return wc;
        }
        public cls_outvaluewithdate Completion_WaterCut_AfterStartDate(int v_wcs)
        {
            cls_outvaluewithdate wc;
            wc = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_outvaluewithdate>("SELECT pp.nominal_water_cut outvalue , ofo.start_time outdate" + "  FROM koc_staging.s_oil_field_operation ofo, koc_staging.s_test_stage ts, koc_staging.s_periodic_production pp" + " WHERE pp.activity_type = 'WATER_CUT'" + " AND pp.nominal_water_cut IS NOT NULL" + " AND pp.test_stage_s = ts.test_stage_s" + " AND ts.containing_act_s = ofo.oil_field_operation_s" + " AND ofo.start_time > TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1" + " AND ofo.activity_type = 'TEST'" + " AND ofo.well_completion_s = " + v_wcs + " " + "    UNION " + " SELECT pp.nominal_water_cut outvalue , ofo.start_time outdate " + " FROM koc.oil_field_operation ofo, koc.test_stage ts, koc.periodic_production pp" + " WHERE pp.activity_type = 'WATER_CUT'" + " AND pp.nominal_water_cut IS NOT NULL" + " AND pp.test_stage_s = ts.test_stage_s" + " AND ts.containing_act_s = ofo.oil_field_operation_s" + " AND ofo.start_time > TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1" + " AND ofo.activity_type = 'TEST'" + " AND ofo.well_completion_s = " + v_wcs + " " + " ORDER BY 2 asc").FirstOrDefault;
            return wc;
        }
        public cls_outvaluewithdate Completion_Choke_left(int v_wcs)
        {
            cls_outvaluewithdate x;
            x = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_outvaluewithdate>("SELECT 	nvl(ts.tubing_left_choke, ts.casing_left_choke)  outvalue,         ofo.start_time outdate " + " FROM koc_staging.s_oil_field_operation ofo, koc_staging.s_test_stage ts " + "       WHERE " + " 	NVL(ts.tubing_left_choke, ts.casing_left_choke) > 0" + "   AND NVL(ts.tubing_right_choke, ts.casing_right_choke) IS NOT NULL" + "   AND ts.containing_act_s = ofo.oil_field_operation_s" + "   AND ofo.start_time < TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1" + "   AND ofo.activity_type = 'TEST'" + "   AND ofo.well_completion_s = " + v_wcs + " " + "        UNION " + " Select " + " nvl(ts.tubing_left_choke, ts.casing_left_choke) outvalue, " + " ofo.start_time outdate" + " FROM koc.oil_field_operation ofo, koc.test_stage ts" + " WHERE " + "  	NVL(ts.tubing_left_choke, ts.casing_left_choke) > 0" + "   AND NVL(ts.tubing_right_choke, ts.casing_right_choke) IS NOT NULL" + "  AND ts.containing_act_s = ofo.oil_field_operation_s" + " AND ofo.start_time < TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1" + " AND ofo.activity_type = 'TEST'" + " AND ofo.well_completion_s = " + v_wcs + " " + " ORDER BY 2 DESC").FirstOrDefault;
            return x;
        }
        public cls_outvaluewithdate Completion_Choke_Right(int v_wcs)
        {
            cls_outvaluewithdate x;
            x = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_outvaluewithdate>("SELECT 	nvl(ts.tubing_right_choke, ts.casing_right_choke)  outvalue,         ofo.start_time outdate " + " FROM koc_staging.s_oil_field_operation ofo, koc_staging.s_test_stage ts " + "       WHERE " + " 	NVL(ts.tubing_right_choke, ts.casing_right_choke) > 0" + "   AND NVL(ts.tubing_left_choke, ts.casing_left_choke) IS NOT NULL" + "   AND ts.containing_act_s = ofo.oil_field_operation_s" + "   AND ofo.start_time < TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1" + "   AND ofo.activity_type = 'TEST'" + "   AND ofo.well_completion_s = " + v_wcs + " " + "        UNION " + " Select " + " nvl(ts.tubing_right_choke, ts.casing_right_choke) outvalue, " + " ofo.start_time outdate" + " FROM koc.oil_field_operation ofo, koc.test_stage ts" + " WHERE " + "  	NVL(ts.tubing_right_choke, ts.casing_right_choke) > 0" + "   AND NVL(ts.tubing_left_choke, ts.casing_left_choke) IS NOT NULL" + "  AND ts.containing_act_s = ofo.oil_field_operation_s" + " AND ofo.start_time < TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1" + " AND ofo.activity_type = 'TEST'" + " AND ofo.well_completion_s = " + v_wcs + " " + " ORDER BY 2 DESC").FirstOrDefault;
            return x;
        }
        public cls_whp_flp_date Completion_Whp_Flp(int v_wcs)
        {
            var x = new cls_whp_flp_date();
            x = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_whp_flp_date>("SELECT nvl(ts.tubing_pressure, ts.casing_pressure) whp, ts.flow_line_pressure flp, ofo.start_time " + " FROM koc_staging.s_oil_field_operation ofo, koc_staging.s_test_stage ts " + "      WHERE ts.flow_line_pressure Is Not NULL " + "  AND (ts.tubing_pressure IS NOT NULL OR ts.casing_pressure IS NOT NULL) " + "  AND ts.containing_act_s = ofo.oil_field_operation_s " + " AND ofo.start_time < TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1 " + "  AND ofo.activity_type = 'TEST'" + "  AND ofo.well_completion_s = " + v_wcs + " " + "      UNION " + " SELECT nvl(ts.tubing_pressure, ts.casing_pressure) whp, ts.flow_line_pressure flp, ofo.start_time " + " FROM koc.oil_field_operation ofo, koc.test_stage ts " + " WHERE ts.flow_line_pressure IS NOT NULL" + "  AND (ts.tubing_pressure IS NOT NULL OR ts.casing_pressure IS NOT NULL) " + "  AND ts.containing_act_s = ofo.oil_field_operation_s " + " AND ofo.start_time < TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1" + " AND ofo.activity_type = 'TEST'" + " AND ofo.well_completion_s = " + v_wcs + " " + " ORDER BY 3 DESC").FirstOrDefault;
            return x;
        }
        public string GetMFL(int v_wcs)
        {
            string x = "";
            x = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<string>("select   mfl   from koc.koc_mult_flowline     where wc_s=" + v_wcs).FirstOrDefault;
            return x;
        }
        public cls_gc_chokechange_data_2 CompletionChokeChange_byTestDate(int v_wcs, string testdate)
        {
            var dr = new cls_gc_chokechange_data_2();
            dr = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_gc_chokechange_data_2>(" SELECT ts.left_choke_size, ts.right_choke_size, ofo.start_time " + " FROM koc.oil_field_operation ofo, koc.test_stage ts " + "    WHERE ts.left_choke_size Is Not NULL " + "  AND ts.right_choke_size IS NOT NULL " + "  AND ts.start_time <TO_DATE('" + testdate + "', 'dd-mm-yyyy')  " + "  AND ts.containing_act_s = ofo.oil_field_operation_s " + "  AND ofo.activity_type = 'TEST' " + "  AND ofo.well_completion_s = " + v_wcs + " " + "     UNION " + "  SELECT ts.left_choke_size, ts.right_choke_size, ofo.start_time " + "  FROM koc_staging.oil_field_operation ofo, koc_staging.test_stage ts " + "  WHERE ts.left_choke_size IS NOT NULL " + "   AND ts.right_choke_size IS NOT NULL " + "   AND ts.start_time <TO_DATE('" + testdate + "', 'dd-mm-yyyy')  " + "   AND ts.containing_act_s = ofo.oil_field_operation_s " + "   AND ofo.activity_type = 'TEST' " + "   AND ofo.well_completion_s =  " + v_wcs + " " + "  ORDER BY 3 DESC").FirstOrDefault;
            return dr;
        }
        public string String_Connection_Header(int string_S)
        {
            string hdr;
            hdr = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<string>("SELECT sf.facility_id " + " FROM koc.surface_facility sf, koc.port_connection pc " + " WHERE sf.facility_type = 'HEADER' " + "   AND sf.surface_facility_s = pc.to_surface_facility_s " + "   AND (pc.end_time IS NULL OR pc.end_time > TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1) " + "   AND pc.start_time < TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1 " + "  AND pc.from_downhole_facility_s =" + string_S + " " + "  ORDER BY pc.start_time DESC").FirstOrDefault;
            return hdr;
        }
        public cls_outvaluewithdate Completion_BeanStatus(int v_wcs)
        {
            cls_outvaluewithdate x;
            x = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_outvaluewithdate>("	SELECT start_time outdate, finding_reason outvalue   " + " FROM koc.oil_field_operation " + " 		   WHERE activity_type = 'CHOKE' " + " 		 AND activity_id = 'CHOKE_CHECK' " + " 	 AND well_completion_s =  " + v_wcs + " " + " 		ORDER BY start_time DESC").FirstOrDefault;
            return x;
        }
        public string Completion_LiftingMethod(int v_wcs)
        {
            string x;
            x = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<string>("SELECT  rfs.description  " + "  FROM koc.oil_field_operation ofo,koc.facility_status fs, codes.r_facility_status rfs " + "   WHERE rfs.source_type = 'LIFT_METHOD' " + "   AND rfs.type = fs.status_type " + "   AND fs.start_oil_field_operation_s = ofo.oil_field_operation_s " + "    AND ofo.activity_type = 'LIFT_METHOD_CHANGE' " + "     AND ofo.well_completion_s =  " + v_wcs + " " + "    AND  ofo.start_time = " + "  (SELECT max(ofo.start_time) " + "    FROM koc.oil_field_operation ofo, koc.facility_status fs, codes.r_facility_status rfs " + "    WHERE rfs.source_type = 'LIFT_METHOD' " + "      AND rfs.type = fs.status_type " + "       AND fs.start_oil_field_operation_s = ofo.oil_field_operation_s " + "       AND ofo.activity_type = 'LIFT_METHOD_CHANGE' " + "       AND ofo.well_completion_s =   " + v_wcs + ") ").FirstOrDefault;
            return x;
        }
        public int Completion_Allowed(int v_wcs)
        {
            int x;
            x = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("select liquid_volume  from koc.daily_production_data " + "	where daily_production_hdr_s in  " + "		(select daily_production_hdr_s from koc.daily_production_hdr " + "	   where WELL_COMPLETION_S =   " + v_wcs + " " + "		AND  ACTIVITY_TYPE 	= 'ALLOWED' " + "			AND  MATERIAL_TYPE 	= 'OIL' " + "			AND  FLOW_DIR_TYPE 	= 'PRODUCTION' " + "			AND  STATE_TYPE 	= 'STANDARD' " + "			AND  EXISTENCE_TYPE 	= 'ACTUAL'  ) " + "		and	 start_time in  " + "		(select MAX(start_time) from koc.daily_production_data " + "			where start_time <=   to_date('" + pStart_date + "','DD/mm/YYYY') " + "			  and  daily_production_hdr_s in " + "				(select daily_production_hdr_s from koc.daily_production_hdr " + "	   where WELL_COMPLETION_S =   " + v_wcs + " " + "				AND  ACTIVITY_TYPE 	= 'ALLOWED' " + "				AND  MATERIAL_TYPE 	= 'OIL' " + "				AND  FLOW_DIR_TYPE 	= 'PRODUCTION' " + "				AND  STATE_TYPE 	= 'STANDARD' " + "			AND  EXISTENCE_TYPE 	= 'ACTUAL' )").FirstOrDefault;
            return x;
        }
        public List<cls_portable_vs_dcs_report> Completion_PortablevsDCS(int v_wcs)
        {
            var ls = new List<cls_portable_vs_dcs_report>();
            ls = KocConfig.DhubContext.ExecuteStoreQuery<cls_portable_vs_dcs_report>("SELECT      a.START_TIME AS starttime, a.TEST_RATE DCSLQ, a.WC DCSWC,  GET_WCS_LQ_PORT_ATDATE(a.WELL_COMPLETION_S,to_char(a.start_time,'dd-mm-yyyy')) as PortLQ,GET_WCS_WATER_CUT_PORT_ATDATE(a.WELL_COMPLETION_S,to_char(a.start_time,'dd-mm-yyyy')) as  PortWC,GET_WCS_TOTAL_GOR_ATDATE(a.WELL_COMPLETION_S,to_char(a.start_time,'dd-mm-yyyy')) as TotalGor  " + "  FROM         well_tests_v1 a " + "  WHERE     (a.TEST_TYPE ='DCS' ) AND (a.WELL_COMPLETION_S= nvl( " + v_wcs + ", a.WELL_COMPLETION_S)) " + "       union all " + "  SELECT       b.START_TIME AS starttime ,GET_WCS_LQ_RATE_DCS(b.WELL_COMPLETION_S,to_char(b.start_time,'dd-mm-yyyy')) as DCSLQ,GET_WCS_WATER_CUT_DCS_ATDATE(b.WELL_COMPLETION_S,to_char(b.start_time,'dd-mm-yyyy')) as  DCSWC ,  b.TEST_RATE PortLQ, b.WC PortWC,GET_WCS_TOTAL_GOR_ATDATE(b.WELL_COMPLETION_S,to_char(b.start_time,'dd-mm-yyyy')) as TotalGor " + "  FROM         well_tests_v1 b " + "  WHERE    b.TEST_TYPE in ('PORTABLE GOR MULTIRATE','PORTABLE') AND (b.WELL_COMPLETION_S= nvl( " + v_wcs + " , b.WELL_COMPLETION_S)) and b.gor is not null  " + "  order by starttime desc").ToList;
            return ls;
            // ,Get_WCS_status(a.WELL_COMPLETION_S,to_char(a.start_time,'dd-mm-yyyy')) as pStatus
        }
        // Public Function CompletionsRTPerformace(v_uwi As String, TAG_DESC As String) As List(Of cls_opc_unit_tag)
        // Dim y As New List(Of cls_opc_unit_tag)
        // 'y = KocConfig.DhubContext.ExecuteStoreQuery(Of cls_opc_unit_tag)("select * from RT_VIEW where WELL_NAME='" & v_uwi & "' and tag_name='" & TAG_DESC & "' order by ACQUISITION_DATE desc").ToList
        // y = KocConfig.RTContext.ExecuteStoreQuery(Of cls_opc_unit_tag)("SELECT   * FROM  realtime.RT_view WHERE (acquisition_date BETWEEN   TRUNC(sysdate) - 60 AND TRUNC(sysdate))   AND WELL_NAME = '" & v_uwi & "'").ToList

        // Return y
        // End Function
        #endregion
        #endregion
        #region GC Report Fetch Routine
        // cls_gc_allocation_report
        // cls_ots_dm_al_stopstart_events
        public List<cls_ProductionPerLF> GetGCProductionPerLF(string pGC)
        {
            return KocConfig.DhubContext.ExecuteStoreQuery<cls_ProductionPerLF>("Select  sum(round(a.LIQUID_RATE * (1 - a.LATEST_WC / 100),0)) as  BOPD,sum(round(a.ALLOWABLE -round(a.LIQUID_RATE),0)) as Potential, sum(round(a.LIQUID_RATE * (a.LATEST_WC / 100),0)) as BWPD,decode(LF_DESCR,'NATURALLY_FLOWING','NF',LF_DESCR) LF,status_type status,reservoir_id    from well_latest_Data a  where current_hc ='" + pGC + "'   group by decode(LF_DESCR,'NATURALLY_FLOWING','NF',LF_DESCR) ,status_type ,reservoir_id").ToList;
        }
        public List<cls_ProductionPerLF> GetGCProductionPerLF(string pGC, string resid)
        {
            return KocConfig.DhubContext.ExecuteStoreQuery<cls_ProductionPerLF>("Select  sum(round(a.LIQUID_RATE * (1 - a.LATEST_WC / 100),0)) as  BOPD,sum(round(a.ALLOWABLE -round(a.LIQUID_RATE),0)) as Potential, sum(round(a.LIQUID_RATE * (a.LATEST_WC / 100),0)) as BWPD,decode(LF_DESCR,'NATURALLY_FLOWING','NF',LF_DESCR) LF,status_type status,reservoir_id    from well_latest_Data a  where current_hc ='" + pGC + "'    and reservoir_id='" + resid + "'  group by decode(LF_DESCR,'NATURALLY_FLOWING','NF',LF_DESCR) ,status_type ,reservoir_id").ToList;
        }
        public List<cls_ots_dm_al_stopstart_events> GetOTSALMSEventsdataForField(string pFieldid)
        {
            var ls = new List<cls_ots_dm_al_stopstart_events>();
            ls = KocConfig.OTSContext.ExecuteStoreQuery<cls_ots_dm_al_stopstart_events>("Select distinct uwi,  datetime start_time , stopstart, remarks ,wstring  from OTS_DM_al_stopstart_events where uwi like '%" + pFieldid + "%'  order by 2").ToList;
            // WellLatestDataList.Where(Function(o) o.UWI = pUWI).FirstOrDefault.rep_survillance_ALMS_StartStopreport = ls
            return ls;
        }
        public List<cls_survillanceclassreport> GetOTSALMSEventsdataForGC(string pGC)
        {
            var ls = new List<cls_survillanceclassreport>();
            ls = KocConfig.OTSContext.ExecuteStoreQuery<cls_survillanceclassreport>("Select  distinct a.well WellName,  a.service_status , a.contractor, a.service_status_date , a.main_job_type , a.service_remarks ,  b.datetime ALM_start_time , b.stopstart, b.remarks ALM_remarks   from OTS_DM_ACTIVITIES_HISTORY a,OTS_DM_al_stopstart_events b where a.well=b.uwi and a.gc like '" + pGC + "'  order by service_status_date").ToList;
            GetGC(pGC).rep_survillance_report = ls;
            return ls;
        }
        public List<ddptrain_daily_report> GetDDP_Train_forGc(string pGC, string fromdate, string todate)
        {
            var ls = new List<ddptrain_daily_report>();
            ls = KocConfig.DhubContext.ExecuteStoreQuery<ddptrain_daily_report>(" select * from ddptrain_daily_report where   issue_dt between to_date('" + fromdate + "','dd/mm/yyyy')  to to_date('" + todate + "','dd/mm/yyyy') and gcid='" + pGC + "'").ToList;
            GetGC(pGC).rep_ddptrain_daily_report = ls;
            return ls;
        }
        public List<cru_daily_report> GetCRU_forGc(string pGC, string fromdate, string todate)
        {
            var ls = new List<cru_daily_report>();
            ls = KocConfig.DhubContext.ExecuteStoreQuery<cru_daily_report>(" select * from cru_daily_report where   issue_dt between to_date('" + fromdate + "','dd/mm/yyyy')  to to_date('" + todate + "','dd/mm/yyyy') and gcid='" + pGC + "'").ToList;

            GetGC(pGC).rep_cru_daily_report = ls;
            return ls;
        }
        public List<ddpheater_daily_report> GetDDP_heater_forGc(string pGC, string fromdate, string todate)
        {
            var ls = new List<ddpheater_daily_report>();
            ls = KocConfig.DhubContext.ExecuteStoreQuery<ddpheater_daily_report>(" select * from ddpheater_daily_report where   issue_dt between to_date('" + fromdate + "','dd/mm/yyyy')  to to_date('" + todate + "','dd/mm/yyyy') and gcid='" + pGC + "'").ToList;

            GetGC(pGC).rep_ddpheater_daily_report = ls;
            return ls;
        }
        public List<gc_daily_report> Get_dailyreport_forGc(string pGC, string fromdate, string todate)
        {
            var ls = new List<gc_daily_report>();
            ls = KocConfig.DhubContext.ExecuteStoreQuery<gc_daily_report>(" select * from gc_daily_report where  issue_dt between to_date('" + fromdate + "','dd/mm/yyyy')  to to_date('" + todate + "','dd/mm/yyyy') and gcid='" + pGC + "'").ToList;

            GetGC(pGC).rep_gc_daily_report = ls;
            return ls;
        }
        public List<cls_gc_allocation_report> CreateWellDataMonthlyReportFromSnapShotv1(string pGC, int MM, int year)
        {
            var ls = new List<cls_gc_allocation_report>();
            ls = KocConfig.DhubContext.ExecuteStoreQuery<cls_gc_allocation_report>(" select * from well_latest_runninghours where  mon=" + MM + " and  yr=" + year + " and gcid='" + pGC + "'").ToList;

            GetGC(pGC).rep_allocation_report.AddRange(ls);
            return ls;
        }
        public List<cls_Well_Data_monthly_report> CreateWellDataMonthlyReportFromSnapShot(string pGC, int MM, int year)
        {
            var ls = new List<cls_Well_Data_monthly_report>();
            pStart_date = "01" + "/" + MM.ToString() + "/" + year.ToString();
            pEnd_date = "01" + "/" + Conversions.ToDate(pStart_date).AddMonths(1).Month + "/" + Conversions.ToDate(pStart_date).AddMonths(1).Year; // CDate(pStart_date).AddMonths(1)
            ls = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_Well_Data_monthly_report>(" select * from finderweb.well_data_report_po_gc where to_date(to_char(status_date,'dd/mm/yyyy'),'dd/mm/yyyy')=to_date('" + pEnd_date + "','dd/mm/yyyy') and gc_id='" + pGC + "'").ToList;
            foreach (cls_Well_Data_monthly_report x in ls)
            {
                x.mm = MM;
                x.yyyy = year;

            }
            bool ext = GetGC(pGC).rep_Well_Data_monthly_report.Exists(x => x.mm == MM & x.yyyy == year);
            if (ext & this.GetGC(pGC).RefershFlag_rep_Well_Data_monthly_report)
            {
                // ---------------- Replace Data
                // ---------------- Replace Data
                GetGC(pGC).rep_Well_Data_monthly_report.RemoveAll(x => x.mm == MM & x.yyyy == year);

                // ----------------------------
                // ----------------------------

            }
            GetGC(pGC).rep_Well_Data_monthly_report.AddRange(ls);
            return ls;
        }
        // Public Function CreateWellDataMonthlyReport(pGC As String, MM As Integer, year As Integer) As List(Of cls_Well_Data_monthly_report)
        // Dim ls As New List(Of cls_well_data_monthly_report_connected_wells)
        // Dim monthlyprod_wells As New List(Of cls_Well_Data_monthly_report)
        // Dim wells As New List(Of cls_Well_Data_monthly_report)
        // pStart_date = "01" & "/" & MM.ToString & "/" & year.ToString


        // If (MM <> Now.Month) Or (year <> Now.Year) Then
        // pEnd_date = CDate(pStart_date).AddMonths(1).AddDays(-1)
        // Else
        // pEnd_date = Now.Date
        // End If
        // wells = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery(Of cls_Well_Data_monthly_report)("SELECT DISTINCT  a.reservoir,a.well_completion_s, a.uwi, a.facility_type  " &
        // " FROM KOC.koc_gc_well a, KOC.well_completion b" &
        // "      WHERE(wc_end_time Is NULL Or wc_end_time > TO_DATE('" & pStart_date & "', 'dd-mm-yyyy'))" &
        // " AND a.well_completion_s = b.well_completion_s " &
        // " AND a.surface_facility_s = (SELECT surface_facility_s FROM KOC.surface_facility" &
        // "                           WHERE facility_type = 'GATHERING CENTER' " &
        // "                           AND facility_id = UPPER('" & pGC & "')) " &
        // " AND a.start_time < TO_DATE('" & pEnd_date & "', 'dd-mm-yyyy')" &
        // " AND (a.end_time >=  TO_DATE('" & pStart_date & "', 'dd-mm-yyyy') OR a.end_time IS NULL)" &
        // "  ORDER BY a.uwi").ToList
        // For Each comp As cls_Well_Data_monthly_report In wells

        // comp.mfl = GetMFL(comp.well_completion_s)
        // comp.mm = MM
        // comp.yyyy = year


        // Try
        // Try
        // Dim st As List(Of StatusCls) = GetStatusatDate(comp.well_completion_s, pStart_date)
        // comp.status = st(0).status_type
        // comp.status_date = st(0).start_time
        // Catch ex As Exception
        // comp.status = "OPEN"

        // End Try
        // Dim outcls As New cls_outvaluewithdate
        // Try
        // comp.slot_id = Completion_Connection_slot_ForMonth(comp.well_completion_s, MM, year)
        // Catch ex As Exception

        // End Try
        // Try
        // comp.header_id = Completion_Header_ForMonth(comp.well_completion_s, MM, year)
        // Catch ex As Exception

        // End Try

        // '-------------------------------------------------------------------------------------------------------
        // '-------------------------Get Status
        // Dim op As New cls_Comp_oper_status
        // op = Completion_status_ForMonth(comp.well_completion_s, MM, year)
        // If IsNothing(op) = False Then
        // comp.status = op.status_type
        // comp.status_date = op.start_time
        // End If
        // '-------------------------Get Whp
        // Dim whpflp As New cls_whp_flp_date
        // whpflp = Completion_Whp_Flp_ForMonth(comp.well_completion_s, MM, year)
        // If IsNothing(whpflp) = False Then
        // comp.whp = whpflp.whp
        // comp.flp = whpflp.flp

        // End If
        // '-------------------------------------------------------------------------------------------------------
        // '-------------------------Get Choke
        // Dim chk_left As New cls_outvaluewithdate
        // Dim chk_right As New cls_outvaluewithdate
        // Dim chkleft As String = ""
        // Dim chkright As String = ""
        // Dim chkleft_date As Date = "01/01/1900"
        // Dim chkright_date As Date = "01/01/1900"
        // chk_left = Completion_Choke_left_ForMonth(comp.well_completion_s, MM, year)
        // chk_right = Completion_Choke_Right_ForMonth(comp.well_completion_s, MM, year)
        // If IsNothing(chk_left) = False Then
        // chkleft = chk_left.outvalue
        // chkleft_date = chk_left.outdate
        // End If
        // If IsNothing(chk_right) = False Then
        // chkright = chk_right.outvalue
        // chkright_date = chk_right.outdate
        // End If

        // If chkleft_date < chkright_date Then 'left is closed
        // If (comp.facility_type = "TUBING LONG") Or (comp.facility_type = "TUBING SHORT") Then
        // comp.choke = chkright
        // Else
        // comp.choke = "(" & chkleft & ")-" & chkright
        // End If
        // ElseIf chkleft_date > chkright_date Then '--right is closed
        // If (comp.facility_type = "TUBING LONG") Or (comp.facility_type = "TUBING SHORT") Then
        // comp.choke = chk_left.outvalue
        // Else
        // comp.choke = "(" & chkleft & ")-" & chkright
        // End If
        // Else '--both are open or no data if start_time = 1-Jan-1901
        // If chkleft_date > CDate("01/01/1900") Then
        // comp.choke = chkleft & "-" & chkright
        // Else
        // comp.choke = ""
        // End If
        // End If
        // '-------------------------------------------------------------------------------------------------------
        // '-------------------------------------------------------------------------------------------------------
        // '-------------------------Get LQ
        // Dim lq As cls_outvaluewithdate
        // lq = Completion_LiquidRate_ForMonth(comp.well_completion_s, MM, year)
        // If IsNothing(lq) = False Then
        // If comp.status = "OPEN" Then
        // comp.production = lq.outvalue

        // Else
        // comp.production = "(" & lq.outvalue & ")"
        // End If
        // End If
        // '-------------------------------------------------------------------------------------------------------
        // '-------------------------Get Watercut
        // Dim wc As cls_outvaluewithdate
        // wc = Completion_WaterCut_ForMonth(comp.well_completion_s, MM, year)
        // If IsNothing(wc) = False Then
        // comp.wc = wc.outvalue
        // comp.wc_date = wc.outdate
        // End If
        // '-------------------------------------------------------------------------------------------------------
        // '-------------------------Get Salt
        // Dim salt As cls_outvaluewithdate
        // salt = Completion_Concentration_Fluids_ForMonth(comp.well_completion_s, "SALT", MM, year)
        // If IsNothing(salt) = False Then
        // comp.salt = salt.outvalue

        // End If
        // '-------------------------------------------------------------------------------------------------------
        // '-------------------------Get GOR
        // Dim GOR As cls_outvaluewithdate
        // GOR = Completion_GOR_ForMonth(comp.well_completion_s, MM, year)
        // If IsNothing(GOR) = False Then
        // comp.gor = GOR.outvalue
        // comp.gor_date = GOR.outdate

        // End If
        // '-------------------------------------------------------------------------------------------------------
        // '-------------------------Get Bean status
        // Dim Bean As cls_outvaluewithdate
        // Bean = Completion_BeanStatus_ForMonth(comp.well_completion_s, MM, year)
        // If IsNothing(Bean) = False Then
        // comp.choke_bean_status = Bean.outvalue
        // comp.choke_bean_date = Bean.outdate

        // End If
        // '-------------------------------------------------------------------------------------------------------
        // '-------------------------Get Lifting Method  status
        // Dim lm As String = ""
        // lm = Completion_LiftingMethod(comp.well_completion_s)
        // comp.LIFT_METHOD = lm
        // '-------------------------------------------------------------------------------------------------------
        // '-------------------------Get Allowed  
        // Dim allowd As Integer = ""
        // allowd = Completion_Allowed_ForMonth(comp.well_completion_s, MM, year)
        // comp.allowed = allowd
        // Catch ex As Exception

        // End Try
        // '  monthlyprod_wells.Add(comp)
        // Next
        // '------------------------ Get Completion on GC for Period --------------------------

        // GetGC(pGC).rep_ProductionPeriods.Clear()
        // For Each comp As cls_Well_Data_monthly_report In wells
        // ls = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery(Of cls_well_data_monthly_report_connected_wells)("SELECT DISTINCT a.well_completion_s, a.uwi, a.facility_type, a.reservoir, a.start_time, a.end_time, a.gc, b.facility_name,a.SURFACE_FACILITY_S,a.port_connection_S,a.string_s " &
        // " FROM KOC.koc_gc_well a, KOC.well_completion b" &
        // "      WHERE(wc_end_time Is NULL Or wc_end_time > TO_DATE('" & pStart_date & "', 'dd-mm-yyyy'))" &
        // " AND a.well_completion_s = b.well_completion_s " &
        // " AND a.well_completion_s=" & comp.well_completion_s &
        // " AND a.surface_facility_s = (SELECT surface_facility_s FROM KOC.surface_facility" &
        // "                           WHERE facility_type = 'GATHERING CENTER' " &
        // "                           AND facility_id = UPPER('" & pGC & "')) " &
        // " AND a.start_time < TO_DATE('" & pEnd_date & "', 'dd-mm-yyyy')" &
        // " AND (a.end_time >=  TO_DATE('" & pStart_date & "', 'dd-mm-yyyy') OR a.end_time IS NULL)" &
        // "  ORDER BY a.uwi").ToList
        // Dim prodhist As New ProductionFacility
        // prodhist.CurConnection = KocConfig.Finderconn
        // prodhist.wcs = comp.well_completion_s
        // prodhist.uwi = comp.uwi


        // prodhist.reservoir = comp.reservoir
        // prodhist.facility_type = comp.facility_type

        // For Each prodperiod As cls_well_data_monthly_report_connected_wells In ls
        // Dim r1 As New ProductionPeriodData
        // If prodperiod.start_time < pStart_date Then
        // r1.StartDate = pStart_date
        // Else
        // r1.StartDate = CDate(prodperiod.start_time)
        // End If
        // If IsNothing(prodperiod.end_time) Then
        // r1.EndDate = pEnd_date
        // Else
        // If prodperiod.end_time > pEnd_date Then
        // r1.EndDate = pEnd_date
        // Else
        // r1.EndDate = CDate(prodperiod.end_time)
        // End If

        // End If


        // Dim outcls As New cls_outvaluewithdate
        // Try
        // r1.header_id = String_Connection_Header_FormTo(prodperiod.string_s, r1.StartDate, r1.EndDate)

        // Catch ex As Exception

        // End Try
        // Try
        // r1.slot_id = Completion_Connection_slot_FromTo(prodperiod.well_completion_s, r1.StartDate, r1.EndDate)

        // Catch ex As Exception

        // End Try

        // prodhist.ProductionPeriods.Add(r1)
        // Next
        // prodhist.StartDate = CDate(pStart_date)

        // prodhist.EndDate = CDate(pEnd_date)
        // prodhist.InitTotalHours()
        // prodhist.CalcProduction()

        // comp.ProductionHistory = prodhist.ProductionHistory

        // Try
        // comp.d1 = prodhist.PeriodHistory(1).RunningHrs
        // comp.d2 = prodhist.PeriodHistory(2).RunningHrs
        // comp.d3 = prodhist.PeriodHistory(3).RunningHrs
        // comp.d4 = prodhist.PeriodHistory(4).RunningHrs
        // comp.d5 = prodhist.PeriodHistory(5).RunningHrs
        // comp.d6 = prodhist.PeriodHistory(6).RunningHrs
        // comp.d7 = prodhist.PeriodHistory(7).RunningHrs
        // comp.d8 = prodhist.PeriodHistory(8).RunningHrs
        // comp.d9 = prodhist.PeriodHistory(9).RunningHrs
        // comp.d10 = prodhist.PeriodHistory(10).RunningHrs
        // comp.d11 = prodhist.PeriodHistory(11).RunningHrs
        // comp.d12 = prodhist.PeriodHistory(12).RunningHrs
        // comp.d13 = prodhist.PeriodHistory(13).RunningHrs
        // comp.d14 = prodhist.PeriodHistory(14).RunningHrs

        // comp.d15 = prodhist.PeriodHistory(15).RunningHrs
        // comp.d16 = prodhist.PeriodHistory(16).RunningHrs
        // comp.d17 = prodhist.PeriodHistory(17).RunningHrs
        // comp.d18 = prodhist.PeriodHistory(18).RunningHrs
        // comp.d19 = prodhist.PeriodHistory(19).RunningHrs
        // comp.d20 = prodhist.PeriodHistory(20).RunningHrs
        // comp.d21 = prodhist.PeriodHistory(21).RunningHrs
        // comp.d22 = prodhist.PeriodHistory(22).RunningHrs
        // comp.d23 = prodhist.PeriodHistory(23).RunningHrs
        // comp.d24 = prodhist.PeriodHistory(24).RunningHrs
        // comp.d25 = prodhist.PeriodHistory(25).RunningHrs
        // comp.d26 = prodhist.PeriodHistory(26).RunningHrs
        // comp.d27 = prodhist.PeriodHistory(27).RunningHrs
        // comp.d28 = prodhist.PeriodHistory(28).RunningHrs
        // comp.d29 = prodhist.PeriodHistory(29).RunningHrs
        // comp.d30 = prodhist.PeriodHistory(30).RunningHrs
        // comp.d31 = prodhist.PeriodHistory(31).RunningHrs
        // Catch ex As Exception

        // End Try
        // ' End If
        // GetGC(pGC).rep_ProductionPeriods.AddRange(prodhist.ProductionPeriods)
        // Next

        // Dim ext As Boolean = GetGC(pGC).rep_Well_Data_monthly_report.Exists(Function(x) x.mm = MM And x.yyyy = year)
        // If ext And GetGC(pGC).RefershFlag_rep_Well_Data_monthly_report Then
        // '---------------- Replace Data
        // GetGC(pGC).rep_Well_Data_monthly_report.RemoveAll(Function(x) x.mm = MM And x.yyyy = year)

        // '----------------------------

        // End If
        // GetGC(pGC).rep_Well_Data_monthly_report.AddRange(wells)


        // Return wells
        // End Function
        // Public Function CreateBackAllocationReport(pGC As String, MM As Integer, year As Integer) As List(Of cls_Well_Data_monthly_report)
        // Dim ls As New List(Of cls_well_data_monthly_report_connected_wells)
        // Dim monthlyprod_wells As New List(Of cls_Well_Data_monthly_report)
        // Dim wells As New List(Of cls_Well_Data_monthly_report)
        // pStart_date = "01" & "/" & MM.ToString & "/" & year.ToString


        // If (MM <> Now.Month) Or (year <> Now.Year) Then
        // pEnd_date = CDate(pStart_date).AddMonths(1).AddDays(-1)
        // Else
        // pEnd_date = Now.Date.AddDays(-1)
        // End If
        // wells = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery(Of cls_Well_Data_monthly_report)("SELECT DISTINCT  a.reservoir,a.well_completion_s, a.uwi, a.facility_type  " &
        // " FROM KOC.koc_gc_well a, KOC.well_completion b" &
        // "      WHERE(wc_end_time Is NULL Or wc_end_time > TO_DATE('" & pStart_date & "', 'dd-mm-yyyy'))" &
        // " AND a.well_completion_s = b.well_completion_s " &
        // " AND a.surface_facility_s = (SELECT surface_facility_s FROM KOC.surface_facility" &
        // "                           WHERE facility_type = 'GATHERING CENTER' " &
        // "                           AND facility_id = UPPER('" & pGC & "')) " &
        // " AND a.start_time < TO_DATE('" & pEnd_date & "', 'dd-mm-yyyy')" &
        // " AND (a.end_time >=  TO_DATE('" & pStart_date & "', 'dd-mm-yyyy') OR a.end_time IS NULL) " &
        // "  ORDER BY a.uwi").ToList

        // '------------------------ Get Completion on GC for Period --------------------------
        // For u = 0 To CDate(pEnd_date).Day - 1

        // Dim x1 As cls_lastProductiondatareport
        // x1 = GetProductionGCdata(pGC, CDate(pStart_date).AddDays(u))
        // Dim p As New GCProductionData
        // If IsNothing(x1) = False Then

        // p.OilProduction = x1.OilProduction 'mynightfigure.hdr.NIGHT_FIGURES_PROD_STOCK.FirstOrDefault.L_GROSS_PRODUCTION.Value + IIf(mynightfigure.hdr.NIGHT_FIGURES_PROD_STOCK.FirstOrDefault.M_GROSS_PRODUCTION.HasValue, 0, mynightfigure.hdr.NIGHT_FIGURES_PROD_STOCK.FirstOrDefault.M_GROSS_PRODUCTION)
        // p.WaterProduction = x1.EffWaterProduction 'mynightfigure.hdr.NIGHT_FIGURE_DDP(0).DDP_L_SEP_WATER + mynightfigure.hdr.NIGHT_FIGURE_DDP(0).DDP_M_SEP_WATER

        // End If
        // p.pYear = year
        // p.pMonth = MM
        // p.pDay = u + 1
        // GetGC(pGC).rep_ProductionBA.Add(p)

        // Next
        // '-----------------------------------------------------------------------------------------
        // GetGC(pGC).rep_ProductionPeriods.Clear()

        // For Each comp As cls_Well_Data_monthly_report In wells
        // comp.mfl = GetMFL(comp.well_completion_s)
        // comp.mm = MM
        // comp.yyyy = year
        // ls = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery(Of cls_well_data_monthly_report_connected_wells)("SELECT DISTINCT a.well_completion_s, a.uwi, a.facility_type, a.reservoir, a.start_time, a.end_time, a.gc, b.facility_name,a.SURFACE_FACILITY_S,a.port_connection_S,a.string_s " &
        // " FROM KOC.koc_gc_well a, KOC.well_completion b" &
        // "      WHERE(wc_end_time Is NULL Or wc_end_time > TO_DATE('" & pStart_date & "', 'dd-mm-yyyy'))" &
        // " AND a.well_completion_s = b.well_completion_s " &
        // " AND a.well_completion_s=" & comp.well_completion_s &
        // " AND a.surface_facility_s = (SELECT surface_facility_s FROM KOC.surface_facility" &
        // "                           WHERE facility_type = 'GATHERING CENTER' " &
        // "                           AND facility_id = UPPER('" & pGC & "')) " &
        // " AND a.start_time < TO_DATE('" & pEnd_date & "', 'dd-mm-yyyy')" &
        // " AND (a.end_time >=  TO_DATE('" & pStart_date & "', 'dd-mm-yyyy') OR a.end_time IS NULL)" &
        // "  ORDER BY a.uwi").ToList
        // Dim prodhist As New ProductionFacility
        // prodhist.CurConnection = KocConfig.Finderconn
        // prodhist.wcs = comp.well_completion_s
        // prodhist.uwi = comp.uwi

        // prodhist.reservoir = comp.reservoir
        // prodhist.facility_type = comp.facility_type

        // For Each prodperiod As cls_well_data_monthly_report_connected_wells In ls
        // Dim r1 As New ProductionPeriodData
        // If prodperiod.start_time < pStart_date Then
        // r1.StartDate = pStart_date
        // Else
        // r1.StartDate = CDate(prodperiod.start_time)
        // End If
        // If IsNothing(prodperiod.end_time) Then
        // r1.EndDate = pEnd_date
        // Else
        // If prodperiod.end_time > pEnd_date Then
        // r1.EndDate = pEnd_date
        // Else
        // r1.EndDate = CDate(prodperiod.end_time)
        // End If

        // End If


        // Dim outcls As New cls_outvaluewithdate
        // Try
        // r1.header_id = String_Connection_Header_FormTo(prodperiod.string_s, r1.StartDate, r1.EndDate)

        // Catch ex As Exception

        // End Try
        // Try
        // r1.slot_id = Completion_Connection_slot_FromTo(prodperiod.well_completion_s, r1.StartDate, r1.EndDate)

        // Catch ex As Exception

        // End Try

        // prodhist.ProductionPeriods.Add(r1)
        // Next
        // prodhist.StartDate = CDate(pStart_date)
        // prodhist.EndDate = CDate(pEnd_date)
        // prodhist.InitTotalHours()
        // prodhist.CalcProduction()

        // comp.ProductionHistory = prodhist.ProductionHistory

        // Try
        // comp.d1 = prodhist.PeriodHistory(1).RunningHrs
        // comp.d2 = prodhist.PeriodHistory(2).RunningHrs
        // comp.d3 = prodhist.PeriodHistory(3).RunningHrs
        // comp.d4 = prodhist.PeriodHistory(4).RunningHrs
        // comp.d5 = prodhist.PeriodHistory(5).RunningHrs
        // comp.d6 = prodhist.PeriodHistory(6).RunningHrs
        // comp.d7 = prodhist.PeriodHistory(7).RunningHrs
        // comp.d8 = prodhist.PeriodHistory(8).RunningHrs
        // comp.d9 = prodhist.PeriodHistory(9).RunningHrs
        // comp.d10 = prodhist.PeriodHistory(10).RunningHrs
        // comp.d11 = prodhist.PeriodHistory(11).RunningHrs
        // comp.d12 = prodhist.PeriodHistory(12).RunningHrs
        // comp.d13 = prodhist.PeriodHistory(13).RunningHrs
        // comp.d14 = prodhist.PeriodHistory(14).RunningHrs

        // comp.d15 = prodhist.PeriodHistory(15).RunningHrs
        // comp.d16 = prodhist.PeriodHistory(16).RunningHrs
        // comp.d17 = prodhist.PeriodHistory(17).RunningHrs
        // comp.d18 = prodhist.PeriodHistory(18).RunningHrs
        // comp.d19 = prodhist.PeriodHistory(19).RunningHrs
        // comp.d20 = prodhist.PeriodHistory(20).RunningHrs
        // comp.d21 = prodhist.PeriodHistory(21).RunningHrs
        // comp.d22 = prodhist.PeriodHistory(22).RunningHrs
        // comp.d23 = prodhist.PeriodHistory(23).RunningHrs
        // comp.d24 = prodhist.PeriodHistory(24).RunningHrs
        // comp.d25 = prodhist.PeriodHistory(25).RunningHrs
        // comp.d26 = prodhist.PeriodHistory(26).RunningHrs
        // comp.d27 = prodhist.PeriodHistory(27).RunningHrs
        // comp.d28 = prodhist.PeriodHistory(28).RunningHrs
        // comp.d29 = prodhist.PeriodHistory(29).RunningHrs
        // comp.d30 = prodhist.PeriodHistory(30).RunningHrs
        // comp.d31 = prodhist.PeriodHistory(31).RunningHrs
        // Catch ex As Exception

        // End Try
        // ' End If

        // GetGC(pGC).rep_ProductionPeriods.AddRange(prodhist.ProductionPeriods)
        // Next

        // Dim ext As Boolean = GetGC(pGC).rep_Well_Data_monthly_report.Exists(Function(x) x.mm = MM And x.yyyy = year)
        // If ext And GetGC(pGC).RefershFlag_rep_Well_Data_monthly_report Then
        // '---------------- Replace Data
        // GetGC(pGC).rep_Well_Data_monthly_report.RemoveAll(Function(x) x.mm = MM And x.yyyy = year)

        // '----------------------------

        // End If
        // GetGC(pGC).rep_Well_Data_monthly_report.AddRange(wells)
        // '----------------------------------------------------------------
        // '------------------- Get GC Production Data ---------------------

        // For Each w As cls_Well_Data_monthly_report In wells
        // For Each H In w.ProductionHistory
        // Dim m As Integer = H.Monthofyear
        // Dim d As Integer = H.DayoftheMonth
        // Dim yr As Integer = H.Year
        // Dim tr As GCProductionData = GetGC(pGC).rep_ProductionBA.Where(Function(o) o.pDay = d And o.pMonth = m And o.pYear = yr).FirstOrDefault
        // tr.WellsProduction.Add(H)
        // tr.BA_OilProduction += H.Oil
        // tr.BA_WaterProduction += H.Water
        // tr.BA_GasProduction += H.Gas
        // tr.GasProductionDiff = tr.BA_GasProduction - tr.GasProduction
        // tr.WaterProductionDiff = tr.BA_WaterProduction - tr.WaterProduction
        // tr.OilProductionDiff = tr.BA_OilProduction - tr.OilProduction
        // For Each pr In GetGC(pGC).rep_ProductionPeriods

        // Next


        // Next
        // Next

        // Return wells
        // End Function
        // '  Public Function CreateBackAllocationReportByFromToData(ByRef comp As cls_Well_Data_monthly_report, pWCS As Integer, pstartdate As Date, penddate As Date) As List(Of ProductionPeriodData)
        // '  Dim ls As New List(Of cls_well_data_monthly_report_connected_wells)
        // Dim monthlyprod_wells As New List(Of ProductionPeriodData)
        // '    Dim wells As New List(Of cls_Well_Data_monthly_report)
        // pStart_date = pstartdate.Day & "-" & pstartdate.Month & "-" & pstartdate.Year
        // pEnd_date = penddate.Day & "-" & penddate.Month & "-" & penddate.Year

        // '      wells = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery(Of cls_Well_Data_monthly_report)("SELECT DISTINCT  a.gc,a.reservoir,a.well_completion_s, a.uwi, a.facility_type,a.start_time startdate,nvl(a.end_time,sysdate) enddate,a.string_s  " & _
        // ' " FROM KOC.koc_gc_well a, KOC.well_completion b" & _
        // ' "      WHERE (wc_end_time Is NULL Or wc_end_time > TO_DATE('" & pStart_date & "', 'dd-mm-yyyy'))" & _
        // '  " AND a.well_completion_s = b.well_completion_s " & _
        // '  " AND a.start_time >= TO_DATE('" & pStart_date & "', 'dd-mm-yyyy')" & _
        // '  " AND (a.end_time <=  TO_DATE('" & pEnd_date & "', 'dd-mm-yyyy') OR a.end_time IS NULL) and b.well_completion_s=" & pWCS & _
        // '"  ORDER BY a.uwi").ToList


        // ' For Each comp As cls_Well_Data_monthly_report In wells
        // comp.mfl = GetMFL(comp.well_completion_s)
        // comp.StartDate = comp.StartDate
        // comp.EndDate = comp.EndDate

        // Dim prodhist As New ProductionFacility
        // prodhist.CurConnection = KocConfig.Finderconn
        // prodhist.wcs = comp.well_completion_s
        // prodhist.uwi = comp.uwi
        // prodhist.GC = comp.gc

        // prodhist.reservoir = comp.reservoir
        // prodhist.facility_type = comp.facility_type

        // Dim r1 As New ProductionPeriodData

        // r1.StartDate = comp.StartDate
        // r1.EndDate = comp.EndDate
        // Dim outcls As New cls_outvaluewithdate
        // Try
        // r1.header_id = String_Connection_Header_FormTo(comp.String_s, r1.StartDate, r1.EndDate)

        // Catch ex As Exception

        // End Try
        // Try
        // r1.slot_id = Completion_Connection_slot_FromTo(comp.well_completion_s, r1.StartDate, r1.EndDate)

        // Catch ex As Exception

        // End Try



        // r1.GC = comp.gc
        // prodhist.ProductionPeriods.Add(r1)
        // prodhist.StartDate = comp.StartDate
        // prodhist.EndDate = comp.EndDate
        // prodhist.InitTotalHours()
        // prodhist.CalcProduction()


        // ' End If

        // monthlyprod_wells.AddRange(prodhist.ProductionPeriods)
        // '  Next



        // Return monthlyprod_wells
        // End Function
        // Public Function CreateWELLBackAllocationReport(pWCS As Integer, pstartdate As String, penddate As String) As List(Of HistoryDailyData)
        // '  Dim ls As New List(Of cls_well_data_monthly_report_connected_wells)
        // Dim monthlyprod_wells As New List(Of ProductionPeriodData)
        // Dim wells As New List(Of cls_Well_Data_monthly_report)
        // Dim ls As New List(Of HistoryDailyData)

        // wells = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery(Of cls_Well_Data_monthly_report)("SELECT DISTINCT   a.gc,a.reservoir,a.well_completion_s, a.uwi, a.facility_type,a.start_time startdate,nvl(a.end_time,sysdate) enddate " &
        // " FROM KOC.koc_gc_well a, KOC.well_completion b" &
        // "      WHERE (wc_end_time Is NULL Or wc_end_time > TO_DATE('" & pstartdate & "', 'dd-mm-yyyy'))" &
        // " AND a.well_completion_s = b.well_completion_s " &
        // " AND (a.end_time <=  TO_DATE('" & penddate & "', 'dd-mm-yyyy') OR a.end_time IS NULL) and b.well_completion_s=" & pWCS &
        // "  ORDER BY a.start_time asc").ToList
        // '" AND a.start_time <= TO_DATE('" & pstartdate & "', 'dd-mm-yyyy')" & _
        // 'AND (a.end_time >=  TO_DATE('" & pstartdate & "', 'dd-mm-yyyy') OR a.end_time IS NULL)
        // For Each o As cls_Well_Data_monthly_report In wells
        // monthlyprod_wells = CreateBackAllocationReportByFromToData(o, o.well_completion_s, o.StartDate, o.EndDate)
        // ls.AddRange(monthlyprod_wells(0).PeriodHistory)
        // Next
        // WellLatestDataList.Where(Function(x) x.WELL_COMPLETION_S = pWCS).FirstOrDefault.Production_history = ls
        // Return ls
        // End Function
        private bool CheckIFDataExist(int mm, int yyyy)
        {
            foreach (cls_Well_Data_monthly_report x in GetGC(GC).rep_Well_Data_monthly_report)
            {
                if (x.mm == mm & x.yyyy == yyyy)
                {
                    return true;
                    return default;
                }
            }
            return false;
        }
        public List<cls_portable_vs_dcs_report> CreateGCPortablevsDCS(string GCID)
        {
            var ls = new List<cls_portable_vs_dcs_report>();
            ls = KocConfig.DhubContext.ExecuteStoreQuery<cls_portable_vs_dcs_report>("SELECT      a.START_TIME AS starttime, a.TEST_RATE DCSLQ, a.WC DCSWC,  GET_WCS_LQ_PORT_ATDATE(a.WELL_COMPLETION_S,to_char(a.start_time,'dd-mm-yyyy')) as PortLQ,GET_WCS_WATER_CUT_PORT_ATDATE(a.WELL_COMPLETION_S,to_char(a.start_time,'dd-mm-yyyy')) as  PortWC,GET_WCS_TOTAL_GOR_ATDATE(a.WELL_COMPLETION_S,to_char(a.start_time,'dd-mm-yyyy')) as TotalGor  " + "  FROM         well_tests_v1 a,well_latest_data c " + "  WHERE     (a.TEST_TYPE ='DCS' ) AND (c.WELL_COMPLETION_S= a.WELL_COMPLETION_S) and (c.current_gc='" + GCID + "')" + "       union all " + "  SELECT       b.START_TIME AS starttime ,GET_WCS_LQ_RATE_DCS(b.WELL_COMPLETION_S,to_char(b.start_time,'dd-mm-yyyy')) as DCSLQ,GET_WCS_WATER_CUT_DCS_ATDATE(b.WELL_COMPLETION_S,to_char(b.start_time,'dd-mm-yyyy')) as  DCSWC ,  b.TEST_RATE PortLQ, b.WC PortWC,GET_WCS_TOTAL_GOR_ATDATE(b.WELL_COMPLETION_S,to_char(b.start_time,'dd-mm-yyyy')) as TotalGor " + "  FROM         well_tests_v1 b ,well_latest_data d" + "  WHERE    b.TEST_TYPE in ('PORTABLE GOR MULTIRATE','PORTABLE') AND (d.WELL_COMPLETION_S= b.WELL_COMPLETION_S) and (d.current_gc='" + GCID + "') and b.gor is not null  " + "  order by starttime desc").ToList;
            return ls;
        }
        public List<cls_incommer_report_staging> CreateIncommerReport(string pGC, string startdate)
        {
            var ls = new List<cls_incommer_report_staging>();
            var gc_slots = new List<cls_gc_slots>();
            var hdr_comps = new List<cls_completion_on_header>();
            pStart_date = startdate;

            // ----------------------------- Get Slot Data
            gc_slots = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_gc_slots>(" SELECT sf.surface_facility_s, sf.facility_id hdr, sf1.facility_id gc,gp.general_port_s " + " FROM " + pSchema + ".surface_facility sf,  " + pSchema + ".facility_composition fc, " + pSchema + ".surface_facility sf1 , " + pSchema + ".general_port gp" + " WHERE gp.facility_type = 'INLET_PORT' " + "   AND gp.surface_facility_s = sf.surface_facility_s " + "    AND sf.facility_type = 'INCOMMER' " + "    AND sf.surface_facility_s = fc.part_surface_facility_s " + "    AND fc.whole_surface_facility_s = sf1.surface_facility_s " + "    AND sf1.facility_id =  UPPER('" + pGC + "') " + "    AND sf1.facility_type = 'GATHERING CENTER' " + "   ORDER BY sf.facility_id").ToList;
            foreach (cls_gc_slots sl in gc_slots)
            {

                hdr_comps = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_completion_on_header>("  SELECT wc.well_completion_s, wc.string_s, wc.uwi, wc.facility_type, wc.facility_name, rs.reservoir_id, pc.start_time, pc.end_time  " + " FROM " + pSchema + ".well_completion wc," + pSchema + ".reservoir rs, " + pSchema + ".port_connection pc," + pSchema + ".general_port gp" + "  WHERE pc.remarks = 'COMPLETION-INCOMMER'" + "  AND (pc.end_time IS NULL OR pc.end_time > TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1)" + "  AND pc.start_time < TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1" + "  AND pc.to_port_s =" + sl.general_port_s + " " + "   AND pc.from_port_s = gp.general_port_s" + " AND gp.downhole_facility_s = wc.string_s" + "  AND (wc.end_time IS NULL OR wc.end_time >= TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1)" + "  AND wc.reservoir_s = rs.reservoir_s " + " ORDER BY wc.uwi, wc.facility_type, rs.reservoir_id").ToList;
                foreach (cls_completion_on_header comp in hdr_comps)
                {
                    var x = new cls_incommer_report_staging();
                    x.well_completion_s = Conversions.ToInteger(comp.well_completion_s);
                    x.uwi = comp.uwi;
                    x.header = String_Connection_Header(comp.string_s);
                    x.facility_name = comp.facility_name;
                    x.facility_type = comp.facility_type;
                    x.reservoir = comp.reservoir_id;
                    x.start_time = comp.start_time;
                    x.end_time = comp.start_time;
                    x.gc = pGC;
                    x.mfl = GetMFL(Conversions.ToInteger(comp.well_completion_s));
                    // -------------------------Get Slot
                    var outcls = new cls_outvaluewithdate();

                    x.slot = String_Connection_Slot(comp.string_s);
                    // -------------------------------------------------------------------------------------------------------
                    // -------------------------Get Status
                    var op = new cls_Comp_oper_status();
                    op = CompletionsOperationalStatus(x.well_completion_s);
                    if (op == null == false)
                    {
                        x.status = op.status_type;
                        x.status_date = Conversions.ToString(op.start_time.Value);
                    }
                    // -------------------------------------------------------------------------------------------------------
                    // -------------------------Get Api
                    // outcls = Completion_Concentration_Fluids(x.well_completion_s, "GAS")
                    // If IsNothing(outcls) = False Then
                    // x.api_gravity = outcls.outvalue
                    // x.api_date = outcls.outdate
                    // End If

                    // -------------------------------------------------------------------------------------------------------
                    // -------------------------Get LQ
                    cls_outvaluewithdate lq;
                    lq = Completion_LiquidRate(x.well_completion_s);
                    if (lq == null == false)
                    {
                        if (x.status == "OPEN")
                        {
                            x.Current_Rate = lq.outvalue;
                        }

                        else
                        {
                            x.close_rate = "(" + lq.outvalue + ")";
                        }
                    }
                    // -------------------------------------------------------------------------------------------------------
                    // -------------------------Get Choke
                    var chk_left = new cls_outvaluewithdate();
                    var chk_right = new cls_outvaluewithdate();
                    string chkleft = "";
                    string chkright = "";
                    DateTime chkleft_date = Conversions.ToDate("01/01/1900");
                    DateTime chkright_date = Conversions.ToDate("01/01/1900");
                    chk_left = Completion_Choke_left(x.well_completion_s);
                    chk_right = Completion_Choke_Right(x.well_completion_s);
                    if (chk_left == null == false)
                    {
                        chkleft = chk_left.outvalue;
                        chkleft_date = Conversions.ToDate(chk_left.outdate);
                    }
                    if (chk_right == null == false)
                    {
                        chkright = chk_right.outvalue;
                        chkright_date = Conversions.ToDate(chk_right.outdate);
                    }

                    if (chkleft_date < chkright_date) // left is closed
                    {
                        if (x.facility_type == "TUBING LONG" | x.facility_type == "TUBING SHORT")
                        {
                            x.choke = chkright;
                        }
                        else
                        {
                            x.choke = "(" + chkleft + ")-" + chkright;
                        }
                    }
                    else if (chkleft_date > chkright_date) // --right is closed
                    {
                        if (x.facility_type == "TUBING LONG" | x.facility_type == "TUBING SHORT")
                        {
                            x.choke = chk_left.outvalue;
                        }
                        else
                        {
                            x.choke = "(" + chkleft + ")-" + chkright;
                        }
                    }
                    else if (chkleft_date > Conversions.ToDate("01/01/1900")) // --both are open or no data if start_time = 1-Jan-1901
                    {
                        x.choke = chkleft + "-" + chkright;
                    }
                    else
                    {
                        x.choke = "";
                    }



                    // -------------------------------------------------------------------------------------------------------

                    // -------------------------Get Salt
                    outcls = Completion_Concentration_Fluids(x.well_completion_s, "SALT");
                    if (outcls == null == false)
                    {

                        x.salt = outcls.outvalue;
                    }

                    // -------------------------------------------------------------------------------------------------------
                    // -------------------------Get H2s
                    // If IsNothing(outcls) = False Then
                    // outcls = Completion_Concentration_Fluids(x.well_completion_s, "H2S")
                    // x.h2s = outcls.outvalue
                    // End If
                    // -------------------------------------------------------------------------------------------------------
                    // -------------------------Get wc
                    outcls = Completion_WaterCut(x.well_completion_s);
                    if (outcls == null == false)
                    {

                        x.wc = outcls.outvalue;
                        x.wc_date = outcls.outdate;
                    }

                    // -------------------------------------------------------------------------------------------------------
                    // -------------------------Get Whp
                    var whpflp = new cls_whp_flp_date();
                    whpflp = Completion_Whp_Flp(x.well_completion_s);
                    if (whpflp == null == false)
                    {
                        x.whp = whpflp.whp;
                        x.flp = whpflp.flp;
                        // x.WHP_FLP_DATE = whpflp.start_time
                    }
                    // -------------------------------------------------------------------------------------------------------
                    ls.Add(x);
                }



            }
            GetGC(pGC).rep_Incommer_SLOT_report = ls;
            return ls;
        }
        public List<cls__header_input_report> CreateHeaderInputReportForKOC(string pGC, string startdate, string enddate)
        {
            var ls = new List<cls__header_input_report>();
            var gc_headers = new List<cls_gc_Headers>();
            var hdr_comps = new List<cls_completion_on_header>();
            pStart_date = startdate;
            pEnd_date = enddate;
            // ----------------------------- Get Header Data
            gc_headers = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_gc_Headers>(" SELECT sf.surface_facility_s, sf.facility_id hdr, sf1.facility_id gc" + " FROM koc.surface_facility sf,  koc.facility_composition fc, koc.surface_facility sf1 " + " WHERE sf.facility_type = 'HEADER'" + " AND sf.surface_facility_s = fc.part_surface_facility_s" + "  AND fc.whole_surface_facility_s = sf1.surface_facility_s" + " AND sf1.facility_id = UPPER('" + pGC + "') " + " AND sf1.facility_type = 'GATHERING CENTER'" + " ORDER BY sf.facility_id").ToList;

            foreach (cls_gc_Headers hd in gc_headers)
            {
                // ------------------------- Get Completions ----------------------------------------------------------------
                hdr_comps = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_completion_on_header>(" SELECT wc.well_completion_s, wc.string_s, wc.uwi, wc.facility_type, wc.facility_name, rs.reservoir_id, pc.start_time, pc.end_time " + " FROM koc.well_completion wc, koc.reservoir rs, koc.port_connection pc " + " wHERE pc.remarks = 'COMPLETION-HEADER' " + " AND (pc.end_time IS NULL OR pc.end_time > TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1) " + " AND pc.start_time < TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1 " + " AND pc.to_surface_facility_s = " + hd.surface_facility_s + " " + " AND pc.from_downhole_facility_s = wc.string_s " + " AND (wc.end_time IS NULL OR wc.end_time >= TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1) " + " AND wc.reservoir_s = rs.reservoir_s " + " ORDER BY wc.uwi, wc.facility_type, rs.reservoir_id").ToList;
                foreach (cls_completion_on_header comp in hdr_comps)
                {

                    var x = new cls__header_input_report();
                    x.well_completion_s = Conversions.ToInteger(comp.well_completion_s);
                    x.uwi = comp.uwi;
                    x.header = hd.hdr;
                    x.facility_name = comp.facility_name;
                    x.facility_type = comp.facility_type;
                    x.reservoir = comp.reservoir_id;
                    x.start_time = comp.start_time;
                    x.end_time = comp.start_time;
                    x.gc = pGC;
                    x.mfl = GetMFL(Conversions.ToInteger(comp.well_completion_s));
                    // -------------------------Get Slot
                    var outcls = new cls_outvaluewithdate();

                    x.slot = String_Connection_Slot(comp.string_s);
                    // -------------------------------------------------------------------------------------------------------
                    // -------------------------Get Status
                    var op = new cls_Comp_oper_status();
                    op = CompletionsOperationalStatus(x.well_completion_s);
                    if (op == null == false)
                    {
                        x.status = op.status_type;
                        x.status_date = Conversions.ToString(op.start_time.Value);
                    }
                    // -------------------------------------------------------------------------------------------------------
                    // -------------------------Get Api
                    outcls = Completion_Concentration_Fluids(x.well_completion_s, "GAS");
                    if (outcls == null == false)
                    {
                        x.api_gravity = outcls.outvalue;
                        x.api_date = outcls.outdate;
                    }

                    // -------------------------------------------------------------------------------------------------------
                    // -------------------------Get LQ
                    cls_outvaluewithdate lq;
                    lq = Completion_LiquidRate(x.well_completion_s);
                    if (lq == null == false)
                    {
                        if (x.status == "OPEN")
                        {
                            x.Current_Rate = lq.outvalue;
                        }

                        else
                        {
                            x.close_rate = "(" + lq.outvalue + ")";
                        }
                    }
                    // -------------------------------------------------------------------------------------------------------
                    // -------------------------Get Choke
                    var chk_left = new cls_outvaluewithdate();
                    var chk_right = new cls_outvaluewithdate();
                    string chkleft = "";
                    string chkright = "";
                    DateTime chkleft_date = Conversions.ToDate("01/01/1900");
                    DateTime chkright_date = Conversions.ToDate("01/01/1900");
                    chk_left = Completion_Choke_left(x.well_completion_s);
                    chk_right = Completion_Choke_Right(x.well_completion_s);
                    if (chk_left == null == false)
                    {
                        chkleft = chk_left.outvalue;
                        chkleft_date = Conversions.ToDate(chk_left.outdate);
                    }
                    if (chk_right == null == false)
                    {
                        chkright = chk_right.outvalue;
                        chkright_date = Conversions.ToDate(chk_right.outdate);
                    }

                    if (chkleft_date < chkright_date) // left is closed
                    {
                        if (x.facility_type == "TUBING LONG" | x.facility_type == "TUBING SHORT")
                        {
                            x.choke = chkright;
                        }
                        else
                        {
                            x.choke = "(" + chkleft + ")-" + chkright;
                        }
                    }
                    else if (chkleft_date > chkright_date) // --right is closed
                    {
                        if (x.facility_type == "TUBING LONG" | x.facility_type == "TUBING SHORT")
                        {
                            x.choke = chk_left.outvalue;
                        }
                        else
                        {
                            x.choke = "(" + chkleft + ")-" + chkright;
                        }
                    }
                    else if (chkleft_date > Conversions.ToDate("01/01/1900")) // --both are open or no data if start_time = 1-Jan-1901
                    {
                        x.choke = chkleft + "-" + chkright;
                    }
                    else
                    {
                        x.choke = "";
                    }



                    // -------------------------------------------------------------------------------------------------------

                    // -------------------------Get Salt
                    outcls = Completion_Concentration_Fluids(x.well_completion_s, "SALT");
                    if (outcls == null == false)
                    {

                        x.salt = outcls.outvalue;
                    }

                    // -------------------------------------------------------------------------------------------------------
                    // -------------------------Get H2s
                    outcls = Completion_Concentration_Fluids(x.well_completion_s, "H2S");
                    if (outcls == null == false)
                    {

                        x.h2s = outcls.outvalue;
                    }
                    // -------------------------------------------------------------------------------------------------------
                    // -------------------------Get wc
                    outcls = Completion_WaterCut(x.well_completion_s);
                    if (outcls == null == false)
                    {

                        x.wc = outcls.outvalue;
                        x.wc_date = outcls.outdate;
                    }

                    // -------------------------------------------------------------------------------------------------------
                    // -------------------------Get Whp
                    var whpflp = new cls_whp_flp_date();
                    whpflp = Completion_Whp_Flp(x.well_completion_s);
                    if (whpflp == null == false)
                    {
                        x.whp = whpflp.whp;
                        x.flp = whpflp.flp;
                        x.WHP_FLP_DATE = whpflp.start_time;
                    }
                    // -------------------------------------------------------------------------------------------------------
                    ls.Add(x);
                }



            }
            GetGC(pGC).rep_HeaderInput_report = ls;
            return ls;
        }
        public List<cls_Well_closeOpen_Report_GC> CreateWellCloseOpenReportonDate(string pGC, string startdate)
        {
            var dr = new List<cls_Well_closeOpen_Report_GC>();

            dr = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_Well_closeOpen_Report_GC>("SELECT kgw.uwi, kgw.facility_type, fs.status_type, ofo.start_time, fs.reason,to_char(sysdate, 'dd-mm-yyyy hh24:mi') today " + " FROM koc.koc_gc_well kgw, koc.oil_field_operation ofo, koc.facility_status fs " + " WHERE fs.start_oil_field_operation_s = ofo.oil_field_operation_s " + " AND ofo.start_time between  TO_DATE('" + startdate + "', 'dd-mm-yyyy')-1  and TO_DATE('" + startdate + "', 'dd-mm-yyyy')  " + " AND kgw.gc = UPPER('" + pGC + "') " + " ORDER BY kgw.uwi, kgw.facility_type").ToList;
            // GetGC(pGC).rep_Well_CloseOpen_Report = dr
            return dr;

        }
        public List<cls_Well_closeOpen_Report_GC> CreateWellCloseOpenReport(string pGC)
        {
            var dr = new List<cls_Well_closeOpen_Report_GC>();

            dr = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_Well_closeOpen_Report_GC>("SELECT kgw.uwi, kgw.facility_type, fs.status_type, ofo.start_time, fs.reason,to_char(sysdate, 'dd-mm-yyyy hh24:mi') today " + " FROM koc.koc_gc_well kgw, koc.oil_field_operation ofo, koc.facility_status fs " + " WHERE fs.start_oil_field_operation_s = ofo.oil_field_operation_s " + " AND ofo.start_time = (SELECT MAX(start_time) FROM koc.oil_field_operation " + " WHERE activity_type = 'FACILITY_STATUS_CHANGE' " + " AND well_completion_s = kgw.well_completion_s) " + " AND ofo.activity_type = 'FACILITY_STATUS_CHANGE' " + " AND ofo.well_completion_s = kgw.well_completion_s " + " AND kgw.wc_end_time IS NULL " + " AND kgw.end_time IS NULL " + " AND kgw.gc = UPPER('" + pGC + "') " + " ORDER BY kgw.uwi, kgw.facility_type").ToList;
            GetGC(pGC).rep_Well_CloseOpen_Report = dr;
            return dr;

        }
        public List<cls_GC_ChokeChange_data> CreateGCChokeChangeReport(string pGC, string startdate, string enddate)
        {
            var ls = new List<cls_GC_ChokeChange_data>();
            pStart_date = startdate;
            pEnd_date = enddate;
            ls = GCChokeChange(pGC, pStart_date, pEnd_date);
            foreach (cls_GC_ChokeChange_data X in ls)
            {
                cls_gc_chokechange_data_2 Y;
                string testdate = "";
                testdate = X.start_time.Day + "-" + X.start_time.Month + "-" + X.start_time.Year;
                X.From_left_choke_size = "";
                X.From_right_choke_size = "";
                Y = CompletionChokeChange_byTestDate(X.well_completion_s, testdate);
                if (Y == null == false)
                {
                    X.From_left_choke_size = Y.left_choke_size;
                    X.From_right_choke_size = Y.right_choke_size;
                }


            }

            GetGC(pGC).rep_ChockChange_report = ls;
            return ls;
        }
        public List<cls_well_test_stats> CreateGCWellTestStatistics(string pGC, string MM, string yyyy)
        {
            var ls = new List<cls_well_test_stats>();
            ls = (List<cls_well_test_stats>)GCTestStatistic(pGC, MM, yyyy);
            GetGC(pGC).rep_WellTest_statistics_report = ls;
            return ls;
        }
        public List<cls_report_well_rerouting> CreateGCWellRerouting(string pGC, string FromDate, string Todate)
        {
            var ls = new List<cls_report_well_rerouting>();
            ls = GCWellRerouting(pGC, FromDate, Todate);
            GetGC(pGC).rep_Well_rerouting_report = ls;
            return ls;
        }
        public List<cls_scale_insp_report> CreateGCScaleInspection(string pGC, string FromDate, string Todate)
        {
            var ls = new List<cls_scale_insp_report>();
            ls = GCScaleInspection(pGC, FromDate, Todate);
            GetGC(pGC).rep_Inspection_report = ls;
            return ls;
        }
        public List<cls_survillanceclassreport> GetSurvillanceGCdata(string pGC, string FromDate, int pdays)
        {
            var ls = new List<cls_survillanceclassreport>();
            ls = KocConfig.OTSContext.ExecuteStoreQuery<cls_survillanceclassreport>("Select distinct well WellName, well_completion_s wc_s, service_status , contractor, service_status_date , main_job_type , service_remarks  from OTS_DM_ACTIVITIES_HISTORY where gc like '" + pGC + "' and service_status_date between convert(datetime,'" + FromDate + "',103) -" + pdays + " and convert(datetime,'" + FromDate + "',103) order by 5,1").ToList;
            GetGC(pGC).rep_survillance_report = ls;
            return ls;
        }
        public List<cls_survillanceclassreport> GetSurvillanceGCdata(string pGC, string FromDate, string toDate)
        {
            var ls = new List<cls_survillanceclassreport>();
            ls = KocConfig.OTSContext.ExecuteStoreQuery<cls_survillanceclassreport>("Select distinct well WellName, well_completion_s wc_s, service_status , contractor, service_status_date , main_job_type , service_remarks  from OTS_DM_ACTIVITIES_HISTORY where gc like '" + pGC + "' and service_status_date between convert(datetime,'" + FromDate + "',103) and convert(datetime,'" + toDate + "',103) order by 5,1").ToList;
            GetGC(pGC).rep_survillance_report = ls;
            return ls;
        }
        public List<cls_survillanceclassreport> GetSurvillanceGCdataJobStatusStats(string pGC, string FromDate, string toDate)
        {
            var ls = new List<cls_survillanceclassreport>();
            ls = KocConfig.OTSContext.ExecuteStoreQuery<cls_survillanceclassreport>("Select distinct service_status , main_job_type,count(well_completion_s) cnt from OTS_DM_ACTIVITIES_HISTORY where gc like '" + pGC + "' and service_status_date between convert(datetime,'" + FromDate + "',103) and convert(datetime,'" + toDate + "',103) group by  service_status ,   main_job_type ").ToList;
            // GetGC(pGC).rep_survillance_report = ls
            return ls;
        }
        public List<cls_survillanceclassreport> GetSurvillanceGCdataJobStatusContractorStats(string pGC, string FromDate, string toDate)
        {
            var ls = new List<cls_survillanceclassreport>();
            ls = KocConfig.OTSContext.ExecuteStoreQuery<cls_survillanceclassreport>("Select distinct service_status ,contractor,main_job_type,count(well_completion_s) cnt from OTS_DM_ACTIVITIES_HISTORY where gc like '" + pGC + "' and service_status_date between convert(datetime,'" + FromDate + "',103) and convert(datetime,'" + toDate + "',103) group by  service_status ,contractor,   main_job_type").ToList;
            // GetGC(pGC).rep_survillance_report = ls
            return ls;
        }
        public List<cls_rigactivityreport> GetRigActivitesforGCdata(string pGC, string FromDate, int pdays)
        {
            var ls = new List<cls_rigactivityreport>();
            GetNewOldConnectedWells(pGC);
            ls = KocConfig.EDMContext.ExecuteStoreQuery<cls_rigactivityreport>("SELECT R.RIG_NAME,CW.WELL_COMMON_NAME WellName,D.DATE_REPORT,D.STATUS status_type,D.COMMENT_SUMMARY DDR_REPORT,D.DAYS_ON_LOCATION,D.DAYS_FROM_SPUD,D.TREE_CONDITION NEXT_LOC FROM EDMADMIN.DM_DAILY D,EDMADMIN.CD_WELL_SOURCE  CW,EDMADMIN.CD_RIG R,  dm_report_journal RJ WHERE D.WELL_ID= CW.WELL_ID    AND R.RIG_ID= RJ.RIG_ID AND D.REPORT_JOURNAL_ID=RJ.REPORT_JOURNAL_ID AND D.DATE_REPORT between to_date('" + FromDate + "','DD-MM-YYYY') and to_date('" + FromDate + "','DD-MM-YYYY')+" + pdays + "  and cw.WELL_COMMON_NAME in " + GetGC(pGC).w_list + " ORDER BY 2,3 DESC").ToList;
            GetGC(pGC).rep_RigAcivities_report = ls;
            return ls;
        }
        public List<cls_rigactivityreport> GetRigActivitesforFielddata(string pFidld, string FromDate, int pdays)
        {
            var ls = new List<cls_rigactivityreport>();
            // GetNewOldConnectedWells(pGC)
            ls = KocConfig.EDMContext.ExecuteStoreQuery<cls_rigactivityreport>("SELECT R.RIG_NAME,CW.WELL_COMMON_NAME WellName,D.DATE_REPORT,D.STATUS status_type,D.COMMENT_SUMMARY DDR_REPORT,D.DAYS_ON_LOCATION,D.DAYS_FROM_SPUD,D.TREE_CONDITION NEXT_LOC FROM EDMADMIN.DM_DAILY D,EDMADMIN.CD_WELL_SOURCE  CW,EDMADMIN.CD_RIG R,  dm_report_journal RJ WHERE D.WELL_ID= CW.WELL_ID    AND R.RIG_ID= RJ.RIG_ID AND D.REPORT_JOURNAL_ID=RJ.REPORT_JOURNAL_ID AND D.DATE_REPORT between to_date('" + FromDate + "','DD-MM-YYYY') and to_date('" + FromDate + "','DD-MM-YYYY')+" + pdays + "  and instr(lower(cw.WELL_COMMON_NAME), '" + pFidld.ToLower() + "')>0  ORDER BY 2,3 DESC").ToList;
            GetField(pFidld).rep_RigAcivities_report = ls;
            return ls;
        }
        public List<cls_rigactivityreport> GetRigActivitesforWelldata(string pWell, string FromDate, int pdays)
        {
            var ls = new List<cls_rigactivityreport>();
            // GetNewOldConnectedWells(pGC)
            ls = KocConfig.EDMContext.ExecuteStoreQuery<cls_rigactivityreport>("SELECT R.RIG_NAME,CW.WELL_COMMON_NAME WellName,D.DATE_REPORT,D.STATUS status_type,D.COMMENT_SUMMARY DDR_REPORT,D.DAYS_ON_LOCATION,D.DAYS_FROM_SPUD,D.TREE_CONDITION NEXT_LOC FROM EDMADMIN.DM_DAILY D,EDMADMIN.CD_WELL_SOURCE  CW,EDMADMIN.CD_RIG R,  dm_report_journal RJ WHERE D.WELL_ID= CW.WELL_ID    AND R.RIG_ID= RJ.RIG_ID AND D.REPORT_JOURNAL_ID=RJ.REPORT_JOURNAL_ID AND D.DATE_REPORT between to_date('" + FromDate + "','DD-MM-YYYY') and to_date('" + FromDate + "','DD-MM-YYYY')+" + pdays + "  and instr(cw.WELL_COMMON_NAME, '" + pWell + "')>0  ORDER BY 2,3 DESC").ToList;

            return ls;
        }
        public List<cls_wellsList> GetNewOldConnectedWells(string pGC)
        {
            var ls = new List<cls_wellsList>();
            ls = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_wellsList>("select distinct uwi  from koc.koc_gc_well_snap where gc = '" + pGC + "' union select uwi from finderweb.well_activities where gc='" + pGC + "'").ToList;
            GetGC(pGC).rep_newoldConnectedWells_report = ls;
            GetGC(pGC).w_list = "(";
            foreach (cls_wellsList i in ls)
            {
                if (GetGC(pGC).w_list == "(")
                {
                    GetGC(pGC).w_list += "'" + i.uwi + "'";
                }
                else
                {
                    GetGC(pGC).w_list += ",'" + i.uwi + "'";
                }

            }

            GetGC(pGC).w_list += ")";
            return ls;
        }
        public DateTime ConvertStringtoDate(string pDate)
        {


            return DateTime.Parse(pDate);

        }
        public string GetWellsStringCompletionNumber(List<cls_Finderwell> wellslist)
        {
            string Wells = "";
            Wells = " in ( ";
            if (wellslist.Count > 0)
            {
                int I;
                var pools = new List<cls_RESERVOIR_LIST>();
                var loopTo = wellslist.Count - 1;
                for (I = 0; I <= loopTo; I++)
                {

                    if (I < wellslist.Count - 1)
                    {
                        Wells = Wells + wellslist[I].WELL_COMPLETION_S + ",";
                    }
                    else
                    {
                        Wells = Wells + wellslist[I].WELL_COMPLETION_S + ")";

                    }

                    if (pools.Exists(x => (x.RESERVOIR_ID ?? "") == (wellslist[I].RESERVOIR_ID ?? "")) == false)
                    {
                        var r = new cls_RESERVOIR_LIST();
                        r.RESERVOIR_ID = wellslist[I].RESERVOIR_ID;
                        r.RESERVOIR_NAME = wellslist[I].RESERVOIR_NAME;
                        pools.Add(r);
                    }


                }

            }
            return Wells;
        }
        public string GetWellsStringUWI(List<cls_Finderwell> wellslist)
        {
            string Wells = "";
            Wells = " in ( ";
            if (wellslist.Count > 0)
            {
                int I;
                var pools = new List<cls_RESERVOIR_LIST>();
                var loopTo = wellslist.Count - 1;
                for (I = 0; I <= loopTo; I++)
                {

                    if (I < wellslist.Count - 1)
                    {
                        Wells = Wells + "'" + wellslist[I].UWI + "',";
                    }
                    else
                    {
                        Wells = Wells + "'" + wellslist[I].UWI + "')";

                    }

                    if (pools.Exists(x => (x.RESERVOIR_ID ?? "") == (wellslist[I].RESERVOIR_ID ?? "")) == false)
                    {
                        var r = new cls_RESERVOIR_LIST();
                        r.RESERVOIR_ID = wellslist[I].RESERVOIR_ID;
                        r.RESERVOIR_NAME = wellslist[I].RESERVOIR_NAME;
                        pools.Add(r);
                    }


                }

            }
            return Wells;
        }
        public List<cls_lastCloseOpenEvent> GetLastCloseOpenforGCdata(string pGC, string FromDate, int pdays)
        {
            var ls = new List<cls_lastCloseOpenEvent>();
            DateTime fdate, edate;
            string todate;
            var splidate = FromDate.Split('-');
            fdate = ConvertStringtoDate(splidate[2] + "-" + splidate[1] + "-" + splidate[0]);
            edate = fdate.AddDays(-pdays);
            todate = edate.Month + "/" + edate.Day + "/" + edate.Year;
            FromDate = fdate.Month + "/" + fdate.Day + "/" + fdate.Year;
            ls = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_lastCloseOpenEvent>("select distinct b.uwi,b.reservoir_id reservoir,b.facility_type,b.status_type,b.last_update event_time,b.reason from koc.well_hdr a,koc.koc_well_status_snap b,koc.koc_gc_well_snap c where a.uwi=b.uwi and b.well_completion_s=c.well_completion_s and c.end_time is null and c.gc='" + pGC + "' and b.status_type in ('CLOSE','OPEN') and b.LAST_UPDATE between to_date('" + FromDate + "','MM-DD-YYYY') and to_date('" + todate + "','MM-DD-YYYY') order by b.last_update desc").ToList;
            // ---------------- get connected wells ---------------
            string wellstring = GetWellsStringUWI(GetGC(pGC).ConnectedWells);
            // ----------------------------------------------------
            var lsAlms = new List<cls_ots_dm_al_stopstart_events>();
            lsAlms = KocConfig.OTSContext.ExecuteStoreQuery<cls_ots_dm_al_stopstart_events>("Select distinct uwi,  datetime start_time , stopstart, remarks ,wstring  from OTS_DM_al_stopstart_events where uwi  " + wellstring + "    and  datetime between '" + todate + " 5:00:00 AM'  And '" + FromDate + " 5:00:00 AM' order by 2  desc").ToList; // 
            foreach (cls_ots_dm_al_stopstart_events l in lsAlms)
            {
                var x = new cls_lastCloseOpenEvent();
                x.event_time = l.start_time;
                x.reason = l.Remarks;
                x.uwi = l.uwi;
                x.status_type = Conversions.ToString(Interaction.IIf(l.StopStart == 1, "CLOSE", "OPEN"));
                ls.Add(x);
            }
            GetGC(pGC).rep_lastcloseopen_report = ls;
            return ls;
        }
        public List<cls_lastCloseOpenEvent> GetLastCloseOpenforFielddata(string pField, string FromDate, int pdays)
        {
            var ls = new List<cls_lastCloseOpenEvent>();
            DateTime fdate, edate;
            string todate;
            var splidate = FromDate.Split('-');
            fdate = ConvertStringtoDate(splidate[2] + "-" + splidate[1] + "-" + splidate[0]);
            edate = fdate.AddDays(-pdays);
            todate = edate.Month + "/" + edate.Day + "/" + edate.Year;
            FromDate = fdate.Month + "/" + fdate.Day + "/" + fdate.Year;
            ls = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_lastCloseOpenEvent>("select distinct b.uwi,b.reservoir_id reservoir,b.facility_type,b.status_type,b.last_update event_time,b.reason from koc.well_hdr a,koc.koc_well_status_snap b,koc.koc_gc_well_snap c where a.uwi=b.uwi and b.well_completion_s=c.well_completion_s and c.end_time is null and substr(c.uwi,0,2)='" + pField + "' and b.status_type in ('CLOSE','OPEN') and b.LAST_UPDATE between to_date('" + FromDate + "','DD-MM-YYYY') and to_date('" + todate + "','DD-MM-YYYY')  order by b.last_update desc").ToList;

            var lsAlms = new List<cls_ots_dm_al_stopstart_events>();
            lsAlms = KocConfig.OTSContext.ExecuteStoreQuery<cls_ots_dm_al_stopstart_events>("Select distinct uwi, DateTime start_time , stopstart, remarks, wstring  from OTS_DM_al_stopstart_events where uwi Like '%" + pField + "%'    and  datetime between '" + todate + " 5:00:00 AM'  And '" + FromDate + " 5:00:00 AM' order by 2  desc").ToList; // 
            foreach (cls_ots_dm_al_stopstart_events l in lsAlms)
            {
                var x = new cls_lastCloseOpenEvent();
                x.event_time = l.start_time;
                x.reason = l.Remarks;
                x.uwi = l.uwi;
                x.status_type = Conversions.ToString(Interaction.IIf(l.StopStart == 1, "CLOSE", "OPEN"));
                ls.Add(x);
            }
            return ls;
        }
        public List<cls_lastCloseOpenEvent> GetLastCloseOpenforFielddata(string pField, string FromDate, string ToDate)
        {
            var ls = new List<cls_lastCloseOpenEvent>();
            DateTime fdate, edate;
            int pdays;
            var splidate1 = FromDate.Split('-');
            var splidate2 = ToDate.Split('-');
            fdate = ConvertStringtoDate(splidate1[2] + "-" + splidate1[1] + "-" + splidate1[0]);
            edate = ConvertStringtoDate(splidate2[2] + "-" + splidate2[1] + "-" + splidate2[0]);
            pdays = (int)Round((fdate - edate).TotalDays);

            ToDate = edate.Month + "/" + edate.Day + "/" + edate.Year;
            FromDate = fdate.Month + "/" + fdate.Day + "/" + fdate.Year;
            ls = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_lastCloseOpenEvent>("select distinct b.uwi,b.reservoir_id reservoir,b.facility_type,b.status_type,b.last_update event_time,b.reason from koc.well_hdr a,koc.koc_well_status_snap b,koc.koc_gc_well_snap c where a.uwi=b.uwi and b.well_completion_s=c.well_completion_s and c.end_time is null and substr(c.uwi,0,2)='" + pField + "' and b.status_type in ('CLOSE','OPEN') and b.LAST_UPDATE between to_date('" + FromDate + "','DD-MM-YYYY') and to_date('" + ToDate + "','DD-MM-YYYY')+1 order by b.last_update desc").ToList;
            var lsAlms = new List<cls_ots_dm_al_stopstart_events>();
            lsAlms = KocConfig.OTSContext.ExecuteStoreQuery<cls_ots_dm_al_stopstart_events>("Select distinct uwi,  datetime start_time , stopstart, remarks ,wstring  from OTS_DM_al_stopstart_events where uwi like '%" + pField + "%'  and  datetime between '" + ToDate + " 5:00:00 AM'  And '" + FromDate + " 5:00:00 AM' order by 2  desc").ToList; // 
            foreach (cls_ots_dm_al_stopstart_events l in lsAlms)
            {
                var x = new cls_lastCloseOpenEvent();
                x.event_time = l.start_time;
                x.reason = l.Remarks;
                x.uwi = l.uwi;
                x.status_type = Conversions.ToString(Interaction.IIf(l.StopStart == 1, "CLOSE", "OPEN"));
                ls.Add(x);
            }
            return ls;
        }
        public List<cls_lastCloseOpenEvent> GetLastCloseOpenforUWIdata(string pUWI, string FromDate, int pdays)
        {
            var ls = new List<cls_lastCloseOpenEvent>();
            ls = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_lastCloseOpenEvent>("select distinct b.uwi,b.reservoir_id reservoir,b.facility_type,b.status_type,b.last_update event_time,b.reason from koc.well_hdr a,koc.koc_well_status_snap b,koc.koc_gc_well_snap c where a.uwi=b.uwi and b.well_completion_s=c.well_completion_s and c.end_time is null and c.uwi ='" + pUWI + "' and b.status_type in ('CLOSE','OPEN') and b.LAST_UPDATE between to_date('" + FromDate + "','DD-MM-YYYY') and to_date('" + FromDate + "','DD-MM-YYYY')+" + pdays + " order by b.last_update asc").Take(1).ToList;
            // GetGC(pGC).rep_lastcloseopen_report = ls
            return ls;
        }
        public List<cls_lastCloseOpenEvent> GetLastCloseOpenforUWIdataFromALMSandFinder(int wcs, string pUWI, string FromDate, int pdays, char ESP = 'N')
        {
            var ls = new List<cls_lastCloseOpenEvent>();
            DateTime fdate, edate;
            string todate;
            var splidate = FromDate.Split('-');
            fdate = ConvertStringtoDate(splidate[2] + "-" + splidate[1] + "-" + splidate[0]);
            edate = fdate.AddDays(-pdays);
            todate = edate.Month + "/" + edate.Day + "/" + edate.Year;
            FromDate = fdate.Month + "/" + fdate.Day + "/" + fdate.Year;

            ls = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_lastCloseOpenEvent>("select distinct b.uwi,b.reservoir_id reservoir,b.facility_type,b.status_type,b.last_update event_time,b.reason from koc.well_hdr a,koc.koc_well_status_snap b,koc.koc_gc_well_snap c where a.uwi=b.uwi and b.well_completion_s=c.well_completion_s and c.end_time is null and c.well_completion_s =" + wcs + " and b.status_type in ('CLOSE','OPEN')  order by b.last_update desc").ToList; // and b.LAST_UPDATE  between to_date('" & FromDate & "','MM/DD/YYYY')-" & pdays & " and to_date('" & FromDate & "','MM/DD/YYYY')+1

            var lsAlms = new List<cls_ots_dm_al_stopstart_events>();
            lsAlms = KocConfig.OTSContext.ExecuteStoreQuery<cls_ots_dm_al_stopstart_events>("Select distinct uwi,  datetime start_time , stopstart, remarks ,wstring  from OTS_DM_al_stopstart_events where uwi like '" + pUWI + "'  and datetime between '" + todate + " 5:00:00 AM'  And '" + FromDate + " 5:00:00 AM' order by 2  desc").ToList; // 
            foreach (cls_ots_dm_al_stopstart_events l in lsAlms)
            {
                var x = new cls_lastCloseOpenEvent();
                x.event_time = l.start_time;
                x.reason = l.Remarks;
                x.uwi = l.uwi;
                x.status_type = Conversions.ToString(Interaction.IIf(l.StopStart == 1, "CLOSE", "OPEN"));

                ls.Add(x);
            }




            // GetGC(pGC).rep_lastcloseopen_report = ls
            return ls;
        }
        public cls_lastCloseOpenEvent GetLastCloseOpenforUWIdataFromALMSandFinderLastEvents(int wcs, string pUWI, string FromDate)
        {
            var ls = new List<cls_lastCloseOpenEvent>();
            ls = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_lastCloseOpenEvent>("select distinct b.uwi,b.reservoir_id reservoir,b.facility_type,b.status_type,b.last_update event_time,b.reason from koc.well_hdr a,koc.koc_well_status_snap b,koc.koc_gc_well_snap c where a.uwi=b.uwi and b.well_completion_s=c.well_completion_s and c.end_time is null and c.well_completion_s =" + wcs + " and b.status_type in ('CLOSE','OPEN') and b.LAST_UPDATE < to_date('" + FromDate + "','DD-MM-YYYY HH24:MI:SS') order by b.last_update desc").Take(1).ToList;
            var lsAlms = new List<cls_ots_dm_al_stopstart_events>();
            lsAlms = KocConfig.OTSContext.ExecuteStoreQuery<cls_ots_dm_al_stopstart_events>("Select distinct uwi, DateTime start_time , stopstart, remarks, wstring  from OTS_DM_al_stopstart_events where uwi Like '" + pUWI + "'  and datetime < to_date('" + FromDate + "','DD-MM-YYYY HH24:MI:SS')  order by 2  desc").ToList;
            foreach (cls_ots_dm_al_stopstart_events l in lsAlms)
            {
                var x = new cls_lastCloseOpenEvent();
                x.event_time = l.start_time;
                x.reason = l.Remarks;
                x.uwi = l.uwi;
                x.status_type = Conversions.ToString(Interaction.IIf(l.StopStart == 1, "CLOSE", "OPEN"));

                ls.Add(x);
            }
            // GetGC(pGC).rep_lastcloseopen_report = ls
            return ls.OrderByDescending(x => x.event_time).FirstOrDefault();

        }
        public cls_lastCloseOpenEvent GetLastCloseOpenforUWIdataFromALMSandFinderFirstEvents(int wcs, string pUWI, string FromDate)
        {
            var ls = new List<cls_lastCloseOpenEvent>();
            ls = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_lastCloseOpenEvent>("select distinct b.uwi,b.reservoir_id reservoir,b.facility_type,b.status_type,b.last_update event_time,b.reason from koc.well_hdr a,koc.koc_well_status_snap b,koc.koc_gc_well_snap c where a.uwi=b.uwi and b.well_completion_s=c.well_completion_s and c.end_time is null and c.well_completion_s =" + wcs + " and b.status_type in ('CLOSE','OPEN') and b.LAST_UPDATE > to_date('" + FromDate + "','DD-MM-YYYY HH24:MI:SS')  order by b.last_update asc").Take(1).ToList;
            var lsAlms = new List<cls_ots_dm_al_stopstart_events>();
            lsAlms = KocConfig.OTSContext.ExecuteStoreQuery<cls_ots_dm_al_stopstart_events>("Select distinct uwi,  datetime start_time , stopstart, remarks ,wstring  from OTS_DM_al_stopstart_events where uwi like '" + pUWI + "'  and datetime > to_date('" + FromDate + "','DD-MM-YYYY HH24:MI:SS')   order by 2  desc").ToList;
            foreach (cls_ots_dm_al_stopstart_events l in lsAlms)
            {
                var x = new cls_lastCloseOpenEvent();
                x.event_time = l.start_time;
                x.reason = l.Remarks;
                x.uwi = l.uwi;
                x.status_type = Conversions.ToString(Interaction.IIf(l.StopStart == 1, "CLOSE", "OPEN"));

                ls.Add(x);
            }
            // GetGC(pGC).rep_lastcloseopen_report = ls
            return ls.OrderByDescending(x => x.event_time).FirstOrDefault();
        }
        public List<cls_lastCloseOpenEvent> GetLastCloseOpenforGCdata(string pGC, string FromDate, string toDate)
        {
            var ls = new List<cls_lastCloseOpenEvent>();
            ls = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_lastCloseOpenEvent>("select distinct b.uwi,b.reservoir_id reservoir,b.facility_type,b.status_type,b.last_update event_time,b.reason from koc.well_hdr a,koc.koc_well_status_snap b,koc.koc_gc_well_snap c where a.uwi=b.uwi and b.well_completion_s=c.well_completion_s and c.end_time is null and c.gc='" + pGC + "' and b.status_type in ('CLOSE','OPEN') and b.LAST_UPDATE between to_date('" + FromDate + "','DD-MM-YYYY') and to_date('" + toDate + "','DD-MM-YYYY')+1 order by b.last_update desc").ToList;
            GetGC(pGC).rep_lastcloseopen_report = ls;
            return ls;
        }
        public List<cls_lastCloseOpenEvent> GetLastCloseOpenforGCdataStatsbyField(string pGC, string FromDate, string toDate)
        {
            var ls = new List<cls_lastCloseOpenEvent>();
            ls = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_lastCloseOpenEvent>("select distinct count(b.status_type) cnt ,b.reason,a.field,b.status_type from koc.well_hdr a,koc.koc_well_status_snap b,koc.koc_gc_well_snap c where a.uwi=b.uwi and b.well_completion_s=c.well_completion_s and c.end_time is null and c.gc='" + pGC + "' and b.status_type in ('CLOSE','OPEN') and b.LAST_UPDATE between to_date('" + FromDate + "','DD-MM-YYYY') and to_date('" + toDate + "','DD-MM-YYYY')+1 group by b.status_type, b.reason,a.field  ").ToList;
            // GetGC(pGC).rep_lastcloseopen_report = ls
            return ls;
        }
        public List<cls_lastCloseOpenEvent> GetLastCloseOpenforGCdataStatsbyRes(string pGC, string FromDate, string toDate)
        {
            var ls = new List<cls_lastCloseOpenEvent>();
            ls = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_lastCloseOpenEvent>("select distinct count(b.status_type) cnt,b.status_type,b.reason,b.reservoir_id reservoir from koc.well_hdr a,koc.koc_well_status_snap b,koc.koc_gc_well_snap c where a.uwi=b.uwi and b.well_completion_s=c.well_completion_s and c.end_time is null and c.gc='" + pGC + "' and b.status_type in ('CLOSE','OPEN') and b.LAST_UPDATE between to_date('" + FromDate + "','DD-MM-YYYY') and to_date('" + toDate + "','DD-MM-YYYY')+1 group by b.status_type,b.reason,b.reservoir_id ").ToList;
            // GetGC(pGC).rep_lastcloseopen_report = ls
            return ls;
        }
        public List<cls_lastProductiondatareport> GetLastProductionGCdata(string pGC, string FromDate)
        {
            var ls = new List<cls_lastProductiondatareport>();
            ls = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_lastProductiondatareport>("Select pd.start_time, pd.flowing_completions,pd.wetoil,pd.dryoil, pd.gc_factor,round(pd.EFFLUENT_WATER_PRODUCED) EffWaterProduction,pd.oilvol  OilProduction,pv.DISPATCH From koc.gc_prod_daily pd,koc.gc_daily_volumes pv  Where pd.GC = '" + pGC + "' And pd.start_time=to_date('" + FromDate + "','DD-MM-YYYY') AND pd.Material_type in ('OIL','LIGHT OIL','MEDIUM OIL') AND pv.surface_facility_s=pd.FINDER_S AND pv.production_date=pd.start_time union Select pd.start_time , pd.flowing_completions ,pd.wetoil,pd.dryoil,pd.gc_factor,round(pd.EFFLUENT_WATER_PRODUCED) EffWaterProduction, pd.oilvol,pv.DISPATCH From koc.gc_prod_daily pd,koc.gc_daily_volumes pv Where pd.GC = '" + pGC + "' And pd.start_time=to_date('" + FromDate + "','DD-MM-YYYY')-1 AND pd.Material_type = 'OIL' AND pv.surface_facility_s=pd.FINDER_S AND pv.production_date=pd.start_time  order by start_time desc").ToList;
            GetGC(pGC).rep_lastproduction_report = ls;
            return ls;
        }
        public cls_lastProductiondatareport GetProductionGCdata(string pGC, string FromDate)
        {

            return KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_lastProductiondatareport>("Select pd.start_time, pd.flowing_completions,pd.wetoil,pd.dryoil, pd.gc_factor,round(pd.EFFLUENT_WATER_PRODUCED) EffWaterProduction,pd.oilvol  OilProduction,pv.DISPATCH From koc.gc_prod_daily pd,koc.gc_daily_volumes pv  Where pd.GC = '" + pGC + "' And pd.start_time=to_date('" + FromDate + "','DD-MM-YYYY') AND pd.Material_type in ('OIL','LIGHT OIL','MEDIUM OIL') AND pv.surface_facility_s=pd.FINDER_S AND pv.production_date=pd.start_time   order by start_time desc").FirstOrDefault;


        }
        public cls_lastProductiondatareport GetProductionGCdata(string pGC, string FromDate, string todate)
        {

            return KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_lastProductiondatareport>("Select pd.start_time, pd.flowing_completions,pd.wetoil,pd.dryoil, pd.gc_factor,round(pd.EFFLUENT_WATER_PRODUCED) EffWaterProduction,pd.oilvol  OilProduction,pv.DISPATCH From koc.gc_prod_daily pd,koc.gc_daily_volumes pv  Where pd.GC = '" + pGC + "' And pd.start_time>=to_date('" + FromDate + "','DD-MM-YYYY') and pd.start_time<=to_date('" + todate + "','DD-MM-YYYY')  AND pd.Material_type in ('OIL','LIGHT OIL','MEDIUM OIL') AND pv.surface_facility_s=pd.FINDER_S AND pv.production_date=pd.start_time   order by start_time desc").FirstOrDefault;


        }
        public cls_lastProductiondatareport GetProductionGCOndata(string pGC, string OnDate)
        {

            return KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_lastProductiondatareport>("Select pd.start_time, pd.flowing_completions,pd.wetoil,pd.dryoil, pd.gc_factor,round(pd.EFFLUENT_WATER_PRODUCED) EffWaterProduction,pd.oilvol  OilProduction,pv.DISPATCH From koc.gc_prod_daily pd,koc.gc_daily_volumes pv  Where pd.GC = '" + pGC + "' And pd.start_time=to_date('" + OnDate + "','DD-MM-YYYY') AND pd.Material_type in ('OIL','LIGHT OIL','MEDIUM OIL') AND pv.surface_facility_s=pd.FINDER_S AND pv.production_date=pd.start_time  order by start_time desc").FirstOrDefault;

        }
        public List<cls_chockchange_report> GetLatestChokeGCdata(string pGC, string FromDate, string todate)
        {
            var ls = new List<cls_chockchange_report>();
            ls = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_chockchange_report>("select gc,uwi ,string_name,reservoir,test_date,lc_o ,rc_o, lc_n,rc_n from koc.chokechange where gc='" + pGC + "'  and DATE_ENTERED between to_date('" + FromDate + "','DD-MM-YYYY')-1 and to_date('" + todate + "','DD-MM-YYYY') +1 order by DATE_ENTERED desc").ToList;
            GetGC(pGC).rep_lastChokeChange_report = ls;
            return ls;
        }
        public List<cls_chockchange_report> GetLatestChokeFielddata(string pField, string FromDate, string todate)
        {
            var ls = new List<cls_chockchange_report>();
            ls = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_chockchange_report>("select gc,uwi ,string_name,reservoir,test_date,lc_o ,rc_o, lc_n,rc_n from koc.chokechange where substr(uwi,0,2)='" + pField + "'  and DATE_ENTERED between to_date('" + FromDate + "','DD-MM-YYYY')-1 and to_date('" + todate + "','DD-MM-YYYY') +1 order by DATE_ENTERED desc").ToList;
            // GetGC(pGC).rep_lastChokeChange_report = ls
            return ls;
        }
        public List<cls_chockchange_report> GetLatestChokeUWIdata(string pUWI, string FromDate, string todate)
        {
            var ls = new List<cls_chockchange_report>();
            ls = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_chockchange_report>("select gc,uwi ,string_name,reservoir,test_date,lc_o ,rc_o, lc_n,rc_n from koc.chokechange where uwi='" + pUWI + "'  and DATE_ENTERED between to_date('" + FromDate + "','DD-MM-YYYY')-1 and to_date('" + todate + "','DD-MM-YYYY') +1 order by DATE_ENTERED desc").ToList;
            // GetGC(pGC).rep_lastChokeChange_report = ls
            return ls;
        }
        public List<cls_chockchange_report> GetLatestChokeGCdataStats(string pGC, string FromDate, string todate)
        {
            var ls = new List<cls_chockchange_report>();
            ls = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_chockchange_report>("select gc,uwi ,string_name,reservoir,test_date,lc_o ,rc_o, lc_n,rc_n from koc.chokechange where gc='" + pGC + "'  and DATE_ENTERED between to_date('" + FromDate + "','DD-MM-YYYY')-1 and to_date('" + todate + "','DD-MM-YYYY') +1 order by DATE_ENTERED desc").ToList;
            // GetGC(pGC).rep_lastChokeChange_report = ls
            return ls;
        }
        public List<cls_chockchange_report> GetLatestChokeByAreadata(string pArea, string FromDate, string todate)
        {
            var ls = new List<cls_chockchange_report>();
            ls = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_chockchange_report>("select gc,uwi ,string_name,reservoir,test_date,lc_o ,rc_o, lc_n,rc_n from koc.chokechange where gc='" + pArea + "'  and DATE_ENTERED between to_date('" + FromDate + "','DD-MM-YYYY')-1 and to_date('" + todate + "','DD-MM-YYYY') +1 order by DATE_ENTERED desc").ToList;
            // GetGC(pArea).rep_lastChokeChange_report = ls
            return ls;
        }
        public List<cls_gcproductionreport> GetLastmonthProductionGCdata(string pGC, string FromDate)
        {
            var ls = new List<cls_gcproductionreport>();
            ls = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_gcproductionreport>("Select pd.start_time,pd.flowing_completions, pd.EFFLUENT_WATER_PRODUCED,pd.DISPOSED_TO_PIT ,pd.WASH_WATER_CONS,pd.oilvol ,pd.wetoil ,pd.dryoil  , pv.dispatch From koc.gc_prod_daily pd,koc.gc_daily_volumes pv  Where pd.GC = '" + pGC + "'  And START_TIME > to_date('" + FromDate + "','DD-MM-YYYY') and  START_TIME <=to_date('" + FromDate + "','DD-MM-YYYY')+30 AND Material_type = 'OIL'  AND surface_facility_s=pd.FINDER_S AND production_date=pd.start_time  order by start_time desc").ToList;
            GetGC(pGC).rep_Last30Daysproduction_report = ls;
            return ls;
        }

        #region Well Data Monthly Fetch Routine
        public string Completion_Header_ForMonth(int v_wcs, int mm, int yyyy)
        {
            string hdr;
            hdr = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<string>("Select facility_id  from koc.surface_facility " + "  where facility_type = 'HEADER' AND " + "  surface_facility_s in " + "  	(select to_surface_facility_s from koc.port_connection " + "     where START_TIME = " + "  	 (select max(start_time) from koc.port_connection " + "  	  WHERE	from_downhole_facility_s in " + "  		(select string_s from koc.well_completion where well_completion_s =   " + v_wcs + ")" + "  	  AND CONNECTION_TYPE IS NULL " + "  	  AND  Last_day(to_date('01/" + mm + "/" + yyyy + "', 'dd-mm-yyyy')) between start_time and nvl(end_time,sysdate+2)) " + "   and	from_downhole_facility_s in " + "  	(select string_s from koc.well_completion where well_completion_s =   " + v_wcs + "))").FirstOrDefault;
            return hdr;
        }
        public string String_Connection_Header_ForMonth(int string_S, int mm, int yyyy)
        {
            string hdr;
            hdr = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<string>("SELECT sf.facility_id " + " FROM koc.surface_facility sf, koc.port_connection pc " + " WHERE sf.facility_type = 'HEADER' " + "   AND sf.surface_facility_s = pc.to_surface_facility_s " + "   AND (pc.end_time IS NULL OR pc.end_time >  Last_day(to_date('01/" + mm + "/" + yyyy + "', 'dd-mm-yyyy'))) " + "   AND pc.start_time < Last_day(to_date('01/" + mm + "/" + yyyy + "', 'dd-mm-yyyy')) " + "  AND pc.from_downhole_facility_s =" + string_S + " " + "  ORDER BY pc.start_time DESC").FirstOrDefault;
            return hdr;
        }
        public string String_Connection_Header_FormTo(int string_S, DateTime pstartdatte, DateTime enddate)
        {
            string hdr;
            hdr = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<string>("SELECT sf.facility_id " + " FROM koc.surface_facility sf, koc.port_connection pc " + " WHERE sf.facility_type = 'HEADER' " + "   AND sf.surface_facility_s = pc.to_surface_facility_s " + "   AND (pc.end_time IS NULL OR pc.end_time >  to_date('" + enddate.Day + "/" + enddate.Month + "/" + enddate.Year + "', 'dd-mm-yyyy')) " + "   AND pc.start_time <= to_date('" + enddate.Day + "/" + enddate.Month + "/" + enddate.Year + "', 'dd-mm-yyyy') " + "  AND pc.from_downhole_facility_s =" + string_S + " " + "  ORDER BY pc.start_time DESC").FirstOrDefault;
            return hdr;
        }
        public cls_outvaluewithdate Completion_BeanStatus_ForMonth(int v_wcs, int mm, int yyyy)
        {
            cls_outvaluewithdate x;
            x = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_outvaluewithdate>("	SELECT start_time outdate, finding_reason outvalue   " + "   FROM koc.oil_field_operation " + " 		 WHERE activity_type = 'CHOKE' " + " 		 AND activity_id = 'CHOKE_CHECK' " + "       AND trunc(start_time) <=  Last_day(to_date('01/" + mm + "/" + yyyy + "', 'dd-mm-yyyy')) " + " 	     AND well_completion_s =  " + v_wcs + " 	 	ORDER BY start_time DESC").FirstOrDefault;
            return x;
        }
        public string Completion_Connection_slot_ForMonth(int v_wcs, int mm, int yyyy)
        {
            string x = "";
            x = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<string>("select facility_id   from koc.surface_facility " + " where surface_facility_s in ( " + " select surface_facility_s from koc.general_port " + "   where general_port_s in ( " + " select to_port_s from koc.port_connection " + " where  start_time = ( " + " select max(start_time) from koc.port_connection WHERE from_port_s in " + " (select general_port_s from koc.general_port where downhole_facility_s in " + " (select string_s from koc.well_completion where well_completion_s = " + v_wcs + "  )) " + " AND trunc(start_time) <=  Last_day(to_date('01/" + mm + "/" + yyyy + "', 'dd-mm-yyyy')) " + " and (trunc(end_time) is null or trunc(end_time) >= Last_day(to_date('01/" + mm + "/" + yyyy + "', 'dd-mm-yyyy')))) " + " and from_port_s in (select general_port_s from koc.general_port where downhole_facility_s in " + "   (select string_s from koc.well_completion where well_completion_s = " + v_wcs + "  ))))").FirstOrDefault;
            return x;
        }
        public string Completion_Connection_slot_FromTo(int v_wcs, DateTime pstartdatte, DateTime enddate)
        {
            string x = "";
            x = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<string>("select facility_id   from koc.surface_facility " + " where surface_facility_s in ( " + " select surface_facility_s from koc.general_port " + "   where general_port_s in ( " + " select to_port_s from koc.port_connection " + " where  start_time = ( " + " select max(start_time) from koc.port_connection WHERE from_port_s in " + " (select general_port_s from koc.general_port where downhole_facility_s in " + " (select string_s from koc.well_completion where well_completion_s = " + v_wcs + "  )) " + " AND trunc(start_time) <  to_date('" + pstartdatte.Day + "/" + pstartdatte.Month + "/" + pstartdatte.Year + "', 'dd-mm-yyyy') " + " and (trunc(end_time) is null or trunc(end_time) >= to_date('" + enddate.Day + "/" + enddate.Month + "/" + enddate.Year + "', 'dd-mm-yyyy'))) " + " and from_port_s in (select general_port_s from koc.general_port where downhole_facility_s in " + "   (select string_s from koc.well_completion where well_completion_s = " + v_wcs + "  ))))").FirstOrDefault;
            return x;
        }
        public cls_Comp_oper_status Completion_status_ForMonth(int v_wcs, int mm, int yyyy)
        {

            var x = new List<cls_Comp_oper_status>();
            x = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_Comp_oper_status>(" SELECT ofo.start_time, fs.status_type,fs.reason " + " FROM koc.oil_field_operation ofo, koc.facility_status fs " + "     WHERE(fs.start_oil_field_operation_s = ofo.oil_field_operation_s) " + "AND ofo.activity_type = 'FACILITY_STATUS_CHANGE'" + "AND ofo.start_time <  Last_day(to_date('01/" + mm + "/" + yyyy + "', 'dd-mm-yyyy')) " + "AND ofo.well_completion_s = " + v_wcs + " " + "ORDER BY ofo.start_time DESC").ToList;

            return x.FirstOrDefault();
        }
        public cls_Comp_oper_status Completion_status_atDate(int v_wcs, int dd, int mm, int yyyy)
        {

            var x = new List<cls_Comp_oper_status>();
            x = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_Comp_oper_status>(" SELECT ofo.start_time, fs.status_type,fs.reason " + " FROM koc.oil_field_operation ofo, koc.facility_status fs " + "     WHERE(fs.start_oil_field_operation_s = ofo.oil_field_operation_s) " + "AND ofo.activity_type = 'FACILITY_STATUS_CHANGE'" + "AND ofo.start_time <  (to_date('" + dd + "/" + mm + "/" + yyyy + " 05:00:00', 'dd-mm-yyyy HH:MM:SS')) " + "AND ofo.well_completion_s = " + v_wcs + " " + "ORDER BY ofo.start_time DESC").ToList;

            return x.FirstOrDefault();
        }
        public cls_whp_flp_date Completion_Whp_Flp_ForMonth(int v_wcs, int mm, int yyyy)
        {
            var x = new cls_whp_flp_date();
            x = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_whp_flp_date>("SELECT nvl(ts.tubing_pressure, ts.casing_pressure) whp, ts.flow_line_pressure flp, ofo.start_time " + " FROM koc.oil_field_operation ofo, koc.test_stage ts " + " WHERE ts.flow_line_pressure IS NOT NULL " + "  AND (ts.tubing_pressure IS NOT NULL OR ts.casing_pressure IS NOT NULL)" + "  AND ts.containing_act_s = ofo.oil_field_operation_s " + " AND ofo.start_time < Last_day(to_date('01/" + mm + "/" + yyyy + "', 'dd-mm-yyyy')) " + " AND ofo.activity_type = 'TEST' " + " AND ofo.well_completion_s = " + v_wcs + " " + " ORDER BY 3 DESC").FirstOrDefault;
            return x;
        }
        public cls_outvaluewithdate Completion_WaterCut_ForMonth(int v_wcs, int mm, int yyyy)
        {
            cls_outvaluewithdate wc;
            wc = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_outvaluewithdate>(" SELECT pp.nominal_water_cut outvalue , ofo.start_time outdate " + " FROM koc.oil_field_operation ofo, koc.test_stage ts, koc.periodic_production pp" + " WHERE pp.activity_type = 'WATER_CUT'" + " AND pp.nominal_water_cut IS NOT NULL" + " AND pp.test_stage_s = ts.test_stage_s" + " AND ts.containing_act_s = ofo.oil_field_operation_s" + " AND ofo.start_time < Last_day(to_date('01/" + mm + "/" + yyyy + "', 'dd-mm-yyyy')) " + " AND ofo.activity_type = 'TEST'" + " AND ofo.well_completion_s = " + v_wcs + " " + " ORDER BY 2 DESC").FirstOrDefault;
            return wc;
        }
        public cls_outvaluewithdate Completion_Choke_left_ForMonth(int v_wcs, int mm, int yyyy)
        {
            cls_outvaluewithdate x;
            x = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_outvaluewithdate>(" Select " + " nvl(ts.tubing_left_choke, ts.casing_left_choke) outvalue, " + " ofo.start_time outdate" + " FROM koc.oil_field_operation ofo, koc.test_stage ts" + " WHERE " + "  	NVL(ts.tubing_left_choke, ts.casing_left_choke) > 0" + "   AND NVL(ts.tubing_right_choke, ts.casing_right_choke) IS NOT NULL" + "  AND ts.containing_act_s = ofo.oil_field_operation_s" + " AND ofo.start_time < Last_day(to_date('01/" + mm + "/" + yyyy + "', 'dd-mm-yyyy')) " + " AND ofo.activity_type = 'TEST'" + " AND ofo.well_completion_s = " + v_wcs + " " + " ORDER BY 2 DESC").FirstOrDefault;
            return x;
        }
        public cls_outvaluewithdate Completion_Choke_Right_ForMonth(int v_wcs, int mm, int yyyy)
        {
            cls_outvaluewithdate x;
            x = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_outvaluewithdate>(" Select " + " nvl(ts.tubing_right_choke, ts.casing_right_choke) outvalue, " + " ofo.start_time outdate" + " FROM koc.oil_field_operation ofo, koc.test_stage ts" + " WHERE " + "  	NVL(ts.tubing_right_choke, ts.casing_right_choke) > 0" + "   AND NVL(ts.tubing_left_choke, ts.casing_left_choke) IS NOT NULL" + "  AND ts.containing_act_s = ofo.oil_field_operation_s" + " AND ofo.start_time < Last_day(to_date('01/" + mm + "/" + yyyy + "', 'dd-mm-yyyy')) " + " AND ofo.activity_type = 'TEST'" + " AND ofo.well_completion_s = " + v_wcs + " " + " ORDER BY 2 DESC").FirstOrDefault;
            return x;
        }
        public cls_outvaluewithdate Completion_LiquidRate_ForMonth(int v_wcs, int mm, int yyyy)
        {
            cls_outvaluewithdate lq;
            lq = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_outvaluewithdate>(" SELECT ofo.start_time outdate, round(ts.liquid_rate) outvalue " + " FROM koc.oil_field_operation ofo, koc.test_stage ts " + " WHERE ts.liquid_rate IS NOT NULL " + " AND ts.containing_act_s = ofo.oil_field_operation_s " + " AND ofo.start_time < Last_day(to_date('01/" + mm + "/" + yyyy + "', 'dd-mm-yyyy')) " + " AND ofo.activity_type = 'TEST' " + " AND ofo.well_completion_s = " + v_wcs + " " + " ORDER BY 1 DESC").FirstOrDefault;
            return lq;
        }
        public cls_outvaluewithdate Completion_Concentration_Fluids_ForMonth(int v_wcs, string Material_type, int mm, int yyyy)
        {
            cls_outvaluewithdate mat;
            mat = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_outvaluewithdate>("SELECT mc.concentration outvalue, ofo.start_time outdate" + " FROM koc_staging.s_oil_field_operation ofo, koc_staging.s_fluid_analysis fa, koc_staging.s_material_composition mc " + " WHERE mc.component_material_type = '" + Material_type.ToUpper() + "'" + "  AND mc.concentration IS NOT NULL" + " AND mc.project_fluid_analysis_s = fa.fluid_analysis_s" + " AND fa.oil_field_operation_s = ofo.oil_field_operation_s" + " AND ofo.start_time < Last_day(to_date('01/" + mm + "/" + yyyy + "', 'dd-mm-yyyy')) " + "    AND ofo.activity_type = 'TEST'" + "    AND ofo.well_completion_s =" + v_wcs + " " + "        UNION" + "  SELECT mc.concentration outvalue, ofo.start_time outdate" + "  FROM koc.oil_field_operation ofo, koc.fluid_analysis fa, koc.material_composition mc" + "  WHERE mc.component_material_type = '" + Material_type.ToUpper() + "'" + "    AND mc.concentration IS NOT NULL" + "    AND mc.project_fluid_analysis_s = fa.fluid_analysis_s" + "    AND fa.oil_field_operation_s = ofo.oil_field_operation_s" + " AND ofo.start_time < Last_day(to_date('01/" + mm + "/" + yyyy + "', 'dd-mm-yyyy')) " + " AND ofo.activity_type = 'TEST'" + " AND ofo.well_completion_s = " + v_wcs + " " + " ORDER BY 2 DESC").FirstOrDefault;
            return mat;

        }
        public cls_outvaluewithdate Completion_GOR_ForMonth(int v_wcs, int mm, int yyyy)
        {
            cls_outvaluewithdate mat;
            mat = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_outvaluewithdate>("  select  NOMINAL_GOR outvalue,pp.start_Time outdate" + " from koc.periodic_productIon  pp " + "    where " + "      activity_type      =  'TOTAL_GOR'" + " and               pp.well_Completion_s=" + v_wcs + " " + " and               preferred_flag='Y'" + " and               NOMINAL_GOR is not null" + " and               pp.start_Time < Last_day(to_date('01/" + mm + "/" + yyyy + "', 'dd-mm-yyyy')) " + " Order by     start_time desc").FirstOrDefault;
            return mat;


        }
        public int Completion_Allowed_ForMonth(int v_wcs, int mm, int yyyy)
        {
            int x;
            x = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("select liquid_volume  from koc.daily_production_data " + "	where daily_production_hdr_s in  " + "		(select daily_production_hdr_s from koc.daily_production_hdr " + "	   where WELL_COMPLETION_S =   " + v_wcs + " " + "		AND  ACTIVITY_TYPE 	= 'ALLOWED' " + "			AND  MATERIAL_TYPE 	= 'OIL' " + "			AND  FLOW_DIR_TYPE 	= 'PRODUCTION' " + "			AND  STATE_TYPE 	= 'STANDARD' " + "			AND  EXISTENCE_TYPE 	= 'ACTUAL'  ) " + "		and	 start_time in  " + "		(select MAX(start_time) from koc.daily_production_data " + "			where start_time < Last_day(to_date('01/" + mm + "/" + yyyy + "', 'dd-mm-yyyy')) " + "			  and  daily_production_hdr_s in " + "				(select daily_production_hdr_s from koc.daily_production_hdr " + "	   where WELL_COMPLETION_S =   " + v_wcs + " " + "				AND  ACTIVITY_TYPE 	= 'ALLOWED' " + "				AND  MATERIAL_TYPE 	= 'OIL' " + "				AND  FLOW_DIR_TYPE 	= 'PRODUCTION' " + "				AND  STATE_TYPE 	= 'STANDARD' " + "			AND  EXISTENCE_TYPE 	= 'ACTUAL') ").FirstOrDefault;
            return x;
        }
        #endregion
        #region Get Facilities Descriptions
        public string GetSurfaceFacilityDescription(int sfs)
        {
            return KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<string>("SELECT sf.facility_id " + " FROM koc.surface_facility sf  " + " WHERE sf.surface_facility_s = " + sfs).FirstOrDefault();
        }
        public string GetPortConnectionFacilityDescription(int PortConnS)
        {
            return KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<string>("SELECT sf.facility_id " + " FROM koc.surface_facility sf ,koc.general_port gp" + " WHERE  sf.surface_facility_s=gb.surface_facility_s " + "   and gp.general_port_s=" + PortConnS).FirstOrDefault();
        }
        #endregion
        #region GC Data Fetch Routine
        public List<cls_GC_ChokeChange_data> GCChokeChange(string pGC, string startdate, string enddate)
        {
            var dr = new List<cls_GC_ChokeChange_data>();
            GC = pGC;
            pStart_date = startdate;
            pEnd_date = enddate;
            dr = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_GC_ChokeChange_data>(" SELECT gc.gc, gc.uwi, gc.well_completion_s, gc.string_name, gc.reservoir, ofo.start_time, ts.left_choke_size, ts.right_choke_size, " + "      ts.created_by, ts.create_date " + " FROM koc.koc_gc_well gc, koc.oil_field_operation ofo, koc.test_stage ts" + " WHERE ts.activity_type = 'CHOKE_SIZE_MODIFICATION'" + "  AND ts.containing_act_s = ofo.oil_field_operation_s" + "  AND ofo.start_time BETWEEN TO_DATE('" + pStart_date + "'||' 05:00', 'DD-MM-YYYY HH24:MI') AND TO_DATE('" + pEnd_date + "'||' 04:59', 'DD-MM-YYYY HH24:MI')" + "  AND ofo.start_time BETWEEN gc.start_time AND NVL(gc.end_time, sysdate)" + "  AND ofo.activity_type = 'TEST'" + "  AND ofo.well_completion_s = gc.well_completion_s" + "  AND gc.gc = UPPER('" + pGC + "') " + "     UNION " + " SELECT gc.gc, gc.uwi, gc.well_completion_s, gc.string_name, gc.reservoir, ofo.start_time, ts.left_choke_size, ts.right_choke_size," + "       ts.created_by, ts.create_date" + " FROM koc.koc_gc_well gc, koc_staging.oil_field_operation ofo, koc_staging.test_stage ts" + " WHERE ts.activity_type = 'CHOKE_SIZE_MODIFICATION'" + "  AND ts.containing_act_s = ofo.oil_field_operation_s" + "  AND ofo.start_time BETWEEN TO_DATE('" + pStart_date + "'||' 05:00', 'DD-MM-YYYY HH24:MI') AND TO_DATE('" + pEnd_date + "'||' 04:59', 'DD-MM-YYYY HH24:MI')" + "  AND ofo.start_time BETWEEN gc.start_time AND NVL(gc.end_time, sysdate)" + "  AND ofo.activity_type = 'TEST'" + "  AND ofo.well_completion_s = gc.well_completion_s" + "   AND gc.gc =  UPPER('" + pGC + "') " + " ORDER BY 1, 2, 4, 5, 6").ToList;
            return dr;
        }
        public object GCTestStatistic(string pGC, string mm, string yyyy)
        {
            var ls = new List<cls_well_test_stats>();
            GC = pGC;
            string v_mth = mm + "-" + yyyy;
            ls = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_well_test_stats>("SELECT gc.uwi, gc.facility_type, gc.reservoir, NVL(ts.activity_name, ts.activity_type) test_name, COUNT(*) Total_no_of_Tests,  " + " SUM(DECODE(ts.activity_type, 'WATER_CUT', DECODE(pp.preferred_flag, 'N', 1, 0), DECODE(ts.preffered_flag, 'N', 1, 0))) RejectedTests, " + " To_Char(sysdate, 'dd-mm-yyyy hh24:mi') today " + " FROM koc.koc_gc_well gc, koc.oil_field_operation ofo, koc.test_stage ts, koc.periodic_production pp " + " WHERE pp.test_stage_s (+) = ts.test_stage_s " + " AND pp.activity_type (+) = 'WATER_CUT' " + "  AND ts.containing_act_s = ofo.oil_field_operation_s " + "  AND ofo.start_time BETWEEN To_Date('01-'||'" + v_mth + "', 'DD-MM-YYYY') AND Last_Day(To_Date('01-'||'" + v_mth + "', 'DD-MM-YYYY'))  " + "  AND ofo.activity_type = 'TEST' " + " AND ofo.well_completion_s = gc.well_completion_s " + " AND gc.start_time < Last_Day(To_Date('01-'||'" + v_mth + "', 'DD-MM-YYYY')) " + " AND (gc.end_time IS NULL OR gc.end_time > To_Date('01-'||'" + v_mth + "', 'DD-MM-YYYY'))  " + "  AND gc.gc =   UPPER('" + pGC + "') " + "  GROUP BY gc.uwi, gc.facility_type, gc.reservoir, ts.activity_name, ts.activity_type " + " ORDER BY gc.uwi, gc.facility_type, gc.reservoir, ts.activity_name, ts.activity_type").ToList;
            return ls;
        }
        public List<cls_report_well_rerouting> GCWellRerouting(string pGC, string startdate, string enddate)
        {
            var ls = new List<cls_report_well_rerouting>();
            GC = pGC;
            pStart_date = startdate;
            pEnd_date = enddate;
            ls = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_report_well_rerouting>("Select distinct 	a.uwi    WELL ,	a.facility_type COMPLETION ,	a.reservoir ,	substr(koc.koc_pack.get_zones(a.well_completion_s),1,8)    ZONE ,b.gc  From_gc, " + " a.gc                   to_gc ," + "     a.start_time, " + "       a.end_time, " + "         a.updated_by, " + "   a.last_update DATE_UPDATED, " + " to_date('" + pStart_date + "','DD-MM-YYYY') + (300/1440) start_rep," + " to_date('" + pEnd_date + "','DD-MM-YYYY') + 1 + (299/1440) end_rep , " + " to_char(sysdate,'dd-mm-yyyy hh24:mi') today" + " from " + " koc.koc_gc_well a, koc.koc_gc_well b " + " where " + " 	a.well_completion_s = b.well_completion_s " + " 	and a.uwi = b.uwi " + " 	and a.reservoir=b.reservoir " + " 	and b.end_time  >= (to_date('" + pStart_date + "','DD-MM-YYYY') + 300/1440) " + " 	and b.end_time   < (to_date('" + pEnd_date + "','DD-MM-YYYY') + 1 + (300/1440)) " + " 	and a.start_time  >= (to_date('" + pStart_date + "','DD-MM-YYYY') + 300/1440) " + " 	and a.start_time   < (to_date('" + pEnd_date + "','DD-MM-YYYY') + 1 + (300/1440)) " + " 	and a.gc =  UPPER('" + pGC + "') " + " 	and b.gc<> a.gc " + " 	and ((nvl(a.wc_end_time,sysdate) >= (to_date('" + pStart_date + "','DD-MM-YYYY') + 300/1440) " + " 	and nvl(a.wc_end_time,sysdate) < (to_date('" + pEnd_date + "','DD-MM-YYYY') + 1 + (300/1440))) " + " 	or a.wc_end_time is null) " + " order by a.uwi , a.start_time ").ToList;

            return ls;

        }
        public List<cls_scale_insp_report> GCScaleInspection(string pGC, string startdate, string enddate)
        {
            var ls = new List<cls_scale_insp_report>();
            GC = pGC;
            pStart_date = startdate;
            pEnd_date = enddate;
            ls = KocConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<cls_scale_insp_report>("SELECT    " + "  wc.GC, " + "    wc.uwi, " + "  wc.facility_type, TO_CHAR(ofo.start_time, 'dd-Mon-yyyy hh24:mi') Start_Time, ofo.remarks Choke_Side,  " + "  ofo.finding_reason choke_status, ofo.finding_code action_on_choke, ofo.description, ofo.inserted_by  " + "   FROM koc.oil_field_operation ofo, koc.koc_gc_well wc " + "  WHERE ofo.activity_type = 'CHOKE' " + "    AND ofo.activity_id = 'CHOKE_CHECK' " + "   AND wc.gc =  UPPER('" + pGC + "') " + "   AND ofo.start_time between to_date('" + pStart_date + "', 'DD-MM-YYYY') and to_date('" + pEnd_date + "', 'DD-MM-YYYY') " + "   AND wc.end_time IS NULL  " + "    AND ofo.well_completion_s = wc.well_completion_s " + "  ORDER BY wc.GC, wc.uwi, wc.well_completion_s, ofo.start_time DESC").ToList;
            return ls;
        }
        #endregion
        #endregion
        #region Other DB Routine
        public int GetSeqValFromIMPRODSTAGING(ref string SeqName)
        {
            return KocConfig.DhubContext.ExecuteStoreQuery<int>("select " + SeqName + ".nextval from dual").FirstOrDefault;
        }
        public void SaveLayoutFileintoDB(cls_file_lib FileID)
        {
            string PathOnly = FileID.FILEPATH;
            string FileName = FileID.FILENAME;
            FileInfo oFile;
            oFile = new FileInfo(FileID.FILEPATH + @"\" + FileID.FILENAME + FileID.id + ".xml");
            byte[] fileData = null;
            var oFileStream = oFile.OpenRead();
            long lBytes = oFileStream.Length;
            if (lBytes > 0L)
            {
                fileData = new byte[(int)(lBytes - 1L + 1)];
                // Read the file into a byte array
                oFileStream.Read(fileData, 0, (int)lBytes);
                oFileStream.Close();
            }
            try
            {
                var myRM_FILE_CONTENT = KocConfig.DhubContext.EXP_FILE_STORAGE.First(x => Operators.ConditionalCompareObjectEqual(x.ID, FileID.id, false));
                myRM_FILE_CONTENT.ID = FileID.id;
                myRM_FILE_CONTENT.UWI = FileID.UWI;
                myRM_FILE_CONTENT.UPDATEBY = FileID.UPDATEBY;
                myRM_FILE_CONTENT.UPDATEDATE = FileID.UPDATEDATE;
                myRM_FILE_CONTENT.TEAMCODE = FileID.TEAMCODE;
                myRM_FILE_CONTENT.TAGS = FileID.TAGS;
                myRM_FILE_CONTENT.REFID = FileID.REFID;
                myRM_FILE_CONTENT.ISSUEDATE = FileID.ISSUEDATE;
                myRM_FILE_CONTENT.INSERTBY = FileID.INSERTBY;
                myRM_FILE_CONTENT.INSERTDATE = FileID.INSERTDATE;
                myRM_FILE_CONTENT.FORMATION = FileID.FORMATION;
                myRM_FILE_CONTENT.FILEPATH = FileID.FILEPATH;
                myRM_FILE_CONTENT.FILENAME = FileID.FILENAME;
                myRM_FILE_CONTENT.FILEBLOB = fileData;
                myRM_FILE_CONTENT.FIELD = FileID.FIELD;
                myRM_FILE_CONTENT.CATEGORY_ID = FileID.CATEGORY_ID;
            }
            // File2Blob(FileID)
            catch (Exception ex)
            {
                var myRM_FILE = new DhubEntities.EXP_FILE_STORAGE();
                myRM_FILE.ID = FileID.id;
                myRM_FILE.UWI = FileID.UWI;
                myRM_FILE.UPDATEBY = FileID.UPDATEBY;
                myRM_FILE.UPDATEDATE = FileID.UPDATEDATE;
                myRM_FILE.TEAMCODE = FileID.TEAMCODE;
                myRM_FILE.TAGS = FileID.TAGS;
                myRM_FILE.REFID = FileID.REFID;
                myRM_FILE.ISSUEDATE = FileID.ISSUEDATE;
                myRM_FILE.INSERTBY = FileID.INSERTBY;
                myRM_FILE.INSERTDATE = FileID.INSERTDATE;
                myRM_FILE.FORMATION = FileID.FORMATION;
                myRM_FILE.FILEPATH = FileID.FILEPATH;
                myRM_FILE.FILENAME = FileID.FILENAME;
                myRM_FILE.FILEBLOB = fileData;
                myRM_FILE.FIELD = FileID.FIELD;
                myRM_FILE.CATEGORY_ID = FileID.CATEGORY_ID;
                KocConfig.DhubContext.EXP_FILE_STORAGE.AddObject(myRM_FILE);
                // File2Blob(FileID)
            }

            try
            {
                KocConfig.DhubContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message);
            }

        }
        public void SaveFileintoDBByName(cls_file_lib FileID)
        {
            string PathOnly = FileID.FILEPATH;
            string FileName = FileID.FILENAME;
            FileInfo oFile;
            oFile = new FileInfo(FileID.FILEPATH + @"\" + FileID.FILENAME);
            byte[] fileData = null;
            var oFileStream = oFile.OpenRead();
            long lBytes = oFileStream.Length;
            if (lBytes > 0L)
            {
                fileData = new byte[(int)(lBytes - 1L + 1)];
                // Read the file into a byte array
                oFileStream.Read(fileData, 0, (int)lBytes);
                oFileStream.Close();
            }
            try
            {
                var myRM_FILE_CONTENT = KocConfig.DhubContext.EXP_FILE_STORAGE.First(x => Operators.ConditionalCompareObjectEqual(x.ID, FileID.id, false));
                myRM_FILE_CONTENT.ID = FileID.id;
                myRM_FILE_CONTENT.UWI = FileID.UWI;
                myRM_FILE_CONTENT.UPDATEBY = FileID.UPDATEBY;
                myRM_FILE_CONTENT.UPDATEDATE = FileID.UPDATEDATE;
                myRM_FILE_CONTENT.TEAMCODE = FileID.TEAMCODE;
                myRM_FILE_CONTENT.TAGS = FileID.TAGS;
                myRM_FILE_CONTENT.REFID = FileID.REFID;
                myRM_FILE_CONTENT.ISSUEDATE = FileID.ISSUEDATE;
                myRM_FILE_CONTENT.INSERTBY = FileID.INSERTBY;
                myRM_FILE_CONTENT.INSERTDATE = FileID.INSERTDATE;
                myRM_FILE_CONTENT.FORMATION = FileID.FORMATION;
                myRM_FILE_CONTENT.FILEPATH = FileID.FILEPATH;
                myRM_FILE_CONTENT.FILENAME = FileID.FILENAME;
                myRM_FILE_CONTENT.FILEBLOB = fileData;
                myRM_FILE_CONTENT.FIELD = FileID.FIELD;
                myRM_FILE_CONTENT.CATEGORY_ID = FileID.CATEGORY_ID;
            }
            // File2Blob(FileID)
            catch (Exception ex)
            {
                var myRM_FILE = new DhubEntities.EXP_FILE_STORAGE();
                myRM_FILE.ID = FileID.id;
                myRM_FILE.UWI = FileID.UWI;
                myRM_FILE.UPDATEBY = FileID.UPDATEBY;
                myRM_FILE.UPDATEDATE = FileID.UPDATEDATE;
                myRM_FILE.TEAMCODE = FileID.TEAMCODE;
                myRM_FILE.TAGS = FileID.TAGS;
                myRM_FILE.REFID = FileID.REFID;
                myRM_FILE.ISSUEDATE = FileID.ISSUEDATE;
                myRM_FILE.INSERTBY = FileID.INSERTBY;
                myRM_FILE.INSERTDATE = FileID.INSERTDATE;
                myRM_FILE.FORMATION = FileID.FORMATION;
                myRM_FILE.FILEPATH = FileID.FILEPATH;
                myRM_FILE.FILENAME = FileID.FILENAME;
                myRM_FILE.FILEBLOB = fileData;
                myRM_FILE.FIELD = FileID.FIELD;
                myRM_FILE.CATEGORY_ID = FileID.CATEGORY_ID;
                KocConfig.DhubContext.EXP_FILE_STORAGE.AddObject(myRM_FILE);
                // File2Blob(FileID)
            }

            try
            {
                KocConfig.DhubContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message);
            }

        }
        public int GetLogHistSEQ()
        {
            var cmd = new OracleCommand();
            cmd.CommandText = "SELECT log_hist_seq.NEXTVAL  FROM DUAL";
            cmd.Connection = KocConfig.DhubDatabaseConnection;

            return cmd.ExecuteScalar().ToString;

        }
        private void Blob2File(cls_file_lib FileID)
        {
            int PictureCol = 0; // the column # of the BLOB field
            var cmd = new Devart.Data.Oracle.OracleCommand("SELECT fileblob FROM exp_file_storage WHERE id=" + FileID.id, KocConfig.DhubDatabaseConnection);

            Devart.Data.Oracle.OracleDataReader dr = cmd.ExecuteReader();
            dr.Read();
            var b = new byte[(dr.GetBytes(PictureCol, 0, default, 0, int.MaxValue))];
            dr.GetBytes(PictureCol, 0, b, 0, b.Length);
            dr.Close();
            var fs = new FileStream(FileID.FILEPATH + @"\" + FileID.FILENAME + FileID.id + ".xml", FileMode.Create, FileAccess.Write);
            fs.Write(b, 0, b.Length);
            fs.Close();
        }
        private void File2Blob(cls_file_lib FileID)
        {

            var cmd = new Devart.Data.Oracle.OracleCommand("UPDATE exp_file_storage SET fileblob=:pfileblob WHERE id=" + FileID.id, KocConfig.DhubDatabaseConnection);
            var fs = new FileStream(FileID.FILEPATH + @"\" + FileID.FILENAME + FileID.id + ".xml", FileMode.Open, FileAccess.Read);
            var b = new byte[(int)(fs.Length - 1L + 1)];
            fs.Read(b, 0, b.Length);
            fs.Close();
            var P = new Devart.Data.Oracle.OracleParameter("pfileblob", OracleDbType.Blob);
            P.Value = b;
            cmd.Parameters.Add(P);
            cmd.ExecuteNonQuery();

        }
        public List<cls_file_lib> LoadFileFromByCategory(string CategoryID)
        {
            var xfilelist = new List<cls_file_lib>();
            string PathOnly = Path.GetDirectoryName(My.MyProject.Application.Info.DirectoryPath);
            string FileName = "";

            var myRM_FILE_CONTENTlist = new List<DhubEntities.EXP_FILE_STORAGE>();

            try
            {
                myRM_FILE_CONTENTlist = (from x in KocConfig.DhubContext.EXP_FILE_STORAGE
                                         where x.CATEGORY_ID.ToUpper == CategoryID.ToUpper() & x.INSERTBY.ToUpper == My.MyProject.User.CurrentPrincipal.Identity.Name.ToUpper()
                                         select x).ToList;
                if (myRM_FILE_CONTENTlist == null == false)
                {
                    foreach (EXP_FILE_STORAGE myRM_FILE_CONTENT in myRM_FILE_CONTENTlist)
                    {
                        FileStream oFileStream;
                        oFileStream = new FileStream(PathOnly + @"\" + myRM_FILE_CONTENT.FILENAME + myRM_FILE_CONTENT.ID + ".xml", FileMode.Create);
                        oFileStream.Write(myRM_FILE_CONTENT.FILEBLOB, 0, myRM_FILE_CONTENT.FILEBLOB.Length);
                        var xfile = new cls_file_lib();
                        xfile.id = myRM_FILE_CONTENT.ID;
                        xfile.UWI = myRM_FILE_CONTENT.UWI;
                        xfile.UPDATEBY = myRM_FILE_CONTENT.UPDATEBY;
                        xfile.UPDATEDATE = myRM_FILE_CONTENT.UPDATEDATE;
                        xfile.TEAMCODE = myRM_FILE_CONTENT.TEAMCODE;
                        xfile.TAGS = myRM_FILE_CONTENT.TAGS;
                        xfile.REFID = myRM_FILE_CONTENT.REFID;
                        xfile.ISSUEDATE = myRM_FILE_CONTENT.ISSUEDATE;
                        xfile.INSERTBY = myRM_FILE_CONTENT.INSERTBY;
                        xfile.INSERTDATE = myRM_FILE_CONTENT.INSERTDATE;
                        xfile.FORMATION = myRM_FILE_CONTENT.FORMATION;
                        xfile.FILEPATH = myRM_FILE_CONTENT.FILEPATH;
                        xfile.FILENAME = myRM_FILE_CONTENT.FILENAME;
                        xfile.FIELD = myRM_FILE_CONTENT.FIELD;
                        xfile.CATEGORY_ID = myRM_FILE_CONTENT.CATEGORY_ID;
                        oFileStream.Close();
                        // Blob2File(xfile)
                        xfilelist.Add(xfile);
                    }

                }

                return xfilelist;
            }
            catch (Exception ex)
            {

                return xfilelist;
            }

        }
        public cls_file_lib LoadFileFromDB(int FileID)
        {
            var xfile = new cls_file_lib();
            string PathOnly = Path.GetDirectoryName(My.MyProject.Application.Info.DirectoryPath);
            string FileName = "";


            var myRM_FILE_CONTENT = new DhubEntities.EXP_FILE_STORAGE();

            try
            {

                myRM_FILE_CONTENT = from x in KocConfig.DhubContext.EXP_FILE_STORAGE
                                    where x.ID == FileID
                                    select x;
                if (myRM_FILE_CONTENT == null == false)
                {
                    FileStream oFileStream;
                    oFileStream = new FileStream(My.MyProject.Application.Info.DirectoryPath + "/" + myRM_FILE_CONTENT.FILENAME, FileMode.Create);
                    oFileStream.Write(myRM_FILE_CONTENT.FILEBLOB, 0, myRM_FILE_CONTENT.FILEBLOB.Length);
                    xfile.id = myRM_FILE_CONTENT.ID;
                    xfile.UWI = myRM_FILE_CONTENT.UWI;
                    xfile.UPDATEBY = myRM_FILE_CONTENT.UPDATEBY;
                    xfile.UPDATEDATE = myRM_FILE_CONTENT.UPDATEDATE;
                    xfile.TEAMCODE = myRM_FILE_CONTENT.TEAMCODE;
                    xfile.TAGS = myRM_FILE_CONTENT.TAGS;
                    xfile.REFID = myRM_FILE_CONTENT.REFID;
                    xfile.ISSUEDATE = myRM_FILE_CONTENT.ISSUEDATE;
                    xfile.INSERTBY = myRM_FILE_CONTENT.INSERTBY;
                    xfile.INSERTDATE = myRM_FILE_CONTENT.INSERTDATE;
                    xfile.FORMATION = myRM_FILE_CONTENT.FORMATION;
                    xfile.FILEPATH = myRM_FILE_CONTENT.FILEPATH;
                    xfile.FILENAME = myRM_FILE_CONTENT.FILENAME;
                    xfile.FIELD = myRM_FILE_CONTENT.FIELD;
                    xfile.CATEGORY_ID = myRM_FILE_CONTENT.CATEGORY_ID;
                    oFileStream.Close();
                }

                return xfile;
            }
            catch (Exception ex)
            {

                return xfile;
            }

        }
        public List<cls_file_lib> LoadFilesFromDBForUWI(string pUWI)
        {
            var myfiles = new List<cls_file_lib>();
            string PathOnly = Path.GetDirectoryName(My.MyProject.Application.Info.DirectoryPath);
            string FileName = "";


            var myRM_FILE_CONTENT = new List<EXP_FILE_STORAGE>();

            try
            {

                myRM_FILE_CONTENT = (from x in KocConfig.DhubContext.EXP_FILE_STORAGE
                                     where x.UWI.ToUpper == pUWI.ToUpper()
                                     select x).ToList;
                if (myRM_FILE_CONTENT == null == false)
                {
                    if (myRM_FILE_CONTENT.Count > 0)
                    {
                        foreach (EXP_FILE_STORAGE myrm in myRM_FILE_CONTENT)
                        {
                            FileStream oFileStream;
                            oFileStream = new FileStream(My.MyProject.Application.Info.DirectoryPath + "/" + myrm.FILENAME, FileMode.Create);
                            oFileStream.Write(myrm.FILEBLOB, 0, myrm.FILEBLOB.Length);
                            var xfile = new cls_file_lib();
                            xfile.id = myrm.ID;
                            xfile.UWI = myrm.UWI;
                            xfile.UPDATEBY = myrm.UPDATEBY;
                            xfile.UPDATEDATE = myrm.UPDATEDATE;
                            xfile.TEAMCODE = myrm.TEAMCODE;
                            xfile.TAGS = myrm.TAGS;
                            xfile.REFID = myrm.REFID;
                            xfile.ISSUEDATE = myrm.ISSUEDATE;
                            xfile.INSERTBY = myrm.INSERTBY;
                            xfile.INSERTDATE = myrm.INSERTDATE;
                            xfile.FORMATION = myrm.FORMATION;
                            xfile.FILEPATH = myrm.FILEPATH;
                            xfile.FILENAME = myrm.FILENAME;
                            xfile.FIELD = myrm.FIELD;
                            xfile.CATEGORY_ID = myrm.CATEGORY_ID;
                            myfiles.Add(xfile);
                            oFileStream.Close();
                        }
                    }
                }
                return myfiles;
            }
            catch (Exception ex)
            {
                return myfiles;
            }

        }
        public List<cls_file_lib> LoadFilesFromDBForField(string field_id)
        {
            var myfiles = new List<cls_file_lib>();
            string PathOnly = Path.GetDirectoryName(My.MyProject.Application.Info.DirectoryPath);
            string FileName = "";


            var myRM_FILE_CONTENT = new List<EXP_FILE_STORAGE>();

            try
            {

                myRM_FILE_CONTENT = (from x in KocConfig.DhubContext.EXP_FILE_STORAGE
                                     where x.FIELD == field_id
                                     select x).ToList;
                if (myRM_FILE_CONTENT == null == false)
                {
                    if (myRM_FILE_CONTENT.Count > 0)
                    {
                        foreach (EXP_FILE_STORAGE myrm in myRM_FILE_CONTENT)
                        {
                            FileStream oFileStream;
                            oFileStream = new FileStream(My.MyProject.Application.Info.DirectoryPath + "/" + myrm.FILENAME, FileMode.Create);
                            oFileStream.Write(myrm.FILEBLOB, 0, myrm.FILEBLOB.Length);
                            var xfile = new cls_file_lib();
                            xfile.id = myrm.ID;
                            xfile.UWI = myrm.UWI;
                            xfile.UPDATEBY = myrm.UPDATEBY;
                            xfile.UPDATEDATE = myrm.UPDATEDATE;
                            xfile.TEAMCODE = myrm.TEAMCODE;
                            xfile.TAGS = myrm.TAGS;
                            xfile.REFID = myrm.REFID;
                            xfile.ISSUEDATE = myrm.ISSUEDATE;
                            xfile.INSERTBY = myrm.INSERTBY;
                            xfile.INSERTDATE = myrm.INSERTDATE;
                            xfile.FORMATION = myrm.FORMATION;
                            xfile.FILEPATH = myrm.FILEPATH;
                            xfile.FILENAME = myrm.FILENAME;
                            xfile.FIELD = myrm.FIELD;
                            xfile.CATEGORY_ID = myrm.CATEGORY_ID;
                            myfiles.Add(xfile);
                            oFileStream.Close();
                        }
                    }
                }
                return myfiles;
            }
            catch (Exception ex)
            {
                return myfiles;
            }

        }
        public int getdocumentIdfromSeq()
        {
            return KocConfig.DhubContext.ExecuteStoreQuery<int>("SELECT EXP_FILE_STORAGE_SEQ.NEXTVAL FROM DUAL").FirstOrDefault;

        }
        public static DataTable ToDataTable<T>(IList<T> data)
        {
            var props = TypeDescriptor.GetProperties(typeof(T));
            var table = new DataTable();

            for (int i = 0, loopTo = props.Count - 1; i <= loopTo; i++)
            {
                var prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }

            var values = new object[props.Count];

            foreach (T item in data)
            {

                for (int i = 0, loopTo1 = values.Length - 1; i <= loopTo1; i++)
                    values[i] = props[i].GetValue(item);

                table.Rows.Add(values);
            }

            return table;
        }
        #endregion
        public Cls_FinderDataList()
        {
        }
    }

    [Serializable()]
    public class cls_fieldrep
    {
        public string Field_code { get; set; }
        public string Field_name { get; set; }

    }
}