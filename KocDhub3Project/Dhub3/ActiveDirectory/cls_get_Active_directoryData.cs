using System.Collections.Generic;

namespace KocConfig.ActiveDirctory
{
    public class cls_get_Active_directoryData
    {
        private clsAD x = new clsAD();
        private List<ActiveDirUser_cls> retds = new List<ActiveDirUser_cls>();
        public List<ActiveDirUser_cls> GetTeamUsers(string TeamCode)
        {
            x = new clsAD();
            retds = new List<ActiveDirUser_cls>();
            var tmpds = new List<ActiveDirUser_cls>();
            if (TeamCode.Length > 0)
            {
                x.GetKOCTeamUsers(TeamCode);
                tmpds = x.Listofusers;
                int count = 0;
                foreach (ActiveDirUser_cls y in tmpds)
                    retds.Add(y);
            }
            return retds;


        }
        public ActiveDirUser_cls GetTeamuser(string Kocno)
        {
            x = new clsAD();

            var tmp = new ActiveDirUser_cls();
            if (Kocno.Length > 0)
            {
                x.GetUserInfo(Kocno);
                tmp = x.Listofusers[0];
            }
            return tmp;


        }
    }
}