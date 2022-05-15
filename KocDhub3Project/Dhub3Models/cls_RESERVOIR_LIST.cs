using System;

namespace KOC.DHUB3.Models
{

    [Serializable()]
    public class cls_RESERVOIR_LIST
    {
        public string RESERVOIR_ID { get; set; } = "";
        public string RESERVOIR_NAME { get; set; } = "";
        public cls_RESERVOIR_LIST()
        {

        }
        public cls_RESERVOIR_LIST(string pRESERVOIR_ID, string pRESERVOIR_NAME)
        {
            RESERVOIR_ID = pRESERVOIR_ID;
            RESERVOIR_NAME = pRESERVOIR_NAME;
        }
    }
}