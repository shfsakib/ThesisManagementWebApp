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
            else if (ddlType.Text == "Select")
            {
                func.PopAlert(this, "Type is required");

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
                string pic = "";
                string deptId = "0";
                string designation = "";

                ViewState["RegId"] = func.GenerateId("Select Max(RegistrationId) FROM Registration");
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
                if (ddlType.Text == "Teacher")
                {
                    if (ddlDepartment.SelectedIndex == -1)
                    {
                        func.PopAlert(this, "Department is required");

                    }
                    else if (IsId(txtTeacherId.Text))
                    {
                        func.PopAlert(this, "Teacher id already exist");
                    }

                    deptId = ddlDepartment.SelectedValue;
                    designation = txtDesignation.Text;
                    ViewState["id"] = txtTeacherId.Text;
                }
                else if (ddlType.Text == "Student")
                {
                    if (ddlStudentDepartment.SelectedIndex == -1)
                    {
                        func.PopAlert(this, "Department is required");

                    }
                    else if (IsId(txtStdntId.Text))
                    {
                        func.PopAlert(this, "Student Id already exist");

                    }

                    deptId = ddlStudentDepartment.SelectedValue;
                    ViewState["id"] = txtStdntId.Text;
                }
                else if (ddlType.Text == "Coordinator")
                {
                    if (IsId(txtCOId.Text))
                    {
                        func.PopAlert(this, "Coordinator id already exist");

                    }
                    designation = txtCoDesignation.Text;
                    ViewState["id"] = txtCOId.Text;

                }

                bool a = func.Execute($@"INSERT INTO Registration(RegistrationId,Name,Email,MobileNo,Gender,Batch,Type,Picture,DepartmentId,Designation,FreeScheduleFrom,FreeScheduleTo,IdNo,Preffer,Interest,Password,Status,InTime) VALUES('{ViewState["RegId"]}','{txtName.Text}','{txtEmail.Text}','{txtMobile.Text}','{ddlGender.SelectedValue}','{txtBatch.Text}','{ddlType.SelectedValue}','{pic}','{deptId}','{designation}','{txtTimeFrom.Text}','{txtTimeTo.Text}','{ ViewState["id"]}','{ddlPreffer.SelectedValue}','{txtTopic.Text}','{txtPass.Text}','I','{func.Date()}')");
                if (a)
                {

                    Response.Write("<script language=javascript>alert('Registered successfully');</script>");
                    lblMessage.Text = "Registered successfully";
                    lblMessage.ForeColor = Color.Green;
                    Refresh();
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Failed to register');</script>");
                    lblMessage.Text = "Failed to register";
                    lblMessage.ForeColor = Color.Red;
                }
            }
        }

        private void Refresh()
        {
            txtName.Text =
                txtEmail.Text =
                    txtMobile.Text =
                        txtBatch.Text =
                            txtTopic.Text =
                                txtTeacherId.Text =
                                    txtDesignation.Text =
                                        txtTimeFrom.Text =
                                            txtTimeTo.Text = txtStdntId.Text = txtCOId.Text = txtCoDesignation.Text = lblMessage.Text = "";
            ddlType.SelectedIndex =
                ddlDepartment.SelectedIndex = ddlGender.SelectedIndex = ddlPreffer.SelectedIndex = ddlPreffer.SelectedIndex = ddlStudentDepartment.SelectedIndex = -1;
        }
    }
}
