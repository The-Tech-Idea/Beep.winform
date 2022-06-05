using KOC.DHUB3.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KOC.DHUB3.Well.Analysis
{
    public class DCA
    {
        // Public KocConfig As KocConfig.Config
        // Public KocFieldData As FinderData.Cls_FinderDataList

        public string FieldID { get; set; }
        public string GCID { get; set; }
        public string PPDMUWI { get; set; }
        public string UWI { get; set; }
        public int WCS { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public List<Decline_Case> DeclineCases { get; set; }
        public List<CasePortableData> PortableData { get; set; }
        private int tdays = 0;
        private double b = 0.5d;

        public int AlarmRate { get; set; } = 100;
        public DCA()
        {

            DeclineCases = new List<Decline_Case>();

            // Add any initialization after the InitializeComponent() call.

        }



        private void CreateCalcpoint(ref Decline_Case d, int pdays, int pmonth)
        {



            int x1 = pdays; // + tdays

            // --------------------------------  Exp Curve ------------------------------------------------------
            var forcast = new Forcast_Data();
            var c1 = new Decline_Curve_Points();
            c1.DeclineRate = d.Effective_Decline_Rate;
            c1.PointDate = d.FINAL_DATE.AddDays(x1);
            c1.PointExpRate = Math.Round(d.INITIAL_RATE * Math.Exp(-x1 * d.Effective_Decline_Rate));
            double by = c1.DeclineRate * x1;
            c1.ExpCumPROD_at_t = Math.Round((d.INITIAL_RATE - c1.PointExpRate) / c1.DeclineRate);
            forcast.ExpCumPROD_at_t = c1.ExpCumPROD_at_t;
            d.DeclineCurve.Add(c1);

            // ---------------------------- Generate Hyper Curve Data --


            // c1 = New Decline_Curve_Points
            b = 0.5d;
            c1.DeclineRate = d.HyperNominal_Decline_Rate;  // ((d.INITIAL_RATE / d.FINAL_RATE) ^ b - 1) / (b * x1)             'd.Nominal_Decline_Rate/
            c1.PointDate = d.FINAL_DATE.AddDays(x1);
            c1.PointHyperRate = d.INITIAL_RATE / Math.Pow(1d + b * c1.DeclineRate * x1, 1d / b);                // d.FINAL_RATE * Math.Exp(-d.Nominal_Decline_Rate * x1)  ' d.FINAL_RATE - (x * d.Nominal_Decline_Rate)
            c1.HyperCumPROD_at_t = Math.Round(d.INITIAL_RATE / (d.HyperNominal_Decline_Rate * (1d - b)) * (1d - (Math.Pow(c1.PointHyperRate / d.INITIAL_RATE, 1d) - b)));
            forcast.HyperCumPROD_at_t = Math.Round(c1.HyperCumPROD_at_t);
            b = 1d;
            // '---------------------------- Generate Harm Curve Data --
            c1.DeclineRate = d.HarmNominal_Decline_Rate; // ((d.INITIAL_RATE / d.FINAL_RATE) ^ b - 1) / (b * x1)  '  b * (d.FINAL_RATE)
            c1.PointDate = d.FINAL_DATE.AddDays(x1);
            c1.PointHarmRate = d.INITIAL_RATE / Math.Pow(1d + b * c1.DeclineRate * x1, 1d / b);      // d.FINAL_RATE - (x * d.Nominal_Decline_Rate)
            c1.HarmCumPROD_at_t = Math.Round(d.INITIAL_RATE / (d.HarmNominal_Decline_Rate * (1d - b)) * (1d - (Math.Pow(c1.PointHarmRate / d.INITIAL_RATE, 1d) - b)));
            forcast.HarmCumPROD_at_t = c1.HarmCumPROD_at_t; // Math.Round(((d.INITIAL_RATE ^ b) * ((c1.PointHyperRate ^ 1 - b) - (c1.PointHyperRate ^ 1 - b))) / ((1 - n) * c1.DeclineRate))
                                                            // ---------------- Add 
            forcast.PointDate = d.FINAL_DATE.AddDays(x1);
            forcast.pMonths = pmonth;
            d.ForcastOutput.Add(forcast);


        }
        public List<Decline_Case> CreateDecline(int pWCS, List<CasePortableData> pPotableData, DateTime pStartDate = default, int pForcastPeriod = 12)
        {
            WCS = pWCS;
            var d = new Decline_Case();
            if (pPotableData == null == false)
            {
                PortableData = pPotableData;
            }
            d.TestHist = PortableData;
            if (d.TestHist.Count > 0)
            {
                var itemb4 = new CasePortableData();
                itemb4 = d.TestHist.Last();
                if (itemb4 == null == false)
                {
                    if (pStartDate==null)
                    {
                        pStartDate = (DateTime)itemb4.start_time;
                    }
                    d.PRODUCT_TYPE = "OIL";
                    d.START_DATE = pStartDate;
                    d.DECLINE_CURVE_TYPE = "EXPONENTIAL";
                    // ---------------------------- Get the Effective and Nominal Decline Rate --------
                    // d.INITIAL_RATE = itemb4.TEST_RATE ' d.TestHist.Where(Function(x) x.start_time = d.START_DATE).FirstOrDefault.TEST_RATE
                    // d.INITIAL_DATE = pStartDate
                    // d.FINAL_RATE = d.TestHist.FirstOrDefault.TEST_RATE
                    // d.FINAL_DATE = d.TestHist.FirstOrDefault.start_time
                    // ln / t.Days ' d
                    double avgoilrate = d.TestHist.Average(x => x.TEST_RATE);
                    // Dim startcase As CasePortableData = d.TestHist.OrderBy(Function(x) x.start_time).First
                    var Endcase = d.TestHist.OrderByDescending(x => x.start_time).First();
                    int mincaseValue = Endcase.TEST_RATE; // d.TestHist.Where(Function(x) x.start_time >= Endcase.start_time).Min(Function(x) x.OILRATE)
                    var mincase = Endcase; // d.TestHist.Where(Function(x) x.start_time >= maxcase.start_time And x.OILRATE = mincaseValue).FirstOrDefault
                                           // -------------
                    int maxcaseValue = d.TestHist.Max(x => x.TEST_RATE);
                    var maxcase = d.TestHist.Where(x => x.TEST_RATE == maxcaseValue).FirstOrDefault();
                    var startcase = maxcase;

                    // Dim itemb4 As New CasePortableData
                    itemb4 = startcase;
                    if (pStartDate == null)
                    {
                        pStartDate = (DateTime)itemb4.start_time;
                    }


                    d.FINAL_RATE = mincaseValue; // .TEST_RATE ' d.TestHist.Where(Function(x) x.start_time = d.START_DATE).FirstOrDefault.TEST_RATE
                    d.FINAL_DATE = (DateTime)mincase.start_time; // pStartDate
                    d.INITIAL_RATE = maxcaseValue; // .TEST_RATE
                    d.INITIAL_DATE = (DateTime)maxcase.start_time;


                    var f1 = new Forcast_Data();
                    bool startfetching = false;
                    // --------------------------------------------------------------------------------
                    var c = new Decline_Curve_Points();


                    // --------------------------------  Get Decline Rates for Curve ----------------------------------------------

                    var t = d.FINAL_DATE - d.INITIAL_DATE;
                    tdays = t.Days;
                    double ln = Math.Log(d.INITIAL_RATE / d.FINAL_RATE);

                    d.Nominal_Decline_Rate = ln / t.Days;       // a
                    d.Effective_Decline_Rate = (d.INITIAL_RATE - d.FINAL_RATE) / (d.INITIAL_RATE * t.Days);
                    d.RemainExp_t = Math.Round(Math.Log(d.INITIAL_RATE / AlarmRate) / d.Nominal_Decline_Rate);
                    double q1 = Math.Sqrt(d.INITIAL_RATE * d.FINAL_RATE);
                    b = 0.5d;

                    d.HyperNominal_Decline_Rate = (Math.Pow(d.INITIAL_RATE / d.FINAL_RATE, b) - 1d) / (b * tdays);
                    d.RemainHyper_t = Math.Round(Math.Log(d.INITIAL_RATE / AlarmRate) / d.HyperNominal_Decline_Rate);

                    b = 1d;
                    d.HarmNominal_Decline_Rate = (Math.Pow(d.INITIAL_RATE / d.FINAL_RATE, b) - 1d) / (b * tdays);
                    d.RemainHarm_t = Math.Round(Math.Log(d.INITIAL_RATE / AlarmRate) / d.HyperNominal_Decline_Rate);

                    // Math.Round(2 * (Math.Sqrt(d.INITIAL_RATE) / d.HyperNominal_Decline_Rate) * (Math.Sqrt(d.INITIAL_RATE) * Math.Sqrt(d.FINAL_RATE)))
                    // -----------------------------------------------------------------------------------------------------------
                    var Endoflifedate = d.FINAL_DATE.AddDays(d.RemainExp_t + 365 * 10);
                    int totyears = (int)Math.Round(Math.Truncate(d.RemainExp_t / 365d));
                    for (int i = 1, loopTo = totyears + 10; i <= loopTo; i++)
                    {
                        int totdays = i * 365;
                        CreateCalcpoint(ref d, totdays, i);
                    }

                    DeclineCases.Add(d);
                }

            }
            return DeclineCases;

            // --------------------------------------------------------------------------------
        }
        public List<Decline_Case> CreateDeclineForArea(List<CasePortableData> pPotableData, DateTime pStartDate = default, int pForcastPeriod = 12, string pCaseName = "", string p_Caseid = "")
        {

            var d = new Decline_Case();
            if (pPotableData == null == false)
            {
                PortableData = pPotableData;
            }
            d.TestHist = PortableData;
            if (d.TestHist.Count > 0)
            {

                d.PRODUCT_TYPE = "OIL";
                d.START_DATE = pStartDate;
                d.CASE_NAME = pCaseName;
                d.CASE_ID = p_Caseid;
                d.DECLINE_CURVE_TYPE = "EXPONENTIAL";
                // ---------------------------- Get the Effective and Nominal Decline Rate --------
                // d.INITIAL_RATE = itemb4.TEST_RATE ' d.TestHist.Where(Function(x) x.start_time = d.START_DATE).FirstOrDefault.TEST_RATE
                // d.INITIAL_DATE = pStartDate
                // d.FINAL_RATE = d.TestHist.FirstOrDefault.TEST_RATE
                // d.FINAL_DATE = d.TestHist.FirstOrDefault.start_time
                // ln / t.Days ' d
                double avgoilrate = d.TestHist.Average(x => x.TEST_RATE);
                // Dim startcase As CasePortableData = d.TestHist.OrderBy(Function(x) x.start_time).First
                var Endcase = d.TestHist.OrderByDescending(x => x.start_time).First();
                int mincaseValue = Endcase.TEST_RATE; // d.TestHist.Where(Function(x) x.start_time >= Endcase.start_time).Min(Function(x) x.OILRATE)
                var mincase = Endcase; // d.TestHist.Where(Function(x) x.start_time >= maxcase.start_time And x.OILRATE = mincaseValue).FirstOrDefault
                                       // -------------
                int maxcaseValue = d.TestHist.Max(x => x.TEST_RATE);
                var maxcase = d.TestHist.Where(x => x.TEST_RATE == maxcaseValue).FirstOrDefault();
                var startcase = maxcase;

                var itemb4 = new CasePortableData();
                itemb4 = startcase;
                if (pStartDate == null)
                {
                    pStartDate = (DateTime)itemb4.start_time;
                }
                // ---
                // --------------------------

                // Dim maxvalue As Integer = mincasev
                // Dim maxdate As Date = d.TestHist.Max(Function(x) x.start_time)

                // Dim mincase As CasePortableData = d.TestHist.Where(Function(x) x.TEST_RATE < maxvalue And x.start_time > maxdate).OrderByDescending(Function(x) x.start_time).FirstOrDefault 'd.TestHist.Min(Function(x) x.TEST_RATE)
                // Dim pmax As CasePortableData = d.TestHist.Where(Function(x)  And x.start_time > maxdate).OrderByDescending(Function(x) x.start_time).FirstOrDefault 'd.TestHist.Min(Function(x) x.TEST_RATE)
                // Dim pmin As CasePortableData
                // Try
                // pmax = d.TestHist.Where(Function(x) x.TEST_RATE = maxvalue).FirstOrDefault
                // pmin = mincase
                // Catch ex As Exception

                // End Try

                d.FINAL_RATE = mincaseValue; // .TEST_RATE ' d.TestHist.Where(Function(x) x.start_time = d.START_DATE).FirstOrDefault.TEST_RATE
                d.FINAL_DATE = (DateTime)mincase.start_time; // pStartDate
                d.INITIAL_RATE = maxcaseValue; // .TEST_RATE
                d.INITIAL_DATE = (DateTime)maxcase.start_time;
                // Dim Kv As Double = d.Effective_Decline_Rate / d.FINAL_RATE
                // Dim Dv As Double = -Math.Exp(d.FINAL_RATE - d.INITIAL_RATE) / t.Days



                var f1 = new Forcast_Data();
                bool startfetching = false;
                // --------------------------------------------------------------------------------
                var c = new Decline_Curve_Points();
                c = new Decline_Curve_Points();
                // c.DeclineRate = d.TestHist(x).TEST_RATE
                c.PointDate = (DateTime)maxcase.start_time;
                c.PointRate = maxcase.TEST_RATE;

                c.PointHyperRate = maxcase.TEST_RATE;
                c.PointExpRate = maxcase.TEST_RATE;
                c.PointHarmRate = maxcase.TEST_RATE;


                d.DeclineCurve.Add(c);
                c = new Decline_Curve_Points();
                // c.DeclineRate = d.TestHist(x).TEST_RATE
                c.PointDate = (DateTime)mincase.start_time;
                c.PointRate = mincase.TEST_RATE;

                c.PointHyperRate = mincase.TEST_RATE;
                c.PointExpRate = mincase.TEST_RATE;
                c.PointHarmRate = mincase.TEST_RATE;


                d.DeclineCurve.Add(c);
                // For x = 1 To d.TestHist.Count - 1 Step -1
                // If (d.TestHist(x).TEST_RATE = maxcaseValue) And (d.TestHist(x).start_time = maxcase.start_time) Then
                // startfetching = True
                // End If
                // If startfetching Then
                // c = New Decline_Curve_Points
                // '  c.DeclineRate = d.TestHist(x).TEST_RATE
                // c.PointDate = d.TestHist(x).start_time
                // c.PointRate = d.TestHist(x).TEST_RATE
                // If x = 0 Then
                // c.PointHyperRate = d.TestHist(x).TEST_RATE
                // c.PointExpRate = d.TestHist(x).TEST_RATE
                // c.PointHarmRate = d.TestHist(x).TEST_RATE
                // End If

                // d.DeclineCurve.Add(c)
                // End If
                // If (d.TestHist(x).TEST_RATE = mincaseValue) And (d.TestHist(x).start_time = mincase.start_time) Then
                // startfetching = False
                // End If

                // Next

                // ---------------------------- Generate Exp Curve Data --
                var m6 = d.FINAL_DATE.AddMonths(6);
                var m12 = d.FINAL_DATE.AddMonths(12);
                var m18 = d.FINAL_DATE.AddMonths(18);
                var m24 = d.FINAL_DATE.AddMonths(24);
                var m30 = d.FINAL_DATE.AddMonths(30);
                var m48 = d.FINAL_DATE.AddMonths(48);
                var m72 = d.FINAL_DATE.AddMonths(72);
                var day6 = m6 - d.FINAL_DATE;
                var day12 = m12 - d.FINAL_DATE;
                var day18 = m18 - d.FINAL_DATE;
                var day24 = m24 - d.FINAL_DATE;
                var day30 = m30 - d.FINAL_DATE;
                var day48 = m48 - d.FINAL_DATE;
                var day72 = m72 - d.FINAL_DATE;

                // --------------------------------  Get Decline Rates for Curve ----------------------------------------------

                var t = d.FINAL_DATE - d.INITIAL_DATE;
                tdays = t.Days;
                double ln = Math.Log(d.INITIAL_RATE / d.FINAL_RATE);

                d.Nominal_Decline_Rate = ln / t.Days;       // a
                d.Effective_Decline_Rate = (d.INITIAL_RATE - d.FINAL_RATE) / (d.INITIAL_RATE * t.Days);
                d.RemainExp_t = Math.Round(Math.Log(d.INITIAL_RATE / AlarmRate) / d.Nominal_Decline_Rate);
                double q1 = Math.Sqrt(d.INITIAL_RATE * d.FINAL_RATE);
                b = 0.5d;

                d.HyperNominal_Decline_Rate = (Math.Pow(d.INITIAL_RATE / d.FINAL_RATE, b) - 1d) / (b * tdays);
                d.RemainHyper_t = Math.Round(Math.Log(d.INITIAL_RATE / AlarmRate) / d.HyperNominal_Decline_Rate);

                b = 1d;
                d.HarmNominal_Decline_Rate = (Math.Pow(d.INITIAL_RATE / d.FINAL_RATE, b) - 1d) / (b * tdays);

                d.RemainHarm_t = Math.Round(Math.Log(d.INITIAL_RATE / AlarmRate) / d.HyperNominal_Decline_Rate);

                // Math.Round(2 * (Math.Sqrt(d.INITIAL_RATE) / d.HyperNominal_Decline_Rate) * (Math.Sqrt(d.INITIAL_RATE) * Math.Sqrt(d.FINAL_RATE)))
                // -----------------------------------------------------------------------------------------------------------
                CreateCalcpoint(ref d, 0, 0);
                int x1 = day6.Days;
                CreateCalcpoint(ref d, x1, 6);
                x1 = day12.Days;
                CreateCalcpoint(ref d, x1, 12);
                x1 = day18.Days;
                CreateCalcpoint(ref d, x1, 18);
                x1 = day24.Days;
                CreateCalcpoint(ref d, x1, 24);
                x1 = day30.Days;
                CreateCalcpoint(ref d, x1, 30);
                x1 = day48.Days;
                CreateCalcpoint(ref d, x1, 48);
                x1 = day72.Days;
                CreateCalcpoint(ref d, x1, 72);

                // -------------------------------------------------------------------------------------------

                x1 = (int)Math.Round(d.RemainExp_t + 1d);
                CreateCalcpoint(ref d, x1, 99);

                DeclineCases.Add(d);


                // KocFieldData.WellLatestDataList.Where(Function(x) x.WELL_COMPLETION_S = WCS).FirstOrDefault.DeclineCases = DeclineCases
            }
            return DeclineCases;

            // --------------------------------------------------------------------------------
        }

    }


}