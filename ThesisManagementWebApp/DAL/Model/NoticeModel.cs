using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThesisManagementWebApp.DAL.Model
{
    public class NoticeModel
    {
        private static NoticeModel _instance;

        public static NoticeModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new NoticeModel();
            }
            return _instance;
        }

        public string NoticeId { get; set; }
        public string Notice { get; set; }
        public string NoticeTime { get; set; }
    }
}