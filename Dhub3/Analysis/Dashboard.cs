using KOC.DHUB3.DataServices;
using KOC.DHUB3.Models;
using KOC.DHUB3.Well.Analysis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TheTechIdea.Beep;
using static System.Math;


namespace KOC.DHUB3.Analysis
{

    public class Dashboard
    {
        IDMEEditor DMEditor { get; set; }
        public Dashboard(IDMEEditor pDMEditor,  Cls_FinderDataList pKocFieldData)
        {
            DMEditor = pDMEditor;
            KocFieldData = pKocFieldData;

        }
        public Cls_FinderDataList KocFieldData { get; set; }

        public string FieldID { get; set; } = "";
        public string GCID { get; set; } = "";
        public string PPDMUWI { get; set; } = "";
        public string myUWI { get; set; } = "";
        public int WCS { get; set; } = 0;
        public string Wells { get; set; } = "";
        public string pStart_date { get; set; } = "";
        public string pEnd_date { get; set; } = "";
        public string Area { get; set; } = "";
        private int maxv;
        private int minv;
        public List<cls_Dashboard_data> DashBoard_data { get; set; } = new List<cls_Dashboard_data>();
        DCA DCA_GEN = new DCA();
        object IIf(bool expression, object truePart, object falsePart)
        { return expression ? truePart : falsePart; }
        public void GetDashboard(string pArea, string pAreaType)
        {
            cls_Dashboard_data pdash;
            switch (pAreaType ?? "")
            {
                case "AREA":
                    {
                        pdash = DashBoard_data.Where(x => (x.Area ?? "") == (pArea ?? "") & x.DashType == "AREA").FirstOrDefault();
                        GetAreaDashboard(pdash, pArea, pAreaType);
                        try
                        {
                            GetDCA_MaxMinForArea(pdash, pArea);
                        }
                        catch (Exception ex)
                        {

                        }

                        break;
                    }
                case "FIELD":
                    {
                        pdash = DashBoard_data.Where(x => (x.FieldID ?? "") == (pArea ?? "") & x.DashType == "FIELD").FirstOrDefault();
                        GetFieldDashboard(pdash, pArea, pAreaType);
                        try
                        {
                            GetDCA_MaxMinForField(pdash, pArea);
                        }
                        catch (Exception ex)
                        {

                        }

                        break;
                    }
                case "GC":
                    {
                        pdash = DashBoard_data.Where(x => (x.GCID ?? "") == (pArea ?? "") & x.DashType == "GC").FirstOrDefault();
                        GetFieldDashboard(pdash, pArea, pAreaType);
                        try
                        {
                        }
                        // GetDCA_MaxMin(pdash, pArea)
                        catch (Exception ex)
                        {

                        }

                        break;
                    }
                case "ALL":
                    {
                        pdash = DashBoard_data.Where(x => (x.Area ?? "") == (pArea ?? "") & x.DashType == "AREA").FirstOrDefault();
                        DashBoard_data.Remove(pdash);
                        pdash = new cls_Dashboard_data();
                        pdash.Area = "ALL";
                        pdash.DashType = "AREA";
                        DashBoard_data.Add(pdash);
                        GetALLDashBoard(pdash);
                        break;
                    }
            }


        }
        private void AddAreaDashBoardDatatoAll(cls_Dashboard_data pdashAll, cls_Dashboard_data pdashArea)
        {
            pdashAll.top10maxWaterwellv.AddRange(pdashArea.top10maxWaterwellv);
            pdashAll.top10maxwellv.AddRange(pdashArea.top10maxwellv);
            pdashAll.top10minWaterwellv.AddRange(pdashArea.top10minWaterwellv);
            pdashAll.top10minwellv.AddRange(pdashArea.top10minwellv);
            pdashAll.TotalNoofESPWells += pdashArea.TotalNoofESPWells;
            pdashAll.TotalNoofGASINJWells += pdashArea.TotalNoofGASINJWells;
            pdashAll.TotalNoofINJWells += pdashArea.TotalNoofINJWells;
            pdashAll.ESPStatusList.AddRange(pdashArea.ESPStatusList);
            pdashAll.ProductionList.Add(new cls_Dashbaord_productionTotalListValues("Oil", 0, System.Drawing.Color.Black));
            pdashAll.ProductionList.Add(new cls_Dashbaord_productionTotalListValues("Water", 0, System.Drawing.Color.Blue));
            pdashAll.ProductionList.Add(new cls_Dashbaord_productionTotalListValues("Gas", 0, System.Drawing.Color.Gray));
            foreach (var p in pdashArea.ProductionList)
            {
                var oil = pdashAll.ProductionList.Where(x => x.TypeName == "Oil").FirstOrDefault();
                var Water = pdashAll.ProductionList.Where(x => x.TypeName == "Water").FirstOrDefault();
                var Gas = pdashAll.ProductionList.Where(x => x.TypeName == "Gas").FirstOrDefault();

                switch (p.TypeName ?? "")
                {
                    case "Oil":
                        {
                            oil.Production += p.Production;
                            break;
                        }
                    case "Water":
                        {
                            Water.Production += p.Production;
                            break;
                        }
                    case "Gas":
                        {
                            Gas.Production += p.Production;
                            break;
                        }

                }

                // pdashAll.ProductionList.Oil += pdashArea.ProductionTotal.Oil
                // pdashAll.ProductionList.Gas += pdashArea.ProductionTotal.Gas
                // pdashAll.ProductionListWater += pdashArea.ProductionTotal.Water

            }
            try
            {
                pdashAll.ProductionTotal.Oil += pdashArea.ProductionTotal.Oil;
                pdashAll.ProductionTotal.Gas += pdashArea.ProductionTotal.Gas;
                pdashAll.ProductionTotal.Water += pdashArea.ProductionTotal.Water;
            }

            catch (Exception ex)
            {

            }
            try
            {

                pdashAll.HighestAPIWell = (cls_Finderwell)IIf(pdashAll.HighestAPIWell.OIL_API > pdashArea.HighestAPIWell.OIL_API, pdashAll.HighestAPIWell, pdashArea.HighestAPIWell);
                pdashAll.LowestAPIWell = (cls_Finderwell)IIf(pdashAll.LowestAPIWell.OIL_API > pdashArea.LowestAPIWell.OIL_API, pdashAll.LowestAPIWell, pdashArea.LowestAPIWell);
                pdashAll.HighestH2SWell = (cls_Finderwell)IIf(pdashAll.HighestH2SWell.H2S > pdashArea.HighestH2SWell.H2S, pdashAll.HighestH2SWell, pdashArea.HighestH2SWell);
                pdashAll.HighestSaltWell = (cls_Finderwell)IIf(pdashAll.HighestSaltWell.SALT > pdashArea.HighestSaltWell.SALT, pdashAll.HighestSaltWell, pdashArea.HighestSaltWell);
                pdashAll.MaxSulferDWell = (cls_Finderwell)IIf(pdashAll.MaxSulferDWell.LATEST_SULFUR > pdashArea.MaxSulferDWell.LATEST_SULFUR, pdashAll.MaxSulferDWell, pdashArea.MaxSulferDWell);
                pdashAll.MaxTVDWell = (cls_Finderwell)IIf(pdashAll.MaxTVDWell.TVD > pdashArea.MaxTVDWell.TVD, pdashAll.MaxTVDWell, pdashArea.MaxTVDWell);
                pdashAll.MinTVDWell = (cls_Finderwell)IIf(pdashAll.MinTVDWell.TVD > pdashArea.MinTVDWell.TVD, pdashAll.MinTVDWell, pdashArea.MinTVDWell);
                pdashAll.maxWaterwellv = (cls_Finderwell)IIf(pdashAll.maxWaterwellv.BWPD > pdashArea.maxWaterwellv.BWPD, pdashAll.maxWaterwellv, pdashArea.maxWaterwellv);
                pdashAll.maxwellv = (cls_Finderwell)IIf(pdashAll.maxwellv.BOPD > pdashArea.maxwellv.BOPD, pdashAll.maxwellv, pdashArea.maxwellv);
                pdashAll.MinTVDWell = (cls_Finderwell)IIf(pdashAll.MinTVDWell.TVD < pdashArea.MinTVDWell.TVD, pdashAll.MinTVDWell, pdashArea.MinTVDWell);
                pdashAll.minWaterwellv = (cls_Finderwell)IIf(pdashAll.minWaterwellv.BWPD < pdashArea.minWaterwellv.BWPD, pdashAll.minWaterwellv, pdashArea.minWaterwellv);
                pdashAll.minwellv = (cls_Finderwell)IIf(pdashAll.minwellv.BOPD < pdashArea.minwellv.BOPD, pdashAll.minwellv, pdashArea.minwellv);
            }
            catch (Exception ex)
            {

            }
            try
            {

                pdashAll.HighestAPIWell = (cls_Finderwell)IIf(pdashAll.HighestAPIWell.OIL_API > pdashArea.HighestAPIWell.OIL_API, pdashAll.HighestAPIWell, pdashArea.HighestAPIWell);
                pdashAll.LowestAPIWell = (cls_Finderwell)IIf(pdashAll.LowestAPIWell.OIL_API > pdashArea.LowestAPIWell.OIL_API, pdashAll.LowestAPIWell, pdashArea.LowestAPIWell);
            }

            catch (Exception ex)
            {

            }
            try
            {
                pdashAll.HighestH2SWell = (cls_Finderwell)IIf(pdashAll.HighestH2SWell.H2S > pdashArea.HighestH2SWell.H2S, pdashAll.HighestH2SWell, pdashArea.HighestH2SWell);
                pdashAll.HighestSaltWell = (cls_Finderwell)IIf(pdashAll.HighestSaltWell.SALT > pdashArea.HighestSaltWell.SALT, pdashAll.HighestSaltWell, pdashArea.HighestSaltWell);
            }

            catch (Exception ex)
            {

            }
            try
            {
                pdashAll.MaxSulferDWell = (cls_Finderwell)IIf(pdashAll.MaxSulferDWell.LATEST_SULFUR > pdashArea.MaxSulferDWell.LATEST_SULFUR, pdashAll.MaxSulferDWell, pdashArea.MaxSulferDWell);
                pdashAll.MaxTVDWell = (cls_Finderwell)IIf(pdashAll.MaxTVDWell.TVD > pdashArea.MaxTVDWell.TVD, pdashAll.MaxTVDWell, pdashArea.MaxTVDWell);
                pdashAll.MinTVDWell = (cls_Finderwell)IIf(pdashAll.MinTVDWell.TVD > pdashArea.MinTVDWell.TVD, pdashAll.MinTVDWell, pdashArea.MinTVDWell);
            }

            catch (Exception ex)
            {

            }
            try
            {
                pdashAll.maxWaterwellv = (cls_Finderwell)IIf(pdashAll.maxWaterwellv.BWPD > pdashArea.maxWaterwellv.BWPD, pdashAll.maxWaterwellv, pdashArea.maxWaterwellv);
                pdashAll.minWaterwellv = (cls_Finderwell)IIf(pdashAll.minWaterwellv.BWPD < pdashArea.minWaterwellv.BWPD, pdashAll.minWaterwellv, pdashArea.minWaterwellv);
                pdashAll.maxwellv = (cls_Finderwell)IIf(pdashAll.maxwellv.BOPD > pdashArea.maxwellv.BOPD, pdashAll.maxwellv, pdashArea.maxwellv);
                pdashAll.minwellv = (cls_Finderwell)IIf(pdashAll.minwellv.BOPD < pdashArea.minwellv.BOPD, pdashAll.minwellv, pdashArea.minwellv);
            }
            catch (Exception ex)
            {

            }
        }
        public void GetDashBoard(cls_Dashboard_data pdash, string pArea, string pAreaType)
        {
            pdash.ESPStatusList.Clear();
            switch (pAreaType ?? "")
            {
                case "AREA":
                    {

                        try
                        {
                            GetTopandBottomTop10Performer(pdash, pArea);
                        }
                        catch (Exception ex)
                        {

                        }
                        try
                        {
                            GetTopandBottomPerformer(pdash, pArea);
                        }
                        catch (Exception ex)
                        {

                        }
                        try
                        {
                            GetTopandBottomWaterProducer(pdash, pArea);
                        }
                        catch (Exception ex)
                        {

                        }

                        try
                        {
                            GetHighestLowestAPIWell(pdash, pArea);
                        }
                        catch (Exception ex)
                        {

                        }

                        try
                        {
                            GetHighestH2SWell(pdash, pArea);
                        }
                        catch (Exception ex)
                        {

                        }
                        // --------------------
                        try
                        {
                            GetTotalESPWells(pdash, pArea);
                        }
                        catch (Exception ex)
                        {

                        }


                        try
                        {
                            GetTotalGasINJWells(pdash, pArea);
                        }
                        catch (Exception ex)
                        {

                        }

                        try
                        {
                            GetTotalINJWells(pdash, pArea);
                        }
                        catch (Exception ex)
                        {

                        }

                        try
                        {
                            GetHighestSaltWell(pdash, pArea);
                        }
                        catch (Exception ex)
                        {

                        }
                        try
                        {

                            GetTotalProductionCapacity(pdash, pArea);
                        }
                        catch (Exception ex)
                        {

                        }
                        try
                        {
                            GetESPStatusList(pdash, pArea);
                        }
                        catch (Exception ex)
                        {

                        }

                        try
                        {
                            GetMaxMinTVDWell(pdash, pArea);
                        }
                        catch (Exception ex)
                        {

                        }
                        try
                        {
                            GetESPStatusHist(pdash, pArea);
                        }
                        catch (Exception ex)
                        {

                        }
                        try
                        {
                            GetProdHist(pdash, pArea);
                        }
                        catch (Exception ex)
                        {

                        }

                        break;
                    }
                case "GC":
                    {
                        try
                        {
                            GetTopandBottomTop10Performer(pdash, pGCID: pArea);
                        }
                        catch (Exception ex)
                        {

                        }
                        try
                        {
                            GetTopandBottomPerformer(pdash, pGCID: pArea);
                        }
                        catch (Exception ex)
                        {

                        }
                        try
                        {
                            GetTopandBottomWaterProducer(pdash, pGCID: pArea);
                        }
                        catch (Exception ex)
                        {

                        }

                        try
                        {
                            GetHighestLowestAPIWell(pdash, pGCID: pArea);
                        }
                        catch (Exception ex)
                        {

                        }

                        try
                        {
                            GetHighestH2SWell(pdash, pGCID: pArea);
                        }
                        catch (Exception ex)
                        {

                        }
                        // --------------------
                        try
                        {
                            GetTotalESPWells(pdash, pGCID: pArea);
                        }
                        catch (Exception ex)
                        {

                        }


                        try
                        {
                            GetTotalGasINJWells(pdash, pGCID: pArea);
                        }
                        catch (Exception ex)
                        {

                        }

                        try
                        {
                            GetTotalINJWells(pdash, pGCID: pArea);
                        }
                        catch (Exception ex)
                        {

                        }

                        try
                        {
                            GetHighestSaltWell(pdash, pGCID: pArea);
                        }
                        catch (Exception ex)
                        {

                        }
                        try
                        {

                            GetTotalProductionCapacity(pdash, pGCID: pArea);
                        }
                        catch (Exception ex)
                        {

                        }
                        try
                        {
                            GetESPStatusList(pdash, pGCID: pArea);
                        }
                        catch (Exception ex)
                        {

                        }

                        try
                        {
                            GetMaxMinTVDWell(pdash, pGCID: pArea);
                        }
                        catch (Exception ex)
                        {

                        }
                        try
                        {
                            GetESPStatusHist(pdash, pGCID: pArea);
                        }
                        catch (Exception ex)
                        {

                        }
                        try
                        {
                            GetProdHist(pdash, pGCID: pArea);
                        }
                        catch (Exception ex)
                        {

                        }

                        break;
                    }
                case "FIELD":
                    {

                        try
                        {
                            GetTopandBottomTop10Performer(pdash, pFieldID: pArea);
                        }
                        catch (Exception ex)
                        {

                        }
                        try
                        {
                            GetTopandBottomPerformer(pdash, pFieldID: pArea);
                        }
                        catch (Exception ex)
                        {

                        }
                        try
                        {
                            GetTopandBottomWaterProducer(pdash, pFieldID: pArea);
                        }
                        catch (Exception ex)
                        {

                        }

                        try
                        {
                            GetHighestLowestAPIWell(pdash, pFieldID: pArea);
                        }
                        catch (Exception ex)
                        {

                        }

                        try
                        {
                            GetHighestH2SWell(pdash, pFieldID: pArea);
                        }
                        catch (Exception ex)
                        {

                        }
                        // --------------------
                        try
                        {
                            GetTotalESPWells(pdash, pFieldID: pArea);
                        }
                        catch (Exception ex)
                        {

                        }


                        try
                        {
                            GetTotalGasINJWells(pdash, pFieldID: pArea);
                        }
                        catch (Exception ex)
                        {

                        }

                        try
                        {
                            GetTotalINJWells(pdash, pFieldID: pArea);
                        }
                        catch (Exception ex)
                        {

                        }

                        try
                        {
                            GetHighestSaltWell(pdash, pFieldID: pArea);
                        }
                        catch (Exception ex)
                        {

                        }
                        try
                        {

                            GetTotalProductionCapacity(pdash, pFieldID: pArea);
                        }
                        catch (Exception ex)
                        {

                        }
                        try
                        {
                            GetESPStatusList(pdash, pFieldID: pArea);
                        }
                        catch (Exception ex)
                        {

                        }

                        try
                        {
                            GetMaxMinTVDWell(pdash, pFieldID: pArea);
                        }
                        catch (Exception ex)
                        {

                        }
                        try
                        {
                            GetESPStatusHist(pdash, pFieldID: pArea);
                        }
                        catch (Exception ex)
                        {

                        }
                        try
                        {
                            GetProdHist(pdash, pFieldID: pArea);
                        }
                        catch (Exception ex)
                        {

                        }

                        break;
                    }
            }


        }
        public void GetALLDashBoard(cls_Dashboard_data pdash)
        {
            var pdash1 = DashBoard_data.Where(x => x.Area == "NK" & x.DashType == "AREA").FirstOrDefault();
            var pdash2 = DashBoard_data.Where(x => x.Area == "WK" & x.DashType == "AREA").FirstOrDefault();
            var pdash3 = DashBoard_data.Where(x => x.Area == "SK" & x.DashType == "AREA").FirstOrDefault();


            AddAreaDashBoardDatatoAll(pdash, pdash1);
            AddAreaDashBoardDatatoAll(pdash, pdash2);
            AddAreaDashBoardDatatoAll(pdash, pdash3);
            try
            {
                GetDCA_MaxMinForArea(pdash, "ALL");
            }
            catch (Exception ex)
            {

            }
            // For Each f In KocFieldData.FieldDataList
            // Dim pfdash As cls_Dashboard_data
            // '   GetFieldDashboard(pfdash, f.Field_Code, "FIELD")
            // ' AddAreaDashBoardDatatoAll(pdash, pfdash)
            // For Each r In f.ReservoirList


            // Next
            // For Each r In f.LayerList


            // Next
            // Next
            // For Each f In KocFieldData.GCListDataList
            // ' GetGCDashboard(pdash, f.GC, "GC")
            // Next

            // For Each f In KocFieldData.Q8ReservoirList
            // '  GetAreaDashboard(pdash, f.Reservoir_ID, "RES")
            // Next
        }
        public void GetFieldDashboard(string pArea)
        {
            cls_Dashboard_data pdash;
            pdash = DashBoard_data.Where(x => (x.FieldID ?? "") == (pArea ?? "") & x.DashType == "FIELD").FirstOrDefault();
            GetDashBoard(pdash, pArea, "FIELD");

        }
        public void GetFieldDashboard(cls_Dashboard_data pdash, string pArea, string pAreaType)
        {
            GetDashBoard(pdash, pArea, pAreaType);

        }
        public void GetAreaDashboard(cls_Dashboard_data pdash, string pArea, string pAreaType)
        {
            GetDashBoard(pdash, pArea, pAreaType);

        }
        public void GetAreaDashboard(string pArea)
        {
            cls_Dashboard_data pdash;
            pdash = DashBoard_data.Where(x => (x.Area ?? "") == (pArea ?? "") & x.DashType == "AREA").FirstOrDefault();
            GetDashBoard(pdash, pArea, "AREA");



        }
        public void GetGCDashboard(string pArea)
        {
            cls_Dashboard_data pdash;
            pdash = DashBoard_data.Where(x => (x.GCID ?? "") == (pArea ?? "") & x.DashType == "GC").FirstOrDefault();
            GetDashBoard(pdash, pArea, "GC");



        }
        public void GetGCDashboard(cls_Dashboard_data pdash, string pArea, string pAreaType)
        {
            GetDashBoard(pdash, pArea, pAreaType);
        }

       
      
