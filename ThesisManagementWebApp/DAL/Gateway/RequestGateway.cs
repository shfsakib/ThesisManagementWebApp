using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

using ThesisManagementWebApp.DAL.Model;

namespace ThesisManagementWebApp.DAL.Gateway
{
    public class RequestGateway
    {
        private Function function;
        private SqlConnection con;
        private SqlCommand cmd;
        public RequestGateway()
        {
            function = Function.GetInstance();
            con = new SqlConnection(function.Connection);
        }
        private static RequestGateway _instance;

        public static RequestGateway GetInstance()
        {
            if (_instance == null)
            {
                _instance = new RequestGateway();
            }
            return _instance;
        }
        internal bool InsertReq(RequestModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("INSERT INTO ReqSupervisor(ReqId,SupervisorId,StudentId,FileName,Subject,Description,Attachment,Status,ReqTime) VALUES(@ReqId,@SupervisorId,@StudentId,@FileName,@Subject,@Description,@Attachment,@Status,@ReqTime)", con);
                cmd.Parameters.AddWithValue("@ReqId", ob.ReqId);
                cmd.Parameters.AddWithValue("@SupervisorId", ob.SupervisorId);
                cmd.Parameters.AddWithValue("@StudentId", ob.StudentId);
                cmd.Parameters.AddWithValue("@FileName", ob.FileName);
                cmd.Parameters.AddWithValue("@Subject", ob.Subject);
                cmd.Parameters.AddWithValue("@Description", ob.Description);
                cmd.Parameters.AddWithValue("@Attachment", ob.Attachment);
                cmd.Parameters.AddWithValue("@Status", ob.Status);
                cmd.Parameters.AddWithValue("@ReqTime", ob.ReqTime);

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
        internal bool UpdateReqStatus(RequestModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("UPDATE ReqSupervisor SET Status=@Status WHERE SupervisorId=@SupervisorId AND StudentId=@StudentId", con);
                cmd.Parameters.AddWithValue("@Status", ob.Status);
                cmd.Parameters.AddWithValue("@SupervisorId", ob.SupervisorId);
                cmd.Parameters.AddWithValue("@StudentId", ob.StudentId);

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
        internal bool DeleteReq(RequestModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("DELETE FROM ReqSupervisor WHERE SupervisorId=@SupervisorId,StudentId=@StudentId", con);
                cmd.Parameters.AddWithValue("@SupervisorId", ob.SupervisorId);
                cmd.Parameters.AddWithValue("@StudentId", ob.StudentId);

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