using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TheTechIdea;
using TheTechIdea.Beep;
using Dapper;
using Dapper.Contrib.Extensions;

namespace KocConfig.ActiveDirctory
{
    public class SimpleODM_user
    {
        public SimpleODM_user(IDMEEditor iDMEEditor)
        {
            DMeditor = iDMEEditor;
        }
        private IDMEEditor DMeditor;
        public IDataSource connection { get; set; }
        #region Variables
        public string DUserID, FullName, FUserID, Fn, Status, KOC_No, Faclty;
        private string _MailID, _Location, _Building, _RoomNo, _Directorate, _TeamGroup, _Title, _TelNo, _FullAddr;
        public string _TeamCode { get; set; }
        protected Dictionary<string, string> _Groups = new Dictionary<string, string>();
        protected Dictionary<string, string> _GrpPerPages = new Dictionary<string, string>();
        protected Dictionary<string, string> _UsrPerPages = new Dictionary<string, string>();
        protected string _Team_id;
        protected int _id;
      
         
        #endregion
        #region Properties
        public string password { get; set; }
        public string loginid { get; set; }
        public string GRPCODE { get; set; }
        public string DIRCODE { get; set; }

        public string MailID
        {
            get
            {
                return _MailID;
            }
        }

        public string Location
        {
            get
            {
                return _Location;
            }
        }

        public string Building
        {
            get
            {
                return _Building;
            }
        }

        public string RoomNo
        {
            get
            {
                return _RoomNo;
            }
        }

        public string TeamCode
        {
            get
            {
                return _TeamCode;
            }
        }

        public string Directorate
        {
            get
            {
                return _Directorate;
            }
        }

        public string TeamGroup
        {
            get
            {
                return _TeamGroup;
            }
        }

        public string Title
        {
            get
            {
                return _Title;
            }
        }

        public string TelNo
        {
            get
            {
                return _TelNo;
            }
        }

        public string FullAddress
        {
            get
            {
                return _FullAddr;
            }
        }



