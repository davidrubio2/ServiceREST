using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace ServicioREST.Models
{
    public class DataAccessEmisor
    {
        string sConnection = "server=localhost;user id=root;password=;persistsecurityinfo=True;port=3306;database=test_candidate;SslMode=none";

        public String GetEmisor(Emisor emisor)
        {
            String sRespuesta = "1";
            try
            {
                List<Emisor> lstEmisor = new List<Emisor>();
                using (MySqlConnection con = new MySqlConnection(sConnection))
                {
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM test_candidate.emisor where Id = @Id;", con);
                    cmd.Parameters.AddWithValue("@Id", emisor.Id);
                    con.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        sRespuesta = Convert.ToString(rdr["Id"]);
                        lstEmisor.Add(emisor);
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                sRespuesta = ex.ToString();
            }
            return sRespuesta;
        }
        public String AddEmisor(Emisor emisor)
        {
            String sRespuesta = "1";
            using (MySqlConnection con = new MySqlConnection(sConnection))
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(
                    "INSERT INTO test_candidate.emisor(Id,Rfc,FechaInicioOperacion,Capital) VALUES(@Id,@Rfc,@FechaInicioOperacion,@Capital);", con);

                    cmd.Parameters.AddWithValue("@Id", emisor.Id);
                    cmd.Parameters.AddWithValue("@Rfc", emisor.Rfc);
                    cmd.Parameters.AddWithValue("@FechaInicioOperacion", emisor.FechaInicioOperacion);
                    cmd.Parameters.AddWithValue("@Capital", emisor.Capital);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    sRespuesta = ex.ToString();
                }
            }
            return sRespuesta;
        }
    }
}