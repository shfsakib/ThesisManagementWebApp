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
    public partial class StudentProfile : System.Web.UI.Page
    {
        private Function func;
        private RegistrationModel registrationModel;
        private RegistrationGateway registrationGateway;
        HttpCookie cookieIndex = HttpContext.Current.Request.Cookies["Thesis"];

        public StudentProfile()
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
                func.BindDropDown(ddlDepartment, "Select", $"SELECT DepartmentId Id,DepartmentName Name FROM DepartmentInfo ORDER BY DepartmentName ASC");
                Load();
            }
        }
        private void Load()
        {
            string ownId = func.UserIdCookie();
            lblName.Text = txtName.Text = func.IsExist($"SELECT NAME FROM Registration WHERE RegistrationId='{ownId}'");
            lblEmail.Text = txtEmail.Text = func.IsExist($"SELECT Email FROM Registration WHERE RegistrationId='{ownId}'");
            lblMobile.Text = txtMobile.Text = func.IsExist($"SELECT MobileNo FROM Registration WHERE RegistrationId='{ownId}'");
            lblDob.Text = txtDob.Text = func.IsExist($"SELECT DOB FROM Registration WHERE RegistrationId='{ownId}'");
            lblGender.Text = ddlGender.Text = func.IsExist($"SELECT Gender FROM Registration WHERE RegistrationId='{ownId}'");
            lblAddress.Text = txtAddress.Text = func.IsExist($"SELECT Address FROM Registration WHERE RegistrationId='{ownId}'");
            ddlDepartment.SelectedValue = func.IsExist($"SELECT DepartmentId FROM Registration WHERE RegistrationId='{ownId}'");
            lblId.Text = txtTeacherId.Text = func.IsExist($"SELECT IdNo FROM Registration WHERE RegistrationId='{ownId}'");
             ViewState["img"] = func.IsExist($"SELECT Picture FROM Registration WHERE RegistrationId='{ownId}'");
            imgPic.ImageUrl = imgDiv.Src = func.IsExist($"SELECT Picture FROM Registration WHERE RegistrationId='{ownId}'");
            txtPass.Text = func.IsExist($"SELECT Password FROM Registration WHERE RegistrationId='{ownId}'");
        }
        protected void btnUpdate_OnClick(object sender, EventArgs e)
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
            else if (txtDob.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "script", "alert('Date of birth is required');", true);

            }
            else if (ddlGender.Text == "Select")
            {
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "script", "alert('Gender is required');", true);

            }
            else if (txtAddress.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "script", "alert('Address is required');", true);

            }
            else if (txtPass.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "script", "alert('Password is required');", true);
            }
            else if (ddlDepartment.SelectedIndex == -1)
            {
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "script", "alert('Department is required');", true);

            }
            else
            {
                registrationModel.RegistrationId = func.UserIdCookie();
                registrationModel.Name = txtName.Text;
                registrationModel.Email = txtEmail.Text;
                registrationModel.MobileNo = txtMobile.Text;
                registrationModel.DOB = txtDob.Text;
                registrationModel.Gender = ddlGender.Text;
                registrationModel.Address = txtAddress.Text;
                registrationModel.Password = txtPass.Text;
                registrationModel.Type = "Student";
                if (filePic.HasFile)
                {
                    string imagePath = Server.MapPath("/photos/") + func.UserIdCookie() + ".png";
                    filePic.PostedFile.SaveAs(imagePath);
                    registrationModel.Picture = "/photos/" + func.UserIdCookie() + ".png";
                }
                else
                {
                    registrationModel.Picture = ViewState["img"].ToString();
                }
                registrationModel.DepartmentId = Convert.ToInt32(ddlDepartment.SelectedValue);
                registrationModel.Designation = "";
                registrationModel.FreeScheduleFrom ="";
                registrationModel.FreeScheduleTo = "";
                registrationModel.IdNo = txtTeacherId.Text;
                registrationModel.Preffer = "";
                bool ans = registrationGateway.UpdateProfile(registrationModel);
                if (ans)
                {
                    ScriptManager.RegisterStartupScript(this, Page.GetType(), "script", "alert('Updated successfully');", true);
                    Load();
                    imgPic.ImageUrl = imgDiv.Src = "/photos/" + func.UserIdCookie() + ".png";

                }
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