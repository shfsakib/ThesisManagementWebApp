
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ThesisManagementWebApp.Web
{
    public partial class send_documents : System.Web.UI.Page
    {
        private Function func;
        public send_documents()
        {
            func = Function.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (func.TypeCookie() != "Student")
                {
                    Response.Redirect("/Web/Login.aspx");
                }

                Load();
            }
        }
        private void Load()
        {
            func.LoadGrid(gridDoc, $@"SELECT * FROM Documents WHERE StudentId='{func.UserIdCookie()}' ORDER BY DocId DESC");
        }
        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            if (ddlType.SelectedIndex <= 0)
            {
                func.PopAlert(this, "Type is Required");
            }
            else if (txtMetricId.Text == "")
            {
                func.PopAlert(this, "Metric is Required");
            }
            else if (txtTopicName.Text == "")
            {
                func.PopAlert(this, "Topic name is Required");
            }
            else
            {
                Random random = new Random();
                string attach = "";
                string ran = random.Next(11111, 999999).ToString();
                if (fileAttach.HasFile)
                {
                    string imagePath = Server.MapPath("/photos/") + ran + fileAttach.FileName;
                    fileAttach.PostedFile.SaveAs(imagePath);
                    attach = "/photos/" + ran + fileAttach.FileName;
                }
                else
                {
                    attach = "";
                }

                bool ans = func.Execute($@"INSERT INTO Documents(StudentId,MetricId,TopicName,Attachment,Type,UploadTime) VALUES('{func.UserIdCookie()}','{txtMetricId.Text}','{txtTopicName.Text}','{attach}','{ddlType.SelectedValue}','{func.Date()}')");
                if (ans)
                {
                    func.AlertWithRedirect(this, "Document sent successfully", "/web/send-documents.aspx");
                    Load();
                }
                else
                {
                    func.PopAlert(this, "Failed to sent");
                }
            }
        }

        protected void gridDoc_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridDoc.PageIndex = e.NewPageIndex;
            Load();

        }

        protected void lnkRemove_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            HiddenField hiddenReportId = (HiddenField)linkButton.Parent.FindControl("hiddenReportId");
            bool ans = func.Execute($@"DELETE FROM Documents WHERE DocId='{hiddenReportId.Value}'");
            if (ans)
            {
                func.PopAlert(this, "Removed successfully");
                Load();
            }
            else
            {
                func.PopAlert(this, "Failed to remove");
            }
        }
    }
}