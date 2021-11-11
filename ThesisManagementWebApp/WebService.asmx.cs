using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using ThesisManagementWebApp;


namespace TicketBookingSystem
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {
        private Function func;
        private SqlConnection con;
        private SqlCommand cmd;

        public WebService()
        {
            func = Function.GetInstance();
            con = new SqlConnection(func.Connection);
        }
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public List<string> GetTeacher(string txt)
        {
            List<string> result = new List<string>();
            try
            {

                string query = @"SELECT Name +' | '+Email txt FROM Registration WHERE Name +' | '+Email +' | '+MobileNo LIKE '%"+ txt + "%' AND Type='Teacher'";
                using (cmd = new SqlCommand(query, con))
                {
                    if (con.State != System.Data.ConnectionState.Open) con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(reader["txt"].ToString().TrimEnd());
                    }
                }
            }
            catch (Exception ex) { }
            return result;
        }
        [WebMethod]
        public List<string> GetStudent(string txt)
        {
            List<string> result = new List<string>();
            try
            {

                string query = @"SELECT Name +' | '+Email txt FROM Registration WHERE Name +' | '+Email +' | '+MobileNo LIKE '%"+ txt + "%' AND Type='Student'";
                using (cmd = new SqlCommand(query, con))
                {
                    if (con.State != System.Data.ConnectionState.Open) con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(reader["txt"].ToString().TrimEnd());
                    }
                }
            }
            catch (Exception ex) { }
            return result;
        }
        [WebMethod]
        public List<string> GetReport(string txt,string type)
        {
            List<string> result = new List<string>();
            try
            {

                string query = @"SELECT FileName txt FROM Report WHERE FileName LIKE '%"+ txt + "%' AND Type='"+type+"'";
                using (cmd = new SqlCommand(query, con))
                {
                    if (con.State != System.Data.ConnectionState.Open) con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(reader["txt"].ToString().TrimEnd());
                    }
                }
            }
            catch (Exception ex) { }
            return result;
        }
    }
}
