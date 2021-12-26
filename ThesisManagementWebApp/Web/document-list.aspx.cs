using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ThesisManagementWebApp.Web
{
    public partial class document_list : System.Web.UI.Page
    {
        private Function func;
        public document_list()
        {
            func = Function.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                func.CheckCookies();
                Load();
            }
        }
        private void Load()
        {
            func.BindDropDown(ddlBatch, "Batch", $@"SELECT DISTINCT Batch Name,Batch Id FROM Registration WHERE DATALENGTH(Batch)>0 ORDER BY Batch ASC");
            func.LoadGrid(gridDoc, $@"SELECT        Documents.DocId, Documents.StudentId, Documents.MetricId, Documents.TopicName, Documents.Attachment, Documents.Type, Documents.UploadTime
FROM            Documents INNER JOIN
                         Registration ON Documents.StudentId = Registration.RegistrationId WHERE Documents.Type='{ddlType.SelectedValue}' ORDER BY DocId DESC");
        }
        protected void ddlType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Load();
        }

        protected void gridDoc_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridDoc.PageIndex = e.NewPageIndex;
            Load();
        }

        protected void lnkSearch_Click(object sender, EventArgs e)
        {
            if (ddlBatch.SelectedIndex > 0 && ddlSection.SelectedIndex > 0)
            {
                func.LoadGrid(gridDoc, $@"SELECT        Documents.DocId, Documents.StudentId, Documents.MetricId, Documents.TopicName, Documents.Attachment, Documents.Type, Documents.UploadTime
FROM            Documents INNER JOIN
                         Registration ON Documents.StudentId = Registration.RegistrationId WHERE Documents.Type='{ddlType.SelectedValue}' AND Registration.Batch='{ddlBatch.SelectedValue}' AND Registration.Gender='{ddlSection.SelectedValue}' ORDER BY DocId DESC");
            }
            else if (ddlBatch.SelectedIndex > 0 && ddlSection.SelectedIndex <= 0)
            {
                func.LoadGrid(gridDoc, $@"SELECT        Documents.DocId, Documents.StudentId, Documents.MetricId, Documents.TopicName, Documents.Attachment, Documents.Type, Documents.UploadTime
FROM            Documents INNER JOIN
                         Registration ON Documents.StudentId = Registration.RegistrationId WHERE Documents.Type='{ddlType.SelectedValue}' ORDER BY DocId DESC");
                  }
            else if (ddlSection.SelectedIndex > 0 && ddlBatch.SelectedIndex <= 0)
            {
                func.LoadGrid(gridDoc, $@"SELECT        Documents.DocId, Documents.StudentId, Documents.MetricId, Documents.TopicName, Documents.Attachment, Documents.Type, Documents.UploadTime
FROM            Documents INNER JOIN
                         Registration ON Documents.StudentId = Registration.RegistrationId WHERE Documents.Type='{ddlType.SelectedValue}' AND Registration.Gender='{ddlSection.SelectedValue}' ORDER BY DocId DESC");
                
            }
            else
            {
                Load();
            }
        }
    }
}