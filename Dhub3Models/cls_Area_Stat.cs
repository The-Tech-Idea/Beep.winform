using System;

namespace KOC.DHUB3.Models
{
    public class cls_Area_Stat
    {
        public string Area { get; set; }
        public int BOPD { get; set; }
        public int BWPD { get; set; }
        public string FIELD_CODE { get; set; }
        public string reservoir_id { get; set; }
        public DateTime UpdateDate { get; set; }
        public string GC { get; set; }
        public cls_Finderwell HighestBOPDUWI { get; set; }
        public cls_Finderwell LowestBOPDUWI { get; set; }
        public cls_Finderwell HighestBWPDUWI { get; set; }
        public cls_Finderwell LowestBWPDUWI { get; set; }
        public cls_Area_Stat()
        {

        }
    }
}