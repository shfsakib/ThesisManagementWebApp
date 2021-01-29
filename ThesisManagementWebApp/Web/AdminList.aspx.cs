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
    public partial class AdminList : System.Web.UI.Page
    {
        private Function func;
        private RegistrationModel registrationModel;
        private RegistrationGateway registrationGateway;

        public AdminList()
        {
            func = Function.GetInstance();
            registrationModel = RegistrationModel.GetInstance();
            registrationGateway = RegistrationGateway.GetInstance();
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
            func.LoadGrid(gridAdmin, @"SELECT * FROM Registration WHERE Registration.Type='Admin' AND Registration.Status='" + ddlStatus.SelectedValue + "' ORDER BY Registration.RegistrationId ASC");
        }
        protected void ddlStatus_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Load();
        }

        protected void gridAdmin_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridAdmin.PageIndex = e.NewPageIndex;
            Load();
        }

        protected void gridAdmin_OnRowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void lnActive_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            HiddenField regId = (HiddenField)linkButton.Parent.FindControl("HiddenField1");
            registrationModel.RegistrationId = regId.Value;
            registrationModel.Status = "A";
            bool a = registrationGateway.UpdateUser(registrationModel);
            if (a)
            {
                Response.Write("<script language=javascript>alert('Admin activate successfully');</script>");
                Load();
            }
            else
            {
                Response.Write("<script language=javascript>alert('Failed to active');</script>");
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
                Response.Write("<script language=javascript>alert('Admin inactivate successfully');</script>");
                Load();
            }
            else
            {
                Response.Write("<script language=javascript>alert('Failed to inactivate');</script>");
            }
        }

        protected void lnkRemove_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            HiddenField regId = (HiddenField)linkButton.Parent.FindControl("HiddenField1");
            registrationModel.RegistrationId = regId.Value;
            bool a = registrationGateway.DeleteUser(registrationModel);
            if (a)
            {
                Response.Write("<script language=javascript>alert('Removed successfully');</script>");
                Load();
            }
            else
            {
                Response.Write("<script language=javascript>alert('Failed to remove');</script>");
            }
        }
    }
}