using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tosapp_Tool
{
    public partial class StageDetailEn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(Server.MapPath("~/") + "/StageDetailHtmlEn.html", Encoding.UTF8);
            //載入JSON字串
            string n_jsonStr = sr.ReadToEnd();
            sr.Close();
            //HtmlGenericControl myhtml = new HtmlGenericControl();
            //myhtml.InnerText = n_jsonStr;
            //PlaceHolder1.Controls.Add(myhtml);
            div_stage_detail.InnerHtml = n_jsonStr;
        }
    }
}