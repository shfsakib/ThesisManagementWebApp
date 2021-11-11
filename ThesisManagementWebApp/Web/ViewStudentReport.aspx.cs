using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ThesisManagementWebApp.DAL.Gateway;
using ThesisManagementWebApp.DAL.Model;

namespace ThesisManagementWebApp.Web
{
    public partial class ViewStudentReport : System.Web.UI.Page
    {
        private Function func;
        private RequestModel requestModel;
        private RequestGateway requestGateway;

        public ViewStudentReport()
        {
            func = Function.GetInstance();
            requestModel = RequestModel.GetInstance();
            requestGateway = RequestGateway.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (func.TypeCookie() != "Teacher")
                {
                    Response.Redirect("/Web/Login.aspx");
                }
                Load();

            }
        }
        private void Load()
        {
            func.LoadGrid(gridStudent, @"SELECT        Report.ReportId, Report.SupervisorId, Report.StudentId, Report.Subject, Report.Description, Report.FileName, Report.Attachment, Report.Status, Report.SendTime, Report.Type, DepartmentInfo.DepartmentName AS Department, 
                         Registration.Name, Registration.Email, Registration.MobileNo, Registration.Picture, Registration.IdNo
FROM            DepartmentInfo INNER JOIN
                         Registration ON DepartmentInfo.DepartmentId = Registration.DepartmentId INNER JOIN
                         Report ON Registration.RegistrationId = Report.StudentId WHERE Report.SupervisorId='" + func.UserIdCookie() + "'  ORDER BY  Report.ReportId ASC");
            func.BindDropDown(ddlBatch, "Batch", $@"SELECT DISTINCT Batch Name,Batch Id FROM Registration WHERE DATALENGTH(Batch)>0 ORDER BY Batch ASC");
            func.BindDropDown(ddlStudent, "SEarch student by name,email & mobile no", $@"SELECT        Registration.Name + ' | ' + Registration.Email + ' | ' + Registration.MobileNo AS Name, Registration.RegistrationId AS Id
FROM            Registration INNER JOIN
                         ReqSupervisor ON Registration.RegistrationId = ReqSupervisor.StudentId WHERE Type='Student' AND ReqSupervisor.SupervisorId='{func.UserIdCookie()}' ORDER BY Name ASC");
        }
        protected void gridStudent_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridStudent.PageIndex = e.NewPageIndex;
            Load();
        }


        public string Image(string img)
        {
            if (img == "")
            {
                return "../DashBoardFile/DummyPic.png";
            }
            else
            {
                return img;
            }
        }
        public string TimeC(string time)
        {
            string cTime = "";
            if (time != "")
            {
                DateTime dateTime = new DateTime();
                dateTime = Convert.ToDateTime(time);
                cTime = dateTime.ToString("hh:mm tt");
            }
            return cTime;
        }

        protected void lnkSearch_OnClickch_OnClick(object sender, EventArgs e)
        {
            if (ddlBatch.SelectedIndex > 0 && ddlSection.SelectedIndex > 0 && ddlStudent.SelectedIndex > 0)
            {
                func.LoadGrid(gridStudent, $@"SELECT        ReqSupervisor.ReqId, ReqSupervisor.SupervisorId, Registration.IdNo, ReqSupervisor.StudentId,ReqSupervisor.FileName, ReqSupervisor.Subject, ReqSupervisor.Description, ReqSupervisor.Attachment, ReqSupervisor.Status, ReqSupervisor.ReqTime, Registration.Name,
                          Registration.Email, Registration.MobileNo, Registration.Picture, DepartmentInfo.DepartmentName AS Department
FROM            ReqSupervisor INNER JOIN
                         Registration ON ReqSupervisor.StudentId = Registration.RegistrationId INNER JOIN
                         DepartmentInfo ON Registration.DepartmentId = DepartmentInfo.DepartmentId WHERE ReqSupervisor.Status='A' AND ReqSupervisor.SupervisorId='{ func.UserIdCookie() }' AND Registration.Name +' | '+Registration.Email+' | '+Registration.MobileNo LIKE '%{ ddlStudent.SelectedItem.ToString() }%' AND Registration.Type='Student' AND Registration.Batch='{ddlBatch.SelectedValue}' AND Registration.Gender='{ddlSection.SelectedValue}' ORDER BY  ReqSupervisor.ReqId ASC");
            }
            else if (ddlBatch.SelectedIndex > 0 && ddlSection.SelectedIndex <= 0 && ddlStudent.SelectedIndex > 0)
            {
                func.LoadGrid(gridStudent, $@"SELECT        ReqSupervisor.ReqId, ReqSupervisor.SupervisorId, Registration.IdNo, ReqSupervisor.StudentId,ReqSupervisor.FileName, ReqSupervisor.Subject, ReqSupervisor.Description, ReqSupervisor.Attachment, ReqSupervisor.Status, ReqSupervisor.ReqTime, Registration.Name,
                          Registration.Email, Registration.MobileNo, Registration.Picture, DepartmentInfo.DepartmentName AS Department
FROM            ReqSupervisor INNER JOIN
                         Registration ON ReqSupervisor.StudentId = Registration.RegistrationId INNER JOIN
                         DepartmentInfo ON Registration.DepartmentId = DepartmentInfo.DepartmentId WHERE ReqSupervisor.Status='A' AND ReqSupervisor.SupervisorId='{ func.UserIdCookie() }' AND   Registration.Name +' | '+Registration.Email+' | '+Registration.MobileNo LIKE '%{ ddlStudent.SelectedItem.ToString() }%' AND Registration.Type='Student'   AND Registration.Batch='{ddlBatch.SelectedValue}'  ORDER BY  ReqSupervisor.ReqId ASC");
            }
            else if (ddlBatch.SelectedIndex <= 0 && ddlSection.SelectedIndex > 0 && ddlStudent.SelectedIndex > 0)
            {
                func.LoadGrid(gridStudent, $@"SELECT        ReqSupervisor.ReqId, ReqSupervisor.SupervisorId, Registration.IdNo, ReqSupervisor.StudentId,ReqSupervisor.FileName, ReqSupervisor.Subject, ReqSupervisor.Description, ReqSupervisor.Attachment, ReqSupervisor.Status, ReqSupervisor.ReqTime, Registration.Name,
                          Registration.Email, Registration.MobileNo, Registration.Picture, DepartmentInfo.DepartmentName AS Department
FROM            ReqSupervisor INNER JOIN
                         Registration ON ReqSupervisor.StudentId = Registration.RegistrationId INNER JOIN
                         DepartmentInfo ON Registration.DepartmentId = DepartmentInfo.DepartmentId WHERE ReqSupervisor.Status='A' AND ReqSupervisor.SupervisorId='{ func.UserIdCookie() }' AND   Registration.Name +' | '+Registration.Email+' | '+Registration.MobileNo LIKE '%{ ddlStudent.SelectedItem.ToString() }%' AND Registration.Type='Student'  AND Registration.Gender='{ddlSection.SelectedValue}' ORDER BY  ReqSupervisor.ReqId ASC");
            }
            else if (ddlBatch.SelectedIndex <= 0 && ddlSection.SelectedIndex <= 0 && ddlStudent.SelectedIndex > 0)
            {
                func.LoadGrid(gridStudent, $@"SELECT        ReqSupervisor.ReqId, ReqSupervisor.SupervisorId, Registration.IdNo, ReqSupervisor.StudentId,ReqSupervisor.FileName, ReqSupervisor.Subject, ReqSupervisor.Description, ReqSupervisor.Attachment, ReqSupervisor.Status, ReqSupervisor.ReqTime, Registration.Name,
                          Registration.Email, Registration.MobileNo, Registration.Picture, DepartmentInfo.DepartmentName AS Department
FROM            ReqSupervisor INNER JOIN
                         Registration ON ReqSupervisor.StudentId = Registration.RegistrationId INNER JOIN
                         DepartmentInfo ON Registration.DepartmentId = DepartmentInfo.DepartmentId WHERE ReqSupervisor.Status='A' AND ReqSupervisor.SupervisorId='{ func.UserIdCookie() }' AND   Registration.Name +' | '+Registration.Email+' | '+Registration.MobileNo LIKE '%{ ddlStudent.SelectedItem.ToString() }%' AND Registration.Type='Student'   ORDER BY  ReqSupervisor.ReqId ASC");
            }
            else if (ddlBatch.SelectedIndex <= 0 && ddlSection.SelectedIndex > 0 && ddlStudent.SelectedIndex <= 0)
            {
                func.LoadGrid(gridStudent, $@"SELECT        ReqSupervisor.ReqId, ReqSupervisor.SupervisorId, Registration.IdNo, ReqSupervisor.StudentId,ReqSupervisor.FileName, ReqSupervisor.Subject, ReqSupervisor.Description, ReqSupervisor.Attachment, ReqSupervisor.Status, ReqSupervisor.ReqTime, Registration.Name,
                          Registration.Email, Registration.MobileNo, Registration.Picture, DepartmentInfo.DepartmentName AS Department
FROM            ReqSupervisor INNER JOIN
                         Registration ON ReqSupervisor.StudentId = Registration.RegistrationId INNER JOIN
                         DepartmentInfo ON Registration.DepartmentId = DepartmentInfo.DepartmentId WHERE ReqSupervisor.Status='A' AND ReqSupervisor.SupervisorId='{ func.UserIdCookie() }' AND  Registration.Gender='{ddlSection.SelectedValue}' AND Registration.Type='Student'   ORDER BY  ReqSupervisor.ReqId ASC");
            }
            else if (ddlBatch.SelectedIndex > 0 && ddlSection.SelectedIndex <= 0 && ddlStudent.SelectedIndex <= 0)
            {
                func.LoadGrid(gridStudent, $@"SELECT        ReqSupervisor.ReqId, ReqSupervisor.SupervisorId, Registration.IdNo, ReqSupervisor.StudentId,ReqSupervisor.FileName, ReqSupervisor.Subject, ReqSupervisor.Description, ReqSupervisor.Attachment, ReqSupervisor.Status, ReqSupervisor.ReqTime, Registration.Name,
                          Registration.Email, Registration.MobileNo, Registration.Picture, DepartmentInfo.DepartmentName AS Department
FROM            ReqSupervisor INNER JOIN
                         Registration ON ReqSupervisor.StudentId = Registration.RegistrationId INNER JOIN
                         DepartmentInfo ON Registration.DepartmentId = DepartmentInfo.DepartmentId WHERE ReqSupervisor.Status='A' AND ReqSupervisor.SupervisorId='" + func.UserIdCookie() + "' AND Registration.Batch='{ddlSection.SelectedValue}' AND Registration.Type='Student'  ORDER BY  ReqSupervisor.ReqId ASC");
            }
            else
            {
                Load();
            }
        }

        protected void btnSend_OnClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            TextBox txtReview = (TextBox)button.Parent.FindControl("txtReview");
            Label lblEmail = (Label)button.Parent.FindControl("lblEmail");
            if (txtReview.Text == "")
            {
                func.PopAlert(this, "Review is required to send feedback");
            }
            else
            {
                bool ans = func.SendEmail("mail.thesisproject@gmail.com", lblEmail.Text, "Supervisor Progress Report Feedback",
                     @"Hello Student,<br/>" + txtReview.Text + "<br/>Thank you.", "thesisandproject");
                if (ans)
                {
                    ScriptManager.RegisterStartupScript(this, Page.GetType(), "script", "alert('Feedback sent successfully');", true);
                    txtReview.Text = "";
                }
            }
        }
    }
}