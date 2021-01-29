using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BitsSoftware;
using ThesisManagementWebApp.DAL.Gateway;
using ThesisManagementWebApp.DAL.Model;

namespace ThesisManagementWebApp.Web
{
    public partial class AddAdmin : System.Web.UI.Page
    {
        private RegistrationModel registrationModel;
        private RegistrationGateway registrationGateway;
        private Function func;
        public AddAdmin()
        {
            func = Function.GetInstance();
            registrationModel = RegistrationModel.GetInstance();
            registrationGateway = RegistrationGateway.GetInstance();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (func.TypeCookie()!="Admin")
                {
                    Response.Redirect("/Web/Login.aspx");
                }
            }
        }
        private bool IsEmail(string email)
        {
            bool a = false;
            string x = func.IsExist($"SELECT Email FROM Registration WHERE Email='{email}'");
            if (x != "")
            {
                a = true;
            }
            return a;
        }
        private bool IsNumber(string number)
        {
            bool a = false;
            string x = func.IsExist($"SELECT MobileNo FROM Registration WHERE MobileNo='{number}'");
            if (x != "")
            {
                a = true;
            }
            return a;
        }
        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            if (txtName.Text=="")
            {
                lblMessage.Text = "Name is required";
                lblMessage.ForeColor = Color.Red;
            }
            else if (txtEmail.Text=="")
            {
                lblMessage.Text = "Email is required";
                lblMessage.ForeColor = Color.Red;
            }else if (txtMobile.Text=="")
            {
                lblMessage.Text = "Mobile is required";
                lblMessage.ForeColor = Color.Red;
            }else if (IsEmail(txtEmail.Text))
            {
                lblMessage.Text = "Email already exist";
                lblMessage.ForeColor = Color.Red;
            }
            else if (IsNumber(txtMobile.Text))
            {
                lblMessage.Text = "Mobile no already exist";
                lblMessage.ForeColor = Color.Red;
            }else if (txtDob.Text == "")
            {
                lblMessage.Text = "Date of birth is required";
                lblMessage.ForeColor = Color.Red;
            }
            else if (ddlGender.Text=="Select")
            {
                lblMessage.Text = "Gender is required";
                lblMessage.ForeColor = Color.Red;
            }
            else if (txtAddress.Text=="")
            {
                lblMessage.Text = "Address is required";
                lblMessage.ForeColor = Color.Red;
            }else if (txtPass.Text=="")
            {
                lblMessage.Text = "Password is required";
                lblMessage.ForeColor = Color.Red;
            }
            else
            {
                ViewState["RegId"] = func.GenerateId("Select Max(RegistrationId) FROM Registration");
                registrationModel.RegistrationId = ViewState["RegId"].ToString();
                registrationModel.Name = txtName.Text;
                registrationModel.Email = txtEmail.Text;
                registrationModel.MobileNo = txtMobile.Text;
                registrationModel.DOB = txtDob.Text;
                registrationModel.Gender = ddlGender.Text;
                registrationModel.Address = txtAddress.Text;
                registrationModel.Password = txtPass.Text;
                registrationModel.Type = "Admin";
                if (filePic.HasFile)
                {
                    string imagePath = Server.MapPath("/photos/") + ViewState["RegId"].ToString() + ".png";
                    filePic.PostedFile.SaveAs(imagePath);
                    registrationModel.Picture = "/photos/" + ViewState["RegId"].ToString() + ".png";
                }
                else
                {
                    registrationModel.Picture = "";
                }
                registrationModel.DepartmentId = 0;
                registrationModel.Designation = "";
                registrationModel.FreeScheduleFrom = "";
                registrationModel.FreeScheduleTo = "";
                registrationModel.IdNo = "";
                registrationModel.Preffer = "";
                registrationModel.Status = "A";
                registrationModel.InTime = func.Date();
                bool a = registrationGateway.Register(registrationModel);
                if (a)
                {
                    lblMessage.Text = "Registered successfully";
                    lblMessage.ForeColor = Color.Green;
                    btnSave.Focus();
                    Refresh();
                }
                else
                {
                    lblMessage.Text = "Registration failed";
                    lblMessage.ForeColor = Color.Red;
                }
            }
        }

        private void Refresh()
        {
            txtName.Text = txtEmail.Text = txtMobile.Text = txtDob.Text = txtAddress.Text = txtPass.Text = "";
            ddlGender.SelectedIndex = -1;
        }
    }
}