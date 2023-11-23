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
    class patientService
    {
        public static ObservableCollection<patient> Listerpatients()
        {
            ObservableCollection<patient> listepatient = new ObservableCollection<patient>();
            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand cmd = new SqlCommand("select * from patient", cnx);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    string pre = "";
                    if (rd.GetString(2) != null)
                    {
                        pre = rd.GetString(2);
                    }
                    patient c = new patient(rd.GetInt32(0), rd.GetString(1), pre, rd.GetString(3), rd.GetString(4), rd.GetInt32(5), rd.GetDateTime(6));
                    listepatient.Add(c);
                }
                rd.Close();
            }
            catch (SqlException ex) { throw ex; }
            finally { Connexion.CloseConnection(); }
            return listepatient;
        }



        public static void Ajouterpatient(patient c)
        {
            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand cmd = new SqlCommand("select count(*) from patient where Nss =" + c.Nss, cnx);
                int i = (int)cmd.ExecuteScalar();
                if (i == 0)
                {
                    if (c.Prenom == null)
                    {
                        c.Prenom = "";
                    }
                    cmd.CommandText = "insert into patient values (" + c.Nss + ",'" + c.Nom + "','" + c.Prenom + "','" + c.Sexe +"' ,'" +c.Adresse + "','" + c.Tel + "','" + c.DateNaiss + "')";
                    i = cmd.ExecuteNonQuery();
                }
                else
                    throw new Exception("Le NSS doit être unique");
            }
            catch (SqlException ex) { throw ex; }
            finally { Connexion.CloseConnection(); }
        }


        public static void Modifierpatient(patient c)
        {
            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnx;
                cmd.CommandText = "update patient set Nss=@Num, Nom=@Nom, Prenom=@Prenom, Sexe=@sexe,Adresse=@Adresse, Tel=@Tel, DateNaiss=@datenaiss where Nss =@Nss";
                cmd.Parameters.AddWithValue("@Num", c.Nss);
                cmd.Parameters.AddWithValue("@Nom", c.Nom);
                string pre = "";
                if (c.Prenom != null)
                {
                    pre = c.Prenom;
                }
                cmd.Parameters.AddWithValue("@Prenom", pre);
                cmd.Parameters.AddWithValue("@Adresse", c.Adresse);
                cmd.Parameters.AddWithValue("@Tel", c.Tel);
                cmd.Parameters.AddWithValue("@Type", c.DateNaiss);

                int i = cmd.ExecuteNonQuery();

            }
            catch (SqlException ex) { throw ex; }

            finally { Connexion.CloseConnection(); }
        }



        public static void Supprimerpatient(int Nss)
        {
            try
            {
                SqlConnection cnx = Connexion.GetConnection();

                SqlCommand cmd = new SqlCommand("delete from patient where Nss=" + Nss, cnx);
                int i = cmd.ExecuteNonQuery();
            }

            catch (SqlException ex) { throw ex; }

            finally { Connexion.CloseConnection(); }
        }
    }
}
