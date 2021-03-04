using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ajans.myclass;

namespace Ajans
{
    public partial class FirmalarForm : Form
    {
        Firma f = new Firma();

        public string gecici_deger;

        public FirmalarForm()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            f.search_text = comboBox1.Text;
            if (comboBox1.Text == "Tüm Oyuncular")
            {
                dataGridView1.DataSource = null;
                f.Datagrid_Data();
                dataGridView1.DataSource = f.DT;
            }
            else
            {
                dataGridView1.DataSource = null;
                f.Filter_Data();
                dataGridView1.DataSource = f.DT;
            }
        }

        private void FirmalarForm_Load(object sender, EventArgs e)
        {
            f.Show_Table();
            comboBox1.DataSource = f.datafill;
            dataGridView1.DataSource = null;
            f.Datagrid_Data();
            dataGridView1.DataSource = f.DT;

            panel1.Visible = false;
            panel2.Visible = false;

            // güncelleme ve silme değişkemleri
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            textBox9.Enabled = false;
            textBox10.Enabled = false;
            
            CREATE_DATAGRİD_BUTTON();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            f.firmaAd =textBox1.Text;
            f.anlasmaUcreti = Convert.ToInt32(textBox2.Text);
            f.sehir = textBox3.Text;
            f.anlasmaAdet = Convert.ToInt32(textBox4.Text);
            
            f.ADD_firma();             // method çağrısı
            MessageBox.Show("Yeni firma anlaşma kaydı başarılı");

            // gridview güncelleme
            dataGridView1.DataSource = null;
            f.Datagrid_Data();
            dataGridView1.DataSource = f.DT;

        }
        // datagrid e silme günceleme butonu ekleme
        private void CREATE_DATAGRİD_BUTTON()
        {
            DataGridViewButtonColumn btn_col = new DataGridViewButtonColumn();
            btn_col.HeaderText = "UPDATE/DELETE";
            btn_col.Text = "Click Here";
            btn_col.Name = "btncol";
            btn_col.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btn_col);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;
            try
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    gecici_deger = (dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    textBox7.Text = gecici_deger;
                    textBox8.Text = (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                    textBox9.Text = (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                    textBox10.Text = (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                    
                    panel2.Visible = true;
                }
            }
            catch
            {
                MessageBox.Show("Başlığa tıklamayın");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox7.Enabled = true;
                textBox8.Enabled = true;
                textBox9.Enabled = true;
                textBox10.Enabled = true;
               
            }
            else
            {
                textBox7.Enabled = false;
                textBox8.Enabled = false;
                textBox9.Enabled = false;
                textBox10.Enabled = false;
               
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox7.Text = gecici_deger;
                button6.Enabled = true;
            }
            else
            {
                button6.Enabled = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            f._fullAd = gecici_deger;

            f.firmaAd = textBox7.Text;
            f.anlasmaUcreti = Convert.ToInt32(textBox8.Text);
            f.sehir = textBox9.Text;
            f.anlasmaAdet = Convert.ToInt32(textBox10.Text);
            
            f.UPDATE_firma();         // method çağırımı

            dataGridView1.DataSource = null;
            f.Datagrid_Data();
            dataGridView1.DataSource = f.DT;

            dataGridView1.Columns.Remove("btncol");
            CREATE_DATAGRİD_BUTTON();

            MessageBox.Show("update başarılı");
            panel2.Visible = false;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Emin misiniz ?", "Kayıt silindi", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                f._fullAd = gecici_deger;
                f.DELETE_firma();             // method çağrımı

                dataGridView1.DataSource = null;
                f.Datagrid_Data();
                dataGridView1.DataSource = f.DT;

                dataGridView1.Columns.Remove("btncol");
                CREATE_DATAGRİD_BUTTON();

                MessageBox.Show("silme başarılı");
                panel2.Visible = false;

            }
            else if (dialog == DialogResult.No)
            {

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            KategorilerForm yo = new KategorilerForm();
            yo.Show();
            this.Hide();
        }
    }
}
