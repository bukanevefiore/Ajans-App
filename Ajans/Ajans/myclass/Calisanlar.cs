using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Ajans.myclass;

namespace Ajans.myclass
{
    public abstract class Calisanlar : Connection_Class
    {

        public int tc { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int mobile { get; set; }
        public int salary { get; set; }
        /*
        public DateTime salary
        { 
            get { return salary; } 
        }
        */
        public int kategori_id { get; set; }

        public string gender { get; set; }
        public string marital_status { get; set; }

        public Calisanlar()
        {

        }

        public abstract void ADD_CALİSAN();

        public abstract void UPDATE_CALİSAN();

        public abstract void DELETE_CALİSAN();

       

      

        


    }
}
