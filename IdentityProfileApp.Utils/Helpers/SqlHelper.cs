using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProfileApp.Utils.Helpers
{
    public class SqlHelper
    {
        public static int ExceuteNonQuery(string sqlstr, CommandType type, SqlParameter[] parameters, string conString)
        {
            SqlConnection con = new SqlConnection(conString);
            if (conString != null)
                con.ConnectionString = conString;
            SqlCommand cmd = new SqlCommand(sqlstr, con);
            cmd.CommandType = type;
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);

            int numrows = 0;
            try
            {
                con.Open();
                numrows = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                    con.Close();
            }
            return numrows;
        }

        public static object ExecuteScalar(string sqlstr, CommandType type, SqlParameter[] parameters, string conString)
        {
            SqlConnection con = new SqlConnection(conString);
            if (conString != null)
                con.ConnectionString = conString;
            SqlCommand cmd = new SqlCommand(sqlstr, con);
            cmd.CommandType = type;
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);
            object result = null;
            try
            {
                con.Open();
                result = cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                    con.Close();
            }
            return result;
        }
        public static SqlDataReader ExecuteReader(string sqlstr, CommandType type, SqlParameter[] parameters, string conString)
        {
            SqlConnection con = new SqlConnection(conString);
            if (conString != null)
                con.ConnectionString = conString;
            SqlCommand cmd = new SqlCommand(sqlstr, con) { CommandType = type };
            /*SqlConnection.ClearPool(con);*/
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);
            SqlDataReader reader;
            try
            {
                con.Open();
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (SqlException ex)
            {
                if (con.State != ConnectionState.Closed)
                    con.Close();
                throw ex;
            }
            return reader;
        }
    }
}
