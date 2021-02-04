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
    public partial class UpdateDepartment : System.Web.UI.Page
    {
        private DepartmentModel departmentModel;
        private DepartmentGateway departmentGateway;
        private Function func;
        public UpdateDepartment()
        {
            func = Function.GetInstance();
            departmentModel = DepartmentModel.GetInstance();
            departmentGateway = DepartmentGateway.GetInstance();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (func.TypeCookie() != "Admin" )
                {
                    Response.Redirect("/Web/Login.aspx");
                }
                if (Request.QueryString["DId"]==null)
                {
                    Response.Redirect("/Web/AddDepartment.aspx");
                }
                Load();
            }
        }

        private void Load()
        {
            txtDepartmentName.Text =
                func.IsExist(
                    $@"SELECT DepartmentName from DepartmentInfo Where DepartmentId='{Request.QueryString["DId"]}'");
        }
        protected void btnUpdate_OnClick(object sender, EventArgs e)
        {
            if (txtDepartmentName.Text == "")
            {
                lblMessage.Text = "Department name is required";
                lblMessage.ForeColor = Color.Red;
            }
           else
            {
                departmentModel.DepartmentName = txtDepartmentName.Text;
                departmentModel.DepartmentId = Convert.ToInt32(Request.QueryString["DId"]);
                bool a = departmentGateway.UpdateDepartment(departmentModel);
                if (a)
                {
                    lblMessage.Text = "Department updated successfully";
                    lblMessage.ForeColor = Color.Green;
                    txtDepartmentName.Text = "";
                    ScriptManager.RegisterStartupScript(this, Page.GetType(), "script", "setTimeout(function(){location.replace('/Web/AddDepartment.aspx')},2500)", true);

                }
                else
                {
                    lblMessage.Text = "Department save failed";
                    lblMessage.ForeColor = Color.Red;
                }
            }
        }
    }
}