using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ajans
{
    public partial class KategorilerForm : Form
    {
        public KategorilerForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Oyuncu_Form yo = new Oyuncu_Form();
            yo.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Personel_Form yo = new Personel_Form();
            yo.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            ProjelerForm yo = new ProjelerForm();
            yo.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FirmalarForm yo = new FirmalarForm();
            yo.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            IzinlerForm yo = new IzinlerForm();
            yo.Show();
            this.Hide();
        }

        private void KategorilerForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
