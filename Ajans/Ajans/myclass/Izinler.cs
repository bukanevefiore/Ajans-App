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
    public class Izinler : Connection_Class
    {

        public string izinTur { get; set; }
        public int tc { get; set; }

        public DateTime izin_baslangic_tarihi { get; set; }

        public DateTime izin_bitis_tarihi { get; set; }

        public Izinler()
        {

        }

        // list tanimlaması
        public List<string> datafill = new List<string>();

        public string search_text;

        private string query = "SELECT * FROM izinler";

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
                    datafill.Add(rd[2].ToString());  // tc kısmı commobox da görünür
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
            string query_filter = "SELECT * FROM izinler WHERE tc='" + search_text + "'";
            MySqlDataAdapter DA = new MySqlDataAdapter(query_filter, connectdb);
            DA.Fill(DS);
            DT = DS.Tables[0];
        }

        public void ADD_izin()
        {
            connectdb.Open();
            string query = "INSERT INTO izinler(izinTur,tc,izin_baslangic_tarihi, izin_bitis_tarihi) VALUES (@izinTur,@tc,@izin_baslangic_tarihi,@izin_bitis_tarihi)";
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                cmd.Parameters.Add("@tc", MySqlDbType.VarChar).Value = tc;
                cmd.Parameters.Add("@izinTur", MySqlDbType.VarChar).Value = izinTur;
                cmd.Parameters.Add("@izin_baslangic_tarihi", MySqlDbType.VarChar).Value = izin_baslangic_tarihi;
                cmd.Parameters.Add("@izin_bitis_tarihi", MySqlDbType.VarChar).Value = izin_bitis_tarihi;


                cmd.ExecuteNonQuery();
                connectdb.Close();
            }
        }

        public void UPDATE_izin()
        {
            connectdb.Open();
            string query = "UPDATE izinler SET izinTur=@izinTur, tc=@tc,  izin_baslangic_tarihi=@izin_baslangic_tarihi, izin_bitis_tarihi=@izin_bitis_tarihi WHERE tc=@fulltc";
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                cmd.Parameters.Add("@fulltc", MySqlDbType.VarChar).Value = _fulltc;
                cmd.Parameters.Add("@tc", MySqlDbType.VarChar).Value = tc;
                cmd.Parameters.Add("@izinTur", MySqlDbType.VarChar).Value = izinTur;
                cmd.Parameters.Add("@izin_başlangic_tarihi", MySqlDbType.VarChar).Value = izin_baslangic_tarihi;
                cmd.Parameters.Add("@izin_bitis_tarihi", MySqlDbType.VarChar).Value = izin_bitis_tarihi;


                cmd.ExecuteNonQuery();
                connectdb.Close();
            }
        }

        public void DELETE_izin()
        {
            connectdb.Open();
            string query = "DELETE FROM izinler WHERE tc=@fulltc";
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                cmd.Parameters.Add("@fulltc", MySqlDbType.VarChar).Value = _fulltc;
                cmd.Parameters.Add("@tc", MySqlDbType.VarChar).Value = tc;
                cmd.Parameters.Add("@izinTur", MySqlDbType.VarChar).Value = izinTur;
                cmd.Parameters.Add("@izin_başlangic_tarihi", MySqlDbType.VarChar).Value = izin_baslangic_tarihi;
                cmd.Parameters.Add("@izin_bitis_tarihi", MySqlDbType.VarChar).Value = izin_bitis_tarihi;

                cmd.ExecuteNonQuery();
                connectdb.Close();
            }
        }
    }
}
