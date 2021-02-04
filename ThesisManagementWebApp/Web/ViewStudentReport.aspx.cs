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
                if (func.TypeCookie() != "Teacher" )
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
        }
        protected void gridStudent_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridStudent.PageIndex = e.NewPageIndex;
            Load();
        }

        protected void txtSearch_OnTextChanged(object sender, EventArgs e)
        {
            func.LoadGrid(gridStudent, @"SELECT        Report.ReportId, Report.SupervisorId, Report.StudentId, Report.Subject, Report.Description, Report.FileName, Report.Attachment, Report.Status, Report.SendTime, Report.Type, DepartmentInfo.DepartmentName AS Department, 
                         Registration.Name, Registration.Email, Registration.MobileNo, Registration.Picture, Registration.IdNo
FROM            DepartmentInfo INNER JOIN
                         Registration ON DepartmentInfo.DepartmentId = Registration.DepartmentId INNER JOIN
                         Report ON Registration.RegistrationId = Report.StudentId WHERE Report.SupervisorId='" + func.UserIdCookie() + "' AND Name +' | '+Email LIKE '%" + txtSearch.Text + "%' ORDER BY  Report.ReportId ASC");

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
    }
}