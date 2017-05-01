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

        public bool deleteAuftrag(int auftragsNummer)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM dbo.Auftrag where auftragsNummer = " + auftragsNummer.ToString(),conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                conn.Close();
                return false;
            }

        }

        public ArrayList getAllOrders(int sortParameter, bool published)
        {
            ArrayList allOrders = new ArrayList();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Auftrag;", conn);
            getAuftraegeFromDB(cmd, ref allOrders);
            return allOrders;
        }

        public ArrayList getYourOrders(int sortParameter, bool published, int userId)
        {
            ArrayList yourOrders = new ArrayList();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Auftrag where auftragsNummer = " + userId + ";", conn);
            getAuftraegeFromDB(cmd, ref yourOrders);
            return yourOrders;
        }

        public void getAuftraegeFromDB(SqlCommand cmd, ref ArrayList listToSaveData)
        {
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Auftrag auftrag = new Auftrag();
                auftrag.auftragsNummer = reader.GetInt32(0);
                auftrag.erstelldatum = reader.GetDateTime(1);
                auftrag.titel = reader.GetString(2);
                auftrag.beschreibung = reader.GetString(3);
                auftrag.ort = reader.GetString(4);
                listToSaveData.Add(auftrag);
            }
            conn.Close();
        }


    
    }
}
