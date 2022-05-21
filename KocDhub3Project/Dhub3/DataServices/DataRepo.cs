
using System;
using System.Collections.Generic;
using System.Linq;

using System.Data;
using System.Reflection;
using KOC.DHUB3.Models;
using TheTechIdea.Beep;
using TheTechIdea;
using TheTechIdea.Beep.DataBase;
using Dapper;
using System.Threading.Tasks;

namespace Dhub3.DataServices
{
    public class DataRepo
    {
        public IDMEEditor DMEditor { get; }
        public string DataSourcename { get; }
        public string pStart_date { get; set; }
        public string pEnd_date { get; set; }

        public IDbConnection KocDB;
        public IDataSource DataSource { get; set; }
        private RDBSource RDB { get; set; }
        public RDBDataConnection RDBConn { get; private set; }

        public DataRepo(IDMEEditor dMEditor,string dataSourcename)
        {
            DMEditor = dMEditor;
            DataSourcename = dataSourcename;
            DataSource = dMEditor.GetDataSource(dataSourcename);
            if (DataSource != null)
            {
                DataSource.Openconnection();
                if (DataSource.ConnectionStatus == ConnectionState.Open)
                {
                    RDB = (RDBSource)DataSource;
                    RDBConn = RDB.RDBMSConnection;
                    KocDB = RDBConn.DbConn;
                }
            }
        }
        public DataRepo(IDMEEditor dMEditor, string pStart_date, string pEnd_date)
        {

            DMEditor = dMEditor;
            this.pStart_date = pStart_date;
            this.pEnd_date = pEnd_date;
        }

