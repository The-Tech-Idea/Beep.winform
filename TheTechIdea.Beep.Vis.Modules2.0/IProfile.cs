using System;
using System.Collections.Generic;
using System.Text;

namespace BeepEnterprize.Vis.Module
{
    public interface IProfile
    {
        string HomePageUrl { get; set; }
        string LoginPageTitle { get; set; }
        string LoginPageDescription { get; set; }
        string LoginPageUrl { get; set; }

        string ConfigurationPageUrl { get; set; }
        string ConfigurationPageTitle { get; set; }
        string ConfigurationPageDescription { get; set; }

        string ProfilePageUrl { get; set; }
        string ProfilePageTitle { get; set; }
        string ProfilePageDescription { get; set; }
       


    }
}
