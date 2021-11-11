﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Image = System.Drawing.Image;

namespace ThesisManagementWebApp
{
    public class Function
    {
        IFormatProvider dateformat = new System.Globalization.CultureInfo("fr-FR", true);
        private static Function _instance;
        private SqlConnection con;
        public static Function GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Function();
            }
            return _instance;
        }

        public Function()
        {
            if (con == null)
            {
                con = new SqlConnection(Connection);
            }
        }

        public string Connection1 = new SqlConnectionStringBuilder
        {
            DataSource = ".\\local",
            InitialCatalog = "DataFillingDb",
            UserID = "sa",
            Password = "123456789",
            MultipleActiveResultSets = true,
            ConnectTimeout = 0,
            Pooling = true,
            MinPoolSize = 0,
            MaxPoolSize = 4096
        }.ToString();
        public string Connection2 = new SqlConnectionStringBuilder
        {
            DataSource = ".\\local",
            InitialCatalog = "DataFillingDb",
            UserID = "sa",
            Password = "ShfS@kib16",
            MultipleActiveResultSets = true,
            ConnectTimeout = 0,
            Pooling = true,
            MinPoolSize = 0,
            MaxPoolSize = 4096
        }.ToString();
        public string Connection = new SqlConnectionStringBuilder
        {
            DataSource = ".\\local",
            InitialCatalog = "ThesisDb",
            MultipleActiveResultSets = true,
            IntegratedSecurity = true,
            ConnectTimeout = 0,
            Pooling = true,
            MinPoolSize = 0,
            MaxPoolSize = 4096
        }.ToString();

        //public string Connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={ Path.GetFullPath("DataFilling.mdf") + @";Integrated Security=True;Connect Timeout = 30";

        //public string Connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={ Path.GetDirectoryName(Application.ExecutablePath) + @"\DataFilling.mdf;Integrated Security=True";
        //public string Connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Program Files (x86)\DataFillingSoft\DataFilling.mdf;Integrated Security=True";

        public void BindDropDown(DropDownList ddl, string root, string query)
        {
            con = new SqlConnection(Connection);
            DataSet dataSet = new DataSet();
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataSet);
                ddl.DataSource = dataSet;
                ddl.DataTextField = "Name";
                ddl.DataValueField = "ID";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("--" + root.ToUpper() + "--"));
                if (con.State != ConnectionState.Closed)
                    con.Close();
            }
            catch (Exception ex)
            {
                if (con.State != ConnectionState.Closed)
                    con.Close();
            }
        }
        public void BindCheckBoxList(CheckBoxList ob, string root, string query)
        {
            con = new SqlConnection(Connection);
            DataSet dataSet = new DataSet();
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataSet);
                ob.DataSource = dataSet;
                ob.DataTextField = "Name";
                ob.DataValueField = "ID";
                ob.DataBind();
                ob.Items.Insert(0, new ListItem(root.ToUpper()));
                if (con.State != ConnectionState.Closed)
                    con.Close();
            }
            catch (Exception ex)
            {
                if (con.State != ConnectionState.Closed)
                    con.Close();
            }
        }
        public bool Execute(string str)
        {
            bool result = false;
            SqlConnection Conn = new SqlConnection(Connection);
            try
            {

                if (Conn.State != ConnectionState.Open) Conn.Open();
                SqlCommand cmd = new SqlCommand(str, Conn);
                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                    result = true;
                else
                    result = false;
                if (Conn.State != ConnectionState.Closed) Conn.Close();
            }
            catch (Exception ex) { if (Conn.State != ConnectionState.Closed) Conn.Close(); }
            return result;
        }
        public string IsExist(string str)
        {
            string result = "";
            try
            {
                if (con.State != ConnectionState.Open) con.Open();
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataReader DR = cmd.ExecuteReader();
                while (DR.Read())
                    result = DR[0].ToString();
                DR.Close();
                if (con.State != ConnectionState.Closed) con.Close();
            }
            catch (Exception ex)
            {
                if (con.State != ConnectionState.Closed) con.Close();
            }
            return result;
        }
        public bool ValidDate(TextBox date)
        {
            try
            {
                if (date.Text == "" || date.Text.Length != 10)
                    return true;
                else
                    DateTime.Parse(date.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            }
            catch (Exception EX)
            { return true; }

            return false;
        }
        public bool ValidDateI(HtmlInputText date)
        {
            try
            {
                if (date.Value == "" || date.Value.Length != 10)
                    return true;
                else
                    DateTime.Parse(date.Value, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            }
            catch (Exception EX)
            { return true; }

            return false;
        }
        public string Date()
        {
            string date = DateTime.Now.ToString("dd/MM/yyyy_hh:mm:ss");
            return date;
        }
        public DateTime Timezone(DateTime datetime)
        {
            var timezoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");
            DateTime printDate = TimeZoneInfo.ConvertTime(datetime, timezoneInfo);
            return printDate;
        }
        public void FocusTools(Page page, string toolName)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), "script", "$('#ContentPlaceHolder1_" + toolName + "').focus()", true);
        }
        public void FocusTool(Page page, string toolName)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), "script", "$('#'" + toolName + "'').focus()", true);
        }
        public void Alert(Page page, string msg, string type, bool confirm)
        {
            int timer = 0;
            if (type == "s")
            {
                type = "success";
            }
            else if (type == "e")
            {
                type = "error";
            }
            else if (type == "w")
            {
                type = "warning";
            }
            if (confirm)
            {
                timer = 6000;
            }
            else
            {
                timer = 1500;
            }
            string alert = @"Swal.fire({  position: 'center',  icon: '" + type + "',title: '" + msg + "',showConfirmButton:'" + confirm + "',timer:'" + timer + "'})";
            ScriptManager.RegisterStartupScript(page, page.GetType(), "Popup", alert, true);
        }

        public void PopAlert(Page page, string msg)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), "script", "alert('"+ msg + "')", true);

        }
        public void ResponseAlert(Page page, string msg)
        {
            HttpContext.Current.Response.Write(" < script language=javascript>alert('"+ msg + "');</script>");

        }
        public void AlertWithRedirect(Page page, string msg, string link)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), "script", "alert(`"+ msg + "`); setTimeout(function(){ location.replace('"+link + "')},800); ", true);
        }
        public bool EmailValidation(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public void LoadGrid(GridView ob, string query)
        {
            DataTable table = new DataTable();
            SqlConnection con = new SqlConnection(Connection);
            try
            {
                ob.Visible = true;
                if (con.State != ConnectionState.Open) con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);
                ob.DataSource = table;
                ob.DataBind();
                if (con.State != ConnectionState.Closed) con.Close();
            }
            catch (Exception ex)
            {
                if (con.State != ConnectionState.Closed) con.Close();
            }
        }
        public void LoadRepeater(Repeater ob, string query)
        {
            DataTable table = new DataTable();
            SqlConnection con = new SqlConnection(Connection);
            try
            {
                ob.Visible = true;
                if (con.State != ConnectionState.Open) con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);
                ob.DataSource = table;
                ob.DataBind();
                if (con.State != ConnectionState.Closed) con.Close();
            }
            catch (Exception ex)
            {
                if (con.State != ConnectionState.Closed) con.Close();
            }
        }
        public void LoadDataList(DataList ob, string query)
        {
            DataTable table = new DataTable();
            SqlConnection con = new SqlConnection(Connection);
            try
            {
                ob.Visible = true;
                if (con.State != ConnectionState.Open) con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);
                ob.DataSource = table;
                ob.DataBind();
                if (con.State != ConnectionState.Closed) con.Close();
            }
            catch (Exception ex)
            {
                if (con.State != ConnectionState.Closed) con.Close();
            }
        }

        public bool MobileNoValidation(string mobileNo)
        {
            try
            {
                if (mobileNo == "" || mobileNo.Length < 11 || !mobileNo.StartsWith("0"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }
        public bool SendEmail(string fromMail, string toMail, string subject, string body, string fromPass)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(fromMail);
                message.To.Add(new MailAddress(toMail));
                message.Subject = subject;
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = body;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(fromMail, fromPass);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                return true;
            }
        }
        public string CheckPassword(string pass)
        {
            if (pass.Length < 6 || pass.Length > 15)
            {
                return "Password must be between 6-15 character";
            }
            else if (pass.Contains(" "))
            {
                return "Remove space from your password";
            }
            else if (!pass.Any(char.IsUpper))
            {
                return "Password must have at least one capital latter";
            }
            else if (!pass.Any(char.IsLower))
            {
                return "Password must have at least one small latter";
            }
            else if (!pass.Any(char.IsDigit))
            {
                return "Password must be a combination of alphanumeric characters";
            }
            else
            {
                return "Strong password";
            }
        }
        public string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public void CheckCookies()
        {
            HttpCookie cookies = GetCookie();
            if (cookies == null)
            {
                HttpContext.Current.Response.Redirect("/web/Login.aspx", true);
            }
        }

        public void CheckStatus(string tableName, string userId)
        {
            string x = IsExist($@"SELECT Status FROM { tableName + " WHERE "+userId + $"='"+UserIdCookie()}'");
            if (x != "A")
            {
                Logout();
            }
        }

        public void Logout()
        {
            HttpCookie cookies = GetCookie();
            cookies.Expires = DateTime.Now.AddDays(-1);
            HttpContext.Current.Response.Cookies.Add(cookies);
            HttpContext.Current.Response.Redirect("/web/Resources.aspx");
        }
        public string UserIdCookie()
        {
            HttpCookie cookies = GetCookie();
            return cookies["UserId"];
        }
        public string NameCookie()
        {
            HttpCookie cookies = GetCookie();
            return cookies["Name"];
        }
        public string MobileCookie()
        {
            HttpCookie cookies = GetCookie();
            return cookies["Mobile"];
        }
        public string EmailCookie()
        {
            HttpCookie cookies = GetCookie();
            return cookies["Email"];
        }
        public string PictureCookie()
        {
            HttpCookie cookies = GetCookie();
            return cookies["Picture"];
        }
        public string TypeCookie()
        {
            HttpCookie cookies = GetCookie();
            return cookies["Type"];
        }

        public void CheckTypeCookie(Page page, string type)
        {
            HttpCookie cookies = GetCookie();
            if (cookies["Type"] != type)
            {
                HttpContext.Current.Response.Redirect("/web/Login.aspx");
            }

        }

        public static HttpCookie CreateCookie()
        {
            HttpCookie cookie = new HttpCookie("Thesis");
            if (cookie == null || cookie?.Value == "")
            {
                cookie = null;
            }
            return cookie;
        }
        public static HttpCookie GetCookie()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["Thesis"];
            if (cookie == null || cookie?.Value == "")
            {
                cookie = null;
            }
            return cookie;
        }
        public void AdminType(Page page, string type1, string type2)
        {
            HttpCookie cookie = new HttpCookie("Thesis");
            HttpCookie cookies = GetCookie();
            if (cookies["Type"] == type1)
            {
            }
            else if (cookies["Type"] == type2)
            {
            }
            else
            {
                HttpContext.Current.Response.Redirect("/web/Login.aspx");
            }
        }

        public string GenerateId(string query)
        {
            string id = "";
            try
            {
                if (con.State != ConnectionState.Open) con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    id = reader[0].ToString();
                    if (id == "")
                        id = "1001";
                    else
                    {
                        id = (int.Parse(id) + 1).ToString();
                    }

                }
                reader.Close();
                if (con.State != ConnectionState.Closed) con.Close();
            }
            catch
            {
            }
            return id;
        }
        public string GenerateInvoice(string query)
        {
            string id = "";
            try
            {
                string date = DateTime.Now.ToString("yyyyMMdd");

                if (con.State != ConnectionState.Open) con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    id = reader[0].ToString();
                    if (id == "")
                        id = "1001";
                    else
                    {
                        id = (int.Parse(id) + 1).ToString();
                    }
                }
                id = date + id;
                reader.Close();
                if (con.State != ConnectionState.Closed) con.Close();
            }
            catch
            {
            }
            return id;
        }
    }
}