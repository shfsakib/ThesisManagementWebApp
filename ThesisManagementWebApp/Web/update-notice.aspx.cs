using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ThesisManagementWebApp.Web
{
    public partial class update_notice : System.Web.UI.Page
    {
        private Function func;

        public update_notice()
        {
            func=Function.GetInstance();
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
            txtNotice.Text = func.IsExist($@"SELECT Notice FROM Notice WHERE NoticeId='{Request.QueryString["id"]}'");
            ViewState["file"] = func.IsExist($@"SELECT Attachment FROM Notice WHERE NoticeId='{Request.QueryString["id"]}'");
        }

        protected void btnUpdate_OnClick(object sender, EventArgs e)
        {
            if (txtNotice.Text == "")
            {
                lblMessage.Text = "Notice is required";
                lblMessage.ForeColor = Color.Red;
            }
            else
            {
                string file = "";
                Random random=new Random();
                string ran = random.Next(11111, 999999).ToString();
                if (fileAttach.HasFile)
                {
                    string imagePath = Server.MapPath("/photos/") + ran + fileAttach.FileName;
                    fileAttach.PostedFile.SaveAs(imagePath);
                    file = "/photos/" + ran + fileAttach.FileName;
                }
                else
                {
                    file = ViewState["file"].ToString();
                }
                bool ans =func.Execute($@"UPDATE Notice SET Notice='{txtNotice.Text}',Attachment='{file}' WHERE NoticeId='{Request.QueryString["id"]}'");
                if (ans)
                {
                    func.AlertWithRedirect(this,"Notice Updated Successfully","/web/noticelist.aspx");
                }
                else
                {
                    func.PopAlert(this,"Failed to update");
                }
            }
        }
    }
}