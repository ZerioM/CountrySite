using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_CountrySite
{
    public class Country
    {
        public int cID { get; internal set; }
        public string countryName { get; set; }
        public List<int> postIDs { get; internal set; }

        public Posts getPosts()
        {
            Posts posts = new Posts(); //initialisiere lehre Liste

            foreach (int postID in postIDs) {
                Post post = Post.getOnePost(postID);
                posts.Add(post);
            }
            return posts;
        }

        public bool save(AdminUser admin)
        {
            if (admin != null) {
                string SQL = "update Countries set name = '@nam' where cid = @id";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQL;
                cmd.Connection = Starter.GetConnection();
                //Die Parameter in SQL-String mit Werten versehen...
                cmd.Parameters.Add(new SqlParameter("nam", countryName));
                cmd.Parameters.Add(new SqlParameter("id", cID));
                // ExecuteNonQuery() gibt die Anzahl der veränderten/angelegten Records zurück.
                return (cmd.ExecuteNonQuery() > 0);
            }

            return false;
        }

        //Statische Methoden, aufgerufen von der Starter-Klasse, damit alle Datenbank-Aufrufe über dieses Objekt in der 
        //derselben Klasse gesammelt sind


        //bei Select * Abfrage gibt er folgende Reihenfolge aus: postID, uid, cid, date, content, tid, cid, name, tid, name, uid, username, pwHash, admin
        private static Country fillCountryFromSQLDataReader(SqlDataReader reader)
        {
            Country oneCountry = new Country();

            oneCountry.cID = reader.GetInt32(0);
            oneCountry.countryName = reader.GetString(1);

            return oneCountry;
        }

        internal static Countries getAllCountries()
        {

            SqlCommand cmd = new SqlCommand("select * from Countries", Starter.GetConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            Countries allCountries = new Countries(); //initialisiere lehre Liste
            while (reader.Read())
            {
                Country oneCountry = fillCountryFromSQLDataReader(reader);
                allCountries.Add(oneCountry);
            }
            return allCountries;
        }
    }
}
