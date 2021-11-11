using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ThesisManagementWebApp.DAL.Gateway;
using ThesisManagementWebApp.DAL.Model;

namespace ThesisManagementWebApp.Web
{
    public partial class AddNotice : System.Web.UI.Page
    {
        private Function func;
        private NoticeGateway noticeGateway;
        private NoticeModel noticeModel;
        public AddNotice()
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
            }
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            if (txtNotice.Text == "")
            {
                lblMessage.Text = "Notice is required";
                lblMessage.ForeColor = Color.Red;
            }
            else
            {
                ViewState["NoticeId"] = func.GenerateId("Select Max(NoticeId) FROM Notice");
                noticeModel.NoticeId = ViewState["NoticeId"].ToString();
                noticeModel.Notice = txtNotice.Text;
                noticeModel.NoticeTime = func.Date();
                bool a = noticeGateway.SaveNotice(noticeModel);
                if (a)
                {

                    lblMessage.Text = "Notice added successfully";
                    lblMessage.ForeColor = Color.Green;
                    txtNotice.Text = "";

                }
                else
                {
                    lblMessage.Text = "failed to add notice";
                    lblMessage.ForeColor = Color.Red;
                }
            }
        }
    }
}