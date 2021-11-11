using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

using ThesisManagementWebApp.DAL.Model;

namespace ThesisManagementWebApp.DAL.Gateway
{
    public class ReportGateway
    {
        private Function function;
        private SqlConnection con;
        private SqlCommand cmd;
        public ReportGateway()
        {
            function = Function.GetInstance();
            con = new SqlConnection(function.Connection);
        }
        private static ReportGateway _instance;

        public static ReportGateway GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ReportGateway();
            }
            return _instance;
        }
        internal bool SendReport(ReportModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("INSERT INTO Report(ReportId,SupervisorId,StudentId,Subject,Description,FileName,Attachment,Status,SendTime,Type) VALUES(@ReportId,@SupervisorId,@StudentId,@Subject,@Description,@FileName,@Attachment,@Status,@SendTime,@Type)", con);
                cmd.Parameters.AddWithValue("@ReportId", ob.ReportId);
                cmd.Parameters.AddWithValue("@SupervisorId", ob.SupervisorId);
                cmd.Parameters.AddWithValue("@StudentId", ob.StudentId);
                cmd.Parameters.AddWithValue("@Subject", ob.Subject);
                cmd.Parameters.AddWithValue("@Description", ob.Description);
                cmd.Parameters.AddWithValue("@FileName", ob.FileName);
                cmd.Parameters.AddWithValue("@Attachment", ob.Attachment);
                cmd.Parameters.AddWithValue("@Status", ob.Status);
                cmd.Parameters.AddWithValue("@SendTime", ob.SendTime);
                cmd.Parameters.AddWithValue("@Type", ob.Type);

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