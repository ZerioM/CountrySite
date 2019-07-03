using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_CountrySite
{
    public class Transport
    {
        public int transportID { get; internal set; }
        public string transportName { get; set; }
        public List<int> postIDs { get; internal set; }

        public Posts getPosts() {
            Posts posts = new Posts(); //initialisiere lehre Liste

            foreach (int postID in postIDs)
            {
                Post post = Post.getOnePost(postID);
                posts.Add(post);
            }
            return posts;
        }

        public bool save(AdminUser admin) {
            if (admin != null)
            {
                string SQL = "update Transport set name = '@nam' where tid = @id";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQL;
                cmd.Connection = Starter.GetConnection();
                //Die Parameter in SQL-String mit Werten versehen...
                cmd.Parameters.Add(new SqlParameter("nam", transportName));
                cmd.Parameters.Add(new SqlParameter("id", transportID));
                // ExecuteNonQuery() gibt die Anzahl der veränderten/angelegten Records zurück.
                return (cmd.ExecuteNonQuery() > 0);
            }

            return false;
        }

        //Statische Methoden, aufgerufen von der Starter-Klasse, damit alle Datenbank-Aufrufe über dieses Objekt in der 
        //derselben Klasse gesammelt sind


        //bei Select * Abfrage gibt er folgende Reihenfolge aus: postID, uid, cid, date, content, tid, cid, name, tid, name, uid, username, pwHash, admin
        private static Transport fillTransportFromSQLDataReader(SqlDataReader reader)
        {
            Transport oneTransport = new Transport();

            oneTransport.transportID = reader.GetInt32(0);
            oneTransport.transportName = reader.GetString(1);

            return oneTransport;
        }

        internal static Transports getAllTransports()
        {

            SqlCommand cmd = new SqlCommand("select * from Transport", Starter.GetConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            Transports allTransports = new Transports(); //initialisiere lehre Liste
            while (reader.Read())
            {
                Transport oneTransport = fillTransportFromSQLDataReader(reader);
                allTransports.Add(oneTransport);
            }
            return allTransports;
        }
    }
}
