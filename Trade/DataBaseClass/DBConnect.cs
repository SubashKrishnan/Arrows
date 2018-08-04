using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
namespace DataBaseClass
{
    public class DBConfiguration
    {
        private readonly SqlConnection connection = new SqlConnection();
        public object Con()
        {
            try
            {
                connection.Close();
                connection.ConnectionString = (System.Configuration.ConfigurationManager.ConnectionStrings["SQL"].ConnectionString);
                connection.Open();
                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        public bool Execute_Non_Query(string Qry)
        {
            try
            {
                Con();
                SqlCommand command = new SqlCommand(Qry, connection);
                command.CommandTimeout = 1000;
                bool result = false;
                if (command.ExecuteNonQuery() > 0)
                {
                    result = true;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
        public DataSet Execute_Query(string Qry, string table)
        {
            DataSet ds = new DataSet();
            try
            {
                Con();
                SqlCommand command = new SqlCommand(Qry, connection);
                command.CommandTimeout = 1000;
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds, table);
                return ds;
            }
            catch (Exception)
            {
                return ds;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool Execute_NQProcdure(string ProcName, ArrayList ProcParamValues, ArrayList parameter)
        {
            int i;
            int j;
            i = parameter.Count;
            try
            {
                Con();
                SqlCommand COM = new SqlCommand();
                {
                    COM.CommandType = CommandType.StoredProcedure;
                    COM.CommandText = ProcName;
                    COM.Connection = connection;
                }
                for (j = 0; j < i; j++)
                {
                    SqlParameter PARAM = new SqlParameter();
                    {
                        PARAM.Value = ProcParamValues[j];
                        PARAM.ParameterName = parameter[j].ToString();
                        PARAM.Direction = ParameterDirection.Input;
                        COM.Parameters.Add(PARAM);
                    }
                }
                return Convert.ToBoolean(COM.ExecuteNonQuery());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
        public DataSet Execute_Query1(string Qry)
        {
            DataSet ds = new DataSet();
            try
            {
                Con();
                SqlCommand command = new SqlCommand(Qry, connection);
                command.CommandTimeout = 1000;
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                return ds;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool Execute_NQProcdure1(string ProcName)
        {
            try
            {
                Con();
                SqlCommand COM = new SqlCommand();
                {
                    COM.CommandType = CommandType.StoredProcedure;
                    COM.CommandText = ProcName;
                    COM.Connection = connection;
                }
                return Convert.ToBoolean(COM.ExecuteNonQuery());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
        public DataTable Execute_Query_DataTable(string Qry, string table)
        {
            DataTable dt = new DataTable();
            try
            {
                Con();
                SqlCommand command = new SqlCommand(Qry, connection);
                command.CommandTimeout = 1000;
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                return dt;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
