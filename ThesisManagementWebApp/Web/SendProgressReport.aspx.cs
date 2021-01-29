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
    public partial class SendProgressReport : System.Web.UI.Page
    {
        private Function func;
        private ReportModel reportModel;
        private ReportGateway reportGateway;

        public SendProgressReport()
        {
            func = Function.GetInstance();
            reportModel = ReportModel.GetInstance();
            reportGateway = ReportGateway.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (func.TypeCookie() != "Student")
                {
                    Response.Redirect("/Web/Login.aspx");
                }
                if (IsAssigned())
                {
                    ScriptManager.RegisterStartupScript(this, Page.GetType(), "script", "alert('You are not supervised by any teacher. Please wait for supervisor approval or sent a teacher request for supervision.');setTimeout(function(){location.replace('/Web/Login.aspx')},2500)", true);

                }
                txtName.Text = func.IsExist($@"SELECT Registration.Name FROM ReqSupervisor INNER JOIN Registration ON ReqSupervisor.SupervisorId = Registration.RegistrationId WHERE ReqSupervisor.StudentId='{func.UserIdCookie()}'");
                txtEmail.Text = func.IsExist($@"SELECT Registration.Email FROM ReqSupervisor INNER JOIN Registration ON ReqSupervisor.SupervisorId = Registration.RegistrationId WHERE ReqSupervisor.StudentId='{func.UserIdCookie()}'");
            }
        }

        private bool IsAssigned()
        {
            bool ans = false;
            string x = func.IsExist($"SELECT StudentId FROM ReqSupervisor WHERE StudentId='{func.UserIdCookie()}' AND Status='I'");
            if (x != "")
            {
                ans = true;
            }
            return ans;
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
            else
            {
                ViewState["ReportId"] = func.GenerateId("Select Max(ReportId) FROM Report");
                reportModel.ReportId = ViewState["ReportId"].ToString();
                reportModel.SupervisorId = func.IsExist($@"SELECT SupervisorId FROM  ReqSupervisor WHERE StudentId='{func.UserIdCookie()}'"); ;
                reportModel.StudentId = func.UserIdCookie();
                reportModel.Subject = txtSubject.Text;
                reportModel.Description = txtDescription.Text;
                if (fileAttach.HasFile)
                {
                    string imagePath = Server.MapPath("/photos/") + ViewState["ReportId"].ToString() + fileAttach.FileName;
                    fileAttach.PostedFile.SaveAs(imagePath);
                    reportModel.FileName = fileAttach.FileName;
                    reportModel.Attachment = "/photos/" + ViewState["ReportId"].ToString() + fileAttach.FileName;
                }
                else
                {
                    reportModel.Attachment = "";
                    reportModel.FileName = "";

                }
                reportModel.Status = "A";
                reportModel.Type = "Report";
                reportModel.SendTime = func.Date();
                bool a = reportGateway.SendReport(reportModel);
                if (a)
                {
                    Refresh();
                    bool ans = func.SendEmail("thesisdemo21@gmail.com", txtEmail.Text, "Progress Report", "<h3>Hello Teacher,</h3><br/>A student name=" + func.NameCookie() + ",Email=" + func.EmailCookie() + " send you his/her/their progress report. Please check his report.", "Thesis2021");
                    if (ans)
                    {
                        ScriptManager.RegisterStartupScript(this, Page.GetType(), "script", "alert('Report sent successfully.');", true);

                    }
                }
            }
        }

        private void Refresh()
        {
            txtName.Text = txtEmail.Text = txtSubject.Text = txtDescription.Text = "";
        }
    }
}