        #endregion
        public string CAE_LEVEL { get; set; }
        public string DESIGNATION { get; set; }
        public string DomainUserID
        {
            get
            {
                return DUserID;
            }
            set
            {
                DUserID = value;
                GetUserInfo(value, "DUID");

            }
        }
        public string FinderUserID
        {
            get
            {
                return FUserID;
            }
            set
            {
                FUserID = value;
                GetUserInfo(value, "FUID");

            }
        }
        public string KOCNO
        {
            get
            {
                return KOC_No;
            }
            set
            {
                KOC_No = value;
                GetUserInfo(value, "KOCNO");
            }
        }
        public int UniqueID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                GetUserInfo(value, "ID");
            }
        }
        #region Read Only

        public string DisplayName
        {
            get
            {
                return FullName;
            }
        }
        public string Team_id
        {
            get
            {
                return _Team_id;
            }
        }
        public string Area { get; set; }


        public string Functions
        {
            get
            {
                return Fn;
            }
        }

        public string UserStatus
        {
            get
            {
                return Status;
            }
        }

        public string Facility
        {
            get
            {
                return Faclty;
            }
        }

        public Dictionary<string,string> Groups
        {
            get
            {
                return _Groups;
            }
        }

        public Dictionary<string, string> PermissionPages
        {
            get
            {
                return _Groups;
            }
        }

        #endregion
        public void FetchFromServiceByDomainId(string DomainID)
        {
            var adSrv = new AD();
            var ds = new DataSet();
            DataRow dr;

            ds = adSrv.GetUserInfoByDomianID(DomainID);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dr = ds.Tables[0].Rows[0];
                    if (!ReferenceEquals(dr["DomainID"], DBNull.Value))
                    {
                        DUserID =  string.Concat(@"KOCKW\", dr["DomainID"].ToString()); // value.ToString
                    }

                    // Me.FUserID = Nothing '-->>> fINDER SPECIFIC INFO

                    if (!ReferenceEquals(dr["DisplayName"], DBNull.Value))
                    {
                        FullName =  dr["DisplayName"].ToString();
                    }

                    // Me._Area = Nothing ' -->>>[EK/NK/SK/WK]

                    if (!ReferenceEquals(dr["title"], DBNull.Value))
                    {
                        Fn =  dr["title"].ToString();
                    }
                    if (!ReferenceEquals(dr["KOCID"], DBNull.Value))
                    {
                        KOC_No =  dr["KOCID"].ToString();
                    }

                    // Me.Faclty = Nothing '-->>> fINDER SPECIFIC INFO

                    // Me._id = Nothing '-->>> fINDER SPECIFIC INFO


                    if (!ReferenceEquals(dr["MailID"], DBNull.Value))
                    {
                        _MailID =  dr["MailID"].ToString();
                    }
                    if (!ReferenceEquals(dr["Location"], DBNull.Value))
                    {
                        _Location =  dr["Location"].ToString();
                    }
                    if (!ReferenceEquals(dr["Building"], DBNull.Value))
                    {
                        _Building =  dr["Building"].ToString();
                    }
                    if (!ReferenceEquals(dr["Location"], DBNull.Value))
                    {
                        _Location =  dr["Location"].ToString();
                    }
                    if (!ReferenceEquals(dr["Room No"], DBNull.Value))
                    {
                        _RoomNo =  dr["Room No"].ToString();
                    }
                    if (!ReferenceEquals(dr["TeamCode"], DBNull.Value))
                    {
                        _TeamCode =  dr["TeamCode"].ToString();


                    }
                    if (!ReferenceEquals(dr["Directorate"], DBNull.Value))
                    {
                        _Directorate =  dr["Directorate"].ToString();
                    }
                    if (!ReferenceEquals(dr["Group"], DBNull.Value))
                    {
                        _TeamGroup =  dr["Group"].ToString();
                    }
                    if (!ReferenceEquals(dr["Title"], DBNull.Value))
                    {
                        _Title =  dr["Title"].ToString();
                    }
                    if (!ReferenceEquals(dr["TelephoneNo"], DBNull.Value))
                    {
                        _TelNo =  dr["TelephoneNo"].ToString();
                    }
                    if (!ReferenceEquals(dr["FullAddress"], DBNull.Value))
                    {
                        _FullAddr =  dr["FullAddress"].ToString();
                    }

                    SetupArea();
                }

            }
        }
        public void FetchFromService(object value)
        {
            var adSrv = new AD();
            var ds = new DataSet();
            DataRow dr;

            ds = adSrv.GetUserInfoByDomianID(value.ToString());

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dr = ds.Tables[0].Rows[0];
                    if (!ReferenceEquals(dr["DomainID"], DBNull.Value))
                    {
                        DUserID =string.Concat(@"KOCKW\", dr["DomainID"].ToString()); // value.ToString
                    }

                    // Me.FUserID = Nothing '-->>> fINDER SPECIFIC INFO

                    if (!ReferenceEquals(dr["DisplayName"], DBNull.Value))
                    {
                        FullName = dr["DisplayName"].ToString();
                    }

                    // Me._Area = Nothing ' -->>>[EK/NK/SK/WK]

                    if (!ReferenceEquals(dr["title"], DBNull.Value))
                    {
                        Fn =  dr["title"].ToString();
                    }
                    if (!ReferenceEquals(dr["KOCID"], DBNull.Value))
                    {
                        KOC_No =  dr["KOCID"].ToString();
                    }

                    // Me.Faclty = Nothing '-->>> fINDER SPECIFIC INFO

                    // Me._id = Nothing '-->>> fINDER SPECIFIC INFO


                    if (!ReferenceEquals(dr["MailID"], DBNull.Value))
                    {
                        _MailID =  dr["MailID"].ToString();
                    }
                    if (!ReferenceEquals(dr["Location"], DBNull.Value))
                    {
                        _Location =  dr["Location"].ToString();
                    }
                    if (!ReferenceEquals(dr["Building"], DBNull.Value))
                    {
                        _Building =  dr["Building"].ToString();
                    }
                    if (!ReferenceEquals(dr["Location"], DBNull.Value))
                    {
                        _Location =  dr["Location"].ToString();
                    }
                    if (!ReferenceEquals(dr["Room No"], DBNull.Value))
                    {
                        _RoomNo =  dr["Room No"].ToString();
                    }
                    if (!ReferenceEquals(dr["TeamCode"], DBNull.Value))
                    {
                        _TeamCode =  dr["TeamCode"].ToString();


                    }
                    if (!ReferenceEquals(dr["Directorate"], DBNull.Value))
                    {
                        _Directorate =  dr["Directorate"].ToString();
                    }
                    if (!ReferenceEquals(dr["Group"], DBNull.Value))
                    {
                        _TeamGroup =  dr["Group"].ToString();
                    }
                    if (!ReferenceEquals(dr["Title"], DBNull.Value))
                    {
                        _Title =  dr["Title"].ToString();
                    }
                    if (!ReferenceEquals(dr["TelephoneNo"], DBNull.Value))
                    {
                        _TelNo =  dr["TelephoneNo"].ToString();
                    }
                    if (!ReferenceEquals(dr["FullAddress"], DBNull.Value))
                    {
                        _FullAddr =  dr["FullAddress"].ToString();
                    }

                    SetupArea();
                }
                // Else
                // Me.FUserID = Nothing
                // Me.FullName = Nothing
                // Me._Area = Nothing
                // Me.Fn = Nothing
                // Me.KOC_No = Nothing
                // Me.Faclty = Nothing
                // Me._id = Nothing
            }
        }
        public void SetupArea()
        {
            if (TeamCode.StartsWith("S") | TeamCode.StartsWith("CR11"))
            {
                Area = "SK";

            }
            if (TeamCode.StartsWith("N") | TeamCode.StartsWith("CR21"))
            {
                Area = "NK";

            }
            if (TeamCode.StartsWith("W") | TeamCode.StartsWith("WK") | TeamCode.StartsWith("CR21"))
            {
                Area = "WK";

            }
            if (TeamCode.StartsWith("P") | TeamCode.StartsWith("CR51") | TeamCode.StartsWith("LP71") | TeamCode.StartsWith("E") | TeamCode.StartsWith("LR"))
            {
                Area = "ALL";

            }
        }
        public void FetchFromServicebyKocNo(string kocno)
        {
            var adSrv = new AD();
            var ds = new DataSet();
            DataRow dr;

            ds = adSrv.GetUserInfoByKocno(kocno);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dr = ds.Tables[0].Rows[0];
                    if (!ReferenceEquals(dr["DomainID"], DBNull.Value))
                    {
                        DUserID = string.Concat(@"KOCKW\", dr["DomainID"].ToString()); // value.ToString
                    }

                    // Me.FUserID = Nothing '-->>> fINDER SPECIFIC INFO

                    if (!ReferenceEquals(dr["DisplayName"], DBNull.Value))
                    {
                        FullName =  dr["DisplayName"].ToString();
                    }

                    // Me._Area = Nothing ' -->>>[EK/NK/SK/WK]

                    if (!ReferenceEquals(dr["title"], DBNull.Value))
                    {
                        Fn =  dr["title"].ToString();
                    }
                    if (!ReferenceEquals(dr["KOCID"], DBNull.Value))
                    {
                        KOC_No =  dr["KOCID"].ToString();
                    }

                    // Me.Faclty = Nothing '-->>> fINDER SPECIFIC INFO

                    // Me._id = Nothing '-->>> fINDER SPECIFIC INFO


                    if (!ReferenceEquals(dr["MailID"], DBNull.Value))
                    {
                        _MailID =  dr["MailID"].ToString();
                    }
                    if (!ReferenceEquals(dr["Location"], DBNull.Value))
                    {
                        _Location =  dr["Location"].ToString();
                    }
                    if (!ReferenceEquals(dr["Building"], DBNull.Value))
                    {
                        _Building =  dr["Building"].ToString();
                    }
                    if (!ReferenceEquals(dr["Location"], DBNull.Value))
                    {
                        _Location =  dr["Location"].ToString();
                    }
                    if (!ReferenceEquals(dr["Room No"], DBNull.Value))
                    {
                        _RoomNo =  dr["Room No"].ToString();
                    }
                    if (!ReferenceEquals(dr["TeamCode"], DBNull.Value))
                    {
                        _TeamCode =  dr["TeamCode"].ToString();


                    }
                    if (!ReferenceEquals(dr["Directorate"], DBNull.Value))
                    {
                        _Directorate =  dr["Directorate"].ToString();
                    }
                    if (!ReferenceEquals(dr["Group"], DBNull.Value))
                    {
                        _TeamGroup =  dr["Group"].ToString();
                    }
                    if (!ReferenceEquals(dr["Title"], DBNull.Value))
                    {
                        _Title =  dr["Title"].ToString();
                    }
                    if (!ReferenceEquals(dr["TelephoneNo"], DBNull.Value))
                    {
                        _TelNo =  dr["TelephoneNo"].ToString();
                    }
                    if (!ReferenceEquals(dr["FullAddress"], DBNull.Value))
                    {
                        _FullAddr =  dr["FullAddress"].ToString();
                    }

                    SetupArea();
                }

            }
        }
        public void GetUserInfo(object Value, string Type)
        {
            var dt = new DataTable();
            DataRow dr;
            string Query = "";

            switch (Type ?? "")
            {
                case "DUID":
                    {
                        Query =  $"SELECT DOMAIN_USERID, USER_NAME, FINDER_USERID, AREA, FUNCTIONS, KOC_NO, FACILITY, ID FROM WEBUSERS WHERE USERSTATUS='ACTIVE' and LOWER(DOMAIN_USERID) =LOWER('{Value}')";
                        break;
                    }
                case "FUID":
                    {
                        Query = $"SELECT DOMAIN_USERID, USER_NAME, FINDER_USERID, AREA, FUNCTIONS, KOC_NO, FACILITY, IDFROM WEBUSERS WHERE USERSTATUS='ACTIVE' and LOWER(FINDER_USERID) =LOWER('{Value}')";
                        break;
                    }
                case "KOCNO":
                    {
                        Query =  $"SELECT DOMAIN_USERID, USER_NAME, FINDER_USERID, AREA, FUNCTIONS, KOC_NO, FACILITY, ID FROM WEBUSERS WHERE USERSTATUS='ACTIVE' and KOC_NO ='{Value}'";
                        break;
                    }
                case "ID":
                    {
                        Query = $"SELECT DOMAIN_USERID, USER_NAME, FINDER_USERID, AREA, FUNCTIONS, KOC_NO, FACILITY, ID FROM WEBUSERS WHERE USERSTATUS='ACTIVE' and ID ='{Value}'";
                        break;
                    }
            }


            dt = (DataTable)connection.RunQuery(Query); 
           
            if (dt !=null)
            {
                if (dt.Rows.Count > 0)
                {
                    dr = dt.Rows[0];
                    DUserID = dr["DOMAIN_USERID"].ToString();
                    FUserID = dr["FINDER_USERID"].ToString();
                    try
                    {
                        FetchFromService(Value);
                    }
                    catch (Exception ex)
                    {
                      //  Interaction.MsgBox("Error :Could not fetch User Data from dataset, Please Contact Information Management Team for Salaha User Account", MsgBoxStyle.Critical, "DHub E&P Info. Nav.");
                    }
                    FullName =  dr["USER_NAME"].ToString();
                    Area =  dr["AREA"].ToString();
                    if (Area == "SEK")
                        Area = "SK";
                    Fn =  dr["FUNCTIONS"].ToString();
                    KOC_No =  dr["KOC_NO"].ToString();
                    Faclty =  dr["FACILITY"].ToString();
                    _id = int.Parse(dr["ID"].ToString());
                    GetUserGroups();
                }
            }
        }
        public void GetUserInfoFromDhubUsers(object Value, string Type)
        {
            var dt = new DataTable();
            DataRow dr;
            string Query = "";

            switch (Type ?? "")
            {
                case "DUID":
                    {
                        Query = $"select * FROM dhub_users WHERE   LOWER(LOGINID)  =LOWER('{Value}')";
                        break;
                    }
                case "KOCNO":
                    {
                        Query = $"SELECT * FROM dhub_users WHERE   KOCNO ='{Value}'";
                        break;
                    }
                case "ID":
                    {
                        Query =  $"SELECT * FROM dhub_users WHERE ID ='{Value}'";
                        break;
                    }
            }

          

            dt = (DataTable)connection.RunQuery(Query);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    dr = dt.Rows[0];
                    DUserID = dr["DOMAIN_USERID"].ToString();
                    FUserID = dr["FINDER_USERID"].ToString();
                    try
                    {
                        FetchFromService(Value);
                    }
                    catch (Exception ex)
                    {
                        //  Interaction.MsgBox("Error :Could not fetch User Data from dataset, Please Contact Information Management Team for Salaha User Account", MsgBoxStyle.Critical, "DHub E&P Info. Nav.");
                    }
                    FullName = dr["USER_NAME"].ToString();
                    Area = dr["AREA"].ToString();
                    if (Area == "SEK")
                        Area = "SK";
                    Fn = dr["FUNCTIONS"].ToString();
                    KOC_No = dr["KOC_NO"].ToString();
                    Faclty = dr["FACILITY"].ToString();
                    _id = int.Parse(dr["ID"].ToString());
                }
                // Me.GetUserGroups()
                else
                {
                    try
                    {
                        FetchFromService(Value);
                    }
                    catch (Exception ex)
                    {
                        //Interaction.MsgBox("Error :Could not fetch User Data from dataset, Please Contact Information Management Team for Salaha User Account", MsgBoxStyle.Critical, "DHub E&P Info. Nav.");
                    }
                }

            }
        }
        private void GetUserGroups()
        {
            var dt = new DataTable();
          
            string Query = "";


            Query = "select distinct Group_ID from group_users where user_table_id=" + UniqueID;
            dt = (DataTable)connection.RunQuery(Query);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    _Groups.Clear();
                    foreach (DataRow dr in dt.Rows)
                        _Groups.Add(dr["Group_ID"].ToString(),  dr["Group_ID"].ToString());
                }
            }
        }
        public bool IsUserInGroup(string UserGroup)
        {
            return Groups.ContainsKey(UserGroup);
        }
        private bool GetGroupPermissionPages(string Group, int PageID)
        {
            int CNT = 0;
            // Dim dr As DataRow


           string qrystr = $"select *  from V_usergroup_permissions a where  LOWER(group_id)=LOWER('{Group}') AND FunctionOrPage={PageID} AND (sel=1)";
            DataTable dt = (DataTable)connection.RunQuery(qrystr);
            if (dt.Rows.Count > 0)
            {
                // If ds.Tables[0].Rows.Count > 0 Then
                // For Each dr In ds.Tables[0].Rows
                // Try
                // _GrpPerPages.Add(dr.Item("FunctionORPage").ToString, dr.Item("FunctionORPage").ToString) ', dr.Item("GROUP_ID").ToString & "#" & dr.Item("FunctionORPage").ToString)
                // Catch ex As Exception
                // End Try
                // Next
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool GetUserPermissionPages(int UserID, int PageID)
        {
            int CNT = 0;



          string  qrystr = $"select * from V_usergroup_permissions a where  userid='{UserID}' AND FunctionOrPage={PageID} AND (sel=0)";
            DataTable dt = (DataTable)connection.RunQuery(qrystr);
            if (dt.Rows.Count > 0)
            {

                // For Each dr In ds.Tables[0].Rows
                // Try
                // _UsrPerPages.Add(dr.Item("FunctionORPage").ToString, dr.Item("FunctionORPage").ToString) ', dr.Item("GROUP_ID").ToString & "#" & dr.Item("FunctionORPage").ToString)
                // Catch ex As Exception
                // End Try
                // Next
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DoesUserHasPermission(int PageID)
        {
            bool permission = false;
            if (!(_Groups.Count > 0))
            {
                GetUserGroups();
            }
            _GrpPerPages.Clear();
            foreach (string item in _Groups.Values)
            {
                permission = GetGroupPermissionPages(item, PageID);
                if (permission)
                {
                    break;
                }
            }
            if (permission == false)
            {
                permission = GetUserPermissionPages(_id, PageID);

            }
            return permission;
        }
        public bool DoesUserHasFacility(string FacilityID)
        {
            int CNT = 0;
            // Dim dr As DataRow
          
            if (FacilityID.ToString().Contains("&"))
            {
                FacilityID = FacilityID.ToString().Replace("&", "");
            }
            string qrystr = $"select *  from facility_control a where  ((a.user_id={_id} AND a.FACLILTY_ID='{FacilityID}') or (a.FACLILTY_ID in (select c.FACLILTY_ID from group_users b ,facility_control c where b.group_id=c.group_id and c.FACLILTY_ID='{FacilityID}' and b.user_table_id={_id}))";
            DataTable dt = (DataTable)connection.RunQuery(qrystr);
            if (dt.Rows.Count > 0)
            {



                return true;
            }
            else
            {

                qrystr = $"SELECT distinct  *  FROM  FACILITY_CONTROL a,FACILITY_CONTROL_DET d  WHERE  a.ID = d.FACILITY_CONTROL_ID and group_id is not null and a.group_id in (select g.group_id from group_users g where g.user_table_id={_id}) and d.facility_name='{FacilityID}'";
                 dt = (DataTable)connection.RunQuery(qrystr);
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
       // public KocConfig.cls_Priv_and_Entit UserPrivileges { get; set; }
    }
}