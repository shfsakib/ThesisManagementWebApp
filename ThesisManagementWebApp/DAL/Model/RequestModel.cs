using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThesisManagementWebApp.DAL.Model
{
    public class RequestModel
    {
        private static RequestModel _instance;

        public static RequestModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new RequestModel();
            }
            return _instance;
        }

        public string ReqId { get; set; }
        public string SupervisorId { get; set; }
        public string StudentId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Attachment { get; set; }
        public string FileName { get; set; }
        public string Status { get; set; }
        public string ReqTime { get; set; }

    }
}