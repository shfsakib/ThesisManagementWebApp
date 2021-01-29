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
    public partial class CoordinatorApproval : System.Web.UI.Page
    {
        private Function func;
        private RegistrationModel registrationModel;
        private RegistrationGateway registrationGateway;

        public CoordinatorApproval()
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
            func.LoadGrid(gridCoord, @"SELECT * FROM Registration WHERE Type='Coordinator' AND Status='I' ORDER BY RegistrationId ASC");
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

        protected void lnkAccpet_OnClick(object sender, EventArgs e)
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

        protected void gridStudent_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridCoord.PageIndex = e.NewPageIndex;
            Load();
        }
    }
}