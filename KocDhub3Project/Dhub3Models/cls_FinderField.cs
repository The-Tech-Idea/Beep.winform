using System;
using System.Collections.Generic;

namespace KOC.DHUB3.Models
{

    [Serializable()]
    public class cls_FinderField
    {

        public string Field_Name { get; set; } = "";
        public string Field_Code { get; set; } = "";
        public string Area { get; set; }
        public List<Reservoir> ReservoirList { get; set; } = new List<Reservoir>();
        public List<Layer> LayerList { get; set; } = new List<Layer>();
        public List<cls_Finderwell> ConnectedWells { get; set; }
        public List<cls_file_lib> Files { get; set; }
        public List<cls_rigactivityreport> Rigs { get; set; } = new List<cls_rigactivityreport>();
        public List<cls_survillanceclassreport> rep_survillance_report { get; set; } = new List<cls_survillanceclassreport>();
        public List<cls_wellsList> rep_newoldConnectedWells_report { get; set; } = new List<cls_wellsList>();
        public List<cls_rigactivityreport> rep_RigAcivities_report { get; set; } = new List<cls_rigactivityreport>();
        public List<cls_lastCloseOpenEvent> rep_lastcloseopen_report { get; set; } = new List<cls_lastCloseOpenEvent>();
        public List<cls_Wide_workover> Wide_WorkOver_report { get; set; } = new List<cls_Wide_workover>();
       
        public bool RefershFlag = false;


        public cls_FinderField(string pField_code)
        {
            Field_Code = pField_code;

        }
        public cls_FinderField()
        {

        }
    }
}