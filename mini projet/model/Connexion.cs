using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini_projet.model

{
    public class Connexion
    {
        private static SqlConnection cnx = new SqlConnection(Properties.Settings.Default.cnx);

        public static SqlConnection GetConnection()
        {
            try
            {
                cnx.Open();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return cnx;
        }

        public static void CloseConnection()
        {
            try
            {
                if (cnx != null) cnx.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
