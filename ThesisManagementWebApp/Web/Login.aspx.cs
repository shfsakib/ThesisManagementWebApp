using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BitsMasterClass;
using BitsSoftware;
using ThesisManagementWebApp.DAL.Gateway;
using ThesisManagementWebApp.DAL.Model;

namespace ThesisManagementWebApp.Web
{
    public partial class Login : System.Web.UI.Page
    {
        private Function func;
        HttpCookie cookieIndex = HttpContext.Current.Request.Cookies["Thesis"];
        private RegistrationModel registrationModel;
        private RegistrationGateway registrationGateway;
        public Login()
        {
            func = Function.GetInstance();
            registrationModel = RegistrationModel.GetInstance();
            registrationGateway = RegistrationGateway.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtEmail.Focus();
                if (cookieIndex != null)
                {
                    string a = func.TypeCookie();
                    if (func.TypeCookie() == "Teacher")
                    {
                        Response.Redirect("/Web/ViewStudentReq.aspx");

                    }
                    else if (func.TypeCookie() == "Coordinator")
                    {
                        Response.Redirect("/Web/ViewAllStudentReq.aspx");
                    }
                    else if (func.TypeCookie() == "Student")
                    {
                        Response.Redirect("/Web/FinalReports.aspx");
                    }
                    else if (func.TypeCookie() == "Admin")
                    {
                        Response.Redirect("/Web/AddDepartment.aspx");
                    }
                }
            }
        }

        protected void lnkForgot_OnClick(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                Response.Write("<script language=javascript>alert('Type your email first, then click on forgot password');</script>");
            }
            else
            {
                string pass = func.IsExist($"SELECT Password FROM Registration WHERE Email='{txtEmail.Text}'");
                if (pass == "")
                {
                    Response.Write("<script language=javascript>alert('Email id does not exist');</script>");

                }
                else
                {
                    bool ans = func.SendEmail("thesisdemo21@gmail.com", txtEmail.Text, "Password", "<h3>Hello User,</h3><br/>Your Password is: " + pass, "Thesis2021");
                    if (ans)
                    {
                        Response.Write("<script language=javascript>alert('Password has been sent to your email address.');</script>");
                    }
                }

            }
        }

        protected void btnLogin_OnServerClick(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                Response.Write("<script language=javascript>alert('Email is required');</script>");
            }
            else if (txtPass.Text == "")
            {
                Response.Write("<script language=javascript>alert('Password is required');</script>");
            }
            else
            {
                string pass =
                    func.IsExist(
                        $"SELECT PASSWORD FROM Registration WHERE Email='{txtEmail.Text}' AND Status='A' COLLATE Latin1_General_CS_AI");
                if (pass == txtPass.Text.Trim())
                {
                    HttpCookie cookie = new HttpCookie("Thesis");
                    cookie.Expires = DateTime.Now.AddDays(-1);
                    HttpContext.Current.Response.Cookies.Add(cookie);
                    cookie["Name"] = func.IsExist($"SELECT Name FROM Registration WHERE Email='{txtEmail.Text}'");
                    cookie["Type"] = func.IsExist($"SELECT Type FROM Registration WHERE Email='{txtEmail.Text}'");
                    cookie["UserId"] = func.IsExist($"SELECT RegistrationId FROM Registration WHERE Email='{txtEmail.Text}'");
                    cookie["Email"] = func.IsExist($"SELECT Email FROM Registration WHERE Email='{txtEmail.Text}'");
                    cookie["Picture"] = func.IsExist($"SELECT Picture FROM Registration WHERE Email='{txtEmail.Text}'");
                    cookie["Mobile"] = func.IsExist($"SELECT MobileNo FROM Registration WHERE Email='{txtEmail.Text}'");
                    cookie.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(cookie);
                    if (cookie["Type"] == "Admin")
                    {
                        Response.Redirect("/Web/AddDepartment.aspx");
                    }
                    else if (cookie["Type"] == "Teacher")
                    {
                        Response.Redirect("/Web/ViewStudentReq.aspx");
                    }
                    else if (cookie["Type"] == "Student")
                    {
                        Response.Redirect("/Web/FinalReports.aspx");
                    }
                    else if (cookie["Type"] == "Coordinator")
                    {
                        Response.Redirect("/Web/ViewAllStudentReq.aspx");
                    }
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Incorrect Password');</script>");
                }
            }
        }
    }
}