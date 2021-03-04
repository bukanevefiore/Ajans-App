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
    public class Personel : Calisanlar
    {
        public List<string> datafill = new List<string>();

        public string search_text;

        private string query = "SELECT * FROM personel";

        // constructor
        public Personel()
        {

        }

        // veri tabanından değer almak çin properties
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
            string query_filter = "SELECT * FROM personel WHERE tc='" + search_text + "'";
            MySqlDataAdapter DA = new MySqlDataAdapter(query_filter, connectdb);
            DA.Fill(DS);
            DT = DS.Tables[0];
        }

        public override void ADD_CALİSAN()
        {
            connectdb.Open();
            string query = "INSERT INTO personel(tc,name,surname,mobile,gender,marital_status,salary,per_kategori_id) VALUES (@tc,@name,@surname,@mobile,@gender,@marital_status,@salary,@per_kategori_id)";
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                cmd.Parameters.Add("@tc", MySqlDbType.VarChar).Value = tc;
                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("@surname", MySqlDbType.VarChar).Value = surname;
                cmd.Parameters.Add("@mobile", MySqlDbType.VarChar).Value = mobile;
                cmd.Parameters.Add("@gender", MySqlDbType.VarChar).Value = gender;
                cmd.Parameters.Add("@marital_status", MySqlDbType.VarChar).Value = marital_status;
                cmd.Parameters.Add("@salary", MySqlDbType.VarChar).Value = salary;
                cmd.Parameters.Add("@per_kategori_id", MySqlDbType.VarChar).Value = kategori_id;

                cmd.ExecuteNonQuery();
                connectdb.Close();
            }
        }

        public override void UPDATE_CALİSAN()
        {
            connectdb.Open();
            string query = "UPDATE personel SET tc=@tc, name=@name, surname=@surname,mobile=@mobile,gender=@gender,marital_status=@marital_status, salary=@salary, per_kategori_id=@per_kategori_id WHERE tc=@fulltc";
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;


                cmd.Parameters.Add("@fulltc", MySqlDbType.VarChar).Value = _fulltc;
                cmd.Parameters.Add("@tc", MySqlDbType.VarChar).Value = tc;
                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("@surname", MySqlDbType.VarChar).Value = surname;
                cmd.Parameters.Add("@mobile", MySqlDbType.VarChar).Value = mobile;
                cmd.Parameters.Add("@gender", MySqlDbType.VarChar).Value = gender;
                cmd.Parameters.Add("@marital_status", MySqlDbType.VarChar).Value = marital_status;
                cmd.Parameters.Add("@salary", MySqlDbType.VarChar).Value = salary;
                cmd.Parameters.Add("@per_kategori_id", MySqlDbType.VarChar).Value = kategori_id;

                cmd.ExecuteNonQuery();
                connectdb.Close();
            }
        }

        public override void DELETE_CALİSAN()
        {
            connectdb.Open();
            string query = "DELETE FROM personel WHERE tc=@fulltc";
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;


                cmd.Parameters.Add("@fulltc", MySqlDbType.VarChar).Value = _fulltc;
                cmd.Parameters.Add("@tc", MySqlDbType.VarChar).Value = tc;
                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("@surname", MySqlDbType.VarChar).Value = surname;
                cmd.Parameters.Add("@mobile", MySqlDbType.VarChar).Value = mobile;
                cmd.Parameters.Add("@gender", MySqlDbType.VarChar).Value = gender;
                cmd.Parameters.Add("@marital_status", MySqlDbType.VarChar).Value = marital_status;
                cmd.Parameters.Add("@salary", MySqlDbType.VarChar).Value = salary;
                cmd.Parameters.Add("@per_kategori_id", MySqlDbType.VarChar).Value = kategori_id;

                cmd.ExecuteNonQuery();
                connectdb.Close();
            }
        }

    }
}
