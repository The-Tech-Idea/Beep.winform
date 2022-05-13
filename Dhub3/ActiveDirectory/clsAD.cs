using System;
using System.Collections.Generic;
using System.Data;
using System.DirectoryServices;
using System.Linq;


namespace KocConfig.ActiveDirctory
{
    public class clsAD
    {

        public List<ActiveDirUser_cls> Listofusers { get; set; } = new List<ActiveDirUser_cls>();

        public DataSet GetUserInfo(string KOCID)
        {
            Listofusers = new List<ActiveDirUser_cls>();
            var dt = new DataTable();

            DataColumn dc;

            dc = new DataColumn("DisplayName");

            dt.Columns.Add(dc);

            dc = new DataColumn("DomainID");

            dt.Columns.Add(dc);

            dc = new DataColumn("KOCID");

            dt.Columns.Add(dc);

            dc = new DataColumn("MailID");

            dt.Columns.Add(dc);

            dc = new DataColumn("Location");

            dt.Columns.Add(dc);

            dc = new DataColumn("Building");

            dt.Columns.Add(dc);

            dc = new DataColumn("Room No");

            dt.Columns.Add(dc);

            dc = new DataColumn("TeamCode");

            dt.Columns.Add(dc);

            dc = new DataColumn("Area");

            dt.Columns.Add(dc);

            dc = new DataColumn("Directorate");

            dt.Columns.Add(dc);

            dc = new DataColumn("Group");

            dt.Columns.Add(dc);

            dc = new DataColumn("title");

            dt.Columns.Add(dc);

            dc = new DataColumn("TelephoneNo");

            dt.Columns.Add(dc);

            dc = new DataColumn("FullAddress");

            dt.Columns.Add(dc);

            var search = new DirectorySearcher();

            SearchResultCollection resultC;
            SearchResult result;

            search.Filter = "(&(objectClass=user)(extensionattribute1=" + KOCID + "))"; // 

            search.PropertiesToLoad.Add("DisplayName");

            search.PropertiesToLoad.Add("SAMAccountName");

            search.PropertiesToLoad.Add("extensionattribute1");

            search.PropertiesToLoad.Add("mail");

            search.PropertiesToLoad.Add("extensionattribute4");

            search.PropertiesToLoad.Add("extensionattribute5");

            search.PropertiesToLoad.Add("extensionattribute6");

            search.PropertiesToLoad.Add("extensionattribute7");

            search.PropertiesToLoad.Add("extensionattribute8");

            search.PropertiesToLoad.Add("extensionattribute9");

            search.PropertiesToLoad.Add("extensionattribute10");

            search.PropertiesToLoad.Add("title");

            search.PropertiesToLoad.Add("telephoneNumber");

            search.PropertiesToLoad.Add("streetAddress");

            resultC = search.FindAll();

            if (resultC is null)
            {

                var _dr = dt.NewRow();
                _dr["DisplayName"] = "";

                _dr["DomainID"] = "";

                _dr["KOCID"] = "";

                _dr["MailID"] = "";

                _dr["Location"] = "";

                _dr["Building"] = "";

                _dr["Room No"] = "";

                _dr["TeamCode"] = "";

                _dr["Area"] = "";

                _dr["Directorate"] = "";

                _dr["Group"] = "";

                _dr["title"] = "";

                _dr["TelephoneNo"] = "";

                _dr["FullAddress"] = "";

                dt.Rows.Add(_dr);
            }
            else
            {

                for (int i = 0, loopTo = resultC.Count - 1; i <= loopTo; i++)
                {
                    result = resultC[i];

                    var dr = dt.NewRow();
                    // ---------------------------------------------
                    var acx = new ActiveDirUser_cls();
                    try
                    {
                        if (result.Properties["DisplayName"] !=null)
                        {
                            acx.DisplayName = result.Properties["DisplayName"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        acx.DomainID = result.Properties["SAMAccountName"][0].ToString();
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        acx.KOCID = result.Properties["extensionattribute1"][0].ToString();
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        acx.MailID = result.Properties["mail"][0].ToString();
                    }
                    catch (Exception ex)
                    {
                    }


                    try
                    {
                        if (result.Properties["extensionattribute4"] !=null)
                        {
                            acx.Location = result.Properties["extensionattribute4"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }



                    try
                    {
                        if (result.Properties["extensionattribute5"] !=null)
                        {
                            acx.Building = result.Properties["extensionattribute5"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }



                    try
                    {
                        if (result.Properties["extensionattribute6"] !=null)
                        {
                            acx.Room_No = result.Properties["extensionattribute6"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }


                    try
                    {
                        if (result.Properties["extensionattribute7"] !=null)
                        {
                            acx.TeamCode = result.Properties["extensionattribute7"][0].ToString();

                        }
                    }
                    catch (Exception ex)
                    {
                    }


                    try
                    {
                        if (result.Properties["extensionattribute8"] !=null)
                        {
                            acx.Area = result.Properties["extensionattribute8"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["extensionattribute9"] !=null)
                        {
                            acx.Directorate = result.Properties["extensionattribute9"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["extensionattribute10"] !=null)
                        {
                            acx.Group = result.Properties["extensionattribute10"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["title"] !=null)
                        {
                            acx.title = result.Properties["title"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["telephoneNumber"] !=null)
                        {
                            acx.TelephoneNo = result.Properties["telephoneNumber"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["streetAddress"] !=null)
                        {
                            acx.FullAddress = result.Properties["streetAddress"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    if (acx.TeamCode.StartsWith("S"))
                    {
                        acx.Area = "SK";

                    }
                    if (acx.TeamCode.StartsWith("N"))
                    {
                        acx.Area = "NK";

                    }
                    if (acx.TeamCode.StartsWith("W"))
                    {
                        acx.Area = "WK";

                    }
                    if (acx.TeamCode.StartsWith("P"))
                    {
                        acx.Area = "ALL";

                    }
                    Listofusers.Add(acx);
                    // ---------------------------------------------
                    try
                    {
                        if (result.Properties["DisplayName"] !=null)
                        {
                            dr["DisplayName"] = result.Properties["DisplayName"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        dr["DomainID"] = result.Properties["SAMAccountName"][0].ToString();
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        dr["KOCID"] = result.Properties["extensionattribute1"][0].ToString();
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        dr["MailID"] = result.Properties["mail"][0].ToString();
                    }
                    catch (Exception ex)
                    {
                    }


                    try
                    {
                        if (result.Properties["extensionattribute4"] !=null)
                        {
                            dr["Location"] = result.Properties["extensionattribute4"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }



                    try
                    {
                        if (result.Properties["extensionattribute5"] !=null)
                        {
                            dr["Building"] = result.Properties["extensionattribute5"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }



                    try
                    {
                        if (result.Properties["extensionattribute6"] !=null)
                        {
                            dr["Room No"] = result.Properties["extensionattribute6"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }


                    try
                    {
                        if (result.Properties["extensionattribute7"] !=null)
                        {
                            dr["TeamCode"] = result.Properties["extensionattribute7"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }


                    try
                    {
                        if (result.Properties["extensionattribute8"] !=null)
                        {
                            dr["Area"] = result.Properties["extensionattribute8"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["extensionattribute9"] !=null)
                        {
                            dr["Directorate"] = result.Properties["extensionattribute9"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["extensionattribute10"] !=null)
                        {
                            dr["Group"] = result.Properties["extensionattribute10"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["title"] !=null)
                        {
                            dr["title"] = result.Properties["title"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["telephoneNumber"] !=null)
                        {
                            dr["TelephoneNo"] = result.Properties["telephoneNumber"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["streetAddress"] !=null)
                        {
                            dr["FullAddress"] = result.Properties["streetAddress"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    if (dr["TeamCode"].ToString().StartsWith("S"))
                    {
                        dr["Area"] = "SK";

                    }
                    if (dr["TeamCode"].ToString().StartsWith("N"))
                    {
                        dr["Area"] = "NK";

                    }
                    if (dr["TeamCode"].ToString().StartsWith("W"))
                    {
                        dr["Area"] = "WK";

                    }
                    if (dr["TeamCode"].ToString().StartsWith("P"))
                    {
                        dr["Area"] = "ALL";

                    }
                    dt.Rows.Add(dr);
                }
            }
            var ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;

            // -------------------------------

        }
        public List<ActiveDirUser_cls> GetUserInfoGetClass(string KOCID)
        {
            Listofusers = new List<ActiveDirUser_cls>();


            var search = new DirectorySearcher();

            SearchResultCollection resultC;
            SearchResult result;

            search.Filter = "(&(objectClass=user)(extensionattribute1=" + KOCID + "))"; // 

            search.PropertiesToLoad.Add("DisplayName");

            search.PropertiesToLoad.Add("SAMAccountName");

            search.PropertiesToLoad.Add("extensionattribute1");

            search.PropertiesToLoad.Add("mail");

            search.PropertiesToLoad.Add("extensionattribute4");

            search.PropertiesToLoad.Add("extensionattribute5");

            search.PropertiesToLoad.Add("extensionattribute6");

            search.PropertiesToLoad.Add("extensionattribute7");

            search.PropertiesToLoad.Add("extensionattribute8");

            search.PropertiesToLoad.Add("extensionattribute9");

            search.PropertiesToLoad.Add("extensionattribute10");

            search.PropertiesToLoad.Add("title");

            search.PropertiesToLoad.Add("telephoneNumber");

            search.PropertiesToLoad.Add("streetAddress");

            resultC = search.FindAll();

            if (resultC is null)
            {
            }

            else
            {

                for (int i = 0, loopTo = resultC.Count - 1; i <= loopTo; i++)
                {
                    result = resultC[i];


                    // ---------------------------------------------
                    var acx = new ActiveDirUser_cls();
                    try
                    {
                        if (result.Properties["DisplayName"] !=null)
                        {
                            acx.DisplayName = result.Properties["DisplayName"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        acx.DomainID = result.Properties["SAMAccountName"][0].ToString();
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        acx.KOCID = result.Properties["extensionattribute1"][0].ToString();
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        acx.MailID = result.Properties["mail"][0].ToString();
                    }
                    catch (Exception ex)
                    {
                    }


                    try
                    {
                        if (result.Properties["extensionattribute4"] !=null)
                        {
                            acx.Location = result.Properties["extensionattribute4"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }



                    try
                    {
                        if (result.Properties["extensionattribute5"] !=null)
                        {
                            acx.Building = result.Properties["extensionattribute5"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }



                    try
                    {
                        if (result.Properties["extensionattribute6"] !=null)
                        {
                            acx.Room_No = result.Properties["extensionattribute6"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }


                    try
                    {
                        if (result.Properties["extensionattribute7"] !=null)
                        {
                            acx.TeamCode = result.Properties["extensionattribute7"][0].ToString();

                        }
                    }
                    catch (Exception ex)
                    {
                    }


                    try
                    {
                        if (result.Properties["extensionattribute8"] !=null)
                        {
                            acx.Area = result.Properties["extensionattribute8"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["extensionattribute9"] !=null)
                        {
                            acx.Directorate = result.Properties["extensionattribute9"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["extensionattribute10"] !=null)
                        {
                            acx.Group = result.Properties["extensionattribute10"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["title"] !=null)
                        {
                            acx.title = result.Properties["title"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["telephoneNumber"] !=null)
                        {
                            acx.TelephoneNo = result.Properties["telephoneNumber"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["streetAddress"] !=null)
                        {
                            acx.FullAddress = result.Properties["streetAddress"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    if (acx.TeamCode.StartsWith("S"))
                    {
                        acx.Area = "SK";

                    }
                    if (acx.TeamCode.StartsWith("N"))
                    {
                        acx.Area = "NK";

                    }
                    if (acx.TeamCode.StartsWith("W"))
                    {
                        acx.Area = "WK";

                    }
                    if (acx.TeamCode.StartsWith("P"))
                    {
                        acx.Area = "ALL";

                    }
                    Listofusers.Add(acx);
                    // ---------------------------------------------

                }
            }

            return Listofusers;

            // -------------------------------

        }
        public DataSet GetUserInfoByDomianID(string DomainID)
        {
            Listofusers = new List<ActiveDirUser_cls>();
            var dt = new DataTable();

            var dr = dt.NewRow();

            DataColumn dc;

            dc = new DataColumn("DisplayName");

            dt.Columns.Add(dc);

            dc = new DataColumn("DomainID");

            dt.Columns.Add(dc);

            dc = new DataColumn("KOCID");

            dt.Columns.Add(dc);

            dc = new DataColumn("MailID");

            dt.Columns.Add(dc);

            dc = new DataColumn("Location");

            dt.Columns.Add(dc);

            dc = new DataColumn("Building");

            dt.Columns.Add(dc);

            dc = new DataColumn("Room No");

            dt.Columns.Add(dc);

            dc = new DataColumn("TeamCode");

            dt.Columns.Add(dc);

            dc = new DataColumn("Area");

            dt.Columns.Add(dc);

            dc = new DataColumn("Directorate");

            dt.Columns.Add(dc);

            dc = new DataColumn("Group");

            dt.Columns.Add(dc);

            dc = new DataColumn("title");

            dt.Columns.Add(dc);

            dc = new DataColumn("TelephoneNo");

            dt.Columns.Add(dc);

            dc = new DataColumn("FullAddress");

            dt.Columns.Add(dc);

            var search = new DirectorySearcher();

            SearchResult result;

            search.Filter = "(&(objectClass=user)(SAMAccountName=" + DomainID + "))"; // 

            search.PropertiesToLoad.Add("DisplayName");

            search.PropertiesToLoad.Add("SAMAccountName");

            search.PropertiesToLoad.Add("extensionattribute1");

            search.PropertiesToLoad.Add("mail");

            search.PropertiesToLoad.Add("extensionattribute4");

            search.PropertiesToLoad.Add("extensionattribute5");

            search.PropertiesToLoad.Add("extensionattribute6");

            search.PropertiesToLoad.Add("extensionattribute7");

            search.PropertiesToLoad.Add("extensionattribute8");

            search.PropertiesToLoad.Add("extensionattribute9");

            search.PropertiesToLoad.Add("extensionattribute10");

            search.PropertiesToLoad.Add("title");

            search.PropertiesToLoad.Add("telephoneNumber");

            search.PropertiesToLoad.Add("streetAddress");

            result = search.FindOne();

            if (result is null)
            {


                dr["DisplayName"] = "";

                dr["DomainID"] = "";

                dr["KOCID"] = "";

                dr["MailID"] = "";

                dr["Location"] = "";

                dr["Building"] = "";

                dr["Room No"] = "";

                dr["TeamCode"] = "";

                dr["Area"] = "";

                dr["Directorate"] = "";

                dr["Group"] = "";

                dr["title"] = "";

                dr["TelephoneNo"] = "";

                dr["FullAddress"] = "";
            }





            else
            {

                try
                {
                    if (result.Properties["DisplayName"] !=null)
                    {
                        dr["DisplayName"] = result.Properties["DisplayName"][0].ToString();
                    }
                }
                catch (Exception ex)
                {
                }

                try
                {
                    dr["DomainID"] = result.Properties["SAMAccountName"][0].ToString();
                }
                catch (Exception ex)
                {
                }

                try
                {
                    dr["KOCID"] = result.Properties["extensionattribute1"][0].ToString();
                }
                catch (Exception ex)
                {
                }

                try
                {
                    dr["MailID"] = result.Properties["mail"][0].ToString();
                }
                catch (Exception ex)
                {
                }


                try
                {
                    if (result.Properties["extensionattribute4"] !=null)
                    {
                        dr["Location"] = result.Properties["extensionattribute4"][0].ToString();
                    }
                }
                catch (Exception ex)
                {
                }



                try
                {
                    if (result.Properties["extensionattribute5"] !=null)
                    {
                        dr["Building"] = result.Properties["extensionattribute5"][0].ToString();
                    }
                }
                catch (Exception ex)
                {
                }



                try
                {
                    if (result.Properties["extensionattribute6"] !=null)
                    {
                        dr["Room No"] = result.Properties["extensionattribute6"][0].ToString();
                    }
                }
                catch (Exception ex)
                {
                }


                try
                {
                    if (result.Properties["extensionattribute7"] !=null)
                    {
                        dr["TeamCode"] = result.Properties["extensionattribute7"][0].ToString();
                    }
                }
                catch (Exception ex)
                {
                }


                try
                {
                    if (result.Properties["extensionattribute8"] !=null)
                    {
                        dr["Area"] = result.Properties["extensionattribute8"][0].ToString();
                    }
                }
                catch (Exception ex)
                {
                }

                try
                {
                    if (result.Properties["extensionattribute9"] !=null)
                    {
                        dr["Directorate"] = result.Properties["extensionattribute9"][0].ToString();
                    }
                }
                catch (Exception ex)
                {
                }

                try
                {
                    if (result.Properties["extensionattribute10"] !=null)
                    {
                        dr["Group"] = result.Properties["extensionattribute10"][0].ToString();
                    }
                }
                catch (Exception ex)
                {
                }

                try
                {
                    if (result.Properties["title"] !=null)
                    {
                        dr["title"] = result.Properties["title"][0].ToString();
                    }
                }
                catch (Exception ex)
                {
                }

                try
                {
                    if (result.Properties["telephoneNumber"] !=null)
                    {
                        dr["TelephoneNo"] = result.Properties["telephoneNumber"][0].ToString();
                    }
                }
                catch (Exception ex)
                {
                }

                try
                {
                    if (result.Properties["streetAddress"] !=null)
                    {
                        dr["FullAddress"] = result.Properties["streetAddress"][0].ToString();
                    }
                }
                catch (Exception ex)
                {
                }

                if (dr["TeamCode"].ToString().StartsWith("S"))
                {
                    dr["Area"] = "SK";

                }
                if (dr["TeamCode"].ToString().StartsWith("N"))
                {
                    dr["Area"] = "NK";

                }
                if (dr["TeamCode"].ToString().StartsWith("W"))
                {
                    dr["Area"] = "WK";

                }
                if (dr["TeamCode"].ToString().StartsWith("P"))
                {
                    dr["Area"] = "ALL";

                }

                dt.Rows.Add(dr);

            }
            var ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;

        }
        public DataSet GetAllKocUsers()
        {
            Listofusers = new List<ActiveDirUser_cls>();
            var dt = new DataTable();

            DataColumn dc;

            dc = new DataColumn("DisplayName");

            dt.Columns.Add(dc);

            dc = new DataColumn("DomainID");

            dt.Columns.Add(dc);

            dc = new DataColumn("KOCID");

            dt.Columns.Add(dc);

            dc = new DataColumn("MailID");

            dt.Columns.Add(dc);

            dc = new DataColumn("Location");

            dt.Columns.Add(dc);

            dc = new DataColumn("Building");

            dt.Columns.Add(dc);

            dc = new DataColumn("Room No");

            dt.Columns.Add(dc);

            dc = new DataColumn("TeamCode");

            dt.Columns.Add(dc);

            dc = new DataColumn("Area");

            dt.Columns.Add(dc);

            dc = new DataColumn("Directorate");

            dt.Columns.Add(dc);

            dc = new DataColumn("Group");

            dt.Columns.Add(dc);

            dc = new DataColumn("title");

            dt.Columns.Add(dc);

            dc = new DataColumn("TelephoneNo");

            dt.Columns.Add(dc);

            dc = new DataColumn("FullAddress");

            dt.Columns.Add(dc);

            var search = new DirectorySearcher();

            SearchResultCollection resultC;
            SearchResult result;

            // search.Filter = "(&(objectClass=user)(extensionattribute7=" & Team_Code & "))" '

            search.PropertiesToLoad.Add("DisplayName");

            search.PropertiesToLoad.Add("SAMAccountName");

            search.PropertiesToLoad.Add("extensionattribute1");

            search.PropertiesToLoad.Add("mail");

            search.PropertiesToLoad.Add("extensionattribute4");

            search.PropertiesToLoad.Add("extensionattribute5");

            search.PropertiesToLoad.Add("extensionattribute6");

            search.PropertiesToLoad.Add("extensionattribute7");

            search.PropertiesToLoad.Add("extensionattribute8");

            search.PropertiesToLoad.Add("extensionattribute9");

            search.PropertiesToLoad.Add("extensionattribute10");

            search.PropertiesToLoad.Add("title");

            search.PropertiesToLoad.Add("telephoneNumber");

            search.PropertiesToLoad.Add("streetAddress");

            resultC = search.FindAll();

            if (resultC is null)
            {

                var _dr = dt.NewRow();
                _dr["DisplayName"] = "";

                _dr["DomainID"] = "";

                _dr["KOCID"] = "";

                _dr["MailID"] = "";

                _dr["Location"] = "";

                _dr["Building"] = "";

                _dr["Room No"] = "";

                _dr["TeamCode"] = "";

                _dr["Area"] = "";

                _dr["Directorate"] = "";

                _dr["Group"] = "";

                _dr["title"] = "";

                _dr["TelephoneNo"] = "";

                _dr["FullAddress"] = "";

                dt.Rows.Add(_dr);
            }
            else
            {

                for (int i = 0, loopTo = resultC.Count - 1; i <= loopTo; i++)
                {
                    result = resultC[i];

                    var dr = dt.NewRow();

                    try
                    {
                        if (result.Properties["DisplayName"] !=null)
                        {
                            dr["DisplayName"] = result.Properties["DisplayName"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        dr["DomainID"] = result.Properties["SAMAccountName"][0].ToString();
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        dr["KOCID"] = result.Properties["extensionattribute1"][0].ToString();
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        dr["MailID"] = result.Properties["mail"][0].ToString();
                    }
                    catch (Exception ex)
                    {
                    }


                    try
                    {
                        if (result.Properties["extensionattribute4"] !=null)
                        {
                            dr["Location"] = result.Properties["extensionattribute4"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }



                    try
                    {
                        if (result.Properties["extensionattribute5"] !=null)
                        {
                            dr["Building"] = result.Properties["extensionattribute5"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }



                    try
                    {
                        if (result.Properties["extensionattribute6"] !=null)
                        {
                            dr["Room No"] = result.Properties["extensionattribute6"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }


                    try
                    {
                        if (result.Properties["extensionattribute7"] !=null)
                        {
                            dr["TeamCode"] = result.Properties["extensionattribute7"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }


                    try
                    {
                        if (result.Properties["extensionattribute8"] !=null)
                        {
                            dr["Area"] = result.Properties["extensionattribute8"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["extensionattribute9"] !=null)
                        {
                            dr["Directorate"] = result.Properties["extensionattribute9"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["extensionattribute10"] !=null)
                        {
                            dr["Group"] = result.Properties["extensionattribute10"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["title"] !=null)
                        {
                            dr["title"] = result.Properties["title"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["telephoneNumber"] !=null)
                        {
                            dr["TelephoneNo"] = result.Properties["telephoneNumber"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["streetAddress"] !=null)
                        {
                            dr["FullAddress"] = result.Properties["streetAddress"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    if (dr["TeamCode"].ToString().StartsWith("S"))
                    {
                        dr["Area"] = "SK";

                    }
                    if (dr["TeamCode"].ToString().StartsWith("N"))
                    {
                        dr["Area"] = "NK";

                    }
                    if (dr["TeamCode"].ToString().StartsWith("W"))
                    {
                        dr["Area"] = "WK";

                    }
                    if (dr["TeamCode"].ToString().StartsWith("P"))
                    {
                        dr["Area"] = "ALL";

                    }
                    dt.Rows.Add(dr);
                }
            }
            var ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;

        }
        public DataSet GetKOCTeamUsers(string Team_Code)
        {
            Listofusers = new List<ActiveDirUser_cls>();
            var dt = new DataTable();

            DataColumn dc;

            dc = new DataColumn("DisplayName");

            dt.Columns.Add(dc);

            dc = new DataColumn("DomainID");

            dt.Columns.Add(dc);

            dc = new DataColumn("KOCID");

            dt.Columns.Add(dc);

            dc = new DataColumn("MailID");

            dt.Columns.Add(dc);

            dc = new DataColumn("Location");

            dt.Columns.Add(dc);

            dc = new DataColumn("Building");

            dt.Columns.Add(dc);

            dc = new DataColumn("Room No");

            dt.Columns.Add(dc);

            dc = new DataColumn("TeamCode");

            dt.Columns.Add(dc);

            dc = new DataColumn("Area");

            dt.Columns.Add(dc);

            dc = new DataColumn("Directorate");

            dt.Columns.Add(dc);

            dc = new DataColumn("Group");

            dt.Columns.Add(dc);

            dc = new DataColumn("title");

            dt.Columns.Add(dc);

            dc = new DataColumn("TelephoneNo");

            dt.Columns.Add(dc);

            dc = new DataColumn("FullAddress");

            dt.Columns.Add(dc);

            var search = new DirectorySearcher();

            SearchResultCollection resultC;
            SearchResult result;

            search.Filter = "(&(objectClass=user)(extensionattribute7 = " + Team_Code + ") Then)"; // 

            search.PropertiesToLoad.Add("DisplayName");

            search.PropertiesToLoad.Add("SAMAccountName");

            search.PropertiesToLoad.Add("extensionattribute1");

            search.PropertiesToLoad.Add("mail");

            search.PropertiesToLoad.Add("extensionattribute4");

            search.PropertiesToLoad.Add("extensionattribute5");

            search.PropertiesToLoad.Add("extensionattribute6");

            search.PropertiesToLoad.Add("extensionattribute7");

            search.PropertiesToLoad.Add("extensionattribute8");

            search.PropertiesToLoad.Add("extensionattribute9");

            search.PropertiesToLoad.Add("extensionattribute10");

            search.PropertiesToLoad.Add("title");

            search.PropertiesToLoad.Add("telephoneNumber");

            search.PropertiesToLoad.Add("streetAddress");

            resultC = search.FindAll();

            if (resultC is null)
            {

                var _dr = dt.NewRow();
                _dr["DisplayName"] = "";

                _dr["DomainID"] = "";

                _dr["KOCID"] = "";

                _dr["MailID"] = "";

                _dr["Location"] = "";

                _dr["Building"] = "";

                _dr["Room No"] = "";

                _dr["TeamCode"] = "";

                _dr["Area"] = "";

                _dr["Directorate"] = "";

                _dr["Group"] = "";

                _dr["title"] = "";

                _dr["TelephoneNo"] = "";

                _dr["FullAddress"] = "";

                dt.Rows.Add(_dr);
            }
            else
            {

                for (int i = 0, loopTo = resultC.Count - 1; i <= loopTo; i++)
                {
                    result = resultC[i];

                    var dr = dt.NewRow();
                    // ---------------------------------------------
                    var acx = new ActiveDirUser_cls();
                    try
                    {
                        if (result.Properties["DisplayName"] !=null)
                        {
                            acx.DisplayName = result.Properties["DisplayName"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        acx.DomainID = result.Properties["SAMAccountName"][0].ToString();
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        acx.KOCID = result.Properties["extensionattribute1"][0].ToString();
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        acx.MailID = result.Properties["mail"][0].ToString();
                    }
                    catch (Exception ex)
                    {
                    }


                    try
                    {
                        if (result.Properties["extensionattribute4"] !=null)
                        {
                            acx.Location = result.Properties["extensionattribute4"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }



                    try
                    {
                        if (result.Properties["extensionattribute5"] !=null)
                        {
                            acx.Building = result.Properties["extensionattribute5"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }



                    try
                    {
                        if (result.Properties["extensionattribute6"] !=null)
                        {
                            acx.Room_No = result.Properties["extensionattribute6"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }


                    try
                    {
                        if (result.Properties["extensionattribute7"] !=null)
                        {
                            acx.TeamCode = result.Properties["extensionattribute7"][0].ToString();

                        }
                    }
                    catch (Exception ex)
                    {
                    }


                    try
                    {
                        if (result.Properties["extensionattribute8"] !=null)
                        {
                            acx.Area = result.Properties["extensionattribute8"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["extensionattribute9"] !=null)
                        {
                            acx.Directorate = result.Properties["extensionattribute9"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["extensionattribute10"] !=null)
                        {
                            acx.Group = result.Properties["extensionattribute10"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["title"] !=null)
                        {
                            acx.title = result.Properties["title"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["telephoneNumber"] !=null)
                        {
                            acx.TelephoneNo = result.Properties["telephoneNumber"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["streetAddress"] !=null)
                        {
                            acx.FullAddress = result.Properties["streetAddress"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    if (acx.TeamCode.StartsWith("S"))
                    {
                        acx.Area = "SK";

                    }
                    if (acx.TeamCode.StartsWith("N"))
                    {
                        acx.Area = "NK";

                    }
                    if (acx.TeamCode.StartsWith("W"))
                    {
                        acx.Area = "WK";

                    }
                    if (acx.TeamCode.StartsWith("P"))
                    {
                        acx.Area = "ALL";

                    }
                    Listofusers.Add(acx);
                    // ---------------------------------------------
                    try
                    {
                        if (result.Properties["DisplayName"] !=null)
                        {
                            dr["DisplayName"] = result.Properties["DisplayName"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        dr["DomainID"] = result.Properties["SAMAccountName"][0].ToString();
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        dr["KOCID"] = result.Properties["extensionattribute1"][0].ToString();
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        dr["MailID"] = result.Properties["mail"][0].ToString();
                    }
                    catch (Exception ex)
                    {
                    }


                    try
                    {
                        if (result.Properties["extensionattribute4"] !=null)
                        {
                            dr["Location"] = result.Properties["extensionattribute4"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }



                    try
                    {
                        if (result.Properties["extensionattribute5"] !=null)
                        {
                            dr["Building"] = result.Properties["extensionattribute5"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }



                    try
                    {
                        if (result.Properties["extensionattribute6"] !=null)
                        {
                            dr["Room No"] = result.Properties["extensionattribute6"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }


                    try
                    {
                        if (result.Properties["extensionattribute7"] !=null)
                        {
                            dr["TeamCode"] = result.Properties["extensionattribute7"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }


                    try
                    {
                        if (result.Properties["extensionattribute8"] !=null)
                        {
                            dr["Area"] = result.Properties["extensionattribute8"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["extensionattribute9"] !=null)
                        {
                            dr["Directorate"] = result.Properties["extensionattribute9"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["extensionattribute10"] !=null)
                        {
                            dr["Group"] = result.Properties["extensionattribute10"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["title"] !=null)
                        {
                            dr["title"] = result.Properties["title"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["telephoneNumber"] !=null)
                        {
                            dr["TelephoneNo"] = result.Properties["telephoneNumber"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["streetAddress"] !=null)
                        {
                            dr["FullAddress"] = result.Properties["streetAddress"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    if (dr["TeamCode"].ToString().StartsWith("S"))
                    {
                        dr["Area"] = "SK";

                    }
                    if (dr["TeamCode"].ToString().StartsWith("N"))
                    {
                        dr["Area"] = "NK";

                    }
                    if (dr["TeamCode"].ToString().StartsWith("W"))
                    {
                        dr["Area"] = "WK";

                    }
                    if (dr["TeamCode"].ToString().StartsWith("P"))
                    {
                        dr["Area"] = "ALL";

                    }
                    dt.Rows.Add(dr);
                }
            }
            var ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;

        }
        public List<ActiveDirUser_cls> GetEmpUnderCode(string Org_Code)
        {
            Listofusers = new List<ActiveDirUser_cls>();
            // Dim dt As New DataTable

            // Dim dc As DataColumn

            // dc = New DataColumn("DisplayName")

            // dt.Columns.Add(dc)

            // dc = New DataColumn("DomainID")

            // dt.Columns.Add(dc)

            // dc = New DataColumn("KOCID")

            // dt.Columns.Add(dc)

            // dc = New DataColumn("MailID")

            // dt.Columns.Add(dc)

            // dc = New DataColumn("Location")

            // dt.Columns.Add(dc)

            // dc = New DataColumn("Building")

            // dt.Columns.Add(dc)

            // dc = New DataColumn("Room No")

            // dt.Columns.Add(dc)

            // dc = New DataColumn("TeamCode")

            // dt.Columns.Add(dc)

            // dc = New DataColumn("Area")

            // dt.Columns.Add(dc)

            // dc = New DataColumn("Directorate")

            // dt.Columns.Add(dc)

            // dc = New DataColumn("Group")

            // dt.Columns.Add(dc)

            // dc = New DataColumn("title")

            // dt.Columns.Add(dc)

            // dc = New DataColumn("TelephoneNo")

            // dt.Columns.Add(dc)

            // dc = New DataColumn("FullAddress")

            // dt.Columns.Add(dc)

            var search = new DirectorySearcher();

            SearchResultCollection resultC;
            SearchResult result;

            search.Filter = "(&(objectClass=user)(extensionattribute7=" + Org_Code + "))"; // 

            search.PropertiesToLoad.Add("DisplayName");

            search.PropertiesToLoad.Add("SAMAccountName");

            search.PropertiesToLoad.Add("extensionattribute1");

            search.PropertiesToLoad.Add("mail");

            search.PropertiesToLoad.Add("extensionattribute4");

            search.PropertiesToLoad.Add("extensionattribute5");

            search.PropertiesToLoad.Add("extensionattribute6");

            search.PropertiesToLoad.Add("extensionattribute7");

            search.PropertiesToLoad.Add("extensionattribute8");

            search.PropertiesToLoad.Add("extensionattribute9");

            search.PropertiesToLoad.Add("extensionattribute10");

            search.PropertiesToLoad.Add("title");

            search.PropertiesToLoad.Add("telephoneNumber");

            search.PropertiesToLoad.Add("streetAddress");

            resultC = search.FindAll();

            if (resultC is null)
            {
            }

            // Dim _dr As DataRow = dt.NewRow
            // _dr("DisplayName") = ""

            // _dr("DomainID") = ""

            // _dr("KOCID") = ""

            // _dr("MailID") = ""

            // _dr("Location") = ""

            // _dr("Building") = ""

            // _dr("Room No") = ""

            // _dr("TeamCode") = ""

            // _dr("Area") = ""

            // _dr("Directorate") = ""

            // _dr("Group") = ""

            // _dr("title") = ""

            // _dr("TelephoneNo") = ""

            // _dr("FullAddress") = ""

            // dt.Rows.Add(_dr)
            else if (resultC.Count > 0)
            {
                for (int i = 0, loopTo = resultC.Count - 1; i <= loopTo; i++)
                {
                    result = resultC[i];

                    // Dim dr As DataRow = dt.NewRow
                    // ---------------------------------------------
                    var acx = new ActiveDirUser_cls();
                    try
                    {
                        if (result.Properties["DisplayName"] !=null)
                        {
                            acx.DisplayName = result.Properties["DisplayName"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        acx.DomainID = result.Properties["SAMAccountName"][0].ToString();
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        acx.KOCID = result.Properties["extensionattribute1"][0].ToString();
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        acx.MailID = result.Properties["mail"][0].ToString();
                    }
                    catch (Exception ex)
                    {
                    }


                    try
                    {
                        if (result.Properties["extensionattribute4"] !=null)
                        {
                            acx.Location = result.Properties["extensionattribute4"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }



                    try
                    {
                        if (result.Properties["extensionattribute5"] !=null)
                        {
                            acx.Building = result.Properties["extensionattribute5"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }



                    try
                    {
                        if (result.Properties["extensionattribute6"] !=null)
                        {
                            acx.Room_No = result.Properties["extensionattribute6"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }


                    try
                    {
                        if (result.Properties["extensionattribute7"] !=null)
                        {
                            acx.TeamCode = result.Properties["extensionattribute7"][0].ToString();

                        }
                    }
                    catch (Exception ex)
                    {
                    }


                    try
                    {
                        if (result.Properties["extensionattribute8"] !=null)
                        {
                            acx.Area = result.Properties["extensionattribute8"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["extensionattribute9"] !=null)
                        {
                            acx.Directorate = result.Properties["extensionattribute9"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["extensionattribute10"] !=null)
                        {
                            acx.Group = result.Properties["extensionattribute10"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["title"] !=null)
                        {
                            acx.title = result.Properties["title"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["telephoneNumber"] !=null)
                        {
                            acx.TelephoneNo = result.Properties["telephoneNumber"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["streetAddress"] !=null)
                        {
                            acx.FullAddress = result.Properties["streetAddress"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    if (acx.TeamCode.StartsWith("S"))
                    {
                        acx.Area = "SK";

                    }
                    if (acx.TeamCode.StartsWith("N"))
                    {
                        acx.Area = "NK";

                    }
                    if (acx.TeamCode.StartsWith("W"))
                    {
                        acx.Area = "WK";

                    }
                    if (acx.TeamCode.StartsWith("P"))
                    {
                        acx.Area = "ALL";

                    }
                    Listofusers.Add(acx);
                    // ---------------------------------------------
                    // Try
                    // If Not result.Properties("DisplayName") Is Nothing Then
                    // dr("DisplayName") = result.Properties("DisplayName")(0).ToString
                    // End If
                    // Catch ex As Exception
                    // End Try

                    // Try
                    // dr("DomainID") = result.Properties("SAMAccountName")(0).ToString
                    // Catch ex As Exception
                    // End Try

                    // Try
                    // dr("KOCID") = result.Properties("extensionattribute1")(0).ToString
                    // Catch ex As Exception
                    // End Try

                    // Try
                    // dr("MailID") = result.Properties("mail")(0).ToString
                    // Catch ex As Exception
                    // End Try


                    // Try
                    // If Not result.Properties("extensionattribute4") Is Nothing Then
                    // dr("Location") = result.Properties("extensionattribute4")(0).ToString
                    // End If
                    // Catch ex As Exception
                    // End Try



                    // Try
                    // If Not result.Properties("extensionattribute5") Is Nothing Then
                    // dr("Building") = result.Properties("extensionattribute5")(0).ToString
                    // End If
                    // Catch ex As Exception
                    // End Try



                    // Try
                    // If Not result.Properties("extensionattribute6") Is Nothing Then
                    // dr("Room No") = result.Properties("extensionattribute6")(0).ToString
                    // End If
                    // Catch ex As Exception
                    // End Try


                    // Try
                    // If Not result.Properties("extensionattribute7") Is Nothing Then
                    // dr("TeamCode") = result.Properties("extensionattribute7")(0).ToString
                    // End If
                    // Catch ex As Exception
                    // End Try


                    // Try
                    // If Not result.Properties("extensionattribute8") Is Nothing Then
                    // dr("Area") = result.Properties("extensionattribute8")(0).ToString
                    // End If
                    // Catch ex As Exception
                    // End Try

                    // Try
                    // If Not result.Properties("extensionattribute9") Is Nothing Then
                    // dr("Directorate") = result.Properties("extensionattribute9")(0).ToString
                    // End If
                    // Catch ex As Exception
                    // End Try

                    // Try
                    // If Not result.Properties("extensionattribute10") Is Nothing Then
                    // dr("Group") = result.Properties("extensionattribute10")(0).ToString
                    // End If
                    // Catch ex As Exception
                    // End Try

                    // Try
                    // If Not result.Properties("title") Is Nothing Then
                    // dr("title") = result.Properties("title")(0).ToString
                    // End If
                    // Catch ex As Exception
                    // End Try

                    // Try
                    // If Not result.Properties("telephoneNumber") Is Nothing Then
                    // dr("TelephoneNo") = result.Properties("telephoneNumber")(0).ToString
                    // End If
                    // Catch ex As Exception
                    // End Try

                    // Try
                    // If Not result.Properties("streetAddress") Is Nothing Then
                    // dr("FullAddress") = result.Properties("streetAddress")(0).ToString
                    // End If
                    // Catch ex As Exception
                    // End Try

                    // dt.Rows.Add(dr)
                }

            }
            // Dim ds As New DataSet
            // ds.Tables.Add(dt)
            // Dim x As List(Of Object) = (From rows In dt.AsEnumerable Select rows("TeamCode")).Distinct.ToList ' dt.DefaultView.ToTable(True, "TeamCode")
            // Dim x As List(Of String) = Listofusers.AsEnumerable.Select(Of String)(Function(y) y.TeamCode).Distinct
            return Listofusers;

        }
        public List<string> GetGrouporTeamsCodesUnderCode(string Org_Code)
        {
            Listofusers = new List<ActiveDirUser_cls>();
            var search = new DirectorySearcher();
            SearchResultCollection resultC;
            SearchResult result;

            search.Filter = "(&(objectClass=user)(extensionattribute7=" + Org_Code + "))"; // 

            search.PropertiesToLoad.Add("DisplayName");

            search.PropertiesToLoad.Add("SAMAccountName");

            search.PropertiesToLoad.Add("extensionattribute1");

            search.PropertiesToLoad.Add("mail");

            search.PropertiesToLoad.Add("extensionattribute4");

            search.PropertiesToLoad.Add("extensionattribute5");

            search.PropertiesToLoad.Add("extensionattribute6");

            search.PropertiesToLoad.Add("extensionattribute7");

            search.PropertiesToLoad.Add("extensionattribute8");

            search.PropertiesToLoad.Add("extensionattribute9");

            search.PropertiesToLoad.Add("extensionattribute10");

            search.PropertiesToLoad.Add("title");

            search.PropertiesToLoad.Add("telephoneNumber");

            search.PropertiesToLoad.Add("streetAddress");

            resultC = search.FindAll();

            if (resultC is null)
            {
            }

            else if (resultC.Count > 0)
            {
                for (int i = 0, loopTo = resultC.Count - 1; i <= loopTo; i++)
                {
                    result = resultC[i];

                    // Dim dr As DataRow = dt.NewRow
                    // ---------------------------------------------
                    var acx = new ActiveDirUser_cls();
                    try
                    {
                        if (result.Properties["DisplayName"] !=null)
                        {
                            acx.DisplayName = result.Properties["DisplayName"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        acx.DomainID = result.Properties["SAMAccountName"][0].ToString();
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        acx.KOCID = result.Properties["extensionattribute1"][0].ToString();
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        acx.MailID = result.Properties["mail"][0].ToString();
                    }
                    catch (Exception ex)
                    {
                    }


                    try
                    {
                        if (result.Properties["extensionattribute4"] !=null)
                        {
                            acx.Location = result.Properties["extensionattribute4"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }



                    try
                    {
                        if (result.Properties["extensionattribute5"] !=null)
                        {
                            acx.Building = result.Properties["extensionattribute5"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }



                    try
                    {
                        if (result.Properties["extensionattribute6"] !=null)
                        {
                            acx.Room_No = result.Properties["extensionattribute6"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }


                    try
                    {
                        if (result.Properties["extensionattribute7"] !=null)
                        {
                            acx.TeamCode = result.Properties["extensionattribute7"][0].ToString();

                        }
                    }
                    catch (Exception ex)
                    {
                    }


                    try
                    {
                        if (result.Properties["extensionattribute8"] !=null)
                        {
                            acx.Area = result.Properties["extensionattribute8"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["extensionattribute9"] !=null)
                        {
                            acx.Directorate = result.Properties["extensionattribute9"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["extensionattribute10"] !=null)
                        {
                            acx.Group = result.Properties["extensionattribute10"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["title"] !=null)
                        {
                            acx.title = result.Properties["title"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["telephoneNumber"] !=null)
                        {
                            acx.TelephoneNo = result.Properties["telephoneNumber"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["streetAddress"] !=null)
                        {
                            acx.FullAddress = result.Properties["streetAddress"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    if (acx.TeamCode.StartsWith("S"))
                    {
                        acx.Area = "SK";

                    }
                    if (acx.TeamCode.StartsWith("N"))
                    {
                        acx.Area = "NK";

                    }
                    if (acx.TeamCode.StartsWith("W"))
                    {
                        acx.Area = "WK";

                    }
                    if (acx.TeamCode.StartsWith("P"))
                    {
                        acx.Area = "ALL";

                    }
                    Listofusers.Add(acx);

                }

            }

            var x = (from rows in Listofusers.AsEnumerable()
                     select rows.TeamCode).Distinct().ToList(); // dt.DefaultView.ToTable(True, "TeamCode")

            return x;

        }
        public List<ActiveDirUser_cls> GetTeamsUnderCode(string Org_Code)
        {
            Listofusers = new List<ActiveDirUser_cls>();
            var search = new DirectorySearcher();
            SearchResultCollection resultC;
            SearchResult result;

            search.Filter = "(&(objectClass=user)(extensionattribute7=" + Org_Code + ")(DisplayName=*@TL.*))"; // 

            search.PropertiesToLoad.Add("DisplayName");

            search.PropertiesToLoad.Add("SAMAccountName");

            search.PropertiesToLoad.Add("extensionattribute1");

            search.PropertiesToLoad.Add("mail");

            search.PropertiesToLoad.Add("extensionattribute4");

            search.PropertiesToLoad.Add("extensionattribute5");

            search.PropertiesToLoad.Add("extensionattribute6");

            search.PropertiesToLoad.Add("extensionattribute7");

            search.PropertiesToLoad.Add("extensionattribute8");

            search.PropertiesToLoad.Add("extensionattribute9");

            search.PropertiesToLoad.Add("extensionattribute10");

            search.PropertiesToLoad.Add("title");

            search.PropertiesToLoad.Add("telephoneNumber");

            search.PropertiesToLoad.Add("streetAddress");

            resultC = search.FindAll();

            if (resultC is null)
            {
            }

            else if (resultC.Count > 0)
            {
                for (int i = 0, loopTo = resultC.Count - 1; i <= loopTo; i++)
                {
                    result = resultC[i];

                    // Dim dr As DataRow = dt.NewRow
                    // ---------------------------------------------
                    var acx = new ActiveDirUser_cls();
                    try
                    {
                        if (result.Properties["DisplayName"] !=null)
                        {
                            acx.DisplayName = result.Properties["DisplayName"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        acx.DomainID = result.Properties["SAMAccountName"][0].ToString();
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        acx.KOCID = result.Properties["extensionattribute1"][0].ToString();
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        acx.MailID = result.Properties["mail"][0].ToString();
                    }
                    catch (Exception ex)
                    {
                    }


                    try
                    {
                        if (result.Properties["extensionattribute4"] !=null)
                        {
                            acx.Location = result.Properties["extensionattribute4"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }



                    try
                    {
                        if (result.Properties["extensionattribute5"] !=null)
                        {
                            acx.Building = result.Properties["extensionattribute5"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }



                    try
                    {
                        if (result.Properties["extensionattribute6"] !=null)
                        {
                            acx.Room_No = result.Properties["extensionattribute6"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }


                    try
                    {
                        if (result.Properties["extensionattribute7"] !=null)
                        {
                            acx.TeamCode = result.Properties["extensionattribute7"][0].ToString();

                        }
                    }
                    catch (Exception ex)
                    {
                    }


                    try
                    {
                        if (result.Properties["extensionattribute8"] !=null)
                        {
                            acx.Area = result.Properties["extensionattribute8"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["extensionattribute9"] !=null)
                        {
                            acx.Directorate = result.Properties["extensionattribute9"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["extensionattribute10"] !=null)
                        {
                            acx.Group = result.Properties["extensionattribute10"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["title"] !=null)
                        {
                            acx.title = result.Properties["title"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["telephoneNumber"] !=null)
                        {
                            acx.TelephoneNo = result.Properties["telephoneNumber"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["streetAddress"] !=null)
                        {
                            acx.FullAddress = result.Properties["streetAddress"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    if (acx.TeamCode.StartsWith("S"))
                    {
                        acx.Area = "SK";

                    }
                    if (acx.TeamCode.StartsWith("N"))
                    {
                        acx.Area = "NK";

                    }
                    if (acx.TeamCode.StartsWith("W"))
                    {
                        acx.Area = "WK";

                    }
                    if (acx.TeamCode.StartsWith("P"))
                    {
                        acx.Area = "ALL";

                    }
                    Listofusers.Add(acx);

                }

            }

            // Dim x As List(Of String) = (From rows In Listofusers.AsEnumerable Select rows.TeamCode).Distinct.ToList ' dt.DefaultView.ToTable(True, "TeamCode")

            return Listofusers.Distinct().ToList();

        }
        public List<ActiveDirUser_cls> GetTeamLeaders()
        {
            Listofusers = new List<ActiveDirUser_cls>();
            var search = new DirectorySearcher();
            SearchResultCollection resultC;
            SearchResult result;

            search.Filter = "(&(objectClass=user)(extensionattribute7=(DisplayName=*@TL.*))"; // 

            search.PropertiesToLoad.Add("DisplayName");

            search.PropertiesToLoad.Add("SAMAccountName");

            search.PropertiesToLoad.Add("extensionattribute1");

            search.PropertiesToLoad.Add("mail");

            search.PropertiesToLoad.Add("extensionattribute4");

            search.PropertiesToLoad.Add("extensionattribute5");

            search.PropertiesToLoad.Add("extensionattribute6");

            search.PropertiesToLoad.Add("extensionattribute7");

            search.PropertiesToLoad.Add("extensionattribute8");

            search.PropertiesToLoad.Add("extensionattribute9");

            search.PropertiesToLoad.Add("extensionattribute10");

            search.PropertiesToLoad.Add("title");

            search.PropertiesToLoad.Add("telephoneNumber");

            search.PropertiesToLoad.Add("streetAddress");

            resultC = search.FindAll();

            if (resultC is null)
            {
            }

            else if (resultC.Count > 0)
            {
                for (int i = 0, loopTo = resultC.Count - 1; i <= loopTo; i++)
                {
                    result = resultC[i];

                    // Dim dr As DataRow = dt.NewRow
                    // ---------------------------------------------
                    var acx = new ActiveDirUser_cls();
                    try
                    {
                        if (result.Properties["DisplayName"] !=null)
                        {
                            acx.DisplayName = result.Properties["DisplayName"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        acx.DomainID = result.Properties["SAMAccountName"][0].ToString();
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        acx.KOCID = result.Properties["extensionattribute1"][0].ToString();
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        acx.MailID = result.Properties["mail"][0].ToString();
                    }
                    catch (Exception ex)
                    {
                    }


                    try
                    {
                        if (result.Properties["extensionattribute4"] !=null)
                        {
                            acx.Location = result.Properties["extensionattribute4"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }



                    try
                    {
                        if (result.Properties["extensionattribute5"] !=null)
                        {
                            acx.Building = result.Properties["extensionattribute5"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }



                    try
                    {
                        if (result.Properties["extensionattribute6"] !=null)
                        {
                            acx.Room_No = result.Properties["extensionattribute6"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }


                    try
                    {
                        if (result.Properties["extensionattribute7"] !=null)
                        {
                            acx.TeamCode = result.Properties["extensionattribute7"][0].ToString();

                        }
                    }
                    catch (Exception ex)
                    {
                    }


                    try
                    {
                        if (result.Properties["extensionattribute8"] !=null)
                        {
                            acx.Area = result.Properties["extensionattribute8"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["extensionattribute9"] !=null)
                        {
                            acx.Directorate = result.Properties["extensionattribute9"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["extensionattribute10"] !=null)
                        {
                            acx.Group = result.Properties["extensionattribute10"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["title"] !=null)
                        {
                            acx.title = result.Properties["title"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["telephoneNumber"] !=null)
                        {
                            acx.TelephoneNo = result.Properties["telephoneNumber"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["streetAddress"] !=null)
                        {
                            acx.FullAddress = result.Properties["streetAddress"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    if (acx.TeamCode.StartsWith("S"))
                    {
                        acx.Area = "SK";

                    }
                    if (acx.TeamCode.StartsWith("N"))
                    {
                        acx.Area = "NK";

                    }
                    if (acx.TeamCode.StartsWith("W"))
                    {
                        acx.Area = "WK";

                    }
                    if (acx.TeamCode.StartsWith("P"))
                    {
                        acx.Area = "ALL";

                    }
                    Listofusers.Add(acx);

                }

            }

            // Dim x As List(Of String) = (From rows In Listofusers.AsEnumerable Select rows.TeamCode).Distinct.ToList ' dt.DefaultView.ToTable(True, "TeamCode")

            return Listofusers.Distinct().ToList();

        }
        public List<ActiveDirUser_cls> GetManagers()
        {
            Listofusers = new List<ActiveDirUser_cls>();
            var search = new DirectorySearcher();
            SearchResultCollection resultC;
            SearchResult result;
            // (DisplayName=*@M.*))"
            search.Filter = "(&(objectClass=user)(extensionattribute7=(DisplayName=*@M.*))"; // 

            search.PropertiesToLoad.Add("DisplayName");

            search.PropertiesToLoad.Add("SAMAccountName");

            search.PropertiesToLoad.Add("extensionattribute1");

            search.PropertiesToLoad.Add("mail");

            search.PropertiesToLoad.Add("extensionattribute4");

            search.PropertiesToLoad.Add("extensionattribute5");

            search.PropertiesToLoad.Add("extensionattribute6");

            search.PropertiesToLoad.Add("extensionattribute7");

            search.PropertiesToLoad.Add("extensionattribute8");

            search.PropertiesToLoad.Add("extensionattribute9");

            search.PropertiesToLoad.Add("extensionattribute10");

            search.PropertiesToLoad.Add("title");

            search.PropertiesToLoad.Add("telephoneNumber");

            search.PropertiesToLoad.Add("streetAddress");

            resultC = search.FindAll();

            if (resultC is null)
            {
            }

            else if (resultC.Count > 0)
            {
                for (int i = 0, loopTo = resultC.Count - 1; i <= loopTo; i++)
                {
                    result = resultC[i];

                    // Dim dr As DataRow = dt.NewRow
                    // ---------------------------------------------
                    var acx = new ActiveDirUser_cls();
                    try
                    {
                        if (result.Properties["DisplayName"] !=null)
                        {
                            acx.DisplayName = result.Properties["DisplayName"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        acx.DomainID = result.Properties["SAMAccountName"][0].ToString();
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        acx.KOCID = result.Properties["extensionattribute1"][0].ToString();
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        acx.MailID = result.Properties["mail"][0].ToString();
                    }
                    catch (Exception ex)
                    {
                    }


                    try
                    {
                        if (result.Properties["extensionattribute4"] !=null)
                        {
                            acx.Location = result.Properties["extensionattribute4"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }



                    try
                    {
                        if (result.Properties["extensionattribute5"] !=null)
                        {
                            acx.Building = result.Properties["extensionattribute5"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }



                    try
                    {
                        if (result.Properties["extensionattribute6"] !=null)
                        {
                            acx.Room_No = result.Properties["extensionattribute6"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }


                    try
                    {
                        if (result.Properties["extensionattribute7"] !=null)
                        {
                            acx.TeamCode = result.Properties["extensionattribute7"][0].ToString();

                        }
                    }
                    catch (Exception ex)
                    {
                    }


                    try
                    {
                        if (result.Properties["extensionattribute8"] !=null)
                        {
                            acx.Area = result.Properties["extensionattribute8"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["extensionattribute9"] !=null)
                        {
                            acx.Directorate = result.Properties["extensionattribute9"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["extensionattribute10"] !=null)
                        {
                            acx.Group = result.Properties["extensionattribute10"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["title"] !=null)
                        {
                            acx.title = result.Properties["title"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["telephoneNumber"] !=null)
                        {
                            acx.TelephoneNo = result.Properties["telephoneNumber"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["streetAddress"] !=null)
                        {
                            acx.FullAddress = result.Properties["streetAddress"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    if (acx.TeamCode.StartsWith("S"))
                    {
                        acx.Area = "SK";

                    }
                    if (acx.TeamCode.StartsWith("N"))
                    {
                        acx.Area = "NK";

                    }
                    if (acx.TeamCode.StartsWith("W"))
                    {
                        acx.Area = "WK";

                    }
                    if (acx.TeamCode.StartsWith("P"))
                    {
                        acx.Area = "ALL";

                    }
                    Listofusers.Add(acx);

                }

            }

            // Dim x As List(Of String) = (From rows In Listofusers.AsEnumerable Select rows.TeamCode).Distinct.ToList ' dt.DefaultView.ToTable(True, "TeamCode")

            return Listofusers.Distinct().ToList();

        }
        public List<ActiveDirUser_cls> GetGroupsUnderCode(string Org_Code)
        {
            Listofusers = new List<ActiveDirUser_cls>();
            var search = new DirectorySearcher();
            SearchResultCollection resultC;
            SearchResult result;

            search.Filter = "(&(objectClass=user)(extensionattribute7=" + Org_Code + ")(DisplayName=*@M.*))"; // 

            search.PropertiesToLoad.Add("DisplayName");

            search.PropertiesToLoad.Add("SAMAccountName");

            search.PropertiesToLoad.Add("extensionattribute1");

            search.PropertiesToLoad.Add("mail");

            search.PropertiesToLoad.Add("extensionattribute4");

            search.PropertiesToLoad.Add("extensionattribute5");

            search.PropertiesToLoad.Add("extensionattribute6");

            search.PropertiesToLoad.Add("extensionattribute7");

            search.PropertiesToLoad.Add("extensionattribute8");

            search.PropertiesToLoad.Add("extensionattribute9");

            search.PropertiesToLoad.Add("extensionattribute10");

            search.PropertiesToLoad.Add("title");

            search.PropertiesToLoad.Add("telephoneNumber");

            search.PropertiesToLoad.Add("streetAddress");

            resultC = search.FindAll();

            if (resultC is null)
            {
            }

            else if (resultC.Count > 0)
            {
                for (int i = 0, loopTo = resultC.Count - 1; i <= loopTo; i++)
                {
                    result = resultC[i];

                    // Dim dr As DataRow = dt.NewRow
                    // ---------------------------------------------
                    var acx = new ActiveDirUser_cls();
                    try
                    {
                        if (result.Properties["DisplayName"] !=null)
                        {
                            acx.DisplayName = result.Properties["DisplayName"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        acx.DomainID = result.Properties["SAMAccountName"][0].ToString();
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        acx.KOCID = result.Properties["extensionattribute1"][0].ToString();
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        acx.MailID = result.Properties["mail"][0].ToString();
                    }
                    catch (Exception ex)
                    {
                    }


                    try
                    {
                        if (result.Properties["extensionattribute4"] !=null)
                        {
                            acx.Location = result.Properties["extensionattribute4"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }



                    try
                    {
                        if (result.Properties["extensionattribute5"] !=null)
                        {
                            acx.Building = result.Properties["extensionattribute5"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }



                    try
                    {
                        if (result.Properties["extensionattribute6"] !=null)
                        {
                            acx.Room_No = result.Properties["extensionattribute6"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }


                    try
                    {
                        if (result.Properties["extensionattribute7"] !=null)
                        {
                            acx.TeamCode = result.Properties["extensionattribute7"][0].ToString();

                        }
                    }
                    catch (Exception ex)
                    {
                    }


                    try
                    {
                        if (result.Properties["extensionattribute8"] !=null)
                        {
                            acx.Area = result.Properties["extensionattribute8"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["extensionattribute9"] !=null)
                        {
                            acx.Directorate = result.Properties["extensionattribute9"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["extensionattribute10"] !=null)
                        {
                            acx.Group = result.Properties["extensionattribute10"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["title"] !=null)
                        {
                            acx.title = result.Properties["title"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["telephoneNumber"] !=null)
                        {
                            acx.TelephoneNo = result.Properties["telephoneNumber"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        if (result.Properties["streetAddress"] !=null)
                        {
                            acx.FullAddress = result.Properties["streetAddress"][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    if (acx.TeamCode.StartsWith("S"))
                    {
                        acx.Area = "SK";

                    }
                    if (acx.TeamCode.StartsWith("N"))
                    {
                        acx.Area = "NK";

                    }
                    if (acx.TeamCode.StartsWith("W"))
                    {
                        acx.Area = "WK";

                    }
                    if (acx.TeamCode.StartsWith("P"))
                    {
                        acx.Area = "ALL";

                    }
                    Listofusers.Add(acx);

                }

            }

            // Dim x As List(Of String) = (From rows In Listofusers.AsEnumerable Select rows.TeamCode).Distinct.ToList ' dt.DefaultView.ToTable(True, "TeamCode")

            return Listofusers.Distinct().ToList();

        }
    }
    public class ActiveDirUser_cls
    {
        public string DisplayName { get; set; }

        public string DomainID { get; set; }

        public string KOCID { get; set; }

        public string MailID { get; set; }

        public string Location { get; set; }

        public string Building { get; set; }

        public string Room_No { get; set; }

        public string TeamCode { get; set; }

        public string Area { get; set; }

        public string Directorate { get; set; }

        public string Group { get; set; }

        public string title { get; set; }

        public string TelephoneNo { get; set; }

        public string FullAddress { get; set; }
        public string GRPCODE { get; set; }
        public string DIVCODE { get; set; }

    }
}