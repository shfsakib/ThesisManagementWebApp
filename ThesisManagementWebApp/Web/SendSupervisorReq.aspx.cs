using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BitsSoftware;
using ThesisManagementWebApp.DAL.Gateway;
using ThesisManagementWebApp.DAL.Model;

namespace ThesisManagementWebApp.Web
{
    public partial class SendSupervisorReq : System.Web.UI.Page
    {
        private Function func;
        private RequestModel requestModel;
        private RequestGateway requestGateway;

        public SendSupervisorReq()
        {
            func = Function.GetInstance();
            requestModel = RequestModel.GetInstance();
            requestGateway = RequestGateway.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (func.TypeCookie() != "Student")
                {
                    Response.Redirect("/Web/Login.aspx");
                }
                if (Request.QueryString["RId"] == null)
                {
                    Response.Redirect("/Web/SearchSupervisor.aspx");
                }
                Load();
            }
        }

        private void Load()
        {
            txtName.Text = func.IsExist($"SELECT Name FROM Registration WHERE RegistrationId='{Request.QueryString["RId"]}'");
            txtEmail.Text = func.IsExist($"SELECT Email FROM Registration WHERE RegistrationId='{Request.QueryString["RId"]}'");

        }

        private bool IsReqExist(string sId)
        {
            bool a = false;
            string x =
                func.IsExist($"SELECT Subject FROM ReqSupervisor WHERE StudentId='{sId}'");
            if (x != "")
            {
                a = true;
            }
            return a;
        }
        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            if (txtSubject.Text == "")
            {
                lblMessage.Text = "Subject is required";
                lblMessage.ForeColor = Color.Red;
            }
            else if (txtDescription.Text == "")
            {
                lblMessage.Text = "Description is required";
                lblMessage.ForeColor = Color.Red;
            }
            else if (IsReqExist(func.UserIdCookie()))
            {

                ScriptManager.RegisterStartupScript(this, Page.GetType(), "script", "alert('You have already sent supervise request. Wait for previous approval or contact with thesis coordinator.');setTimeout(function(){location.replace('/Web/SearchSupervisor.aspx')},2500)", true);
            }
            else
            {
                ViewState["ReqId"] = func.GenerateId("Select Max(ReqId) FROM ReqSupervisor");
                requestModel.ReqId = ViewState["ReqId"].ToString();
                requestModel.SupervisorId = Request.QueryString["RId"];
                requestModel.StudentId = func.UserIdCookie();
                requestModel.Subject = txtSubject.Text;
                requestModel.Description = txtDescription.Text;
                if (fileAttach.HasFile)
                {
                    string imagePath = Server.MapPath("/photos/") + ViewState["ReqId"].ToString() + fileAttach.FileName;
                    fileAttach.PostedFile.SaveAs(imagePath);
                    requestModel.FileName = fileAttach.FileName;
                    requestModel.Attachment = "/photos/" + ViewState["ReqId"].ToString() + fileAttach.FileName;
                }
                else
                {
                    requestModel.Attachment = "";
                    requestModel.FileName = "";

                }
                requestModel.Status = "I";
                requestModel.ReqTime = func.Date();
                bool a = requestGateway.InsertReq(requestModel);
                if (a)
                {
                    bool ans = func.SendEmail("thesisdemo21@gmail.com", txtEmail.Text, "Request", "<h3>Hello Teacher,</h3><br/>Your have a request from a student name=" + func.NameCookie() + ",Email=" + func.EmailCookie() + " for supervise his/her project. Please check his request.", "Thesis2021");
                    if (ans)
                    {
                        ScriptManager.RegisterStartupScript(this, Page.GetType(), "script", "alert('Request sent successfully. Wait for approval.');setTimeout(function(){location.replace('/Web/SearchSupervisor.aspx')},2500)", true);

                    }
                }
            }
        }
    }
}