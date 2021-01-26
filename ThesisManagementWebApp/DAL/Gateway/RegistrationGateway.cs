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
    public class RegistrationGateway
    {
        private Function function;
        private SqlConnection con;
        private SqlCommand cmd;
        public RegistrationGateway()
        {
            function = Function.GetInstance();
            con = new SqlConnection(function.Connection);
        }
        private static RegistrationGateway _instance;

        public static RegistrationGateway GetInstance()
        {
            if (_instance == null)
            {
                _instance = new RegistrationGateway();
            }
            return _instance;
        }
        internal bool Register(RegistrationModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("INSERT INTO Registration(RegistrationId,Name,Email,MobileNo,DOB,Gender,Address,Type,Picture,DepartmentId,Designation,Preffer,FreeScheduleFrom,FreeScheduleTo,IdNo,Status,Password,InTime) VALUES(@RegistrationId,@Name,@Email,@MobileNo,@DOB,@Gender,@Address,@Type,@Picture,@DepartmentId,@Designation,@Preffer,@FreeScheduleFrom,@FreeScheduleTo,@IdNo,@Status,@Password,@InTime)", con);
                cmd.Parameters.AddWithValue("@RegistrationId", ob.RegistrationId);
                cmd.Parameters.AddWithValue("@Name", ob.Name);
                cmd.Parameters.AddWithValue("@Email", ob.Email);
                cmd.Parameters.AddWithValue("@MobileNo", ob.MobileNo);
                cmd.Parameters.AddWithValue("@DOB", ob.DOB);
                cmd.Parameters.AddWithValue("@Gender", ob.Gender);
                cmd.Parameters.AddWithValue("@Address", ob.Address);
                cmd.Parameters.AddWithValue("@Preffer", ob.Preffer);
                cmd.Parameters.AddWithValue("@Password", ob.Password);
                cmd.Parameters.AddWithValue("@Type", ob.Type);
                cmd.Parameters.AddWithValue("@Picture", ob.Picture);
                cmd.Parameters.AddWithValue("@DepartmentId", ob.DepartmentId);
                cmd.Parameters.AddWithValue("@Designation", ob.Designation);
                cmd.Parameters.AddWithValue("@FreeScheduleFrom", ob.FreeScheduleFrom);
                cmd.Parameters.AddWithValue("@FreeScheduleTo", ob.FreeScheduleTo);
                cmd.Parameters.AddWithValue("@IdNo", ob.IdNo);
                cmd.Parameters.AddWithValue("@Status", ob.Status);
                cmd.Parameters.AddWithValue("@InTime", ob.InTime);

                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                result = true;
                if (con.State != ConnectionState.Closed)
                    con.Close();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
            }
            return result;
        }
        internal bool UpdateUser(RegistrationModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("UPDATE Registration SET Status=@Status WHERE RegistrationId=@RegistrationId", con);
                cmd.Parameters.AddWithValue("@Status", ob.Status);
                cmd.Parameters.AddWithValue("@RegistrationId", ob.RegistrationId);

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
        internal bool DeleteUser(RegistrationModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("DELETE FROM Registration WHERE RegistrationId=@RegistrationId", con);
                cmd.Parameters.AddWithValue("@RegistrationId", ob.RegistrationId);

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