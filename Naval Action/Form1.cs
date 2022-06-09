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
    public partial class NavalAction1 : Form
    {
        public NavalAction1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 Ventana2 = new Form2();
            Ventana2.ShowDialog();
        }

        private void NavalAction1_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
