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
    public partial class SignupOption : System.Web.UI.Page
    {
        private Function func;
        private RegistrationModel registrationModel;
        private RegistrationGateway registrationGateway;
        public SignupOption()
        {
            func = Function.GetInstance();
            registrationModel = RegistrationModel.GetInstance();
            registrationGateway = RegistrationGateway.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtName.Focus();
                LoadDropdown();
            }
        }

        private void LoadDropdown()
        {
            func.BindDropDown(ddlDepartment, "Select", $"SELECT DepartmentId Id,DepartmentName Name FROM DepartmentInfo ORDER BY DepartmentName ASC");
            func.BindDropDown(ddlStudentDepartment, "Select", $"SELECT DepartmentId Id,DepartmentName Name FROM DepartmentInfo ORDER BY DepartmentName ASC");

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
        private bool IsId(string id)
        {
            bool a = false;
            string x = func.IsExist($"SELECT IdNo FROM Registration WHERE IdNo='{id}'");
            if (x != "")
            {
                a = true;
            }
            return a;
        }
        protected void ddlType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlType.Text == "Teacher")
            {
                teacherPanel.Visible = true;
                studentPanel.Visible = false;
                coordinatePanel.Visible = false;
                ddlDepartment.Focus();
            }
            else if (ddlType.Text == "Student")
            {
                teacherPanel.Visible = false;
                studentPanel.Visible = true;
                coordinatePanel.Visible = false;
                ddlStudentDepartment.Focus();

            }
            else if (ddlType.Text == "Coordinator")
            {
                teacherPanel.Visible = false;
                studentPanel.Visible = false;
                coordinatePanel.Visible = true;
                txtCOId.Focus();
            }
            else
            {
                teacherPanel.Visible = false;
                studentPanel.Visible = false;
                coordinatePanel.Visible = false;
            }
        }

        protected void OnServerClick(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                lblMessage.Text = "Name is required";
                lblMessage.ForeColor = Color.Red;
            }
            else if (txtEmail.Text == "")
            {
                lblMessage.Text = "Email is required";
                lblMessage.ForeColor = Color.Red;
            }
            else if (txtMobile.Text == "")
            {
                lblMessage.Text = "Mobile no is required";
                lblMessage.ForeColor = Color.Red;
            }
            else if (txtDob.Text == "")
            {
                lblMessage.Text = "Date of birth is required";
                lblMessage.ForeColor = Color.Red;
            }
            else if (ddlGender.Text == "Select")
            {
                lblMessage.Text = "Gender is required";
                lblMessage.ForeColor = Color.Red;
            }
            else if (txtAddress.Text == "Select")
            {
                lblMessage.Text = "Address is required";
                lblMessage.ForeColor = Color.Red;
            }
            else if (ddlType.Text == "Select")
            {
                lblMessage.Text = "Type is required";
                lblMessage.ForeColor = Color.Red;
            }
            else if (txtPass.Text == "")
            {
                lblMessage.Text = "Password is required";
                lblMessage.ForeColor = Color.Red;
            }
            else if (IsEmail(txtEmail.Text))
            {
                lblMessage.Text = "Email already exist";
                lblMessage.ForeColor = Color.Red;
            }
            else if (IsNumber(txtMobile.Text))
            {
                lblMessage.Text = "Mobile no already exist";
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
                registrationModel.Type = ddlType.Text;
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
                if (ddlType.Text == "Teacher")
                {
                    if (ddlDepartment.SelectedIndex == -1)
                    {
                        lblMessage.Text = "Department is required";
                        lblMessage.ForeColor = Color.Red;
                    }
                    else if (IsId(txtTeacherId.Text))
                    {
                        lblMessage.Text = "Teacher id already exist";
                        lblMessage.ForeColor = Color.Red;
                    }
                    else
                    {

                        registrationModel.DepartmentId = Convert.ToInt32(ddlDepartment.SelectedValue);
                        registrationModel.Designation = txtDesignation.Text;
                        registrationModel.FreeScheduleFrom = txtTimeFrom.Text;
                        registrationModel.FreeScheduleTo = txtTimeTo.Text;
                        registrationModel.IdNo = txtTeacherId.Text;
                        registrationModel.Preffer = ddlPreffer.Text;
                    }
                }
                else if (ddlType.Text == "Student")
                {
                    if (ddlStudentDepartment.SelectedIndex == -1)
                    {
                        lblMessage.Text = "Department is required";
                        lblMessage.ForeColor = Color.Red;
                    }
                    else if (IsId(txtStdntId.Text))
                    {
                        lblMessage.Text = "Student id already exist";
                        lblMessage.ForeColor = Color.Red;
                    }
                    else
                    {
                        registrationModel.DepartmentId = Convert.ToInt32(ddlStudentDepartment.SelectedValue);
                        registrationModel.Designation = "";
                        registrationModel.FreeScheduleFrom = "";
                        registrationModel.FreeScheduleTo = "";
                        registrationModel.IdNo = txtStdntId.Text;
                        registrationModel.Preffer = "";
                    }
                }
                else if (ddlType.Text == "Coordinator")
                {
                    if (IsId(txtCOId.Text))
                    {
                        lblMessage.Text = "Coordinator id already exist";
                        lblMessage.ForeColor = Color.Red;
                    }
                    else
                    {
                        registrationModel.DepartmentId = 0;
                        registrationModel.Designation = txtCoDesignation.Text;
                        registrationModel.FreeScheduleFrom = "";
                        registrationModel.FreeScheduleTo = "";
                        registrationModel.IdNo = txtCOId.Text;
                        registrationModel.Preffer = "";
                    }

                }
                registrationModel.Status = "I";
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
            txtName.Text =
                txtEmail.Text =
                    txtMobile.Text =
                        txtDob.Text =
                            txtAddress.Text =
                                txtTeacherId.Text =
                                    txtDesignation.Text =
                                        txtTimeFrom.Text =
                                            txtTimeTo.Text = txtStdntId.Text = txtCOId.Text = txtCoDesignation.Text = "";
            ddlType.SelectedIndex =
                ddlDepartment.SelectedIndex = ddlGender.SelectedIndex = ddlPreffer.SelectedIndex = ddlStudentDepartment.SelectedIndex = -1;
        }
    }
}