using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BL_CountrySite
{
    public static class Starter
    {
        //dies ist der Work-Branch Tag 1

        static internal SqlConnection GetConnection()
        {
            List<string> dirs = new List<string>(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory).Split('\\'));
            dirs.RemoveAt(dirs.Count - 1); //letztes Verzeichnis entfernen
            string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + String.Join(@"\", dirs) + @"\DL_CountrySite\countrySite.mdf;Integrated Security=True;Connect Timeout=5";
          
            SqlConnection con = new SqlConnection(conString);
            try
            {
                con.Open();
                return con;
            }
            catch (Exception e) {
                return null;
            }
            //ACHTUNG! Aus Funktion returnen, wenn Connection null ist
            
            
        }


        public static Posts getAllPosts() {
            return null;
        }

        public static Countries getAllCountries() {
            return null;
        }

        public static Transports getAllTransports() {
            return null;
        }

        public static object searchByName(string name) {
            return null; 
        }

        public static loggedInUser login(string username, string password) {
            return null;
        }

    }
}
