using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BitsSoftware;
using ThesisManagementWebApp.DAL.Gateway;
using ThesisManagementWebApp.DAL.Model;

namespace ThesisManagementWebApp.Web
{
    public partial class Resources : System.Web.UI.Page
    {
        private Function func;
        private ResourceGateway resourceGateway;
        private ResourceModel resourceModel;
        public Resources()
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
            LoadRepeater(repeaterResource, "SELECT * FROM Resource ORDER BY ResourceId DESC");
        }

        public void LoadRepeater(Repeater ob, string query)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(func.Connection);
            try
            {
                ob.Visible = true;
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                new SqlDataAdapter(new SqlCommand(query, connection)).Fill(dataTable);
                ob.DataSource = (object)dataTable;
                ob.DataBind();
                if ((uint)connection.State <= 0U)
                    return;
                connection.Close();
            }
            catch (Exception ex)
            {
                if ((uint)connection.State <= 0U)
                    return;
                connection.Close();
            }
        }

        protected void repeaterResource_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Reference the Repeater Item.
                RepeaterItem item = e.Item;
                Image imgFile = (Image) item.FindControl("imgFile");
                HtmlVideo videoResource = (HtmlVideo) item.FindControl("videoResource");
                HiddenField Type = (HiddenField) item.FindControl("Type");
                HtmlAnchor btnDownload = (HtmlAnchor) item.FindControl("btnDownload");
                if (Type.Value=="File")
                {
                    videoResource.Visible = false;
                    btnDownload.InnerText = "Download";
                }
                else if (Type.Value=="Video")
                {
                    imgFile.Visible = false;
                    btnDownload.InnerText = "Play";

                }
            }
        }
    }
}