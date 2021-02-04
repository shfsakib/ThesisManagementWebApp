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
    public partial class NoticeList : System.Web.UI.Page
    {
        private Function func;
        private NoticeGateway noticeGateway;
        private NoticeModel noticeModel;
        public NoticeList()
        {
            func = Function.GetInstance();
            noticeModel = NoticeModel.GetInstance();
            noticeGateway = NoticeGateway.GetInstance();
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
            func.LoadGrid(gridResource, "SELECT * FROM Notice ORDER BY NoticeId DESC");
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
            noticeModel.NoticeId = HiddenField1.Value;
            bool a = noticeGateway.DeleteNotice(noticeModel);
            if (a)
            {
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "script", "alert('Notice removed successfully.');", true);
                Load();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "script", "alert('Notice remove failed.');", true);
            }
        }
    }
}