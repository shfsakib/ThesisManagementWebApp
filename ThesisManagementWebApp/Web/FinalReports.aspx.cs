using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BitsSoftware;
using ThesisManagementWebApp.DAL.Gateway;
using ThesisManagementWebApp.DAL.Model;

namespace ThesisManagementWebApp.Web
{
    public partial class FinalReports : System.Web.UI.Page
    {
        private Function func; 

        public FinalReports()
        {
            func = Function.GetInstance(); 
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (func.TypeCookie() == "Admin" || func.TypeCookie()=="Coordinator")
                {
                    Response.Redirect("/Web/Login.aspx");
                }
                Load();
            }
        }

        private void Load()
        {
            func.LoadGrid(gridReport,"SELECT FileName,Attachment FROM Report WHERE Type='"+ddlType.Text+"'");
            
        }
        protected void txtSearch_OnTextChanged(object sender, EventArgs e)
        {
            func.LoadGrid(gridReport,"SELECT FileName,Attachment FROM Report WHERE Type='"+ddlType.Text+"' AND FileName LIKE '%"+txtSearch.Text+"%'");

        }

        protected void ddlType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Load();
        }

        protected void gridReport_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridReport.PageIndex = e.NewPageIndex;
            Load();
        }
    }
}