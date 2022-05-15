using System;
using System.Data;
using System.DirectoryServices;
using System.Web.Services;

namespace KocConfig.ActiveDirctory
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class AD : WebService
    {
        [WebMethod()]
        public DataSet GetUserInfo(string KOCID)
        {

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
                    if (result.Properties["DisplayName"] != null)
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
                    if (result.Properties["extensionattribute4"] != null)
                    {
                        dr["Location"] = result.Properties["extensionattribute4"][0].ToString();
                    }
                }
                catch (Exception ex)
                {
                }



                try
                {
                    if (result.Properties["extensionattribute5"] != null)
                    {
                        dr["Building"] = result.Properties["extensionattribute5"][0].ToString();
                    }
                }
                catch (Exception ex)
                {
                }



                try
                {
                    if (result.Properties["extensionattribute6"] != null)
                    {
                        dr["Room No"] = result.Properties["extensionattribute6"][0].ToString();
                    }
                }
                catch (Exception ex)
                {
                }


                try
                {
                    if (result.Properties["extensionattribute7"] != null)
                    {
                        dr["TeamCode"] = result.Properties["extensionattribute7"][0].ToString();
                    }
                }
                catch (Exception ex)
                {
                }


                try
                {
                    if (result.Properties["extensionattribute8"] != null)
                    {
                        dr["Area"] = result.Properties["extensionattribute8"][0].ToString();
                    }
                }
                catch (Exception ex)
                {
                }

                try
                {
                    if (result.Properties["extensionattribute9"] != null)
                    {
                        dr["Directorate"] = result.Properties["extensionattribute9"][0].ToString();
                    }
                }
                catch (Exception ex)
                {
                }

                try
                {
                    if (result.Properties["extensionattribute10"] != null)
                    {
                        dr["Group"] = result.Properties["extensionattribute10"][0].ToString();
                    }
                }
                catch (Exception ex)
                {
                }

                try
                {
                    if (result.Properties["title"] != null)
                    {
                        dr["title"] = result.Properties["title"][0].ToString();
                    }
                }
                catch (Exception ex)
                {
                }

                try
                {
                    if (result.Properties["telephoneNumber"] != null)
                    {
                        dr["TelephoneNo"] = result.Properties["telephoneNumber"][0].ToString();
                    }
                }
                catch (Exception ex)
                {
                }

                try
                {
                    if (result.Properties["streetAddress"] != null)
                    {
                        dr["FullAddress"] = result.Properties["streetAddress"][0].ToString();
                    }
                }
                catch (Exception ex)
                {
                }

                dr["Area"] = SetupArea(dr["TeamCode"].ToString());
                dt.Rows.Add(dr);

            }
            var ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;

        }
        [WebMethod()]
        public DataSet GetUserInfoByDomianID(string DomainID)
        {

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
                    if (result.Properties["DisplayName"] != null)
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
                    if (result.Properties["extensionattribute4"] != null)
                    {
                        dr["Location"] = result.Properties["extensionattribute4"][0].ToString();
                    }
                }
                catch (Exception ex)
                {
                }



                try
                {
                    if (result.Properties["extensionattribute5"] != null)
                    {
                        dr["Building"] = result.Properties["extensionattribute5"][0].ToString();
                    }
                }
                catch (Exception ex)
                {
                }



                try
                {
                    if (result.Properties["extensionattribute6"] != null)
                    {
                        dr["Room No"] = result.Properties["extensionattribute6"][0].ToString();
                    }
                }
                catch (Exception ex)
                {
                }


                try
                {
                    if (result.Properties["extensionattribute7"] != null)
                    {
                        dr["TeamCode"] = result.Properties["extensionattribute7"][0].ToString();
                    }
                }
                catch (Exception ex)
                {
                }


                try
                {
                    if (result.Properties["extensionattribute8"] != null)
                    {
                        dr["Area"] = result.Properties["extensionattribute8"][0].ToString();
                    }
                }
                catch (Exception ex)
                {
                }

                try
                {
                    if (result.Properties["extensionattribute9"] != null)
                    {
                        dr["Directorate"] = result.Properties["extensionattribute9"][0].ToString();
                    }
                }
                catch (Exception ex)
                {
                }

                try
                {
                    if (result.Properties["extensionattribute10"] != null)
                    {
                        dr["Group"] = result.Properties["extensionattribute10"][0].ToString();
                    }
                }
                catch (Exception ex)
                {
                }

                try
                {
                    if (result.Properties["title"] != null)
                    {
                        dr["title"] = result.Properties["title"][0].ToString();
                    }
                }
                catch (Exception ex)
                {
                }

                try
                {
                    if (result.Properties["telephoneNumber"] != null)
                    {
                        dr["TelephoneNo"] = result.Properties["telephoneNumber"][0].ToString();
                    }
                }
                catch (Exception ex)
                {
                }

                try
                {
                    if (result.Properties["streetAddress"] != null)
                    {
                        dr["FullAddress"] = result.Properties["streetAddress"][0].ToString();
                    }
                }
                catch (Exception ex)
                {
                }


                dr["Area"] = SetupArea(dr["TeamCode"].ToString());
                dt.Rows.Add(dr);

            }
            var ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;

        }
        public object SetupArea(string Teamcode)
        {
            string area = "";
            if (Teamcode.StartsWith("S") | Teamcode.StartsWith("CR11"))
            {
                area = "SK";

            }
            if (Teamcode.StartsWith("N") | Teamcode.StartsWith("CR21"))
            {
                area = "NK";

            }
            if (Teamcode.StartsWith("W") | Teamcode.StartsWith("W") | Teamcode.StartsWith("CR21"))
            {
                area = "WK";

            }
            if (Teamcode.StartsWith("P") | Teamcode.StartsWith("CR51"))
            {
                area = "ALL";

            }
            return area;
        }
        [WebMethod()]
        public DataSet GetUserInfoByKocno(string Kocno)
        {

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

            search.Filter = "(&(objectClass=user)(extensionattribute1=" + Kocno + "))"; // 

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
                    if (result.Properties["DisplayName"] != null)
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
                    if (result.Properties["extensionattribute4"] != null)
                    {
                        dr["Location"] = result.Properties["extensionattribute4"][0].ToString();
                    }
                }
                catch (Exception ex)
                {
                }



                try
                {
                    if (result.Properties["extensionattribute5"] != null)
                    {
                        dr["Building"] = result.Properties["extensionattribute5"][0].ToString();
                    }
                }
                catch (Exception ex)
                {
                }



                try
                {
                    if (result.Properties["extensionattribute6"] != null)
                    {
                        dr["Room No"] = result.Properties["extensionattribute6"][0].ToString();
                    }
                }
                catch (Exception ex)
                {
                }


                try
                {
                    if (result.Properties["extensionattribute7"] != null)
                    {
                        dr["TeamCode"] = result.Properties["extensionattribute7"][0].ToString();
                    }
                }
                catch (Exception ex)
                {
                }


                try
                {
                    if (result.Properties["extensionattribute8"] != null)
                    {
                        dr["Area"] = result.Properties["extensionattribute8"][0].ToString();
                    }
                }
                catch (Exception ex)
                {
                }

                try
                {
                    if (result.Properties["extensionattribute9"] != null)
                    {
                        dr["Directorate"] = result.Properties["extensionattribute9"][0].ToString();
                    }
                }
                catch (Exception ex)
                {
                }

                try
                {
                    if (result.Properties["extensionattribute10"] != null)
                    {
                        dr["Group"] = result.Properties["extensionattribute10"][0].ToString();
                    }
                }
                catch (Exception ex)
                {
                }

                try
                {
                    if (result.Properties["title"] != null)
                    {
                        dr["title"] = result.Properties["title"][0].ToString();
                    }
                }
                catch (Exception ex)
                {
                }

                try
                {
                    if (result.Properties["telephoneNumber"] != null)
                    {
                        dr["TelephoneNo"] = result.Properties["telephoneNumber"][0].ToString();
                    }
                }
                catch (Exception ex)
                {
                }

                try
                {
                    if (result.Properties["streetAddress"] != null)
                    {
                        dr["FullAddress"] = result.Properties["streetAddress"][0].ToString();
                    }
                }
                catch (Exception ex)
                {
                }

                dr["Area"] = SetupArea(dr["TeamCode"].ToString());
                dt.Rows.Add(dr);

            }
            var ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;

        }
    }
}