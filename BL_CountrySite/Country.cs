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
        public List<int> postIDs = new List<int>();


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

        internal static Countries getAllCountries()
        {

            SqlCommand cmd = new SqlCommand("select c.cid, c.name, p.postID from Countries as c left join Posts as p on c.cid = p.cid", Starter.GetConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            Countries allCountries = new Countries(); //initialisiere lehre Liste

            Country currentObject = new Country();
            currentObject.cID = 0;

            while (reader.Read())
            {
                
                if (currentObject.cID != reader.GetInt32(0)) {
                    Country oneCountry = new Country();
                    currentObject = oneCountry;
                    allCountries.Add(currentObject);
                    currentObject.cID = reader.GetInt32(0);
                    currentObject.countryName = reader.GetString(1); 
                }

                currentObject.postIDs.Add(reader.GetInt32(2));
                
                
            }
            return allCountries;
        }
    }
}
