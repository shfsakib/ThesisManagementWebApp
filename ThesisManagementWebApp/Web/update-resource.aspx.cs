using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ThesisManagementWebApp.Web
{
    public partial class update_resource : System.Web.UI.Page
    {
        private Function func;

        public update_resource()
        {
            func = Function.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
        }
        private void Load()
        {
            txtResourceName.Text = func.IsExist($@"SELECT ResourceName FROM Resource WHERE ResourceId='{Request.QueryString["id"]}'");
            ddlType.SelectedValue = func.IsExist($@"SELECT Type FROM Resource WHERE ResourceId='{Request.QueryString["id"]}'");
            ViewState["file"] = func.IsExist($@"SELECT Path FROM Resource WHERE ResourceId='{Request.QueryString["id"]}'");

        }
        protected void btnUpdate_OnClick(object sender, EventArgs e)
        {
            if (txtResourceName.Text == "")
            {
                lblMessage.Text = "Resouce name is required";
                lblMessage.ForeColor = Color.Red;
            }
            else if (ddlType.SelectedIndex < 0)
            {
                lblMessage.Text = "Type is required";
                lblMessage.ForeColor = Color.Red;
            }
            else
            {
                string file = "";
                Random random = new Random();
                string ran = random.Next(11111, 999999).ToString();
                if (filePic.HasFile)
                {
                    string imagePath = Server.MapPath("/photos/") + ran + filePic.FileName;
                    filePic.PostedFile.SaveAs(imagePath);
                    file = "/photos/" + ran + filePic.FileName;
                }
                else
                {
                    file = ViewState["file"].ToString();
                }
                bool ans = func.Execute($@"UPDATE Resource SET ResourceName='{txtResourceName.Text}',Path='{file}',Type='{ddlType.SelectedValue}' WHERE ResourceId='{Request.QueryString["id"]}'");
                if (ans)
                {
                    func.AlertWithRedirect(this, "Resource Updated Successfully", "/web/resourcelist.aspx");
                }
                else
                {
                    func.PopAlert(this, "Failed to update");
                }
            }
        }
    }
}