using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataLayer
{
    public static class RN_DataTools
    {
        public static void ExecuteCommand(String storedProcedureName, SqlParameter[] args)
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            try
            {
                connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
                command = new SqlCommand(storedProcedureName);                
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;
                if (args != null)
                {
                    foreach (SqlParameter param in args)
                    {
                        command.Parameters.Add(param);
                    }
                }
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                    connection = null;
                }
            }
        }
        public static SqlDataReader GetReader(String storedProcedureName, SqlParameter[] args)
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            SqlDataReader reader = null;
            try
            {
                connection = new SqlConnection(ConfigurationManager.AppSettings["connectionString"]);
                command = new SqlCommand(storedProcedureName);
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;
                if (args != null)
                {
                    foreach (SqlParameter param in args)
                    {
                        command.Parameters.Add(param);
                    }
                }
                connection.Open();
                reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.StackTrace);
            }            
            return reader;
        }
    }
}
