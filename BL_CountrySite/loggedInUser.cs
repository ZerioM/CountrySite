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
        public loggedInUser changePassword(string oldPassword, string newPassword) {
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
