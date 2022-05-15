using System;

namespace KOC.DHUB3.Models
{

    public class cls_hr_lov
    {
        public cls_hr_lov()
        {

        }
        public string ACTIVE { get; set; }

        public string DESCRIPTION { get; set; }
        public string GRPCODE { get; set; }
        public int ID { get; set; }
        public string KOCNO { get; set; }
        public string LOV_CODE { get; set; }
        public string LOV_NAME_ARA { get; set; }
        public string LOV_NAME_ENG { get; set; }
        public string LOV_TYPE { get; set; }
        public int PARENTID { get; set; }
        public string ROW_CREATED_BY { get; set; }
        public DateTime? ROW_CREATE_DATE { get; set; }
        public string ROW_UPDATE_BY { get; set; }
        public DateTime? ROW_UPDATE_DATE { get; set; }
        public string TEAMCODE { get; set; }
        public string Updated { get; set; } = "NO";
    }
}