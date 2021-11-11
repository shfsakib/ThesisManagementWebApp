using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                if (func.TypeCookie()!= "Admin")
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
            if (txtName.Text == "")
            {
                func.PopAlert(this, "Name is required");

            }
            else if (txtEmail.Text == "")
            {
                func.PopAlert(this, "Email is required");

            }
            else if (txtMobile.Text == "")
            {
                func.PopAlert(this, "Mobile no is required");
            }
            else if (ddlGender.Text == "Select")
            {
                func.PopAlert(this, "Gender is required");
            } 
            else if (txtPass.Text == "")
            {
                func.PopAlert(this, "Password is required");

            }
            else if (IsEmail(txtEmail.Text))
            {
                func.PopAlert(this, "Email already exist");

            }
            else if (IsNumber(txtMobile.Text))
            {
                func.PopAlert(this, "Mobile no. already exist");

            } 
            else
            {
                ViewState["RegId"] = func.GenerateId("Select Max(RegistrationId) FROM Registration");
                string pic = "";
                if (filePic.HasFile)
                {
                    string imagePath = Server.MapPath("/photos/") + ViewState["RegId"].ToString() + ".png";
                    filePic.PostedFile.SaveAs(imagePath);
                    pic = "/photos/" + ViewState["RegId"].ToString() + ".png";
                }
                else
                {
                    pic = "/DashboardFile/avatar.svg";
                }
                
                bool a = func.Execute($@"INSERT INTO Registration(RegistrationId,Name,Email,MobileNo,Gender,Batch,Type,Picture,DepartmentId,Designation,FreeScheduleFrom,FreeScheduleTo,IdNo,Preffer,Interest,Password,Status,InTime) VALUES('{ViewState["RegId"]}','{txtName.Text}','{txtEmail.Text}','{txtMobile.Text}','{ddlGender.SelectedValue}','','Admin','{pic}','0','','','','','','','{txtPass.Text}','A','{func.Date()}')");
                if (a)
                {
                    Response.Write("<script language=javascript>alert('Added successfully');</script>");
                    lblMessage.Text = "Added successfully";
                    lblMessage.ForeColor = Color.Green;
                    Refresh(); 
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Failed to add');</script>");
                    lblMessage.Text = "Failed to add";
                    lblMessage.ForeColor = Color.Red;
                }
            }
        }

        private void Refresh()
        {
            txtName.Text = txtEmail.Text = txtMobile.Text =  txtPass.Text = "";
            ddlGender.SelectedIndex = -1;
        }
    }
}