using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThesisManagementWebApp.DAL.Model
{
    public class RegistrationModel
    {
        private static RegistrationModel _instance;

        public static RegistrationModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new RegistrationModel();
            }
            return _instance;
        }

        public string RegistrationId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Batch { get; set; }
        public string Type { get; set; }
        public string Picture { get; set; }
        public int DepartmentId { get; set; }
        public string Designation { get; set; }
        public string FreeScheduleFrom { get; set; }
        public string FreeScheduleTo { get; set; }
        public string IdNo { get; set; }
        public string Preffer { get; set; }
        public string Interest { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public string InTime { get; set; }
    }
}