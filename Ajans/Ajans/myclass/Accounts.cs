using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Ajans.myclass;

namespace Ajans.myclass
{
    class Accounts : Connection_Class     // kalıtım
    {
        public string username { get; set; }
        public string user_password { get; set; }

        public string user_fullname { get; set; }

        // doğrulama
        public bool Validate_User()
        {

            bool check = false;
            connectdb.Open();
            MySqlDataReader rd;

            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "SELECT * FROM user WHERE username=@user AND password=@pass";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = connectdb;

                // parametreler
                cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = username;
                cmd.Parameters.Add("@pass", MySqlDbType.VarChar).Value = user_password;

                rd = cmd.ExecuteReader();
                while(rd.Read())
                {
                    check = true;
                    user_fullname = rd.GetString("fullname");
                }
                connectdb.Close();
            }

            return check;
        }
    }
}
