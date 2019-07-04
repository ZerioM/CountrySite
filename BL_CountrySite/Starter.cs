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

            return Post.getAllPosts();

        }

        public static Countries getAllCountries() {

            return Country.getAllCountries();

        }

        public static Transports getAllTransports() {

            return Transport.getAllTransports();

        }

        public static object searchByName(string name) {

            Countries countries = Country.getAllCountries();
            Transports transports = Transport.getAllTransports();
            Users users = User.getAllUsers();

            foreach (User u in users) {
                if (u.userName.Equals(name)) return u;
            }
            foreach (Transport t in transports) {
                if (t.transportName.Equals(name)) return t;
            }
            foreach (Country c in countries) {
                if (c.countryName.Equals(name)) return c;
            }

            return null; 

        }

        public static loggedInUser login(string username, string password) {

            object o = searchByName(username);

            if (o != null) {
                Type typeOfo = o.GetType();

                Transport control1 = new Transport();
                Type transportType = control1.GetType();
                Country control2 = new Country();
                Type countryType = control2.GetType();
                User control3 = new User();
                Type userType = control3.GetType();

                if (typeOfo == transportType || typeOfo == countryType)
                {
                    Console.WriteLine("Name ist schon an ein Land oder Transportmittel vergeben.");
                    return null;
                }

                if (typeOfo == userType)
                {
                    User user = (User)o;
                    if (user.checkPassword(password)) {
                        if (user.checkAdmin()) {
                            AdminUser admin = new AdminUser();
                            admin.uID = user.uID;
                            admin.userName = user.userName;
                            admin.postIDs = user.postIDs;
                            return admin;
                        }
                        loggedInUser loggedInUser = new loggedInUser();
                        loggedInUser.uID = user.uID;
                        loggedInUser.userName = user.userName;
                        loggedInUser.postIDs = user.postIDs;
                        return loggedInUser;
                    }
                    else
                    {
                        Console.WriteLine("Username oder Passwort falsch bzw. Username schon vergeben.");
                        return null;
                    }
                }
            }

            loggedInUser newUser = new loggedInUser();
            newUser.userName = username;
            if (newUser.insert(password)) return newUser;

            Console.WriteLine("Das Speichern des Datensatzes hat nicht funktioniert.");
            return null;

        }

    }
}
