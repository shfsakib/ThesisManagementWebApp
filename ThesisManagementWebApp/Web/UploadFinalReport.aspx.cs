using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BitsSoftware;
using ThesisManagementWebApp.DAL.Gateway;
using ThesisManagementWebApp.DAL.Model;

namespace ThesisManagementWebApp.Web
{
    public partial class UploadFinalReport : System.Web.UI.Page
    {
        private Function func;
        private ReportModel reportModel;
        private ReportGateway reportGateway;

        public UploadFinalReport()
        {
            func = Function.GetInstance();
            reportModel = ReportModel.GetInstance();
            reportGateway = ReportGateway.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (func.TypeCookie() != "Student" )
                {
                    Response.Redirect("/Web/Login.aspx");
                }
            }
        }

        private void Check()
        {
            string x = func.IsExist($@"SELECT FileName FROM Report WHERE StudentId='{func.UserIdCookie()}' AND Type='"+ddlType.Text+"'");
            if (x != "")
            {
                func.Execute($"DELETE FROM Report WHERE StudentId='{func.UserIdCookie()}' AND Type='" + ddlType.Text + "'");
            }
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            if (txtTitle.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "script", "alert('Title is required');", true);
            }
            else if (ddlType.Text == "Select")
            {
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "script", "alert('Type is required');", true);
            }
            else
            {
                Check();
                ViewState["ReportId"] = func.GenerateId("Select Max(ReportId) FROM Report");
                reportModel.ReportId = ViewState["ReportId"].ToString();
                reportModel.SupervisorId = func.IsExist($@"SELECT SupervisorId FROM  ReqSupervisor WHERE StudentId='{func.UserIdCookie()}'"); ;
                reportModel.StudentId = func.UserIdCookie();
                reportModel.Subject = "";
                reportModel.FileName = txtTitle.Text;
                reportModel.Description = "";
                if (fileReport.HasFile)
                {
                    string imagePath = Server.MapPath("/photos/") + ViewState["ReportId"].ToString() + fileReport.FileName;
                    fileReport.PostedFile.SaveAs(imagePath);
                    reportModel.Attachment = "/photos/" + ViewState["ReportId"].ToString() + fileReport.FileName;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, Page.GetType(), "script", "alert('Choose your report first');", true);
                }
                reportModel.Status = "A";
                reportModel.Type = ddlType.Text;
                reportModel.SendTime = func.Date();
                bool a = reportGateway.SendReport(reportModel);
                if (a)
                {
                    ScriptManager.RegisterStartupScript(this, Page.GetType(), "script", "alert('Report uploaded successfully.');", true);
                    txtTitle.Text = "";
                    ddlType.SelectedIndex = -1;
                }
            }
        }
    }
}