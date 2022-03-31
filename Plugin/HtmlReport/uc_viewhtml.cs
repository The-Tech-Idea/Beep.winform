using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HtmlReport
{
    public partial class uc_viewhtml : UserControl
    {
        public uc_viewhtml()
        {
            InitializeComponent();
            InitializeAsync();

        }
        async void InitializeAsync()
        {
            await webView21.EnsureCoreWebView2Async(null);
        }
        public void GetReport()
        {

        }
        private void loadtable()
        {
            webView21.CoreWebView2.ExecuteScriptAsync("<script>  $(document).ready(function() { $.getJSON('report.json', function(data) { }).fail(function() {console.log('An error has occurred.);}");
           
        }
        private void linktable()
        {
            webView21.CoreWebView2.ExecuteScriptAsync("$(document).ready(function() { $('report').DataTable();});");
    
        }
    }
}
