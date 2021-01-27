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
    public partial class ViewStudentReq : System.Web.UI.Page
    {
        private Function func;
        private RequestModel requestModel;
        private RequestGateway requestGateway;

        public ViewStudentReq()
        {
            func = Function.GetInstance();
            requestModel = RequestModel.GetInstance();
            requestGateway = RequestGateway.GetInstance();
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
            func.LoadGrid(gridStudent, @"SELECT        ReqSupervisor.ReqId, ReqSupervisor.SupervisorId, Registration.IdNo, ReqSupervisor.StudentId,ReqSupervisor.FileName, ReqSupervisor.Subject, ReqSupervisor.Description, ReqSupervisor.Attachment, ReqSupervisor.Status, ReqSupervisor.ReqTime, Registration.Name,
                          Registration.Email, Registration.MobileNo, Registration.Picture, DepartmentInfo.DepartmentName AS Department
FROM            ReqSupervisor INNER JOIN
                         Registration ON ReqSupervisor.StudentId = Registration.RegistrationId INNER JOIN
                         DepartmentInfo ON Registration.DepartmentId = DepartmentInfo.DepartmentId WHERE ReqSupervisor.SupervisorId='" + func.UserIdCookie() + "'  ORDER BY  ReqSupervisor.ReqId ASC");
        }


        protected void txtSearch_OnTextChanged(object sender, EventArgs e)
        {
            func.LoadGrid(gridStudent, @"SELECT        ReqSupervisor.ReqId, ReqSupervisor.SupervisorId, Registration.IdNo, ReqSupervisor.StudentId,ReqSupervisor.FileName, ReqSupervisor.Subject, ReqSupervisor.Description, ReqSupervisor.Attachment, ReqSupervisor.Status, ReqSupervisor.ReqTime, Registration.Name,
                          Registration.Email, Registration.MobileNo, Registration.Picture, DepartmentInfo.DepartmentName AS Department
FROM            ReqSupervisor INNER JOIN
                         Registration ON ReqSupervisor.StudentId = Registration.RegistrationId INNER JOIN
                         DepartmentInfo ON Registration.DepartmentId = DepartmentInfo.DepartmentId WHERE ReqSupervisor.SupervisorId='" + func.UserIdCookie() + "' AND Name +' | '+Email LIKE '%" + txtSearch.Text + "%' ORDER BY  ReqSupervisor.ReqId ASC");

        }

        protected void gridStudent_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridStudent.PageIndex = e.NewPageIndex;
            Load();
        }

        protected void lnkAccept_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            HiddenField HiddenField1 = (HiddenField)linkButton.Parent.FindControl("HiddenField1");
            requestModel.StudentId = HiddenField1.Value;
            requestModel.Status = "A";
            requestModel.SupervisorId = func.UserIdCookie();
            bool a = requestGateway.UpdateReqStatus(requestModel);
            if (a)
            {
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "script", "alert('Request accepted successfully');", true);

                Load();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "script", "alert('Request accepted failed');", true);

            }
        }

        protected void lnkReject_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            HiddenField HiddenField1 = (HiddenField)linkButton.Parent.FindControl("HiddenField1");
            requestModel.StudentId = HiddenField1.Value;
            requestModel.SupervisorId = func.UserIdCookie();
            bool a = requestGateway.DeleteReq(requestModel);
            if (a)
            {
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "script", "alert('Request removed successfully');", true);

                Load();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "script", "alert('Request removed failed');", true);

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