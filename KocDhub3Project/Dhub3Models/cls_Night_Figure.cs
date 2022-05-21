using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;


namespace KOC.DHUB3.Models
{


    [Serializable()]
    public class cls_Night_Figure
    {
        // Inherits NIGHT_FIGURES_HDR
      


        public string GC_ID { get; set; }
        public decimal? ID { get; set; } = 0;
        public DateTime? ISSUE_DATE { get; set; } = DateTime.Now.Date;
        public DateTime? ROW_CREATE_DATE { get; set; }
        public string ROW_CREATED_BY { get; set; }
        public string ROW_UPDATE_BY { get; set; }
        public DateTime? ROW_UPDATE_DATE { get; set; }

        public decimal? T_PRODUCTION { get; set; } = 0;
        public decimal? T_DESPATCH { get; set; } = 0;
        public decimal? gc_sf_s { get; set; } = 0;
        public decimal? eff_water_in_pit { get; set; } = 0;
        public decimal? gc_outlet_port { get; set; } = 0;
        public decimal? gc_inlet_port { get; set; } = 0;
        public decimal? despatch_hdr_s { get; set; } = 0;
        public decimal? l_despatch_hdr_s { get; set; } = 0;
        public decimal? m_despatch_hdr_s { get; set; } = 0;
        public decimal? stock_hdr_s { get; set; } = 0;
        public decimal? l_stock_hdr_s { get; set; } = 0;
        public decimal? m_stock_hdr_s { get; set; } = 0;
        public decimal? stock { get; set; } = 0;
        public decimal? gas_flow_hdr_s { get; set; } = 0;
        public decimal? l_dry_stock_tdy { get; set; } = 0;
        public decimal? l_dry_stock_ydy { get; set; } = 0;
        public decimal? m_dry_stock_tdy { get; set; } = 0;
        public decimal? m_dry_stock_ydy { get; set; } = 0;
        public decimal? l_wet_stock_tdy { get; set; } = 0;
        public decimal? l_wet_stock_ydy { get; set; } = 0;
        public decimal? m_wet_stock_tdy { get; set; } = 0;
        public decimal? m_wet_stock_ydy { get; set; } = 0;
        public decimal? dry_stock_tdy { get; set; } = 0;
        public decimal? dry_stock_ydy { get; set; } = 0;
        public decimal? wet_stock_ydy { get; set; } = 0;
        public decimal? wet_stock_tdy { get; set; } = 0;
        public decimal? dual_stock_tdy { get; set; } = 0;
        public decimal? l_dual_stock_ydy { get; set; } = 0;
        public decimal? dual_stock_ydy { get; set; } = 0;
        public decimal? l_dry_stock_change { get; set; } = 0;
        public decimal? m_dry_stock_change { get; set; } = 0;
        public decimal? l_wet_stock_change { get; set; } = 0;
        public decimal? m_wet_stock_change { get; set; } = 0;
        public decimal? dry_stock_change { get; set; } = 0;
        public decimal? wet_stock_change { get; set; } = 0;
        public decimal? m_stock_ydy { get; set; } = 0;
        public decimal? m_stock_tdy { get; set; } = 0;
        public decimal? m_gross_stock { get; set; } = 0;
        public decimal? m_net_stock { get; set; } = 0;
        public decimal? l_stock_ydy { get; set; } = 0;
        public decimal? l_stock_tdy { get; set; } = 0;
        public decimal? l_gross_stock { get; set; } = 0;
        public decimal? l_net_stock { get; set; } = 0;
        public decimal? net_stock_change { get; set; } = 0;
        public DateTime st_date { get; set; }
        public decimal? gc_stock_port { get; set; } = 0;
        public int? production_hdr_s { get; set; } = 0;
        public int? l_production_hdr_s { get; set; } = 0;
        public int? m_production_hdr_s { get; set; } = 0;
        public int? dry_production_hdr_s { get; set; } = 0;
        public int? wet_production_hdr_s { get; set; } = 0;
        public int? m_dry_production_hdr_s { get; set; } = 0;
        public int? l_dry_production_hdr_s { get; set; } = 0;
        public int? l_wet_production_hdr_s { get; set; } = 0;
        public int? m_wet_production_hdr_s { get; set; } = 0;
        public int? l_api_salt_hdr_s { get; set; } = 0;
        public int? m_api_salt_hdr_s { get; set; } = 0;
        public int? SA_oil_s { get; set; } = 0;
        public int? SA_water_s { get; set; } = 0;
        public int? RA_oil_s { get; set; } = 0;
        public int? RA_water_s { get; set; } = 0;
        public int? RQ_oil_s { get; set; } = 0;
        public int? RQ_water_s { get; set; } = 0;
        public int? AD_oil_s { get; set; } = 0;
        public int? AD_water_s { get; set; } = 0;
        public int? tl1_s { get; set; } = 0;
        public int? tl2_s { get; set; } = 0;
        public int? tl3_s { get; set; } = 0;
        public int? tl_subbia_s { get; set; } = 0;
        public int? tank_hdr_s { get; set; } = 0;
        public int? eff_water_hdr_s { get; set; } = 0;
        public int? EWDP1_HDR_S { get; set; } = 0;
        public int? EFF_WATER_TANK_HDR_S { get; set; } =0;
        public int? EFF_WATER_OUT_HDR_S { get; set; } = 0;
        public int? EFF_WATER_IN_HDR_S { get; set; } = 0;
        public decimal? L_FACTOR { get; set; } = 0;
        public int? total_water_injection { get; set; } = 0;
        public List<string> LogOutPut { get; set; } = new List<string>();
        public bool Erroron { get; set; }
        private string txt_date;
        public DhubEntities.NIGHT_FIGURES_HDR hdr { get; set; } = new DhubEntities.NIGHT_FIGURES_HDR();
        private DhubEntities.NIGHT_FIGURES_PROD_STOCK l_retint = new DhubEntities.NIGHT_FIGURES_PROD_STOCK();
        private DhubEntities.NIGHT_FIGURES_PROD_STOCK m_retint = new DhubEntities.NIGHT_FIGURES_PROD_STOCK();
        private DhubEntities.NIGHT_FIGURES_PROD_STOCK PROD_STOCK = new DhubEntities.NIGHT_FIGURES_PROD_STOCK();
        private DhubEntities.NIGHT_FIGURE_DDP ddp = new DhubEntities.NIGHT_FIGURE_DDP();
        private DhubEntities.NIGHT_FIGURES_EWDP_HDR EWDP_HDR = new DhubEntities.NIGHT_FIGURES_EWDP_HDR();
        private DhubEntities.NIGHT_FIGURES_DDP_MISC DDP_MISC = new DhubEntities.NIGHT_FIGURES_DDP_MISC();
        #region Finder
        #region  Save Data To Finder
        private void InsertIntoDailyProductionData(decimal pdaily_production_hdr_s, DateTime pstart_time, decimal pgc_factor, decimal pliquid_volume, decimal ppressure = default, string premarks = "", string TransactionDescription = "", string ppreferred_flag = "", decimal pgas_volume = default, decimal pnominal_water_cut = default)
        {
            var retint = from x in SimpleODMConfig.FinderModelEntities.KocContext.DAILY_PRODUCTION_DATA
                         where x.DAILY_PRODUCTION_HDR_S == pdaily_production_hdr_s & x.START_TIME.Equals(st_date)
                         select x;
            if (retint.Count == 0)
            {
                var dp = new KOCFinder.FinderDBKOCModel.DAILY_PRODUCTION_DATA();
                dp.DAILY_PRODUCTION_HDR_S = pdaily_production_hdr_s;
                dp.START_TIME = pstart_time;
                dp.GC_FACTOR = pgc_factor;
                dp.LIQUID_VOLUME = pliquid_volume;
                dp.GAS_VOLUME = pgas_volume;
                dp.NOMINAL_WATER_CUT = pnominal_water_cut;
                dp.REMARKS = premarks;
                dp.PREFERRED_FLAG = ppreferred_flag;
                try
                {
                    SimpleODMConfig.FinderModelEntities.KocContext.AddToDAILY_PRODUCTION_DATA(dp);
                    SimpleODMConfig.FinderModelEntities.KocContext.SaveChanges();
                    LogOutPut.Add("add Production Data for the GC - " + TransactionDescription);
                }

                catch (EntityException ex)
                {
                    LogOutPut.Add("Unable add Production for Data the GC - " + TransactionDescription);
                    Erroron = true;

                    return;

                }
            }
            else
            {
                var dp = new KOCFinder.FinderDBKOCModel.DAILY_PRODUCTION_DATA();
                dp = retint.FirstOrDefault;
                dp.DAILY_PRODUCTION_HDR_S = pdaily_production_hdr_s;
                dp.START_TIME = pstart_time;
                dp.GC_FACTOR = pgc_factor;
                dp.GAS_VOLUME = pgas_volume;
                dp.NOMINAL_WATER_CUT = pnominal_water_cut;
                dp.LIQUID_VOLUME = pliquid_volume;
                dp.REMARKS = premarks;
                dp.PREFERRED_FLAG = ppreferred_flag;
                try
                {
                    SimpleODMConfig.FinderModelEntities.KocContext.SaveChanges();
                    LogOutPut.Add("Updated Production Data for the GC - " + TransactionDescription);
                }

                catch (EntityException ex)
                {
                    LogOutPut.Add("Unable Update Production Data for the GC - " + TransactionDescription);
                    Erroron = true;

                    return;

                }

            }


        }
        private void InsertIntoDailyMiscellaneousData(decimal pdaily_miscellaneous_hdr_s, DateTime pstart_time, string pattribute, string pattribute_string, string TransactionDescription = "", string ppreferred_flag = "")
        {

            // Dim retint As KOCFinder.FinderDBKOCModel.DAILY_PRODUCTION_DATA = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery(Of KOCFinder.FinderDBKOCModel.DAILY_PRODUCTION_DATA)("SELECT *  FROM koc.daily_production_data   WHERE daily_production_hdr_s = " & pdaily_production_hdr_s & "   AND to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" & txt_date & "','dd/mm/yyyy')").FirstOrDefault
            var retint = from x in SimpleODMConfig.FinderModelEntities.KocContext.DAILY_MISCELLANEOUS_DATA
                         where x.DAILY_MISCELLANEOUS_HDR_S == pdaily_miscellaneous_hdr_s & x.START_TIME.Equals(st_date)
                         select x;
            if (retint.Count == 0)
            {
                var dp = new KOCFinder.FinderDBKOCModel.DAILY_MISCELLANEOUS_DATA();
                dp.DAILY_MISCELLANEOUS_HDR_S = pdaily_miscellaneous_hdr_s;
                dp.START_TIME = pstart_time;
                dp.ATTRIBUTE = pattribute;
                dp.ATTRIBUTE_STRING = pattribute_string;
                dp.PREFERRED_FLAG = ppreferred_flag;
                try
                {
                    SimpleODMConfig.FinderModelEntities.KocContext.AddToDAILY_MISCELLANEOUS_DATA(dp);
                    SimpleODMConfig.FinderModelEntities.KocContext.SaveChanges();
                    LogOutPut.Add("add Production miscellaneous Data for the GC - " + TransactionDescription);
                }
                catch (EntityException ex)
                {
                    LogOutPut.Add("Unable add Production  miscellaneous Data the GC - " + TransactionDescription);
                    Erroron = true;
                    return;
                }
            }
            else
            {
                var dp = new KOCFinder.FinderDBKOCModel.DAILY_MISCELLANEOUS_DATA();
                dp = retint.FirstOrDefault;
                dp.DAILY_MISCELLANEOUS_HDR_S = pdaily_miscellaneous_hdr_s;
                dp.START_TIME = pstart_time;
                dp.ATTRIBUTE = pattribute;
                dp.ATTRIBUTE_STRING = pattribute_string;
                dp.PREFERRED_FLAG = ppreferred_flag;
                try
                {
                    SimpleODMConfig.FinderModelEntities.KocContext.SaveChanges();
                    LogOutPut.Add("Updated Production miscellaneous Data for the GC - " + TransactionDescription);
                }
                catch (EntityException ex)
                {
                    LogOutPut.Add("Unable Update Production miscellaneous Data for the GC - " + TransactionDescription);
                    Erroron = true;
                    return;
                }
            }


        }
        private void SaveDispatchtoFinder()
        {
            if (GC_ID != "GC27" & GC_ID != "28")
            {
                if (0 is var arg2 && despatch_hdr_s is { } arg1 && arg1 > arg2)
                {
                    InsertIntoDailyProductionData(despatch_hdr_s, st_date, hdr.NIGHT_FIGURES_PROD_STOCK(0).L_FACTOR, hdr.NIGHT_FIGURES_PROD_STOCK(0).L_NET_DESPATCH, hdr.NIGHT_FIGURES_PROD_STOCK(0).L_TL);
                }
                if (0 is var arg4 && dry_production_hdr_s is { } arg3 && arg3 > arg4)
                {
                    InsertIntoDailyProductionData(dry_production_hdr_s, st_date, default, hdr.NIGHT_FIGURES_PROD_STOCK(0).L_DRY_PRODUCTION);
                }
                if (0 is var arg6 && wet_production_hdr_s is { } arg5 && arg5 > arg6)
                {
                    InsertIntoDailyProductionData(wet_production_hdr_s, st_date, default, hdr.NIGHT_FIGURES_PROD_STOCK(0).L_WET_PRODUCTION);
                }
                if (0 is var arg8 && production_hdr_s is { } arg7 && arg7 > arg8)
                {
                    InsertIntoDailyProductionData(production_hdr_s, st_date, default, hdr.NIGHT_FIGURES_PROD_STOCK(0).L_NET_PRODUCTION);
                }
                if (0 is var arg10 && l_api_salt_hdr_s is { } arg9 && arg9 > arg10)
                {
                    InsertIntoDailyMiscellaneousData(l_api_salt_hdr_s, st_date, "GC_API", hdr.NIGHT_FIGURES_PROD_STOCK(0).L_API_CORR);
                    InsertIntoDailyMiscellaneousData(l_api_salt_hdr_s, st_date, "GC_TEMPERATURE", hdr.NIGHT_FIGURES_PROD_STOCK(0).L_TEMPERATURE);
                    InsertIntoDailyMiscellaneousData(l_api_salt_hdr_s, st_date, "GC_SALT", hdr.NIGHT_FIGURES_PROD_STOCK(0).L_SALT);
                }
                if (GC_ID == "GC15" | GC_ID == "GC23" | GC_ID == "GC25" | GC_ID == "EPF-120")
                {
                    if (0 is var arg12 && SA_oil_s is { } arg11 && arg11 > arg12)
                    {
                        InsertIntoDailyProductionData(SA_oil_s, st_date, default, hdr.NIGHT_FIGURES_PROD_STOCK(0).SA_NET);
                    }
                    if (0 is var arg14 && SA_water_s is { } arg13 && arg13 > arg14)
                    {
                        InsertIntoDailyProductionData(SA_water_s, st_date, default, hdr.NIGHT_FIGURES_PROD_STOCK(0).SA_WC);
                    }
                    if (0 is var arg16 && RA_oil_s is { } arg15 && arg15 > arg16)
                    {
                        InsertIntoDailyProductionData(RA_oil_s, st_date, default, hdr.NIGHT_FIGURES_PROD_STOCK(0).RA_NET);
                    }
                    if (0 is var arg18 && RA_water_s is { } arg17 && arg17 > arg18)
                    {
                        InsertIntoDailyProductionData(RA_water_s, st_date, default, hdr.NIGHT_FIGURES_PROD_STOCK(0).RA_WC);
                    }
                    if (0 is var arg20 && RQ_oil_s is { } arg19 && arg19 > arg20)
                    {
                        InsertIntoDailyProductionData(RQ_oil_s, st_date, default, hdr.NIGHT_FIGURES_PROD_STOCK(0).RQ_NET);
                    }
                    if (0 is var arg22 && RQ_water_s is { } arg21 && arg21 > arg22)
                    {
                        InsertIntoDailyProductionData(RQ_water_s, st_date, default, hdr.NIGHT_FIGURES_PROD_STOCK(0).RQ_WC);
                    }
                    if (0 is var arg24 && AD_oil_s is { } arg23 && arg23 > arg24)
                    {
                        InsertIntoDailyProductionData(AD_oil_s, st_date, default, hdr.NIGHT_FIGURES_PROD_STOCK(0).AD_NET);
                    }
                    if (0 is var arg26 && AD_water_s is { } arg25 && arg25 > arg26)
                    {
                        InsertIntoDailyProductionData(AD_water_s, st_date, default, hdr.NIGHT_FIGURES_PROD_STOCK(0).AD_WC);
                    }
                    if (GC_ID == "GC15")
                    {
                        if (0 is var arg28 && tl1_s is { } arg27 && arg27 > arg28)
                        {
                            InsertIntoDailyProductionData(tl1_s, st_date, default, hdr.NIGHT_FIGURES_PROD_STOCK(0).TL1);
                        }
                        if (0 is var arg30 && tl2_s is { } arg29 && arg29 > arg30)
                        {
                            InsertIntoDailyProductionData(tl2_s, st_date, default, hdr.NIGHT_FIGURES_PROD_STOCK(0).TL2);
                        }
                        if (0 is var arg32 && tl3_s is { } arg31 && arg31 > arg32)
                        {
                            InsertIntoDailyProductionData(tl3_s, st_date, default, hdr.NIGHT_FIGURES_PROD_STOCK(0).TL3);
                        }
                        if (0 is var arg34 && tl_subbia_s is { } arg33 && arg33 > arg34)
                        {
                            InsertIntoDailyProductionData(tl_subbia_s, st_date, default, hdr.NIGHT_FIGURES_PROD_STOCK(0).SUBBIA);
                        }
                    }
                }
            }
            else
            {
                // -----------------------------------------------------------------
                // ---------		DESPATCHES AND PRODUCTION	-----------
                // -----------------------------------------------------------------
                // ---- DESPATCHES
                // ------Light
                if (0 is var arg36 && l_despatch_hdr_s is { } arg35 && arg35 > arg36)
                {
                    InsertIntoDailyProductionData(l_despatch_hdr_s, st_date, l_retint.L_FACTOR, l_retint.L_NET_DESPATCH, l_retint.L_TL);
                }
                // ------Medium
                if (0 is var arg38 && m_despatch_hdr_s is { } arg37 && arg37 > arg38)
                {
                    InsertIntoDailyProductionData(m_despatch_hdr_s, st_date, m_retint.M_FACTOR, m_retint.M_NET_DISPATCH, m_retint.M_TL);
                }
                // ------Total
                if (0 is var arg40 && despatch_hdr_s is { } arg39 && arg39 > arg40)
                {
                    InsertIntoDailyProductionData(production_hdr_s, st_date, PROD_STOCK.L_FACTOR, PROD_STOCK.T_DESPATCH, default);
                }
                // -- PRODUCTION
                // ------Light Dry
                if (0 is var arg42 && despatch_hdr_s is { } arg41 && arg41 > arg42)
                {
                    InsertIntoDailyProductionData(despatch_hdr_s, st_date, default, PROD_STOCK.L_DRY_PRODUCTION);
                }
                // ------Medium Dry
                if (0 is var arg44 && m_dry_production_hdr_s is { } arg43 && arg43 > arg44)
                {
                    InsertIntoDailyProductionData(m_dry_production_hdr_s, st_date, default, m_retint.M_DRY_PRODUCTION);
                }
                // ------Light Wet
                if (0 is var arg46 && l_wet_production_hdr_s is { } arg45 && arg45 > arg46)
                {
                    InsertIntoDailyProductionData(l_wet_production_hdr_s, st_date, default, l_retint.L_WET_PRODUCTION);
                }
                // ------Medium Wet
                if (0 is var arg48 && m_wet_production_hdr_s is { } arg47 && arg47 > arg48)
                {
                    InsertIntoDailyProductionData(m_wet_production_hdr_s, st_date, default, m_retint.M_WET_PRODUCTION);
                }
                // ------Total Light Production
                if (0 is var arg50 && l_production_hdr_s is { } arg49 && arg49 > arg50)
                {
                    InsertIntoDailyProductionData(l_production_hdr_s, st_date, default, l_retint.L_NET_PRODUCTION);
                }
                // ------Total Medium Production
                if (0 is var arg52 && m_production_hdr_s is { } arg51 && arg51 > arg52)
                {
                    InsertIntoDailyProductionData(m_production_hdr_s, st_date, default, m_retint.M_NET_PRODUCTION);
                }
                // ------ Total production
                if (0 is var arg54 && production_hdr_s is { } arg53 && arg53 > arg54)
                {
                    InsertIntoDailyProductionData(production_hdr_s, st_date, default, PROD_STOCK.T_PRODUCTION);
                }
                // ------Light API & Salt
                if (0 is var arg56 && l_api_salt_hdr_s is { } arg55 && arg55 > arg56)
                {
                    InsertIntoDailyMiscellaneousData(l_api_salt_hdr_s, st_date, "GC_API", l_retint.L_API_CORR);
                    InsertIntoDailyMiscellaneousData(l_api_salt_hdr_s, st_date, "GC_TEMPERATURE", l_retint.L_TEMPERATURE);
                    InsertIntoDailyMiscellaneousData(l_api_salt_hdr_s, st_date, "GC_SALT", l_retint.L_SALT);
                }
                // ------Medium API & Salt
                if (0 is var arg58 && m_api_salt_hdr_s is { } arg57 && arg57 > arg58)
                {
                    InsertIntoDailyMiscellaneousData(m_api_salt_hdr_s, st_date, "GC_API", m_retint.M_API_CORR);
                    InsertIntoDailyMiscellaneousData(m_api_salt_hdr_s, st_date, "GC_TEMPERATURE", m_retint.M_TEMPERATURE);
                    InsertIntoDailyMiscellaneousData(m_api_salt_hdr_s, st_date, "GC_SALT", m_retint.M_SALT);
                }
            }
        }
        private void SaveTankstoFinder()
        {
            foreach (var tanks in hdr.NIGHT_FIGURES_TANKS)
                InsertIntoDailyProductionData(Conversions.ToDecimal(tanks.TANK_HDR_S), st_date, default, Conversions.ToDecimal(tanks.TANK_STOCK), default, "", "Y");
            if (GC_ID != "GC27" | GC_ID != "28")
            {
                InsertIntoDailyProductionData((decimal)stock_hdr_s, st_date, default, (decimal)stock, default, "", "Y");
            }

            else
            {
                InsertIntoDailyProductionData((decimal)l_stock_hdr_s, st_date, default, (decimal)l_stock_tdy, default, "", "Y");
                InsertIntoDailyProductionData((decimal)m_stock_hdr_s, st_date, default, (decimal)m_stock_tdy, default, "", "Y");
                InsertIntoDailyProductionData((decimal)stock_hdr_s, st_date, default, (decimal)m_stock_tdy, default, "", "Y");
            }
        }
        private class Pumpsp1
        {
            public decimal oil_field_operation_s { get; set; }
            public decimal pump_pty_s { get; set; }
        }
        private void SavePumpstoFinder()
        {

            foreach (var pumps in hdr.NIGHT_FIGURES_PUMPS)
            {
                decimal v_ofo_s = default;
                decimal v_pp_s = default;
                try
                {
                    Pumpsp1 retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<Pumpsp1>(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(" SELECT ofo.oil_field_operation_s, pp.pump_pty_s FROM koc.oil_field_operation ofo, koc.pump_pty pp WHERE pp.oil_field_operation_s (+) = ofo.oil_field_operation_s AND ofo.surface_facility_s =", pumps.PUMP_S), "  AND to_date(to_char(ofo.start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('"), txt_date), "','dd/mm/yyyy') AND ofo.activity_type = 'FACILITY_OPERATION'")).FirstOrDefault;
                    if (retint is not null)
                    {
                        v_ofo_s = retint.oil_field_operation_s;
                        v_pp_s = retint.pump_pty_s;
                    }
                    if (v_ofo_s == 0m)
                    {
                        v_ofo_s = GetFinderSeq();
                        var ofo = new KOCFinder.FinderDBKOCModel.OIL_FIELD_OPERATION();
                        ofo.ACTIVITY_TYPE = "FACILITY_OPERATION";
                        ofo.SURFACE_FACILITY_S = pumps.PUMP_S;
                        ofo.EXISTENCE_TYPE = "ACTUAL";
                        ofo.START_TIME = st_date;
                        ofo.OIL_FIELD_OPERATION_S = v_ofo_s;
                        var Pump = new KOCFinder.FinderDBKOCModel.PUMP_PTY();
                        Pump.RUNNING_HOURS = pumps.PUMP_RUNNING_HOURS;
                        Pump.SHUTDOWN_REASON = pumps.PUMP_REASON;
                        Pump.OIL_FIELD_OPERATION_S = v_ofo_s;
                        Pump.PUMP_PTY_S = GetFinderSeq();
                        SimpleODMConfig.FinderModelEntities.KocContext.AddToOIL_FIELD_OPERATION(ofo);
                        SimpleODMConfig.FinderModelEntities.KocContext.AddToPUMP_PTY(Pump);
                        SimpleODMConfig.FinderModelEntities.KocContext.SaveChanges();
                    }
                    else if (v_ofo_s > 0m & v_pp_s > 0m)
                    {
                        // Update Pump Data
                        KOCFinder.FinderDBKOCModel.PUMP_PTY Pump = (from x in SimpleODMConfig.FinderModelEntities.KocContext.PUMP_PTY
                                                                    where x.PUMP_PTY_S == v_pp_s
                                                                    select x).FirstOrDefault;
                        Pump.RUNNING_HOURS = pumps.PUMP_RUNNING_HOURS;
                        Pump.SHUTDOWN_REASON = pumps.PUMP_REASON;
                        SimpleODMConfig.FinderModelEntities.KocContext.SaveChanges();
                    }
                    else if (v_pp_s == 0m & v_ofo_s > 0m)
                    {
                        var Pump = new KOCFinder.FinderDBKOCModel.PUMP_PTY();
                        Pump.RUNNING_HOURS = pumps.PUMP_RUNNING_HOURS;
                        Pump.SHUTDOWN_REASON = pumps.PUMP_REASON;
                        Pump.OIL_FIELD_OPERATION_S = v_ofo_s;
                        Pump.PUMP_PTY_S = GetFinderSeq();
                        SimpleODMConfig.FinderModelEntities.KocContext.AddToPUMP_PTY(Pump);
                        SimpleODMConfig.FinderModelEntities.KocContext.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    v_ofo_s = default;
                    v_pp_s = default;
                }
            }

        }
        private void SaveTurbinestoFinder()
        {
            foreach (var turbines in hdr.NIGHT_FIGURE_TURBINES)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(turbines.TURBINE_GAS_HDR_S, 0, false)))
                {
                    InsertIntoDailyMiscellaneousData(Conversions.ToDecimal(turbines.TURBINE_GAS_HDR_S), st_date, "RUNNING_HOURS", Conversions.ToString(turbines.TURBINE_RH), "", "Y");
                    InsertIntoDailyMiscellaneousData(Conversions.ToDecimal(turbines.TURBINE_GAS_HDR_S), st_date, "SHUT_REASON", Conversions.ToString(turbines.TURBINE_REASON), "", "Y");
                }
            }
        }
        private void SaveDDPToFinder()
        {
            if (GC_ID != "GC27" & GC_ID != "GC28")
            {

                if (hdr.NIGHT_FIGURE_DDP(0).DDP_IN_L_DRY_HDR_S > 0)
                {
                    InsertIntoDailyProductionData(hdr.NIGHT_FIGURE_DDP(0).DDP_IN_L_DRY_HDR_S, st_date, default, hdr.NIGHT_FIGURE_DDP(0).DDP_L_DRY);
                }
                if (hdr.NIGHT_FIGURE_DDP(0).DDP_IN_L_WET_HDR_S > 0)
                {
                    InsertIntoDailyProductionData(hdr.NIGHT_FIGURE_DDP(0).DDP_IN_L_WET_HDR_S, st_date, default, hdr.NIGHT_FIGURE_DDP(0).DDP_L_WET);
                }
                if (hdr.NIGHT_FIGURE_DDP(0).DDP_IN_L_HDR_S > 0)
                {
                    InsertIntoDailyProductionData(hdr.NIGHT_FIGURE_DDP(0).DDP_IN_L_HDR_S, st_date, default, hdr.NIGHT_FIGURE_DDP(0).DDP_L_TOTAL, pnominal_water_cut: hdr.NIGHT_FIGURE_DDP(0).DDP_L_WC);
                }
                if (hdr.NIGHT_FIGURE_DDP(0).DDP_OUT_L_WATER_HDR_S > 0)
                {
                    InsertIntoDailyProductionData(hdr.NIGHT_FIGURE_DDP(0).DDP_OUT_L_WATER_HDR_S, st_date, default, hdr.NIGHT_FIGURE_DDP(0).DDP_L_SEP_WATER);
                }
                if (hdr.NIGHT_FIGURE_DDP(0).DDP_OUT_L_HDR_S > 0)
                {
                    InsertIntoDailyProductionData(hdr.NIGHT_FIGURE_DDP(0).DDP_OUT_L_HDR_S, st_date, default, hdr.NIGHT_FIGURE_DDP(0).DDP_L_TREATED_CRUDE);
                }
            }
            else
            {
                // ------Light Dry
                if (hdr.NIGHT_FIGURE_DDP(0).DDP_IN_L_DRY_HDR_S > 0)
                {
                    InsertIntoDailyProductionData(hdr.NIGHT_FIGURE_DDP(0).DDP_IN_L_DRY_HDR_S, st_date, default, hdr.NIGHT_FIGURE_DDP(0).DDP_L_DRY);
                }
                // ------Light Wet
                if (hdr.NIGHT_FIGURE_DDP(0).DDP_IN_L_WET_HDR_S > 0)
                {
                    InsertIntoDailyProductionData(hdr.NIGHT_FIGURE_DDP(0).DDP_IN_L_WET_HDR_S, st_date, default, hdr.NIGHT_FIGURE_DDP(0).DDP_L_WET);
                }
                // -------Light Total
                if (hdr.NIGHT_FIGURE_DDP(0).DDP_IN_L_HDR_S > 0)
                {
                    InsertIntoDailyProductionData(hdr.NIGHT_FIGURE_DDP(0).DDP_IN_L_HDR_S, st_date, default, hdr.NIGHT_FIGURE_DDP(0).DDP_L_TOTAL, pnominal_water_cut: hdr.NIGHT_FIGURE_DDP(0).DDP_L_WC);
                }
                // ------Light Seperated Water
                if (hdr.NIGHT_FIGURE_DDP(0).DDP_OUT_L_WATER_HDR_S > 0)
                {
                    InsertIntoDailyProductionData(hdr.NIGHT_FIGURE_DDP(0).DDP_OUT_L_WATER_HDR_S, st_date, default, hdr.NIGHT_FIGURE_DDP(0).DDP_L_SEP_WATER);
                }
                // ------Light Treated Crude
                if (hdr.NIGHT_FIGURE_DDP(0).DDP_OUT_L_HDR_S > 0)
                {
                    InsertIntoDailyProductionData(hdr.NIGHT_FIGURE_DDP(0).DDP_OUT_L_HDR_S, st_date, default, hdr.NIGHT_FIGURE_DDP(0).DDP_L_TREATED_CRUDE);
                }
                // ------Medium Dry
                if (hdr.NIGHT_FIGURE_DDP(0).DDP_IN_M_DRY_HDR_S > 0)
                {
                    InsertIntoDailyProductionData(hdr.NIGHT_FIGURE_DDP(0).DDP_IN_M_DRY_HDR_S, st_date, default, hdr.NIGHT_FIGURE_DDP(0).DDP_M_DRY);
                }
                // ------Medium Wet
                if (hdr.NIGHT_FIGURE_DDP(0).DDP_IN_M_WET_HDR_S > 0)
                {
                    InsertIntoDailyProductionData(hdr.NIGHT_FIGURE_DDP(0).DDP_IN_M_WET_HDR_S, st_date, default, hdr.NIGHT_FIGURE_DDP(0).DDP_M_WET);
                }
                // -------Medium Total
                if (hdr.NIGHT_FIGURE_DDP(0).DDP_IN_M_HDR_S > 0)
                {
                    InsertIntoDailyProductionData(hdr.NIGHT_FIGURE_DDP(0).DDP_IN_M_HDR_S, st_date, default, hdr.NIGHT_FIGURE_DDP(0).DDP_M_TOTAL, pnominal_water_cut: hdr.NIGHT_FIGURE_DDP(0).DDP_M_WC);
                }
                // ------Light Seperated Water
                if (hdr.NIGHT_FIGURE_DDP(0).DDP_OUT_M_WATER_HDR_S > 0)
                {
                    InsertIntoDailyProductionData(hdr.NIGHT_FIGURE_DDP(0).DDP_OUT_M_WATER_HDR_S, st_date, default, hdr.NIGHT_FIGURE_DDP(0).DDP_M_SEP_WATER);
                }
                // ------Light Treated Crude
                if (hdr.NIGHT_FIGURE_DDP(0).DDP_OUT_M_HDR_S > 0)
                {
                    InsertIntoDailyProductionData(hdr.NIGHT_FIGURE_DDP(0).DDP_OUT_M_HDR_S, st_date, default, hdr.NIGHT_FIGURE_DDP(0).DDP_M_TREATED_CRUDE);

                }
            }
        }
        private class DDPHeater1
        {
            public decimal oil_field_operation_s { get; set; }
            public decimal facility_operating_pty_s { get; set; }
        }
        private void SaveDDPHeaterstoFinder()
        {
            foreach (var ddp_heaters in hdr.NIGHT_FIGURE_DDP_HEATERS)
            {
                decimal v_ofo_s = default;
                decimal v_pp_s = default;
                try
                {
                    DDPHeater1 retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<DDPHeater1>(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(" SELECT ofo.oil_field_operation_s, pp.facility_operating_pty_s FROM koc.oil_field_operation ofo, koc.facility_operating_pty pp  WHERE pp.oil_field_operation_s (+) = ofo.oil_field_operation_s AND ofo.surface_facility_s = ", ddp_heaters.DDP_HEATER_S), "  AND to_date(to_char(ofo.start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('"), txt_date), "','dd/mm/yyyy')   AND ofo.activity_type = 'FACILITY_OPERATION'")).FirstOrDefault;
                    if (retint is not null)
                    {
                        v_ofo_s = retint.oil_field_operation_s;
                        v_pp_s = retint.facility_operating_pty_s;
                    }
                    if (v_ofo_s == 0m)
                    {
                        v_ofo_s = GetFinderSeq();
                        var ofo = new KOCFinder.FinderDBKOCModel.OIL_FIELD_OPERATION();
                        ofo.ACTIVITY_TYPE = "FACILITY_OPERATION";
                        ofo.SURFACE_FACILITY_S = ddp_heaters.DDP_HEATER_S;
                        ofo.EXISTENCE_TYPE = "ACTUAL";
                        ofo.START_TIME = st_date;
                        ofo.OIL_FIELD_OPERATION_S = v_ofo_s;
                        var facilitypty = new KOCFinder.FinderDBKOCModel.FACILITY_OPERATING_PTY();
                        facilitypty.RUNNING_HOURS = ddp_heaters.DDP_HEATERS_RH;
                        facilitypty.SHUTDOWN_REASON = ddp_heaters.DDP_HEATERS_REASON;
                        facilitypty.OIL_FIELD_OPERATION_S = v_ofo_s;
                        facilitypty.FACILITY_OPERATING_PTY_S = GetFinderSeq();
                        SimpleODMConfig.FinderModelEntities.KocContext.AddToOIL_FIELD_OPERATION(ofo);
                        SimpleODMConfig.FinderModelEntities.KocContext.AddToFACILITY_OPERATING_PTY(facilitypty);
                        SimpleODMConfig.FinderModelEntities.KocContext.SaveChanges();
                    }
                    else if (v_ofo_s > 0m & v_pp_s > 0m)
                    {
                        // Update Pump Data
                        KOCFinder.FinderDBKOCModel.FACILITY_OPERATING_PTY facilitypty = (from x in SimpleODMConfig.FinderModelEntities.KocContext.FACILITY_OPERATING_PTY
                                                                                         where x.FACILITY_OPERATING_PTY_S == v_pp_s
                                                                                         select x).FirstOrDefault;
                        facilitypty.RUNNING_HOURS = ddp_heaters.DDP_HEATERS_RH;
                        facilitypty.SHUTDOWN_REASON = ddp_heaters.DDP_HEATERS_REASON;
                        SimpleODMConfig.FinderModelEntities.KocContext.SaveChanges();
                    }
                    else if (v_pp_s == 0m & v_ofo_s > 0m)
                    {
                        var facilitypty = new KOCFinder.FinderDBKOCModel.FACILITY_OPERATING_PTY();
                        facilitypty.RUNNING_HOURS = ddp_heaters.DDP_HEATERS_RH;
                        facilitypty.SHUTDOWN_REASON = ddp_heaters.DDP_HEATERS_REASON;
                        facilitypty.OIL_FIELD_OPERATION_S = v_ofo_s;
                        facilitypty.FACILITY_OPERATING_PTY_S = GetFinderSeq();
                        SimpleODMConfig.FinderModelEntities.KocContext.AddToFACILITY_OPERATING_PTY(facilitypty);
                        SimpleODMConfig.FinderModelEntities.KocContext.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    v_ofo_s = default;
                    v_pp_s = default;
                }
            }
        }
        private void SaveDDPTrainstoFinder()
        {
            foreach (var ddp_trains in hdr.NIGHT_FIGURES_DDP_TRAIN)
            {
                decimal v_ofo_s = default;
                decimal v_pp_s = default;
                try
                {
                    DDPHeater1 retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<DDPHeater1>(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(" SELECT ofo.oil_field_operation_s, pp.facility_operating_pty_s FROM koc.oil_field_operation ofo, koc.facility_operating_pty pp  WHERE pp.oil_field_operation_s (+) = ofo.oil_field_operation_s AND ofo.surface_facility_s = ", ddp_trains.DDP_TRAIN_S), "  AND to_date(to_char(ofo.start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('"), txt_date), "','dd/mm/yyyy')   AND ofo.activity_type = 'FACILITY_OPERATION'")).FirstOrDefault;
                    if (retint is not null)
                    {
                        v_ofo_s = retint.oil_field_operation_s;
                        v_pp_s = retint.facility_operating_pty_s;
                    }
                    if (v_ofo_s == 0m)
                    {
                        v_ofo_s = GetFinderSeq();
                        var ofo = new KOCFinder.FinderDBKOCModel.OIL_FIELD_OPERATION();
                        ofo.ACTIVITY_TYPE = "FACILITY_OPERATION";
                        ofo.SURFACE_FACILITY_S = ddp_trains.DDP_TRAIN_S;
                        ofo.EXISTENCE_TYPE = "ACTUAL";
                        ofo.START_TIME = st_date;
                        ofo.OIL_FIELD_OPERATION_S = v_ofo_s;
                        var facilitypty = new KOCFinder.FinderDBKOCModel.FACILITY_OPERATING_PTY();
                        facilitypty.PROCESS_HOURS = ddp_trains.DDP_TRAIN_PROCESS;
                        facilitypty.CIRCULATION_HOURS = ddp_trains.DDP_TRAIN_CIRC;
                        facilitypty.SALT_VOLUME = ddp_trains.DDP_TRAIN_SALT;
                        facilitypty.SHUTIN_TIME = ddp_trains.DDP_TRAIN_SHUT_TIME;
                        facilitypty.SHUTDOWN_REASON = ddp_trains.DDP_TRAIN_REASON;
                        facilitypty.OIL_FIELD_OPERATION_S = v_ofo_s;
                        facilitypty.FACILITY_OPERATING_PTY_S = GetFinderSeq();
                        SimpleODMConfig.FinderModelEntities.KocContext.AddToOIL_FIELD_OPERATION(ofo);
                        SimpleODMConfig.FinderModelEntities.KocContext.AddToFACILITY_OPERATING_PTY(facilitypty);
                        SimpleODMConfig.FinderModelEntities.KocContext.SaveChanges();
                    }
                    else if (v_ofo_s > 0m & v_pp_s > 0m)
                    {
                        // Update Pump Data
                        KOCFinder.FinderDBKOCModel.FACILITY_OPERATING_PTY facilitypty = (from x in SimpleODMConfig.FinderModelEntities.KocContext.FACILITY_OPERATING_PTY
                                                                                         where x.FACILITY_OPERATING_PTY_S == v_pp_s
                                                                                         select x).FirstOrDefault;
                        facilitypty.PROCESS_HOURS = ddp_trains.DDP_TRAIN_PROCESS;
                        facilitypty.CIRCULATION_HOURS = ddp_trains.DDP_TRAIN_CIRC;
                        facilitypty.SALT_VOLUME = ddp_trains.DDP_TRAIN_SALT;
                        facilitypty.SHUTIN_TIME = ddp_trains.DDP_TRAIN_SHUT_TIME;
                        facilitypty.SHUTDOWN_REASON = ddp_trains.DDP_TRAIN_REASON;
                        SimpleODMConfig.FinderModelEntities.KocContext.SaveChanges();
                    }
                    else if (v_pp_s == 0m & v_ofo_s > 0m)
                    {
                        var facilitypty = new KOCFinder.FinderDBKOCModel.FACILITY_OPERATING_PTY();
                        facilitypty.PROCESS_HOURS = ddp_trains.DDP_TRAIN_PROCESS;
                        facilitypty.CIRCULATION_HOURS = ddp_trains.DDP_TRAIN_CIRC;
                        facilitypty.SALT_VOLUME = ddp_trains.DDP_TRAIN_SALT;
                        facilitypty.SHUTIN_TIME = ddp_trains.DDP_TRAIN_SHUT_TIME;
                        facilitypty.SHUTDOWN_REASON = ddp_trains.DDP_TRAIN_REASON;
                        facilitypty.OIL_FIELD_OPERATION_S = v_ofo_s;
                        facilitypty.FACILITY_OPERATING_PTY_S = GetFinderSeq();
                        SimpleODMConfig.FinderModelEntities.KocContext.AddToFACILITY_OPERATING_PTY(facilitypty);
                        SimpleODMConfig.FinderModelEntities.KocContext.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    v_ofo_s = default;
                    v_pp_s = default;
                }
            }


        }
        private void SaveCRUtoFinder()
        {
            foreach (var cru in hdr.NIGHT_FIGURES_CRU)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(cru.CRU_OIL_HDR_S, 0, false)))
                {
                    InsertIntoDailyProductionData(Conversions.ToDecimal(cru.CRU_OIL_HDR_S), st_date, default, Conversions.ToDecimal(cru.CRU_LIQUID), default, "", "Y");
                }
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(cru.CRU_GAS_HDR_S, 0, false)))
                {
                    InsertIntoDailyProductionData(Conversions.ToDecimal(cru.CRU_GAS_HDR_S), st_date, default, default, default, "", "Y", Conversions.ToString(cru.CRU_STAGE_SUCTION));
                }
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(cru.CRU_RICH_GAS_HDR_S, 0, false)))
                {
                    InsertIntoDailyProductionData(Conversions.ToDecimal(cru.CRU_RICH_GAS_HDR_S), st_date, default, default, default, "", "Y", Conversions.ToString(cru.CRU_RICH_GAS));
                }
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(cru.CRU_LEAN_GAS_HDR_S, 0, false)))
                {
                    InsertIntoDailyProductionData(Conversions.ToDecimal(cru.CRU_LEAN_GAS_HDR_S), st_date, default, default, default, "", "Y", Conversions.ToString(cru.CRU_LEAN_GAS));
                }
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(cru.CRU_HP_GAS_EXPORT_HDR_S, 0, false)))
                {
                    InsertIntoDailyProductionData(Conversions.ToDecimal(cru.CRU_HP_GAS_EXPORT_HDR_S), st_date, default, default, default, "", "Y", Conversions.ToString(cru.CRU_HP_GAS_EXPORT));
                }
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(cru.CRU_MP_GAS_EXPORT_HDR_S, 0, false)))
                {
                    InsertIntoDailyProductionData(Conversions.ToDecimal(cru.CRU_MP_GAS_EXPORT_HDR_S), st_date, default, default, default, "", "Y", Conversions.ToString(cru.CRU_MP_GAS_EXPORT));
                }
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(cru.CRU_LP_GAS_EXPORT_HDR_S, 0, false)))
                {
                    InsertIntoDailyProductionData(Conversions.ToDecimal(cru.CRU_LP_GAS_EXPORT_HDR_S), st_date, default, default, default, "", "Y", Conversions.ToString(cru.CRU_LP_GAS_EXPORT));
                }
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(cru.SRU_GAS_HDR_S, 0, false)))
                {
                    InsertIntoDailyProductionData(Conversions.ToDecimal(cru.SRU_GAS_HDR_S), st_date, default, default, default, "", "Y", Conversions.ToString(cru.SRU_GAS));
                }
                // -- Main Flare GAS
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(cru.CRU_FLARE_GAS_HDR_S, 0, false)))
                {
                    InsertIntoDailyProductionData(Conversions.ToDecimal(cru.CRU_FLARE_GAS_HDR_S), st_date, default, default, default, "", "Y", Conversions.ToString(cru.CRU_FLARE_GAS));
                }
                // -- Acid Flare GAS
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(cru.CRU_FLARE_GAS_ACID_HDR_S, 0, false)))
                {
                    InsertIntoDailyProductionData(Conversions.ToDecimal(cru.CRU_FLARE_GAS_ACID_HDR_S), st_date, default, default, default, "", "Y", Conversions.ToString(cru.CRU_FLARE_ACID_GAS));
                }
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(cru.CRU_PROD_MISC_HDR_S, 0, false)))
                {
                    InsertIntoDailyMiscellaneousData(Conversions.ToDecimal(cru.CRU_PROD_MISC_HDR_S), st_date, "RUNNING_HOURS", Conversions.ToString(cru.CRU_RUNNING_HOURS), "", "Y");
                    InsertIntoDailyMiscellaneousData(Conversions.ToDecimal(cru.CRU_PROD_MISC_HDR_S), st_date, "SPEED", Conversions.ToString(cru.CRU_SPEED), "", "Y");
                    InsertIntoDailyMiscellaneousData(Conversions.ToDecimal(cru.CRU_PROD_MISC_HDR_S), st_date, "UNLOADER", Conversions.ToString(cru.CRU_UNLOADER), "", "Y");
                    InsertIntoDailyMiscellaneousData(Conversions.ToDecimal(cru.CRU_PROD_MISC_HDR_S), st_date, "SHUT_REASON", Conversions.ToString(cru.CRU_SHUTDOWN_REASON), "", "Y");
                    InsertIntoDailyMiscellaneousData(Conversions.ToDecimal(cru.CRU_PROD_MISC_HDR_S), st_date, "TV LOAD", Conversions.ToString(cru.CRU_TV_LOAD), "", "Y");
                }
            }
        }
        private void SaveMisctoFinder()
        {
            if (hdr.NIGHT_FIGURES_DDP_MISC(0).MISC_HDR_S > 0)
            {
                InsertIntoDailyMiscellaneousData(hdr.NIGHT_FIGURES_DDP_MISC(0).MISC_HDR_S, st_date, "CHART_CRUDE_DESPATCHES", hdr.NIGHT_FIGURES_DDP_MISC(0).CHART_CRUDE_DESPATCH);
                InsertIntoDailyMiscellaneousData(hdr.NIGHT_FIGURES_DDP_MISC(0).MISC_HDR_S, st_date, "CHEMICAL_CONSUMPTION", hdr.NIGHT_FIGURES_DDP_MISC(0).CHEM_CONS_GAL);
                InsertIntoDailyMiscellaneousData(hdr.NIGHT_FIGURES_DDP_MISC(0).MISC_HDR_S, st_date, "WASH_WATER_CONSUMPTION", hdr.NIGHT_FIGURES_DDP_MISC(0).WASH_WATER_CONSUMPTION);
                InsertIntoDailyMiscellaneousData(hdr.NIGHT_FIGURES_DDP_MISC(0).MISC_HDR_S, st_date, "EFFLUENT_WATER_ANALYSIS", hdr.NIGHT_FIGURES_DDP_MISC(0).EFFLUENT_WATER_ANALYSIS);
                if (GC_ID == "GC15" | GC_ID == "GC23" | GC_ID == "GC25")
                {
                    InsertIntoDailyMiscellaneousData(hdr.NIGHT_FIGURES_DDP_MISC(0).MISC_HDR_S, st_date, "SCALE_INHIBITOR", hdr.NIGHT_FIGURES_DDP_MISC(0).SCALE);
                }
                InsertIntoDailyMiscellaneousData(hdr.NIGHT_FIGURES_DDP_MISC(0).MISC_HDR_S, st_date, "ANTI_FOAM", hdr.NIGHT_FIGURES_DDP_MISC(0).ANTIFOAM);
                InsertIntoDailyMiscellaneousData(hdr.NIGHT_FIGURES_DDP_MISC(0).MISC_HDR_S, st_date, "OXYGEN_SCAVENGER", hdr.NIGHT_FIGURES_DDP_MISC(0).OXYGEN);
            }


        }
        private class Pumpsp2
        {
            public decimal oil_field_operation_s { get; set; }
            public decimal facility_operating_pty_s { get; set; }
        }
        private void SaveEffluantWatertoFinder()
        {
            if (0 is var arg60 && eff_water_hdr_s is { } arg59 && arg59 > arg60)
            {
                InsertIntoDailyProductionData(eff_water_hdr_s, st_date, default, hdr.NIGHT_FIGURES_EWDP_HDR(0).EFF_WATER_PRODUCED);
            }

            foreach (var effluent_water in hdr.NIGHT_FIGURE_EFFLUENT_WATER)
            {
                decimal v_ofo_s = default;
                decimal v_pp_s = default;
                List<Pumpsp2> retint;
                try
                {
                    retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<Pumpsp2>(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("sELECT ofo.oil_field_operation_s, pp.facility_operating_pty_s   FROM koc.oil_field_operation ofo, koc.facility_operating_pty pp   WHERE pp.oil_field_operation_s (+) = ofo.oil_field_operation_s  AND ofo.surface_facility_s = " + gc_sf_s + "  AND to_date(to_char(ofo.start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy')    AND ofo.activity_type = 'WATER_DISPOSAL'    AND uwi = '", effluent_water.WELL), "'    AND ofo.well_completion_s ="), effluent_water.WELL_WC_S)).ToList;
                    if (retint.Count == 0)
                    {
                        retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<Pumpsp2>(Operators.ConcatenateObject(Operators.ConcatenateObject("sELECT ofo.oil_field_operation_s, pp.facility_operating_pty_s   FROM koc.oil_field_operation ofo, koc.facility_operating_pty pp   WHERE pp.oil_field_operation_s (+) = ofo.oil_field_operation_s  AND ofo.surface_facility_s = " + gc_sf_s + "  AND to_date(to_char(ofo.start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy')    AND ofo.activity_type = 'WATER_DISPOSAL'    AND uwi = '", effluent_water.WELL), "'")).ToList;
                    }
                    if (retint is not null)
                    {
                        v_ofo_s = retint.FirstOrDefault().oil_field_operation_s;
                        v_pp_s = retint.FirstOrDefault().facility_operating_pty_s;
                    }
                    if (v_ofo_s == 0m)
                    {
                        v_ofo_s = GetFinderSeq();
                        var ofo = new KOCFinder.FinderDBKOCModel.OIL_FIELD_OPERATION();
                        ofo.ACTIVITY_TYPE = "WATER_DISPOSAL";
                        ofo.SURFACE_FACILITY_S = gc_sf_s;
                        ofo.EXISTENCE_TYPE = "ACTUAL";
                        ofo.START_TIME = st_date;
                        ofo.UWI = effluent_water.WELL;
                        ofo.WELL_COMPLETION_S = effluent_water.WELL_WC_S;
                        ofo.OIL_FIELD_OPERATION_S = v_ofo_s;
                        var facilitypty = new KOCFinder.FinderDBKOCModel.FACILITY_OPERATING_PTY();
                        facilitypty.OPERATING_PRESS = effluent_water.PUMP_PRESSURE;
                        facilitypty.WHP_CASING = effluent_water.WHP_CASING;
                        facilitypty.WHP_TUBING = effluent_water.WHP_TUBING;
                        facilitypty.RUNNING_HOURS = effluent_water.RUNNING_HOURS;
                        facilitypty.SHUTDOWN_REASON = effluent_water.SHUT_REASON;
                        facilitypty.OIL_FIELD_OPERATION_S = v_ofo_s;
                        facilitypty.FACILITY_OPERATING_PTY_S = GetFinderSeq();
                        SimpleODMConfig.FinderModelEntities.KocContext.AddToOIL_FIELD_OPERATION(ofo);
                        SimpleODMConfig.FinderModelEntities.KocContext.AddToFACILITY_OPERATING_PTY(facilitypty);
                        SimpleODMConfig.FinderModelEntities.KocContext.SaveChanges();
                    }
                    else if (v_ofo_s > 0m & v_pp_s > 0m)
                    {
                        // Update Pump Data
                        KOCFinder.FinderDBKOCModel.FACILITY_OPERATING_PTY facilitypty = (from x in SimpleODMConfig.FinderModelEntities.KocContext.FACILITY_OPERATING_PTY
                                                                                         where x.FACILITY_OPERATING_PTY_S == v_pp_s
                                                                                         select x).FirstOrDefault;
                        facilitypty.OPERATING_PRESS = effluent_water.PUMP_PRESSURE;
                        facilitypty.WHP_CASING = effluent_water.WHP_CASING;
                        facilitypty.WHP_TUBING = effluent_water.WHP_TUBING;
                        facilitypty.RUNNING_HOURS = effluent_water.RUNNING_HOURS;
                        facilitypty.SHUTDOWN_REASON = effluent_water.SHUT_REASON;
                        SimpleODMConfig.FinderModelEntities.KocContext.SaveChanges();
                    }
                    else if (v_pp_s == 0m & v_ofo_s > 0m)
                    {
                        var facilitypty = new KOCFinder.FinderDBKOCModel.FACILITY_OPERATING_PTY();
                        facilitypty.OPERATING_PRESS = effluent_water.PUMP_PRESSURE;
                        facilitypty.WHP_CASING = effluent_water.WHP_CASING;
                        facilitypty.WHP_TUBING = effluent_water.WHP_TUBING;
                        facilitypty.RUNNING_HOURS = effluent_water.RUNNING_HOURS;
                        facilitypty.SHUTDOWN_REASON = effluent_water.SHUT_REASON;
                        facilitypty.OIL_FIELD_OPERATION_S = v_ofo_s;
                        facilitypty.FACILITY_OPERATING_PTY_S = GetFinderSeq();
                        SimpleODMConfig.FinderModelEntities.KocContext.AddToFACILITY_OPERATING_PTY(facilitypty);
                        SimpleODMConfig.FinderModelEntities.KocContext.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    v_ofo_s = default;
                    v_pp_s = default;
                }
            }
            if ((0 is var arg62 && EWDP1_HDR_S is { } arg61 ? arg61 > arg62 : (bool?)null) & hdr.NIGHT_FIGURES_EWDP_HDR(0).EFF_WATER_IN_EWDP1 > 0)
            {
                InsertIntoDailyProductionData(EWDP1_HDR_S, st_date, default, hdr.NIGHT_FIGURES_EWDP_HDR(0).EFF_WATER_IN_EWDP1);
            }

        }
        private void SaveDispatchPumptoFinder()
        {
            foreach (var despatch_pump in hdr.NIGHT_FIGURES_EWDP_PUMPS)
            {
                if (Conversions.ToBoolean(Operators.AndObject(string.IsNullOrEmpty(Conversions.ToString(despatch_pump.DPUMP_ID)) == false, Operators.ConditionalCompareObjectGreater(despatch_pump.DPUMP_RUNNING_HOURS, 0, false))))
                {
                    decimal v_ofo_s = default;
                    decimal v_pp_s = default;

                    Pumpsp1 retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<Pumpsp1>(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(" SELECT ofo.oil_field_operation_s, pp.pump_pty_s FROM koc.oil_field_operation ofo, koc.pump_pty pp WHERE pp.oil_field_operation_s (+) = ofo.oil_field_operation_s AND ofo.surface_facility_s =", despatch_pump.DPUMP_S), "  AND to_date(to_char(ofo.start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('"), txt_date), "','dd/mm/yyyy') AND ofo.activity_type = 'FACILITY_OPERATION'")).FirstOrDefault;
                    if (retint is not null)
                    {
                        v_ofo_s = retint.oil_field_operation_s;
                        v_pp_s = retint.pump_pty_s;
                    }
                    if (v_ofo_s == 0m)
                    {
                        v_ofo_s = GetFinderSeq();
                        var ofo = new KOCFinder.FinderDBKOCModel.OIL_FIELD_OPERATION();
                        ofo.ACTIVITY_TYPE = "FACILITY_OPERATION";
                        ofo.SURFACE_FACILITY_S = despatch_pump.DPUMP_S;
                        ofo.EXISTENCE_TYPE = "ACTUAL";
                        ofo.START_TIME = st_date;
                        ofo.OIL_FIELD_OPERATION_S = v_ofo_s;
                        var Pump = new KOCFinder.FinderDBKOCModel.PUMP_PTY();
                        Pump.RUNNING_HOURS = despatch_pump.DPUMP_RUNNING_HOURS;
                        Pump.OIL_FIELD_OPERATION_S = v_ofo_s;
                        Pump.PUMP_PTY_S = GetFinderSeq();
                        SimpleODMConfig.FinderModelEntities.KocContext.AddToOIL_FIELD_OPERATION(ofo);
                        SimpleODMConfig.FinderModelEntities.KocContext.AddToPUMP_PTY(Pump);
                        SimpleODMConfig.FinderModelEntities.KocContext.SaveChanges();
                    }
                    else if (v_ofo_s > 0m & v_pp_s > 0m)
                    {
                        // Update Pump Data
                        KOCFinder.FinderDBKOCModel.PUMP_PTY Pump = (from x in SimpleODMConfig.FinderModelEntities.KocContext.PUMP_PTY
                                                                    where x.PUMP_PTY_S == v_pp_s
                                                                    select x).FirstOrDefault;
                        Pump.RUNNING_HOURS = despatch_pump.DPUMP_RUNNING_HOURS;
                        SimpleODMConfig.FinderModelEntities.KocContext.SaveChanges();
                    }
                    else if (v_pp_s == 0m & v_ofo_s > 0m)
                    {
                        var Pump = new KOCFinder.FinderDBKOCModel.PUMP_PTY();
                        Pump.RUNNING_HOURS = despatch_pump.DPUMP_RUNNING_HOURS;
                        Pump.OIL_FIELD_OPERATION_S = v_ofo_s;
                        Pump.PUMP_PTY_S = GetFinderSeq();
                        SimpleODMConfig.FinderModelEntities.KocContext.AddToPUMP_PTY(Pump);
                        SimpleODMConfig.FinderModelEntities.KocContext.SaveChanges();
                    }
                }
            }

        }
        public void SaveToFinder()
        {
            if (GC_ID != "GC27" | GC_ID != "28")
            {
                hdr.NIGHT_FIGURES_EWDP_HDR(0).EFF_WATER_PRODUCED = hdr.NIGHT_FIGURE_DDP(0).DDP_L_SEP_WATER + hdr.NIGHT_FIGURES_DDP_MISC(0).WASH_WATER_CONSUMPTION;
            }
            else
            {
                hdr.NIGHT_FIGURES_EWDP_HDR(0).EFF_WATER_PRODUCED = hdr.NIGHT_FIGURE_DDP(0).DDP_L_SEP_WATER + hdr.NIGHT_FIGURE_DDP(0).DDP_M_SEP_WATER + hdr.NIGHT_FIGURES_DDP_MISC(0).WASH_WATER_CONSUMPTION;
                l_retint = hdr.NIGHT_FIGURES_PROD_STOCK(1);
                m_retint = hdr.NIGHT_FIGURES_PROD_STOCK(2);
            }
            PROD_STOCK = hdr.NIGHT_FIGURES_PROD_STOCK(0);
            // -----------------------------------------------------------------
            // ---------		DESPATCHES AND PRODUCTION	-----------
            // -----------------------------------------------------------------
            SaveDispatchtoFinder();
            // --------------------------------------------------------------
            // -----------		TANKS & STOCK		----------------
            // --------------------------------------------------------------
            SaveTankstoFinder();
            // --------------------------------------------------------------
            // -------		PUMPS				--------
            // --------------------------------------------------------------
            SavePumpstoFinder();
            // --------------------------------------------------------------
            // -------		TURBINES				--------
            // --------------------------------------------------------------
            SaveTurbinestoFinder();
            // ------------------------------------------
            // ----		CRU DATA		----
            // ------------------------------------------
            SaveCRUtoFinder();
            // --------------------------------------------------------
            // ----------		DDP DATA		----------
            // -------------------------------------------------------- 
            SaveDDPToFinder();
            // ------------------------------------------------------
            // --------		DDP HEATERS		--------
            // ------------------------------------------------------
            SaveDDPHeaterstoFinder();
            // ------------------------------------------------------
            // --------		DDP TRAINS		--------
            // ------------------------------------------------------
            SaveDDPTrainstoFinder();
            // ---------------------------------------------------------
            // ---------		MISC DATA		-----------
            // ---------------------------------------------------------

            SaveMisctoFinder();
            // --------------------------------------------------------------------
            // ------------		EFFLUENT WATER DATA		--------------
            // --------------------------------------------------------------------
            SaveEffluantWatertoFinder();

            // -------		DESPATCH_PUMPS				--------
            // --------------------------------------------------------------

            SaveDispatchPumptoFinder();

            // -- ========
            // --  Tank Effluent Water

            if (0 is var arg64 && EFF_WATER_TANK_HDR_S is { } arg63 && arg63 > arg64)
            {
                InsertIntoDailyProductionData(EFF_WATER_TANK_HDR_S, st_date, default, hdr.NIGHT_FIGURES_EWDP_HDR(0).EFF_WATER_STOCK);
            }
            // -- Save Eff Water - IN
            if ((0 is var arg66 && EFF_WATER_IN_HDR_S is { } arg65 ? arg65 > arg66 : (bool?)null) & hdr.NIGHT_FIGURES_EWDP_HDR(0).EFF_WATER_IN > 0)
            {
                InsertIntoDailyProductionData(EFF_WATER_IN_HDR_S, st_date, default, hdr.NIGHT_FIGURES_EWDP_HDR(0).EFF_WATER_IN);
            }
            // --- ======
            // -- Save Eff Water - Out
            if ((0 is var arg68 && EFF_WATER_OUT_HDR_S is { } arg67 ? arg67 > arg68 : (bool?)null) & hdr.NIGHT_FIGURES_EWDP_HDR(0).EFF_WATER_OUT > 0)
            {
                InsertIntoDailyProductionData(EFF_WATER_OUT_HDR_S, st_date, default, hdr.NIGHT_FIGURES_EWDP_HDR(0).EFF_WATER_OUT);
            }
        }
        #endregion
        #region  Get Data From Finder
        private class GCclsspecs
        {
            public string facility_id { get; set; }
            public int surface_facility_s { get; set; }
        }
        private class TankSpecs
        {
            public int factor { get; set; }
            public int initial_offset { get; set; }
            public int tank_capacity { get; set; }
        }
        private class PumpsSpecs
        {
            public int running_hours { get; set; }
            public string shutdown_reason { get; set; }
        }
        private class DDPSpecs
        {
            public decimal liquid_volume { get; set; }
            public decimal nominal_water_cut { get; set; }
            public string remarks { get; set; }
        }
        private class DDPSpecs1
        {
            public decimal liquid_volume { get; set; }
            public decimal nominal_water_cut { get; set; }
            public string remarks { get; set; }
        }
        private class ddptrainspecs
        {
            public decimal process_hours { get; set; }
            public decimal circulation_hours { get; set; }
            public decimal salt_volume { get; set; }
            public decimal shutin_time { get; set; }
            public string shutdown_reason { get; set; }
        }
        private class ewdpwellsspecs
        {
            // fop.operating_press, fop.whp_casing, fop.whp_tubing, fop.running_hours, fop.SHUTDOWN_REASON 
            public decimal operating_press { get; set; }
            public decimal whp_casing { get; set; }
            public decimal whp_tubing { get; set; }
            public decimal running_hours { get; set; }
            public string SHUTDOWN_REASON { get; set; }
        }
        private void GetTanks()
        {
            var Parameters = new Devart.Data.Oracle.OracleParameter[2];
            Parameters[0] = new Devart.Data.Oracle.OracleParameter("st_date", st_date);
            Parameters[1] = new Devart.Data.Oracle.OracleParameter("gc_sf_s", gc_sf_s);
            Parameters = null;
            List<DhubEntities.NIGHT_FIGURES_TANKS> retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<DhubEntities.NIGHT_FIGURES_TANKS>("  SELECT decode(sf.facility_id, 'EPF120_LP_WET_1', sf.facility_id || ' Reject Tank',sf.facility_id) tank_id , sf.surface_facility_s tank_sf_s,  sf.fluid_state  FROM koc.surface_facility sf, koc.facility_composition fc  WHERE sf.facility_type = 'GC TANK'   AND sf.surface_facility_s = fc.part_surface_facility_s     AND (fc.end_time Is Null or to_date(to_char(fc.end_time,'dd/mm/yyyy'),'dd/mm/yyyy') > to_date('" + txt_date + "','dd/mm/yyyy'))     AND fc.whole_surface_facility_s =" + gc_sf_s + "   ORDER BY sf.catalog_number", Parameters).ToList;
            hdr.NIGHT_FIGURES_TANKS.Clear();

            foreach (var r in retint)
            {
                r.GC = GC_ID;
                // r.HDR_ID = ID
                r.ID = GetSeq();
                hdr.NIGHT_FIGURES_TANKS.Add(r);
                // SimpleODMConfig.DhubContext.NIGHT_FIGURES_TANKS.AddObject(r)
            }
            foreach (var tank in hdr.NIGHT_FIGURES_TANKS)
            {
                int Tank_HDR_S = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>(Operators.ConcatenateObject("SELECT dph.daily_production_hdr_s  FROM koc.daily_production_hdr dph, koc.general_port gp  WHERE dph.activity_type = 'MEASURED' AND dph.flow_dir_type = 'STOCK' AND dph.material_type = 'OIL'   AND dph.general_port_s = gp.general_port_s AND gp.facility_type = 'INLET_PORT'    AND gp.surface_facility_s =", tank.TANK_SF_S)).FirstOrDefault;
                tank.TANK_HDR_S = (object)Tank_HDR_S;
                TankSpecs TanksSpecsList = SimpleODMConfig.FinderModelEntities.KocCodesContext.ExecuteStoreQuery<TankSpecs>(Operators.ConcatenateObject(Operators.ConcatenateObject("  SELECT  nt.factor, nt.initial_offset, nt.storage_capacity tank_capacity  FROM  codes.n_tank nt   WHERE nt.catalog_number ='", tank.TANK_ID), "'")).FirstOrDefault;
                tank.FACTOR = (object)TanksSpecsList.factor;
                tank.INITIAL_OFFSET = (object)TanksSpecsList.initial_offset;
                tank.TANK_CAPACITY = (object)TanksSpecsList.tank_capacity;
            }
        }
        private void GetPumps()
        {
            var Parameters = new Devart.Data.Oracle.OracleParameter[2];
            Parameters[0] = new Devart.Data.Oracle.OracleParameter("st_date", st_date);
            Parameters[1] = new Devart.Data.Oracle.OracleParameter("gc_sf_s", gc_sf_s);
            Parameters = null;
            List<DhubEntities.NIGHT_FIGURES_PUMPS> retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<DhubEntities.NIGHT_FIGURES_PUMPS>(" SELECT sf.facility_id pump_id, sf.surface_facility_s  pump_s     FROM koc.surface_facility sf, koc.facility_composition fc       WHERE sf.facility_type = 'PUMP'         AND sf.surface_facility_s = fc.part_surface_facility_s         AND (fc.end_time Is Null or  to_date(to_char(fc.end_time,'dd/mm/yyyy'),'dd/mm/yyyy') > to_date('" + txt_date + "','dd/mm/yyyy'))          AND fc.whole_surface_facility_s = " + gc_sf_s + "       ORDER BY sf.facility_id", Parameters).ToList;
            hdr.NIGHT_FIGURES_PUMPS.Clear();
            foreach (var r in retint)
            {
                r.GC = GC_ID;
                // r.HDR_ID = ID
                r.ID = GetSeq();
                hdr.NIGHT_FIGURES_PUMPS.Add(r);
                // SimpleODMConfig.DhubContext.NIGHT_FIGURES_PUMPS.AddObject(r)
            }


        }
        private void GetTurbines()
        {
            var Parameters = new Devart.Data.Oracle.OracleParameter[2];
            Parameters[0] = new Devart.Data.Oracle.OracleParameter("st_date", st_date);
            Parameters[1] = new Devart.Data.Oracle.OracleParameter("gc_sf_s", gc_sf_s);
            Parameters = null;
            List<DhubEntities.NIGHT_FIGURE_TURBINES> retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<DhubEntities.NIGHT_FIGURE_TURBINES>("  SELECT sf.facility_name turbine_id, sf.surface_facility_s turbine_s FROM koc.surface_facility sf, koc.facility_composition fc   WHERE sf.facility_type = 'GAS_TURBINE'       AND sf.surface_facility_s = fc.part_surface_facility_s     AND (fc.end_time Is Null or  to_date(to_char(fc.end_time,'dd/mm/yyyy'),'dd/mm/yyyy') > to_date('" + txt_date + "','dd/mm/yyyy'))       AND fc.whole_surface_facility_s = " + gc_sf_s + "         ORDER BY sf.facility_id", Parameters).ToList;
            hdr.NIGHT_FIGURE_TURBINES.Clear();
            foreach (var r in retint)
            {
                r.GC = GC_ID;
                // r.HDR_ID = ID
                r.ID = GetSeq();
                hdr.NIGHT_FIGURE_TURBINES.Add(r);
                // SimpleODMConfig.DhubContext.NIGHT_FIGURE_TURBINES.AddObject(r)
            }
            foreach (var tur in hdr.NIGHT_FIGURE_TURBINES)
            {
                try
                {
                    int TURBINE_OUTLET_PORT = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>(Operators.ConcatenateObject(" SELECT general_port_s  FROM koc.general_port   WHERE facility_type = 'OUTLET_PORT' AND surface_facility_s =", tur.TURBINE_S)).FirstOrDefault;
                    tur.TURBINE_OUTLET_PORT = (object)TURBINE_OUTLET_PORT;
                    LogOutPut.Add("Got TURBINE_OUTLET_PORT");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No TURBINE_OUTLET_PORT");
                    tur.TURBINE_OUTLET_PORT = "";
                }
                if (string.IsNullOrEmpty(Conversions.ToString(tur.TURBINE_OUTLET_PORT)) == false)
                {
                    try
                    {
                        int TURBINE_GAS_HDR_S = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>(Operators.ConcatenateObject("SELECT daily_miscellaneous_hdr_s FROM koc.daily_miscellaneous_hdr  WHERE activity_type = 'MEASURED' AND flow_dir_type = 'CONSUMED' AND material_type = 'GAS'   AND general_port_s =", tur.TURBINE_OUTLET_PORT)).FirstOrDefault;
                        tur.TURBINE_GAS_HDR_S = (object)TURBINE_GAS_HDR_S;
                        LogOutPut.Add("Got TURBINE_GAS_HDR_S");
                    }
                    catch (Exception ex)
                    {
                        LogOutPut.Add("No TURBINE_GAS_HDR_S");
                        tur.TURBINE_GAS_HDR_S = "";
                    }
                }



            }
        }
        private void GetCRU()
        {
            var Parameters = new Devart.Data.Oracle.OracleParameter[2];
            Parameters[0] = new Devart.Data.Oracle.OracleParameter("st_date", st_date);
            Parameters[1] = new Devart.Data.Oracle.OracleParameter("gc_sf_s", gc_sf_s);
            Parameters = null;
            List<DhubEntities.NIGHT_FIGURES_CRU> retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<DhubEntities.NIGHT_FIGURES_CRU>(" SELECT decode('" + GC_ID + "', 'EPF-120', substr(sf.facility_id, 5, 30), sf.facility_id) cru_id, sf.surface_facility_s CRU_S FROM koc.surface_facility sf, koc.facility_composition fc  WHERE sf.facility_type = 'GAS COMPRESSOR'  AND sf.surface_facility_s = fc.part_surface_facility_s     AND (fc.end_time Is Null or to_date(to_char(fc.end_time,'dd/mm/yyyy'),'dd/mm/yyyy') > to_date('" + txt_date + "','dd/mm/yyyy'))    AND fc.whole_surface_facility_s =" + gc_sf_s + "    ORDER BY sf.facility_id", Parameters).ToList;
            hdr.NIGHT_FIGURES_CRU.Clear();
            foreach (var cr in retint)
            {
                cr.GC = GC_ID;
                // cr.HDR_ID = ID
                cr.ID = GetSeq();

                try
                {
                    int cru_inlet_port = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>(" SELECT general_port_s  FROM koc.general_port   WHERE facility_type = 'INLET_PORT' AND surface_facility_s =" + cr.CRU_S).FirstOrDefault;
                    cr.CRU_INLET_PORT = cru_inlet_port;
                    LogOutPut.Add("Got cru_inlet_port");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No cru_inlet_port");
                    cr.CRU_INLET_PORT = "";
                }
                try
                {
                    int cru_outlet_port = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>(" SELECT general_port_s  FROM koc.general_port   WHERE facility_type = 'OUTLET_PORT' AND surface_facility_s =" + cr.CRU_S).FirstOrDefault;
                    cr.CRU_OUTLET_PORT = cru_outlet_port;
                    LogOutPut.Add("Got cru_outlet_port");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No cru_outlet_port");
                    cr.CRU_OUTLET_PORT = "";
                }
                try
                {
                    int cru_oil_hdr_s = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("SELECT daily_production_hdr_s  FROM koc.daily_production_hdr   WHERE activity_type = 'MEASURED' AND flow_dir_type = 'PRODUCTION' AND material_type = 'OIL'    AND general_port_s =" + cr.CRU_OUTLET_PORT).FirstOrDefault;
                    cr.CRU_OIL_HDR_S = cru_oil_hdr_s;
                    LogOutPut.Add("Got cru_oil_hdr_s");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No cru_oil_hdr_s");
                    cr.CRU_OIL_HDR_S = "";
                }
                try
                {
                    int cru_gas_hdr_s = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>(" SELECT daily_production_hdr_s  FROM koc.daily_production_hdr  WHERE activity_type = 'MEASURED' AND flow_dir_type = 'PRODUCTION' AND material_type = 'GAS'  AND general_port_s =" + cr.CRU_INLET_PORT).FirstOrDefault;
                    cr.CRU_GAS_HDR_S = cru_gas_hdr_s;
                    LogOutPut.Add("Got cru_gas_hdr_s");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No cru_gas_hdr_s");
                    cr.CRU_GAS_HDR_S = "";
                }
                try
                {
                    int cru_rich_gas_hdr_s = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("SELECT daily_production_hdr_s  FROM koc.daily_production_hdr  WHERE activity_type = 'MEASURED' AND flow_dir_type = 'PRODUCTION' AND material_type = 'RICH GAS'   AND general_port_s =" + cr.CRU_OUTLET_PORT).FirstOrDefault;
                    cr.CRU_RICH_GAS_HDR_S = cru_rich_gas_hdr_s;
                    LogOutPut.Add("Got cru_rich_gas_hdr_s");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No cru_rich_gas_hdr_s");
                    cr.CRU_RICH_GAS_HDR_S = "";
                }
                try
                {
                    int cru_lean_gas_hdr_s = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>(" SELECT daily_production_hdr_s  FROM koc.daily_production_hdr  WHERE activity_type = 'MEASURED' AND flow_dir_type = 'PRODUCTION' AND material_type = 'LEAN GAS'  AND general_port_s =" + cr.CRU_OUTLET_PORT).FirstOrDefault;
                    cr.CRU_LEAN_GAS_HDR_S = cru_lean_gas_hdr_s;
                    LogOutPut.Add("Got cru_lean_gas_hdr_s");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No cru_lean_gas_hdr_s");
                    cr.CRU_LEAN_GAS_HDR_S = "";
                }

                if (GC_ID == "GC23" | GC_ID == "GC25" | GC_ID == "GC15" | GC_ID == "GC22")
                {
                    try
                    {
                        int cru_hp_gas_export_hdr_s = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("SELECT daily_production_hdr_s   FROM koc.daily_production_hdr     WHERE activity_type = 'MEASURED' AND flow_dir_type = 'EXPORT' AND material_type = 'HP_GAS'   AND general_port_s =" + cr.CRU_OUTLET_PORT).FirstOrDefault;
                        cr.CRU_HP_GAS_EXPORT_HDR_S = cru_hp_gas_export_hdr_s;
                        LogOutPut.Add("Got cru_hp_gas_export_hdr_s");
                    }
                    catch (Exception ex)
                    {
                        LogOutPut.Add("No cru_hp_gas_export_hdr_s");
                        cr.CRU_HP_GAS_EXPORT_HDR_S = "";
                    }
                    try
                    {
                        int cru_mp_gas_export_hdr_s = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("SELECT daily_production_hdr_s  FROM koc.daily_production_hdr  WHERE activity_type = 'MEASURED' AND flow_dir_type = 'EXPORT' AND material_type = 'MP_GAS' AND general_port_s =" + cr.CRU_OUTLET_PORT).FirstOrDefault;
                        cr.CRU_MP_GAS_EXPORT_HDR_S = cru_mp_gas_export_hdr_s;
                        LogOutPut.Add("Got cru_mp_gas_export_hdr_s");
                    }
                    catch (Exception ex)
                    {
                        LogOutPut.Add("No cru_mp_gas_export_hdr_s");
                        cr.CRU_MP_GAS_EXPORT_HDR_S = "";
                    }
                    try
                    {
                        int cru_lp_gas_export_hdr_s = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("SELECT daily_production_hdr_s  FROM koc.daily_production_hdr WHERE activity_type = 'MEASURED' AND flow_dir_type = 'EXPORT' AND material_type = 'LP_GAS' AND general_port_s =" + cr.CRU_OUTLET_PORT).FirstOrDefault;
                        cr.CRU_MP_GAS_EXPORT_HDR_S = cru_lp_gas_export_hdr_s;
                        LogOutPut.Add("Got cru_lp_gas_export_hdr_s");
                    }
                    catch (Exception ex)
                    {
                        LogOutPut.Add("No cru_lp_gas_export_hdr_s");
                        cr.CRU_LP_GAS_EXPORT_HDR_S = "";
                    }
                    try
                    {
                        int sru_gas_hdr_s = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("SELECT daily_production_hdr_s FROM koc.daily_production_hdr WHERE activity_type = 'MEASURED' AND flow_dir_type = 'EXPORT' AND material_type = 'SRU_GAS' AND general_port_s =" + cr.CRU_OUTLET_PORT).FirstOrDefault;
                        cr.SRU_GAS_HDR_S = sru_gas_hdr_s;
                        LogOutPut.Add("Got sru_gas_hdr_s");
                    }
                    catch (Exception ex)
                    {
                        LogOutPut.Add("No sru_gas_hdr_s");
                        cr.SRU_GAS_HDR_S = "";
                    }

                }
                if (GC_ID == "EPF-50")
                {
                    try
                    {
                        int cru_mp_gas_export_hdr_s = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("SELECT daily_production_hdr_s  FROM koc.daily_production_hdr  WHERE activity_type = 'MEASURED' AND flow_dir_type = 'EXPORT' AND material_type = 'MP_GAS' AND general_port_s =" + cr.CRU_OUTLET_PORT).FirstOrDefault;
                        cr.CRU_MP_GAS_EXPORT_HDR_S = cru_mp_gas_export_hdr_s;
                        LogOutPut.Add("Got cru_mp_gas_export_hdr_s");
                    }
                    catch (Exception ex)
                    {
                        LogOutPut.Add("No cru_mp_gas_export_hdr_s");
                        cr.CRU_MP_GAS_EXPORT_HDR_S = "";
                    }
                    try
                    {
                        int cru_flare_gas_hdr_s = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>(" SELECT daily_production_hdr_s  FROM koc.daily_production_hdr WHERE activity_type = 'FLARED_MAIN' AND flow_dir_type = 'FLARED' AND material_type = 'GAS' AND general_port_s =" + cr.CRU_OUTLET_PORT).FirstOrDefault;
                        cr.CRU_FLARE_GAS_HDR_S = cru_flare_gas_hdr_s;
                        LogOutPut.Add("Got cru_flare_gas_hdr_s");
                    }
                    catch (Exception ex)
                    {
                        LogOutPut.Add("No cru_flare_gas_hdr_s");
                        cr.CRU_FLARE_GAS_HDR_S = "";
                    }
                    try
                    {
                        int cru_flare_gas_acid_hdr_s = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>(" SELECT daily_production_hdr_s  FROM koc.daily_production_hdr  WHERE activity_type = 'FLARED_ACID' AND flow_dir_type = 'FLARED' AND material_type = 'GAS'    AND general_port_s =" + cr.CRU_OUTLET_PORT).FirstOrDefault;
                        cr.CRU_FLARE_GAS_ACID_HDR_S = cru_flare_gas_acid_hdr_s;
                        LogOutPut.Add("Got cru_flare_gas_acid_hdr_s");
                    }
                    catch (Exception ex)
                    {
                        LogOutPut.Add("No cru_flare_gas_acid_hdr_s");
                        cr.CRU_FLARE_GAS_ACID_HDR_S = "";
                    }
                }
                try
                {
                    int cru_prod_misc_hdr_s = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("SELECT daily_miscellaneous_hdr_s  FROM koc.daily_miscellaneous_hdr  WHERE activity_type = 'MEASURED' AND flow_dir_type = 'PRODUCTION' AND material_type = 'OIL'  AND general_port_s =" + cr.CRU_OUTLET_PORT).FirstOrDefault;
                    cr.CRU_PROD_MISC_HDR_S = cru_prod_misc_hdr_s;
                    LogOutPut.Add("Got cru_prod_misc_hdr_s");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No cru_prod_misc_hdr_s");
                    cr.CRU_PROD_MISC_HDR_S = "";
                }
                hdr.NIGHT_FIGURES_CRU.Add(cr);
                // SimpleODMConfig.DhubContext.NIGHT_FIGURES_CRU.AddObject(cr)
            }
        }
        private void GetDdpTrains()
        {
            var ddp_s = default(int);
            try
            {
                int ddp_l_s = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>(" SELECT daily_production_hdr_s  FROM koc.daily_production_hdr   WHERE activity_type = 'MEASURED' AND flow_dir_type = 'STOCK' AND material_type = 'OIL'   AND general_port_s = " + gc_stock_port).FirstOrDefault;
                ddp.DDP_L_S = ddp_l_s;
                LogOutPut.Add("Got ddp_l_s");
            }
            catch (Exception ex)
            {
                LogOutPut.Add("No ddp_l_s");
            }
            try
            {
                int ddp_m_s = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("SELECT sf.surface_facility_s  FROM koc.surface_facility sf, koc.facility_composition fc WHERE sf.facility_type = 'DEHYDRATION DESALINATION PLANT' AND sf.facility_id like '%M%' AND sf.surface_facility_s = fc.part_surface_facility_s  AND fc.whole_surface_facility_s = " + gc_sf_s).FirstOrDefault;
                ddp.DDP_M_S = ddp_m_s;
                LogOutPut.Add("Got ddp_m_s");
            }
            catch (Exception ex)
            {
                LogOutPut.Add("No ddp_m_s");
            }
            try
            {
                ddp_s = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("SELECT sf.surface_facility_s  FROM koc.surface_facility sf, koc.facility_composition fc   WHERE sf.facility_type = 'DEHYDRATION DESALINATION PLANT' AND sf.surface_facility_s = fc.part_surface_facility_s  AND fc.whole_surface_facility_s =" + gc_sf_s).FirstOrDefault;
                ddp.DDP_S = ddp_s;
                LogOutPut.Add("Got ddp_s");
            }
            catch (Exception ex)
            {
                LogOutPut.Add("No ddp_s");
            }
            if (ddp_s > 0)
            {
                try
                {
                    int ddp_inlet_port = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("SELECT general_port_s FROM koc.general_port  WHERE surface_facility_s = " + ddp_s + " AND facility_type = 'INLET_PORT'").FirstOrDefault;
                    ddp.DDP_INLET_PORT = ddp_inlet_port;
                    LogOutPut.Add("Got ddp_inlet_port");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No ddp_inlet_port");
                }
                try
                {
                    int ddp_outlet_port = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("SELECT general_port_s FROM koc.general_port  WHERE surface_facility_s = " + ddp_s + " AND facility_type = 'OUTLET_PORT'").FirstOrDefault;
                    ddp.DDP_OUTLET_PORT = ddp_outlet_port;
                    LogOutPut.Add("Got ddp_outlet_port");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No ddp_outlet_port");
                }
                try
                {
                    int ddp_in_l_hdr_s = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("SELECT daily_production_hdr_s  FROM koc.daily_production_hdr WHERE activity_type = 'MEASURED' AND flow_dir_type = 'PRODUCTION' AND material_type = 'OIL'  AND general_port_s =" + ddp.DDP_INLET_PORT).FirstOrDefault;
                    ddp.DDP_IN_L_HDR_S = ddp_in_l_hdr_s;
                    LogOutPut.Add("Got ddp_in_l_hdr_s");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No ddp_in_l_hdr_s");
                }
                try
                {
                    int ddp_in_l_dry_hdr_s = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("SELECT daily_production_hdr_s  FROM koc.daily_production_hdr   WHERE activity_type = 'MEASURED' AND flow_dir_type = 'PRODUCTION' AND material_type = 'DRY OIL'   AND general_port_s = " + ddp.DDP_INLET_PORT).FirstOrDefault;
                    ddp.DDP_IN_L_DRY_HDR_S = ddp_in_l_dry_hdr_s;
                    LogOutPut.Add("Got ddp_in_l_dry_hdr_s");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No ddp_in_l_dry_hdr_s");
                }
                try
                {
                    int ddp_in_l_wet_hdr_s = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>(" SELECT daily_production_hdr_s  FROM koc.daily_production_hdr   WHERE activity_type = 'MEASURED' AND flow_dir_type = 'PRODUCTION' AND material_type = 'WET OIL'  AND general_port_s = " + ddp.DDP_INLET_PORT).FirstOrDefault;
                    ddp.DDP_IN_L_WET_HDR_S = ddp_in_l_wet_hdr_s;
                    LogOutPut.Add("Got ddp_in_l_wet_hdr_s");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No ddp_in_l_wet_hdr_s");
                }
                try
                {
                    int ddp_out_l_hdr_s = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("SELECT daily_production_hdr_s  FROM koc.daily_production_hdr  WHERE activity_type = 'MEASURED' AND flow_dir_type = 'PRODUCTION' AND material_type = 'OIL' AND general_port_s = " + ddp.DDP_OUTLET_PORT).FirstOrDefault;
                    ddp.DDP_OUT_L_HDR_S = ddp_out_l_hdr_s;
                    LogOutPut.Add("Got ddp_out_l_hdr_s");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No ddp_out_l_hdr_s");
                }
                try
                {
                    int ddp_out_l_water_hdr_s = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("SELECT daily_production_hdr_s  FROM koc.daily_production_hdr WHERE activity_type = 'MEASURED' AND flow_dir_type = 'PRODUCTION' AND material_type = 'WATER' AND general_port_s =" + ddp.DDP_OUTLET_PORT).FirstOrDefault;
                    ddp.DDP_OUT_L_WATER_HDR_S = ddp_out_l_water_hdr_s;
                    LogOutPut.Add("Got ddp_out_l_water_hdr_s");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No ddp_out_l_water_hdr_s");
                }
                // ------------------------------------------------------
                // -------------------- Light and Medium
                // ------------------------------------------------------
                if (ddp.DDP_L_S.HasValue)
                {
                    try
                    {
                        int ddp_in_l_hdr_s = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>(" SELECT daily_production_hdr_s  FROM koc.daily_production_hdr  WHERE activity_type = 'MEASURED' AND flow_dir_type = 'PRODUCTION' AND material_type = 'LIGHT OIL'   AND general_port_s = " + ddp.DDP_INLET_PORT_L).FirstOrDefault;
                        ddp.DDP_IN_L_HDR_S = ddp_in_l_hdr_s;
                        LogOutPut.Add("Got ddp_in_l_hdr_s");
                    }
                    catch (Exception ex)
                    {
                        LogOutPut.Add("No ddp_in_l_hdr_s");
                    }
                    try
                    {
                        int ddp_in_l_dry_hdr_s = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("SELECT daily_production_hdr_s  FROM koc.daily_production_hdr  WHERE activity_type = 'MEASURED' AND flow_dir_type = 'PRODUCTION' AND material_type = 'LIGHT DRY OIL'  AND general_port_s = " + ddp.DDP_INLET_PORT_L).FirstOrDefault;
                        ddp.DDP_IN_L_DRY_HDR_S = ddp_in_l_dry_hdr_s;
                        LogOutPut.Add("Got ddp_in_l_dry_hdr_s");
                    }
                    catch (Exception ex)
                    {
                        LogOutPut.Add("No ddp_in_l_dry_hdr_s");
                    }
                    try
                    {
                        int ddp_in_l_wet_hdr_s = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("SELECT daily_production_hdr_s INTO :ddp.ddp_in_l_wet_hdr_s FROM koc.daily_production_hdr   WHERE activity_type = 'MEASURED' AND flow_dir_type = 'PRODUCTION' AND material_type = 'LIGHT WET OIL'  AND general_port_s = " + ddp.DDP_INLET_PORT_L).FirstOrDefault;
                        ddp.DDP_IN_L_WET_HDR_S = ddp_in_l_wet_hdr_s;
                        LogOutPut.Add("Got ddp_in_l_wet_hdr_s");
                    }
                    catch (Exception ex)
                    {
                        LogOutPut.Add("No ddp_in_l_wet_hdr_s");
                    }
                    try
                    {
                        int ddp_out_l_hdr_s = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("SELECT daily_production_hdr_s  FROM koc.daily_production_hdr  WHERE activity_type = 'MEASURED' AND flow_dir_type = 'PRODUCTION' AND material_type = 'LIGHT OIL' AND general_port_s =" + ddp.DDP_OUTLET_PORT_L).FirstOrDefault;
                        ddp.DDP_OUT_L_HDR_S = ddp_out_l_hdr_s;
                        LogOutPut.Add("Got ddp_out_l_hdr_s");
                    }
                    catch (Exception ex)
                    {
                        LogOutPut.Add("No ddp_out_l_hdr_s");
                    }
                    try
                    {
                        int ddp_out_l_water_hdr_s = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>(" SELECT daily_production_hdr_s  FROM koc.daily_production_hdr  WHERE activity_type = 'MEASURED' AND flow_dir_type = 'PRODUCTION' AND material_type = 'LIGHT WATER'  AND general_port_s = " + ddp.DDP_OUTLET_PORT_L).FirstOrDefault;
                        ddp.DDP_OUT_L_WATER_HDR_S = ddp_out_l_water_hdr_s;
                        LogOutPut.Add("Got ddp_out_l_water_hdr_s");
                    }
                    catch (Exception ex)
                    {
                        LogOutPut.Add("No ddp_out_l_water_hdr_s");
                    }
                }
                // --------------------------------
                // ----	MEDIUM DDP	----
                // --------------------------------
                if (ddp.DDP_M_S.HasValue)
                {
                    try
                    {
                        int ddp_inlet_port_m = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("SELECT general_port_s FROM koc.general_port WHERE surface_facility_s = " + ddp.DDP_M_S + " AND facility_type = 'INLET_PORT'").FirstOrDefault;
                        ddp.DDP_INLET_PORT_M = ddp_inlet_port_m;
                        LogOutPut.Add("Got ddp_inlet_port_m");
                    }
                    catch (Exception ex)
                    {
                        LogOutPut.Add("No ddp_inlet_port_m");
                    }
                    try
                    {
                        int ddp_outlet_port_m = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("SELECT general_port_s FROM koc.general_port WHERE surface_facility_s = " + ddp.DDP_M_S + " AND facility_type = 'OUTLET_PORT'").FirstOrDefault;
                        ddp.DDP_OUTLET_PORT_M = ddp_outlet_port_m;
                        LogOutPut.Add("Got ddp_outlet_port_m");
                    }
                    catch (Exception ex)
                    {
                        LogOutPut.Add("No ddp_outlet_port_m");
                    }
                    try
                    {
                        int ddp_in_m_hdr_s = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>(" SELECT daily_production_hdr_s  FROM koc.daily_production_hdr   WHERE activity_type = 'MEASURED' AND flow_dir_type = 'PRODUCTION' AND material_type = 'MEDIUM OIL'  AND general_port_s =" + ddp.DDP_INLET_PORT_M).FirstOrDefault;
                        ddp.DDP_IN_M_HDR_S = ddp_in_m_hdr_s;
                        LogOutPut.Add("Got ddp_in_m_hdr_s");
                    }
                    catch (Exception ex)
                    {
                        LogOutPut.Add("No ddp_in_m_hdr_s");
                    }
                    try
                    {
                        int ddp_in_m_dry_hdr_s = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>(" SELECT daily_production_hdr_s  FROM koc.daily_production_hdr WHERE activity_type = 'MEASURED' AND flow_dir_type = 'PRODUCTION' AND material_type = 'MEDIUM DRY OIL'  AND general_port_s =" + ddp.DDP_INLET_PORT_M).FirstOrDefault;
                        ddp.DDP_IN_M_DRY_HDR_S = ddp_in_m_dry_hdr_s;
                        LogOutPut.Add("Got ddp_in_m_dry_hdr_s");
                    }
                    catch (Exception ex)
                    {
                        LogOutPut.Add("No ddp_in_m_dry_hdr_s");
                    }
                    try
                    {
                        int ddp_in_m_wet_hdr_s = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>(" SELECT daily_production_hdr_s  FROM koc.daily_production_hdr   WHERE activity_type = 'MEASURED' AND flow_dir_type = 'PRODUCTION' AND material_type = 'MEDIUM WET OIL'  AND general_port_s = " + ddp.DDP_INLET_PORT_M).FirstOrDefault;
                        ddp.DDP_IN_M_WET_HDR_S = ddp_in_m_wet_hdr_s;
                        LogOutPut.Add("Got ddp_in_m_wet_hdr_s");
                    }
                    catch (Exception ex)
                    {
                        LogOutPut.Add("No ddp_in_m_wet_hdr_s");
                    }
                    try
                    {
                        int ddp_out_m_hdr_s = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>(" SELECT daily_production_hdr_s  FROM koc.daily_production_hdr  WHERE activity_type = 'MEASURED' AND flow_dir_type = 'PRODUCTION' AND material_type = 'MEDIUM OIL'  AND general_port_s =" + ddp.DDP_OUTLET_PORT_M).FirstOrDefault;
                        ddp.DDP_OUT_M_HDR_S = ddp_out_m_hdr_s;
                        LogOutPut.Add("Got ddp_out_m_hdr_s");
                    }
                    catch (Exception ex)
                    {
                        LogOutPut.Add("No ddp_out_m_hdr_s");
                    }
                    try
                    {
                        int ddp_out_m_water_hdr_s = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("SELECT daily_production_hdr_s  FROM koc.daily_production_hdr  WHERE activity_type = 'MEASURED' AND flow_dir_type = 'PRODUCTION' AND material_type = 'MEDIUM WATER' AND general_port_s = " + ddp.DDP_OUTLET_PORT_M).FirstOrDefault;
                        ddp.DDP_OUT_M_WATER_HDR_S = ddp_out_m_water_hdr_s;
                        LogOutPut.Add("Got ddp_out_m_water_hdr_s");
                    }
                    catch (Exception ex)
                    {
                        LogOutPut.Add("No ddp_out_m_water_hdr_s");
                    }
                }
                ddp.GC = GC_ID;
                ddp.HDR_ID = ID;
                ddp.ID = GetSeq();
                hdr.NIGHT_FIGURE_DDP.Clear();
                hdr.NIGHT_FIGURE_DDP.Add(ddp);

                var Parameters = new Devart.Data.Oracle.OracleParameter[2];
                Parameters[0] = new Devart.Data.Oracle.OracleParameter("st_date", st_date);
                Parameters[1] = new Devart.Data.Oracle.OracleParameter("ddp_s", ddp_s);
                Parameters = null;
                List<DhubEntities.NIGHT_FIGURES_DDP_TRAIN> TRains = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<DhubEntities.NIGHT_FIGURES_DDP_TRAIN>("SELECT sf.facility_id ddp_train_id, sf.surface_facility_s  ddp_train_s  FROM koc.surface_facility sf, koc.facility_composition fc        WHERE sf.facility_type = 'DDP_TRAIN'         AND sf.surface_facility_s = fc.part_surface_facility_s         AND (fc.end_time Is Null or to_date(to_char(fc.end_time,'dd/mm/yyyy'),'dd/mm/yyyy') > to_date('" + txt_date + "','dd/mm/yyyy'))          AND fc.whole_surface_facility_s =" + ddp_s + "       ORDER BY sf.facility_id", Parameters).ToList;
                hdr.NIGHT_FIGURES_DDP_TRAIN.Clear();
                foreach (var train in TRains)
                {
                    train.GC = GC_ID;
                    // train.HDR_ID = ID
                    train.ID = GetSeq();
                    hdr.NIGHT_FIGURES_DDP_TRAIN.Add(train);
                    // SimpleODMConfig.DhubContext.NIGHT_FIGURES_DDP_TRAIN.AddObject(train)
                }
                GetDdpHeaters(ddp_s);
                GetEffWaterWells(ddp_s);
                // ------------------------------------------------------
                // ---------		MISC HDR 		----------
                // ------------------------------------------------------
                try
                {
                    int misc_hdr_s = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("SELECT daily_miscellaneous_hdr_s  FROM koc.daily_miscellaneous_hdr  WHERE activity_type = 'MEASURED' AND flow_dir_type = 'PRODUCTION' AND material_type = 'GAS'  AND general_port_s = " + gc_inlet_port).FirstOrDefault;
                    misc_hdr_s = misc_hdr_s;
                    LogOutPut.Add("Got misc_hdr_s");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No misc_hdr_s");
                }
            }


        }
        private void GetDdpHeaters(int ddp_s)
        {
            var Parameters = new Devart.Data.Oracle.OracleParameter[1];

            Parameters[0] = new Devart.Data.Oracle.OracleParameter("ddp_s", ddp_s);
            List<DhubEntities.NIGHT_FIGURE_DDP_HEATERS> retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<DhubEntities.NIGHT_FIGURE_DDP_HEATERS>(" SELECT sf.facility_id ddp_heaters_id, sf.surface_facility_s  ddp_heater_s   FROM koc.surface_facility sf, koc.facility_composition fc     WHERE sf.facility_type = 'DDP_HEATER'      AND (fc.end_time Is Null or to_date(to_char(fc.end_time,'dd/mm/yyyy'),'dd/mm/yyyy') > to_date('" + txt_date + "','dd/mm/yyyy'))   AND sf.surface_facility_s = fc.part_surface_facility_s   AND fc.whole_surface_facility_s = " + ddp_s + "   ORDER BY sf.facility_id", Parameters).ToList;
            hdr.NIGHT_FIGURE_DDP_HEATERS.Clear();
            foreach (var r1 in retint)
            {
                r1.GC = GC_ID;
                // r1.HDR_ID = ID
                r1.ID = GetSeq();
                hdr.NIGHT_FIGURE_DDP_HEATERS.Add(r1);
                // SimpleODMConfig.DhubContext.NIGHT_FIGURE_DDP_HEATERS.AddObject(r1)
            }
        }
        private void GetEffWaterWells(int ddp_s)
        {
            var Parameters = new Devart.Data.Oracle.OracleParameter[2];
            Parameters[0] = new Devart.Data.Oracle.OracleParameter("st_date", st_date);
            Parameters[1] = new Devart.Data.Oracle.OracleParameter("gc_sf_s", gc_sf_s);
            Parameters = null;
            List<DhubEntities.NIGHT_FIGURE_EFFLUENT_WATER> retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<DhubEntities.NIGHT_FIGURE_EFFLUENT_WATER>("SELECT fc.part_well_completion_s WELL_WC_S, wc.uwi  well, wc.facility_name  FLOWLINE FROM koc.facility_composition fc, koc.well_completion  wc   WHERE whole_surface_facility_s =" + gc_sf_s + "   and fc.part_well_completion_s = wc.well_completion_s    and  part_well_completion_s is not null     ORDER BY decode(substr(wc.uwi, 1,2), 'WW', replace(part_uwi,'WW','RA'),  wc.uwi)", Parameters).ToList;
            hdr.NIGHT_FIGURE_EFFLUENT_WATER.Clear();
            foreach (var r in retint)
            {
                r.GC = GC_ID;
                // r.HDR_ID = ID
                r.ID = GetSeq();
                hdr.NIGHT_FIGURE_EFFLUENT_WATER.Add(r);
                // SimpleODMConfig.DhubContext.NIGHT_FIGURE_EFFLUENT_WATER.AddObject(r)
            }


        }
        private void GetWaterPumps()
        {
            var Parameters = new Devart.Data.Oracle.OracleParameter[1];

            Parameters[0] = new Devart.Data.Oracle.OracleParameter("gc_sf_s", gc_sf_s);
            Parameters = null;
            List<DhubEntities.NIGHT_FIGURES_EWDP_PUMPS> retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<DhubEntities.NIGHT_FIGURES_EWDP_PUMPS>(" SELECT sf.facility_id DPUMP_ID, sf.surface_facility_s  DPUMP_S FROM koc.surface_facility sf, koc.facility_composition fc WHERE sf.facility_type = 'WATER_PUMP'   AND sf.surface_facility_s = fc.part_surface_facility_s  AND (fc.end_time Is Null or to_date(to_char(fc.end_time,'dd/mm/yyyy'),'dd/mm/yyyy') > to_date('" + txt_date + "','dd/mm/yyyy'))   AND fc.whole_surface_facility_s =" + gc_sf_s + "   ORDER BY sf.facility_id", Parameters).ToList;

            hdr.NIGHT_FIGURES_EWDP_PUMPS.Clear();
            foreach (var r in retint)
            {
                r.GC = GC_ID;
                // r.HDR_ID = ID
                r.ID = GetSeq();
                hdr.NIGHT_FIGURES_EWDP_PUMPS.Add(r);
                // SimpleODMConfig.DhubContext.NIGHT_FIGURES_EWDP_PUMPS.AddObject(r)
            }
        }
        private void Get_Dry_wet_Stock_Exchange()
        {
            var Parameters = new Devart.Data.Oracle.OracleParameter[1];
            var prevdate = st_date.AddDays(-1);
            Parameters[0] = new Devart.Data.Oracle.OracleParameter("st_date", prevdate);
            Parameters = null;
            l_dry_stock_tdy = 0;
            dry_stock_ydy = 0;
            m_wet_stock_change = 0;
            m_dry_stock_change = 0;
            m_wet_stock_ydy = 0;
            m_dry_stock_tdy = 0;
            m_dry_stock_ydy = 0;
            l_wet_stock_tdy = 0;
            m_wet_stock_tdy = 0;
            wet_stock_ydy = 0;
            foreach (var tanks in hdr.NIGHT_FIGURES_TANKS)
            {
                if (Conversions.ToBoolean(Operators.AndObject(Operators.ConditionalCompareObjectEqual(tanks.FLUID_STATE, "DRY", false), tanks.TANK_ID.Contains("LCO"))))
                {

                    l_dry_stock_tdy = Conversions.ToDecimal(Operators.AddObject(tanks.TANK_STOCK, l_dry_stock_tdy));
                    dry_stock_ydy = 0;
                    try
                    {
                        dry_stock_ydy = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("  SELECT liquid_volume  FROM koc.daily_production_data  WHERE daily_production_hdr_s =", tanks.TANK_HDR_S), " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('"), prevdate), "','dd/mm/yyyy') "), Parameters).FirstOrDefault;
                        l_dry_stock_ydy = l_dry_stock_ydy + dry_stock_ydy;
                    }
                    catch (Exception ex)
                    {

                    }
                }
                if (Conversions.ToBoolean(Operators.AndObject(Operators.ConditionalCompareObjectEqual(tanks.FLUID_STATE, "DRY", false), tanks.TANK_ID.Contains("MCO"))))
                {

                    m_dry_stock_tdy = Conversions.ToDecimal(Operators.AddObject(tanks.TANK_STOCK, m_dry_stock_tdy));
                    dry_stock_ydy = 0;
                    try
                    {
                        dry_stock_ydy = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("  SELECT liquid_volume  FROM koc.daily_production_data  WHERE daily_production_hdr_s =", tanks.TANK_HDR_S), " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('"), prevdate), "','dd/mm/yyyy') "), Parameters).FirstOrDefault;
                        m_dry_stock_ydy = m_dry_stock_ydy + dry_stock_ydy;
                    }
                    catch (Exception ex)
                    {

                    }
                }
                if (Conversions.ToBoolean(Operators.AndObject(Operators.ConditionalCompareObjectEqual(tanks.FLUID_STATE, "WET", false), tanks.TANK_ID.Contains("LCO"))))
                {

                    l_wet_stock_tdy = Conversions.ToDecimal(Operators.AddObject(tanks.TANK_STOCK, l_wet_stock_tdy));
                    wet_stock_ydy = 0;
                    try
                    {
                        wet_stock_ydy = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("  SELECT liquid_volume  FROM koc.daily_production_data  WHERE daily_production_hdr_s =", tanks.TANK_HDR_S), " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('"), prevdate), "','dd/mm/yyyy') "), Parameters).FirstOrDefault;
                        l_wet_stock_ydy = l_wet_stock_ydy + wet_stock_ydy;
                    }
                    catch (Exception ex)
                    {

                    }
                }
                if (Conversions.ToBoolean(Operators.AndObject(Operators.ConditionalCompareObjectEqual(tanks.FLUID_STATE, "WET", false), tanks.TANK_ID.Contains("MCO"))))
                {

                    m_wet_stock_tdy = Conversions.ToDecimal(Operators.AddObject(tanks.TANK_STOCK, m_wet_stock_tdy));
                    wet_stock_ydy = 0;
                    try
                    {
                        wet_stock_ydy = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("  SELECT liquid_volume  FROM koc.daily_production_data  WHERE daily_production_hdr_s =", tanks.TANK_HDR_S), " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('"), prevdate), "','dd/mm/yyyy') "), Parameters).FirstOrDefault;
                        m_wet_stock_ydy = m_wet_stock_ydy + wet_stock_ydy;
                    }
                    catch (Exception ex)
                    {

                    }
                }
                if (Conversions.ToBoolean(Operators.AndObject(Operators.ConditionalCompareObjectEqual(tanks.FLUID_STATE, "WET", false), tanks.TANK_ID.Contains("MCO"))))
                {

                    m_wet_stock_tdy = Conversions.ToDecimal(Operators.AddObject(tanks.TANK_STOCK, m_wet_stock_tdy));
                    wet_stock_ydy = 0;
                    try
                    {
                        wet_stock_ydy = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("  SELECT liquid_volume  FROM koc.daily_production_data  WHERE daily_production_hdr_s =", tanks.TANK_HDR_S), " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('"), prevdate), "','dd/mm/yyyy') "), Parameters).FirstOrDefault;
                        m_wet_stock_ydy = m_wet_stock_ydy + wet_stock_ydy;
                    }
                    catch (Exception ex)
                    {

                    }
                }
                if (Conversions.ToBoolean(Operators.AndObject(Operators.ConditionalCompareObjectEqual(tanks.FLUID_STATE, "DRY", false), GC_ID != "GC27" | GC_ID != "GC28")))
                {
                    dry_stock_tdy = Conversions.ToDecimal(Operators.AddObject(tanks.TANK_STOCK, dry_stock_tdy));
                    try
                    {
                        l_dry_stock_ydy = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("  SELECT liquid_volume  FROM koc.daily_production_data  WHERE daily_production_hdr_s =", tanks.TANK_HDR_S), " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('"), prevdate), "','dd/mm/yyyy') "), Parameters).FirstOrDefault;
                        dry_stock_ydy = l_dry_stock_ydy + dry_stock_ydy;
                    }
                    catch (Exception ex)
                    {

                    }
                }
                if (Conversions.ToBoolean(Operators.AndObject(Operators.ConditionalCompareObjectEqual(tanks.FLUID_STATE, "WET", false), GC_ID != "GC27" | GC_ID != "GC28")))
                {
                    wet_stock_tdy = Conversions.ToDecimal(Operators.AddObject(tanks.TANK_STOCK, wet_stock_tdy));
                    try
                    {
                        l_wet_stock_ydy = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("  SELECT liquid_volume  FROM koc.daily_production_data  WHERE daily_production_hdr_s =", tanks.TANK_HDR_S), " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('"), prevdate), "','dd/mm/yyyy') "), Parameters).FirstOrDefault;
                        wet_stock_ydy = l_wet_stock_ydy + wet_stock_ydy;
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            l_dry_stock_change = l_dry_stock_tdy - l_dry_stock_ydy;
            m_dry_stock_change = m_dry_stock_tdy - m_dry_stock_ydy;
            l_wet_stock_change = l_wet_stock_tdy - l_wet_stock_ydy;
            m_wet_stock_change = m_wet_stock_tdy - m_wet_stock_ydy;
            dry_stock_change = l_dry_stock_change + m_dry_stock_change;
            wet_stock_change = l_wet_stock_change + m_wet_stock_change;

        }
        private void Get_Tanks_Data()
        {
            // ----------------------------------------------------------
            // ----			TANK STOCK'S DATA		----
            // ----------------------------------------------------------
            var Parameters = new Devart.Data.Oracle.OracleParameter[2];
            Parameters[0] = new Devart.Data.Oracle.OracleParameter("st_date", st_date);
            Parameters[1] = new Devart.Data.Oracle.OracleParameter("despatch_hdr_s", despatch_hdr_s);
            Parameters = null;
            foreach (var Tanks in hdr.NIGHT_FIGURES_TANKS)
            {
                try
                {

                    Tanks.TANK_STOCK = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("  SELECT liquid_volume  FROM koc.daily_production_data  WHERE daily_production_hdr_s =", Tanks.TANK_HDR_S), " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('"), txt_date), "','dd/mm/yyyy') "), Parameters).FirstOrDefault;

                    if (GC_ID != "GC23")
                    {

                        if (Conversions.ToBoolean(Operators.AndObject(Tanks.FACTOR.HasValue, Operators.ConditionalCompareObjectNotEqual(Tanks.FACTOR, 0, false))))
                        {

                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(Tanks.TANK_ID, "17_WET_NEW", false)))
                            {
                                Tanks.TANK_DIP = Operators.AddObject(Operators.DivideObject(Operators.SubtractObject(Tanks.TANK_STOCK, Tanks.INITIAL_OFFSET), Tanks.FACTOR), 16.0105d);
                            }
                            else
                            {
                                Tanks.TANK_DIP = Operators.DivideObject(Operators.SubtractObject(Tanks.TANK_STOCK, Tanks.INITIAL_OFFSET), Tanks.FACTOR);
                            }

                            Tanks.TANK_FT = Math.Floor(Tanks.TANK_DIP.GetValueOrDefault);
                            Tanks.TANK_INCH = Operators.MultiplyObject(Math.Round(Operators.ModObject(Tanks.TANK_DIP.GetValueOrDefault, 1)), 12);

                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(Tanks.TANK_INCH, 12, false)))
                            {
                                Tanks.TANK_FT = Operators.AddObject(Tanks.TANK_FT, 1);
                                Tanks.TANK_INCH = (object)0;
                            }

                        }

                    }
                }

                catch (Exception ex)
                {
                    Tanks.TANK_STOCK = (object)0;
                }
            }

            if (GC_ID != "GC27" | GC_ID != "GC28")
            {
                try
                {
                    stock = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>("  SELECT liquid_volume  FROM koc.daily_production_data  WHERE daily_production_hdr_s =" + stock_hdr_s + " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                }
                catch (Exception ex)
                {
                    stock = 0;
                }

                try
                {
                    var prevdate = st_date.AddDays(-1);
                    // Parameters(0) = New Devart.Data.Oracle.OracleParameter("st_date", prevdate)
                    l_stock_ydy = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>("  SELECT nvl(liquid_volume,-999999999)  FROM koc.daily_production_data  WHERE daily_production_hdr_s =" + stock_hdr_s + " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + Conversions.ToString(prevdate) + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                }
                catch (Exception ex)
                {
                    l_stock_ydy = 0;
                }
                try
                {

                    // Parameters(0) = New Devart.Data.Oracle.OracleParameter("st_date", st_date)
                    l_stock_tdy = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>("  SELECT nvl(liquid_volume,-999999999)   FROM koc.daily_production_data  WHERE daily_production_hdr_s =" + stock_hdr_s + " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                }
                catch (Exception ex)
                {
                    l_stock_tdy = 0;
                }

                try
                {
                    if (((0 is var arg70 && l_stock_ydy is { } arg69 ? arg69 == arg70 : null) | (Conversions.ToDouble("-999999999") is var arg72 && (double?)l_stock_ydy is { } arg71 ? arg71 == arg72 : null)) == true)
                    {
                    }

                    else if (((0 is var arg74 && l_stock_tdy is { } arg73 ? arg73 == arg74 : null) | (Conversions.ToDouble("-999999999") is var arg76 && (double?)l_stock_tdy is { } arg75 ? arg75 == arg76 : null)) == true)
                    {
                    }
                    // If Me.hdr.NIGHT_FIGURES_PROD_STOCK(0).T_DESPATCH.HasValue = False Then

                    // End If
                    else
                    {

                        l_gross_stock = l_stock_tdy - l_stock_ydy;
                        l_net_stock = Math.Round(Operators.MultiplyObject(Interaction.IIf(hdr.NIGHT_FIGURES_PROD_STOCK(0).L_FACTOR > 0, hdr.NIGHT_FIGURES_PROD_STOCK(0).L_FACTOR, 1), l_gross_stock));
                        net_stock_change = l_net_stock;
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else
            {

                // ---- LIGHT
                try
                {

                    var prevdate = st_date.AddDays(-1);
                    // Parameters(0) = New Devart.Data.Oracle.OracleParameter("st_date", prevdate)
                    l_stock_ydy = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>("  SELECT nvl(liquid_volume,-999999999)   FROM koc.daily_production_data  WHERE daily_production_hdr_s =" + l_stock_hdr_s + " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + Conversions.ToString(prevdate) + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                }
                catch (Exception ex)
                {
                    l_stock_ydy = 0;
                }
                // ---- MEDIUM
                try
                {

                    var prevdate = st_date.AddDays(-1);
                    // Parameters(0) = New Devart.Data.Oracle.OracleParameter("st_date", prevdate)
                    m_stock_ydy = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>("  SELECT nvl(liquid_volume,-999999999)   FROM koc.daily_production_data  WHERE daily_production_hdr_s =" + m_stock_hdr_s + " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + Conversions.ToString(prevdate) + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                }
                catch (Exception ex)
                {
                    m_stock_ydy = 0;
                }
                // ---- Get Today's stock
                // ---- LIGHT
                try
                {
                    // Parameters(0) = New Devart.Data.Oracle.OracleParameter("st_date", st_date)
                    l_stock_tdy = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>("  SELECT nvl(liquid_volume,-999999999)   FROM koc.daily_production_data  WHERE daily_production_hdr_s =" + l_stock_hdr_s + " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                }
                catch (Exception ex)
                {
                    l_stock_tdy = 0;
                }
                // ---- MEDIUM
                try
                {
                    // Parameters(0) = New Devart.Data.Oracle.OracleParameter("st_date", st_date)
                    m_stock_tdy = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>("  SELECT nvl(liquid_volume,-999999999)   FROM koc.daily_production_data  WHERE daily_production_hdr_s =" + m_stock_hdr_s + " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                }
                catch (Exception ex)
                {
                    m_stock_tdy = 0;
                }
                // ---- Calculate Stock Change
                // ---- LIGHT
                try
                {
                    if (((0 is var arg78 && l_stock_ydy is { } arg77 ? arg77 == arg78 : null) | (Conversions.ToDouble("-999999999") is var arg80 && (double?)l_stock_ydy is { } arg79 ? arg79 == arg80 : null)) == true)
                    {
                    }

                    else if (((0 is var arg82 && l_stock_tdy is { } arg81 ? arg81 == arg82 : null) | (Conversions.ToDouble("-999999999") is var arg84 && (double?)l_stock_tdy is { } arg83 ? arg83 == arg84 : null)) == true)
                    {
                    }

                    else
                    {
                        l_gross_stock = l_stock_tdy - l_stock_ydy;
                        l_net_stock = Math.Round(Operators.MultiplyObject(Interaction.IIf(hdr.NIGHT_FIGURES_PROD_STOCK(0).L_FACTOR > 0, hdr.NIGHT_FIGURES_PROD_STOCK(0).L_FACTOR, 1), l_gross_stock));
                    }
                    // ---- MEDIUM
                    if (((0 is var arg86 && m_stock_ydy is { } arg85 ? arg85 == arg86 : null) | (Conversions.ToDouble("-999999999") is var arg88 && (double?)m_stock_ydy is { } arg87 ? arg87 == arg88 : null)) == true)
                    {
                    }
                    else if (((0 is var arg90 && m_stock_tdy is { } arg89 ? arg89 == arg90 : null) | (Conversions.ToDouble("-999999999") is var arg92 && (double?)m_stock_tdy is { } arg91 ? arg91 == arg92 : null)) == true)
                    {
                    }
                    else
                    {
                        m_gross_stock = m_stock_tdy - m_stock_ydy;
                        m_net_stock = Math.Round(Operators.MultiplyObject(Interaction.IIf(m_retint.M_FACTOR.Value > 0, m_retint.M_FACTOR.Value, 1), m_gross_stock));
                    }
                    // ---- TOTAL STOCK CHANGE
                    if (((0 is var arg94 && l_net_stock is { } arg93 ? arg93 > arg94 : null) & (0 is var arg96 && m_net_stock is { } arg95 ? arg95 > arg96 : null)) == true)
                    {
                        net_stock_change = l_net_stock + m_net_stock;
                    }
                }
                catch (Exception ex)
                {

                }

            }


            // --------------------------------------------------
            // ----		DRY AND WET STOCK CHANGE	----
            // --------------------------------------------------

            Get_Dry_wet_Stock_Exchange();
            var x = new NIGHT_FIGURES_STOCK_CHANGE();
            x.GC = GC_ID;
            x.HDR_ID = hdr.ID;
            x.L_DRY_STOCK_CHANGE = l_dry_stock_change;
            x.L_GROSS_STOCK = l_gross_stock;
            x.L_NET_STOCK = l_net_stock;
            x.L_STOCK_TDY = l_stock_tdy;
            x.L_STOCK_YDY = l_stock_ydy;
            x.L_WET_STOCK_CHANGE = l_wet_stock_change;
            x.M_DRY_STOCK_CHANGE = m_dry_stock_change;
            x.M_GROSS_STOCK = m_gross_stock;
            x.M_NET_STOCK = m_net_stock;
            x.M_STOCK_TDY = m_stock_tdy;
            x.M_STOCK_YDY = m_stock_ydy;
            x.M_WET_STOCK_CHANGE = m_wet_stock_change;
            x.NET_STOCK_CHANGE = l_net_stock + m_net_stock;
            x.STOCK_TDY = dual_stock_tdy;
            x.STOCK_YDY = dual_stock_ydy;
            x.T_DRY_STOCK_CHANGE = l_dry_stock_change + m_dry_stock_change;
            x.T_WET_STOCK_CHANGE = l_wet_stock_change + m_wet_stock_change;

            hdr.NIGHT_FIGURES_STOCK_CHANGE.Add(x);



        }
        private void get_Pump_data()
        {
            var Parameters = new Devart.Data.Oracle.OracleParameter[2];
            Parameters[0] = new Devart.Data.Oracle.OracleParameter("st_date", st_date);
            Parameters = null;
            foreach (var pumps in hdr.NIGHT_FIGURES_PUMPS)
            {

                try
                {
                    PumpsSpecs retpumps = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<PumpsSpecs>(Operators.ConcatenateObject("    SELECT pp.running_hours, pp.shutdown_reason  FROM koc.oil_field_operation ofo, koc.pump_pty pp  WHERE pp.oil_field_operation_s = ofo.oil_field_operation_s AND  to_date(to_char(ofo.start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy')  AND ofo.activity_type = 'FACILITY_OPERATION'  AND ofo.surface_facility_s =", pumps.PUMP_S), Parameters).FirstOrDefault;
                    pumps.PUMP_RUNNING_HOURS = (object)retpumps.running_hours;
                    pumps.PUMP_REASON = retpumps.shutdown_reason;
                }
                catch (Exception ex)
                {
                    pumps.PUMP_RUNNING_HOURS = (object)0;
                    pumps.PUMP_REASON = (object)0;
                }
            }
        }
        private void Get_turbines_data()
        {
            var Parameters = new Devart.Data.Oracle.OracleParameter[2];
            Parameters[0] = new Devart.Data.Oracle.OracleParameter("st_date", st_date);
            Parameters = null;
            foreach (var TURBINES in hdr.NIGHT_FIGURE_TURBINES)
            {

                try
                {
                    string TURBINE_RH = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<string>(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("select attribute_string   from koc.daily_miscellaneous_data   where daily_miscellaneous_hdr_s = ", TURBINES.TURBINE_GAS_HDR_S), " and to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('"), txt_date), "','dd/mm/yyyy')    and attribute = 'RUNNING_HOURS'"), Parameters).FirstOrDefault;
                    TURBINES.TURBINE_RH = TURBINE_RH;
                }

                catch (Exception ex)
                {
                    TURBINES.TURBINE_RH = "";

                }
                try
                {
                    string TURBINE_REASON = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<string>(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("select attribute_string   from koc.daily_miscellaneous_data   where daily_miscellaneous_hdr_s = ", TURBINES.TURBINE_GAS_HDR_S), " and to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('"), txt_date), "','dd/mm/yyyy')    and attribute = 'SHUT_REASON'"), Parameters).FirstOrDefault;
                    TURBINES.TURBINE_REASON = TURBINE_REASON;
                }

                catch (Exception ex)
                {
                    TURBINES.TURBINE_RH = "";

                }
            }
        }
        private void get_cru_data()
        {
            var Parameters = new Devart.Data.Oracle.OracleParameter[2];
            Parameters[0] = new Devart.Data.Oracle.OracleParameter("st_date", st_date);
            Parameters = null;
            foreach (var cru in hdr.NIGHT_FIGURES_CRU)
            {

                try
                {
                    decimal cru_liquid = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("  SELECT liquid_volume   FROM koc.daily_production_data  WHERE daily_production_hdr_s = ", cru.CRU_OIL_HDR_S), " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('"), txt_date), "','dd/mm/yyyy') "), Parameters).FirstOrDefault;
                    cru.CRU_LIQUID = (object)cru_liquid;
                }

                catch (Exception ex)
                {
                    cru.CRU_LIQUID = "";

                }
                try
                {
                    decimal cru_stage_suction = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("  SELECT gas_volume   FROM koc.daily_production_data  WHERE daily_production_hdr_s = ", cru.CRU_GAS_HDR_S), " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('"), txt_date), "','dd/mm/yyyy') "), Parameters).FirstOrDefault;
                    cru.CRU_STAGE_SUCTION = (object)cru_stage_suction;
                }

                catch (Exception ex)
                {
                    cru.CRU_STAGE_SUCTION = "";

                }
                try
                {
                    decimal cru_rich_gas = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("  SELECT gas_volume   FROM koc.daily_production_data  WHERE daily_production_hdr_s = ", cru.CRU_RICH_GAS_HDR_S), " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('"), txt_date), "','dd/mm/yyyy') "), Parameters).FirstOrDefault;
                    cru.CRU_RICH_GAS = (object)cru_rich_gas;
                }

                catch (Exception ex)
                {
                    cru.CRU_RICH_GAS = "";

                }
                try
                {
                    decimal cru_lean_gas = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("  SELECT gas_volume   FROM koc.daily_production_data  WHERE daily_production_hdr_s = ", cru.CRU_LEAN_GAS_HDR_S), " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('"), txt_date), "','dd/mm/yyyy') "), Parameters).FirstOrDefault;
                    cru.CRU_LEAN_GAS = (object)cru_lean_gas;
                }

                catch (Exception ex)
                {
                    cru.CRU_LEAN_GAS = "";

                }
                if (GC_ID == "GC23" | GC_ID == "GC25" | GC_ID == "GC15" | GC_ID == "GC22")
                {
                    try
                    {
                        decimal cru_hp_gas_export = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("  SELECT gas_volume   FROM koc.daily_production_data  WHERE daily_production_hdr_s = ", cru.CRU_HP_GAS_EXPORT_HDR_S), " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('"), txt_date), "','dd/mm/yyyy') "), Parameters).FirstOrDefault;
                        cru.CRU_HP_GAS_EXPORT = (object)cru_hp_gas_export;
                    }
                    catch (Exception ex)
                    {
                        cru.CRU_HP_GAS_EXPORT = "";
                    }
                    try
                    {
                        decimal cru_lp_gas_export = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("  SELECT gas_volume   FROM koc.daily_production_data  WHERE daily_production_hdr_s = ", cru.CRU_MP_GAS_EXPORT_HDR_S), " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('"), txt_date), "','dd/mm/yyyy') "), Parameters).FirstOrDefault;
                        cru.CRU_LP_GAS_EXPORT = (object)cru_lp_gas_export;
                    }
                    catch (Exception ex)
                    {
                        cru.CRU_LP_GAS_EXPORT = "";
                    }
                    try
                    {
                        decimal sru_gas = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("  SELECT gas_volume   FROM koc.daily_production_data  WHERE daily_production_hdr_s = ", cru.SRU_GAS_HDR_S), " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('"), txt_date), "','dd/mm/yyyy') "), Parameters).FirstOrDefault;
                        cru.SRU_GAS = (object)sru_gas;
                    }
                    catch (Exception ex)
                    {
                        cru.SRU_GAS = "";
                    }
                    try
                    {
                        decimal cru_mp_gas_export = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("  SELECT gas_volume   FROM koc.daily_production_data  WHERE daily_production_hdr_s = ", cru.CRU_MP_GAS_EXPORT_HDR_S), " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('"), txt_date), "','dd/mm/yyyy') "), Parameters).FirstOrDefault;
                        cru.CRU_MP_GAS_EXPORT = (object)cru_mp_gas_export;
                    }
                    catch (Exception ex)
                    {
                        cru.CRU_MP_GAS_EXPORT = "";
                    }
                    try
                    {
                        decimal cru_flare_gas = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("  SELECT gas_volume   FROM koc.daily_production_data  WHERE daily_production_hdr_s = ", cru.CRU_FLARE_GAS_HDR_S), " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('"), txt_date), "','dd/mm/yyyy') "), Parameters).FirstOrDefault;
                        cru.CRU_FLARE_GAS = (object)cru_flare_gas;
                    }
                    catch (Exception ex)
                    {
                        cru.CRU_FLARE_GAS = "";
                    }
                    try
                    {
                        decimal cru_flare_acid_gas = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("  SELECT gas_volume   FROM koc.daily_production_data  WHERE daily_production_hdr_s = ", cru.CRU_FLARE_GAS_ACID_HDR_S), " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('"), txt_date), "','dd/mm/yyyy') "), Parameters).FirstOrDefault;
                        cru.CRU_FLARE_ACID_GAS = (object)cru_flare_acid_gas;
                    }
                    catch (Exception ex)
                    {
                        cru.CRU_FLARE_ACID_GAS = "";
                    }
                    try
                    {
                        decimal cru_flare_acid_gas = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("  SELECT gas_volume   FROM koc.daily_production_data  WHERE daily_production_hdr_s = ", cru.CRU_FLARE_GAS_ACID_HDR_S), " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('"), txt_date), "','dd/mm/yyyy') "), Parameters).FirstOrDefault;
                        cru.CRU_FLARE_ACID_GAS = (object)cru_flare_acid_gas;
                    }
                    catch (Exception ex)
                    {
                        cru.CRU_FLARE_ACID_GAS = "";
                    }
                }
                try
                {
                    string cru_running_hours = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<string>(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("  SELECT attribute_string   FROM koc.daily_miscellaneous_data  WHERE daily_miscellaneous_hdr_s = ", cru.CRU_PROD_MISC_HDR_S), " AND attribute = 'RUNNING_HOURS' AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('"), txt_date), "','dd/mm/yyyy') "), Parameters).FirstOrDefault;
                    cru.CRU_RUNNING_HOURS = cru_running_hours;
                }
                catch (Exception ex)
                {
                    cru.CRU_RUNNING_HOURS = "";
                }
                try
                {
                    string cru_speed = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<string>(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("  SELECT attribute_string   FROM koc.daily_miscellaneous_data  WHERE daily_miscellaneous_hdr_s = ", cru.CRU_PROD_MISC_HDR_S), " AND attribute = 'SPEED' AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('"), txt_date), "','dd/mm/yyyy') "), Parameters).FirstOrDefault;
                    cru.CRU_SPEED = cru_speed;
                }
                catch (Exception ex)
                {
                    cru.CRU_SPEED = "";
                }
                try
                {
                    string cru_unloader = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<string>(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("  SELECT attribute_string   FROM koc.daily_miscellaneous_data  WHERE daily_miscellaneous_hdr_s = ", cru.CRU_PROD_MISC_HDR_S), " AND attribute = 'UNLOADER' AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('"), txt_date), "','dd/mm/yyyy') "), Parameters).FirstOrDefault;
                    cru.CRU_UNLOADER = cru_unloader;
                }
                catch (Exception ex)
                {
                    cru.CRU_UNLOADER = "";
                }
                try
                {
                    string cru_shutdown_reason = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<string>(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("  SELECT attribute_string   FROM koc.daily_miscellaneous_data  WHERE daily_miscellaneous_hdr_s = ", cru.CRU_PROD_MISC_HDR_S), " AND attribute = 'SHUT_REASON' AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('"), txt_date), "','dd/mm/yyyy') "), Parameters).FirstOrDefault;
                    cru.CRU_SHUTDOWN_REASON = cru_shutdown_reason;
                }
                catch (Exception ex)
                {
                    cru.CRU_SHUTDOWN_REASON = "";
                }
                try
                {
                    string cru_tv_load = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<string>(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("  SELECT attribute_string   FROM koc.daily_miscellaneous_data  WHERE daily_miscellaneous_hdr_s = ", cru.CRU_PROD_MISC_HDR_S), " AND attribute = 'TV LOAD' AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('"), txt_date), "','dd/mm/yyyy') "), Parameters).FirstOrDefault;
                    cru.CRU_TV_LOAD = cru_tv_load;
                }
                catch (Exception ex)
                {
                    cru.CRU_TV_LOAD = "";
                }
            }

        }
        private void Get_Ddp_Data()
        {
            var Parameters = new Devart.Data.Oracle.OracleParameter[2];
            Parameters[0] = new Devart.Data.Oracle.OracleParameter("st_date", st_date);
            Parameters = null;
            try
            {
                decimal ddp_l_dry = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>("select liquid_volume   from koc.daily_production_data   where daily_production_hdr_s = " + ddp.DDP_IN_L_DRY_HDR_S + " and to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                hdr.NIGHT_FIGURE_DDP(0).DDP_L_DRY = ddp_l_dry;
            }
            catch (Exception ex)
            {
                hdr.NIGHT_FIGURE_DDP(0).DDP_L_DRY = null;
            }
            try
            {
                decimal ddp_l_wet = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>("select liquid_volume   from koc.daily_production_data   where daily_production_hdr_s = " + ddp.DDP_IN_L_WET_HDR_S + " and to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                hdr.NIGHT_FIGURE_DDP(0).DDP_L_WET = ddp_l_wet;
            }
            catch (Exception ex)
            {
                hdr.NIGHT_FIGURE_DDP(0).DDP_L_WET = null;
            }
            try
            {
                DDPSpecs ddpsp = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<DDPSpecs>("   SELECT liquid_volume, nominal_water_cut, remarks  FROM koc.daily_production_data wHERE daily_production_hdr_s = " + ddp.DDP_IN_L_HDR_S + " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                hdr.NIGHT_FIGURE_DDP(0).DDP_L_TOTAL = ddpsp.liquid_volume;
                hdr.NIGHT_FIGURE_DDP(0).DDP_L_WC = ddpsp.nominal_water_cut;
                if (string.IsNullOrEmpty(ddpsp.remarks) == false)
                {
                    var re = new DhubEntities.NIGHT_FIGURE_REMARKS();
                    re.GC_ID = GC_ID;
                    re.HDR_ID = ID;
                    re.ID = GetSeq();
                    re.REMARK = ddpsp.remarks;
                    re.REMARK_TYPE = "DDP";
                    hdr.NIGHT_FIGURE_REMARKS.Add(re);
                    hdr.NIGHT_FIGURE_DDP(0).DDP_L_WC = Math.Round(hdr.NIGHT_FIGURE_DDP(0).DDP_L_WC.Value, 3);
                }
            }
            catch (Exception ex)
            {
                hdr.NIGHT_FIGURE_DDP(0).DDP_L_TOTAL = null;
                hdr.NIGHT_FIGURE_DDP(0).DDP_L_WC = null;
            }
            try
            {
                decimal ddp_l_sep_water = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>("select liquid_volume   from koc.daily_production_data   where daily_production_hdr_s = " + ddp.DDP_OUT_L_WATER_HDR_S + " and to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                hdr.NIGHT_FIGURE_DDP(0).DDP_L_SEP_WATER = ddp_l_sep_water;
                hdr.NIGHT_FIGURE_DDP(0).DDP_L_SEP_WATER = Math.Round(hdr.NIGHT_FIGURE_DDP(0).DDP_L_SEP_WATER.Value, 3);
            }
            catch (Exception ex)
            {
                hdr.NIGHT_FIGURE_DDP(0).DDP_L_SEP_WATER = null;
            }
            try
            {
                decimal ddp_l_treated_crude = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>("select liquid_volume   from koc.daily_production_data   where daily_production_hdr_s = " + ddp.DDP_OUT_L_HDR_S + " and to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                hdr.NIGHT_FIGURE_DDP(0).DDP_L_TREATED_CRUDE = ddp_l_treated_crude;
                hdr.NIGHT_FIGURE_DDP(0).DDP_L_TREATED_CRUDE = Math.Round(hdr.NIGHT_FIGURE_DDP(0).DDP_L_TREATED_CRUDE.Value, 3);
            }
            catch (Exception ex)
            {
                hdr.NIGHT_FIGURE_DDP(0).DDP_L_TREATED_CRUDE = null;
            }
            // ---- MEDIUM TRAIN
            try
            {
                decimal ddp_m_dry = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>("select liquid_volume   from koc.daily_production_data   where daily_production_hdr_s = " + ddp.DDP_IN_M_DRY_HDR_S + " and to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                hdr.NIGHT_FIGURE_DDP(0).DDP_M_DRY = ddp_m_dry;
                hdr.NIGHT_FIGURE_DDP(0).DDP_M_DRY = Math.Round(hdr.NIGHT_FIGURE_DDP(0).DDP_M_DRY.Value, 3);
            }
            catch (Exception ex)
            {
                hdr.NIGHT_FIGURE_DDP(0).DDP_M_DRY = null;
            }
            try
            {
                decimal ddp_m_wet = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>("select liquid_volume   from koc.daily_production_data   where daily_production_hdr_s = " + ddp.DDP_IN_M_WET_HDR_S + " and to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                hdr.NIGHT_FIGURE_DDP(0).DDP_M_WET = ddp_m_wet;
                hdr.NIGHT_FIGURE_DDP(0).DDP_M_WET = Math.Round(hdr.NIGHT_FIGURE_DDP(0).DDP_M_WET.Value, 3);
            }
            catch (Exception ex)
            {
                hdr.NIGHT_FIGURE_DDP(0).DDP_M_WET = null;
            }
            try
            {
                decimal ddp_m_total = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>("select liquid_volume   from koc.daily_production_data   where daily_production_hdr_s = " + ddp.DDP_IN_M_HDR_S + " and to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                hdr.NIGHT_FIGURE_DDP(0).DDP_M_TOTAL = ddp_m_total;
                hdr.NIGHT_FIGURE_DDP(0).DDP_M_TOTAL = Math.Round(hdr.NIGHT_FIGURE_DDP(0).DDP_M_TOTAL.Value, 3);
            }
            catch (Exception ex)
            {
                hdr.NIGHT_FIGURE_DDP(0).DDP_M_TOTAL = null;
            }
            try
            {
                DDPSpecs1 ddp_m_DDPSpecs1 = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<DDPSpecs1>("select liquid_volume, nominal_water_cut   from koc.daily_production_data   where daily_production_hdr_s = " + ddp.DDP_IN_M_HDR_S + " and to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                hdr.NIGHT_FIGURE_DDP(0).DDP_M_TOTAL = ddp_m_DDPSpecs1.liquid_volume;
                hdr.NIGHT_FIGURE_DDP(0).DDP_M_WC = ddp_m_DDPSpecs1.nominal_water_cut;
                hdr.NIGHT_FIGURE_DDP(0).DDP_M_WC = Math.Round(hdr.NIGHT_FIGURE_DDP(0).DDP_M_WC.Value, 3);
            }
            catch (Exception ex)
            {
                hdr.NIGHT_FIGURE_DDP(0).DDP_M_TOTAL = null;
                hdr.NIGHT_FIGURE_DDP(0).DDP_M_WC = null;
            }
            try
            {
                decimal ddp_m_sep_water = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>("select liquid_volume   from koc.daily_production_data   where daily_production_hdr_s = " + ddp.DDP_OUT_M_WATER_HDR_S + " and to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                hdr.NIGHT_FIGURE_DDP(0).DDP_M_SEP_WATER = ddp_m_sep_water;
                hdr.NIGHT_FIGURE_DDP(0).DDP_M_SEP_WATER = Math.Round(hdr.NIGHT_FIGURE_DDP(0).DDP_M_SEP_WATER.Value, 3);
            }
            catch (Exception ex)
            {
                hdr.NIGHT_FIGURE_DDP(0).DDP_M_SEP_WATER = null;
            }
            try
            {
                decimal ddp_m_treated_crude = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>("select liquid_volume   from koc.daily_production_data   where daily_production_hdr_s = " + ddp.DDP_OUT_M_HDR_S + " and to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                hdr.NIGHT_FIGURE_DDP(0).DDP_M_TREATED_CRUDE = ddp_m_treated_crude;
                hdr.NIGHT_FIGURE_DDP(0).DDP_M_TREATED_CRUDE = Math.Round(hdr.NIGHT_FIGURE_DDP(0).DDP_M_TREATED_CRUDE.Value, 3);
            }
            catch (Exception ex)
            {
                hdr.NIGHT_FIGURE_DDP(0).DDP_M_TREATED_CRUDE = null;
            }
            hdr.NIGHT_FIGURE_DDP(0).GC = GC_ID;
            hdr.NIGHT_FIGURE_DDP(0).HDR_ID = ID;
            hdr.NIGHT_FIGURE_DDP(0).ID = GetSeq();
            // ------------------------------------------------------
            // --------		DDP HEATERS		--------
            // ------------------------------------------------------
            foreach (var ddp_heater in hdr.NIGHT_FIGURE_DDP_HEATERS)
            {
                try
                {
                    // INTO :ddp_heaters.ddp_heaters_rh, :ddp_heaters.ddp_heaters_reason
                    PumpsSpecs PSpecs = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<PumpsSpecs>(Operators.ConcatenateObject("SELECT fop.running_hours, fop.shutdown_reason  FROM koc.oil_field_operation ofo, koc.facility_operating_pty fop  WHERE fop.oil_field_operation_s = ofo.oil_field_operation_s   AND ofo.activity_type = 'FACILITY_OPERATION'    AND  to_date(to_char(ofo.start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy')     AND ofo.surface_facility_s = ", ddp_heater.DDP_HEATER_S), Parameters).FirstOrDefault;
                    ddp_heater.DDP_HEATERS_REASON = (object)PSpecs.running_hours;
                    ddp_heater.DDP_HEATERS_RH = (object)PSpecs.running_hours;
                }

                catch (Exception ex)
                {
                    ddp_heater.DDP_HEATERS_REASON = null;
                    ddp_heater.DDP_HEATERS_RH = null;
                }
            }
            // ------------------------------------------------------
            // --------		DDP TRAINS		--------
            // ------------------------------------------------------
            foreach (var ddp_train in hdr.NIGHT_FIGURES_DDP_TRAIN)
            {
                try
                {
                    // INTO :ddp_trains.ddp_train_process, :ddp_trains.ddp_train_circ, :ddp_trains.ddp_train_salt, :ddp_trains.ddp_train_shut_time, :ddp_trains.ddp_train_reason
                    ddptrainspecs PSpecs = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<ddptrainspecs>(Operators.ConcatenateObject("   SELECT fop.process_hours, fop.circulation_hours, fop.salt_volume, fop.shutin_time, fop.shutdown_reason FROM koc.oil_field_operation ofo, koc.facility_operating_pty fop   WHERE fop.oil_field_operation_s = ofo.oil_field_operation_s AND ofo.activity_type = 'FACILITY_OPERATION'   AND  to_date(to_char(ofo.start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy')   AND ofo.surface_facility_s =", ddp_train.DDP_TRAIN_S), Parameters).FirstOrDefault;
                    ddp_train.DDP_TRAIN_PROCESS = (object)PSpecs.process_hours;
                    ddp_train.DDP_TRAIN_CIRC = (object)PSpecs.circulation_hours;
                    ddp_train.DDP_TRAIN_SALT = (object)PSpecs.salt_volume;
                    ddp_train.DDP_TRAIN_SHUT_TIME = (object)PSpecs.shutin_time;
                    ddp_train.DDP_TRAIN_REASON = PSpecs.shutdown_reason;
                }

                catch (Exception ex)
                {
                    ddp_train.DDP_TRAIN_PROCESS = null;
                    ddp_train.DDP_TRAIN_CIRC = null;
                    ddp_train.DDP_TRAIN_SALT = null;
                    ddp_train.DDP_TRAIN_SHUT_TIME = null;
                    ddp_train.DDP_TRAIN_REASON = null;
                }
            }


        }
        private void Get_Misc_Data()
        {
            DDP_MISC.GC = GC_ID;
            // DDP_MISC.HDR_ID = Me.ID
            DDP_MISC.ID = GetSeq();
            hdr.NIGHT_FIGURES_DDP_MISC.Clear();
            hdr.NIGHT_FIGURES_DDP_MISC.Add(DDP_MISC);
            // SimpleODMConfig.DhubContext.NIGHT_FIGURES_DDP_MISC.AddObject(DDP_MISC)
            var Parameters = new Devart.Data.Oracle.OracleParameter[2];
            Parameters[0] = new Devart.Data.Oracle.OracleParameter("st_date", st_date);
            Parameters = null;

            if (hdr.NIGHT_FIGURES_DDP_MISC(0).MISC_HDR_S.HasValue)
            {

                try
                {
                    string chart_crude_despatch = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<string>("select attribute_string   from koc.daily_miscellaneous_data   where daily_miscellaneous_hdr_s = " + hdr.NIGHT_FIGURES_DDP_MISC(0).MISC_HDR_S + " AND attribute  = 'CHART_CRUDE_DESPATCHES' and to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                    hdr.NIGHT_FIGURES_DDP_MISC(0).CHART_CRUDE_DESPATCH = chart_crude_despatch;
                }
                catch (Exception ex)
                {
                    hdr.NIGHT_FIGURES_DDP_MISC(0).CHART_CRUDE_DESPATCH = "";
                }
                try
                {
                    string chem_cons_gal = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<string>("select attribute_string   from koc.daily_miscellaneous_data   where daily_miscellaneous_hdr_s = " + hdr.NIGHT_FIGURES_DDP_MISC(0).MISC_HDR_S + " AND attribute  = 'CHEMICAL_CONSUMPTION' and to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                    hdr.NIGHT_FIGURES_DDP_MISC(0).CHEM_CONS_GAL = chem_cons_gal;
                }
                catch (Exception ex)
                {
                    hdr.NIGHT_FIGURES_DDP_MISC(0).CHEM_CONS_GAL = "";
                }

                if (ddp.DDP_L_TREATED_CRUDE + ddp.DDP_M_TREATED_CRUDE != 0 & hdr.NIGHT_FIGURES_DDP_MISC(0).CHEM_CONS_GAL.Value > 0)
                {
                    hdr.NIGHT_FIGURES_DDP_MISC(0).CHEM_CONS_PPM = Math.Round(hdr.NIGHT_FIGURES_DDP_MISC(0).CHEM_CONS_GAL.Value * 1000000 / (ddp.DDP_L_TREATED_CRUDE.Value + ddp.DDP_M_TREATED_CRUDE.Value) * 42);
                }
                try
                {
                    string wash_water_consumption = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<string>("select attribute_string   from koc.daily_miscellaneous_data   where daily_miscellaneous_hdr_s = " + hdr.NIGHT_FIGURES_DDP_MISC(0).MISC_HDR_S + " AND attribute  = 'WASH_WATER_CONSUMPTION' and to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                    hdr.NIGHT_FIGURES_DDP_MISC(0).WASH_WATER_CONSUMPTION = wash_water_consumption;
                }
                catch (Exception ex)
                {
                    hdr.NIGHT_FIGURES_DDP_MISC(0).WASH_WATER_CONSUMPTION = "";
                }

                try
                {
                    string effluent_water_analysis = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<string>("select attribute_string   from koc.daily_miscellaneous_data   where daily_miscellaneous_hdr_s = " + hdr.NIGHT_FIGURES_DDP_MISC(0).MISC_HDR_S + " AND attribute  = 'EFFLUENT_WATER_ANALYSIS' and to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                    hdr.NIGHT_FIGURES_DDP_MISC(0).EFFLUENT_WATER_ANALYSIS = effluent_water_analysis;
                }
                catch (Exception ex)
                {
                    hdr.NIGHT_FIGURES_DDP_MISC(0).EFFLUENT_WATER_ANALYSIS = "";
                }
                // If GC_ID = "GC15" Or GC_ID = "GC23" Or GC_ID = "GC25" Then
                try
                {
                    string scale = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<string>("select attribute_string   from koc.daily_miscellaneous_data   where daily_miscellaneous_hdr_s = " + hdr.NIGHT_FIGURES_DDP_MISC(0).MISC_HDR_S + " AND attribute  = 'SCALE_INHIBITOR' and to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                    hdr.NIGHT_FIGURES_DDP_MISC(0).SCALE = scale;
                }
                catch (Exception ex)
                {
                    hdr.NIGHT_FIGURES_DDP_MISC(0).SCALE = "";
                }
                try
                {
                    string oxygen = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<string>("select attribute_string   from koc.daily_miscellaneous_data   where daily_miscellaneous_hdr_s = " + hdr.NIGHT_FIGURES_DDP_MISC(0).MISC_HDR_S + " AND attribute  = 'OXYGEN_SCAVENGER' and to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                    hdr.NIGHT_FIGURES_DDP_MISC(0).OXYGEN = oxygen;
                }
                catch (Exception ex)
                {
                    hdr.NIGHT_FIGURES_DDP_MISC(0).OXYGEN = "";
                }
                try
                {
                    string antifoam = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<string>("select attribute_string   from koc.daily_miscellaneous_data   where daily_miscellaneous_hdr_s = " + hdr.NIGHT_FIGURES_DDP_MISC(0).MISC_HDR_S + " AND attribute  = 'ANTI_FOAM' and to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                    hdr.NIGHT_FIGURES_DDP_MISC(0).ANTIFOAM = antifoam;
                }
                catch (Exception ex)
                {
                    hdr.NIGHT_FIGURES_DDP_MISC(0).ANTIFOAM = "";
                }
                // End If
            }

        }
        private void Get_GasFlow_Data()
        {

            // ------------------------------------------
            // ---------		GET GAS FLOW DATA	------------
            // ------------------------------------------
            var r = new DhubEntities.NIGHT_FIGURE_GASFLOW();
            if (0 is var arg98 && gas_flow_hdr_s is { } arg97 && arg97 > arg98)
            {
                r.GC = GC_ID;
                r.ID = GetSeq();
                hdr.NIGHT_FIGURE_GASFLOW.Add(r);
                try
                {
                    decimal HPGASTOTAL = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>("SELECT attribute_string  FROM daily_miscellaneous_data   where attribute = 'HP GAS TOTAL' and daily_miscellaneous_hdr_s = " + gas_flow_hdr_s + " and to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ").FirstOrDefault;
                    r.HP_GAS_TOTAL = HPGASTOTAL;
                }
                catch (Exception ex)
                {
                    r.HP_GAS_TOTAL = null;
                }
                try
                {
                    decimal HPGASSYSTEM = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>("SELECT attribute_string  FROM daily_miscellaneous_data   where attribute = 'HP GAS SYSTEM'  and daily_miscellaneous_hdr_s =  " + gas_flow_hdr_s + " and to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ").FirstOrDefault;
                    r.HP_GAS_SYSTEM = HPGASSYSTEM;
                }
                catch (Exception ex)
                {
                    r.HP_GAS_SYSTEM = null;
                }
                try
                {
                    decimal LPGASTOTAL = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>("SELECT attribute_string  FROM daily_miscellaneous_data   where attribute = 'LP GAS TOTAL'  and daily_miscellaneous_hdr_s =  " + gas_flow_hdr_s + " and to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ").FirstOrDefault;
                    r.LP_GAS_TOTAL = LPGASTOTAL;
                }
                catch (Exception ex)
                {
                    r.LP_GAS_TOTAL = null;
                }
                try
                {
                    decimal LPGASSYSTEM = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>("SELECT attribute_string  FROM daily_miscellaneous_data   where attribute = 'LP GAS SYSTEM'  and daily_miscellaneous_hdr_s =  " + gas_flow_hdr_s + " and to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ").FirstOrDefault;
                    r.LP_GAS_SYSTEM = LPGASSYSTEM;
                }
                catch (Exception ex)
                {
                    r.LP_GAS_SYSTEM = null;
                }
            }

        }
        private void Get_EFF_Water_data()
        {
            EWDP_HDR.GC = GC_ID;
            EWDP_HDR.ID = GetSeq();
            // SimpleODMConfig.DhubContext.NIGHT_FIGURES_EWDP_HDR.AddObject(EWDP_HDR)
            hdr.NIGHT_FIGURES_EWDP_HDR.Add(EWDP_HDR);

            var Parameters = new Devart.Data.Oracle.OracleParameter[2];
            Parameters[0] = new Devart.Data.Oracle.OracleParameter("st_date", st_date);
            Parameters = null;
            try
            {
                decimal eff_water_produced = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>("select liquid_volume   from koc.daily_production_data   where daily_production_hdr_s = " + eff_water_hdr_s + "  and to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                hdr.NIGHT_FIGURES_EWDP_HDR(0).EFF_WATER_PRODUCED = eff_water_produced;
            }
            catch (Exception ex)
            {
                hdr.NIGHT_FIGURES_EWDP_HDR(0).EFF_WATER_PRODUCED = null;
            }
            foreach (var effluent_water in hdr.NIGHT_FIGURE_EFFLUENT_WATER)
            {
                effluent_water.GC = GC_ID;
                // effluent_water.HDR_ID = ID
                effluent_water.ID = (object)GetSeq();
                try
                {
                    string reservoir = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<string>(Operators.ConcatenateObject("SELECT DECODE(rs.reservoir_name, 'SHUAIBA DOLOMITIC LIMESTONE', 'SHUAIBA', rs.reservoir_name)  ResNAme FROM koc.well_completion wc, koc.reservoir rs       WHERE rs.reservoir_s = wc.reservoir_s AND wc.facility_type <> 'PERFORATION' and wc.well_completion_s = ", effluent_water.WELL_WC_S), Parameters).FirstOrDefault;
                    effluent_water.RESERVOIR = reservoir;
                }
                catch (Exception ex)
                {
                    effluent_water.RESERVOIR = "";
                }
                try
                {
                    // INTO :effluent_water.pump_pressure, :effluent_water.whp_casing, :effluent_water.whp_tubing, :effluent_water.running_hours, :effluent_water.SHUT_REASON
                    ewdpwellsspecs ewdpwellsspecsp = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<ewdpwellsspecs>(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT fop.operating_press, fop.whp_casing, fop.whp_tubing, fop.running_hours, fop.SHUTDOWN_REASON    FROM koc.oil_field_operation ofo, koc.facility_operating_pty fop  WHERE fop.oil_field_operation_s = ofo.oil_field_operation_s  AND  to_date(to_char(ofo.start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy')   AND ofo.surface_facility_s = " + gc_sf_s + "  AND ofo.activity_type = 'WATER_DISPOSAL'  AND ofo.uwi = '", effluent_water.WELL), "'  and ofo.well_completion_s = "), effluent_water.WELL_WC_S), Parameters).FirstOrDefault;
                    effluent_water.PUMP_PRESSURE = (object)ewdpwellsspecsp.operating_press;
                    effluent_water.WHP_CASING = (object)ewdpwellsspecsp.whp_casing;
                    effluent_water.RUNNING_HOURS = (object)ewdpwellsspecsp.running_hours;
                    effluent_water.WHP_TUBING = (object)ewdpwellsspecsp.whp_tubing;
                    effluent_water.SHUT_REASON = ewdpwellsspecsp.SHUTDOWN_REASON;
                }
                catch (Exception ex)
                {
                    try
                    {
                        ewdpwellsspecs ewdpwellsspecsp = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<ewdpwellsspecs>(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT fop.operating_press, fop.whp_casing, fop.whp_tubing, fop.running_hours, fop.SHUTDOWN_REASON    FROM koc.oil_field_operation ofo, koc.facility_operating_pty fop  WHERE fop.oil_field_operation_s = ofo.oil_field_operation_s  AND  to_date(to_char(ofo.start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy')   AND ofo.surface_facility_s = " + gc_sf_s + "  AND ofo.activity_type = 'WATER_DISPOSAL'  AND ofo.uwi = '", effluent_water.WELL), "'"), Parameters).FirstOrDefault;
                        effluent_water.PUMP_PRESSURE = (object)ewdpwellsspecsp.operating_press;
                        effluent_water.WHP_CASING = (object)ewdpwellsspecsp.whp_casing;
                        effluent_water.RUNNING_HOURS = (object)ewdpwellsspecsp.running_hours;
                        effluent_water.WHP_TUBING = (object)ewdpwellsspecsp.whp_tubing;
                        effluent_water.SHUT_REASON = ewdpwellsspecsp.SHUTDOWN_REASON;
                    }
                    catch (Exception ex1)
                    {
                        effluent_water.PUMP_PRESSURE = (object)0;
                        effluent_water.WHP_CASING = (object)0;
                        effluent_water.RUNNING_HOURS = (object)0;
                        effluent_water.WHP_TUBING = (object)0;
                        effluent_water.SHUT_REASON = (object)0;
                    }
                }
                try
                {
                    decimal well_dph_s = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>(Operators.ConcatenateObject(" Select daily_production_hdr_s  FROM koc.daily_production_hdr  WHERE material_type = 'WATER'  AND activity_type = 'MEASURED' AND flow_dir_type = 'DISPOSAL'   AND well_completion_s = ", effluent_water.WELL_WC_S), Parameters).FirstOrDefault;
                    effluent_water.WELL_DPH_S = (object)well_dph_s;
                }
                catch (Exception ex)
                {
                    effluent_water.WELL_DPH_S = null;
                }
                try
                {
                    decimal injected_water = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>(Operators.ConcatenateObject(" Select liquid_volume FROM koc.daily_production_data WHERE  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy')    AND daily_production_hdr_s = ", effluent_water.WELL_DPH_S), Parameters).FirstOrDefault;
                    effluent_water.INJECTED_WATER = (object)injected_water;
                }
                catch (Exception ex)
                {
                    effluent_water.INJECTED_WATER = null;
                }
            }




        }
        private void Get_Finder_Data()
        {

            // -----------------------------------------------------------
            // ----	GET DESPATCHES, FACTORS, REMARKS & T/L PRESSURE  ----
            // -----------------------------------------------------------
            var Parameters = new Devart.Data.Oracle.OracleParameter[1];

            // Parameters(0) = New Devart.Data.Oracle.OracleParameter("st_date", st_date)


            Parameters[0] = new Devart.Data.Oracle.OracleParameter("despatch_hdr_s", despatch_hdr_s);
            Parameters = null;
            try
            {
                // ------------------------------------------
                // ----		GET PRODUCTION DATA	----
                // ------------------------------------------
                hdr.NIGHT_FIGURES_PROD_STOCK.Clear();
                if (GC_ID == "GC27" | GC_ID == "GC28")
                {
                    // --------------------------- Getting Main Light and Medium 
                    try
                    {
                        l_retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<DhubEntities.NIGHT_FIGURES_PROD_STOCK>("SELECT liquid_volume l_net_despatch, gc_factor l_factor, pressure l_tl, remarks     FROM koc.daily_production_data     WHERE daily_production_hdr_s =" + l_despatch_hdr_s + " AND to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                        if (l_retint.L_FACTOR != 0)
                        {
                            l_retint.L_GROSS_DESPATCH = Math.Round(Operators.DivideObject(Interaction.IIf(l_retint.L_NET_DESPATCH > 0, l_retint.L_NET_DESPATCH, 0), Interaction.IIf(l_retint.L_FACTOR > 0, l_retint.L_FACTOR, 1)));
                        }
                        else
                        {
                            l_retint.L_GROSS_DESPATCH = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        l_retint.L_NET_DESPATCH = 0;
                        l_retint.L_FACTOR = 0;
                        l_retint.L_TL = 0;
                    }
                    try
                    {
                        m_retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<DhubEntities.NIGHT_FIGURES_PROD_STOCK>("SELECT liquid_volume M_NET_DISPATCH, gc_factor m_factor, pressure m_tl, remarks     FROM koc.daily_production_data     WHERE daily_production_hdr_s =" + m_despatch_hdr_s + " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                        if (m_retint.M_FACTOR != 0)
                        {
                            m_retint.M_GROSS_DESPATCH = Math.Round(Operators.DivideObject(Interaction.IIf(m_retint.M_NET_DISPATCH > 0, m_retint.M_NET_DISPATCH, 0), Interaction.IIf(m_retint.M_FACTOR > 0, l_retint.L_FACTOR, 1)));
                        }
                        else
                        {
                            m_retint.M_GROSS_DESPATCH = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        m_retint.M_NET_DISPATCH = 0;
                        m_retint.M_FACTOR = 0;
                        m_retint.M_TL = 0;
                    }
                    try
                    {
                        T_DESPATCH = l_retint.L_NET_DESPATCH + m_retint.M_NET_DISPATCH;
                    }
                    catch (Exception ex)
                    {

                    }
                    l_retint.M_NET_DISPATCH = m_retint.M_NET_DISPATCH;
                    l_retint.M_GROSS_DESPATCH = m_retint.M_GROSS_DESPATCH;
                    l_retint.M_FACTOR = m_retint.M_FACTOR;
                    l_retint.M_TL = m_retint.M_TL;
                    // ----------------- Getting Dry and Wet ------------------
                    try
                    {
                        l_retint.L_DRY_PRODUCTION = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>("  SELECT liquid_volume  FROM koc.daily_production_data  WHERE daily_production_hdr_s =" + l_dry_production_hdr_s + " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                    }
                    catch (Exception ex)
                    {
                        l_retint.L_DRY_PRODUCTION = 0;
                    }
                    try
                    {
                        l_retint.L_WET_PRODUCTION = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>("  SELECT liquid_volume  FROM koc.daily_production_data  WHERE daily_production_hdr_s =" + l_wet_production_hdr_s + " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                    }
                    catch (Exception ex)
                    {
                        l_retint.L_WET_PRODUCTION = 0;
                    }
                    try
                    {
                        l_retint.L_NET_PRODUCTION = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>("  SELECT liquid_volume  FROM koc.daily_production_data  WHERE daily_production_hdr_s =" + l_production_hdr_s + " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                    }
                    catch (Exception ex)
                    {
                        l_retint.L_NET_PRODUCTION = 0;
                    }
                    try
                    {
                        l_retint.M_DRY_PRODUCTION = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>("  SELECT liquid_volume  FROM koc.daily_production_data  WHERE daily_production_hdr_s =" + m_dry_production_hdr_s + " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                    }
                    catch (Exception ex)
                    {
                        l_retint.M_DRY_PRODUCTION = 0;
                    }
                    try
                    {
                        l_retint.M_WET_PRODUCTION = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>("  SELECT liquid_volume  FROM koc.daily_production_data  WHERE daily_production_hdr_s =" + m_wet_production_hdr_s + " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                    }
                    catch (Exception ex)
                    {
                        l_retint.M_WET_PRODUCTION = 0;
                    }
                    try
                    {
                        l_retint.M_NET_PRODUCTION = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>("  SELECT liquid_volume  FROM koc.daily_production_data  WHERE daily_production_hdr_s =" + m_production_hdr_s + " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                    }
                    catch (Exception ex)
                    {
                        l_retint.M_NET_PRODUCTION = 0;
                    }
                    try
                    {
                        l_retint.M_GROSS_PRODUCTION = l_retint.M_DRY_PRODUCTION + l_retint.M_WET_PRODUCTION;
                        l_retint.L_GROSS_PRODUCTION = l_retint.L_DRY_PRODUCTION + l_retint.L_WET_PRODUCTION;
                    }
                    catch (Exception ex)
                    {

                    }


                    try
                    {
                        l_retint.T_PRODUCTION = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>("  SELECT liquid_volume  FROM koc.daily_production_data  WHERE daily_production_hdr_s =" + production_hdr_s + " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                        T_PRODUCTION = l_retint.T_PRODUCTION;
                    }

                    catch (Exception ex)
                    {
                        l_retint.T_PRODUCTION = l_retint.M_NET_PRODUCTION + l_retint.L_NET_PRODUCTION;
                        T_PRODUCTION = l_retint.M_NET_PRODUCTION + l_retint.L_NET_PRODUCTION;
                    }
                    // If l_retint.T_PRODUCTION.Value <= 0 Then
                    // l_retint.T_PRODUCTION = l_retint.M_NET_PRODUCTION + l_retint.L_NET_PRODUCTION
                    // End If
                    // -------------- Getting Misc Data ----------------------------
                    try
                    {
                        l_retint.M_API_CORR = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>(" SELECT attribute_string  FROM koc.daily_miscellaneous_data  WHERE daily_miscellaneous_hdr_s = " + m_api_salt_hdr_s + " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy')  AND attribute = 'GC_API'", Parameters).FirstOrDefault;
                    }
                    catch (Exception ex)
                    {
                        l_retint.M_API_CORR = 0;
                    }
                    try
                    {
                        l_retint.M_TEMPERATURE = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>(" SELECT attribute_string FROM koc.daily_miscellaneous_data  WHERE daily_miscellaneous_hdr_s = " + m_api_salt_hdr_s + " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy')  AND attribute = 'GC_TEMPERATURE'", Parameters).FirstOrDefault;
                    }
                    catch (Exception ex)
                    {
                        l_retint.M_TEMPERATURE = 0;
                    }
                    try
                    {
                        l_retint.M_SALT = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>(" SELECT attribute_string  FROM koc.daily_miscellaneous_data  WHERE daily_miscellaneous_hdr_s = " + m_api_salt_hdr_s + " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy')  AND attribute = 'GC_SALT'", Parameters).FirstOrDefault;
                    }
                    catch (Exception ex)
                    {
                        l_retint.M_SALT = 0;
                    }
                    // -----------------------------------------------------------
                    try
                    {
                        l_retint.L_API_CORR = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>(" SELECT attribute_string  FROM koc.daily_miscellaneous_data  WHERE daily_miscellaneous_hdr_s = " + l_api_salt_hdr_s + " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy')  AND attribute = 'GC_API'", Parameters).FirstOrDefault;
                    }
                    catch (Exception ex)
                    {
                        l_retint.L_API_CORR = 0;
                    }
                    try
                    {
                        l_retint.L_TEMPERATURE = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>(" SELECT attribute_string  FROM koc.daily_miscellaneous_data  WHERE daily_miscellaneous_hdr_s = " + l_api_salt_hdr_s + " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy')  AND attribute = 'GC_TEMPERATURE'", Parameters).FirstOrDefault;
                    }
                    catch (Exception ex)
                    {
                        l_retint.L_TEMPERATURE = 0;
                    }
                    try
                    {
                        l_retint.L_SALT = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>(" SELECT attribute_string  FROM koc.daily_miscellaneous_data  WHERE daily_miscellaneous_hdr_s = " + l_api_salt_hdr_s + " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy')  AND attribute = 'GC_SALT'", Parameters).FirstOrDefault;
                    }
                    catch (Exception ex)
                    {
                        l_retint.L_SALT = 0;
                    }
                }
                // ----------------------------------------------------------
                else
                {
                    try
                    {
                        PROD_STOCK = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<DhubEntities.NIGHT_FIGURES_PROD_STOCK>("SELECT liquid_volume l_net_despatch, gc_factor l_factor, pressure l_tl, remarks     FROM koc.daily_production_data     WHERE daily_production_hdr_s = " + despatch_hdr_s + " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                        PROD_STOCK.GC = GC_ID;
                        // PROD_STOCK.HDR_ID = ID
                        PROD_STOCK.ID = GetSeq();

                        try
                        {
                            L_FACTOR = PROD_STOCK.L_FACTOR;
                        }
                        catch (Exception ex)
                        {

                        }
                    }

                    catch (Exception ex)
                    {

                    }
                    // --------------------
                    if (PROD_STOCK.L_FACTOR != 0)
                    {
                        PROD_STOCK.L_GROSS_DESPATCH = PROD_STOCK.L_NET_DESPATCH / PROD_STOCK.L_FACTOR;
                    }
                    else
                    {
                        PROD_STOCK.L_GROSS_DESPATCH = 0;
                    }
                    try
                    {
                        PROD_STOCK.T_DESPATCH = PROD_STOCK.L_NET_DESPATCH;
                    }
                    catch (Exception ex)
                    {

                    }

                    try
                    {
                        PROD_STOCK.L_DRY_PRODUCTION = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>("  SELECT liquid_volume  FROM koc.daily_production_data  WHERE daily_production_hdr_s =" + dry_production_hdr_s + " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                    }
                    catch (Exception ex)
                    {
                        PROD_STOCK.L_DRY_PRODUCTION = 0;
                    }
                    try
                    {
                        PROD_STOCK.L_WET_PRODUCTION = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>("  SELECT liquid_volume  FROM koc.daily_production_data  WHERE daily_production_hdr_s =" + l_wet_production_hdr_s + " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                    }
                    catch (Exception ex)
                    {
                        PROD_STOCK.L_WET_PRODUCTION = 0;
                    }
                    try
                    {
                        PROD_STOCK.L_NET_PRODUCTION = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>("  SELECT liquid_volume  FROM koc.daily_production_data  WHERE daily_production_hdr_s =" + l_production_hdr_s + " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                    }
                    catch (Exception ex)
                    {
                        PROD_STOCK.L_NET_PRODUCTION = 0;
                    }
                    try
                    {
                        PROD_STOCK.L_GROSS_PRODUCTION = PROD_STOCK.L_DRY_PRODUCTION + PROD_STOCK.L_WET_PRODUCTION;
                    }
                    catch (Exception ex)
                    {

                    }
                    try
                    {
                        PROD_STOCK.T_PRODUCTION = PROD_STOCK.L_NET_PRODUCTION;
                    }
                    catch (Exception ex)
                    {

                    }
                    try
                    {
                        T_PRODUCTION = PROD_STOCK.T_PRODUCTION;
                    }
                    catch (Exception ex)
                    {

                    }
                    try
                    {
                        T_DESPATCH = PROD_STOCK.L_NET_DESPATCH;
                    }
                    catch (Exception ex)
                    {

                    }

                    try
                    {
                        PROD_STOCK.L_API_CORR = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>("     SELECT attribute_string FROM koc.daily_miscellaneous_data   WHERE daily_miscellaneous_hdr_s =" + l_api_salt_hdr_s + " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy')  AND attribute = 'GC_API'", Parameters).FirstOrDefault;
                    }
                    catch (Exception ex)
                    {
                        PROD_STOCK.L_API_CORR = 0;
                    }
                    try
                    {
                        PROD_STOCK.L_TEMPERATURE = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>("     SELECT attribute_string  FROM koc.daily_miscellaneous_data   WHERE daily_miscellaneous_hdr_s =" + l_api_salt_hdr_s + " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy')  AND attribute = 'GC_TEMPERATURE'", Parameters).FirstOrDefault;
                    }
                    catch (Exception ex)
                    {
                        PROD_STOCK.L_TEMPERATURE = 0;
                    }
                    try
                    {
                        PROD_STOCK.L_SALT = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>("     SELECT attribute_string  FROM koc.daily_miscellaneous_data   WHERE daily_miscellaneous_hdr_s =" + l_api_salt_hdr_s + " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy')  AND attribute = 'GC_SALT'", Parameters).FirstOrDefault;
                    }
                    catch (Exception ex)
                    {
                        PROD_STOCK.L_SALT = 0;
                    }
                    if (GC_ID == "GC15" | GC_ID == "GC23" | GC_ID == "GC25" | GC_ID == "EPF-120")
                    {
                        try
                        {
                            PROD_STOCK.SA_NET = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>(" Select liquid_volume  from koc.daily_production_data   WHERE daily_production_hdr_s = " + SA_oil_s + " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                        }
                        catch (Exception ex)
                        {
                            PROD_STOCK.SA_NET = 0;
                        }
                        try
                        {
                            PROD_STOCK.SA_WATER = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>(" Select liquid_volume  from koc.daily_production_data   WHERE daily_production_hdr_s = " + SA_water_s + " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                        }
                        catch (Exception ex)
                        {
                            PROD_STOCK.SA_WATER = 0;
                        }
                        try
                        {
                            PROD_STOCK.SA_WC = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>(" Select nominal_water_cut  from koc.daily_production_data   WHERE daily_production_hdr_s = " + SA_water_s + " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                        }
                        catch (Exception ex)
                        {
                            PROD_STOCK.SA_WC = 0;
                        }
                        try
                        {
                            PROD_STOCK.SA_GROSS = PROD_STOCK.SA_WATER / (PROD_STOCK.SA_WC / 100);
                        }
                        catch (Exception ex)
                        {

                        }

                        try
                        {
                            PROD_STOCK.RA_NET = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>(" Select liquid_volume  from koc.daily_production_data   WHERE daily_production_hdr_s = " + RA_oil_s + " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                        }
                        catch (Exception ex)
                        {
                            PROD_STOCK.RA_NET = 0;
                        }
                        try
                        {
                            PROD_STOCK.RA_WATER = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>(" Select liquid_volume  from koc.daily_production_data   WHERE daily_production_hdr_s = " + RA_water_s + " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                        }
                        catch (Exception ex)
                        {
                            PROD_STOCK.RA_WATER = 0;
                        }
                        try
                        {
                            PROD_STOCK.RA_WC = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>(" Select nominal_water_cut  from koc.daily_production_data   WHERE daily_production_hdr_s = " + RA_water_s + " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                        }
                        catch (Exception ex)
                        {
                            PROD_STOCK.RA_WC = 0;
                        }
                        try
                        {
                            PROD_STOCK.RA_GROSS = PROD_STOCK.RA_WATER / (PROD_STOCK.RA_WC / 100);
                        }
                        catch (Exception ex)
                        {

                        }

                        try
                        {
                            PROD_STOCK.RQ_NET = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>(" Select liquid_volume  from koc.daily_production_data   WHERE daily_production_hdr_s = " + RQ_oil_s + " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                        }
                        catch (Exception ex)
                        {
                            PROD_STOCK.RQ_NET = 0;
                        }

                        try
                        {
                            PROD_STOCK.RQ_WATER = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>(" Select liquid_volume  from koc.daily_production_data   WHERE daily_production_hdr_s = " + RQ_water_s + " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                        }
                        catch (Exception ex)
                        {
                            // PROD_STOCK.RQ_WATER = 0
                        }
                        try
                        {
                            PROD_STOCK.RQ_WC = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>(" Select nominal_water_cut  from koc.daily_production_data   WHERE daily_production_hdr_s = " + RQ_water_s + " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                        }
                        catch (Exception ex)
                        {
                            PROD_STOCK.RQ_WC = 0;
                        }
                        try
                        {
                            PROD_STOCK.RQ_GROSS = PROD_STOCK.RQ_WATER / (PROD_STOCK.RQ_WC / 100);
                        }
                        catch (Exception ex)
                        {

                        }


                        try
                        {
                            PROD_STOCK.AD_NET = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>(" Select liquid_volume  from koc.daily_production_data   WHERE daily_production_hdr_s = " + AD_oil_s + " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                        }
                        catch (Exception ex)
                        {
                            PROD_STOCK.AD_NET = 0;
                        }

                        try
                        {
                            PROD_STOCK.AD_WATER = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>(" Select liquid_volume  from koc.daily_production_data   WHERE daily_production_hdr_s = " + AD_water_s + " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                        }
                        catch (Exception ex)
                        {
                            PROD_STOCK.AD_WATER = 0;
                        }

                        try
                        {
                            PROD_STOCK.AD_WC = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>(" Select nominal_water_cut  from koc.daily_production_data   WHERE daily_production_hdr_s = " + AD_water_s + " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                        }
                        catch (Exception ex)
                        {
                            PROD_STOCK.AD_WC = 0;
                        }
                        try
                        {
                            PROD_STOCK.AD_GROSS = PROD_STOCK.AD_WATER / (PROD_STOCK.AD_WC / 100);
                        }
                        catch (Exception ex)
                        {

                        }

                    }
                    if (GC_ID == "GC15")
                    {
                        try
                        {
                            PROD_STOCK.TL1 = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>(" Select pressure  from koc.daily_production_data   WHERE daily_production_hdr_s = " + tl1_s + " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                        }
                        catch (Exception ex)
                        {
                            PROD_STOCK.TL1 = 0;
                        }
                        try
                        {
                            PROD_STOCK.TL2 = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>(" Select pressure  from koc.daily_production_data   WHERE daily_production_hdr_s = " + tl2_s + " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                        }
                        catch (Exception ex)
                        {
                            PROD_STOCK.TL2 = 0;
                        }
                        try
                        {
                            PROD_STOCK.TL3 = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>(" Select pressure  from koc.daily_production_data   WHERE daily_production_hdr_s = " + tl3_s + " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                        }
                        catch (Exception ex)
                        {
                            PROD_STOCK.TL3 = 0;
                        }
                        try
                        {
                            PROD_STOCK.SUBBIA = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>(" Select pressure  from koc.daily_production_data   WHERE daily_production_hdr_s = " + tl_subbia_s + " AND  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                        }
                        catch (Exception ex)
                        {
                            PROD_STOCK.SUBBIA = 0;
                        }
                    }

                }


                if (GC_ID == "GC27" | GC_ID == "GC28")
                {
                    l_retint.GC = GC_ID;
                    // l_retint.HDR_ID = ID
                    l_retint.ID = GetSeq();
                    // m_retint.GC = GC_ID
                    // m_retint.HDR_ID = ID
                    // m_retint.ID = GetSeq()
                    // SimpleODMConfig.DhubContext.NIGHT_FIGURES_PROD_STOCK.AddObject(l_retint)
                    // SimpleODMConfig.DhubContext.NIGHT_FIGURES_PROD_STOCK.AddObject(m_retint)
                    hdr.NIGHT_FIGURES_PROD_STOCK.Add(l_retint);
                    // hdr.NIGHT_FIGURES_PROD_STOCK.Add(m_retint)
                    var lre = new DhubEntities.NIGHT_FIGURE_REMARKS();
                    if (string.IsNullOrEmpty(l_retint.REMARKS) == false)
                    {

                        lre.GC_ID = GC_ID;
                        // lre.HDR_ID = Me.ID
                        lre.ID = GetSeq();
                        lre.REMARK = l_retint.REMARKS;
                        lre.REMARK_TYPE = "L_PROD_STOCK";
                        // SimpleODMConfig.DhubContext.NIGHT_FIGURE_REMARKS.AddObject(lre)
                        hdr.NIGHT_FIGURE_REMARKS.Add(lre);

                    }
                }

                // Dim mre As New ImprodDbEntities.NIGHT_FIGURE_REMARKS
                // If String.IsNullOrEmpty(m_retint.REMARKS) = False Then
                // mre.GC_ID = GC_ID
                // ' mre.HDR_ID = Me.ID
                // mre.ID = GetSeq()
                // mre.REMARK = l_retint.REMARKS
                // mre.REMARK_TYPE = "M_PROD_STOCK"
                // SimpleODMConfig.DhubContext.NIGHT_FIGURE_REMARKS.AddObject(mre)
                // hdr.NIGHT_FIGURE_REMARKS.Add(mre)

                // End If

                else
                {
                    hdr.NIGHT_FIGURES_PROD_STOCK.Add(PROD_STOCK);
                    if (string.IsNullOrEmpty(PROD_STOCK.REMARKS) == false)
                    {

                        var re = new DhubEntities.NIGHT_FIGURE_REMARKS();
                        re.GC_ID = GC_ID;
                        // re.HDR_ID = Me.ID
                        re.ID = GetSeq();
                        re.REMARK = PROD_STOCK.REMARKS;
                        re.REMARK_TYPE = "PROD_STOCK";
                        // SimpleODMConfig.DhubContext.NIGHT_FIGURE_REMARKS.AddObject(re)
                        hdr.NIGHT_FIGURE_REMARKS.Add(re);

                    }

                }
                LogOutPut.Add("Got Production Stock data");
            }
            catch (Exception ex)
            {
                LogOutPut.Add("No Production Stock data");
            }
            try
            {
                Get_Tanks_Data();
            }
            catch (Exception ex)
            {

            }
            try
            {
                get_Pump_data();
            }
            catch (Exception ex)
            {

            }
            try
            {
                Get_turbines_data();
            }
            catch (Exception ex)
            {

            }
            try
            {
                get_cru_data();
            }
            catch (Exception ex)
            {

            }
            try
            {
                Get_Ddp_Data();
            }
            catch (Exception ex)
            {

            }
            try
            {
                Get_GasFlow_Data();
            }
            catch (Exception ex)
            {

            }
            try
            {
                Get_Misc_Data();
            }
            catch (Exception ex)
            {

            }
            try
            {
                Get_EFF_Water_data();
            }
            catch (Exception ex)
            {

            }



            // --- ===============despatch_hdr_s
            // --   Effluent water for EWDP
            // hdr.NIGHT_FIGURES_EWDP_HDR(0).GC = GC_ID
            // hdr.NIGHT_FIGURES_EWDP_HDR(0).HDR_ID = ID
            // hdr.NIGHT_FIGURES_EWDP_HDR(0).ID = GetSeq()
            if (0 is var arg100 && EWDP1_HDR_S is { } arg99 && arg99 > arg100)
            {
                try
                {
                    hdr.NIGHT_FIGURES_EWDP_HDR(0).EFF_WATER_IN_EWDP1 = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>("Select liquid_volume  from koc.daily_production_data where daily_production_hdr_s = " + EWDP1_HDR_S + " and  to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                }
                catch (Exception ex)
                {
                    hdr.NIGHT_FIGURES_EWDP_HDR(0).EFF_WATER_IN_EWDP1 = "";
                }


            }
            foreach (var eff in hdr.NIGHT_FIGURE_EFFLUENT_WATER)
            {

                if (Conversions.ToBoolean(eff.INJECTED_WATER.HasValue))
                {

                    total_water_injection = Conversions.ToInteger(Operators.AddObject(total_water_injection, eff.INJECTED_WATER));

                }
            }
            // --- =============
            hdr.NIGHT_FIGURES_EWDP_HDR(0).EFF_WATER_IN_PIT = hdr.NIGHT_FIGURES_EWDP_HDR(0).EFF_WATER_PRODUCED - total_water_injection - hdr.NIGHT_FIGURES_EWDP_HDR(0).EFF_WATER_IN_EWDP1;
            // ----		DESPATCH PUMP DATA		----
            // ------------------------------------------
            foreach (var DESPATCH_PUMP in hdr.NIGHT_FIGURES_EWDP_PUMPS)
            {
                try
                {
                    // INTO :DESPATCH_PUMP.dpump_running_hours
                    DESPATCH_PUMP.DPUMP_RUNNING_HOURS = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>(Operators.ConcatenateObject("    Select pp.running_hours FROM koc.oil_field_operation ofo, koc.pump_pty pp  WHERE pp.oil_field_operation_s = ofo.oil_field_operation_s  AND ofo. to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy')   AND ofo.activity_type = 'FACILITY_OPERATION'   AND ofo.surface_facility_s =", DESPATCH_PUMP.DPUMP_S), Parameters).FirstOrDefault;
                }
                catch (Exception ex)
                {
                    // DESPATCH_PUMP.DPUMP_RUNNING_HOURS = ""
                }
            }
            // -- ========
            // --  Tank Effluent Water
            if (0 is var arg102 && EFF_WATER_TANK_HDR_S is { } arg101 && arg101 > arg102)
            {
                try
                {
                    // into :EFF_WATER.EFF_WATER_STOCK 
                    hdr.NIGHT_FIGURES_EWDP_HDR(0).EFF_WATER_STOCK = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>("  Select nvl(liquid_volume, 0)  from koc.daily_production_data where  daily_production_hdr_s =  " + EFF_WATER_TANK_HDR_S + " and    to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                }
                catch (Exception ex)
                {
                    // Me.hdr.NIGHT_FIGURES_EWDP_HDR(0).EFF_WATER_STOCK = ""
                }
            }
            // --- Eff. Water - IN
            if (0 is var arg104 && EFF_WATER_IN_HDR_S is { } arg103 && arg103 > arg104)
            {
                try
                {
                    // into :EFF_WATER.EFF_WATER_STOCK 
                    hdr.NIGHT_FIGURES_EWDP_HDR(0).EFF_WATER_IN = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>("  Select nvl(liquid_volume, 0)  from koc.daily_production_data where  daily_production_hdr_s =  " + EFF_WATER_IN_HDR_S + " and    to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                }
                catch (Exception ex)
                {
                    // Me.hdr.NIGHT_FIGURES_EWDP_HDR(0).EFF_WATER_IN = ""
                }

            }

            // --- Eff. Water - Out
            if (0 is var arg106 && EFF_WATER_OUT_HDR_S is { } arg105 && arg105 > arg106)
            {
                try
                {
                    // into :EFF_WATER.EFF_WATER_STOCK 
                    hdr.NIGHT_FIGURES_EWDP_HDR(0).EFF_WATER_OUT = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<decimal>("  Select nvl(liquid_volume, 0)  from koc.daily_production_data where  daily_production_hdr_s =  " + EFF_WATER_OUT_HDR_S + " and    to_date(to_char(start_time,'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + txt_date + "','dd/mm/yyyy') ", Parameters).FirstOrDefault;
                }
                catch (Exception ex)
                {
                    // Me.hdr.NIGHT_FIGURES_EWDP_HDR(0).EFF_WATER_OUT = ""
                }
            }
            hdr.NIGHT_FIGURES_EWDP_HDR(0).EFF_WATER_IN_PIT = hdr.NIGHT_FIGURES_EWDP_HDR(0).EFF_WATER_PRODUCED - total_water_injection - hdr.NIGHT_FIGURES_EWDP_HDR(0).EFF_WATER_IN_EWDP1 + hdr.NIGHT_FIGURES_EWDP_HDR(0).EFF_WATER_STOCK + hdr.NIGHT_FIGURES_EWDP_HDR(0).EFF_WATER_IN - hdr.NIGHT_FIGURES_EWDP_HDR(0).EFF_WATER_OUT;

        }
        private void Get_Finder_Ports()
        {
            // --------------------------------------------------
            // ----		GET GENERAL PORTS		----
            // --------------------------------------------------
            try
            {
                int retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("SELECT general_port_s  FROM koc.general_port   WHERE facility_type = 'OUTLET_PORT'   AND surface_facility_s =" + gc_sf_s).FirstOrDefault;
                gc_outlet_port = retint;
                LogOutPut.Add("Got outlet port for the GC");
            }
            catch (Exception ex)
            {
                LogOutPut.Add("Unable to get outlet port for the GC");
                Erroron = true;
                return;
            }
            try
            {
                int retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("SELECT general_port_s   FROM koc.general_port   WHERE facility_type = 'INLET_PORT'   AND surface_facility_s =" + gc_sf_s).FirstOrDefault;
                gc_inlet_port = retint;
                LogOutPut.Add("Got inlet port for the GC");
            }
            catch (Exception ex)
            {
                LogOutPut.Add("Unable to get inlet port for the GC");
                Erroron = true;
                return;
            }
            try
            {
                int retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("SELECT general_port_s   FROM koc.general_port   WHERE facility_type = 'STOCK_PORT'   AND surface_facility_s =" + gc_sf_s).FirstOrDefault;
                gc_stock_port = retint;
                LogOutPut.Add("Got inlet port for the GC");
            }
            catch (Exception ex)
            {
                LogOutPut.Add("Unable to get inlet port for the GC");
                Erroron = true;
                return;
            }
        }
        private void Get_Finder_Dispatch_Hdr()
        {
            // --------------------------------------------------
            // ----		DESPATCH HEADERS		----
            // --------------------------------------------------
            try
            {
                int retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("SELECT daily_production_hdr_s FROM koc.daily_production_hdr   WHERE activity_type = 'MEASURED' AND flow_dir_type = 'PRODUCTION' AND material_type = 'OIL'  AND general_port_s =" + gc_outlet_port).FirstOrDefault;
                despatch_hdr_s = retint;
                LogOutPut.Add("Got despatch hdr for Oil");
            }
            catch (Exception ex)
            {
                LogOutPut.Add("No despatch hdr for Oil");
                Erroron = true;
                return;
            }
            try
            {
                int retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("SELECT daily_production_hdr_s FROM koc.daily_production_hdr   WHERE activity_type = 'MEASURED' AND flow_dir_type = 'PRODUCTION' AND material_type = 'LIGHT OIL'  AND general_port_s =" + gc_outlet_port).FirstOrDefault;
                l_despatch_hdr_s = retint;
                LogOutPut.Add("Got despatch hdr for Light Oil");
            }
            catch (Exception ex)
            {
                LogOutPut.Add("No despatch hdr for Light Oil");
                Erroron = true;
                return;
            }
            try
            {
                int retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("SELECT daily_production_hdr_s FROM koc.daily_production_hdr   WHERE activity_type = 'MEASURED' AND flow_dir_type = 'PRODUCTION' AND material_type = 'MEDIUM OIL'  AND general_port_s =" + gc_outlet_port).FirstOrDefault;
                m_despatch_hdr_s = retint;
                LogOutPut.Add("Got despatch hdr for Medium Oil");
            }
            catch (Exception ex)
            {
                LogOutPut.Add("No despatch hdr for Medium Oil");
                Erroron = true;
                return;
            }
        }
        private void Get_Finder_Stock_Hdr()
        {
            // --------------------------------------------------
            // ----		Stock HEADERS		----
            // --------------------------------------------------
            try
            {
                int retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>(" SELECT daily_production_hdr_s  FROM koc.daily_production_hdr   WHERE activity_type = 'MEASURED' AND flow_dir_type = 'STOCK' AND material_type = 'OIL'   AND general_port_s = " + gc_stock_port).FirstOrDefault;
                stock_hdr_s = retint;
                LogOutPut.Add("Got stock hdr hdr for Oil");
            }
            catch (Exception ex)
            {
                LogOutPut.Add("No stock hdr hdr for Oil");
                Erroron = true;
                return;
            }
            try
            {
                int retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>(" SELECT daily_production_hdr_s  FROM koc.daily_production_hdr   WHERE activity_type = 'MEASURED' AND flow_dir_type = 'STOCK' AND material_type = 'LIGHT OIL'   AND general_port_s = " + gc_stock_port).FirstOrDefault;
                l_stock_hdr_s = retint;
                LogOutPut.Add("Got stock hdr hdr for Light Oil");
            }
            catch (Exception ex)
            {
                LogOutPut.Add("No stock hdr hdr for Light Oil");
                Erroron = true;
                return;
            }
            try
            {
                int retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>(" SELECT daily_production_hdr_s  FROM koc.daily_production_hdr   WHERE activity_type = 'MEASURED' AND flow_dir_type = 'STOCK' AND material_type = 'MEDIUM OIL'   AND general_port_s = " + gc_stock_port).FirstOrDefault;
                m_stock_hdr_s = retint;
                LogOutPut.Add("Got stock hdr hdr for Medium Oil");
            }
            catch (Exception ex)
            {
                LogOutPut.Add("No stock hdr hdr for Medium Oil");
                Erroron = true;
                return;
            }
        }
        private void Get_Finder_Prod_Hdr()
        {
            // --------------------------------------------------
            // ----		PRODUCTION HEADERS		----
            // --------------------------------------------------
            try
            {
                int retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>(" SELECT daily_production_hdr_s  FROM koc.daily_production_hdr   WHERE activity_type = 'MEASURED' AND flow_dir_type = 'PRODUCTION' AND material_type = 'OIL'   AND general_port_s = " + gc_inlet_port).FirstOrDefault;
                production_hdr_s = retint;
                LogOutPut.Add("Got PRODUCTION hdr  for Oil");
            }
            catch (Exception ex)
            {
                LogOutPut.Add("No PRODUCTION hdr  for Oil");
                // Erroron = True
                // Exit Sub
            }
            if (GC_ID != "GC27" & GC_ID != "GC28")
            {

                // ------------- PRoduction hdr not light or meduim---------------
                try
                {
                    int retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("SELECT daily_production_hdr_s FROM koc.daily_production_hdr      WHERE activity_type = 'MEASURED' AND flow_dir_type = 'PRODUCTION' AND material_type = 'DRY OIL'  AND general_port_s = " + gc_inlet_port).FirstOrDefault;
                    dry_production_hdr_s = retint;
                    LogOutPut.Add("Got Dry PRODUCTION  hdr for Oil");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No Dry PRODUCTION  hdr for Oil");
                    // Erroron = True
                    // Exit Sub
                }
                try
                {
                    int retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("SELECT daily_production_hdr_s  FROM koc.daily_production_hdr        WHERE activity_type = 'MEASURED' AND flow_dir_type = 'PRODUCTION' AND material_type = 'WET OIL'    AND general_port_s=" + gc_inlet_port).FirstOrDefault;
                    wet_production_hdr_s = retint;
                    LogOutPut.Add("Got wet PRODUCTION  hdr for  Oil");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No wet PRODUCTION   for  Oil");
                    // Erroron = True
                    // Exit Sub
                }
                try
                {
                    int retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>(" SELECT daily_miscellaneous_hdr_s  FROM koc.daily_miscellaneous_hdr   WHERE activity_type = 'MEASURED' AND flow_dir_type = 'PRODUCTION' AND material_type = 'OIL'   AND general_port_s = " + gc_inlet_port).FirstOrDefault;
                    l_api_salt_hdr_s = retint;
                    LogOutPut.Add("Got API Salt hdr for  Oil");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No API Salt hdr for  Oil");
                    // Erroron = True
                    // Exit Sub
                }
            }
            if (GC_ID == "GC27" | GC_ID == "GC28")
            {
                try
                {
                    int retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>(" SELECT daily_production_hdr_s  FROM koc.daily_production_hdr   WHERE activity_type = 'MEASURED' AND flow_dir_type = 'PRODUCTION' AND material_type = 'LIGHT OIL'   AND general_port_s = " + gc_inlet_port).FirstOrDefault;
                    l_production_hdr_s = retint;
                    LogOutPut.Add("Got PRODUCTION hdr  for Light Oil");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No PRODUCTION hdr  for Light Oil");
                    // Erroron = True
                    // Exit Sub
                }
                try
                {
                    int retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>(" SELECT daily_production_hdr_s  FROM koc.daily_production_hdr   WHERE activity_type = 'MEASURED' AND flow_dir_type = 'PRODUCTION' AND material_type = 'MEDIUM OIL'   AND general_port_s = " + gc_inlet_port).FirstOrDefault;
                    m_production_hdr_s = retint;
                    LogOutPut.Add("Got PRODUCTION hdr  for Medium Oil");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No PRODUCTION hdr  for Medium Oil");
                    // Erroron = True
                    // Exit Sub
                }
                // -------------- 
                // -------------Dry ---------------
                try
                {
                    int retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>(" SELECT daily_production_hdr_s  FROM koc.daily_production_hdr   WHERE activity_type = 'MEASURED' AND flow_dir_type = 'PRODUCTION' AND material_type = 'LIGHT DRY OIL'   AND general_port_s = " + gc_inlet_port).FirstOrDefault;
                    l_dry_production_hdr_s = retint;
                    LogOutPut.Add("Got Dry PRODUCTION  hdr for Oil");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No Dry PRODUCTION  hdr for Oil");
                    // Erroron = True
                    // Exit Sub
                }
                try
                {
                    int retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>(" SELECT daily_production_hdr_s  FROM koc.daily_production_hdr   WHERE activity_type = 'MEASURED' AND flow_dir_type = 'PRODUCTION' AND material_type = 'MEDIUM DRY OIL'   AND general_port_s = " + gc_inlet_port).FirstOrDefault;
                    m_dry_production_hdr_s = retint;
                    LogOutPut.Add("Got Dry PRODUCTION  hdr for Light Oil");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No Dry PRODUCTION   for Light Oil");
                    // Erroron = True
                    // Exit Sub
                }
                // ----------------------

                // ----------  Wet 
                try
                {
                    int retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>(" SELECT daily_production_hdr_s  FROM koc.daily_production_hdr   WHERE activity_type = 'MEASURED' AND flow_dir_type = 'PRODUCTION' AND material_type = 'LIGHT WET OIL'   AND general_port_s = " + gc_inlet_port).FirstOrDefault;
                    l_wet_production_hdr_s = retint;
                    LogOutPut.Add("Got Wet PRODUCTION  hdr for Medium Oil");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No Wet PRODUCTION hdr  for Medium Oil");
                    // Erroron = True
                    // Exit Sub
                }
                try
                {
                    int retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>(" SELECT daily_production_hdr_s  FROM koc.daily_production_hdr   WHERE activity_type = 'MEASURED' AND flow_dir_type = 'PRODUCTION' AND material_type = 'MEDIUM WET OIL'   AND general_port_s = " + gc_inlet_port).FirstOrDefault;
                    m_wet_production_hdr_s = retint;
                    LogOutPut.Add("Got Wet PRODUCTION  hdr for Medium Oil");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No Wet PRODUCTION  hdr for Medium Oil");
                    // Erroron = True
                    // Exit Sub
                }
                try
                {
                    int retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>(" SELECT daily_miscellaneous_hdr_s  FROM koc.daily_miscellaneous_hdr   WHERE activity_type = 'MEASURED' AND flow_dir_type = 'PRODUCTION' AND material_type = 'LIGHT OIL'   AND general_port_s = " + gc_inlet_port).FirstOrDefault;
                    l_api_salt_hdr_s = retint;
                    LogOutPut.Add("Got API Salt hdr for light Oil");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No API Salt hdr for light Oil");
                    // Erroron = True
                    // Exit Sub
                }
                try
                {
                    int retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>(" SELECT daily_miscellaneous_hdr_s  FROM koc.daily_miscellaneous_hdr   WHERE activity_type = 'MEASURED' AND flow_dir_type = 'PRODUCTION' AND material_type = 'MEDIUM OIL'   AND general_port_s = " + gc_inlet_port).FirstOrDefault;
                    m_api_salt_hdr_s = retint;
                    LogOutPut.Add("Got API Salt hdr for Medium Oil");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No API Salt hdr for Medium Oil");
                    // Erroron = True
                    // Exit Sub
                }
            }

            // ----------  API Salt 



            if (GC_ID == "GC15" | GC_ID == "GC23" | GC_ID == "GC25" | GC_ID == "EPF-120")
            {
                if (GC_ID == "EPF-120")
                {
                    try
                    {
                        int retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("SELECT daily_production_hdr_s  FROM koc.daily_production_hdr   WHERE general_port_s in (SELECT general_port_s from koc.general_port where facility_type = 'INLET_PORT' and surface_facility_s in  (select part_surface_facility_s from koc.facility_composition where  whole_surface_facility_s =" + gc_sf_s + " and surface_facility_s in (select surface_facility_s from  koc.surface_facility where facility_type = 'FLOWLINE_PORT')  and facility_id like '%SA%') and material_type = 'OIL' and activity_type = 'MEASURED'  and flow_dir_type = 'PRODUCTION')").FirstOrDefault;
                        SA_oil_s = retint;
                        LogOutPut.Add("Got production hdr for SA Oil");
                    }
                    catch (Exception ex)
                    {
                        LogOutPut.Add("No production hdr for SA Oil");
                        // Erroron = True
                        // Exit Sub
                    }
                    try
                    {
                        int retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("SELECT daily_production_hdr_s  FROM koc.daily_production_hdr   WHERE general_port_s in (SELECT general_port_s from koc.general_port where facility_type = 'INLET_PORT' and surface_facility_s in  (select part_surface_facility_s from koc.facility_composition where  whole_surface_facility_s =" + gc_sf_s + " and surface_facility_s in (select surface_facility_s from  koc.surface_facility where facility_type = 'FLOWLINE_PORT')  and facility_id like '%SA%') and material_type = 'WATER' and activity_type = 'MEASURED'  and flow_dir_type = 'PRODUCTION')").FirstOrDefault;
                        SA_water_s = retint;
                        LogOutPut.Add("Got production hdr for SA WATER");
                    }
                    catch (Exception ex)
                    {
                        LogOutPut.Add("No production hdr for SA WATER");
                        // Erroron = True
                        // Exit Sub
                    }
                    try
                    {
                        int retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("SELECT daily_production_hdr_s  FROM koc.daily_production_hdr   WHERE general_port_s in (SELECT general_port_s from koc.general_port where facility_type = 'INLET_PORT' and surface_facility_s in  (select part_surface_facility_s from koc.facility_composition where  whole_surface_facility_s =" + gc_sf_s + " and surface_facility_s in (select surface_facility_s from  koc.surface_facility where facility_type = 'FLOWLINE_PORT')  and facility_id like '%RA%') and material_type = 'OIL' and activity_type = 'MEASURED'  and flow_dir_type = 'PRODUCTION')").FirstOrDefault;
                        RA_oil_s = retint;
                        LogOutPut.Add("Got production hdr for RA OIL");
                    }
                    catch (Exception ex)
                    {
                        LogOutPut.Add("No production hdr for RA OIL");
                        // Erroron = True
                        // Exit Sub
                    }
                    try
                    {
                        int retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("SELECT daily_production_hdr_s  FROM koc.daily_production_hdr   WHERE general_port_s in (SELECT general_port_s from koc.general_port where facility_type = 'INLET_PORT' and surface_facility_s in  (select part_surface_facility_s from koc.facility_composition where  whole_surface_facility_s =" + gc_sf_s + " and surface_facility_s in (select surface_facility_s from  koc.surface_facility where facility_type = 'FLOWLINE_PORT')  and facility_id like '%RA%') and material_type = 'WATER' and activity_type = 'MEASURED'  and flow_dir_type = 'PRODUCTION')").FirstOrDefault;
                        RA_water_s = retint;
                        LogOutPut.Add("Got production hdr for RA WATER");
                    }
                    catch (Exception ex)
                    {
                        LogOutPut.Add("No production hdr for RA WATER");
                        // Erroron = True
                        // Exit Sub
                    }
                }
                try
                {
                    int retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("SELECT daily_production_hdr_s  FROM koc.daily_production_hdr   WHERE general_port_s in (SELECT general_port_s from koc.general_port where facility_type = 'INLET_PORT' and surface_facility_s in  (select part_surface_facility_s from koc.facility_composition where  whole_surface_facility_s =" + gc_sf_s + " and surface_facility_s in (select surface_facility_s from  koc.surface_facility where facility_type = 'FLOWLINE_PORT')  and facility_id like '%RQ%') and material_type = 'OIL' and activity_type = 'MEASURED'  and flow_dir_type = 'PRODUCTION')").FirstOrDefault;
                    RQ_oil_s = retint;
                    LogOutPut.Add("Got production hdr for RQ OIL");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No production hdr for RQ OIL");
                    // Erroron = True
                    // Exit Sub
                }
                try
                {
                    int retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("SELECT daily_production_hdr_s  FROM koc.daily_production_hdr   WHERE general_port_s in (SELECT general_port_s from koc.general_port where facility_type = 'INLET_PORT' and surface_facility_s in  (select part_surface_facility_s from koc.facility_composition where  whole_surface_facility_s =" + gc_sf_s + " and surface_facility_s in (select surface_facility_s from  koc.surface_facility where facility_type = 'FLOWLINE_PORT')  and facility_id like '%RQ%') and material_type = 'WATER' and activity_type = 'MEASURED'  and flow_dir_type = 'PRODUCTION')").FirstOrDefault;
                    RQ_water_s = retint;
                    LogOutPut.Add("Got production hdr for RQ Water");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No production hdr for RQ Water");
                    // Erroron = True
                    // Exit Sub
                }
                try
                {
                    int retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("SELECT daily_production_hdr_s  FROM koc.daily_production_hdr   WHERE general_port_s in (SELECT general_port_s from koc.general_port where facility_type = 'INLET_PORT' and surface_facility_s in  (select part_surface_facility_s from koc.facility_composition where  whole_surface_facility_s =" + gc_sf_s + " and surface_facility_s in (select surface_facility_s from  koc.surface_facility where facility_type = 'FLOWLINE_PORT')  and facility_id like '%AD%') and material_type = 'OIL' and activity_type = 'MEASURED'  and flow_dir_type = 'PRODUCTION')").FirstOrDefault;
                    AD_oil_s = retint;
                    LogOutPut.Add("Got production hdr for AD OIL");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No production hdr for AD OIL");
                    // Erroron = True
                    // Exit Sub
                }
                try
                {
                    int retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("SELECT daily_production_hdr_s  FROM koc.daily_production_hdr   WHERE general_port_s in (SELECT general_port_s from koc.general_port where facility_type = 'INLET_PORT' and surface_facility_s in  (select part_surface_facility_s from koc.facility_composition where  whole_surface_facility_s =" + gc_sf_s + " and surface_facility_s in (select surface_facility_s from  koc.surface_facility where facility_type = 'FLOWLINE_PORT')  and facility_id like '%AD%') and material_type = 'WATER' and activity_type = 'MEASURED'  and flow_dir_type = 'PRODUCTION')").FirstOrDefault;
                    AD_water_s = retint;
                    LogOutPut.Add("Got production hdr for AD Water");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No production hdr for AD Water");
                    // Erroron = True
                    // Exit Sub
                }


            }

            if (GC_ID == "GC15")
            {
                try
                {
                    int retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("SELECT daily_production_hdr_s  FROM koc.daily_production_hdr     WHERE general_port_s in (SELECT general_port_s from koc.general_port where facility_type = 'OUTLET_PORT' and surface_facility_s in   (select part_surface_facility_s from koc.facility_composition where   whole_surface_facility_s = " + gc_sf_s + " and surface_facility_s in (select surface_facility_s from koc.surface_facility where facility_type = 'TRANSIT_LINE') and facility_id like '%TL_1%') and material_type = 'OIL' and activity_type = 'MEASURED' and flow_dir_type = 'PRODUCTION')").FirstOrDefault;
                    tl1_s = retint;
                    LogOutPut.Add("Got production hdr for TL 1");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No production hdr for TL 1");
                    // Erroron = True
                    // Exit Sub
                }
                try
                {
                    int retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("SELECT daily_production_hdr_s  FROM koc.daily_production_hdr     WHERE general_port_s in (SELECT general_port_s from koc.general_port where facility_type = 'OUTLET_PORT' and surface_facility_s in   (select part_surface_facility_s from koc.facility_composition where   whole_surface_facility_s = " + gc_sf_s + " and surface_facility_s in (select surface_facility_s from koc.surface_facility where facility_type = 'TRANSIT_LINE') and facility_id like '%TL_2%') and material_type = 'OIL' and activity_type = 'MEASURED' and flow_dir_type = 'PRODUCTION')").FirstOrDefault;
                    tl2_s = retint;
                    LogOutPut.Add("Got production hdr for TL 2");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No production hdr for TL 2");
                    // Erroron = True
                    // Exit Sub
                }
                try
                {
                    int retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("SELECT daily_production_hdr_s  FROM koc.daily_production_hdr     WHERE general_port_s in (SELECT general_port_s from koc.general_port where facility_type = 'OUTLET_PORT' and surface_facility_s in   (select part_surface_facility_s from koc.facility_composition where   whole_surface_facility_s = " + gc_sf_s + " and surface_facility_s in (select surface_facility_s from koc.surface_facility where facility_type = 'TRANSIT_LINE') and facility_id like '%TL_3%') and material_type = 'OIL' and activity_type = 'MEASURED' and flow_dir_type = 'PRODUCTION')").FirstOrDefault;
                    tl3_s = retint;
                    LogOutPut.Add("Got production hdr for TL 3");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No production hdr for TL 3");
                    // Erroron = True
                    // Exit Sub
                }
                try
                {
                    int retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("SELECT daily_production_hdr_s  FROM koc.daily_production_hdr     WHERE general_port_s in (SELECT general_port_s from koc.general_port where facility_type = 'OUTLET_PORT' and surface_facility_s in   (select part_surface_facility_s from koc.facility_composition where   whole_surface_facility_s = " + gc_sf_s + " and surface_facility_s in (select surface_facility_s from koc.surface_facility where facility_type = 'TRANSIT_LINE') and facility_id like '%TL_SUBBIA%') and material_type = 'OIL' and activity_type = 'MEASURED' and flow_dir_type = 'PRODUCTION')").FirstOrDefault;
                    tl_subbia_s = retint;
                    LogOutPut.Add("Got production hdr for TL_SUBBIA");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No production hdr for TL_SUBBIA");
                    // Erroron = True
                    // Exit Sub
                }

            }

        }
        private void Get_finder_GasFlow_hdr()
        {
            // --------------------------------------------------
            // ----------------		GAS FLOW HEADERS		----------
            // --------------------------------------------------
            try
            {
                int retint = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>(" SELECT hdr.daily_miscellaneous_hdr_s FROM koc.daily_miscellaneous_hdr hdr   WHERE  hdr.material_type = 'GAS' and hdr.general_port_s = " + gc_outlet_port).FirstOrDefault;
                gas_flow_hdr_s = retint;
                LogOutPut.Add("Got gas flow hdr gc");
            }
            catch (Exception ex)
            {
                LogOutPut.Add("No gas flow hdr gc");
                // Erroron = True
                // Exit Sub
            }


        }
        public void Get_Finder_Hdr_ID()
        {
            try
            {
                GCclsspecs gcdr = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<GCclsspecs>("  select facility_id , surface_facility_s from koc.surface_facility where facility_type = 'GATHERING CENTER'  and facility_id ='" + GC_ID + "'").FirstOrDefault;
                if (gcdr is not null)
                {
                    GC_ID = gcdr.facility_id;
                    gc_sf_s = gcdr.surface_facility_s;
                }
                txt_date = st_date.Day + "/" + st_date.Month + "/" + st_date.Year;
                ID = GetSeq();

                hdr = new NIGHT_FIGURES_HDR();
                hdr.ID = ID;
                hdr.GC_ID = GC_ID;
                hdr.ISSUE_DATE = st_date;
                hdr.GC_ID = GC_ID;
                hdr.ID = ID;

                hdr.ROW_CREATE_DATE = ROW_CREATE_DATE;
                hdr.ROW_CREATED_BY = ROW_CREATED_BY;
                hdr.ROW_UPDATE_BY = ROW_UPDATE_BY;
                hdr.ROW_UPDATE_DATE = ROW_UPDATE_DATE;
                // SimpleODMConfig.DhubContext.NIGHT_FIGURES_HDR.AddObject(hdr)
                try
                {
                    Get_Finder_Ports();

                    LogOutPut.Add("Got Ports");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No Ports");
                }
                try
                {
                    Get_Finder_Dispatch_Hdr();

                    LogOutPut.Add("Got Despatch HDR Keys");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No Despatch HDR Keys");
                }

                try
                {
                    Get_Finder_Stock_Hdr();

                    LogOutPut.Add("Got Stock HDR Keys");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No Stock HDR Keys");
                }

                try
                {
                    Get_Finder_Prod_Hdr();

                    LogOutPut.Add("Got Production  HDR Keys");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No Production  HDR Keys");
                }
                try
                {

                    Get_finder_GasFlow_hdr();
                    LogOutPut.Add("Got GAS Flow HDR Keys");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No GAS Flow HDR Keys");
                }
                try
                {
                    GetTanks();

                    LogOutPut.Add("Got Tanks");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No Tanks");
                }

                try
                {
                    GetPumps();

                    LogOutPut.Add("Got Pumps");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No Pumps");
                }

                try
                {
                    GetDdpTrains();

                    LogOutPut.Add("Got DDP Trains");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No No DDP Trains");
                }

                try
                {
                    GetTurbines();
                    GetCRU();
                    LogOutPut.Add("Got Turbines");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No Turbines");
                }
                try
                {

                    GetCRU();
                    LogOutPut.Add("Got CRU");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No CRU");
                }

                // hdr.night_FIGURES_CRU.Clear()
                // ------------------------------------------------------
                // --------		EFFLUENT WATER		----------
                // ------------------------------------------------------
                try
                {
                    eff_water_hdr_s = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("SELECT daily_production_hdr_s  FROM koc.daily_production_hdr  WHERE activity_type = 'MEASURED' AND flow_dir_type = 'INJECTION' AND material_type = 'WATER'  AND general_port_s = " + gc_outlet_port).FirstOrDefault;
                    LogOutPut.Add("Got eff_water_hdr_s");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No eff_water_hdr_s");
                }
                // ------------------------------------------------------
                // --------		Eff. water for EWDP1		----------
                // ------------------------------------------------------
                // -- ====== effluent water for EWDP-1 - East Kuwait
                if (GC_ID == "GC09" | GC_ID == "GC10" | GC_ID == "GC20" | GC_ID == "GC19" | GC_ID == "GC22")
                {
                    try
                    {
                        EWDP1_HDR_S = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("Select daily_production_hdr_s  FROM koc.daily_production_hdr   where activity_type = 'MEASURED' AND flow_dir_type = 'DISPOSAL' AND material_type = 'WATER' 	and oil_field_operation_s in (select  oil_field_operation_s  from koc.oil_field_operation  where activity_type='WATER_DISPOSAL' and surface_facility_s = " + gc_sf_s + "	 and activity_id = 'Effluent Water into EWDP-1') and general_port_s in (select gp.general_port_s FROM koc.general_port gp, surface_facility sf  where sf.surface_facility_s = gp.surface_facility_s and sf.facility_id = 'EWDP-1' and sf.facility_type = 'WATER_INJECTION_PLANT' and gp.facility_type = 'OUTLET_PORT')").FirstOrDefault;
                        LogOutPut.Add("Got EWDP1_HDR_S");
                    }
                    catch (Exception ex)
                    {
                        LogOutPut.Add("No EWDP1_HDR_S");
                    }
                }
                // -- ====== effluent water for EWDP-2 - South Kuwait	
                if (GC_ID == "GC01" | GC_ID == "GC02" | GC_ID == "GC11" | GC_ID == "GC03" | GC_ID == "GC06" | GC_ID == "GC08" | GC_ID == "GC04" | GC_ID == "GC07" | GC_ID == "GC21")
                {
                    try
                    {
                        EWDP1_HDR_S = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>(" Select daily_production_hdr_s FROM koc.daily_production_hdr where activity_type = 'MEASURED' AND flow_dir_type = 'DISPOSAL' AND material_type = 'WATER' and oil_field_operation_s in (select oil_field_operation_s from koc.oil_field_operation where activity_type='WATER_DISPOSAL' and surface_facility_s =" + gc_sf_s + " and activity_id = 'Effluent Water into EWDP-2') and general_port_s in (select gp.general_port_s FROM koc.general_port gp, surface_facility sf where sf.surface_facility_s = gp.surface_facility_s and sf.facility_id = 'EWDP-2' and sf.facility_type = 'WATER_INJECTION_PLANT' and gp.facility_type = 'OUTLET_PORT')").FirstOrDefault;
                        LogOutPut.Add("Got EWDP1_HDR_S");
                    }
                    catch (Exception ex)
                    {
                        LogOutPut.Add("No EWDP1_HDR_S");
                    }
                }
                // --- ============= for MNWIP .... West Kuwait
                if (GC_ID == "GC16" | GC_ID == "GC17" | GC_ID == "GC27" | GC_ID == "GC28")
                {
                    try
                    {
                        EWDP1_HDR_S = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("Select daily_production_hdr_s FROM koc.daily_production_hdr where activity_type = 'MEASURED' AND flow_dir_type = 'DISPOSAL' AND material_type = 'WATER' and oil_field_operation_s in (select  oil_field_operation_s  from KOC.oil_field_operation where activity_type='WATER_DISPOSAL' and surface_facility_s = " + gc_sf_s + " and activity_id = 'Water Sent to MNWIP') and general_port_s in (select gp.general_port_s FROM koc.general_port gp, koc.surface_facility sf where sf.surface_facility_s = gp.surface_facility_s and  sf.facility_id = 'MNWIP' and sf.facility_type = 'WATER_INJECTION_PLANT' and gp.facility_type = 'OUTLET_PORT')").FirstOrDefault;
                        LogOutPut.Add("Got EWDP1_HDR_S");
                    }
                    catch (Exception ex)
                    {
                        LogOutPut.Add("No EWDP1_HDR_S");
                    }
                }
                // --------		EFFLUENT WATER - DESPATCH_PUMP		----------
                // ------------------------------------------------------
                GetWaterPumps();
                // ----------
                // -------- Tank Effluent Water  -- Yassine, 25-Aug-09
                try
                {
                    EFF_WATER_TANK_HDR_S = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("Select daily_production_hdr_s from koc.daily_production_hdr where activity_type = 'MEASURED' and   material_type = 'EFFLUENT_WATER' and   flow_dir_type = 'STOCK' 	and   general_port_s in ( select general_port_s  from koc.general_port t WHERE facility_type = 'STOCK_PORT'  and t.facility_id = 'EFFLUENT_WATER_TANK_' || substr('" + GC_ID + "',3,2))").FirstOrDefault;
                    LogOutPut.Add("Got EFF_WATER_TANK_HDR_S");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No EFF_WATER_TANK_HDR_S");
                    EFF_WATER_TANK_HDR_S = Conversions.ToInteger("");
                }
                // -- == Send Eff Water to Other GC
                try
                {
                    EFF_WATER_OUT_HDR_S = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("Select daily_production_hdr_s from koc.daily_production_hdr where activity_type = 'MEASURED' and   material_type = 'EFFLUENT_WATER' and   flow_dir_type = 'OUT_STOCK' 	and   general_port_s in ( select general_port_s  from koc.general_port t WHERE facility_type = 'STOCK_PORT'  and t.facility_id = 'EFFLUENT_WATER_TANK_' || substr('" + GC_ID + "',3,2))").FirstOrDefault;
                    LogOutPut.Add("Got EFF_WATER_OUT_HDR_S");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No EFF_WATER_OUT_HDR_S");
                    EFF_WATER_OUT_HDR_S = Conversions.ToInteger("");
                }
                // -- == Get Eff Water to Other GC
                try
                {
                    EFF_WATER_OUT_HDR_S = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("Select daily_production_hdr_s from koc.daily_production_hdr where activity_type = 'MEASURED' and   material_type = 'EFFLUENT_WATER' and   flow_dir_type = 'IN_STOCK' 	and   general_port_s in ( select general_port_s  from koc.general_port t WHERE facility_type = 'STOCK_PORT'  and t.facility_id = 'EFFLUENT_WATER_TANK_' || substr('" + GC_ID + "',3,2))").FirstOrDefault;
                    LogOutPut.Add("Got EFF_WATER_IN_HDR_S");
                }
                catch (Exception ex)
                {
                    LogOutPut.Add("No EFF_WATER_IN_HDR_S");
                    EFF_WATER_OUT_HDR_S = Conversions.ToInteger("");
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Could not Find GC");
                return;
            }
        }
        public void GetExistingFromFinder()
        {
            try
            {
                Get_Finder_Hdr_ID();
            }
            catch (Exception ex)
            {

            }
            try
            {
                Get_Finder_Data();
            }
            catch (Exception ex)
            {
            }

        }
        public bool GetExistingFromStaging(string PGC_ID = "", DateTime pDate = default)
        {
            if (string.IsNullOrEmpty(PGC_ID) == false)
            {
                GC_ID = PGC_ID;
            }
            if (pDate != default)
            {
                ISSUE_DATE = pDate;
                st_date = pDate;
            }
            var ExistingData = (from x in SimpleODMConfig.DhubContext.NIGHT_FIGURES_HDR
                                where x.GC_ID == GC_ID & x.ISSUE_DATE.Value == ISSUE_DATE
                                select x).FirstOrDefault;
            if (ExistingData is not null)
            {
                hdr = ExistingData;
                return true;
            }
            else
            {
                return false;
            }
        }
        public void GetData(string PGC_ID = "", DateTime pDate = default)
        {
            if (string.IsNullOrEmpty(PGC_ID) == false)
            {
                GC_ID = PGC_ID;
            }
            if (pDate != default)
            {
                ISSUE_DATE = pDate;
                st_date = pDate;
            }

            if (GetExistingFromStaging(PGC_ID, pDate))
            {
            }
            else
            {
                GetExistingFromFinder();
            }

        }
        #endregion
        #endregion
        #region Local Improd Staging Tables
        public void SaveNightFigureToDatabase()
        {
            try
            {
                SimpleODMConfig.DhubContext.NIGHT_FIGURES_HDR.AddObject(hdr);
                SimpleODMConfig.DhubContext.SaveChanges();
                Interaction.MsgBox("Saved");
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Error : " + ex.Message);
            }
        }
        public NIGHT_FIGURES_HDR GetNightFigureHDR()
        {
            return hdr;
        }
        // Private Sub CreateNewNightFigureHDRForSaving()
        // hdr.GC_ID = GC_ID
        // hdr.ID = Me.ID
        // hdr.ISSUE_DATE = Me.ISSUE_DATE
        // hdr.ROW_CREATE_DATE = Me.ROW_CREATE_DATE
        // hdr.ROW_CREATED_BY = Me.ROW_CREATED_BY
        // hdr.ROW_UPDATE_BY = Me.ROW_UPDATE_BY
        // hdr.ROW_UPDATE_DATE = Me.ROW_UPDATE_DATE

        // 'Dim x As List(Of NIGHT_FIGURES_TANKS) = NIGHT_FIGURES_TANKS
        // 'For Each t1 In x
        // '    hdr.NIGHT_FIGURES_TANKS.Add(t1)
        // 'Next
        // 'Dim x1 As List(Of NIGHT_FIGURE_DDP) = NIGHT_FIGURE_DDP.ToList()
        // 'For Each t2 In x1
        // '    hdr.NIGHT_FIGURE_DDP.Add(t2)
        // 'Next
        // 'Dim x2 As List(Of NIGHT_FIGURE_DDP_HEATERS) = NIGHT_FIGURE_DDP_HEATERS.ToList()
        // 'For Each t3 In x2
        // '    hdr.NIGHT_FIGURE_DDP_HEATERS.Add(t3)
        // 'Next
        // 'Dim x3 As List(Of NIGHT_FIGURES_PUMPS) = NIGHT_FIGURES_PUMPS.ToList()
        // 'For Each t4 In x3
        // '    hdr.NIGHT_FIGURES_PUMPS.Add(t4)
        // 'Next
        // 'Dim x4 As List(Of NIGHT_FIGURE_EFFLUENT_WATER) = NIGHT_FIGURE_EFFLUENT_WATER.ToList()
        // 'For Each t5 In x4
        // '    hdr.NIGHT_FIGURE_EFFLUENT_WATER.Add(t5)
        // 'Next
        // 'Dim x5 As List(Of NIGHT_FIGURE_REMARKS) = NIGHT_FIGURE_REMARKS.ToList()
        // 'For Each t6 In x5
        // '    hdr.NIGHT_FIGURE_REMARKS.Add(t6)
        // 'Next
        // 'Dim x6 As List(Of NIGHT_FIGURE_TURBINES) = NIGHT_FIGURE_TURBINES.ToList()
        // 'For Each t7 In x6
        // '    hdr.NIGHT_FIGURE_TURBINES.Add(t7)
        // 'Next
        // 'Dim x7 As List(Of NIGHT_FIGURES_CRU) = NIGHT_FIGURES_CRU.ToList()
        // 'For Each t8 In x7
        // '    hdr.NIGHT_FIGURES_CRU.Add(t8)
        // 'Next
        // 'Dim x8 As List(Of NIGHT_FIGURES_DDP_MISC) = NIGHT_FIGURES_DDP_MISC.ToList()
        // 'For Each t9 In x8
        // '    hdr.NIGHT_FIGURES_DDP_MISC.Add(t9)
        // 'Next
        // 'Dim x9 As List(Of NIGHT_FIGURES_DDP_TRAIN) = NIGHT_FIGURES_DDP_TRAIN.ToList()
        // 'For Each t10 In x9
        // '    hdr.NIGHT_FIGURES_DDP_TRAIN.Add(t10)
        // 'Next
        // 'Dim x10 As List(Of NIGHT_FIGURES_EWDP_HDR) = NIGHT_FIGURES_EWDP_HDR.ToList()
        // 'For Each t11 In x10
        // '    hdr.NIGHT_FIGURES_EWDP_HDR.Add(t11)
        // 'Next
        // 'Dim x11 As List(Of NIGHT_FIGURES_EWDP_PUMPS) = NIGHT_FIGURES_EWDP_PUMPS.ToList()
        // 'For Each t12 In x11
        // '    hdr.NIGHT_FIGURES_EWDP_PUMPS.Add(t12)
        // 'Next
        // 'Dim x12 As List(Of NIGHT_FIGURES_PROD_STOCK) = NIGHT_FIGURES_PROD_STOCK.ToList()
        // 'For Each t13 In x12
        // '    hdr.NIGHT_FIGURES_PROD_STOCK.Add(t13)
        // 'Next
        // 'Dim x13 As List(Of NIGHT_FIGURES_STOCK_CHANGE) = NIGHT_FIGURES_STOCK_CHANGE.ToList()
        // 'For Each t14 In x13
        // '    hdr.NIGHT_FIGURES_STOCK_CHANGE.Add(t14)
        // 'Next



        // End Sub
        #endregion
        #region Init Records and Set Sequencer
        private NIGHT_FIGURES_HDR BaseToDerived(NIGHT_FIGURES_HDR source, NIGHT_FIGURES_HDR target)
        {
            var sourceproperties = TypeDescriptor.GetProperties(new NIGHT_FIGURES_HDR());
            var targetproperties = TypeDescriptor.GetProperties(new NIGHT_FIGURES_HDR());
            foreach (PropertyDescriptor pd in targetproperties)
            {
                foreach (PropertyDescriptor _pd in sourceproperties)
                {
                    if ((pd.Name ?? "") == (_pd.Name ?? "")) // And (pd.Name.Contains("NIGHT_FIGURE") = False) 
                    {
                        pd.SetValue(target, _pd.GetValue(source));
                    }
                }
            }

            return target;
        }

        public cls_Night_Figure()
        {
            hdr = new DhubEntities.NIGHT_FIGURES_HDR();
        }
        private int GetSeq()
        {
            var Seq1 = default(int);
            try
            {
                Seq1 = SimpleODMConfig.DhubContext.ExecuteStoreQuery<int>("SELECT NIGHT_FIGURES_HDR_ID_SEQ.nextval from dual ").FirstOrDefault;
            }
            catch (Exception ex)
            {

            }
            return Seq1;
        }
        private int GetFinderSeq()
        {
            var Seq1 = default(int);
            try
            {
                Seq1 = SimpleODMConfig.FinderModelEntities.KocContext.ExecuteStoreQuery<int>("SELECT esi.production_db_seq.nextval from dual ").FirstOrDefault;
            }
            catch (Exception ex)
            {

            }
            return Seq1;
        }
        // esi.production_db_seq.nextval
        #endregion

    }
}