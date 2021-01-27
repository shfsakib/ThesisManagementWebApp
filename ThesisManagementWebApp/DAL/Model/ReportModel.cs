using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThesisManagementWebApp.DAL.Model
{
    public class ReportModel
    {
        private static ReportModel _instance;

        public static ReportModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ReportModel();
            }
            return _instance;
        }
        public string ReportId { get; set; }
        public string SupervisorId { get; set; }
        public string StudentId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Attachment { get; set; }
        public string FileName { get; set; }
        public string Status { get; set; }
        public string SendTime { get; set; }
        public string Type { get; set; }
    }
}