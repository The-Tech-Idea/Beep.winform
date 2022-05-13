using System;

namespace KOC.DHUB3.Models
{
    [Serializable()]
    public class cls_file_lib
    {
        public int id { get; set; }
        public string UWI { get; set; } = "";
        public string FORMATION { get; set; } = "";
        public string FIELD { get; set; } = "";
        public DateTime? ISSUEDATE { get; set; }
        public string TAGS { get; set; } = "";
        public string INSERTBY { get; set; } = "";
        public string UPDATEBY { get; set; } = "";
        public DateTime? INSERTDATE { get; set; }
        public DateTime? UPDATEDATE { get; set; }
        public string FILENAME { get; set; } = "";
        public string TEAMCODE { get; set; } = "";
        public string CATEGORY_ID { get; set; } = "";
        public int? REFID { get; set; }
        public string FILEPATH { get; set; } = "";

        public cls_file_lib()
        {

        }
    }
}