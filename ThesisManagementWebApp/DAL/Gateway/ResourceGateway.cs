using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

using ThesisManagementWebApp.DAL.Model;

namespace ThesisManagementWebApp.DAL.Gateway
{
    public class ResourceGateway
    {
        private Function function;
        private SqlConnection con;
        private SqlCommand cmd;
        public ResourceGateway()
        {
            function = Function.GetInstance();
            con = new SqlConnection(function.Connection);
        }
        private static ResourceGateway _instance;

        public static ResourceGateway GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ResourceGateway();
            }
            return _instance;
        }
        internal bool AddResource(ResourceModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("INSERT INTO Resource(ResourceId, ResourceName, Path, InTime, Type) VALUES(@ResourceId, @ResourceName, @Path, @InTime, @Type)", con);
                cmd.Parameters.AddWithValue("@ResourceId", ob.ResourceId);
                cmd.Parameters.AddWithValue("@ResourceName", ob.ResourceName);
                cmd.Parameters.AddWithValue("@Path", ob.Path);
                cmd.Parameters.AddWithValue("@InTime", ob.InTime);
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
        internal bool DeleteResouce(ResourceModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("DELETE FROM Resource WHERE ResourceId=@ResourceId", con);
                cmd.Parameters.AddWithValue("@ResourceId", ob.ResourceId);

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