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
    public partial class SupervisedStudentList : System.Web.UI.Page
    {
        private Function func;
        private RequestModel requestModel;
        private RequestGateway requestGateway;

        public SupervisedStudentList()
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
            func.LoadGrid(gridStudent, $@"SELECT        ReqSupervisor.ReqId, ReqSupervisor.SupervisorId, Registration.IdNo, ReqSupervisor.StudentId,ReqSupervisor.FileName, ReqSupervisor.Subject, ReqSupervisor.Description, ReqSupervisor.Attachment, ReqSupervisor.Status, ReqSupervisor.ReqTime, Registration.Name,
                          Registration.Email, Registration.MobileNo, Registration.Picture, DepartmentInfo.DepartmentName AS Department
FROM            ReqSupervisor INNER JOIN
                         Registration ON ReqSupervisor.StudentId = Registration.RegistrationId INNER JOIN
                         DepartmentInfo ON Registration.DepartmentId = DepartmentInfo.DepartmentId WHERE ReqSupervisor.Status='A' AND ReqSupervisor.SupervisorId='{ func.UserIdCookie() }' ORDER BY  ReqSupervisor.ReqId ASC");
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

        protected void lnkSearch_OnClick(object sender, EventArgs e)
        {
            if (ddlBatch.SelectedIndex > 0 && ddlSection.SelectedIndex > 0 && ddlStudent.SelectedIndex > 0)
            {
                func.LoadGrid(gridStudent, $@"SELECT        ReqSupervisor.ReqId, ReqSupervisor.SupervisorId, Registration.IdNo, ReqSupervisor.StudentId,ReqSupervisor.FileName, ReqSupervisor.Subject, ReqSupervisor.Description, ReqSupervisor.Attachment, ReqSupervisor.Status, ReqSupervisor.ReqTime, Registration.Name,
                          Registration.Email, Registration.MobileNo, Registration.Picture, DepartmentInfo.DepartmentName AS Department
FROM            ReqSupervisor INNER JOIN
                         Registration ON ReqSupervisor.StudentId = Registration.RegistrationId INNER JOIN
                         DepartmentInfo ON Registration.DepartmentId = DepartmentInfo.DepartmentId WHERE ReqSupervisor.Status='A' AND ReqSupervisor.SupervisorId='{ func.UserIdCookie() }' AND Registration.Name +' | '+Registration.Email+' | '+Registration.MobileNo LIKE '%{ddlStudent.SelectedItem.ToString()}%' AND Registration.Type='Student' AND Registration.Batch='{ddlBatch.SelectedValue}' AND Registration.Gender='{ddlSection.SelectedValue}' ORDER BY  ReqSupervisor.ReqId ASC");
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
                         DepartmentInfo ON Registration.DepartmentId = DepartmentInfo.DepartmentId WHERE ReqSupervisor.Status='A' AND ReqSupervisor.SupervisorId='{ func.UserIdCookie() }' AND Registration.Batch='{ddlSection.SelectedValue}' AND Registration.Type='Student'  ORDER BY  ReqSupervisor.ReqId ASC");
            }
            else
            {
                Load();
            }
        }
    }
}