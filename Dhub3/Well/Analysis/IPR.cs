using KOC.DHUB3.Models;
using KOC.DHUB3.Models.Analysis;
using System;
using System.Collections.Generic;

namespace KOC.DHUB3.Well.Analysis
{
    public class IPR
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
        public List<IPRPoints> IPRs { get; set; }
        public int QmaxVogel { get; set; }
        public int QmaxWiggins { get; set; }
        public int QmaxStandings { get; set; }
        public int QmaxFetkovichs { get; set; }
        public int pwf_bhfp { get; set; }
        public int Q0 { get; set; }
        public int pr { get; set; }

        private int tdays = 0;
        private double b = 0.5d;

        public List<int> PressureList { get; set; }
        public IPR()
        {

            IPRs = new List<IPRPoints>();
            PressureList = new List<int>();
            // RatesList.Add(0)
            // Add any initialization after the InitializeComponent() call.

        }
        public void GenerateIPR(string uwi, int wcs, int pQ0, int ppwf_bhfp, int ppr)
        {
            IPRs = new List<IPRPoints>();
            if (wcs < 90000000)
            {
                Q0 = pQ0;
                pwf_bhfp = ppwf_bhfp;
                pr = ppr;
                QmaxVogel = (int)Math.Round(Q0 / (1d - 0.2d * (pwf_bhfp / (double)pr) - 0.8d * Math.Pow(pwf_bhfp / (double)pr, 2d)));
                QmaxWiggins = (int)Math.Round(Q0 / (1d - 0.52d * (pwf_bhfp / (double)pr) - 0.48d * Math.Pow(pwf_bhfp / (double)pr, 2d)));
                QmaxStandings = (int)Math.Round(Q0 / (1d - pwf_bhfp / (double)pr) * (1.8d * (pwf_bhfp / (double)pr)));
                QmaxFetkovichs = (int)Math.Round(Q0 / (1d - 0.2d * (pwf_bhfp / (double)pr) - 0.8d * Math.Pow(pwf_bhfp / (double)pr, 2d)));

                // --------------
                PressureList = new List<int>();
                PressureList.Add(ppr);
                for (double x = Math.Round(ppr / 300d) - 1d; x >= 1d; x += -1)

                    PressureList.Add((int)Math.Round(x * 300d));
                PressureList.Add(0);
                // PressureList.Add(0)
                // For x = 1 To Math.Round(ppr / 300) - 1
                // If x * 500 > ppr Then
                // Exit For
                // End If
                // PressureList.Add(x * 300)
                // Next
                // PressureList.Add(ppr)
                // -----------------
                try
                {
                    for (int y = 0, loopTo = PressureList.Count - 1; y <= loopTo; y++)  // rt As Integer In PressureList
                    {
                        var x = new IPRPoints();
                        int rt = PressureList[y];
                        x.Pressure = rt;
                        // Qmax = rt
                        x.VogelFlowRate = (int)Math.Round(Math.Round(CalcRate_Vogels(rt, pr)));
                        x.WigginsFlowRate = (int)Math.Round(Math.Round(CalcRate_Wiggins(rt, pr)));
                        x.StandingsFlowRate = (int)Math.Round(Math.Round(CalcRate_Standings(rt, pr)));
                        // x.FetkovichsFlowRate = CalcRate_Fetkovichs(Qmax, rt, pr)
                        IPRs.Add(x);
                    }
                }
                catch (Exception ex)
                {
                    // MsgBox("Some Values dont Exist ...", MsgBoxStyle.Exclamation, "DHUB 2")
                }

            }

        }
        private double CalcRate_Vogels(int pwf, int pr)
        {
            double x = pwf / (double)pr;
            return QmaxVogel * (1d - 0.2d * x - 0.8d * Math.Pow(x, 2d));
        }
        private double CalcRate_Wiggins(int pwf, int pr)
        {
            double x = pwf / (double)pr;
            return QmaxWiggins * (1d - 0.52d * x - 0.48d * Math.Pow(x, 2d));
        }
        private double CalcRate_Standings(int pwf, int pr)
        {
            double x = pwf / (double)pr;
            return QmaxStandings * (1d - 0.52d * x - 1.8d * x);
        }
        private double CalcRate_Fetkovichs(int pwf, int pr)
        {
            double x = pwf / (double)pr;
            return QmaxFetkovichs * (1d - 0.52d * x - (1d + 0.48d * x));
        }
        // Private Function Calc_PI()
        // Return
        // End Function

    }


}