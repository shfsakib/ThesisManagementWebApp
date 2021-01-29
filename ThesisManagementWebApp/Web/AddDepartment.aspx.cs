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
    public partial class AddDepartment : System.Web.UI.Page
    {
        private DepartmentModel departmentModel;
        private DepartmentGateway departmentGateway;
        private Function func;
        public AddDepartment()
        {
            func = Function.GetInstance();
            departmentModel = DepartmentModel.GetInstance();
            departmentGateway = DepartmentGateway.GetInstance();

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
            func.LoadGrid(gridDepartment,@"SELECT * FROM DepartmentInfo ORDER BY DepartmentName ASC");
        }

        private bool IsDapartmentExist(string department)
        {
            bool a = false;
            string x = func.IsExist($"SELECT DepartmentName FROM DepartmentInfo WHERE DepartmentName='{department}'");
            if (x!="")
            {
                a = true;
            }
            return a;
        }
        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            if (txtDepartmentName.Text == "")
            {
                lblMessage.Text = "Department name is required";
                lblMessage.ForeColor = Color.Red;
            }
            else if (IsDapartmentExist(txtDepartmentName.Text))
            {
                lblMessage.Text = "Department name already exist";
                lblMessage.ForeColor = Color.Red;
            }
            else
            {
                departmentModel.DepartmentName = txtDepartmentName.Text;
                departmentModel.InTime = func.Date();
                bool a = departmentGateway.SaveDepartment(departmentModel);
                if (a)
                {
                    lblMessage.Text = "Department saved successfully";
                    lblMessage.ForeColor = Color.Green;
                    txtDepartmentName.Text = "";
                    Load();
                }
                else
                {
                    lblMessage.Text = "Department save failed";
                    lblMessage.ForeColor = Color.Red;
                }
            }
        }

        protected void gridDepartment_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridDepartment.PageIndex = e.NewPageIndex;
            Load();
        }

        protected void lnkUpdate_OnClick(object sender, EventArgs e)
        {
            
        }
    }
}