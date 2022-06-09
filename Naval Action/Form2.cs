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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void BotonOpciones_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 Ventana3 = new Form3();
            Ventana3.ShowDialog();
        }

        private void BotonSalir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vuelve pronto.");
            Application.Exit();
        }

        private void BotonJugar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 Ventana5 = new Form5();
            Ventana5.ShowDialog();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
