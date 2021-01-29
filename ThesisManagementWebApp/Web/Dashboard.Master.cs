using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BitsSoftware;

namespace ThesisManagementWebApp.Web
{
    public partial class Dashboard : System.Web.UI.MasterPage
    {
        private Function func;

        public Dashboard()
        {
            func=Function.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (func.TypeCookie()=="")
                {
                    Response.Redirect("/Web/Login.aspx");
                }
            }
        }

        protected void OnServerClick(object sender, EventArgs e)
        {
            func.Logout();
        }
        public string Image(string img)
        {
            if (img == "")
            {
                return "../DashBoardFile/DummyPic.png";
            }
            else
            {
                return img;
            }
        }
        public string TimeC(string time)
        {
            string cTime = "";
            if (time != "")
            {
                DateTime dateTime = new DateTime();
                dateTime = Convert.ToDateTime(time);
                cTime = dateTime.ToString("hh:mm tt");
            }
            return cTime;
        }
    }
}