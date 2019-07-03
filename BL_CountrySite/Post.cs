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


        internal Post(){
            //postID = null;
        }

        public User getUser() {
            //Load user from DB
            User loadedUser = new User();
            SqlCommand cmd = new SqlCommand("select u.uid, u.username, p.postID from Users as u left join Posts as p on u.uid = p.uid where uid = @id", Starter.GetConnection());
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
            SqlCommand cmd = new SqlCommand("select c.cid, c.name, p.postID from Countries as c left join Posts as p on c.cid = p.cid where cid = @id", Starter.GetConnection());
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
            return null;
        }

        public Posts save(loggedInUser currentUser) {
            return null;
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
