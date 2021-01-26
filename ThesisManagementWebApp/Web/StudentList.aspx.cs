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
    public partial class StudentList : System.Web.UI.Page
    {
        private Function func;
        private RegistrationModel registrationModel;
        private RegistrationGateway registrationGateway;

        public StudentList()
        {
            func = Function.GetInstance();
            registrationModel = RegistrationModel.GetInstance();
            registrationGateway = RegistrationGateway.GetInstance();
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
            func.LoadGrid(gridStudent, @"SELECT        Registration.RegistrationId, Registration.Name, Registration.Email, Registration.MobileNo, Registration.DOB, Registration.Gender, Registration.Address, Registration.Type, Registration.Picture, Registration.Designation, 
                         Registration.FreeScheduleFrom, Registration.FreeScheduleTo, Registration.IdNo, Registration.Preffer, Registration.Status, Registration.InTime, DepartmentInfo.DepartmentName AS Department
FROM            Registration INNER JOIN
                         DepartmentInfo ON Registration.DepartmentId = DepartmentInfo.DepartmentId WHERE Registration.Type='Student' AND Registration.Status='" + ddlStatus.SelectedValue + "' ORDER BY Registration.RegistrationId ASC");
        }
        protected void ddlStatus_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Load();
        }

        protected void gridStudent_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridStudent.PageIndex = e.NewPageIndex;
            Load();
        }

        protected void gridStudent_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkAccept = (LinkButton)e.Row.FindControl("lnActive");
                LinkButton lnkInactive = (LinkButton)e.Row.FindControl("lnkInactive");
                if (ddlStatus.SelectedValue == "A")
                {
                    lnkAccept.Visible = false;
                    lnkInactive.Visible = true;
                }
                else
                {
                    lnkAccept.Visible = true;
                    lnkInactive.Visible = false;
                }
            }
        }

        protected void lnActive_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            HiddenField regId = (HiddenField)linkButton.Parent.FindControl("HiddenField1");
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

        protected void lnkInactive_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            HiddenField regId = (HiddenField)linkButton.Parent.FindControl("HiddenField1");
            registrationModel.RegistrationId = regId.Value;
            registrationModel.Status = "I";
            bool a = registrationGateway.UpdateUser(registrationModel);
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