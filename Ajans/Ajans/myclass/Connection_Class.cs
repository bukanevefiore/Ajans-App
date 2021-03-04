using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Ajans.myclass
{
    public class Connection_Class
    {

        public MySqlConnection connectdb;

        public Connection_Class()
        {
            string host = "localhost";
            string database = "testuser";
            string username = "root";
            string password = "";
            string port = "3306";
            string connection_string = "datasource=" + host + "; database=" + database + "; port=" + port + "; username=" + username + "; password=" + password + "; SslMode=none;";

            connectdb = new MySqlConnection(connection_string);
        
        
        }
    
    }
}
