using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_CountrySite
{
    public class Post
    {
        public int postID { get; internal set; }
        public string content { get; set; }
        public DateTime date { get; internal set; }
        public Country country { get; set; }
        public User user { get; set; }
        public Transport transport { get; set; }



        public Post(){
            postID = -1;
        }

        public User getUser() {
            //Load user from DB
            User loadedUser = new User();
            SqlCommand cmd = new SqlCommand("select u.uid, u.username, p.postID from Users as u left join Posts as p on u.uid = p.uid where u.uid = @id", Starter.GetConnection());
            cmd.Parameters.Add(new SqlParameter("id", user.uID));
            SqlDataReader reader = cmd.ExecuteReader();

            loadedUser.uID = 0;

            while (reader.Read())
            {
                if(loadedUser.uID != reader.GetInt32(0))
                {
                    loadedUser.uID = reader.GetInt32(0);
                    loadedUser.userName = reader.GetString(1);
                }

                try
                {
                    loadedUser.postIDs.Add(reader.GetInt32(2));
                }
                catch (Exception e) {

                }
               
                
            }
            return loadedUser;
        }

        public Country getCountry() {
            //Load country from DB
            Country loadedCountry = new Country();
            SqlCommand cmd = new SqlCommand("select c.cid, c.name, p.postID from Countries as c left join Posts as p on c.cid = p.cid where c.cid = @id", Starter.GetConnection());
            cmd.Parameters.Add(new SqlParameter("id", country.cID));
            SqlDataReader reader = cmd.ExecuteReader();

            loadedCountry.cID = 0;

            while (reader.Read())
            {
                if (loadedCountry.cID != reader.GetInt32(0))
                {
                    loadedCountry.cID = reader.GetInt32(0);
                    loadedCountry.countryName = reader.GetString(1);
                }

                try
                {
                    loadedCountry.postIDs.Add(reader.GetInt32(2));
                }
                catch (Exception e)
                {

                }


            }
            return loadedCountry;
        }

        public Transport getTransport() {
            //Load transport from DB
            Transport loadedTransport = new Transport();
            SqlCommand cmd = new SqlCommand("select t.tid, t.name, p.postID from Transport as t left join Posts as p on t.tid = p.tid where t.tid = @id", Starter.GetConnection());
            cmd.Parameters.Add(new SqlParameter("id", transport.transportID));
            SqlDataReader reader = cmd.ExecuteReader();

            loadedTransport.transportID = 0;

            while (reader.Read())
            {
                if (loadedTransport.transportID != reader.GetInt32(0))
                {
                    loadedTransport.transportID = reader.GetInt32(0);
                    loadedTransport.transportName = reader.GetString(1);
                }

                try
                {
                    loadedTransport.postIDs.Add(reader.GetInt32(2));
                }
                catch (Exception e)
                {

                }


            }
            return loadedTransport;
        }

        public bool save(loggedInUser currentUser) {

            string selectCSQL = "select cid from Countries where name = '@nam'";
            SqlCommand selectCCMD = new SqlCommand();
            selectCCMD.CommandText = selectCSQL;
            selectCCMD.Connection = Starter.GetConnection();
            selectCCMD.Parameters.Add(new SqlParameter("nam", country.countryName));
            SqlDataReader Creader = selectCCMD.ExecuteReader();
            while (Creader.Read())
            {
                country.cID = Creader.GetInt32(0);
            }

            string selectTSQL = "select tid from Transport where name = '@nam'";
            SqlCommand selectTCMD = new SqlCommand();
            selectTCMD.CommandText = selectTSQL;
            selectTCMD.Connection = Starter.GetConnection();
            selectTCMD.Parameters.Add(new SqlParameter("nam", transport.transportName));
            SqlDataReader Treader = selectTCMD.ExecuteReader();
            while (Treader.Read())
            {
                transport.transportID = Treader.GetInt32(0);
            }

            if (postID != -1) {
                //test, if user who created this post, is currently logged in user
                if (currentUser.Equals(user))
                {
                    string SQLSTMT = "update Posts set cid = '@cid', content = '@content', tid = '@tid' where postID = @id";
                    SqlCommand updateCMD = new SqlCommand();
                    updateCMD.CommandText = SQLSTMT;
                    updateCMD.Connection = Starter.GetConnection();
                    //Die Parameter in SQL-String mit Werten versehen...
                    updateCMD.Parameters.Add(new SqlParameter("cid", country.cID));
                    updateCMD.Parameters.Add(new SqlParameter("content", content));
                    updateCMD.Parameters.Add(new SqlParameter("tid", transport.transportID));
                    updateCMD.Parameters.Add(new SqlParameter("id", postID));
                    // ExecuteNonQuery() gibt die Anzahl der veränderten/angelegten Records zurück.
                    return (updateCMD.ExecuteNonQuery() > 0);
                }
            }

            string selectCSQL = "select cid from Countries where name = '@nam'";
            SqlCommand selectCCMD = new SqlCommand();
            selectCCMD.CommandText = selectCSQL;
            selectCCMD.Connection = Starter.GetConnection();
            selectCCMD.Parameters.Add(new SqlParameter("nam", country.countryName));
            SqlDataReader Creader = selectCCMD.ExecuteReader();
            while (Creader.Read())
            {
                country.cID = Creader.GetInt32(0);
            }

            string selectTSQL = "select tid from Transport where name = '@nam'";
            SqlCommand selectTCMD = new SqlCommand();
            selectTCMD.CommandText = selectTSQL;
            selectTCMD.Connection = Starter.GetConnection();
            selectTCMD.Parameters.Add(new SqlParameter("nam", transport.transportName));
            SqlDataReader Treader = selectTCMD.ExecuteReader();
            while (Treader.Read())
            {
                transport.transportID = Treader.GetInt32(0);
            }

            user.uID = currentUser.uID;
            user.userName = currentUser.userName;

            string SQL = "insert into Posts (uid, cid, content, tid) values (@uid, @cid, @content, @tid)";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Starter.GetConnection();
            //Die Parameter in SQL-String mit Werten versehen...
            cmd.Parameters.Add(new SqlParameter("uid", currentUser.uID));
            cmd.Parameters.Add(new SqlParameter("cid", country.cID));
            cmd.Parameters.Add(new SqlParameter("content", content));
            cmd.Parameters.Add(new SqlParameter("tid", transport.transportID));
            // ExecuteNonQuery() gibt die Anzahl der veränderten/angelegten Records zurück.
            return (cmd.ExecuteNonQuery() > 0);
        }


        //Statische Methoden, aufgerufen von anderen Klassen, damit alle Datenbank-Aufrufe über dieses Objekt in der 
        //derselben Klasse gesammelt sind


        //bei Select * Abfrage gibt er folgende Reihenfolge aus: postID, uid, cid, date, content, tid, cid, name, tid, name, uid, username, pwHash, admin
        private static Post fillPostFromSQLDataReader(SqlDataReader reader)
        {
            Post onePost = new Post();
            onePost.user = new User();
            onePost.transport = new Transport();
            onePost.country = new Country();

            
            onePost.postID = reader.GetInt32(0);
            onePost.content = reader.GetString(4);
            onePost.date = reader.GetDateTime(3);
            onePost.country.cID = reader.GetInt32(6);
            onePost.country.countryName = reader.GetString(7);
            onePost.user.uID = reader.GetInt32(10);
            onePost.user.userName = reader.GetString(11);
            onePost.transport.transportID = reader.GetInt32(8);
            onePost.transport.transportName = reader.GetString(9);
            return onePost;
        }

        internal static Posts getAllPosts() {

            SqlCommand cmd = new SqlCommand("select * from Posts as p inner join Countries as c on p.cid = c.cid inner join Transport as t on p.tid = t.tid inner join Users as u on p.uid = u.uid;", Starter.GetConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            Posts allPosts = new Posts(); //initialisiere lehre Liste
            while (reader.Read())
            {
                Post onePost = fillPostFromSQLDataReader(reader);
                allPosts.Add(onePost);
            }
            return allPosts;
        }

        internal static Post getOnePost(int postID) {
            Post onePost = new Post();
            SqlCommand cmd = new SqlCommand("select * from Posts as p inner join Countries as c on p.cid = c.cid inner join Transport as t on p.tid = t.tid inner join Users as u on p.uid = u.uid where postID = @id", Starter.GetConnection());
            cmd.Parameters.Add(new SqlParameter("id", postID));
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                onePost = fillPostFromSQLDataReader(reader);
            }
            return onePost;
        }
        
        

    }
}
