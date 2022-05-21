using System;
using System.Collections.Generic;
using System.Text;

namespace KOC.DHUB3.Models
{
    public class CasePortableData
    {
        public int TEST_STAGE_S { get; set; }
        public int OIL_FIELD_OPERATION_S { get; set; }
        public int Well_Completion_s { get; set; }
        public DateTime? start_time { get; set; }
        public string TEST_TYPE { get; set; }
        public int TEST_RATE { get; set; }
        public int WC { get; set; }
        public int GOR { get; set; }
        public int WHP { get; set; }
        public int FLP { get; set; }
        public int OILRATE { get; set; }
        public string LEFT_CHOKE_SIZE { get; set; }
        public string RIGHT_CHOKE_SIZE { get; set; }
        public string CHOKE { get; set; }
        // Public Property Avg_oilRate As Integer
        // Public Property Min_oilRate As Integer
        public CasePortableData()
        {

        }
    }

    public class Decline_Case
    {
        public string PRODUCT_TYPE { get; set; }
        public string CASE_ID { get; set; }
        public string CASE_NAME { get; set; }
        public string DECLINE_CURVE_TYPE { get; set; } // as exponential,harmonic,hyperbolic,linear
        public double Effective_Decline_Rate { get; set; }
        public double Nominal_Decline_Rate { get; set; }
        public double HyperEffective_Decline_Rate { get; set; }
        public double HyperNominal_Decline_Rate { get; set; }
        public double HarmEffective_Decline_Rate { get; set; }
        public double HarmNominal_Decline_Rate { get; set; }
        public double FINAL_DECLINE { get; set; }
        public double FINAL_RATE { get; set; }
        public double INITIAL_DECLINE { get; set; }
        public double INITIAL_RATE { get; set; }
        public string PROJECT_ID { get; set; }
        public string REMARK { get; set; }
        public DateTime START_DATE { get; set; }
        public DateTime INITIAL_DATE { get; set; }
        public DateTime FINAL_DATE { get; set; }
        public double VOLUME { get; set; }
        public List<Forcast_Data> ForcastOutput { get; set; }
        public double ExpCumPROD_at_t { get; set; }
        public double HyperCumPROD_at_t { get; set; }
        public double HarmCumPROD_at_t { get; set; }

        public double RemainExp_t { get; set; }
        public double RemainHyper_t { get; set; }
        public double RemainHarm_t { get; set; }
        public int WCS { get; set; }
        public string UWI { get; set; }
        public List<Decline_Case_Condition> Conditions { get; set; }
        public List<Decline_Case_Segment> Segments { get; set; }
        public List<CasePortableData> TestHist { get; set; }
        public List<Decline_Curve_Points> DeclineCurve_4Max { get; set; }
        public List<Decline_Curve_Points> DeclineCurve_4Min { get; set; }
        public List<Decline_Curve_Points> DeclineCurve_4Avg { get; set; }
        public List<Decline_Curve_Points> DeclineCurve { get; set; }

        public Decline_Case()
        {
            Conditions = new List<Decline_Case_Condition>();
            Segments = new List<Decline_Case_Segment>();
            TestHist = new List<CasePortableData>();
            ForcastOutput = new List<Forcast_Data>();
            DeclineCurve = new List<Decline_Curve_Points>();
            // This call is required by the designer.


            // Add any initialization after the InitializeComponent() call.

        }
    }

    public class Decline_Case_Condition
    {
        public string PERIOD_TYPE { get; set; }
        public DateTime VOLUME_DATE { get; set; }
        public string CONDITION_CODE { get; set; }
        public string CONDITION_DESC { get; set; }
        public string CONDITION_TYPE { get; set; }
        public double CONDITION_VALUE { get; set; }
        public Decline_Case_Condition()
        {

            // This call is required by the designer.


            // Add any initialization after the InitializeComponent() call.

        }
    }

    public class Decline_Case_Segment
    {
        public string SEGMENT_ID { get; set; }
        public double DURATION { get; set; }
        public DateTime END_DATE { get; set; }
        public double FINAL_DECLINE { get; set; }
        public double FINAL_RATE { get; set; }
        public double INITIAL_RATE { get; set; }
        public double INITIAL_DECLINE { get; set; }
        public double MINIMUM_DECLINE { get; set; }
        public double N_FACTOR { get; set; }
        public string RATIO_CURVE_TYPE { get; set; }
        public double RATIO_FINAL_RATE { get; set; }
        public string RATIO_FLUID_TYPE { get; set; }
        public double RATIO_INITIAL_RATE { get; set; }
        public double RATIO_VOLUME { get; set; }
        public double VOLUME { get; set; }
        public DateTime START_DATE { get; set; }
        public Decline_Case_Segment()
        {

            // This call is required by the designer.


            // Add any initialization after the InitializeComponent() call.

        }
    }

    public class Decline_Curve_Points
    {
        public string Segment_id { get; set; }
        public DateTime PointDate { get; set; }
        public double PointRate { get; set; }
        public double PointExpRate { get; set; }
        public double PointHyperRate { get; set; }
        public double PointHarmRate { get; set; }

        public double PointExpRateAVG { get; set; }
        public double PointHyperRateAVG { get; set; }
        public double PointHarmRateAVG { get; set; }

        public double PointExpRateMin { get; set; }
        public double PointHyperRateMin { get; set; }
        public double PointHarmRateMin { get; set; }

        public double PointExpRateMax { get; set; }
        public double PointHyperRateMax { get; set; }
        public double PointHarmRateMax { get; set; }


        public double DeclineRate { get; set; }
        public double ExpCumPROD_at_t { get; set; }
        public double HyperCumPROD_at_t { get; set; }
        public double HarmCumPROD_at_t { get; set; }


        public double RemainExp_t { get; set; }
        public double RemainHyper_t { get; set; }
        public double RemainHarm_t { get; set; }
        public Decline_Curve_Points()
        {

            // This call is required by the designer.


            // Add any initialization after the InitializeComponent() call.

        }
    }

    public class Forcast_Data
    {
        public int WCS { get; set; }
        public string UWI { get; set; }
        public int pMonths { get; set; }
        public double ExpCumPROD_at_t { get; set; }
        public double HyperCumPROD_at_t { get; set; }
        public double HarmCumPROD_at_t { get; set; }

        public double RemainExp_t { get; set; }
        public double RemainHyper_t { get; set; }
        public double RemainHarm_t { get; set; }

        public DateTime PointDate { get; set; }
        public double PointRate { get; set; }
    }
}
