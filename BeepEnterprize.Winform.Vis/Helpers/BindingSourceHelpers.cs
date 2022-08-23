using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeepEnterprize.Winform.Vis.Helpers
{
   
    public static class BindingSourceExtensions
    {
        public static DataTable DataTable(this BindingSource pBindingSource)
        {
                return (DataTable)pBindingSource.DataSource;
        }
        public static DataRow CurrentRow(this BindingSource pBindingSource)
        {
                return ((DataRowView)pBindingSource.Current).Row;
        }
        public static bool Is<T>(this object pObject)
        {
            return pObject is T;
        }
    }
}
