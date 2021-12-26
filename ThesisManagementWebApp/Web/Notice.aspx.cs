using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ThesisManagementWebApp.Web
{
    public partial class Notice1 : System.Web.UI.Page
    {
        private Function func;

        public Notice1()
        {
            func=Function.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load();
            }
        }
        private void Load()
        {
            func.LoadGrid(gridNotice, "SELECT * FROM Notice ORDER BY NoticeId DESC");
        }
        protected void gridNotice_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridNotice.PageIndex = e.NewPageIndex;
            Load();
        }

        protected void gridNotice_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HtmlAnchor btnDownload = (HtmlAnchor)e.Row.FindControl("btnDownload");
                Label lblWarn = (Label)e.Row.FindControl("lblWarn");
                if (btnDownload.HRef == "")
                {
                    btnDownload.Visible = false;
                    lblWarn.Visible = true;
                }
                else
                {
                    btnDownload.Visible = true;
                    lblWarn.Visible = false;
                }
            }
        }
    }
}