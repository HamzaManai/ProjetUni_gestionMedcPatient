using mini_projet.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini_projet.Model
{
    class medicamentService
    {
        public static ObservableCollection<medicament> Listermedicaments()
        {
            ObservableCollection<medicament> listemedicament = new ObservableCollection<medicament>();
            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand cmd = new SqlCommand("select * from medicament", cnx);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    string pre = "";
                    if (rd.GetString(2) != null)
                    {
                        pre = rd.GetString(2);
                    }
                    medicament c = new medicament( rd.GetString(0), pre,  rd.GetDouble(2), rd.GetString(3));
                    listemedicament.Add(c);
                }
                rd.Close();
            }
            catch (SqlException ex) { throw ex; }
            finally { Connexion.CloseConnection(); }
            return listemedicament;
        }



        public static void Ajoutermedicament(medicament c)
        {
            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand cmd = new SqlCommand("select count(*) from medicament where CodeMed =" + c.CodeMed, cnx);
                int i = (int)cmd.ExecuteScalar();
                if (i == 0)
                {
                    if (c.Nom == null)
                    {
                        c.Nom = "";
                    }
                    cmd.CommandText = "insert into medicament values (" + c.CodeMed + ",'" + c.Nom + "','" + c.Prix + "','" + c.Lab + "')";
                    i = cmd.ExecuteNonQuery();
                }
                else
                    throw new Exception("Le NSS doit être unique");
            }
            catch (SqlException ex) { throw ex; }
            finally { Connexion.CloseConnection(); }
        }


        public static void Modifiermedicament(medicament c)
        {
            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnx;
                cmd.CommandText = "update medicament set CodeMed=@CodeMed, Nom=@Nom, Prix=@Prix, Lab=@Lab where CodeMed=@CodeMed";
                cmd.Parameters.AddWithValue("@CodeMed", c.CodeMed);
               
                string n = "";
                if (c.Nom!= null)
                {
                    n = c.Nom;
                }
                cmd.Parameters.AddWithValue("@Nom", c.Nom);
                cmd.Parameters.AddWithValue("@Prix", c.Prix);
                cmd.Parameters.AddWithValue("@Lab", c.Lab);
               

                int i = cmd.ExecuteNonQuery();

            }
            catch (SqlException ex) { throw ex; }

            finally { Connexion.CloseConnection(); }
        }



        public static void Supprimermedicament(int C)
        {
            try
            {
                SqlConnection cnx = Connexion.GetConnection();

                SqlCommand cmd = new SqlCommand("delete from medicament where CodeMed=" + C, cnx);
                int i = cmd.ExecuteNonQuery();
            }

            catch (SqlException ex) { throw ex; }

            finally { Connexion.CloseConnection(); }
        }
    }
}
