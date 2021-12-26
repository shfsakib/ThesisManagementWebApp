using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ThesisManagementWebApp.Web
{
    public partial class view_assigned_list : System.Web.UI.Page
    {
        private Function func;

        public view_assigned_list()
        {
            func = Function.GetInstance();
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
            func.LoadGrid(gridStudent, $@"SELECT        ReqSupervisor.ReqId, ReqSupervisor.SupervisorId AS TeacherId, Registration.IdNo AS StudentIdNo, ReqSupervisor.StudentId, ReqSupervisor.FileName, ReqSupervisor.Subject, ReqSupervisor.Description, 
                         ReqSupervisor.Attachment, ReqSupervisor.Status, ReqSupervisor.ReqTime, Registration.Name AS StudentName, Registration.Email AS StudentEmail, Registration.MobileNo AS StudentMobileNo, 
                         Registration.Picture AS StudentPicture, Registration_1.Name TeacherName, Registration_1.Email TeacherEmail, Registration_1.MobileNo TeacherMobileNo, Registration_1.Picture TeacherPicture, Registration_1.IdNo TeacherIdNo
FROM            ReqSupervisor INNER JOIN
                         Registration ON ReqSupervisor.StudentId = Registration.RegistrationId INNER JOIN
                         Registration AS Registration_1 ON ReqSupervisor.SupervisorId = Registration_1.RegistrationId WHERE ReqSupervisor.Status='A'  ORDER BY  ReqSupervisor.ReqId ASC");
            func.BindDropDown(ddlBatch, "Batch", $@"SELECT DISTINCT Batch Name,Batch Id FROM Registration WHERE DATALENGTH(Batch)>0 ORDER BY Batch ASC");
        }
        protected void lnkSearch_OnClick(object sender, EventArgs e)
        {
            if (ddlBatch.SelectedIndex <= 0 && ddlSection.SelectedIndex > 0)
            {
                func.LoadGrid(gridStudent, $@"SELECT        ReqSupervisor.ReqId, ReqSupervisor.SupervisorId AS TeacherId, Registration.IdNo AS StudentIdNo, ReqSupervisor.StudentId, ReqSupervisor.FileName, ReqSupervisor.Subject, ReqSupervisor.Description, 
                         ReqSupervisor.Attachment, ReqSupervisor.Status, ReqSupervisor.ReqTime, Registration.Name AS StudentName, Registration.Email AS StudentEmail, Registration.MobileNo AS StudentMobileNo, 
                         Registration.Picture AS StudentPicture, Registration_1.Name TeacherName, Registration_1.Email TeacherEmail, Registration_1.MobileNo TeacherMobileNo, Registration_1.Picture TeacherPicture, Registration_1.IdNo TeacherIdNo
FROM            ReqSupervisor INNER JOIN
                         Registration ON ReqSupervisor.StudentId = Registration.RegistrationId INNER JOIN
                         Registration AS Registration_1 ON ReqSupervisor.SupervisorId = Registration_1.RegistrationId WHERE ReqSupervisor.Status='A' AND  Registration.Gender='{ddlSection.SelectedValue}' AND Registration.Type='Student'   ORDER BY  ReqSupervisor.ReqId ASC");
            }
            else if (ddlBatch.SelectedIndex > 0 && ddlSection.SelectedIndex <= 0)
            {
                func.LoadGrid(gridStudent, $@"SELECT        ReqSupervisor.ReqId, ReqSupervisor.SupervisorId AS TeacherId, Registration.IdNo AS StudentIdNo, ReqSupervisor.StudentId, ReqSupervisor.FileName, ReqSupervisor.Subject, ReqSupervisor.Description, 
                         ReqSupervisor.Attachment, ReqSupervisor.Status, ReqSupervisor.ReqTime, Registration.Name AS StudentName, Registration.Email AS StudentEmail, Registration.MobileNo AS StudentMobileNo, 
                         Registration.Picture AS StudentPicture, Registration_1.Name TeacherName, Registration_1.Email TeacherEmail, Registration_1.MobileNo TeacherMobileNo, Registration_1.Picture TeacherPicture, Registration_1.IdNo TeacherIdNo
FROM            ReqSupervisor INNER JOIN
                         Registration ON ReqSupervisor.StudentId = Registration.RegistrationId INNER JOIN
                         Registration AS Registration_1 ON ReqSupervisor.SupervisorId = Registration_1.RegistrationId WHERE ReqSupervisor.Status='A' AND Registration.Batch='{ddlBatch.SelectedValue}' AND Registration.Type='Student'  ORDER BY  ReqSupervisor.ReqId ASC");
            }
            else
            {
                Load();
            }
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

        protected void gridStudent_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridStudent.PageIndex = e.NewPageIndex;
            Load();
        }
    }
}