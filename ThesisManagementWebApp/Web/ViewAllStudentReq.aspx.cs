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
                if (func.TypeCookie() != "Coordinator" )
                {
                    Response.Redirect("/Web/Login.aspx");
                }
                Load();

            }
        }
        private void Load()
        {
            func.LoadGrid(gridStudent, @"SELECT        ReqSupervisor.ReqId, ReqSupervisor.SupervisorId, ReqSupervisor.StudentId, ReqSupervisor.Subject, ReqSupervisor.Description, ReqSupervisor.FileName, ReqSupervisor.Attachment, ReqSupervisor.Status, 
                         ReqSupervisor.ReqTime, Registration.Name, Registration.Email, Registration.MobileNo, Registration.IdNo, DepartmentInfo.DepartmentName AS Department, Registration_1.Name AS TeacherName, 
                         Registration_1.Email AS TeacherEmail, Registration.Picture
FROM            ReqSupervisor INNER JOIN
                         Registration ON ReqSupervisor.StudentId = Registration.RegistrationId INNER JOIN
                         DepartmentInfo ON Registration.DepartmentId = DepartmentInfo.DepartmentId INNER JOIN
                         Registration AS Registration_1 ON ReqSupervisor.SupervisorId = Registration_1.RegistrationId ORDER BY  ReqSupervisor.ReqId ASC");
        }
        protected void txtSearch_OnTextChanged(object sender, EventArgs e)
        {
            func.LoadGrid(gridStudent, @"SELECT        ReqSupervisor.ReqId, ReqSupervisor.SupervisorId, ReqSupervisor.StudentId, ReqSupervisor.Subject, ReqSupervisor.Description, ReqSupervisor.FileName, ReqSupervisor.Attachment, ReqSupervisor.Status, 
                         ReqSupervisor.ReqTime, Registration.Name, Registration.Email, Registration.MobileNo, Registration.IdNo, DepartmentInfo.DepartmentName AS Department, Registration_1.Name AS TeacherName, 
                         Registration_1.Email AS TeacherEmail, Registration.Picture
FROM            ReqSupervisor INNER JOIN
                         Registration ON ReqSupervisor.StudentId = Registration.RegistrationId INNER JOIN
                         DepartmentInfo ON Registration.DepartmentId = DepartmentInfo.DepartmentId INNER JOIN
                         Registration AS Registration_1 ON ReqSupervisor.SupervisorId = Registration_1.RegistrationId WHERE  Name +' | '+Email LIKE '%" + txtSearch.Text + "%' ORDER BY  ReqSupervisor.ReqId ASC");


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
    }
}