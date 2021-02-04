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
    public partial class Notice : System.Web.UI.Page
    {
        private Function func;
        private NoticeGateway noticeGateway;
        private NoticeModel noticeModel;
        public Notice()
        {
            func = Function.GetInstance();
            noticeModel = NoticeModel.GetInstance();
            noticeGateway = NoticeGateway.GetInstance();
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
            func.LoadGrid(gridResource, "SELECT * FROM Notice ORDER BY NoticeId DESC");
        }
        protected void gridResource_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridResource.PageIndex = e.NewPageIndex;
            Load();
        }
    }
}