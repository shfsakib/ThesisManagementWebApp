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
    public partial class ViewAllStudentReq : System.Web.UI.Page
    {
        private Function func;
        private RequestModel requestModel;
        private RequestGateway requestGateway;

        public ViewAllStudentReq()
        {
            func = Function.GetInstance();
            requestModel = RequestModel.GetInstance();
            requestGateway = RequestGateway.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (func.TypeCookie() != "Coordinator")
                {
                    Response.Redirect("/Web/Login.aspx");
                }
                Load();

            }
        }
        private void Load()
        {
            func.BindDropDown(ddlBatch, "Batch", $@"SELECT DISTINCT Batch Name,Batch Id FROM Registration WHERE DATALENGTH(Batch)>0 ORDER BY Batch ASC");
            func.LoadGrid(gridStudent, @"SELECT        ReqSupervisor.ReqId, ReqSupervisor.SupervisorId, ReqSupervisor.StudentId, ReqSupervisor.Subject, ReqSupervisor.Description, ReqSupervisor.FileName, ReqSupervisor.Attachment, ReqSupervisor.Status, 
                         ReqSupervisor.ReqTime, Registration.Name, Registration.Email, Registration.MobileNo, Registration.IdNo, DepartmentInfo.DepartmentName AS Department, Registration_1.Name AS TeacherName, 
                         Registration_1.Email AS TeacherEmail, Registration.Picture
FROM            ReqSupervisor INNER JOIN
                         Registration ON ReqSupervisor.StudentId = Registration.RegistrationId INNER JOIN
                         DepartmentInfo ON Registration.DepartmentId = DepartmentInfo.DepartmentId INNER JOIN
                         Registration AS Registration_1 ON ReqSupervisor.SupervisorId = Registration_1.RegistrationId WHERE Registration.Type='Student' AND ReqSupervisor.Status='I'  ORDER BY  ReqSupervisor.ReqId ASC");
            func.BindDropDown(ddlStudent, "SEarch student by name,email & mobile no", $@"SELECT        Registration.Name + ' | ' + Registration.Email + ' | ' + Registration.MobileNo AS Name, Registration.RegistrationId AS Id
FROM            Registration INNER JOIN
                         ReqSupervisor ON Registration.RegistrationId = ReqSupervisor.StudentId WHERE Type='Student' AND ReqSupervisor.Status='I'  ORDER BY Name ASC");
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

        protected void lnkSearch_OnClick(object sender, EventArgs e)
        {
            if (ddlBatch.SelectedIndex > 0 && ddlSection.SelectedIndex > 0 && ddlStudent.SelectedIndex > 0)
            {
                func.LoadGrid(gridStudent, $@"SELECT        ReqSupervisor.ReqId, ReqSupervisor.SupervisorId, ReqSupervisor.StudentId, ReqSupervisor.Subject, ReqSupervisor.Description, ReqSupervisor.FileName, ReqSupervisor.Attachment, ReqSupervisor.Status, 
                         ReqSupervisor.ReqTime, Registration.Name, Registration.Email, Registration.MobileNo, Registration.IdNo, DepartmentInfo.DepartmentName AS Department, Registration_1.Name AS TeacherName, 
                         Registration_1.Email AS TeacherEmail, Registration.Picture
FROM            ReqSupervisor INNER JOIN
                         Registration ON ReqSupervisor.StudentId = Registration.RegistrationId INNER JOIN
                         DepartmentInfo ON Registration.DepartmentId = DepartmentInfo.DepartmentId INNER JOIN
                         Registration AS Registration_1 ON ReqSupervisor.SupervisorId = Registration_1.RegistrationId WHERE  Registration.Name +' | '+Registration.Email+' | '+Registration.MobileNo LIKE '%{ ddlStudent.SelectedItem.ToString() }%' AND Registration.Type='Student' AND ReqSupervisor.Status='A' AND Registration.Batch='{ddlBatch.SelectedValue}' AND Registration.Gender='{ddlSection.SelectedValue}' ORDER BY  ReqSupervisor.ReqId ASC");
            }
            else if (ddlBatch.SelectedIndex > 0 && ddlSection.SelectedIndex <= 0 && ddlStudent.SelectedIndex > 0)
            {
                func.LoadGrid(gridStudent, $@"SELECT        ReqSupervisor.ReqId, ReqSupervisor.SupervisorId, ReqSupervisor.StudentId, ReqSupervisor.Subject, ReqSupervisor.Description, ReqSupervisor.FileName, ReqSupervisor.Attachment, ReqSupervisor.Status, 
                         ReqSupervisor.ReqTime, Registration.Name, Registration.Email, Registration.MobileNo, Registration.IdNo, DepartmentInfo.DepartmentName AS Department, Registration_1.Name AS TeacherName, 
                         Registration_1.Email AS TeacherEmail, Registration.Picture
FROM            ReqSupervisor INNER JOIN
                         Registration ON ReqSupervisor.StudentId = Registration.RegistrationId INNER JOIN
                         DepartmentInfo ON Registration.DepartmentId = DepartmentInfo.DepartmentId INNER JOIN
                         Registration AS Registration_1 ON ReqSupervisor.SupervisorId = Registration_1.RegistrationId WHERE  Registration.Name +' | '+Registration.Email+' | '+Registration.MobileNo LIKE '%{ ddlStudent.SelectedItem.ToString() }%' AND Registration.Type='Student' AND ReqSupervisor.Status='A' AND Registration.Batch='{ddlBatch.SelectedValue}'  ORDER BY  ReqSupervisor.ReqId ASC");
            }
            else if (ddlBatch.SelectedIndex <= 0 && ddlSection.SelectedIndex > 0 && ddlStudent.SelectedIndex > 0)
            {
                func.LoadGrid(gridStudent, $@"SELECT        ReqSupervisor.ReqId, ReqSupervisor.SupervisorId, ReqSupervisor.StudentId, ReqSupervisor.Subject, ReqSupervisor.Description, ReqSupervisor.FileName, ReqSupervisor.Attachment, ReqSupervisor.Status, 
                         ReqSupervisor.ReqTime, Registration.Name, Registration.Email, Registration.MobileNo, Registration.IdNo, DepartmentInfo.DepartmentName AS Department, Registration_1.Name AS TeacherName, 
                         Registration_1.Email AS TeacherEmail, Registration.Picture
FROM            ReqSupervisor INNER JOIN
                         Registration ON ReqSupervisor.StudentId = Registration.RegistrationId INNER JOIN
                         DepartmentInfo ON Registration.DepartmentId = DepartmentInfo.DepartmentId INNER JOIN
                         Registration AS Registration_1 ON ReqSupervisor.SupervisorId = Registration_1.RegistrationId WHERE  Registration.Name +' | '+Registration.Email+' | '+Registration.MobileNo LIKE '%{ ddlStudent.SelectedItem.ToString() }%' AND Registration.Type='Student' AND ReqSupervisor.Status='A' AND Registration.Gender='{ddlSection.SelectedValue}' ORDER BY  ReqSupervisor.ReqId ASC");
            }
            else if (ddlBatch.SelectedIndex <= 0 && ddlSection.SelectedIndex <= 0 && ddlStudent.SelectedIndex > 0)
            {
                func.LoadGrid(gridStudent, $@"SELECT        ReqSupervisor.ReqId, ReqSupervisor.SupervisorId, ReqSupervisor.StudentId, ReqSupervisor.Subject, ReqSupervisor.Description, ReqSupervisor.FileName, ReqSupervisor.Attachment, ReqSupervisor.Status, 
                         ReqSupervisor.ReqTime, Registration.Name, Registration.Email, Registration.MobileNo, Registration.IdNo, DepartmentInfo.DepartmentName AS Department, Registration_1.Name AS TeacherName, 
                         Registration_1.Email AS TeacherEmail, Registration.Picture
FROM            ReqSupervisor INNER JOIN
                         Registration ON ReqSupervisor.StudentId = Registration.RegistrationId INNER JOIN
                         DepartmentInfo ON Registration.DepartmentId = DepartmentInfo.DepartmentId INNER JOIN
                         Registration AS Registration_1 ON ReqSupervisor.SupervisorId = Registration_1.RegistrationId WHERE  Registration.Name +' | '+Registration.Email+' | '+Registration.MobileNo LIKE '%{ ddlStudent.SelectedItem.ToString() }%' AND Registration.Type='Student' AND ReqSupervisor.Status='A' ORDER BY  ReqSupervisor.ReqId ASC");
            }
            else if (ddlBatch.SelectedIndex <= 0 && ddlSection.SelectedIndex > 0 && ddlStudent.SelectedIndex <= 0)
            {
                func.LoadGrid(gridStudent, $@"SELECT        ReqSupervisor.ReqId, ReqSupervisor.SupervisorId, ReqSupervisor.StudentId, ReqSupervisor.Subject, ReqSupervisor.Description, ReqSupervisor.FileName, ReqSupervisor.Attachment, ReqSupervisor.Status, 
                         ReqSupervisor.ReqTime, Registration.Name, Registration.Email, Registration.MobileNo, Registration.IdNo, DepartmentInfo.DepartmentName AS Department, Registration_1.Name AS TeacherName, 
                         Registration_1.Email AS TeacherEmail, Registration.Picture
FROM            ReqSupervisor INNER JOIN
                         Registration ON ReqSupervisor.StudentId = Registration.RegistrationId INNER JOIN
                         DepartmentInfo ON Registration.DepartmentId = DepartmentInfo.DepartmentId INNER JOIN
                         Registration AS Registration_1 ON ReqSupervisor.SupervisorId = Registration_1.RegistrationId WHERE  Registration.Gender='{ddlSection.SelectedValue}' AND Registration.Type='Student' AND ReqSupervisor.Status='A' ORDER BY  ReqSupervisor.ReqId ASC");
            }
            else if (ddlBatch.SelectedIndex > 0 && ddlSection.SelectedIndex <= 0 && ddlStudent.SelectedIndex <= 0)
            {
                func.LoadGrid(gridStudent, $@"SELECT        ReqSupervisor.ReqId, ReqSupervisor.SupervisorId, ReqSupervisor.StudentId, ReqSupervisor.Subject, ReqSupervisor.Description, ReqSupervisor.FileName, ReqSupervisor.Attachment, ReqSupervisor.Status, 
                         ReqSupervisor.ReqTime, Registration.Name, Registration.Email, Registration.MobileNo, Registration.IdNo, DepartmentInfo.DepartmentName AS Department, Registration_1.Name AS TeacherName, 
                         Registration_1.Email AS TeacherEmail, Registration.Picture
FROM            ReqSupervisor INNER JOIN
                         Registration ON ReqSupervisor.StudentId = Registration.RegistrationId INNER JOIN
                         DepartmentInfo ON Registration.DepartmentId = DepartmentInfo.DepartmentId INNER JOIN
                         Registration AS Registration_1 ON ReqSupervisor.SupervisorId = Registration_1.RegistrationId WHERE  Registration.Batch='{ddlSection.SelectedValue}' AND Registration.Type='Student' AND ReqSupervisor.Status='A' ORDER BY  ReqSupervisor.ReqId ASC");
            }
            else
            {
                Load();
            }
        }
    }
}