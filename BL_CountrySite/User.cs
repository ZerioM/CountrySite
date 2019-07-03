using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BL_CountrySite
{
    public class User
    {
        public int uID { get; internal set; }
        public string userName { get; set; }
        public List<int> postIDs { get; internal set; }

        public Posts getPosts()
        {
            Posts posts = new Posts(); //initialisiere lehre Liste

            foreach (int postID in postIDs)
            {
                Post post = Post.getOnePost(postID);
                posts.Add(post);
            }
            return posts;
        }

        
        
        //Statische Methoden, aufgerufen von der Starter-Klasse, damit alle Datenbank-Aufrufe über dieses Objekt in der 
        //derselben Klasse gesammelt sind


        private static User fillUserFromSQLDataReader(SqlDataReader reader)
        {
            User oneUser = new User();

            oneUser.uID = reader.GetInt32(0);
            oneUser.userName = reader.GetString(1);

            return oneUser;
        }

        internal static Users getAllUsers()
        {

            SqlCommand cmd = new SqlCommand("select uid, username, admin from Users", Starter.GetConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            Users allUsers = new Users(); //initialisiere lehre Liste
            while (reader.Read())
            {
                User oneUser = fillUserFromSQLDataReader(reader);
                allUsers.Add(oneUser);
            }
            return allUsers;
        }

        internal bool checkPassword(string pwEntered) {

            string pwHashDB;

            string SQL = "select pwHash from Users where uID = @id";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Starter.GetConnection();
            cmd.Parameters.Add(new SqlParameter("id", uID));
            SqlDataReader reader = cmd.ExecuteReader();

            reader.Read(); //setzt den Reader auf den ersten / nächsten DS
            pwHashDB = reader.GetString(0);


            if (pwHashDB.Equals(md5(pwEntered))) return true;

            
            return false;
        }

        protected string md5(string password) {
                MD5 md5 = new MD5CryptoServiceProvider();

                //compute hash from the bytes of text  
                md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));

                //get hash result after compute it  
                byte[] result = md5.Hash;

                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < result.Length; i++)
                {
                    //change it into 2 hexadecimal digits  
                    //for each byte  
                    strBuilder.Append(result[i].ToString("x2"));
                }

                return strBuilder.ToString();
            }
        }

}


