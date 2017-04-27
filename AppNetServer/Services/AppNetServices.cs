using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNetServer.Services
{
    class AppNetServices
    {
        private static string connectionString = "Data Source=152.96.56.70,40001;Initial Catalog=AppNet;Persist Security Info=True;User ID=sa;Password=HSR-00776688";
        SqlConnection conn = new SqlConnection(connectionString);

        public void saveOrder (Auftrag auftrag)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Auftrag (erstelldatum,titel,beschreibung,ort) VALUES ('" + auftrag.erstelldatum + "','" + auftrag.titel + "','" + auftrag.beschreibung + "','" + auftrag.ort + "') ",conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public ArrayList getAllOrders()
        {
            ArrayList allOrders = new ArrayList();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Auftrag;", conn);
            SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Auftrag auftrag = new Auftrag();
                    auftrag.auftragsNummer = reader.GetInt32(0);
                    auftrag.erstelldatum = reader.GetDateTime(1);
                    auftrag.titel = reader.GetString(2);
                    auftrag.beschreibung = reader.GetString(3);
                    auftrag.ort = reader.GetString(4);
                    allOrders.Add(auftrag);
                }
           
            conn.Close();

            return allOrders;
        }
    }
}
