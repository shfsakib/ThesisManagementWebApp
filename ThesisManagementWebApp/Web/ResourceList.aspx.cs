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
    public partial class ResourceList : System.Web.UI.Page
    {
        private Function func;
        private ResourceGateway resourceGateway;
        private ResourceModel resourceModel;
        public ResourceList()
        {
            func = Function.GetInstance();
            resourceModel = ResourceModel.GetInstance();
            resourceGateway = ResourceGateway.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (func.TypeCookie() != "Admin")
                {
                    Response.Redirect("/Web/Login.aspx");
                }
                Load();
            }
        }

        private void Load()
        {
            func.LoadGrid(gridResource, "SELECT * FROM Resource ORDER BY ResourceId DESC");
        }
        protected void gridResource_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridResource.PageIndex = e.NewPageIndex;
            Load();
        }

        protected void lnkRemove_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            HiddenField HiddenField1 = (HiddenField)linkButton.Parent.FindControl("HiddenField1");
            resourceModel.ResourceId = HiddenField1.Value;
            bool a = resourceGateway.DeleteResouce(resourceModel);
            if (a)
            {
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "script", "alert('Resource removed successfully.');", true);
                Load();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "script", "alert('Resource remove failed.');", true);
            }
        }
    }
}