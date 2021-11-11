using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ThesisManagementWebApp.DAL.Gateway;
using ThesisManagementWebApp.DAL.Model;

namespace ThesisManagementWebApp.Web
{
    public partial class resources_list : System.Web.UI.Page
    {
        private Function func;
        private ResourceGateway resourceGateway;
        private ResourceModel resourceModel;
        public resources_list()
        {
            func = Function.GetInstance();
            resourceModel = ResourceModel.GetInstance();
            resourceGateway = ResourceGateway.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load();
            }
        }
        private void Load()
        {
            func.LoadRepeater(repeaterResource, $"SELECT * FROM Resource WHERE Type='{ddlType.SelectedValue}' ORDER BY ResourceId DESC");
        }
        protected void ddlType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Load();
        }

        protected void repeaterResource_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Reference the Repeater Item.
                RepeaterItem item = e.Item;
                Image imgFile = (Image)item.FindControl("imgFile");
                HtmlVideo videoResource = (HtmlVideo)item.FindControl("videoResource");
                HiddenField Type = (HiddenField)item.FindControl("Type");
                HtmlAnchor btnDownload = (HtmlAnchor)item.FindControl("btnDownload");
                if (Type.Value == "File")
                {
                    videoResource.Visible = false;
                    btnDownload.InnerText = "Download";
                }
                else if (Type.Value == "Video")
                {
                    imgFile.Visible = false;
                    btnDownload.InnerText = "Play";

                }
            }
        }
    }
}