        public void InitDashBoard()
        {
            cls_Dashboard_data x;
            cls_Dashboard_data x1;
            cls_Dashboard_data x2;
            x = new cls_Dashboard_data();
            x.Area = "NK";
            x.DashType = "AREA";
            DashBoard_data.Add(x);
            x = new cls_Dashboard_data();
            x.Area = "ALL";
            x.DashType = "AREA";
            DashBoard_data.Add(x);
            x = new cls_Dashboard_data();
            x.Area = "WK";
            x.DashType = "AREA";
            DashBoard_data.Add(x);
            x = new cls_Dashboard_data();
            x.Area = "SK";
            x.DashType = "AREA";
            DashBoard_data.Add(x);

            foreach (var f in KocFieldData.FieldDataList)
            {
                x = new cls_Dashboard_data();
                x.FieldID = f.Field_Code;
                x.DashType = "FIELD";
                x.Area = f.Area;
                DashBoard_data.Add(x);
                foreach (var r in f.ReservoirList)
                {
                    x1 = new cls_Dashboard_data();
                    x1.FieldID = f.Field_Code;
                    x1.Res = r.Reservoir_ID;
                    x1.Area = f.Area;
                    x1.DashType = "FIELDRES";
                    DashBoard_data.Add(x1);

                }
                foreach (var r in f.LayerList)
                {
                    x2 = new cls_Dashboard_data();
                    x2.FieldID = f.Field_Code;
                    x2.Res = r.RESERVOIR_ID;
                    x2.Layer = r.Layer_Name;
                    x2.Area = f.Area;
                    x2.DashType = "FIELDRESLAYER";
                    DashBoard_data.Add(x2);

                }
            }
            foreach (var f in KocFieldData.GCListDataList)
            {
                x = new cls_Dashboard_data();
                x.GCID = f.GC;
                x.DashType = "GC";
                x.Area = f.Area;
                DashBoard_data.Add(x);
            }

            foreach (var f in KocFieldData.Q8ReservoirList)
            {
                x = new cls_Dashboard_data();
                x.Res = f.Reservoir_ID;
                x.DashType = "RES";
                // x.Area = f.Area
                DashBoard_data.Add(x);
            }
        }
        public void GetDCA_AVG(cls_Dashboard_data pdash, string pArea)
        {
            // pdash.DCA_GEN = New DCA

            var maxitems_avg = new List<CasePortableData>();
            var minitems_avg = new List<CasePortableData>();
            maxitems_avg = KocFieldData.GetDCAavgPortableTestDataForArea2YearsAgo(pArea);
            minitems_avg = KocFieldData.GetDCAAvgPortableTestDataForArea(pArea);
            minitems_avg.Add(maxitems_avg.FirstOrDefault());
            DCA_GEN.CreateDeclineForArea(minitems_avg, DateTime.Today, 12);

        }
        public void GetDCA_MaxMinForField(cls_Dashboard_data pdash, string pArea)
        {
            var maxitems = new List<CasePortableData>();
            var minitems = new List<CasePortableData>();
            int wcs;
            string uwi;

            maxitems = KocFieldData.GetDCAMaxPortableTestDataForField2YearsAgo(pArea);
            wcs = maxitems.FirstOrDefault().Well_Completion_s;
            uwi = KocFieldData.MyWellLatestDataList.Where(x => x.WELL_COMPLETION_S == wcs).FirstOrDefault().PPDM_WCS_UWI;
            minitems.Add(KocFieldData.GetDCAFromWellLatestDataPortableTestDataForField(pArea, wcs));

            minitems.Add(maxitems.FirstOrDefault());
            DCA_GEN.CreateDeclineForArea(minitems, DateTime.Today, 12, uwi);
            // ------------------------------------
            // Dim DCA_GEN_AVG As New DCA
            // Dim maxitems_avg As New List(Of AI.CasePortableData)
            // Dim minitems_avg As New List(Of AI.CasePortableData)
            // maxitems_avg = KocFieldData.GetDCAavgPortableTestDataForArea2YearsAgo(pArea)
            // minitems_avg = KocFieldData.GetDCAAvgPortableTestDataForArea(pArea)
            // minitems_avg.Add(maxitems_avg.FirstOrDefault)
            // DCA_GEN_AVG.CreateDeclineForArea(minitems_avg, Today, 12)
            // pdash.DCA_GEN.DeclineCases.FirstOrDefault.DeclineCurve_4Avg = New List(Of AI.Decline_Curve_Points)
            // pdash.DCA_GEN.DeclineCases.FirstOrDefault.DeclineCurve_4Avg.AddRange(DCA_GEN_AVG.DeclineCases.FirstOrDefault.DeclineCurve)
            // For i = 0 To pdash.DCA_GEN.DeclineCases.FirstOrDefault.DeclineCurve.Count - 1
            // Dim d As Decline_Curve_Points = pdash.DCA_GEN.DeclineCases.FirstOrDefault.DeclineCurve(i)
            // Dim r As Decline_Curve_Points = DCA_GEN_AVG.DeclineCases.FirstOrDefault.DeclineCurve(i)
            // d.PointExpRateAVG = Round(r.PointExpRate)
            // d.PointHarmRateAVG = Round(r.PointHarmRate)
            // d.PointHyperRateAVG = Round(r.PointHyperRate)
            // Next
            // -------------------
            // Dim DCA_GEN_MIN As New DCA
            // Dim maxitems_min As New List(Of AI.CasePortableData)
            // Dim minitems_min As New List(Of AI.CasePortableData)
            // maxitems_min = KocFieldData.GetDCAMinPortableTestDataForArea(pArea)
            // minitems_min = KocFieldData.GetDCAFromWellLatestDataPortableTestDataForArea(pArea, maxitems_min.FirstOrDefault.Well_Completion_s)
            // minitems_min.Add(maxitems_min.FirstOrDefault)
            // DCA_GEN_MIN.CreateDeclineForArea(minitems_min, Today, 12)
            // pdash.DCA_GEN.DeclineCases.FirstOrDefault.DeclineCurve_4Min = New List(Of AI.Decline_Curve_Points)
            // pdash.DCA_GEN.DeclineCases.FirstOrDefault.DeclineCurve_4Min.AddRange(DCA_GEN_MIN.DeclineCases.FirstOrDefault.DeclineCurve)
            // For i = 0 To pdash.DCA_GEN.DeclineCases.FirstOrDefault.DeclineCurve.Count - 1
            // Dim d As Decline_Curve_Points = pdash.DCA_GEN.DeclineCases.FirstOrDefault.DeclineCurve(i)
            // Dim r As Decline_Curve_Points = DCA_GEN_MIN.DeclineCases.FirstOrDefault.DeclineCurve(i)
            // d.PointExpRateMin = Round(r.PointExpRate)
            // d.PointHarmRateMin = Round(r.PointHarmRate)
            // d.PointHyperRateMin = Round(r.PointHyperRate)
            // Next
        }
        public void GetDCA_MaxMinForArea(cls_Dashboard_data pdash, string pArea)
        {
            var maxitems = new List<CasePortableData>();
            var minitems = new List<CasePortableData>();
            int wcs;
            string uwi;

            maxitems = KocFieldData.GetDCAMaxPortableTestDataForArea2YearsAgo(pArea);
            wcs = maxitems.FirstOrDefault().Well_Completion_s;
            uwi = KocFieldData.MyWellLatestDataList.Where(x => x.WELL_COMPLETION_S == wcs).FirstOrDefault().PPDM_WCS_UWI;
            minitems.Add(KocFieldData.GetDCAFromWellLatestDataPortableTestDataForArea(pArea, wcs));

            minitems.Add(maxitems.FirstOrDefault());
            DCA_GEN.CreateDeclineForArea(minitems, DateTime.Today, 12, uwi);
            // ------------------------------------
            // Dim DCA_GEN_AVG As New DCA
            // Dim maxitems_avg As New List(Of AI.CasePortableData)
            // Dim minitems_avg As New List(Of AI.CasePortableData)
            // maxitems_avg = KocFieldData.GetDCAavgPortableTestDataForArea2YearsAgo(pArea)
            // minitems_avg = KocFieldData.GetDCAAvgPortableTestDataForArea(pArea)
            // minitems_avg.Add(maxitems_avg.FirstOrDefault)
            // DCA_GEN_AVG.CreateDeclineForArea(minitems_avg, Today, 12)
            // pdash.DCA_GEN.DeclineCases.FirstOrDefault.DeclineCurve_4Avg = New List(Of AI.Decline_Curve_Points)
            // pdash.DCA_GEN.DeclineCases.FirstOrDefault.DeclineCurve_4Avg.AddRange(DCA_GEN_AVG.DeclineCases.FirstOrDefault.DeclineCurve)
            // For i = 0 To pdash.DCA_GEN.DeclineCases.FirstOrDefault.DeclineCurve.Count - 1
            // Dim d As Decline_Curve_Points = pdash.DCA_GEN.DeclineCases.FirstOrDefault.DeclineCurve(i)
            // Dim r As Decline_Curve_Points = DCA_GEN_AVG.DeclineCases.FirstOrDefault.DeclineCurve(i)
            // d.PointExpRateAVG = Round(r.PointExpRate)
            // d.PointHarmRateAVG = Round(r.PointHarmRate)
            // d.PointHyperRateAVG = Round(r.PointHyperRate)
            // Next
            // -------------------
            // Dim DCA_GEN_MIN As New DCA
            // Dim maxitems_min As New List(Of AI.CasePortableData)
            // Dim minitems_min As New List(Of AI.CasePortableData)
            // maxitems_min = KocFieldData.GetDCAMinPortableTestDataForArea(pArea)
            // minitems_min = KocFieldData.GetDCAFromWellLatestDataPortableTestDataForArea(pArea, maxitems_min.FirstOrDefault.Well_Completion_s)
            // minitems_min.Add(maxitems_min.FirstOrDefault)
            // DCA_GEN_MIN.CreateDeclineForArea(minitems_min, Today, 12)
            // pdash.DCA_GEN.DeclineCases.FirstOrDefault.DeclineCurve_4Min = New List(Of AI.Decline_Curve_Points)
            // pdash.DCA_GEN.DeclineCases.FirstOrDefault.DeclineCurve_4Min.AddRange(DCA_GEN_MIN.DeclineCases.FirstOrDefault.DeclineCurve)
            // For i = 0 To pdash.DCA_GEN.DeclineCases.FirstOrDefault.DeclineCurve.Count - 1
            // Dim d As Decline_Curve_Points = pdash.DCA_GEN.DeclineCases.FirstOrDefault.DeclineCurve(i)
            // Dim r As Decline_Curve_Points = DCA_GEN_MIN.DeclineCases.FirstOrDefault.DeclineCurve(i)
            // d.PointExpRateMin = Round(r.PointExpRate)
            // d.PointHarmRateMin = Round(r.PointHarmRate)
            // d.PointHyperRateMin = Round(r.PointHyperRate)
            // Next
        }
        public void GetTopandBottomTop10Performer(cls_Dashboard_data dash, string pAreaID = "", string pGCID = "", string pFieldID = "", string pRESID = "", string pESP = "")
        {
            // Get Top 10 Performance
            try
            {
                if (pAreaID.Length > 0)
                {
                    dash.top10maxwellv = KocFieldData.MyWellLatestDataList.Where(X => (X.AREA ?? "") == (pAreaID ?? "") & X.BOPD > 0m).OrderByDescending(x => x.BOPD).ToList();
                }
            }
            catch (Exception ex)
            {

            }

            if (pGCID.Length > 0)
            {
                dash.top10maxwellv = KocFieldData.MyWellLatestDataList.Where(X => (X.CURRENT_GC ?? "") == (pGCID ?? "") & X.BOPD > 0m).OrderByDescending(x => x.BOPD).ToList();
            }
            if (pFieldID.Length > 0)
            {
                dash.top10maxwellv = KocFieldData.MyWellLatestDataList.Where(X => (X.FIELD_CODE ?? "") == (pFieldID ?? "") & X.BOPD > 0m).OrderByDescending(x => x.BOPD).ToList();
            }
            if (pRESID.Length > 0)
            {
                dash.top10maxwellv = KocFieldData.MyWellLatestDataList.Where(X => X.BOPD > 0m).OrderByDescending(x => x.BOPD).ToList();
            }

            if (pAreaID.Length > 0 & pESP == "Y")
            {
                dash.top10maxwellv = KocFieldData.MyWellLatestDataList.Where(X => (X.AREA ?? "") == (pAreaID ?? "") & X.BOPD > 0m).OrderByDescending(x => x.BOPD).ToList();
            }
            if (pGCID.Length > 0 & pESP == "Y")
            {
                dash.top10maxwellv = KocFieldData.MyWellLatestDataList.Where(X => (X.CURRENT_GC ?? "") == (pGCID ?? "") & X.BOPD > 0m).OrderByDescending(x => x.BOPD).ToList();
            }
            if (pFieldID.Length > 0 & pESP == "Y")
            {
                dash.top10maxwellv = KocFieldData.MyWellLatestDataList.Where(X => (X.FIELD_CODE ?? "") == (pFieldID ?? "") & X.BOPD > 0m).OrderByDescending(x => x.BOPD).ToList();
            }
            if (pRESID.Length > 0 & pESP == "Y")
            {
                dash.top10maxwellv = KocFieldData.MyWellLatestDataList.Where(X => X.BOPD > 0m).OrderByDescending(x => x.BOPD).ToList();
            }
            // ------------------------
            if (pAreaID.Length > 0)
            {
                dash.top10maxWaterwellv = KocFieldData.MyWellLatestDataList.Where(X => (X.AREA ?? "") == (pAreaID ?? "") & X.BWPD > 0m).OrderByDescending(x => x.BWPD).ToList();
            }
            if (pGCID.Length > 0)
            {
                dash.top10maxWaterwellv = KocFieldData.MyWellLatestDataList.Where(X => (X.CURRENT_GC ?? "") == (pGCID ?? "") & X.BWPD > 0m).OrderByDescending(x => x.BWPD).ToList();
            }
            if (pFieldID.Length > 0)
            {
                dash.top10maxWaterwellv = KocFieldData.MyWellLatestDataList.Where(X => (X.FIELD_CODE ?? "") == (pFieldID ?? "") & X.BWPD > 0m).OrderByDescending(x => x.BWPD).ToList();
            }
            if (pRESID.Length > 0)
            {
                dash.top10maxWaterwellv = KocFieldData.MyWellLatestDataList.Where(X => X.BWPD > 0m).OrderByDescending(x => x.BWPD).ToList();
            }

            if (pAreaID.Length > 0 & pESP == "Y")
            {
                dash.top10maxWaterwellv = KocFieldData.MyWellLatestDataList.Where(X => (X.AREA ?? "") == (pAreaID ?? "") & X.BWPD > 0m).OrderByDescending(x => x.BWPD).ToList();
            }
            if (pGCID.Length > 0 & pESP == "Y")
            {
                dash.top10maxWaterwellv = KocFieldData.MyWellLatestDataList.Where(X => (X.CURRENT_GC ?? "") == (pGCID ?? "") & X.BWPD > 0m).OrderByDescending(x => x.BWPD).ToList();
            }
            if (pFieldID.Length > 0 & pESP == "Y")
            {
                dash.top10maxWaterwellv = KocFieldData.MyWellLatestDataList.Where(X => (X.FIELD_CODE ?? "") == (pFieldID ?? "") & X.BWPD > 0m).OrderByDescending(x => x.BWPD).ToList();
            }
            if (pRESID.Length > 0 & pESP == "Y")
            {
                dash.top10maxWaterwellv = KocFieldData.MyWellLatestDataList.Where(X => X.BWPD > 0m).OrderByDescending(x => x.BWPD).ToList();
            }

            // Get Bottom 10 Performance

            if (pAreaID.Length > 0)
            {
                dash.top10minwellv = KocFieldData.MyWellLatestDataList.Where(X => (X.AREA ?? "") == (pAreaID ?? "") & X.BOPD > 0m).OrderBy(x => x.BOPD).ToList();
            }
            if (pGCID.Length > 0)
            {
                dash.top10minwellv = KocFieldData.MyWellLatestDataList.Where(X => (X.CURRENT_GC ?? "") == (pGCID ?? "") & X.BOPD > 0m).OrderBy(x => x.BOPD).ToList();
            }
            if (pFieldID.Length > 0)
            {
                dash.top10minwellv = KocFieldData.MyWellLatestDataList.Where(X => (X.FIELD_CODE ?? "") == (pFieldID ?? "") & X.BOPD > 0m).OrderBy(x => x.BOPD).ToList();
            }
            if (pRESID.Length > 0)
            {
                dash.top10minwellv = KocFieldData.MyWellLatestDataList.Where(X => X.BOPD > 0m).OrderBy(x => x.BOPD).ToList();
            }

            if (pAreaID.Length > 0 & pESP == "Y")
            {
                dash.top10minwellv = KocFieldData.MyWellLatestDataList.Where(X => (X.AREA ?? "") == (pAreaID ?? "") & X.BOPD > 0m).OrderBy(x => x.BOPD).ToList();
            }
            if (pGCID.Length > 0 & pESP == "Y")
            {
                dash.top10minwellv = KocFieldData.MyWellLatestDataList.Where(X => (X.CURRENT_GC ?? "") == (pGCID ?? "") & X.BOPD > 0m).OrderBy(x => x.BOPD).ToList();
            }
            if (pFieldID.Length > 0 & pESP == "Y")
            {
                dash.top10minwellv = KocFieldData.MyWellLatestDataList.Where(X => (X.FIELD_CODE ?? "") == (pFieldID ?? "") & X.BOPD > 0m).OrderBy(x => x.BOPD).ToList();
            }
            if (pRESID.Length > 0 & pESP == "Y")
            {
                dash.top10minwellv = KocFieldData.MyWellLatestDataList.Where(X => X.BOPD > 0m).OrderBy(x => x.BOPD).ToList();
            }
            // ------------------------
            if (pAreaID.Length > 0)
            {
                dash.top10minWaterwellv = KocFieldData.MyWellLatestDataList.Where(X => (X.AREA ?? "") == (pAreaID ?? "") & X.BWPD > 0m).OrderBy(x => x.BWPD).ToList();
            }
            if (pGCID.Length > 0)
            {
                dash.top10minWaterwellv = KocFieldData.MyWellLatestDataList.Where(X => (X.CURRENT_GC ?? "") == (pGCID ?? "") & X.BWPD > 0m).OrderBy(x => x.BWPD).ToList();
            }
            if (pFieldID.Length > 0)
            {
                dash.top10minWaterwellv = KocFieldData.MyWellLatestDataList.Where(X => (X.FIELD_CODE ?? "") == (pFieldID ?? "") & X.BWPD > 0m).OrderBy(x => x.BWPD).ToList();
            }
            if (pRESID.Length > 0)
            {
                dash.top10minWaterwellv = KocFieldData.MyWellLatestDataList.OrderBy(x => x.BWPD).ToList();
            }

            if (pAreaID.Length > 0 & pESP == "Y")
            {
                dash.top10minWaterwellv = KocFieldData.MyWellLatestDataList.Where(X => (X.AREA ?? "") == (pAreaID ?? "") & X.BWPD > 0m).OrderBy(x => x.BWPD).ToList();
            }
            if (pGCID.Length > 0 & pESP == "Y")
            {
                dash.top10minWaterwellv = KocFieldData.MyWellLatestDataList.Where(X => (X.CURRENT_GC ?? "") == (pGCID ?? "") & X.BWPD > 0m).OrderBy(x => x.BWPD).ToList();
            }
            if (pFieldID.Length > 0 & pESP == "Y")
            {
                dash.top10minWaterwellv = KocFieldData.MyWellLatestDataList.Where(X => (X.FIELD_CODE ?? "") == (pFieldID ?? "") & X.BWPD > 0m).OrderBy(x => x.BWPD).ToList();
            }
            if (pRESID.Length > 0 & pESP == "Y")
            {
                dash.top10minWaterwellv = KocFieldData.MyWellLatestDataList.Where(X => X.BWPD > 0m).OrderBy(x => x.BWPD).ToList();
            }
        }
        public void GetTopandBottomPerformer(cls_Dashboard_data dash, string pAreaID = "", string pGCID = "", string pFieldID = "", string pRESID = "", string pESP = "")
        {


            if (pAreaID.Length > 0)
            {
                maxv = (int)Round(KocFieldData.MyWellLatestDataList.Where(y => (y.AREA ?? "") == (pAreaID ?? "")).Max(y => y.BOPD));
                minv = (int)Round(KocFieldData.MyWellLatestDataList.Where(y => (y.AREA ?? "") == (pAreaID ?? "") & y.BOPD > 0m).Min(y => y.BOPD));
                dash.maxwellv = KocFieldData.MyWellLatestDataList.Where(x => (x.AREA ?? "") == (pAreaID ?? "") & x.BOPD == maxv).FirstOrDefault();
                dash.minwellv = KocFieldData.MyWellLatestDataList.Where(x => (x.AREA ?? "") == (pAreaID ?? "") & x.BOPD == minv).FirstOrDefault();
            }
            if (pGCID.Length > 0)
            {
                maxv = (int)Round(KocFieldData.MyWellLatestDataList.Where(y => (y.CURRENT_GC ?? "") == (pGCID ?? "")).Max(y => y.BOPD));
                minv = (int)Round(KocFieldData.MyWellLatestDataList.Where(y => (y.CURRENT_GC ?? "") == (pGCID ?? "") & y.BOPD > 0m).Min(y => y.BOPD));
                dash.maxwellv = KocFieldData.MyWellLatestDataList.Where(x => (x.CURRENT_GC ?? "") == (pGCID ?? "") & x.BOPD == maxv).FirstOrDefault();
                dash.minwellv = KocFieldData.MyWellLatestDataList.Where(x => (x.CURRENT_GC ?? "") == (pGCID ?? "") & x.BOPD == minv).FirstOrDefault();
            }
            if (pFieldID.Length > 0)
            {
                maxv = (int)Round(KocFieldData.MyWellLatestDataList.Where(y => (y.FIELD_CODE ?? "") == (pFieldID ?? "")).Max(y => y.BOPD));
                minv = (int)Round(KocFieldData.MyWellLatestDataList.Where(y => (y.FIELD_CODE ?? "") == (pFieldID ?? "") & y.BOPD > 0m).Min(y => y.BOPD));
                dash.maxwellv = KocFieldData.MyWellLatestDataList.Where(x => (x.FIELD_CODE ?? "") == (pFieldID ?? "") & x.BOPD == maxv).FirstOrDefault();
                dash.minwellv = KocFieldData.MyWellLatestDataList.Where(x => (x.FIELD_CODE ?? "") == (pFieldID ?? "") & x.BOPD == minv).FirstOrDefault();
            }
            if (pRESID.Length > 0)
            {
                maxv = (int)Round(KocFieldData.MyWellLatestDataList.Where(y => (y.RESERVOIR_ID ?? "") == (pRESID ?? "")).Max(y => y.BOPD));
                minv = (int)Round(KocFieldData.MyWellLatestDataList.Where(y => (y.RESERVOIR_ID ?? "") == (pRESID ?? "") & y.BOPD > 0m).Min(y => y.BOPD));
                dash.maxwellv = KocFieldData.MyWellLatestDataList.Where(x => x.BOPD == maxv).FirstOrDefault();
                dash.minwellv = KocFieldData.MyWellLatestDataList.Where(x => x.BOPD == minv).FirstOrDefault();
            }


            if (pAreaID.Length > 0 & pESP == "Y")
            {
                maxv = (int)Round(KocFieldData.MyWellLatestDataList.Where(y => (y.AREA ?? "") == (pAreaID ?? "") & y.ESP.Length > 0).Max(y => y.BOPD));
                minv = (int)Round(KocFieldData.MyWellLatestDataList.Where(y => (y.AREA ?? "") == (pAreaID ?? "") & y.BOPD > 0m & y.ESP.Length > 0).Min(y => y.BOPD));
                dash.maxwellv = KocFieldData.MyWellLatestDataList.Where(x => x.BOPD == maxv).FirstOrDefault();
                dash.minwellv = KocFieldData.MyWellLatestDataList.Where(x => x.BOPD == minv).FirstOrDefault();
            }
            if (pGCID.Length > 0 & pESP == "Y")
            {
                maxv = (int)Round(KocFieldData.MyWellLatestDataList.Where(y => (y.CURRENT_GC ?? "") == (pGCID ?? "") & y.ESP.Length > 0).Max(y => y.BOPD));
                minv = (int)Round(KocFieldData.MyWellLatestDataList.Where(y => (y.CURRENT_GC ?? "") == (pGCID ?? "") & y.BOPD > 0m & y.ESP.Length > 0).Min(y => y.BOPD));
                dash.maxwellv = KocFieldData.MyWellLatestDataList.Where(x => x.BOPD == maxv).FirstOrDefault();
                dash.minwellv = KocFieldData.MyWellLatestDataList.Where(x => x.BOPD == minv).FirstOrDefault();
            }
            if (pFieldID.Length > 0 & pESP == "Y")
            {
                maxv = (int)Round(KocFieldData.MyWellLatestDataList.Where(y => (y.FIELD_CODE ?? "") == (pFieldID ?? "") & y.ESP.Length > 0).Max(y => y.BOPD));
                minv = (int)Round(KocFieldData.MyWellLatestDataList.Where(y => (y.FIELD_CODE ?? "") == (pFieldID ?? "") & y.BOPD > 0m & y.ESP.Length > 0).Min(y => y.BOPD));
                dash.maxwellv = KocFieldData.MyWellLatestDataList.Where(x => x.BOPD == maxv).FirstOrDefault();
                dash.minwellv = KocFieldData.MyWellLatestDataList.Where(x => x.BOPD == minv).FirstOrDefault();
            }
            if (pRESID.Length > 0 & pESP == "Y")
            {
                maxv = (int)Round(KocFieldData.MyWellLatestDataList.Where(y => (y.RESERVOIR_ID ?? "") == (pRESID ?? "") & y.ESP.Length > 0).Max(y => y.BOPD));
                minv = (int)Round(KocFieldData.MyWellLatestDataList.Where(y => (y.RESERVOIR_ID ?? "") == (pRESID ?? "") & y.BOPD > 0m & y.ESP.Length > 0).Min(y => y.BOPD));
                dash.maxwellv = KocFieldData.MyWellLatestDataList.Where(x => x.BOPD == maxv).FirstOrDefault();
                dash.minwellv = KocFieldData.MyWellLatestDataList.Where(x => x.BOPD == minv).FirstOrDefault();
            }
        }
        public void GetTopandBottomWaterProducer(cls_Dashboard_data dash, string pAreaID = "", string pGCID = "", string pFieldID = "", string pRESID = "", string pESP = "")
        {


            if (pAreaID.Length > 0)
            {
                maxv = (int)Round(KocFieldData.MyWellLatestDataList.Where(y => (y.AREA ?? "") == (pAreaID ?? "")).Max(y => y.BWPD));
                minv = (int)Round(KocFieldData.MyWellLatestDataList.Where(y => (y.AREA ?? "") == (pAreaID ?? "")).Min(y => y.BWPD));
                dash.maxWaterwellv = KocFieldData.MyWellLatestDataList.Where(x => (x.AREA ?? "") == (pAreaID ?? "") & x.BWPD == maxv).FirstOrDefault();
                dash.minWaterwellv = KocFieldData.MyWellLatestDataList.Where(x => (x.AREA ?? "") == (pAreaID ?? "") & x.BWPD == minv).FirstOrDefault();
            }
            if (pGCID.Length > 0)
            {
                maxv = (int)Round(KocFieldData.MyWellLatestDataList.Where(y => (y.CURRENT_GC ?? "") == (pGCID ?? "")).Max(y => y.BWPD));
                minv = (int)Round(KocFieldData.MyWellLatestDataList.Where(y => (y.CURRENT_GC ?? "") == (pGCID ?? "")).Min(y => y.BWPD));
                dash.maxWaterwellv = KocFieldData.MyWellLatestDataList.Where(x => (x.CURRENT_GC ?? "") == (pGCID ?? "") & x.BWPD == maxv).FirstOrDefault();
                dash.minWaterwellv = KocFieldData.MyWellLatestDataList.Where(x => (x.CURRENT_GC ?? "") == (pGCID ?? "") & x.BWPD == minv).FirstOrDefault();
            }
            if (pFieldID.Length > 0)
            {
                maxv = (int)Round(KocFieldData.MyWellLatestDataList.Where(y => (y.FIELD_CODE ?? "") == (pFieldID ?? "")).Max(y => y.BWPD));
                minv = (int)Round(KocFieldData.MyWellLatestDataList.Where(y => (y.FIELD_CODE ?? "") == (pFieldID ?? "")).Min(y => y.BWPD));
                dash.maxWaterwellv = KocFieldData.MyWellLatestDataList.Where(x => (x.FIELD_CODE ?? "") == (pFieldID ?? "") & x.BWPD == maxv).FirstOrDefault();
                dash.minWaterwellv = KocFieldData.MyWellLatestDataList.Where(x => (x.FIELD_CODE ?? "") == (pFieldID ?? "") & x.BWPD == minv).FirstOrDefault();
            }
            if (pRESID.Length > 0)
            {
                maxv = (int)Round(KocFieldData.MyWellLatestDataList.Where(y => (y.RESERVOIR_ID ?? "") == (pRESID ?? "")).Max(y => y.BWPD));
                minv = (int)Round(KocFieldData.MyWellLatestDataList.Where(y => (y.RESERVOIR_ID ?? "") == (pRESID ?? "")).Min(y => y.BWPD));
                dash.maxWaterwellv = KocFieldData.MyWellLatestDataList.Where(x => x.BWPD == maxv).FirstOrDefault();
                dash.minWaterwellv = KocFieldData.MyWellLatestDataList.Where(x => x.BWPD == minv).FirstOrDefault();
            }


            if (pAreaID.Length > 0 & pESP == "Y")
            {
                maxv = (int)Round(KocFieldData.MyWellLatestDataList.Where(y => (y.AREA ?? "") == (pAreaID ?? "") & y.ESP.Length > 0).Max(y => y.BWPD));
                minv = (int)Round(KocFieldData.MyWellLatestDataList.Where(y => (y.AREA ?? "") == (pAreaID ?? "") & y.ESP.Length > 0).Min(y => y.BWPD));
                dash.maxWaterwellv = KocFieldData.MyWellLatestDataList.Where(x => (x.AREA ?? "") == (pAreaID ?? "") & x.BWPD == maxv).FirstOrDefault();
                dash.minWaterwellv = KocFieldData.MyWellLatestDataList.Where(x => (x.AREA ?? "") == (pAreaID ?? "") & x.BWPD == minv).FirstOrDefault();
            }
            if (pGCID.Length > 0 & pESP == "Y")
            {
                maxv = (int)Round(KocFieldData.MyWellLatestDataList.Where(y => (y.CURRENT_GC ?? "") == (pGCID ?? "") & y.ESP.Length > 0).Max(y => y.BWPD));
                minv = (int)Round(KocFieldData.MyWellLatestDataList.Where(y => (y.CURRENT_GC ?? "") == (pGCID ?? "") & y.ESP.Length > 0).Min(y => y.BWPD));
                dash.maxWaterwellv = KocFieldData.MyWellLatestDataList.Where(x => (x.CURRENT_GC ?? "") == (pGCID ?? "") & x.BWPD == maxv).FirstOrDefault();
                dash.minWaterwellv = KocFieldData.MyWellLatestDataList.Where(x => (x.CURRENT_GC ?? "") == (pGCID ?? "") & x.BWPD == minv).FirstOrDefault();
            }
            if (pFieldID.Length > 0 & pESP == "Y")
            {
                maxv = (int)Round(KocFieldData.MyWellLatestDataList.Where(y => (y.FIELD_CODE ?? "") == (pFieldID ?? "") & y.ESP.Length > 0).Max(y => y.BWPD));
                minv = (int)Round(KocFieldData.MyWellLatestDataList.Where(y => (y.FIELD_CODE ?? "") == (pFieldID ?? "") & y.ESP.Length > 0).Min(y => y.BWPD));
                dash.maxWaterwellv = KocFieldData.MyWellLatestDataList.Where(x => (x.FIELD_CODE ?? "") == (pFieldID ?? "") & x.BWPD == maxv).FirstOrDefault();
                dash.minWaterwellv = KocFieldData.MyWellLatestDataList.Where(x => (x.FIELD_CODE ?? "") == (pFieldID ?? "") & x.BWPD == minv).FirstOrDefault();
            }
            if (pRESID.Length > 0 & pESP == "Y")
            {
                maxv = (int)Round(KocFieldData.MyWellLatestDataList.Where(y => (y.RESERVOIR_ID ?? "") == (pRESID ?? "") & y.ESP.Length > 0).Max(y => y.BWPD));
                minv = (int)Round(KocFieldData.MyWellLatestDataList.Where(y => (y.RESERVOIR_ID ?? "") == (pRESID ?? "") & y.ESP.Length > 0).Min(y => y.BWPD));
                dash.maxWaterwellv = KocFieldData.MyWellLatestDataList.Where(x => x.BWPD == maxv).FirstOrDefault();
                dash.minWaterwellv = KocFieldData.MyWellLatestDataList.Where(x => x.BWPD == minv).FirstOrDefault();
            }
        }
        public void GetHighestH2SWell(cls_Dashboard_data dash, string pAreaID = "", string pGCID = "", string pFieldID = "", string pRESID = "", string pESP = "")
        {
            decimal maxh2s;
            if (pAreaID.Length > 0)
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.AREA ?? "") == (pAreaID ?? "")).Max(y => y.H2S);
                dash.HighestH2SWell = KocFieldData.MyWellLatestDataList.Where(x => (x.AREA ?? "") == (pAreaID ?? "") & x.H2S == maxh2s).FirstOrDefault();
            }
            if (pGCID.Length > 0)
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.CURRENT_GC ?? "") == (GCID ?? "")).Max(y => y.H2S);
                dash.HighestH2SWell = KocFieldData.MyWellLatestDataList.Where(x => (x.CURRENT_GC ?? "") == (pGCID ?? "") & x.H2S == maxh2s).FirstOrDefault();
            }
            if (pFieldID.Length > 0)
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.FIELD_CODE ?? "") == (pFieldID ?? "")).Max(y => y.H2S);
                dash.HighestH2SWell = KocFieldData.MyWellLatestDataList.Where(x => (x.FIELD_CODE ?? "") == (pFieldID ?? "") & x.H2S == maxh2s).FirstOrDefault();
            }
            if (pRESID.Length > 0)
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.RESERVOIR_ID ?? "") == (pRESID ?? "")).Max(y => y.H2S);
                dash.HighestH2SWell = KocFieldData.MyWellLatestDataList.Where(x => x.H2S == maxh2s).FirstOrDefault();
            }


            if (pAreaID.Length > 0 & pESP == "Y")
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.AREA ?? "") == (pAreaID ?? "") & y.ESP.Length > 0).Max(y => y.H2S);
                dash.HighestH2SWell = KocFieldData.MyWellLatestDataList.Where(x => (x.AREA ?? "") == (pAreaID ?? "") & x.H2S == maxh2s).FirstOrDefault();
            }
            if (pGCID.Length > 0 & pESP == "Y")
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.CURRENT_GC ?? "") == (GCID ?? "") & y.ESP.Length > 0).Max(y => y.H2S);
                dash.HighestH2SWell = KocFieldData.MyWellLatestDataList.Where(x => (x.CURRENT_GC ?? "") == (pGCID ?? "") & x.H2S == maxh2s).FirstOrDefault();
            }
            if (pFieldID.Length > 0 & pESP == "Y")
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.FIELD_CODE ?? "") == (pFieldID ?? "") & y.ESP.Length > 0).Max(y => y.H2S);
                dash.HighestH2SWell = KocFieldData.MyWellLatestDataList.Where(x => (x.FIELD_CODE ?? "") == (pFieldID ?? "") & x.H2S == maxh2s).FirstOrDefault();
            }
            if (pRESID.Length > 0 & pESP == "Y")
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.RESERVOIR_ID ?? "") == (pRESID ?? "") & y.ESP.Length > 0).Max(y => y.H2S);
                dash.HighestH2SWell = KocFieldData.MyWellLatestDataList.Where(x => x.H2S == maxh2s).FirstOrDefault();
            }
        }
        public void GetMaxMinTVDWell(cls_Dashboard_data dash, string pAreaID = "", string pGCID = "", string pFieldID = "", string pRESID = "", string pESP = "")
        {
            decimal maxh2s;
            if (pAreaID.Length > 0)
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.AREA ?? "") == (pAreaID ?? "") & y.TVD > 0m).Max(y => y.TVD);
                dash.MaxTVDWell = KocFieldData.MyWellLatestDataList.Where(x => (x.AREA ?? "") == (pAreaID ?? "") & x.TVD == maxh2s).FirstOrDefault();
            }
            if (pGCID.Length > 0)
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.CURRENT_GC ?? "") == (GCID ?? "") & y.TVD > 0m).Max(y => y.TVD);
                dash.MaxTVDWell = KocFieldData.MyWellLatestDataList.Where(x => (x.CURRENT_GC ?? "") == (pGCID ?? "") & x.TVD == maxh2s).FirstOrDefault();
            }
            if (pFieldID.Length > 0)
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.FIELD_CODE ?? "") == (pFieldID ?? "") & y.TVD > 0m).Max(y => y.TVD);
                dash.MaxTVDWell = KocFieldData.MyWellLatestDataList.Where(x => (x.FIELD_CODE ?? "") == (pFieldID ?? "") & x.TVD == maxh2s).FirstOrDefault();
            }
            if (pRESID.Length > 0)
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.RESERVOIR_ID ?? "") == (pRESID ?? "") & y.TVD > 0m).Max(y => y.TVD);
                dash.MaxTVDWell = KocFieldData.MyWellLatestDataList.Where(x => x.TVD == maxh2s).FirstOrDefault();
            }


            if (pAreaID.Length > 0 & pESP == "Y")
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.AREA ?? "") == (pAreaID ?? "") & y.TVD > 0m & y.ESP.Length > 0).Max(y => y.TVD);
                dash.MaxTVDWell = KocFieldData.MyWellLatestDataList.Where(x => (x.AREA ?? "") == (pAreaID ?? "") & x.TVD == maxh2s).FirstOrDefault();
            }
            if (pGCID.Length > 0 & pESP == "Y")
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.CURRENT_GC ?? "") == (GCID ?? "") & y.ESP.Length > 0 & y.TVD > 0m).Max(y => y.TVD);
                dash.MaxTVDWell = KocFieldData.MyWellLatestDataList.Where(x => (x.CURRENT_GC ?? "") == (pGCID ?? "") & x.TVD == maxh2s).FirstOrDefault();
            }
            if (pFieldID.Length > 0 & pESP == "Y")
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.FIELD_CODE ?? "") == (pFieldID ?? "") & y.ESP.Length > 0 & y.TVD > 0m).Max(y => y.TVD);
                dash.MaxTVDWell = KocFieldData.MyWellLatestDataList.Where(x => (x.FIELD_CODE ?? "") == (pFieldID ?? "") & x.TVD == maxh2s).FirstOrDefault();
            }
            if (pRESID.Length > 0 & pESP == "Y")
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.RESERVOIR_ID ?? "") == (pRESID ?? "") & y.ESP.Length > 0 & y.TVD > 0m).Max(y => y.TVD);
                dash.MaxTVDWell = KocFieldData.MyWellLatestDataList.Where(x => x.TVD == maxh2s).FirstOrDefault();
            }

            // ------------------------------------- Get minimum

            if (pAreaID.Length > 0)
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.AREA ?? "") == (pAreaID ?? "") & y.TVD > 0m).Min(y => y.TVD);
                dash.MinTVDWell = KocFieldData.MyWellLatestDataList.Where(x => (x.AREA ?? "") == (pAreaID ?? "") & x.TVD == maxh2s).FirstOrDefault();
            }
            if (pGCID.Length > 0)
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.CURRENT_GC ?? "") == (GCID ?? "") & y.TVD > 0m).Min(y => y.TVD);
                dash.MinTVDWell = KocFieldData.MyWellLatestDataList.Where(x => (x.CURRENT_GC ?? "") == (pGCID ?? "") & x.TVD == maxh2s).FirstOrDefault();
            }
            if (pFieldID.Length > 0)
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.FIELD_CODE ?? "") == (pFieldID ?? "") & y.TVD > 0m).Min(y => y.TVD);
                dash.MinTVDWell = KocFieldData.MyWellLatestDataList.Where(x => (x.FIELD_CODE ?? "") == (pFieldID ?? "") & x.TVD == maxh2s).FirstOrDefault();
            }
            if (pRESID.Length > 0)
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.RESERVOIR_ID ?? "") == (pRESID ?? "") & y.TVD > 0m).Min(y => y.TVD);
                dash.MinTVDWell = KocFieldData.MyWellLatestDataList.Where(x => x.TVD == maxh2s).FirstOrDefault();
            }


            if (pAreaID.Length > 0 & pESP == "Y")
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.AREA ?? "") == (pAreaID ?? "") & y.ESP.Length > 0 & y.TVD > 0m).Min(y => y.TVD);
                dash.MinTVDWell = KocFieldData.MyWellLatestDataList.Where(x => (x.AREA ?? "") == (pAreaID ?? "") & x.TVD == maxh2s).FirstOrDefault();
            }
            if (pGCID.Length > 0 & pESP == "Y")
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.CURRENT_GC ?? "") == (GCID ?? "") & y.ESP.Length > 0 & y.TVD > 0m).Min(y => y.TVD);
                dash.MinTVDWell = KocFieldData.MyWellLatestDataList.Where(x => (x.CURRENT_GC ?? "") == (pGCID ?? "") & x.TVD == maxh2s).FirstOrDefault();
            }
            if (pFieldID.Length > 0 & pESP == "Y")
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.FIELD_CODE ?? "") == (pFieldID ?? "") & y.ESP.Length > 0 & y.TVD > 0m).Max(y => y.TVD);
                dash.MinTVDWell = KocFieldData.MyWellLatestDataList.Where(x => (x.FIELD_CODE ?? "") == (pFieldID ?? "") & x.TVD == maxh2s).FirstOrDefault();
            }
            if (pRESID.Length > 0 & pESP == "Y")
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.RESERVOIR_ID ?? "") == (pRESID ?? "") & y.ESP.Length > 0 & y.TVD > 0m).Min(y => y.TVD);
                dash.MinTVDWell = KocFieldData.MyWellLatestDataList.Where(x => x.TVD == maxh2s).FirstOrDefault();
            }


        }
        public void GetHighestLowestAPIWell(cls_Dashboard_data dash, string pAreaID = "", string pGCID = "", string pFieldID = "", string pRESID = "", string pESP = "")
        {
            decimal maxh2s;
            if (pAreaID.Length > 0)
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.AREA ?? "") == (pAreaID ?? "")).Max(y => y.OIL_API);
                dash.HighestAPIWell = KocFieldData.MyWellLatestDataList.Where(x => (x.AREA ?? "") == (pAreaID ?? "") & x.OIL_API == maxh2s).FirstOrDefault();
            }
            if (pGCID.Length > 0)
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.CURRENT_GC ?? "") == (GCID ?? "")).Max(y => y.OIL_API);
                dash.HighestAPIWell = KocFieldData.MyWellLatestDataList.Where(x => (x.CURRENT_GC ?? "") == (pGCID ?? "") & x.OIL_API == maxh2s).FirstOrDefault();
            }
            if (pFieldID.Length > 0)
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.FIELD_CODE ?? "") == (pFieldID ?? "")).Max(y => y.OIL_API);
                dash.HighestAPIWell = KocFieldData.MyWellLatestDataList.Where(x => (x.FIELD_CODE ?? "") == (pFieldID ?? "") & x.OIL_API == maxh2s).FirstOrDefault();
            }
            if (pRESID.Length > 0)
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.RESERVOIR_ID ?? "") == (pRESID ?? "")).Max(y => y.OIL_API);
                dash.HighestAPIWell = KocFieldData.MyWellLatestDataList.Where(x => x.OIL_API == maxh2s).FirstOrDefault();
            }


            if (pAreaID.Length > 0 & pESP == "Y")
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.AREA ?? "") == (pAreaID ?? "") & y.ESP.Length > 0).Max(y => y.OIL_API);
                dash.HighestAPIWell = KocFieldData.MyWellLatestDataList.Where(x => (x.AREA ?? "") == (pAreaID ?? "") & x.OIL_API == maxh2s).FirstOrDefault();
            }
            if (pGCID.Length > 0 & pESP == "Y")
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.CURRENT_GC ?? "") == (GCID ?? "") & y.ESP.Length > 0).Max(y => y.OIL_API);
                dash.HighestAPIWell = KocFieldData.MyWellLatestDataList.Where(x => (x.CURRENT_GC ?? "") == (pGCID ?? "") & x.OIL_API == maxh2s).FirstOrDefault();
            }
            if (pFieldID.Length > 0 & pESP == "Y")
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.FIELD_CODE ?? "") == (pFieldID ?? "") & y.ESP.Length > 0).Max(y => y.OIL_API);
                dash.HighestAPIWell = KocFieldData.MyWellLatestDataList.Where(x => (x.FIELD_CODE ?? "") == (pFieldID ?? "") & x.OIL_API == maxh2s).FirstOrDefault();
            }
            if (pRESID.Length > 0 & pESP == "Y")
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.RESERVOIR_ID ?? "") == (pRESID ?? "") & y.ESP.Length > 0).Max(y => y.OIL_API);
                dash.HighestAPIWell = KocFieldData.MyWellLatestDataList.Where(x => x.OIL_API == maxh2s).FirstOrDefault();
            }
            // ------------------- get minimum
            if (pAreaID.Length > 0)
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.AREA ?? "") == (pAreaID ?? "") & y.OIL_API > 0).Min(y => y.OIL_API);
                dash.LowestAPIWell = KocFieldData.MyWellLatestDataList.Where(x => (x.AREA ?? "") == (pAreaID ?? "") & x.OIL_API == maxh2s).FirstOrDefault();
            }
            if (pGCID.Length > 0)
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.CURRENT_GC ?? "") == (GCID ?? "") & y.OIL_API > 0).Min(y => y.OIL_API);
                dash.LowestAPIWell = KocFieldData.MyWellLatestDataList.Where(x => (x.CURRENT_GC ?? "") == (pGCID ?? "") & x.OIL_API == maxh2s).FirstOrDefault();
            }
            if (pFieldID.Length > 0)
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.FIELD_CODE ?? "") == (pFieldID ?? "") & y.OIL_API > 0).Min(y => y.OIL_API);
                dash.LowestAPIWell = KocFieldData.MyWellLatestDataList.Where(x => (x.FIELD_CODE ?? "") == (pFieldID ?? "") & x.OIL_API == maxh2s).FirstOrDefault();
            }
            if (pRESID.Length > 0)
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.RESERVOIR_ID ?? "") == (pRESID ?? "") & y.OIL_API > 0).Min(y => y.OIL_API);
                dash.LowestAPIWell = KocFieldData.MyWellLatestDataList.Where(x => x.OIL_API == maxh2s).FirstOrDefault();
            }


            if (pAreaID.Length > 0 & pESP == "Y")
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.AREA ?? "") == (pAreaID ?? "") & y.OIL_API > 0 & y.ESP.Length > 0).Min(y => y.OIL_API);
                dash.LowestAPIWell = KocFieldData.MyWellLatestDataList.Where(x => (x.AREA ?? "") == (pAreaID ?? "") & x.OIL_API == maxh2s).FirstOrDefault();
            }
            if (pGCID.Length > 0 & pESP == "Y")
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.CURRENT_GC ?? "") == (GCID ?? "") & y.OIL_API > 0 & y.ESP.Length > 0).Min(y => y.OIL_API);
                dash.LowestAPIWell = KocFieldData.MyWellLatestDataList.Where(x => (x.CURRENT_GC ?? "") == (pGCID ?? "") & x.OIL_API == maxh2s).FirstOrDefault();
            }
            if (pFieldID.Length > 0 & pESP == "Y")
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.FIELD_CODE ?? "") == (pFieldID ?? "") & y.ESP.Length > 0).Min(y => y.OIL_API);
                dash.LowestAPIWell = KocFieldData.MyWellLatestDataList.Where(x => (x.FIELD_CODE ?? "") == (pFieldID ?? "") & x.OIL_API == maxh2s).FirstOrDefault();
            }
            if (pRESID.Length > 0 & pESP == "Y")
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.RESERVOIR_ID ?? "") == (pRESID ?? "") & y.OIL_API > 0 & y.ESP.Length > 0).Min(y => y.OIL_API);
                dash.LowestAPIWell = KocFieldData.MyWellLatestDataList.Where(x => x.OIL_API == maxh2s).FirstOrDefault();
            }
        }
        public void GetHighestSaltWell(cls_Dashboard_data dash, string pAreaID = "", string pGCID = "", string pFieldID = "", string pRESID = "", string pESP = "")
        {
            int maxh2s;
            if (pAreaID.Length > 0)
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.AREA ?? "") == (pAreaID ?? "")).Max(y => y.SALT);
                dash.HighestSaltWell = KocFieldData.MyWellLatestDataList.Where(x => (x.AREA ?? "") == (pAreaID ?? "") & x.SALT == maxh2s).FirstOrDefault();
            }
            if (pGCID.Length > 0)
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.CURRENT_GC ?? "") == (GCID ?? "")).Max(y => y.SALT);
                dash.HighestSaltWell = KocFieldData.MyWellLatestDataList.Where(x => (x.CURRENT_GC ?? "") == (pGCID ?? "") & x.SALT == maxh2s).FirstOrDefault();
            }
            if (pFieldID.Length > 0)
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.FIELD_CODE ?? "") == (pFieldID ?? "")).Max(y => y.SALT);
                dash.HighestSaltWell = KocFieldData.MyWellLatestDataList.Where(x => (x.FIELD_CODE ?? "") == (pFieldID ?? "") & x.SALT == maxh2s).FirstOrDefault();
            }
            if (pRESID.Length > 0)
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.RESERVOIR_ID ?? "") == (pRESID ?? "")).Max(y => y.SALT);
                dash.HighestSaltWell = KocFieldData.MyWellLatestDataList.Where(x => x.SALT == maxh2s).FirstOrDefault();
            }


            if (pAreaID.Length > 0 & pESP == "Y")
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.AREA ?? "") == (pAreaID ?? "") & y.ESP.Length > 0).Max(y => y.SALT);
                dash.HighestSaltWell = KocFieldData.MyWellLatestDataList.Where(x => (x.AREA ?? "") == (pAreaID ?? "") & x.SALT == maxh2s).FirstOrDefault();
            }
            if (pGCID.Length > 0 & pESP == "Y")
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.CURRENT_GC ?? "") == (GCID ?? "") & y.ESP.Length > 0).Max(y => y.SALT);
                dash.HighestSaltWell = KocFieldData.MyWellLatestDataList.Where(x => (x.CURRENT_GC ?? "") == (pGCID ?? "") & x.SALT == maxh2s).FirstOrDefault();
            }
            if (pFieldID.Length > 0 & pESP == "Y")
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.FIELD_CODE ?? "") == (pFieldID ?? "") & y.ESP.Length > 0).Max(y => y.SALT);
                dash.HighestAPIWell = KocFieldData.MyWellLatestDataList.Where(x => (x.FIELD_CODE ?? "") == (pFieldID ?? "") & x.SALT == maxh2s).FirstOrDefault();
            }
            if (pRESID.Length > 0 & pESP == "Y")
            {
                maxh2s = KocFieldData.MyWellLatestDataList.Where(y => (y.RESERVOIR_ID ?? "") == (pRESID ?? "") & y.ESP.Length > 0).Max(y => y.SALT);
                dash.HighestSaltWell = KocFieldData.MyWellLatestDataList.Where(x => x.SALT == maxh2s).FirstOrDefault();
            }
        }
        public void GetTotalESPWells(cls_Dashboard_data dash, string pAreaID = "", string pGCID = "", string pFieldID = "", string pRESID = "")
        {

            if (pAreaID.Length > 0)
            {
                dash.TotalNoofESPWells = KocFieldData.MyWellLatestDataList.Where(y => (y.AREA ?? "") == (pAreaID ?? "") & y.ESP == "Y").Count(y => y.WELL_COMPLETION_S);
            }
            if (pGCID.Length > 0)
            {
                dash.TotalNoofESPWells = KocFieldData.MyWellLatestDataList.Where(y => (y.CURRENT_GC ?? "") == (pGCID ?? "") & y.ESP == "Y").Count(y => y.WELL_COMPLETION_S);
            }
            if (pFieldID.Length > 0)
            {
                dash.TotalNoofESPWells = KocFieldData.MyWellLatestDataList.Where(y => y.FIELD_CODE == pFieldID && y.ESP == "Y").Count(u => u.WELL_COMPLETION_S);
            }
            if (pRESID.Length > 0)
            {
                dash.TotalNoofESPWells = KocFieldData.MyWellLatestDataList.Where(y => (y.RESERVOIR_ID ?? "") == (pRESID ?? "") & y.ESP == "Y").Count(y => y.WELL_COMPLETION_S);
            }




        }
        public void GetTotalINJWells(cls_Dashboard_data dash, string pAreaID = "", string pGCID = "", string pFieldID = "", string pRESID = "")
        {

            if (pAreaID.Length > 0)
            {
                dash.TotalNoofINJWells = KocFieldData.MyWellLatestDataList.Where(y => (y.AREA ?? "") == (pAreaID ?? "") & y.INJ == "x").Count(y => y.WELL_COMPLETION_S);
            }
            if (pGCID.Length > 0)
            {
                dash.TotalNoofINJWells = KocFieldData.MyWellLatestDataList.Where(y => (y.CURRENT_GC ?? "") == (pGCID ?? "") & y.INJ == "x").Count(y => y.WELL_COMPLETION_S);
            }
            if (pFieldID.Length > 0)
            {
                dash.TotalNoofINJWells = KocFieldData.MyWellLatestDataList.Where(y => (y.FIELD_CODE ?? "") == (pFieldID ?? "") & y.INJ == "x").Count(y => y.WELL_COMPLETION_S);
            }
            if (pRESID.Length > 0)
            {
                dash.TotalNoofINJWells = KocFieldData.MyWellLatestDataList.Where(y => (y.RESERVOIR_ID ?? "") == (pRESID ?? "") & y.INJ == "x").Count(y => y.WELL_COMPLETION_S);
            }




        }
        public void GetTotalGasINJWells(cls_Dashboard_data dash, string pAreaID = "", string pGCID = "", string pFieldID = "", string pRESID = "")
        {

            if (pAreaID.Length > 0)
            {
                dash.TotalNoofGASINJWells = KocFieldData.MyWellLatestDataList.Where(y => (y.AREA ?? "") == (pAreaID ?? "") & y.GASINJ == "Y").Count(y => y.WELL_COMPLETION_S);
            }
            if (pGCID.Length > 0)
            {
                dash.TotalNoofGASINJWells = KocFieldData.MyWellLatestDataList.Where(y => (y.CURRENT_GC ?? "") == (pGCID ?? "") & y.GASINJ == "Y").Count(y => y.WELL_COMPLETION_S);
            }
            if (pFieldID.Length > 0)
            {
                dash.TotalNoofGASINJWells = KocFieldData.MyWellLatestDataList.Where(y => (y.FIELD_CODE ?? "") == (pFieldID ?? "") & y.GASINJ == "Y").Count(y => y.WELL_COMPLETION_S);
            }
            if (pRESID.Length > 0)
            {
                dash.TotalNoofGASINJWells = KocFieldData.MyWellLatestDataList.Where(y => (y.RESERVOIR_ID ?? "") == (pRESID ?? "") & y.GASINJ == "Y").Count(y => y.WELL_COMPLETION_S);
            }




        }
        public void GetTotalProductionCapacity(cls_Dashboard_data dash, string pAreaID = "", string pGCID = "", string pFieldID = "", string pRESID = "")
        {
            dash.ProductionList.Clear();
            if (pAreaID.Length > 0)
            {
                dash.ProductionTotal.Oil = KocFieldData.MyWellLatestDataList.Where(y => (y.AREA ?? "") == (pAreaID ?? "")).Sum(y => y.BOPD);
                dash.ProductionTotal.Water = KocFieldData.MyWellLatestDataList.Where(y => (y.AREA ?? "") == (pAreaID ?? "")).Sum(y => y.BWPD);
                dash.ProductionTotal.Gas = KocFieldData.MyWellLatestDataList.Where(y => (y.AREA ?? "") == (pAreaID ?? "")).Sum(y => y.LATEST_GAS_RATE);


            }
            if (pGCID.Length > 0)
            {
                dash.ProductionTotal.Oil = KocFieldData.MyWellLatestDataList.Where(y => (y.CURRENT_GC ?? "") == (pGCID ?? "")).Sum(y => y.BOPD);
                dash.ProductionTotal.Water = KocFieldData.MyWellLatestDataList.Where(y => (y.CURRENT_GC ?? "") == (pGCID ?? "")).Sum(y => y.BWPD);
                dash.ProductionTotal.Gas = KocFieldData.MyWellLatestDataList.Where(y => (y.CURRENT_GC ?? "") == (pGCID ?? "")).Sum(y => y.LATEST_GAS_RATE);

            }
            if (pFieldID.Length > 0)
            {
                dash.ProductionTotal.Oil = KocFieldData.MyWellLatestDataList.Where(y => (y.FIELD_CODE ?? "") == (pFieldID ?? "")).Sum(y => y.BOPD);
                dash.ProductionTotal.Water = KocFieldData.MyWellLatestDataList.Where(y => (y.FIELD_CODE ?? "") == (pFieldID ?? "")).Sum(y => y.BWPD);
                dash.ProductionTotal.Gas = KocFieldData.MyWellLatestDataList.Where(y => (y.FIELD_CODE ?? "") == (pFieldID ?? "")).Sum(y => y.LATEST_GAS_RATE);

            }
            if (pRESID.Length > 0)
            {
                dash.ProductionTotal.Oil = KocFieldData.MyWellLatestDataList.Where(y => (y.RESERVOIR_ID ?? "") == (pRESID ?? "")).Sum(y => y.BOPD);
                dash.ProductionTotal.Water = KocFieldData.MyWellLatestDataList.Where(y => (y.RESERVOIR_ID ?? "") == (pRESID ?? "")).Sum(y => y.BWPD);
                dash.ProductionTotal.Gas = KocFieldData.MyWellLatestDataList.Where(y => (y.RESERVOIR_ID ?? "") == (pRESID ?? "")).Sum(y => y.LATEST_GAS_RATE);

            }

            dash.ProductionList.Add(new cls_Dashbaord_productionTotalListValues("Oil", (int)Round(dash.ProductionTotal.Oil), System.Drawing.Color.Black));
            dash.ProductionList.Add(new cls_Dashbaord_productionTotalListValues("Water", (int)Round(dash.ProductionTotal.Water), System.Drawing.Color.Blue));
            dash.ProductionList.Add(new cls_Dashbaord_productionTotalListValues("Gas", (int)Round(dash.ProductionTotal.Gas), System.Drawing.Color.Gray));


        }
        public void GetESPStatusList(cls_Dashboard_data dash, string pAreaID = "", string pGCID = "", string pFieldID = "", string pRESID = "")
        {


            if (pAreaID.Length > 0)
            {
                string p = "select count(*) production, " + "              case  " + "              when instr(upper(esp_status_reason),'POWER',1)>0  then 'Power Surge' " + "              when instr(upper(esp_status_reason),'WC',1)>0  then 'Due to High WC' " + "              when instr(upper(esp_status_reason),'NO FLOW',1)>0  then 'Due to No flow' " + "              when instr(upper(esp_status_reason),'REMOT',1)>0  then 'Restarted Remotely' " + "              when instr(upper(esp_status_reason),'MANUALLY',1)>0  then 'Restarted Manually' " + "              when instr(upper(esp_status_reason),'STALL',1)>0  then 'Due to Motor stall' " + "              when instr(upper(esp_status_reason),'O/L',1)>0  then 'Tripped due to O/L' " + "              when instr(upper(esp_status_reason),'OVER LOAD',1)>0  then 'Tripped due to O/L' " + "              when instr(upper(esp_status_reason),'GC',1)>0  then 'GC Request' " + "              when instr(upper(esp_status_reason),'U/L',1)>0  then 'Due to U/L' " + "              when instr(upper(esp_status_reason),'W/O',1)>0  then 'Manual off for Workover' " + "              when instr(upper(esp_status_reason),'WORKOVER',1)>0  then 'Manual off for Workover' " + "              when instr(upper(esp_status_reason),'RESTARTED',1)>0  then 'Restarted' " + "              when instr(upper(esp_status_reason),'SCADA',1)>0  then 'SCADA'   " + "              when instr(upper(esp_status_reason),'TM',1)>0  then 'Due to High Temp'   " + "              when instr(upper(esp_status_reason),'TEMP',1)>0  then 'Due to High Temp'   " + "              Else  " + "                ESP_STATUS_REASON " + "              end  TypeName  " + "            from WELL_LATEST_DATA " + "   where area='" + pAreaID + "' and esp_status='ESP CLOSE' and esp_status_reason is not null " + "   group by case  " + "             when instr(upper(esp_status_reason),'POWER',1)>0  then 'Power Surge' " + "             when instr(upper(esp_status_reason),'WC',1)>0  then 'Due to High WC' " + "             when instr(upper(esp_status_reason),'NO FLOW',1)>0  then 'Due to No flow' " + "              when instr(upper(esp_status_reason),'REMOT',1)>0  then 'Restarted Remotely' " + "              when instr(upper(esp_status_reason),'MANUALLY',1)>0  then 'Restarted Manually' " + " when instr(upper(esp_status_reason),'STALL',1)>0  then 'Due to Motor stall' " + " when instr(upper(esp_status_reason),'O/L',1)>0  then 'Tripped due to O/L' " + " when instr(upper(esp_status_reason),'OVER LOAD',1)>0  then 'Tripped due to O/L' " + " when instr(upper(esp_status_reason),'GC',1)>0  then 'GC Request' " + " when instr(upper(esp_status_reason),'U/L',1)>0  then 'Due to U/L' " + " when instr(upper(esp_status_reason),'W/O',1)>0  then 'Manual off for Workover' " + " when instr(upper(esp_status_reason),'WORKOVER',1)>0  then 'Manual off for Workover' " + " when instr(upper(esp_status_reason),'RESTARTED',1)>0  then 'Restarted' " + " when instr(upper(esp_status_reason),'SCADA',1)>0  then 'SCADA'   " + " when instr(upper(esp_status_reason),'TM',1)>0  then 'Due to High Temp' " + " when instr(upper(esp_status_reason),'TEMP',1)>0  then 'Due to High Temp'    " + " else " + "          ESP_STATUS_REASON" + "              END " + "              having count(*) >1 ";










































                dash.ESPStatusList = KocConfig.DhubContext.ExecuteStoreQuery<cls_Dashbaord_productionTotalListValues>(p, default).ToList;

            }
            if (pGCID.Length > 0)
            {
                string p = "select count(*) production, " + "              case  " + "                     when instr(upper(esp_status_reason),'POWER',1)>0  then 'Power Surge' " + "               when instr(upper(esp_status_reason),'WC',1)>0  then 'Due to High WC' " + "               when instr(upper(esp_status_reason),'NO FLOW',1)>0  then 'Due to No flow' " + "               when instr(upper(esp_status_reason),'REMOT',1)>0  then 'Restarted Remotely' " + "              when instr(upper(esp_status_reason),'MANUALLY',1)>0  then 'Restarted Manually' " + "              when instr(upper(esp_status_reason),'STALL',1)>0  then 'Due to Motor stall' " + "              when instr(upper(esp_status_reason),'O/L',1)>0  then 'Tripped due to O/L' " + "              when instr(upper(esp_status_reason),'OVER LOAD',1)>0  then 'Tripped due to O/L' " + "              when instr(upper(esp_status_reason),'GC',1)>0  then 'GC Request' " + "              when instr(upper(esp_status_reason),'U/L',1)>0  then 'Due to U/L' " + "              when instr(upper(esp_status_reason),'W/O',1)>0  then 'Manual off for Workover' " + "              when instr(upper(esp_status_reason),'WORKOVER',1)>0  then 'Manual off for Workover' " + "              when instr(upper(esp_status_reason),'RESTARTED',1)>0  then 'Restarted' " + "              when instr(upper(esp_status_reason),'SCADA',1)>0  then 'SCADA'   " + "              when instr(upper(esp_status_reason),'TM',1)>0  then 'Due to High Temp'   " + "              when instr(upper(esp_status_reason),'TEMP',1)>0  then 'Due to High Temp'   " + "        Else  " + "            ESP_STATUS_REASON " + "              end  TypeName  " + "            from WELL_LATEST_DATA " + "where current_gc='" + pGCID + "' and esp_status='ESP CLOSE' and esp_status_reason is not null " + "group by case  " + "             when instr(upper(esp_status_reason),'POWER',1)>0  then 'Power Surge' " + "               when instr(upper(esp_status_reason),'WC',1)>0  then 'Due to High WC' " + "               when instr(upper(esp_status_reason),'NO FLOW',1)>0  then 'Due to No flow' " + "               when instr(upper(esp_status_reason),'REMOT',1)>0  then 'Restarted Remotely' " + "              when instr(upper(esp_status_reason),'MANUALLY',1)>0  then 'Restarted Manually' " + " when instr(upper(esp_status_reason),'STALL',1)>0  then 'Due to Motor stall' " + " when instr(upper(esp_status_reason),'O/L',1)>0  then 'Tripped due to O/L' " + " when instr(upper(esp_status_reason),'OVER LOAD',1)>0  then 'Tripped due to O/L' " + " when instr(upper(esp_status_reason),'GC',1)>0  then 'GC Request' " + " when instr(upper(esp_status_reason),'U/L',1)>0  then 'Due to U/L' " + " when instr(upper(esp_status_reason),'W/O',1)>0  then 'Manual off for Workover' " + " when instr(upper(esp_status_reason),'WORKOVER',1)>0  then 'Manual off for Workover' " + " when instr(upper(esp_status_reason),'RESTARTED',1)>0  then 'Restarted' " + " when instr(upper(esp_status_reason),'SCADA',1)>0  then 'SCADA'   " + " when instr(upper(esp_status_reason),'TM',1)>0  then 'Due to High Temp' " + " when instr(upper(esp_status_reason),'TEMP',1)>0  then 'Due to High Temp'    " + "           else " + "          ESP_STATUS_REASON" + "           END " + "having count(*) >1 ";










































                dash.ESPStatusList = KocConfig.DhubContext.ExecuteStoreQuery<cls_Dashbaord_productionTotalListValues>(p, default).ToList;

            }
            if (pFieldID.Length > 0)
            {
                string p = "select count(*) production, " + "              case  " + "                     when instr(upper(esp_status_reason),'POWER',1)>0  then 'Power Surge' " + "               when instr(upper(esp_status_reason),'WC',1)>0  then 'Due to High WC' " + "               when instr(upper(esp_status_reason),'NO FLOW',1)>0  then 'Due to No flow' " + "               when instr(upper(esp_status_reason),'REMOT',1)>0  then 'Restarted Remotely' " + "              when instr(upper(esp_status_reason),'MANUALLY',1)>0  then 'Restarted Manually' " + "              when instr(upper(esp_status_reason),'STALL',1)>0  then 'Due to Motor stall' " + "              when instr(upper(esp_status_reason),'O/L',1)>0  then 'Tripped due to O/L' " + "              when instr(upper(esp_status_reason),'OVER LOAD',1)>0  then 'Tripped due to O/L' " + "              when instr(upper(esp_status_reason),'GC',1)>0  then 'GC Request' " + "              when instr(upper(esp_status_reason),'U/L',1)>0  then 'Due to U/L' " + "              when instr(upper(esp_status_reason),'W/O',1)>0  then 'Manual off for Workover' " + "              when instr(upper(esp_status_reason),'WORKOVER',1)>0  then 'Manual off for Workover' " + "              when instr(upper(esp_status_reason),'RESTARTED',1)>0  then 'Restarted' " + "              when instr(upper(esp_status_reason),'SCADA',1)>0  then 'SCADA'   " + "              when instr(upper(esp_status_reason),'TM',1)>0  then 'Due to High Temp'   " + "              when instr(upper(esp_status_reason),'TEMP',1)>0  then 'Due to High Temp'   " + "        Else  " + "            ESP_STATUS_REASON " + "              end  TypeName  " + "            from WELL_LATEST_DATA " + "where field_code='" + pFieldID + "' and esp_status='ESP CLOSE' and esp_status_reason is not null " + "group by case  " + "             when instr(upper(esp_status_reason),'POWER',1)>0  then 'Power Surge' " + "               when instr(upper(esp_status_reason),'WC',1)>0  then 'Due to High WC' " + "               when instr(upper(esp_status_reason),'NO FLOW',1)>0  then 'Due to No flow' " + "               when instr(upper(esp_status_reason),'REMOT',1)>0  then 'Restarted Remotely' " + "              when instr(upper(esp_status_reason),'MANUALLY',1)>0  then 'Restarted Manually' " + " when instr(upper(esp_status_reason),'STALL',1)>0  then 'Due to Motor stall' " + " when instr(upper(esp_status_reason),'O/L',1)>0  then 'Tripped due to O/L' " + " when instr(upper(esp_status_reason),'OVER LOAD',1)>0  then 'Tripped due to O/L' " + " when instr(upper(esp_status_reason),'GC',1)>0  then 'GC Request' " + " when instr(upper(esp_status_reason),'U/L',1)>0  then 'Due to U/L' " + " when instr(upper(esp_status_reason),'W/O',1)>0  then 'Manual off for Workover' " + " when instr(upper(esp_status_reason),'WORKOVER',1)>0  then 'Manual off for Workover' " + " when instr(upper(esp_status_reason),'RESTARTED',1)>0  then 'Restarted' " + " when instr(upper(esp_status_reason),'SCADA',1)>0  then 'SCADA'   " + " when instr(upper(esp_status_reason),'TM',1)>0  then 'Due to High Temp' " + " when instr(upper(esp_status_reason),'TEMP',1)>0  then 'Due to High Temp'    " + "           else " + "          ESP_STATUS_REASON" + "           END " + "having count(*) >1 ";










































                dash.ESPStatusList = KocConfig.DhubContext.ExecuteStoreQuery<cls_Dashbaord_productionTotalListValues>(p, default).ToList;

            }
            if (pRESID.Length > 0)
            {
                string p = "select count(*) production, " + "              case  " + "                     when instr(upper(esp_status_reason),'POWER',1)>0  then 'Power Surge' " + "               when instr(upper(esp_status_reason),'WC',1)>0  then 'Due to High WC' " + "               when instr(upper(esp_status_reason),'NO FLOW',1)>0  then 'Due to No flow' " + "               when instr(upper(esp_status_reason),'REMOT',1)>0  then 'Restarted Remotely' " + "              when instr(upper(esp_status_reason),'MANUALLY',1)>0  then 'Restarted Manually' " + "              when instr(upper(esp_status_reason),'STALL',1)>0  then 'Due to Motor stall' " + "              when instr(upper(esp_status_reason),'O/L',1)>0  then 'Tripped due to O/L' " + "              when instr(upper(esp_status_reason),'OVER LOAD',1)>0  then 'Tripped due to O/L' " + "              when instr(upper(esp_status_reason),'GC',1)>0  then 'GC Request' " + "              when instr(upper(esp_status_reason),'U/L',1)>0  then 'Due to U/L' " + "              when instr(upper(esp_status_reason),'W/O',1)>0  then 'Manual off for Workover' " + "              when instr(upper(esp_status_reason),'WORKOVER',1)>0  then 'Manual off for Workover' " + "              when instr(upper(esp_status_reason),'RESTARTED',1)>0  then 'Restarted' " + "              when instr(upper(esp_status_reason),'SCADA',1)>0  then 'SCADA'   " + "              when instr(upper(esp_status_reason),'TM',1)>0  then 'Due to High Temp'   " + "              when instr(upper(esp_status_reason),'TEMP',1)>0  then 'Due to High Temp'   " + "        Else  " + "            ESP_STATUS_REASON " + "              end  TypeName  " + "            from WELL_LATEST_DATA " + "where  RESERVOIR_ID='" + pRESID + "' and esp_status='ESP CLOSE' and esp_status_reason is not null " + "group by case  " + "             when instr(upper(esp_status_reason),'POWER',1)>0  then 'Power Surge' " + "               when instr(upper(esp_status_reason),'WC',1)>0  then 'Due to High WC' " + "               when instr(upper(esp_status_reason),'NO FLOW',1)>0  then 'Due to No flow' " + "               when instr(upper(esp_status_reason),'REMOT',1)>0  then 'Restarted Remotely' " + "              when instr(upper(esp_status_reason),'MANUALLY',1)>0  then 'Restarted Manually' " + " when instr(upper(esp_status_reason),'STALL',1)>0  then 'Due to Motor stall' " + " when instr(upper(esp_status_reason),'O/L',1)>0  then 'Tripped due to O/L' " + " when instr(upper(esp_status_reason),'OVER LOAD',1)>0  then 'Tripped due to O/L' " + " when instr(upper(esp_status_reason),'GC',1)>0  then 'GC Request' " + " when instr(upper(esp_status_reason),'U/L',1)>0  then 'Due to U/L' " + " when instr(upper(esp_status_reason),'W/O',1)>0  then 'Manual off for Workover' " + " when instr(upper(esp_status_reason),'WORKOVER',1)>0  then 'Manual off for Workover' " + " when instr(upper(esp_status_reason),'RESTARTED',1)>0  then 'Restarted' " + " when instr(upper(esp_status_reason),'SCADA',1)>0  then 'SCADA'   " + " when instr(upper(esp_status_reason),'TM',1)>0  then 'Due to High Temp' " + " when instr(upper(esp_status_reason),'TEMP',1)>0  then 'Due to High Temp'    " + "           else " + "          ESP_STATUS_REASON" + "           END " + "having count(*) >1 ";










































                dash.ESPStatusList = KocConfig.DhubContext.ExecuteStoreQuery<cls_Dashbaord_productionTotalListValues>(p, default).ToList;

            }


            // dash.ProductionList.Add(New cls_Dashbaord_productionTotalListValues("Water", dash.ProductionTotal.Water, Drawing.Color.Blue))
            // dash.ProductionList.Add(New cls_Dashbaord_productionTotalListValues("Gas", dash.ProductionTotal.Gas, Drawing.Color.Gray))


        }
        public void GetESPStatusHist(cls_Dashboard_data dash, string pAreaID = "", string pGCID = "", string pFieldID = "", string pRESID = "")
        {


            if (pAreaID.Length > 0)
            {

                dash.ESP_Failures_hist = KocConfig.DhubContext.ExecuteStoreQuery<cls_stat_esp_failures_hist>("select sum(failures) failures,typename from stat_esp_failures where area='" + pAreaID + "'  group by typename", default).ToList;
                // select sum(floor(a.LIQUID_RATE * (1 - a.LATEST_WC / 100))) as  BOPD,sum(floor(a.LIQUID_RATE * (a.LATEST_WC / 100))) as BWPD,area,field_code,current_gc gc,reservoir_id,insertmonth pmonth,insertyear pyear ,status_type statustype,'AREA' DATATYPE
                // From well_latest_data_hist a
                // dash.ESP_Failures_hist = 

            }
            if (pGCID.Length > 0)
            {

                dash.ESP_Failures_hist = KocConfig.DhubContext.ExecuteStoreQuery<cls_stat_esp_failures_hist>("select sum(failures) failures,typename from stat_esp_failures where current_gc='" + pGCID + "'  group by typenameorder ", default).ToList;

            }
            if (pFieldID.Length > 0)
            {

                dash.ESP_Failures_hist = KocConfig.DhubContext.ExecuteStoreQuery<cls_stat_esp_failures_hist>("select sum(failures) failures,typename from stat_esp_failures where field_code='" + pFieldID + "' group by typename ", default).ToList;

            }
            if (pRESID.Length > 0)
            {

                dash.ESP_Failures_hist = KocConfig.DhubContext.ExecuteStoreQuery<cls_stat_esp_failures_hist>("select sum(failures) failures,typename from stat_esp_failures where RESERVOIR_ID='" + pRESID + "'  group by typename ", default).ToList;

            }


            // dash.ProductionList.Add(New cls_Dashbaord_productionTotalListValues("Water", dash.ProductionTotal.Water, Drawing.Color.Blue))
            // dash.ProductionList.Add(New cls_Dashbaord_productionTotalListValues("Gas", dash.ProductionTotal.Gas, Drawing.Color.Gray))


        }
        public void GetProdHist(cls_Dashboard_data dash, string pAreaID = "", string pGCID = "", string pFieldID = "", string pRESID = "")
        {


            if (pAreaID.Length > 0)
            {

                dash.Prod_hist = KocConfig.DhubContext.ExecuteStoreQuery<cls_stat_production_hist>("select sum(bopd) bopd,sum(bwpd) bwpd,monthyear from stat_production  where area='" + pAreaID + "' group by monthyear order by monthyear asc", default).ToList;

            }
            if (pGCID.Length > 0)
            {

                dash.Prod_hist = KocConfig.DhubContext.ExecuteStoreQuery<cls_stat_production_hist>("select sum(bopd) bopd,sum(bwpd) bwpd,monthyear from stat_production where current_gc='" + pGCID + "'  group by monthyear order by monthyear asc", default).ToList;

            }
            if (pFieldID.Length > 0)
            {

                dash.Prod_hist = KocConfig.DhubContext.ExecuteStoreQuery<cls_stat_production_hist>("select sum(bopd) bopd,sum(bwpd) bwpd,monthyear from stat_production where field_code='" + pFieldID + "'  group by monthyear order by monthyear asc", default).ToList;

            }
            if (pRESID.Length > 0)
            {

                dash.Prod_hist = KocConfig.DhubContext.ExecuteStoreQuery<cls_stat_production_hist>("select sum(bopd) bopd,sum(bwpd) bwpd,monthyear from stat_production where RESERVOIR_ID='" + pRESID + "'  group by monthyear order by monthyear asc", default).ToList;

            }


            // dash.ProductionList.Add(New cls_Dashbaord_productionTotalListValues("Water", dash.ProductionTotal.Water, Drawing.Color.Blue))
            // dash.ProductionList.Add(New cls_Dashbaord_productionTotalListValues("Gas", dash.ProductionTotal.Gas, Drawing.Color.Gray))


        }

    }
}