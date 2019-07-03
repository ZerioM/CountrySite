using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_CountrySite
{
    public class loggedInUser : User
    {

        internal loggedInUser() { }

        public loggedInUser changePassword(string oldPassword, string newPassword) {
            string pwHashDB;

            string SQL = "select pwHash from Users where uID = @id";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Starter.GetConnection();
            cmd.Parameters.Add(new SqlParameter("id", uID));
            SqlDataReader reader = cmd.ExecuteReader();

            reader.Read(); //setzt den Reader auf den ersten / nächsten DS
            pwHashDB = reader.GetString(0);

            if (pwHashDB.Equals(md5(oldPassword)))
            {
                string updateSTMT = "update Users set pwHash = '@pH' where uID = @id";
                SqlCommand updateCMD = new SqlCommand();
                updateCMD.CommandText = updateSTMT;
                updateCMD.Connection = Starter.GetConnection();
                updateCMD.Parameters.Add(new SqlParameter("pH", md5(newPassword)));
            }
            else {
                Console.WriteLine("Passwort nicht gefunden");
            }
            return this;
        }

        internal bool insert(string password) {

            string SQL = "insert into Users (username, pwHash) values (@nam, @pw)";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Starter.GetConnection();
            //Die Parameter in SQL-String mit Werten versehen...
            cmd.Parameters.Add(new SqlParameter("nam", userName));
            cmd.Parameters.Add(new SqlParameter("pw", md5(password)));
            // ExecuteNonQuery() gibt die Anzahl der veränderten/angelegten Records zurück.
            return (cmd.ExecuteNonQuery() > 0);
        }
    }
}
