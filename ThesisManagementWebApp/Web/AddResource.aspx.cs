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
    public partial class AddResource : System.Web.UI.Page
    {
        private Function func;
        private ResourceGateway resourceGateway;
        private ResourceModel resourceModel;
        public AddResource()
        {
            func = Function.GetInstance();
            resourceModel = ResourceModel.GetInstance();
            resourceGateway = ResourceGateway.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (func.TypeCookie() != "Admin")
                {
                    Response.Redirect("/Web/Login.aspx");
                }
            }
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            if (txtResourceName.Text == "")
            {
                lblMessage.Text = "Resouce name is required";
                lblMessage.ForeColor = Color.Red;
            }
            else if (ddlType.Text == "")
            {
                lblMessage.Text = "Resource type is required";
                lblMessage.ForeColor = Color.Red;
            }
            else
            {
                ViewState["ResourceId"] = func.GenerateId("Select Max(ResourceId) FROM Resource");
                resourceModel.ResourceId = ViewState["ResourceId"].ToString();
                resourceModel.ResourceName = txtResourceName.Text;
                resourceModel.Type = ddlType.Text;
                if (filePic.HasFile)
                {
                    string imagePath = Server.MapPath("/photos/") + ViewState["ResourceId"].ToString() + filePic.FileName;
                    filePic.PostedFile.SaveAs(imagePath);
                    resourceModel.Path = "/photos/" + ViewState["ResourceId"].ToString() + filePic.FileName;
                }
                else
                {
                    lblMessage.Text = "File is required";
                    lblMessage.ForeColor = Color.Red;
                }
                resourceModel.InTime = func.Date();
                bool a = resourceGateway.AddResource(resourceModel);
                if (a)
                {
                    lblMessage.Text = "Resource added successfully";
                    lblMessage.ForeColor = Color.Green;
                    txtResourceName.Text = "";
                    ddlType.SelectedIndex = -1;

                }
                else
                {
                    lblMessage.Text = "failed to add resource";
                    lblMessage.ForeColor = Color.Red;
                }
            }
        }
    }
}