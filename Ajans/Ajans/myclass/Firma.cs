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
    public class Firma : Connection_Class
    {

        public string firmaAd { get; set; }
        public int anlasmaUcreti { get; set; }
        public string sehir { get; set; }
        public int anlasmaAdet { get; set; }

        // constructur
        public Firma()
        {

        }

        public void AnlasmaAdet()
        {

        }

        // list tanimlaması
        public List<string> datafill = new List<string>();

        public string search_text;

        private string query = "SELECT * FROM firmalar";

        // veri tabanından değer almak çin 
        public string _fullproje;
        public string _fullAd;

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
                    datafill.Add(rd[1].ToString());  // firmad kısmı commobox da görünür
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
            string query_filter = "SELECT * FROM firmalar WHERE firmaAd='" + search_text + "'";
            MySqlDataAdapter DA = new MySqlDataAdapter(query_filter, connectdb);
            DA.Fill(DS);
            DT = DS.Tables[0];
        }

        public void ADD_firma()
        {
            connectdb.Open();
            string query = "INSERT INTO firmalar(firmaAd,anlasmaUcreti,sehir, anlasmaAdet) VALUES (@firmaAd, @anlasmaUcreti,@sehir, @anlasmaAdet)";
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                cmd.Parameters.Add("@firmaAd", MySqlDbType.VarChar).Value = firmaAd;
                cmd.Parameters.Add("@anlasmaUcreti", MySqlDbType.VarChar).Value = anlasmaUcreti;
                cmd.Parameters.Add("@sehir", MySqlDbType.VarChar).Value = sehir;
                cmd.Parameters.Add("@anlasmaAdet", MySqlDbType.VarChar).Value = anlasmaAdet;


                cmd.ExecuteNonQuery();
                connectdb.Close();
            }
        }

        public void UPDATE_firma()
        {
            connectdb.Open();
            string query = "UPDATE firmalar SET firmaAd=@firmaAd, anlasmaUcreti=@anlasmaUcreti,  sehir=@sehir, anlasmaAdet=@anlasmaAdet WHERE firmaAd=@fullAd";
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                cmd.Parameters.Add("@fullAd", MySqlDbType.VarChar).Value = _fullAd;
                cmd.Parameters.Add("@firmaAd", MySqlDbType.VarChar).Value = firmaAd;
                cmd.Parameters.Add("@anlasmaUcreti", MySqlDbType.VarChar).Value = anlasmaUcreti;
                cmd.Parameters.Add("@sehir", MySqlDbType.VarChar).Value = sehir;
                cmd.Parameters.Add("@anlasmaAdet", MySqlDbType.VarChar).Value = anlasmaAdet;


                cmd.ExecuteNonQuery();
                connectdb.Close();
            }
        }

        public void DELETE_firma()
        {
            connectdb.Open();
            string query = "DELETE FROM firmalar WHERE firmaAd=@fullAd";
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                cmd.Parameters.Add("@fullAd", MySqlDbType.VarChar).Value = _fullAd;
                cmd.Parameters.Add("@firmaAd", MySqlDbType.VarChar).Value = firmaAd;
                cmd.Parameters.Add("@anlasmaUcreti", MySqlDbType.VarChar).Value = anlasmaUcreti;
                cmd.Parameters.Add("@sehir", MySqlDbType.VarChar).Value = sehir;
                cmd.Parameters.Add("@anlasmaAdet", MySqlDbType.VarChar).Value = anlasmaAdet;

                cmd.ExecuteNonQuery();
                connectdb.Close();
            }
        }
    }
}
