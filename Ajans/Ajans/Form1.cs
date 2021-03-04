using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Ajans.myclass;

namespace Ajans
{
    public partial class Form1 : Form

    {
        
        Accounts acct = new Accounts();
        
        
        public Form1()
        {
            InitializeComponent();
        }

        public static string gonderilecekveri;
       
        private void button2_Click(object sender, EventArgs e)
        {

            

            acct.username = comboBox1.Text;
            acct.user_password = textBox2.Text;
            bool verify = acct.Validate_User();

            // doğrulama ve veri gönderme
            if (verify)
            {
                MessageBox.Show("Welcome" +acct.user_fullname);
                if (comboBox1.Text == "yonetici@gmail.com")
                    {
                    gonderilecekveri = comboBox1.Text;
                    OyuncuKategoriForm f2 = new OyuncuKategoriForm();
                    f2.Show();
                    this.Hide();// bu yani form1 gizle diyoruz
                }
                else
                {
                    
                    KategorilerForm ka = new KategorilerForm();
                    ka.Show();
                    this.Hide();// bu yani form1 gizle diyoruz
                }
            }
            else
            {
                MessageBox.Show("Bilgilerinizi kontrol edin");
            }
        }






        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Visible = false;
            textBox1.Visible = false;
        } 
        private void button1_Click(object sender, EventArgs e)
        {

       

        }

    }
}