        public DataRepo(IDbConnection kocDB, string pStart_date, string pEnd_date)
        {
            KocDB = kocDB;
            this.pStart_date = pStart_date;
            this.pEnd_date = pEnd_date;
        }
        #region "Dapper Methods"
        public async Task<IEnumerable<T>> LoadData<T, U>(string querystring,U parameters)
        {
         
            return await KocDB.QueryAsync<T>(querystring, parameters);
        }
        #endregion "Dapper Methods"
        #region "Well Schematics Methods"
        public string GetWellDeviation(string puwi)
        {

            try
            {
                var parameters = new { uwi = puwi };
                return KocDB.QueryAsync<string>(@"SELECT distinct(WELL_DEVIATION) as WELL_DEVIATION FROM KOC_WELL_VV where where UWI=@uwi", parameters).Result.FirstOrDefault();

            }
            catch (Exception ex)
            {
            }
            return null;
        }
        public double ScalarOutDiaTubing(string puwi)
        {

            try
            {
                double r = 0;
                var parameters = new { uwi = puwi };
                var retval = Convert.ToDouble(KocDB.QueryAsync<string>(@"SELECT  MIN(OUTER_DIAMETER) AS OUTER_DIAMETER FROM   WELL_TREE  WHERE   (UWI = @puwi) AND (ACTIVE = \'Y\') AND (END_TIME IS NULL) AND (FACILITY_NAME = \'TUBING\') ORDER BY BOTTOM DESC", parameters).Result.FirstOrDefault());
                if (retval != null)
                {
                    r = Convert.ToDouble(retval);
                }
                return r;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
        public IEnumerable<WELL_TREE> GetWellTree_w_FacilityType(string puwi, string pFACILITY_TYPE)
        {
            try
            {
                var parameters = new { uwi = puwi, FACILITY_TYPE = pFACILITY_TYPE };
                return KocDB.QueryAsync<WELL_TREE>(@"SELECT ACTIVE, BOTTOM, DEFINITION, END_TIME, FACILITY_KEY, FACILITY_NAME, FACILITY_TYPE, GRADE, ID, INNER_DIAMETER, INSERTBY, INSERTDATE, OUTER_DIAMETER, PARENTID, START_TIME, STATUS, TOP, UPDATEBY, UPDATEDATE, UWI, WEIGHT FROM STAGING.WELL_TREE WHERE (UWI = @UWI) AND (ACTIVE = 'Y') AND (FACILITY_TYPE = @FACILITY_TYPE) AND (END_TIME IS NULL) ORDER BY TOP, OUTER_DIAMETER DESC", parameters).Result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public IEnumerable<WELL_TREE> GetCurrentWellTree(string puwi)
        {
            try
            {
                var parameters = new { uwi = puwi };
                return KocDB.QueryAsync<WELL_TREE>(@"SELECT ACTIVE, BOTTOM, DEFINITION, END_TIME, FACILITY_KEY, FACILITY_NAME, FACILITY_TYPE, GRADE, ID, INNER_DIAMETER, INSERTBY, INSERTDATE, OUTER_DIAMETER, PARENTID, START_TIME, STATUS, TOP, UPDATEBY, UPDATEDATE, UWI, WEIGHT FROM STAGING.WELL_TREE WHERE (UWI = @UWI) AND (ACTIVE = 'Y')  AND (END_TIME IS NULL) ORDER BY TOP, OUTER_DIAMETER DESC", parameters).Result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public IEnumerable<WELL_TREE> GetWellTree_w_EndDate(string puwi, string pend_date)
        {
            try
            {
                var parameters = new { uwi = puwi, end_date = pend_date };
                return KocDB.QueryAsync<WELL_TREE>(@"SELECT        ACTIVE, BOTTOM, DEFINITION, END_TIME, FACILITY_KEY, FACILITY_NAME, FACILITY_TYPE, GRADE, ID, INNER_DIAMETER, INSERTBY, INSERTDATE, 
                         OUTER_DIAMETER, PARENTID, START_TIME, STATUS, TOP, UPDATEBY, UPDATEDATE, UWI, WEIGHT
                    FROM            WELL_TREE
                WHERE        ((UWI = @UWI) AND (START_TIME <= to_date(@end_date, 'dd/mm/yyyy')) AND (END_TIME > to_date(@end_date, 'dd/mm/yyyy'))) OR
             ((UWI = @UWI) AND (START_TIME <= to_date(@end_date, 'dd/mm/yyyy')) AND (END_TIME IS NULL)) OR
             ((UWI = @UWI) AND (START_TIME <= to_date(@end_date, 'dd/mm/yyyy')) AND END_TIME = to_date(@end_date, 'dd/mm/yyyy') AND (FACILITY_TYPE = 'PERF') AND (STATUS='CLOSED')) OR
             ((UWI = @UWI) AND (FACILITY_TYPE = 'UWI'))", parameters).Result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public IEnumerable<WELL_TREE> GetCurrentWellTree_NotActive(string puwi)
        {
            try
            {
                var parameters = new { uwi = puwi };
                return KocDB.QueryAsync<WELL_TREE>(@"SELECT * FROM WELL_TREE WHERE (UWI = @UWI)  AND (END_TIME IS NULL) ORDER BY TOP, OUTER_DIAMETER DESC", parameters).Result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public IEnumerable<WELL_TREE> GetCurrentWellTree_WO_DATE(string puwi, string pend_date)
        {
            try
            {
                var parameters = new { uwi = puwi, end_date = pend_date };
                return KocDB.QueryAsync<WELL_TREE>(@"SELECT        ID, PARENTID, UWI, FACILITY_TYPE, START_TIME, END_TIME, ACTIVE, INSERTBY, INSERTDATE, UPDATEBY, UPDATEDATE, FACILITY_KEY, FACILITY_NAME, 
        DEFINITION, TOP, BOTTOM, GRADE, WEIGHT, INNER_DIAMETER, OUTER_DIAMETER, STATUS
        FROM            WELL_TREE
        WHERE(UWI = @UWI) AND(WO_DATE = to_date(@end_date, 'dd/mm/yyyy'))", parameters).Result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public IEnumerable<WELL_DIR_SRVY_PTS> GetWellDirSRVYPTS(string puwi)
        {
            try
            {
                var parameters = new { uwi = puwi };
                return KocDB.QueryAsync<WELL_DIR_SRVY_PTS>(@"SELECT        t.MD, t.TVD, t.MD - t.TVD AS inclination, t.DEVIATION_ANGLE, t.AZIMUTH, t.DX, t.DY
FROM            KOC.WELL_DIR_SRVY_HDR tt INNER JOIN
                         KOC.WELL_DIR_SRVY_PTS t ON tt.UWI = t.UWI AND tt.DIR_SRVY_ID = t.DIR_SRVY_ID
WHERE        (tt.PREFERRED_FLAG = 'Y') AND (tt.UWI = @puwi)", parameters).Result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        #region "Digital Hub Schema"
        public IEnumerable<CasePortableData> GetDCAPortableTestData(int wcs)
        {
            return KocDB.QueryAsync<CasePortableData>("SELECT  well_completion_S,     START_TIME, TEST_TYPE,  TEST_RATE, WC, GOR, WHP, FLP,  ROUND(test_rate * (1 - WC / 100) ) AS OILRATE,  " + " LEFT_CHOKE_SIZE, RIGHT_CHOKE_SIZE, CHOKE " + " FROM WELL_TESTS_VW " + " WHERE     (TEST_TYPE in ('PORTABLE GOR MULTIRATE','PORTABLE')  ) AND (WELL_COMPLETION_S= " + wcs + ") and gor is not null " + "    ORDER BY start_time DESC").Result;
        }
        public IEnumerable<CasePortableData> GetDCAPortableTestDataForField(string FLD_CODE)
        {
            return KocDB.QueryAsync<CasePortableData>("SELECT   b.ppdm_WCS_UWI uwi, b.well_completion_S,    a.START_TIME, a.TEST_TYPE,  a.TEST_RATE, a.WC, a.GOR, a.WHP, a.FLP,  ROUND(a.test_rate * (1 - a.WC / 100) ) AS test_rate,  " + " a.LEFT_CHOKE_SIZE, a.RIGHT_CHOKE_SIZE, a.CHOKE,b.area,b.field_code " + " FROM WELL_TESTS_VW a,well_latest_data b " + " WHERE    (a.well_completion_s=b.well_completion_s)and b.wcc_status='OPEN'  and  (TEST_TYPE in ('PORTABLE GOR MULTIRATE','PORTABLE')  ) AND (b.field_code= '" + FLD_CODE + "') and gor is not null " + "    ORDER BY start_time DESC").Result;
        }
        public IEnumerable<CasePortableData> GetDCAPortableTestDataForArea(string AreaCode)
        {
            return KocDB.QueryAsync<CasePortableData>("SELECT b.ppdm_WCS_UWI uwi, b.well_completion_S a.start_time ,     a.START_TIME, a.TEST_TYPE,  a.TEST_RATE, a.WC, a.GOR, a.WHP, a.FLP,  ROUND(a.test_rate * (1 - a.WC / 100) ) AS test_rate,  " + " a.LEFT_CHOKE_SIZE, a.RIGHT_CHOKE_SIZE, a.CHOKE,b.area,b.field_code " + " FROM WELL_TESTS_VW a,well_latest_data b " + " WHERE    (a.WELL_COMPLETION_S=b.WELL_COMPLETION_S) and  b.wcc_status='OPEN' and  (TEST_TYPE in ('PORTABLE GOR MULTIRATE','PORTABLE')  ) AND (decode('" + AreaCode + "','ALL','ALL',b.area)= '" + AreaCode + "') and gor is not null " + "    ORDER BY start_time DESC").Result;
        }
        public IEnumerable<CasePortableData> GetDCAMaxPortableTestDataForArea2YearsAgo(string AreaCode)
        {
            return KocDB.QueryAsync<CasePortableData>("SELECT    ppdm_WCS_UWI uwi,well_completion_S, ADD_MONTHS(SYSDATE,-24)   start_time, ROUND(max( GET_WCS_LIQUID_RATE_NOB4(B.WELL_COMPLETION_S,ADD_MONTHS(SYSDATE,-24)) * (1 - GET_WCS_WATER_CUT_nob4(B.WELL_COMPLETION_S,ADD_MONTHS(SYSDATE,-24)) / 100)))  AS test_rate     " + " FROM  well_latest_data b   where  (decode('" + AreaCode + "','ALL','ALL',b.area)= '" + AreaCode + "')" + "   group by ADD_MONTHS(SYSDATE,-24),well_completion_S,ppdm_WCS_UWI  having ROUND( max(GET_WCS_LIQUID_RATE_NOB4(B.WELL_COMPLETION_S,ADD_MONTHS(SYSDATE,-24)) * (1 - GET_WCS_WATER_CUT_nob4(B.WELL_COMPLETION_S,ADD_MONTHS(SYSDATE,-24)) / 100))) >0  ORDER BY ROUND(max( GET_WCS_LIQUID_RATE_NOB4(B.WELL_COMPLETION_S,ADD_MONTHS(SYSDATE,-24)) * (1 - GET_WCS_WATER_CUT_nob4(B.WELL_COMPLETION_S,ADD_MONTHS(SYSDATE,-24)) / 100))) DESC  ").Result;
        }
        public IEnumerable<CasePortableData> GetDCAMaxPortableTestDataForField2YearsAgo(string FieldCode)
        {
            return KocDB.QueryAsync<CasePortableData>("SELECT    ppdm_WCS_UWI uwi,well_completion_S, ADD_MONTHS(SYSDATE,-24)   start_time, ROUND(max( GET_WCS_LIQUID_RATE_NOB4(B.WELL_COMPLETION_S,ADD_MONTHS(SYSDATE,-24)) * (1 - GET_WCS_WATER_CUT_nob4(B.WELL_COMPLETION_S,ADD_MONTHS(SYSDATE,-24)) / 100)))  AS test_rate     " + " FROM  well_latest_data b  where FIELD_CODE='" + FieldCode + "'" + "   group by ADD_MONTHS(SYSDATE,-24),well_completion_S,ppdm_WCS_UWI  having ROUND( max(GET_WCS_LIQUID_RATE_NOB4(B.WELL_COMPLETION_S,ADD_MONTHS(SYSDATE,-24)) * (1 - GET_WCS_WATER_CUT_nob4(B.WELL_COMPLETION_S,ADD_MONTHS(SYSDATE,-24)) / 100))) >0  ORDER BY ROUND(max( GET_WCS_LIQUID_RATE_NOB4(B.WELL_COMPLETION_S,ADD_MONTHS(SYSDATE,-24)) * (1 - GET_WCS_WATER_CUT_nob4(B.WELL_COMPLETION_S,ADD_MONTHS(SYSDATE,-24)) / 100))) DESC  ").Result;
        }
        public IEnumerable<CasePortableData> GetDCAMinPortableTestDataForArea(string AreaCode)
        {
            return KocDB.QueryAsync<CasePortableData>("SELECT    ppdm_WCS_UWI uwi,well_completion_S, ADD_MONTHS(SYSDATE,-24)   start_time, ROUND(min( GET_WCS_LIQUID_RATE_NOB4(B.WELL_COMPLETION_S,ADD_MONTHS(SYSDATE,-24)) * (1 - GET_WCS_WATER_CUT_nob4(B.WELL_COMPLETION_S,ADD_MONTHS(SYSDATE,-24)) / 100)))  AS test_rate     " + " FROM  well_latest_data b  " + "   group by ADD_MONTHS(SYSDATE,-24),well_completion_S,ppdm_WCS_UWI  having ROUND( min(GET_WCS_LIQUID_RATE_NOB4(B.WELL_COMPLETION_S,ADD_MONTHS(SYSDATE,-24)) * (1 - GET_WCS_WATER_CUT_nob4(B.WELL_COMPLETION_S,ADD_MONTHS(SYSDATE,-24)) / 100))) >0  ORDER BY ROUND(min( GET_WCS_LIQUID_RATE_NOB4(B.WELL_COMPLETION_S,ADD_MONTHS(SYSDATE,-24)) * (1 - GET_WCS_WATER_CUT_nob4(B.WELL_COMPLETION_S,ADD_MONTHS(SYSDATE,-24)) / 100))) asc  ").Result;
        }
        public IEnumerable<CasePortableData> GetDCAMinFromWellLatestDataPortableTestDataForArea(string AreaCode)
        {
            return KocDB.QueryAsync<CasePortableData>("SELECT       min(LATEST_OIL_RATE) AS test_rate,sysdate  start_time,well_completion_S  " + " FROM well_latest_data b  " + " WHERE    (decode('" + AreaCode + "','ALL','ALL',b.area)= '" + AreaCode + "') and  wcc_status='OPEN' And LATEST_OIL_RATE is not null  and LATEST_OIL_RATE>0 " + "   group by sysdate,well_completion_S   ").Result;
        }
        public CasePortableData GetDCAFromWellLatestDataPortableTestDataForArea(string AreaCode, int wcs)
        {
            return KocDB.QueryAsync<CasePortableData>("SELECT       round(LATEST_OIL_RATE) AS test_rate,  sysdate start_time,well_completion_S  " + " FROM well_latest_data b  " + " WHERE    (decode('" + AreaCode + "','ALL','ALL',b.area)= '" + AreaCode + "') and  wcc_status='OPEN' And LATEST_OIL_RATE is not null   and LATEST_OIL_RATE>0 and well_completion_s=" + wcs + " " + "      ").Result.FirstOrDefault();
        }
        public CasePortableData GetDCAFromWellLatestDataPortableTestDataForField(string FieldCode, int wcs)
        {
            return KocDB.QueryAsync<CasePortableData>("SELECT       round(LATEST_OIL_RATE) AS test_rate,  sysdate start_time,well_completion_S  " + " FROM well_latest_data b  " + " WHERE    field_code= '" + FieldCode + "' and LATEST_OIL_RATE is not null   wcc_status='OPEN' And and LATEST_OIL_RATE>0 and well_completion_s=" + wcs).Result.FirstOrDefault();
        }
        public IEnumerable<CasePortableData> GetDCAavgPortableTestDataForArea2YearsAgo(string AreaCode)
        {
            return (KocDB.QueryAsync<CasePortableData>("SELECT     ADD_MONTHS(SYSDATE,-24)   start_time, ROUND( avg(GET_WCS_LIQUID_RATE_NOB4(B.WELL_COMPLETION_S,ADD_MONTHS(SYSDATE,-24)) * (1 - GET_WCS_WATER_CUT_nob4(B.WELL_COMPLETION_S,ADD_MONTHS(SYSDATE,-24)) / 100)))  AS test_rate     " + " FROM  well_latest_data b  " + "    group by   ADD_MONTHS(SYSDATE,-24)  having ROUND( avg(GET_WCS_LIQUID_RATE_NOB4(B.WELL_COMPLETION_S,ADD_MONTHS(SYSDATE,-24)) * (1 - GET_WCS_WATER_CUT_nob4(B.WELL_COMPLETION_S,ADD_MONTHS(SYSDATE,-24)) / 100))) >0  ")).Result;
        }
        public IEnumerable<CasePortableData> GetDCAAvgPortableTestDataForArea(string AreaCode)
        {
            return (KocDB.QueryAsync<CasePortableData>("SELECT     ROUND(avg (LATEST_OIL_RATE )) AS test_rate,sysdate  start_time    " + " FROM well_latest_data b  " + " WHERE    (decode('" + AreaCode + "','ALL','ALL',b.area)= '" + AreaCode + "') and LATEST_OIL_RATE is not null  and LATEST_OIL_RATE>0 " + "    group by   sysdate    ")).Result;
        }
        #endregion
        #region "OTS Methods"
        public IEnumerable<cls_ESP_DAILY_READING_report> GetWellESPReadingData(string puwi)
        {
            IEnumerable<cls_ESP_DAILY_READING_report> ls;
            ls = KocDB.QueryAsync<cls_ESP_DAILY_READING_report>("select WELL,GC,INSTALLATION_DATE,WELL_COMPLETION_S,READING_DATE_TIME,RECORD_ENTRY_DATE_TIME,PI,PD,WHP,TI,TM,FLP,CURRENT_A,CURRENT_B,CURRENT_C,VOLTAGE_AB, VOLTAGE_BC, VOLTAGE_CA, FREQUENCY, VIBRATION, TANK_LEVEL, REMARKS from ESP_DAILY_READING_VW where UBHI = '" + puwi + "'  order by reading_date_time asc").Result; // and reading_date_time between to_date('" + startdate + "','dd-mm-yyyy') and to_date('" + enddate + "','dd-mm-yyyy')
            //WellLatestDataList.Where(o => o.UWI == puwi).FirstOrDefault.rep_ESP_Reading_report = ls;
            return ls;
        }
        public IEnumerable<cls_ESP_DAILY_READING_report> GetWellESPReadingData(string puwi, string startdate, string enddate)
        {
            IEnumerable<cls_ESP_DAILY_READING_report> ls;
            ls = KocDB.QueryAsync<cls_ESP_DAILY_READING_report>("select WELL,GC,INSTALLATION_DATE,WELL_COMPLETION_S,READING_DATE_TIME,RECORD_ENTRY_DATE_TIME,PI,PD,WHP,TI,TM,FLP,CURRENT_A,CURRENT_B,CURRENT_C,VOLTAGE_AB, VOLTAGE_BC, VOLTAGE_CA, FREQUENCY, VIBRATION, TANK_LEVEL, REMARKS from OTS_DM_ESP_DAILY_READINGS where UBHI = '" + puwi + "' and pi is not null and reading_date_time between '" + startdate + "' and '" + enddate + "' order by reading_date_time asc").Result; // 
            //WellLatestDataList.Where(o => o.UWI == puwi).FirstOrDefault.rep_ESP_Reading_report = ls;
            return ls;
        }
        /// <summary>
        /// Missing
        /// </summary>
        /// <param name="pUWI"></param>
        /// <returns></returns>
        public IEnumerable<cls_survillanceclassreport> GetOTSALMSEventsdata(string pUWI)
        {
            IEnumerable<cls_survillanceclassreport> ls;
            ls = KocDB.QueryAsync<cls_survillanceclassreport>("Select distinct distinct a.well WellName,  a.service_status , a.contractor, a.service_status_date , a.main_job_type , a.service_remarks ,  b.datetime ALM_start_time , b.stopstart, b.remarks ALM_remarks   from OTS_DM_ACTIVITIES_HISTORY a,OTS_DM_al_stopstart_events b where a.well=b.uwi and b.uwi like '" + pUWI + "'  order by service_status_date").Result;
            // WellLatestDataList.Where(o => o.UWI == pUWI).FirstOrDefault.rep_survillance_report = ls;
            return ls;
        }

        /// <summary>
        /// |Missing 
        /// </summary>
        /// <param name="pUWI"></param>
        /// <returns></returns>
        public IEnumerable<cls_ots_dm_al_stopstart_events> GetALMStartStopdata(string pUWI)
        {
            IEnumerable<cls_ots_dm_al_stopstart_events> ls;
            ls = KocDB.QueryAsync<cls_ots_dm_al_stopstart_events>("Select distinct uwi,  datetime start_time , stopstart, remarks ,wstring  from OTS_DM_al_stopstart_events where uwi like '" + pUWI + "'  order by 2").Result;
            //  WellLatestDataList.Where(o => o.UWI == pUWI).FirstOrDefault.rep_survillance_ALMS_StartStopreport = ls;
            return ls;
        }
        public IEnumerable<cls_survillanceclassreport> GetWellSurvillancedata(string pUWI)
        {
            IEnumerable<cls_survillanceclassreport> ls;
            ls = KocDB.QueryAsync<cls_survillanceclassreport>("Select distinct UWI WellName, STATUS service_status , contractor,STATUS service_status_date , ACTIVITY_NAME main_job_type , REMARKS service_remarks  from WIRELINE_ACTIVITY_VW where uwi like '" + pUWI + "'  order by 1").Result;
            // WellLatestDataList.Where(o => o.UWI == pUWI).FirstOrDefault.rep_survillance_report = ls;
            return ls;
        }
        #endregion
        #region "Finder Methods"
        /// <summary>
        /// missing
        /// </summary>
        /// <param name="WCS"></param>
        /// <returns></returns>
        public IEnumerable<WellSCADAcls> GetSCADA(int WCS)
        {
            IEnumerable<WellSCADAcls> dr;
            try
            {
                var parameters = new { wcs = WCS };
                dr = KocDB.QueryAsync<WellSCADAcls>("SELECT start_time FROM WELL_OPERATION_STATUS_VW ofo WHERE ofo.activity_type='SCADA_INSTALL' AND ofo.well_completion_s= @wcs AND ofo.end_time is null", parameters).Result;
                return dr;
            }
            catch (Exception ex)
            {
            }
            return null;
        }
        public IEnumerable<WellHeadercls> GetHeader(int string_s)
        {
            IEnumerable<WellHeadercls> dr;
            try
            {
                var parameters = new { string_s = string_s };
                dr = KocDB.QueryAsync<WellHeadercls>("SELECT pc.start_time, sf.facility_id, sf.surface_facility_s, pc.port_connection_s " + "   FROM koc.port_connection pc, koc.surface_facility sf" + "   WHERE sf.facility_type = 'HEADER'" + "   AND sf.surface_facility_s = pc.to_surface_facility_s" + "   AND pc.end_time IS NULL " + "   AND pc.from_downhole_facility_s = @string_s " + "  ORDER BY pc.start_time DESC", parameters).Result;


                return dr;
            }
            catch (Exception ex)
            {
            }
            return null;
        }
        public IEnumerable<WellSlotCls> GetSlot(int string_s)
        {
            IEnumerable<WellSlotCls> dr;
            try
            {
                var Parameters = new { string_s = string_s };
                dr = KocDB.QueryAsync<WellSlotCls>("  SELECT gp.general_port_s, pc.start_time, sf.facility_id, gp_s.general_port_s slot_gp_s, pc.port_connection_s " + "    FROM koc.general_port gp, koc.general_port gp_s, koc.port_connection pc, koc.surface_facility sf " + "   WHERE sf.facility_type (+) = 'INCOMMER' " + "    AND sf.surface_facility_s (+) = gp_s.surface_facility_s " + "    AND gp_s.general_port_s (+) = pc.to_port_s " + "    AND pc.end_time (+) IS NULL " + "    AND pc.from_port_s (+) = gp.general_port_s " + "    AND gp.downhole_facility_s = @string_s " + " ORDER BY pc.start_time DESC", Parameters).Result;


                return dr;
            }
            catch (Exception ex)
            {
            }
            return null;
        }
        public IEnumerable<WellLiftMethodcls> GetLiftMethod(int WCS)
        {
            IEnumerable<WellLiftMethodcls> dr;
            try
            {
                var Parameters = new { wcs = WCS };
                dr = KocDB.QueryAsync<WellLiftMethodcls>("  SELECT fs.status_type, rfs.description, ofo.start_time" + " FROM koc.oil_field_operation ofo, koc.facility_status fs, codes.r_facility_status rfs " + " WHERE rfs.source_type = 'LIFT_METHOD' " + "   AND rfs.type = fs.status_type " + "   AND fs.start_oil_field_operation_s = ofo.oil_field_operation_s " + "   AND ofo.activity_type = 'LIFT_METHOD_CHANGE' " + "  AND ofo.well_completion_s = @wcs " + " ORDER BY ofo.start_time DESC", Parameters).Result;


                return dr;
            }
            catch (Exception ex)
            {
            }
            return null;
        }
        public string GetMFL(int v_wcs)
        {
            string x = "";
            x = KocDB.QueryAsync<string>("select   mfl   from koc.koc_mult_flowline     where wc_s=" + v_wcs).Result.FirstOrDefault();
            return x;
        }
        public string String_Connection_Header(int string_S)
        {
            string hdr;
            hdr = KocDB.QueryAsync<string>("SELECT sf.facility_id " + " FROM koc.surface_facility sf, koc.port_connection pc " + " WHERE sf.facility_type = 'HEADER' " + "   AND sf.surface_facility_s = pc.to_surface_facility_s " + "   AND (pc.end_time IS NULL OR pc.end_time > TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1) " + "   AND pc.start_time < TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1 " + "  AND pc.from_downhole_facility_s =" + string_S + " " + "  ORDER BY pc.start_time DESC").Result.FirstOrDefault();
            return hdr;
        }
        public string GetESP(int UWI)
        {
            string dr;
            try
            {
                var Parameters = new { UWI = UWI };
                dr = KocDB.QueryAsync<string>(" SELECT decode(facility_type,'ESP_SYSTEM','Y',null) ESP FROM koc.downhole_facility  WHERE UWI = @uwi  AND facility_type = 'ESP_SYSTEM'  AND end_time is null", Parameters).Result.FirstOrDefault();

                return dr;
            }
            catch (Exception ex)
            {
            }
            return null;
        }
        public IEnumerable<WellAllowedcls> GetAllowed(int WCS)
        {
            IEnumerable<WellAllowedcls> dr;
            try
            {
                var Parameters = new { wcs = WCS };
                dr = KocDB.QueryAsync<WellAllowedcls>("  select liquid_volume,start_time  from koc.daily_production_data " + "  where daily_production_hdr_s in  " + "	(select daily_production_hdr_s from koc.daily_production_hdr  " + "	  where well_completion_s = @wcs   " + "		AND  ACTIVITY_TYPE 	= 'ALLOWED'  " + "		AND  MATERIAL_TYPE 	= 'OIL'  " + "		AND  FLOW_DIR_TYPE 	= 'PRODUCTION'  " + "		AND  STATE_TYPE 	= 'STANDARD'  " + "		AND  EXISTENCE_TYPE 	= 'ACTUAL'  ) order by start_time desc", Parameters).Result;
                return dr;
            }
            catch (Exception ex)
            {
            }
            return null;
        }
        public IEnumerable<StatusCls> GetESPStatus(int WCS)
        {
            IEnumerable<StatusCls> dr;
            try
            {
                var Parameters = new { wcs = WCS };
                dr = KocDB.QueryAsync<StatusCls>("SELECT fs.status_type, fs.reason, ofo.start_time, ofo.oil_field_operation_s, fs.facility_status_s " + " FROM koc.oil_field_operation ofo, koc.facility_status fs " + "  WHERE fs.start_oil_field_operation_s = ofo.oil_field_operation_s " + " AND ofo.activity_type = 'ESP_STATUS_CHANGE' " + " AND ofo.well_completion_s = @wcs " + " ORDER BY ofo.start_time DESC", Parameters).Result;




                return dr;
            }
            catch (Exception ex)
            {
            }
            return null;
        }
        public IEnumerable<StatusCls> GetStatus(int WCS)
        {
            IEnumerable<StatusCls> dr;
            try
            {
                var Parameters = new { wcs = WCS };
                dr = KocDB.QueryAsync<StatusCls>("SELECT fs.status_type, fs.reason, ofo.start_time, ofo.oil_field_operation_s, fs.facility_status_s " + " FROM koc.oil_field_operation ofo, koc.facility_status fs " + "  WHERE fs.start_oil_field_operation_s = ofo.oil_field_operation_s " + " AND ofo.activity_type = 'FACILITY_STATUS_CHANGE' " + " AND ofo.well_completion_s = @wcs " + " ORDER BY ofo.start_time DESC", Parameters).Result;



                return dr;
            }
            catch (Exception ex)
            {
            }
            return null;
        }
        public IEnumerable<StatusCls> GetStatusatDate(int WCS, string pdate)
        {
            IEnumerable<StatusCls> dr;
            try
            {
                var Parameters = new { wcs = WCS };
                dr = KocDB.QueryAsync<StatusCls>("SELECT fs.status_type, fs.reason, ofo.start_time, ofo.oil_field_operation_s, fs.facility_status_s " + " FROM koc.oil_field_operation ofo, koc.facility_status fs " + "  WHERE fs.start_oil_field_operation_s = ofo.oil_field_operation_s " + " AND ofo.activity_type = 'FACILITY_STATUS_CHANGE'" + " and  ofo.start_time <=to_date('" + pdate + " 05:00:00" + "', 'dd-mm-yyyy HH24:MI:SS')" + " AND ofo.well_completion_s = @wcs " + " ORDER BY ofo.start_time DESC", Parameters).Result;



                return dr;
            }
            catch (Exception ex)
            {
            }
            return null;
        }
        public IEnumerable<cls_WellCurrentGC> GetGCWELL(int pwcs)
        {
            IEnumerable<cls_WellCurrentGC> dr;
            try
            {
                var Parameters = new { wcs = pwcs };
                dr = KocDB.QueryAsync<cls_WellCurrentGC>("select sf.facility_id   GC , wc.uwi                       UWI ," + " wc.facility_type   FACILITY_TYPE ," + " substr(wc.facility_name,1,12)   STRING_NAME," + " re.reservoir_id        RESERVOIR ," + " substr(koc_pack.get_zones(wc.well_completion_s),1,40) ZONE," + " pc.start_time                    ," + " pc.end_time                      ," + " pc.created_by                    ," + " pc.create_date                   ," + " pc.updated_by                    ," + " pc.last_update                   ," + " sf.surface_facility_s            ," + " pc.port_connection_s             ," + " wc.string_s                      ," + " wc.well_completion_s             ," + " wc.reservoir_s                   ," + " wc.start_time      WC_START_TIME ," + " wc.end_time WC_END_TIME" + " from" + " port_connection pc,surface_facility sf,well_completion wc,reservoir re" + " where " + "     pc.connection_type          = 'BA-NETWORK'" + " and pc.to_surface_facility_s    = sf.surface_facility_s" + " and pc.from_downhole_facility_s = wc.string_s" + " and wc.well_completion_s =@wcs  and wc.reservoir_s(+)           = re.reservoir_s order by pc.start_time desc", Parameters).Result;

                return dr;
            }
            catch (Exception ex)
            {
            }
            return null;
        }
        public IEnumerable<WellBasicDatacls> GetWellBasicInfo(string pUWI)
        {
            IEnumerable<WellBasicDatacls> dr;
            try
            {
                var Parameters = new { UWI = pUWI };
                dr = KocDB.QueryAsync<WellBasicDatacls>("SELECT well_completion_s, uwi, DECODE(facility_type, 'TUBING', 'T', 'CASING', 'C', 'BOTH', 'B', 'TUBING LONG', 'TL', 'TUBING SHORT', 'TS') stringid,string_name, facility_type, reservoir, string_s, wc_start_time " + "     FROM koc.koc_gc_well " + "  AND end_time IS NULL AND wc_end_time IS NULL" + "  AND uwi LIKE NVL(@uwi, '%') " + "  ORDER BY uwi, facility_type", Parameters).Result;

                return dr;
            }
            catch (Exception ex)
            {
            }
            return null;
        }
        public IEnumerable<PortableMultiRate> GetPortableTestMultiRateData(int wcs)
        {
            return KocDB.QueryAsync<PortableMultiRate>("SELECT   UWI, STRING WellSTRING, RESR_ID, START_TIME, END_TIME, DURATION, CONTRACTOR, REPORT_NUMBER, T_FLOW_PERIOD, ACTIVITY_TYPE, " + " ACTUAL_CHOKE, C_PRESS, T_PRESS, WHT, FLP, FLOW_P_NO, CRITICAL_FLOW, F_DURATION, TEST_CHOKE, CHOKE_LC, CHOKE_RC, CHOKE_LT, " + " CHOKE_RT, LEFT_CHOKE_SIZE, RIGHT_CHOKE_SIZE, LIQUID_RATE, WATER_RATE, REMARKS, WATER_CUT, TOTAL_GOR, GAS_RATE, HP_GOR, " + " SEP_PRESS, SEP_TEMP, LP_GOR, FORMATION_GOR, TOTAL_GLR, INJECTION_GLR, API, SPECIFIC_GRAVITY, SHRINKAGE_FACTOR, " + "  WATER_SALINITY, WELL_COMPLETION_S" + " FROM   PORTABLE_MULTRATE_V " + " WHERE    WELL_COMPLETION_S= " + wcs + " " + "    ORDER BY start_time,FLOW_P_NO DESC").Result;
        }
        public IEnumerable<PortableData> GetPortableTestData(int wcs)
        {
            return KocDB.QueryAsync<PortableData>("SELECT    well_completion_S,   START_TIME, TEST_TYPE,  TEST_RATE, WC, GOR, WHP, FLP,  ROUND(test_rate * (1 - WC / 100) ) AS OILRATE, ROUND(GOR*test_rate/1000,3)  AS GASRATE," + " LEFT_CHOKE_SIZE, RIGHT_CHOKE_SIZE, CHOKE " + " FROM WELL_TESTS_VW " + " WHERE     (TEST_TYPE in ('PORTABLE GOR MULTIRATE','PORTABLE')  ) AND (WELL_COMPLETION_S= " + wcs + ") and gor is not null " + "    ORDER BY start_time DESC").Result;
        }
        public IEnumerable<WaterCutData> GetWaterCutTestData(int wcs)
        {
            return KocDB.QueryAsync<WaterCutData>("SELECT DISTINCT WT.WELL_COMPLETION_S, WT.UWI, WT.FACILITY_TYPE,  WT.ACTIVITY_TYPE, WT.ACTIVITY_NAME, WT.START_TIME, WT.LIQUID_RATE, WT.CASING_PRESSURE, WT.TUBING_PRESSURE, WT.FLOW_LINE_PRESSURE, WT.LEFT_CHOKE_SIZE, WT.RIGHT_CHOKE_SIZE, WT.WATER_RATE,pp.nominal_water_cut, GET_WCS_SALT_uwi(WT.UWI, TO_CHAR(WT.START_TIME, 'dd/mm/yyyy')) AS SALT, PP.ACTIVITY_TYPE AS TEST_TYPE FROM  TEST_STAGE WT , PERIODIC_PRODUCTION(PP) WHERE     (PP.ACTIVITY_TYPE = 'WATER_CUT') AND (PP.PREFERRED_FLAG = 'Y') AND  (WT.WELL_COMPLETION_S =" + wcs + ") AND  WT.TEST_STAGE_S = PP.TEST_STAGE_S ORDER BY WT.START_TIME DESC").Result;
        }
        public IEnumerable<DCSData> GetDCSTestData(int wcs)
        {
            // 
            return KocDB.QueryAsync<DCSData>("SELECT       START_TIME, TEST_TYPE, TEST_RATE, WC, GOR, WHP, FLP,  ROUND(test_rate * (100 - WC / 100) ) AS OILRATE,  " + " LEFT_CHOKE_SIZE, RIGHT_CHOKE_SIZE, CHOKE " + " FROM WELL_TESTS_VW " + " WHERE     (TEST_TYPE ='DCS' ) AND (WELL_COMPLETION_S= " + wcs + ")  " + "    ORDER BY start_time DESC").Result;
        }
        public IEnumerable<FluidAnalysisData> GetFuildAnalysis(int wcs)
        {
            return KocDB.QueryAsync<FluidAnalysisData>(" SELECT DISTINCT wc.well_completion_s, wc.uwi, wc.facility_type, wc.start_time wc_dt, rs.reservoir_id, fa.start_time, fa.oil_field_operation_s, fa.pressure, fa.temperature,fs.api_gravity, fs.specific_gravity,SUM(DECODE(mc.component_material_type, 'SALT', mc.concentration)) SALT, SUM(DECODE(mc.component_material_type, 'SULPHUR', mc.concentration)) SULPHUR  FROM koc.well_completion wc, koc.reservoir rs, koc.fluid_analysis fa,koc.fluid_analysis fa1,koc.fluid_state_pty fs,koc.material_composition mc, koc.fluid_analysis fa2   WHERE (wc.reservoir_s = rs.reservoir_s) AND fa.well_completion_s = wc.well_completion_s  and fs.project_fluid_analysis_s = fa1.fluid_analysis_s AND fa1.oil_field_operation_s = fa.oil_field_operation_s AND fa.activity_type IN ('FLUID_ANALYSIS', 'SALT_CONTENT', 'SULPHUR_CONTENT_OF_OIL', 'SPECIFIC_GRAVITY_OF_OIL') AND fa1.oil_field_operation_s IS NOT NULL AND fs.api_gravity IS NOT NULL  AND fs.material_type = 'GAS'  and mc.component_material_type IN ('SALT', 'SULPHUR')  AND mc.project_fluid_analysis_s = fa2.fluid_analysis_s AND fa2.oil_field_operation_s = fa.oil_field_operation_s AND fa2.activity_type IN ('FLUID_ANALYSIS', 'SALT_CONTENT', 'SULPHUR_CONTENT_OF_OIL') AND fa2.start_time = fa.start_time AND fa2.well_completion_s = fa.well_completion_s AND wc.well_completion_s =" + wcs + "  GROUP BY fa.start_time, fa.oil_field_operation_s, wc.well_completion_s, wc.uwi, wc.facility_type, wc.start_time,  rs.reservoir_id, fa.start_time, fa.oil_field_operation_s, fa.pressure, fa.temperature, fs.api_gravity, fs.specific_gravity  HAVING count(*)  = 1  ORDER BY wc.uwi, fa.start_time desc").Result;
        }
        public IEnumerable<TestStageData> GetTestStageData(int wcs)
        {
            return KocDB.QueryAsync<TestStageData>("SELECT    START_TIME as starttime, TEST_TYPE, TEST_RATE, WC, GOR, WHP, FLP, LEFT_CHOKE_SIZE, RIGHT_CHOKE_SIZE, CHOKE, WELL_COMPLETION_S, UWI   FROM  WELL_TESTS_VW  WHERE        (TEST_TYPE ='DCS') AND (WELL_COMPLETION_S = " + wcs + ") ORDER BY START_TIME desc").Result;
        }
        public IEnumerable<FBHPclassreport> GetFBHPDataForFieldandRes(string FldID, string resid)
        {
            IEnumerable<FBHPclassreport> x;
            x = KocDB.QueryAsync<FBHPclassreport>("  a.start_time,a.pressure,a.temperature,a.depth,b.PPDM_WCS_UWI,b.RESERVOIR_ID from koc.test_stage@FINDERWEB_ORB_DBLINK a,well_latest_data b " + " where a.activity_type='FBHP'" + " and a.well_completion_s=b.well_completion_s" + "  b.field_id = '" + FldID + "'" + "  b.reservoir_id = '" + resid + "'" + "  ORDER BY a.START_TIME desc").Result;

            return x;
        }
        public IEnumerable<FBHPclassreport> GetSBHPDataForFieldandRes(string FldID, string resid)
        {
            IEnumerable<FBHPclassreport> x;
            x = KocDB.QueryAsync<FBHPclassreport>("  a.start_time,a.pressure,a.temperature,a.depth,b.PPDM_WCS_UWI,b.RESERVOIR_ID from koc.test_stage@FINDERWEB_ORB_DBLINK a,well_latest_data b " + " where a.activity_type='SBHP'" + " and a.well_completion_s=b.well_completion_s" + "  b.field_id = '" + FldID + "'" + "  b.reservoir_id = '" + resid + "'" + "  ORDER BY a.START_TIME desc").Result;

            return x;
        }
        public IEnumerable<FBHPclassreport> GetFBHPData(int wcs)
        {
            IEnumerable<FBHPclassreport> x;
            x = KocDB.QueryAsync<FBHPclassreport>("SELECT   ofo.uwi, ofo.start_time, ofo.activity_type, ofo.activity_name," + "          ofo.existence_type, ts.state_type, tsum.stabilized_flow_period," + "      ts.DEPTH, ts.pressure, ta.pressure_datum," + "        ta.extrapolated_pressure, ta.gradient, ts.static_gradient," + "        ts.temperature, ts.casing_pressure, ts.tubing_pressure," + "       ts.well_head_temp, ts.preffered_flag, ofo.SOURCE," + "       eu.description gauge_number, eu.equipment_role, eu.equipment_type," + "       ofo.business_assoc_id, ofo.operation_number, ofo.engineer," + "      ofo.remarks, koc.wellcalc.tvdepth (ofo.uwi, ts.DEPTH) depth_tvd," + "       CASE" + "           WHEN (  koc.wellcalc.tvdepth (ofo.uwi, ts.DEPTH)" + "                - LAG (koc.wellcalc.tvdepth (ofo.uwi, ts.DEPTH)) OVER (PARTITION BY ofo.oil_field_operation_s ORDER BY DEPTH ASC)" + "               ) > 0" + "            THEN ROUND" + "                    ((  (  pressure- LAG (pressure) OVER (PARTITION BY ofo.oil_field_operation_s ORDER BY DEPTH ASC))/( koc.wellcalc.tvdepth (ofo.uwi, ts.DEPTH) - LAG (koc.wellcalc.tvdepth (ofo.uwi, ts.DEPTH)) OVER (PARTITION BY ofo.oil_field_operation_s ORDER BY DEPTH ASC))),3 )" + "          ELSE NULL" + "        END gradient_tvd," + "         ts.remarks ts_remarks, ofo.oil_field_operation_s," + "          ofo.well_completion_s, ofo.insert_date, ofo.inserted_by," + "         ofo.last_update, ofo.updated_by" + "    FROM koc.oil_field_operation ofo," + "         koc.test_summary tsum," + "         koc.test_stage ts," + "        koc.test_analysis ta," + " koc.equipment_used eu" + " WHERE ofo.activity_type ='FBHP' " + " AND ofo.oil_field_operation_s = tsum.containing_act_s(+)" + " AND ofo.well_completion_s = " + wcs + " AND ofo.oil_field_operation_s = ts.containing_act_s(+)" + " And ofo.oil_field_operation_s = ta.containing_act_s(+)" + " AND ofo.oil_field_operation_s = eu.oil_field_operation_s(+)").Result;

            return x;
        }
        public IEnumerable<FBHPclassreport> GetSBHPData(int wcs)
        {
            IEnumerable<FBHPclassreport> x;
            x = KocDB.QueryAsync<FBHPclassreport>("SELECT   ofo.uwi, ofo.start_time, ofo.activity_type, ofo.activity_name," + "          ofo.existence_type, ts.state_type, tsum.stabilized_flow_period," + "      ts.DEPTH, ts.pressure, ta.pressure_datum," + "        ta.extrapolated_pressure, ta.gradient, ts.static_gradient," + "        ts.temperature, ts.casing_pressure, ts.tubing_pressure," + "       ts.well_head_temp, ts.preffered_flag, ofo.SOURCE," + "       eu.description gauge_number, eu.equipment_role, eu.equipment_type," + "       ofo.business_assoc_id, ofo.operation_number, ofo.engineer," + "      ofo.remarks, koc.wellcalc.tvdepth (ofo.uwi, ts.DEPTH) depth_tvd," + "       CASE" + "           WHEN (  koc.wellcalc.tvdepth (ofo.uwi, ts.DEPTH)" + "                - LAG (koc.wellcalc.tvdepth (ofo.uwi, ts.DEPTH)) OVER (PARTITION BY ofo.oil_field_operation_s ORDER BY DEPTH ASC)" + "               ) > 0" + "            THEN ROUND" + "                    ((  (  pressure- LAG (pressure) OVER (PARTITION BY ofo.oil_field_operation_s ORDER BY DEPTH ASC))/( koc.wellcalc.tvdepth (ofo.uwi, ts.DEPTH) - LAG (koc.wellcalc.tvdepth (ofo.uwi, ts.DEPTH)) OVER (PARTITION BY ofo.oil_field_operation_s ORDER BY DEPTH ASC))),3 )" + "          ELSE NULL" + "        END gradient_tvd," + "         ts.remarks ts_remarks, ofo.oil_field_operation_s," + "          ofo.well_completion_s, ofo.insert_date, ofo.inserted_by," + "         ofo.last_update, ofo.updated_by" + "    FROM koc.oil_field_operation ofo," + "         koc.test_summary tsum," + "         koc.test_stage ts," + "        koc.test_analysis ta," + " koc.equipment_used eu" + " WHERE ofo.activity_type ='SBHP' " + " AND ofo.oil_field_operation_s = tsum.containing_act_s(+)" + " AND ofo.well_completion_s = " + wcs + " AND ofo.oil_field_operation_s = ts.containing_act_s(+)" + " And ofo.oil_field_operation_s = ta.containing_act_s(+)" + " AND ofo.oil_field_operation_s = eu.oil_field_operation_s(+)").Result;
            return x;
        }
        public IEnumerable<cls_rigactivityreport> GetWellRigActivitesfordata(string pUWI)
        {
            IEnumerable<cls_rigactivityreport> ls;
            // GetNewOldConnectedWells(pGC)
            ls = KocDB.QueryAsync<cls_rigactivityreport>("SELECT R.RIG_NAME,CW.WELL_COMMON_NAME WellName,D.DATE_REPORT,D.STATUS status_type,D.COMMENT_SUMMARY DDR_REPORT,D.DAYS_ON_LOCATION,D.DAYS_FROM_SPUD,D.TREE_CONDITION NEXT_LOC FROM EDMADMIN.DM_DAILY D,EDMADMIN.CD_WELL_SOURCE  CW,EDMADMIN.CD_RIG R,  EDMADMIN.dm_report_journal RJ WHERE D.WELL_ID= CW.WELL_ID    AND R.RIG_ID= RJ.RIG_ID AND D.REPORT_JOURNAL_ID=RJ.REPORT_JOURNAL_ID   and cw.WELL_COMMON_NAME = '" + pUWI + "' ORDER BY 2,3 DESC").Result;
            // WellLatestDataList.Where(o => o.UWI == pUWI).FirstOrDefault.rep_RigAcivities_report = ls;
            return ls;
        }
        /// <summary>
        /// Missing Functions
        /// </summary>
        /// <param name="v_wcs"></param>
        /// <returns></returns>
        public IEnumerable<cls_ba> GetBAData(int v_wcs)
        {
            return KocDB.QueryAsync<cls_ba>("SELECT     UBHI, OIL_VOLUME AS TOTOIL, WATER_VOLUME AS TOTWater, GAS_VOLUME AS TOTGAS,PRODUCTION_DATE " + "      AS proddate,  GET_WCS_WATER_CUT(WELL_COMPLETION_S,   " + "     to_char(PRODUCTION_DATE,'dd/mm/yyyy')) AS WC," + "    decode(WATER_VOLUME,0,0,(WATER_VOLUME   / (WATER_VOLUME + OIL_VOLUME))*100) AS ba_wc,  GET_WCS_LIQUID_RATE(WELL_COMPLETION_S,  to_char(PRODUCTION_DATE,'dd/mm/yyyy')) AS lq, " + " WELL_COMPLETION_S FROM PRODUCTION_HISTORY_VW   WHERE WELL_COMPLETION_S =" + v_wcs + " ORDER BY PRODUCTION_DATE").Result;
        }
        public IEnumerable<cls_proddata> GetProdData(string puwi, int pwcs, int pmonths)
        {
            return KocDB.QueryAsync<cls_proddata>("select     TO_CHAR(d.start_time,'YYYY/MM')   LASTMONTH,  " + "     round(sum(decode(material_type,'OIL',d.liquid_volume))) oil ,   " + "     round(sum(decode(material_type ,'GAS',d.GAS_volume))) gas,  " + "     round(sum(decode(material_type, 'WATER',d.liquid_volume))) water  " + "      from " + "     koc.monthly_production_hdr  h,  " + "         koc.MONTHLY_PRODUCTION_DATA d, " + "        koc.WELL_COMPLETION w, " + "         koc.RESERVOIR      rr    where " + "          d.monthly_production_hdr_s = h.monthly_production_hdr_s  " + "     and h.well_completion_s=w.well_completion_s  " + "     and h.flow_dir_type='PRODUCTION'  " + "     and h.activity_Type='ALLOCATED'  " + "     and rr.reservoir_s=w.reservoir_s  " + "     and w.uwi='" + puwi + "'" + "     and h.well_completion_s=" + pwcs + "     and  trunc(d.start_time) >= trunc(add_months(sysdate,-1 * " + pmonths + "))  " + "      Group by    TO_CHAR(d.start_time,'YYYY/MM')     order by 1 asc").Result;
        }
        public cls_prepostdata GetWellPrePostData(int v_wcs, string pdate, string cond)
        {
            return KocDB.QueryAsync<cls_prepostdata>(" SELECT  " + v_wcs + "  AS Completion_No, ' " + pdate + "'  AS Entered_Date,   GET_PREPOST_WCS_BHP(" + v_wcs + ",  to_date('" + pdate + "','dd/mm/yyyy')   , 'FBHP',  '" + cond + "' ) AS FBHP,   Get_PREPOST_Wcs_Perf(" + v_wcs + ",  to_date('" + pdate + "','dd/mm/yyyy')   ,  '" + cond + "' ) AS Perf,   GET_PREPOST_WCS_CHOKE(" + v_wcs + ",  to_date('" + pdate + "','dd/mm/yyyy')   , '" + cond + "' ) AS CHOKE,   Get_PREPOST_Wcs_PI(" + v_wcs + ",  to_date('" + pdate + "','dd/mm/yyyy')   ,  '" + cond + "' ) AS PI,   GET_PREPOST_ESP_TYPE(" + v_wcs + ",  to_date('" + pdate + "','dd/mm/yyyy')   ,  '" + cond + "' ) AS ESP_TYPE,   GET_PREPOST_WCS_LQ_RATE(" + v_wcs + ",  to_date('" + pdate + "','dd/mm/yyyy')   ,  '" + cond + "' ) AS Liquid_rate,   GET_PREPOST_WCS_GOR(" + v_wcs + ",  to_date('" + pdate + "','dd/mm/yyyy')   ,  '" + cond + "' ) AS GOR,   GET_PREPOST_WCS_WATER_CUT(" + v_wcs + ",  to_date('" + pdate + "','dd/mm/yyyy')   ,  '" + cond + "' ) AS WC,   GET_PREPOST_WCS_BHP(" + v_wcs + ",  to_date('" + pdate + "','dd/mm/yyyy')   , 'SBHP',  '" + cond + "' ) AS SBHP,    GET_PREPOST_WCS_WHP(" + v_wcs + ", to_date('" + pdate + "','dd/mm/yyyy')   ,  '" + cond + "' ) AS WHP  FROM DUAL").Result.FirstOrDefault();
        }
        public cls_outvaluewithdate Completion_GOR(int v_wcs)
        {
            cls_outvaluewithdate mat;
            mat = KocDB.QueryAsync<cls_outvaluewithdate>("  select  NOMINAL_GOR outvalue,pp.start_Time outdate" + " from koc.periodic_productIon  pp " + "    where " + "      activity_type      =  'TOTAL_GOR'" + " and               pp.well_Completion_s=" + v_wcs + " " + " and               preferred_flag='Y'" + " and               NOMINAL_GOR is not null" + " and               pp.start_Time <=to_date('" + pStart_date + "','dd/mm/yyyy')" + " Order by     start_time desc").Result.FirstOrDefault();
            return mat;
        }
        public cls_outvaluewithdate Completion_GOR_AfterStartDate(int v_wcs)
        {
            cls_outvaluewithdate mat;
            mat = KocDB.QueryAsync<cls_outvaluewithdate>("  select  NOMINAL_GOR outvalue,pp.start_Time outdate" + " from koc.periodic_productIon  pp " + "    where " + "      activity_type      =  'TOTAL_GOR'" + " and               pp.well_Completion_s=" + v_wcs + " " + " and               preferred_flag='Y'" + " and               NOMINAL_GOR is not null" + " and               pp.start_Time >to_date('" + pStart_date + "','dd/mm/yyyy')+1" + " Order by     start_time asc").Result.FirstOrDefault();
            return mat;
        }
        public cls_Comp_oper_status CompletionsOperationalStatus(int v_wcs)
        {
            IEnumerable<cls_Comp_oper_status> x;
            x = KocDB.QueryAsync<cls_Comp_oper_status>(" SELECT ofo.start_time, fs.status_type,fs.reason " + " FROM koc_staging.s_oil_field_operation ofo, koc_staging.s_facility_status fs " + "     WHERE(fs.start_oil_field_operation_s = ofo.oil_field_operation_s) " + "AND ofo.activity_type = 'FACILITY_STATUS_CHANGE'" + "AND ofo.start_time < TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1" + "AND ofo.well_completion_s = " + v_wcs + " " + "ORDER BY ofo.start_time DESC").Result;

            return x.FirstOrDefault();
        }
        public string String_Connection_Slot(int string_S, string pSchema)
        {
            string slot;
            slot = KocDB.QueryAsync<string>("SELECT sf.facility_id " + " FROM " + pSchema + ".surface_facility sf, " + pSchema + ".general_port gp_sf, " + pSchema + ".port_connection pc, " + pSchema + ".general_port gp_wc " + " WHERE sf.facility_type = 'INCOMMER'" + " AND sf.surface_facility_s = gp_sf.surface_facility_s" + " AND gp_sf.general_port_s = pc.to_port_s " + " AND (pc.end_time IS NULL OR pc.end_time > TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1) " + " AND pc.start_time < TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1" + " AND pc.from_port_s = gp_wc.general_port_s" + " AND gp_wc.downhole_facility_s = " + string_S + " " + " ORDER BY pc.start_time DESC").Result.FirstOrDefault();
            return slot;
        }
        public cls_outvaluewithdate Completion_LiquidRate(int v_wcs)
        {
            cls_outvaluewithdate lq;
            lq = KocDB.QueryAsync<cls_outvaluewithdate>("SELECT ofo.start_time outdate, round(ts.liquid_rate) outvalue " + " FROM koc_staging.s_oil_field_operation ofo, koc_staging.s_test_stage ts" + "     WHERE ts.liquid_rate Is Not NULL " + " AND ts.containing_act_s = ofo.oil_field_operation_s" + " AND ofo.start_time < TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1" + " AND ofo.activity_type = 'TEST'" + " AND ofo.well_completion_s = " + v_wcs + " " + "   UNION " + " SELECT ofo.start_time outdate, round(ts.liquid_rate) outvalue " + " FROM koc.oil_field_operation ofo, koc.test_stage ts" + " WHERE ts.liquid_rate IS NOT NULL" + " AND ts.containing_act_s = ofo.oil_field_operation_s" + " AND ofo.start_time < TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1" + " AND ofo.activity_type = 'TEST'" + " AND ofo.well_completion_s = " + v_wcs + " " + " ORDER BY 1 DESC").Result.FirstOrDefault();
            return lq;
        }
        public cls_outvaluewithdate Completion_LiquidRate_AfterStartDate(int v_wcs)
        {
            cls_outvaluewithdate lq;
            lq = KocDB.QueryAsync<cls_outvaluewithdate>("SELECT ofo.start_time outdate, round(ts.liquid_rate) outvalue " + " FROM koc_staging.s_oil_field_operation ofo, koc_staging.s_test_stage ts" + "     WHERE(ts.liquid_rate Is Not NULL)" + " AND ts.containing_act_s = ofo.oil_field_operation_s" + " AND ofo.start_time > TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1" + " AND ofo.activity_type = 'TEST'" + " AND ofo.well_completion_s = " + v_wcs + " " + "   UNION " + " SELECT ofo.start_time outdate, round(ts.liquid_rate) outvalue " + " FROM koc.oil_field_operation ofo, koc.test_stage ts" + " WHERE ts.liquid_rate IS NOT NULL" + " AND ts.containing_act_s = ofo.oil_field_operation_s" + " AND ofo.start_time > TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1" + " AND ofo.activity_type = 'TEST'" + " AND ofo.well_completion_s = " + v_wcs + " " + " ORDER BY 1 asc").Result.FirstOrDefault();
            return lq;
        }
        public cls_outvaluewithdate Completion_Concentration_Fluids(int v_wcs, string Material_type)
        {
            cls_outvaluewithdate mat;
            mat = KocDB.QueryAsync<cls_outvaluewithdate>("SELECT mc.concentration outvalue, ofo.start_time outdate" + " FROM koc_staging.s_oil_field_operation ofo, koc_staging.s_fluid_analysis fa, koc_staging.s_material_composition mc " + " WHERE mc.component_material_type = '" + Material_type.ToUpper() + "'" + "  AND mc.concentration IS NOT NULL" + " AND mc.project_fluid_analysis_s = fa.fluid_analysis_s" + " AND fa.oil_field_operation_s = ofo.oil_field_operation_s" + " AND ofo.start_time < TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1" + "    AND ofo.activity_type = 'TEST'" + "    AND ofo.well_completion_s =" + v_wcs + " " + "        UNION" + "  SELECT mc.concentration outvalue, ofo.start_time outdate" + "  FROM koc.oil_field_operation ofo, koc.fluid_analysis fa, koc.material_composition mc" + "  WHERE mc.component_material_type = '" + Material_type.ToUpper() + "'" + "    AND mc.concentration IS NOT NULL" + "    AND mc.project_fluid_analysis_s = fa.fluid_analysis_s" + "    AND fa.oil_field_operation_s = ofo.oil_field_operation_s" + " AND ofo.start_time < TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1" + " AND ofo.activity_type = 'TEST'" + " AND ofo.well_completion_s = " + v_wcs + " " + " ORDER BY 2 DESC").Result.FirstOrDefault();
            return mat;
        }
        public cls_outvaluewithdate Completion_WaterCut(int v_wcs)
        {
            cls_outvaluewithdate wc;
            wc = KocDB.QueryAsync<cls_outvaluewithdate>("SELECT pp.nominal_water_cut outvalue , ofo.start_time outdate" + "  FROM koc_staging.s_oil_field_operation ofo, koc_staging.s_test_stage ts, koc_staging.s_periodic_production pp" + " WHERE pp.activity_type = 'WATER_CUT'" + " AND pp.nominal_water_cut IS NOT NULL" + " AND pp.test_stage_s = ts.test_stage_s" + " AND ts.containing_act_s = ofo.oil_field_operation_s" + " AND ofo.start_time < TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1" + " AND ofo.activity_type = 'TEST'" + " AND ofo.well_completion_s = " + v_wcs + " " + "    UNION " + " SELECT pp.nominal_water_cut outvalue , ofo.start_time outdate " + " FROM koc.oil_field_operation ofo, koc.test_stage ts, koc.periodic_production pp" + " WHERE pp.activity_type = 'WATER_CUT'" + " AND pp.nominal_water_cut IS NOT NULL" + " AND pp.test_stage_s = ts.test_stage_s" + " AND ts.containing_act_s = ofo.oil_field_operation_s" + " AND ofo.start_time < TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1" + " AND ofo.activity_type = 'TEST'" + " AND ofo.well_completion_s = " + v_wcs + " " + " ORDER BY 2 DESC").Result.FirstOrDefault();
            return wc;
        }
        public cls_outvaluewithdate Completion_WaterCut_AfterStartDate(int v_wcs)
        {
            cls_outvaluewithdate wc;
            wc = KocDB.QueryAsync<cls_outvaluewithdate>("SELECT pp.nominal_water_cut outvalue , ofo.start_time outdate" + "  FROM koc_staging.s_oil_field_operation ofo, koc_staging.s_test_stage ts, koc_staging.s_periodic_production pp" + " WHERE pp.activity_type = 'WATER_CUT'" + " AND pp.nominal_water_cut IS NOT NULL" + " AND pp.test_stage_s = ts.test_stage_s" + " AND ts.containing_act_s = ofo.oil_field_operation_s" + " AND ofo.start_time > TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1" + " AND ofo.activity_type = 'TEST'" + " AND ofo.well_completion_s = " + v_wcs + " " + "    UNION " + " SELECT pp.nominal_water_cut outvalue , ofo.start_time outdate " + " FROM koc.oil_field_operation ofo, koc.test_stage ts, koc.periodic_production pp" + " WHERE pp.activity_type = 'WATER_CUT'" + " AND pp.nominal_water_cut IS NOT NULL" + " AND pp.test_stage_s = ts.test_stage_s" + " AND ts.containing_act_s = ofo.oil_field_operation_s" + " AND ofo.start_time > TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1" + " AND ofo.activity_type = 'TEST'" + " AND ofo.well_completion_s = " + v_wcs + " " + " ORDER BY 2 asc").Result.FirstOrDefault();
            return wc;
        }
        public cls_outvaluewithdate Completion_Choke_left(int v_wcs)
        {
            cls_outvaluewithdate x;
            x = KocDB.QueryAsync<cls_outvaluewithdate>("SELECT 	nvl(ts.tubing_left_choke, ts.casing_left_choke)  outvalue,         ofo.start_time outdate " + " FROM koc_staging.s_oil_field_operation ofo, koc_staging.s_test_stage ts " + "       WHERE " + " 	NVL(ts.tubing_left_choke, ts.casing_left_choke) > 0" + "   AND NVL(ts.tubing_right_choke, ts.casing_right_choke) IS NOT NULL" + "   AND ts.containing_act_s = ofo.oil_field_operation_s" + "   AND ofo.start_time < TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1" + "   AND ofo.activity_type = 'TEST'" + "   AND ofo.well_completion_s = " + v_wcs + " " + "        UNION " + " Select " + " nvl(ts.tubing_left_choke, ts.casing_left_choke) outvalue, " + " ofo.start_time outdate" + " FROM koc.oil_field_operation ofo, koc.test_stage ts" + " WHERE " + "  	NVL(ts.tubing_left_choke, ts.casing_left_choke) > 0" + "   AND NVL(ts.tubing_right_choke, ts.casing_right_choke) IS NOT NULL" + "  AND ts.containing_act_s = ofo.oil_field_operation_s" + " AND ofo.start_time < TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1" + " AND ofo.activity_type = 'TEST'" + " AND ofo.well_completion_s = " + v_wcs + " " + " ORDER BY 2 DESC").Result.FirstOrDefault();
            return x;
        }
        public cls_outvaluewithdate Completion_Choke_Right(int v_wcs)
        {
            cls_outvaluewithdate x;
            x = KocDB.QueryAsync<cls_outvaluewithdate>("SELECT 	nvl(ts.tubing_right_choke, ts.casing_right_choke)  outvalue,         ofo.start_time outdate " + " FROM koc_staging.s_oil_field_operation ofo, koc_staging.s_test_stage ts " + "       WHERE " + " 	NVL(ts.tubing_right_choke, ts.casing_right_choke) > 0" + "   AND NVL(ts.tubing_left_choke, ts.casing_left_choke) IS NOT NULL" + "   AND ts.containing_act_s = ofo.oil_field_operation_s" + "   AND ofo.start_time < TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1" + "   AND ofo.activity_type = 'TEST'" + "   AND ofo.well_completion_s = " + v_wcs + " " + "        UNION " + " Select " + " nvl(ts.tubing_right_choke, ts.casing_right_choke) outvalue, " + " ofo.start_time outdate" + " FROM koc.oil_field_operation ofo, koc.test_stage ts" + " WHERE " + "  	NVL(ts.tubing_right_choke, ts.casing_right_choke) > 0" + "   AND NVL(ts.tubing_left_choke, ts.casing_left_choke) IS NOT NULL" + "  AND ts.containing_act_s = ofo.oil_field_operation_s" + " AND ofo.start_time < TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1" + " AND ofo.activity_type = 'TEST'" + " AND ofo.well_completion_s = " + v_wcs + " " + " ORDER BY 2 DESC").Result.FirstOrDefault();
            return x;
        }
        public cls_whp_flp_date Completion_Whp_Flp(int v_wcs)
        {
            cls_whp_flp_date x = new cls_whp_flp_date();
            x = KocDB.QueryAsync<cls_whp_flp_date>("SELECT nvl(ts.tubing_pressure, ts.casing_pressure) whp, ts.flow_line_pressure flp, ofo.start_time " + " FROM koc_staging.s_oil_field_operation ofo, koc_staging.s_test_stage ts " + "      WHERE ts.flow_line_pressure Is Not NULL " + "  AND (ts.tubing_pressure IS NOT NULL OR ts.casing_pressure IS NOT NULL) " + "  AND ts.containing_act_s = ofo.oil_field_operation_s " + " AND ofo.start_time < TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1 " + "  AND ofo.activity_type = 'TEST'" + "  AND ofo.well_completion_s = " + v_wcs + " " + "      UNION " + " SELECT nvl(ts.tubing_pressure, ts.casing_pressure) whp, ts.flow_line_pressure flp, ofo.start_time " + " FROM koc.oil_field_operation ofo, koc.test_stage ts " + " WHERE ts.flow_line_pressure IS NOT NULL" + "  AND (ts.tubing_pressure IS NOT NULL OR ts.casing_pressure IS NOT NULL) " + "  AND ts.containing_act_s = ofo.oil_field_operation_s " + " AND ofo.start_time < TO_DATE('" + pStart_date + "', 'dd-mm-yyyy') + 1" + " AND ofo.activity_type = 'TEST'" + " AND ofo.well_completion_s = " + v_wcs + " " + " ORDER BY 3 DESC").Result.FirstOrDefault();
            return x;
        }
        public cls_outvaluewithdate Completion_BeanStatus(int v_wcs)
        {
            cls_outvaluewithdate x;
            x = KocDB.QueryAsync<cls_outvaluewithdate>("	SELECT start_time outdate, finding_reason outvalue   " + " FROM koc.oil_field_operation " + " 		   WHERE activity_type = 'CHOKE' " + " 		 AND activity_id = 'CHOKE_CHECK' " + " 	 AND well_completion_s =  " + v_wcs + " " + " 		ORDER BY start_time DESC").Result.FirstOrDefault();
            return x;
        }
        public string Completion_LiftingMethod(int v_wcs)
        {
            string x;
            x = KocDB.QueryAsync<string>("SELECT  rfs.description  " + "  FROM koc.oil_field_operation ofo,koc.facility_status fs, codes.r_facility_status rfs " + "   WHERE rfs.source_type = 'LIFT_METHOD' " + "   AND rfs.type = fs.status_type " + "   AND fs.start_oil_field_operation_s = ofo.oil_field_operation_s " + "    AND ofo.activity_type = 'LIFT_METHOD_CHANGE' " + "     AND ofo.well_completion_s =  " + v_wcs + " " + "    AND  ofo.start_time = " + "  (SELECT max(ofo.start_time) " + "    FROM koc.oil_field_operation ofo, koc.facility_status fs, codes.r_facility_status rfs " + "    WHERE rfs.source_type = 'LIFT_METHOD' " + "      AND rfs.type = fs.status_type " + "       AND fs.start_oil_field_operation_s = ofo.oil_field_operation_s " + "       AND ofo.activity_type = 'LIFT_METHOD_CHANGE' " + "       AND ofo.well_completion_s =   " + v_wcs + ") ").Result.FirstOrDefault();
            return x;
        }
        public int Completion_Allowed(int v_wcs)
        {
            int x;
            x = KocDB.QueryAsync<int>("select liquid_volume  from koc.daily_production_data " + "	where daily_production_hdr_s in  " + "		(select daily_production_hdr_s from koc.daily_production_hdr " + "	   where WELL_COMPLETION_S =   " + v_wcs + " " + "		AND  ACTIVITY_TYPE 	= 'ALLOWED' " + "			AND  MATERIAL_TYPE 	= 'OIL' " + "			AND  FLOW_DIR_TYPE 	= 'PRODUCTION' " + "			AND  STATE_TYPE 	= 'STANDARD' " + "			AND  EXISTENCE_TYPE 	= 'ACTUAL'  ) " + "		and	 start_time in  " + "		(select MAX(start_time) from koc.daily_production_data " + "			where start_time <=   to_date('" + pStart_date + "','DD/mm/YYYY') " + "			  and  daily_production_hdr_s in " + "				(select daily_production_hdr_s from koc.daily_production_hdr " + "	   where WELL_COMPLETION_S =   " + v_wcs + " " + "				AND  ACTIVITY_TYPE 	= 'ALLOWED' " + "				AND  MATERIAL_TYPE 	= 'OIL' " + "				AND  FLOW_DIR_TYPE 	= 'PRODUCTION' " + "				AND  STATE_TYPE 	= 'STANDARD' " + "			AND  EXISTENCE_TYPE 	= 'ACTUAL' )").Result.FirstOrDefault();
            return x;
        }
        public cls_gc_chokechange_data_2 CompletionChokeChange_byTestDate(int v_wcs, string testdate)
        {
            cls_gc_chokechange_data_2 dr = new cls_gc_chokechange_data_2();
            dr = KocDB.QueryAsync<cls_gc_chokechange_data_2>(" SELECT ts.left_choke_size, ts.right_choke_size, ofo.start_time " + " FROM koc.oil_field_operation ofo, koc.test_stage ts " + "    WHERE ts.left_choke_size Is Not NULL " + "  AND ts.right_choke_size IS NOT NULL " + "  AND ts.start_time <TO_DATE('" + testdate + "', 'dd-mm-yyyy')  " + "  AND ts.containing_act_s = ofo.oil_field_operation_s " + "  AND ofo.activity_type = 'TEST' " + "  AND ofo.well_completion_s = " + v_wcs + " " + "     UNION " + "  SELECT ts.left_choke_size, ts.right_choke_size, ofo.start_time " + "  FROM koc_staging.oil_field_operation ofo, koc_staging.test_stage ts " + "  WHERE ts.left_choke_size IS NOT NULL " + "   AND ts.right_choke_size IS NOT NULL " + "   AND ts.start_time <TO_DATE('" + testdate + "', 'dd-mm-yyyy')  " + "   AND ts.containing_act_s = ofo.oil_field_operation_s " + "   AND ofo.activity_type = 'TEST' " + "   AND ofo.well_completion_s =  " + v_wcs + " " + "  ORDER BY 3 DESC").Result.FirstOrDefault();
            return dr;
        }
        public IEnumerable<cls_portable_vs_dcs_report> Completion_PortablevsDCS(int v_wcs)
        {
            IEnumerable<cls_portable_vs_dcs_report> ls;
            ls = KocDB.QueryAsync<cls_portable_vs_dcs_report>("SELECT      a.START_TIME AS starttime, a.TEST_RATE DCSLQ, a.WC DCSWC,  GET_WCS_LQ_PORT_ATDATE(a.WELL_COMPLETION_S,to_char(a.start_time,'dd-mm-yyyy')) as PortLQ,GET_WCS_WATER_CUT_PORT_ATDATE(a.WELL_COMPLETION_S,to_char(a.start_time,'dd-mm-yyyy')) as  PortWC,GET_WCS_TOTAL_GOR_ATDATE(a.WELL_COMPLETION_S,to_char(a.start_time,'dd-mm-yyyy')) as TotalGor  " + "  FROM         WELL_TESTS_VW a " + "  WHERE     (a.TEST_TYPE ='DCS' ) AND (a.WELL_COMPLETION_S= nvl( " + v_wcs + ", a.WELL_COMPLETION_S)) " + "       union all " + "  SELECT       b.START_TIME AS starttime ,GET_WCS_LQ_RATE_DCS(b.WELL_COMPLETION_S,to_char(b.start_time,'dd-mm-yyyy')) as DCSLQ,GET_WCS_WATER_CUT_DCS_ATDATE(b.WELL_COMPLETION_S,to_char(b.start_time,'dd-mm-yyyy')) as  DCSWC ,  b.TEST_RATE PortLQ, b.WC PortWC,GET_WCS_TOTAL_GOR_ATDATE(b.WELL_COMPLETION_S,to_char(b.start_time,'dd-mm-yyyy')) as TotalGor " + "  FROM         WELL_TESTS_VW b " + "  WHERE    b.TEST_TYPE in ('PORTABLE GOR MULTIRATE','PORTABLE') AND (b.WELL_COMPLETION_S= nvl( " + v_wcs + " , b.WELL_COMPLETION_S)) and b.gor is not null  " + "  order by starttime desc").Result;
            return ls;
        }
      
       
        #endregion
        #region "Misc Util Functions"
        private void FillData(PropertyInfo[] properties, DataTable dt, Object o)
        {
            DataRow dr = dt.NewRow();
            foreach (PropertyInfo pi in properties)
            {
                if (pi.Name != null)
                    dr[pi.Name] = pi.GetValue(o, null);
            }
            dt.Rows.Add(dr);
        }
        public DataTable CreateDataTable(Object[] array)
        {
            PropertyInfo[] properties = array.GetType().GetElementType().GetProperties();
            DataTable dt = CreateTable(properties);
            if (array.Length != 0)
            {
                foreach (object o in array)
                    FillData(properties, dt, o);
            }
            return dt;
        }
        private DataTable CreateTable(PropertyInfo[] properties)
        {
            DataTable dt = new DataTable();
            foreach (PropertyInfo pi in properties)
            {
                DataColumn dc = new DataColumn
                {
                    ColumnName = pi.Name,
                    DataType = pi.PropertyType
                };
                dt.Columns.Add(dc);
            }
            return dt;
        }
        #endregion
    }
}
