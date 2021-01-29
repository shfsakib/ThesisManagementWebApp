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
    public partial class TeacherApproval : System.Web.UI.Page
    {
        private Function func;
        private RegistrationModel registrationModel;
        private RegistrationGateway registrationGateway;

        public TeacherApproval()
        {
            func=Function.GetInstance();
            registrationModel=RegistrationModel.GetInstance();
            registrationGateway=RegistrationGateway.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (func.TypeCookie() != "Admin")
                {
                    Response.Redirect("/Web/Login.aspx");
                }
                Load();
            }
        }

        private void Load()
        {
            func.LoadGrid(gridTeacher, @"SELECT        Registration.RegistrationId, Registration.Name, Registration.Email, Registration.MobileNo, Registration.DOB, Registration.Gender, Registration.Address, Registration.Type, Registration.Picture, Registration.Designation, 
                         Registration.FreeScheduleFrom, Registration.FreeScheduleTo, Registration.IdNo, Registration.Preffer, Registration.Status, Registration.InTime, DepartmentInfo.DepartmentName AS Department
FROM            Registration INNER JOIN
                         DepartmentInfo ON Registration.DepartmentId = DepartmentInfo.DepartmentId WHERE Registration.Type='Teacher' AND Registration.Status='I' ORDER BY Registration.RegistrationId ASC");
        }
        protected void gridTeacher_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridTeacher.PageIndex = e.NewPageIndex;
            Load();
        }

        protected void lnkAccpet_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton) sender;
            HiddenField regId = (HiddenField) linkButton.Parent.FindControl("HiddenField1");
            registrationModel.RegistrationId = regId.Value;
            registrationModel.Status = "A";
            bool a = registrationGateway.UpdateUser(registrationModel);
            if (a)
            {
                Response.Write("<script language=javascript>alert('Registration accpeted successfully');</script>");
                Load();
            }
            else
            {
                Response.Write("<script language=javascript>alert('Failed to accept');</script>");
            }
        }

        protected void lnkReject_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            HiddenField regId = (HiddenField)linkButton.Parent.FindControl("HiddenField1");
            registrationModel.RegistrationId = regId.Value; 
            bool a = registrationGateway.DeleteUser(registrationModel);
            if (a)
            {
                Response.Write("<script language=javascript>alert('Registration rejected successfully');</script>");
                Load();
            }
            else
            {
                Response.Write("<script language=javascript>alert('Failed to reject');</script>");
            }
        }

        public string Image(string img)
        {
            if (img=="")
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