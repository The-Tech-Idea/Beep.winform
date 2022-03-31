using System;
using System.Collections.Generic;
using System.Text;
using TheTechIdea.Beep.AppModule;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Util;

namespace TheTechIdea.Beep.AppBuilder
{
    [AddinAttribute(Caption = "Beep App BreadCrumb", Name = "BeepAPPBreadCrumb", misc = "BeepAPPBreadCrumb", addinType = AddinType.Class, iconimage = "appbreadcrumb.ico")]
    public class BreadCrumb : IEquatable<IBreadCrumb>, IBreadCrumb
    {
        public BreadCrumb()
        {

        }
        public string screenname { get; set; }
        public Dictionary<string, string> keyValues { get; set; } = new Dictionary<string, string>();

        public override bool Equals(object obj)
        {
            return Equals(obj as BreadCrumb);
        }

        public bool Equals(IBreadCrumb other)
        {
            return other != null &&
                   screenname == other.screenname &&
                   EqualityComparer<Dictionary<string, string>>.Default.Equals(keyValues, other.keyValues);
        }

        public override int GetHashCode()
        {
            int hashCode = 1569004476;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(screenname);
            hashCode = hashCode * -1521134295 + EqualityComparer<Dictionary<string, string>>.Default.GetHashCode(keyValues);
            return hashCode;
        }

        public static bool operator ==(BreadCrumb left, BreadCrumb right)
        {
            return EqualityComparer<BreadCrumb>.Default.Equals(left, right);
        }

        public static bool operator !=(BreadCrumb left, BreadCrumb right)
        {
            return !(left == right);
        }
    }
}
