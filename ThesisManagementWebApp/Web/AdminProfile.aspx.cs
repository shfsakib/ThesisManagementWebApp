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
    public partial class AdminProfile : System.Web.UI.Page
    {
        private Function func;
        private RegistrationModel registrationModel;
        private RegistrationGateway registrationGateway;
        HttpCookie cookieIndex = HttpContext.Current.Request.Cookies["Thesis"];

        public AdminProfile()
        {
            func = Function.GetInstance();
            registrationModel = RegistrationModel.GetInstance();
            registrationGateway = RegistrationGateway.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (func.TypeCookie() != "Admin" )
                {
                    Response.Redirect("/Web/Login.aspx");
                }
                Load();
            }
        }
        private void Load()
        {
            string ownId = func.UserIdCookie();
            lblName.Text = txtName.Text = func.IsExist($"SELECT NAME FROM Registration WHERE RegistrationId='{ownId}'");
            lblEmail.Text = txtEmail.Text = func.IsExist($"SELECT Email FROM Registration WHERE RegistrationId='{ownId}'");
            lblMobile.Text = txtMobile.Text = func.IsExist($"SELECT MobileNo FROM Registration WHERE RegistrationId='{ownId}'");
             lblGender.Text = ddlGender.Text = func.IsExist($"SELECT Gender FROM Registration WHERE RegistrationId='{ownId}'");
             
             ViewState["img"] = func.IsExist($"SELECT Picture FROM Registration WHERE RegistrationId='{ownId}'");
            imgPic.ImageUrl = imgDiv.Src = func.IsExist($"SELECT Picture FROM Registration WHERE RegistrationId='{ownId}'");
            txtPass.Text = func.IsExist($"SELECT Password FROM Registration WHERE RegistrationId='{ownId}'");
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "script", "alert('Name is required');", true);

            }
            else if (txtEmail.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "script", "alert('Email is required');", true);

            }
            else if (txtMobile.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "script", "alert('Mobile no is required');", true);

            }
            
            else if (ddlGender.Text == "Select")
            {
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "script", "alert('Gender is required');", true);

            }
             
            else if (txtPass.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "script", "alert('Password is required');", true);
            }
            else
            {
                string pic = ""; 
                if (filePic.HasFile)
                {
                    string imagePath = Server.MapPath("/photos/") + func.UserIdCookie() + ".png";
                    filePic.PostedFile.SaveAs(imagePath);
                    pic = "/photos/" + func.UserIdCookie() + ".png";
                }
                else
                {
                    pic = ViewState["img"].ToString();
                } 
                bool ans = func.Execute(
                    $@"UPDATE Registration SET Name='{txtName.Text}',Email='{txtEmail.Text}',MobileNo='{txtMobile.Text}',Gender='{ddlGender.SelectedValue}',Picture='{pic}',Password='{txtPass.Text}' WHERE RegistrationId='{func.UserIdCookie()}'");
                if (ans)
                {
                    ScriptManager.RegisterStartupScript(this, Page.GetType(), "script", "alert('Updated successfully');", true);
                    Load();
                    imgPic.ImageUrl = imgDiv.Src = func.IsExist($"SELECT Picture FROM Registration WHERE RegistrationId='{func.UserIdCookie()}'"); ;

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, Page.GetType(), "script", "alert('Failed to update');", true);
                }
            }
        }
    }
}