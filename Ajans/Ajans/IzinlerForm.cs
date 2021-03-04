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
    public partial class IzinlerForm : Form

    {

        Izinler izin = new Izinler();

        public string gecici_deger;

        public IzinlerForm()
        {
            InitializeComponent();
        }

        private void IzinlerForm_Load(object sender, EventArgs e)
        {

            izin.Show_Table();
            comboBox1.DataSource = izin.datafill;
            dataGridView1.DataSource = null;
            izin.Datagrid_Data();
            dataGridView1.DataSource = izin.DT;

            panel1.Visible = false;
            panel2.Visible = false;

            // güncelleme ve silme değişkemleri
            textBox7.Enabled = false;
            comboBox3.Enabled = false;

            CREATE_DATAGRİD_BUTTON();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            izin.search_text = comboBox1.Text;
            if (comboBox1.Text == "Tüm Projeler")
            {
                dataGridView1.DataSource = null;
                izin.Datagrid_Data();
                dataGridView1.DataSource = izin.DT;
            }
            else
            {
                dataGridView1.DataSource = null;
                izin.Filter_Data();
                dataGridView1.DataSource = izin.DT;
            }
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
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "d/M/yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "d/M/yyyy";

            izin.tc = Convert.ToInt32(textBox1.Text);
            izin.izinTur = comboBox2.Text;
            izin.izin_baslangic_tarihi = dateTimePicker1.Value;
            izin.izin_bitis_tarihi = dateTimePicker2.Value;
            izin.ADD_izin();
            MessageBox.Show("Yeni izin kaydı başarılı");

            // gridview güncelleme
            dataGridView1.DataSource = null;
            izin.Datagrid_Data();
            dataGridView1.DataSource = izin.DT;
        }

        // datagride silme güncelleme butonu ekleme
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
                    gecici_deger = (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                    textBox7.Text = gecici_deger;
                    comboBox3.Text = (dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    //  dateTimePicker3.Value = (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                    //  dateTimePicker4.Value = (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());


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
                comboBox3.Enabled = true;
                dateTimePicker3.Enabled = true;
                dateTimePicker4.Enabled = true;
            }
            else
            {
                textBox7.Enabled = false;
                comboBox3.Enabled = false;
                dateTimePicker3.Enabled = false;
                dateTimePicker4.Enabled = false;

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
            izin._fullproje = gecici_deger;

            izin.tc = Convert.ToInt32(textBox7.Text);
            izin.izinTur = comboBox3.Text;
            izin.izin_baslangic_tarihi = dateTimePicker3.Value;
            izin.izin_bitis_tarihi = dateTimePicker4.Value;
            izin.UPDATE_izin();

            dataGridView1.DataSource = null;
            izin.Datagrid_Data();
            dataGridView1.DataSource = izin.DT;

            dataGridView1.Columns.Remove("btncol");
            CREATE_DATAGRİD_BUTTON();

            MessageBox.Show("update başarılı");
            panel2.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Emin misiniz ?", "İzin silindi", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                izin._fullproje = gecici_deger;
                izin.DELETE_izin();

                dataGridView1.DataSource = null;
                izin.Datagrid_Data();
                dataGridView1.DataSource = izin.DT;

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
