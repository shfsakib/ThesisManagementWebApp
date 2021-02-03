using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BitsSoftware;
using ThesisManagementWebApp.DAL.Model;

namespace ThesisManagementWebApp.DAL.Gateway
{
    public class DepartmentGateway
    {
        private Function function;
        private SqlConnection con;
        private SqlCommand cmd;
        public DepartmentGateway()
        {
            function = Function.GetInstance();
            con = new SqlConnection(function.Connection);
        }
        private static DepartmentGateway _instance;

        public static DepartmentGateway GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DepartmentGateway();
            }
            return _instance;
        }
        internal bool SaveDepartment(DepartmentModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("INSERT INTO DepartmentInfo(DepartmentName,InTime) VALUES(@DepartmentName,@InTime)", con);
                cmd.Parameters.AddWithValue("@DepartmentName", ob.DepartmentName);
                cmd.Parameters.AddWithValue("@InTime", ob.InTime);

                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                result = true;
                if (con.State != ConnectionState.Closed)
                    con.Close();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
            return result;
        }
        internal bool UpdateDepartment(DepartmentModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("UPDATE DepartmentInfo SET DepartmentName=@DepartmentName WHERE DepartmentId=@DepartmentId", con);
                cmd.Parameters.AddWithValue("@DepartmentName", ob.DepartmentName);
                cmd.Parameters.AddWithValue("@DepartmentId", ob.DepartmentId);

                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                result = true;
                if (con.State != ConnectionState.Closed)
                    con.Close();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
            return result;
        }
    }
}