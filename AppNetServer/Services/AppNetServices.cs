using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNetServer.Services
{
    public class AppNetServices
    {
        private static string connectionString = "Data Source=152.96.56.70,40001;Initial Catalog=AppNet;Persist Security Info=True;User ID=sa;Password=HSR-00776688";
        SqlConnection conn = new SqlConnection(connectionString);

        public void addAuftrag (Auftrag auftrag)
        {
            conn.Open();
            try { 
                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Auftrag (erstelldatum,titel,beschreibung,ort, userid) VALUES ('" + auftrag.erstelldatum + "','" + auftrag.titel + "','" + auftrag.beschreibung + "','" + auftrag.ort + "','" + auftrag.userid + "') ",conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                conn.Close();
            }
        }

        public bool updateAuftrag(int auftragsNummer, Auftrag auftrag)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Auftrag where auftragsNummer = " + auftragsNummer.ToString() + ";", conn);
            conn.Open();
            var mssqlReader = cmd.ExecuteReader();
            if(mssqlReader.Read())
            {
                mssqlReader.Close();
                try
                {
                    cmd = new SqlCommand("UPDATE dbo.Auftrag SET erstelldatum = '" + auftrag.erstelldatum + "',titel = '" + auftrag.titel + "',beschreibung = '" + auftrag.beschreibung + "', ort = '" + auftrag.ort + "' WHERE auftragsNummer = " + auftragsNummer + ";", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
            else
            {
                Console.WriteLine("No entry found");
                conn.Close();
                return false;
            }
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

        public ArrayList getAllOrders(string sortBy, bool published)
        {
            ArrayList allOrders = new ArrayList();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Auftrag;", conn);
            getAuftraegeFromDB(cmd, ref allOrders);
            return allOrders;
        }

        public ArrayList getYourOrders(string sortBy, int userId)
        {
            ArrayList yourOrders = new ArrayList();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Auftrag where userid = " + userId + " ORDER BY " + sortBy + " DESC ;", conn);
            getAuftraegeFromDB(cmd, ref yourOrders);
            return yourOrders;
        }

        public ArrayList getYourPublishedOrders(string sortBy, int userId)
        {
            ArrayList yourOrders = new ArrayList();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Auftrag where userid = " + userId + " AND ausgeschrieben = 1 ORDER BY " + sortBy + " DESC ;", conn);
            getAuftraegeFromDB(cmd, ref yourOrders);
            return yourOrders;
        }

        public void getAuftraegeFromDB(SqlCommand cmd, ref ArrayList listToSaveData)
        {
            conn.Open();
            try
            { 
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Auftrag auftrag = new Auftrag();
                    auftrag.auftragsNummer = reader.GetInt32(0);
                    auftrag.erstelldatum = reader.GetDateTime(1);
                    auftrag.titel = reader.GetString(2);
                    auftrag.beschreibung = reader.GetString(3);
                    auftrag.ort = reader.GetString(4);
                    if(reader.GetBoolean(7) == true)
                    { 
                    auftrag.ausschreibungsende = reader.GetDateTime(5);
                    }
                    auftrag.ausgeschrieben = reader.GetBoolean(7);
                    listToSaveData.Add(auftrag);
                }
                conn.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                conn.Close();
            }
        }


    
    }
}
