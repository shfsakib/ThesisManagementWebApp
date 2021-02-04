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
    public class NoticeGateway
    {
        private Function function;
        private SqlConnection con;
        private SqlCommand cmd;
        public NoticeGateway()
        {
            function = Function.GetInstance();
            con = new SqlConnection(function.Connection);
        }
        private static NoticeGateway _instance;

        public static NoticeGateway GetInstance()
        {
            if (_instance == null)
            {
                _instance = new NoticeGateway();
            }
            return _instance;
        }
        internal bool SaveNotice(NoticeModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("INSERT INTO Notice(NoticeId,Notice,NoticeTIme) VALUES(@NoticeId,@Notice,@NoticeTIme)", con);
                cmd.Parameters.AddWithValue("@NoticeId", ob.NoticeId);
                cmd.Parameters.AddWithValue("@Notice", ob.Notice);
                cmd.Parameters.AddWithValue("@NoticeTIme", ob.NoticeTime);

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
        internal bool DeleteNotice(NoticeModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("DELETE FROM Notice WHERE NoticeId=@NoticeId", con);
                cmd.Parameters.AddWithValue("@NoticeId", ob.NoticeId);

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