using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ThesisManagementWebApp.Web
{
    public partial class document_list : System.Web.UI.Page
    {
        private Function func;
        public document_list()
        {
            func = Function.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                func.CheckCookies();
                Load();
            }
        }
        private void Load()
        {
            func.LoadGrid(gridDoc, $@"SELECT * FROM Documents WHERE Type='{ddlType.SelectedValue}' ORDER BY DocId DESC");
        }
        protected void ddlType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Load();
        }

        protected void gridDoc_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridDoc.PageIndex = e.NewPageIndex;
            Load();
        }
    }
}