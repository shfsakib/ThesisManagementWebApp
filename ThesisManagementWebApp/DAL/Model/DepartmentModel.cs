using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThesisManagementWebApp.DAL.Model
{
    public class DepartmentModel
    {
        private static DepartmentModel _instance;

        public static DepartmentModel GetInstance()
        {
            if (_instance==null)
            {
                _instance=new DepartmentModel();
            }
            return _instance;
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string InTime { get; set; }
    }
}