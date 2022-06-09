using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Naval_Action
{
    public partial class Form3 : Form
    {
        public static int nivelvolumen=100;

        public Form3()
        {
            InitializeComponent();
        }

        private void BotonAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 Ventana2 = new Form2();
            Ventana2.ShowDialog();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            nivelvolumen = trackBar1.Value;
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
