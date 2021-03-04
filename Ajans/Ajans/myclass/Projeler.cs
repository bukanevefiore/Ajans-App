using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Ajans.myclass;

namespace Ajans.myclass
{
    public class Projeler : Connection_Class
    {
        // propertys
        public string projeAd { get; set; }

        public int tc { get; set; }

        public string is_baslangic_tarihi { get; set; }

        public string is_bitis_tarihi { get; set; }

        // constructor
        public Projeler()
        {

        }


        // list tanimlaması
        public List<string> datafill = new List<string>();

        public string search_text;

        private string query = "SELECT * FROM projeler";

        // veri tabanından değer almak çin 
        public string _fullproje;
        public string _fulltc;

        public DataTable DT = new DataTable();
        public DataSet DS = new DataSet();

        public void Show_Table()
        {
            datafill.Clear();
            MySqlDataReader rd;


            using (var cmd = new MySqlCommand())
            {
                connectdb.Open();
                cmd.CommandText = query;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = connectdb;

                datafill.Add("Select Full");
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    datafill.Add(rd[1].ToString());  // tc kısmı commobox da görünür
                }
                connectdb.Close();
            }

        }

        public void Datagrid_Data()
        {
            DT.Clear();
            MySqlDataAdapter DA = new MySqlDataAdapter(query, connectdb);
            DA.Fill(DS);
            DT = DS.Tables[0];
        }

        public void Filter_Data()
        {
            DT.Clear();
            string query_filter = "SELECT * FROM projeler WHERE projeAd='" + search_text + "'";
            MySqlDataAdapter DA = new MySqlDataAdapter(query_filter, connectdb);
            DA.Fill(DS);
            DT = DS.Tables[0];
        }

        public void ADD_Proje()
        {
            connectdb.Open();
            string query = "INSERT INTO projeler(projeAd,tc,is_baslangic_tarihi, is_bitis_tarihi) VALUES (@projeAd,@tc,@is_baslangic_tarihi,@is_bitis_tarihi)";
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                cmd.Parameters.Add("@tc", MySqlDbType.VarChar).Value = tc;
                cmd.Parameters.Add("@projeAd", MySqlDbType.VarChar).Value = projeAd;
                cmd.Parameters.Add("@is_baslangic_tarihi", MySqlDbType.VarString).Value = is_baslangic_tarihi;
                cmd.Parameters.Add("@is_bitis_tarihi", MySqlDbType.VarString).Value = is_bitis_tarihi;
              

                cmd.ExecuteNonQuery();
                connectdb.Close();
            }
        }

        public void UPDATE_PROJE()
        {
            connectdb.Open();
            string query = "UPDATE projeler SET projeAd=@projeAd, tc=@tc,  is_baslangic_tarihi=@is_baslangic_tarihi, is_bitis_tarihi=@is_bitis_tarihi WHERE tc=@fulltc";
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                cmd.Parameters.Add("@fulltc", MySqlDbType.VarChar).Value = _fulltc;
                cmd.Parameters.Add("@tc", MySqlDbType.VarChar).Value = tc;
                cmd.Parameters.Add("@projeAd", MySqlDbType.VarChar).Value = projeAd;
                cmd.Parameters.Add("@is_başlangic_tarihi", MySqlDbType.VarString).Value = is_baslangic_tarihi;
                cmd.Parameters.Add("@is_bitis_tarihi", MySqlDbType.VarString).Value = is_bitis_tarihi;


                cmd.ExecuteNonQuery();
                connectdb.Close();
            }
        }

        public void DELETE_PROJE()
        {
            connectdb.Open();
            string query = "DELETE FROM projeler WHERE tc=@fulltc";
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                cmd.Parameters.Add("@fulltc", MySqlDbType.VarChar).Value = _fulltc;
                cmd.Parameters.Add("@tc", MySqlDbType.VarChar).Value = tc;
                cmd.Parameters.Add("@projeAd", MySqlDbType.VarChar).Value = projeAd;
                cmd.Parameters.Add("@is_başlangic_tarihi", MySqlDbType.VarChar).Value = is_baslangic_tarihi;
                cmd.Parameters.Add("@is_bitis_tarihi", MySqlDbType.VarChar).Value = is_bitis_tarihi;

                cmd.ExecuteNonQuery();
                connectdb.Close();
            }
        }
    }
}
