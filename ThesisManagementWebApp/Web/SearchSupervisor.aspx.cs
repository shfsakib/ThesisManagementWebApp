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
    public partial class SearchSupervisor : System.Web.UI.Page
    {
        private Function func;
        private RegistrationModel registrationModel;
        private RegistrationGateway registrationGateway;

        public SearchSupervisor()
        {
            func = Function.GetInstance();
            registrationModel = RegistrationModel.GetInstance();
            registrationGateway = RegistrationGateway.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (func.TypeCookie() != "Student" )
                {
                    Response.Redirect("/Web/Login.aspx");
                }
                Load();
            }
        }
        private void Load()
        {
            func.LoadGrid(gridTeacher, @"SELECT        Registration.RegistrationId, Registration.Name, Registration.Email, Registration.MobileNo,   Registration.Gender, Registration.Type, Registration.Picture, Registration.Designation, 
                         Registration.FreeScheduleFrom, Registration.FreeScheduleTo, Registration.IdNo, Registration.Preffer, Registration.Status, Registration.InTime, DepartmentInfo.DepartmentName AS Department
FROM            Registration INNER JOIN
                         DepartmentInfo ON Registration.DepartmentId = DepartmentInfo.DepartmentId WHERE Registration.Type='Teacher' AND Registration.Status='A' AND Preffer='" + ddlType.Text + "' ORDER BY Registration.RegistrationId ASC");
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
        protected void gridTeacher_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gridTeacher_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridTeacher.PageIndex = e.NewPageIndex;
            Load();
        }

        protected void lnkReq_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            HiddenField regId = (HiddenField)linkButton.Parent.FindControl("HiddenField1");
            Response.Write("<script>window.open('/Web/SendSupervisorReq.aspx?RId=" + regId.Value + "','_blank');</script>");
        }

        protected void ddlType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Load();
        }

        protected void txtSearch_OnTextChanged(object sender, EventArgs e)
        {
            func.LoadGrid(gridTeacher, @"SELECT        Registration.RegistrationId, Registration.Name, Registration.Email, Registration.MobileNo, Registration.DOB, Registration.Gender, Registration.Address, Registration.Type, Registration.Picture, Registration.Designation, 
                         Registration.FreeScheduleFrom, Registration.FreeScheduleTo, Registration.IdNo, Registration.Preffer, Registration.Status, Registration.InTime, DepartmentInfo.DepartmentName AS Department
FROM            Registration INNER JOIN
                         DepartmentInfo ON Registration.DepartmentId = DepartmentInfo.DepartmentId WHERE Registration.Type='Teacher' AND Registration.Status='A' AND Preffer='" + ddlType.Text + "' AND Name +' | '+Email LIKE '" + txtSearch.Text + "' ORDER BY Registration.RegistrationId ASC");

        }

    }
}