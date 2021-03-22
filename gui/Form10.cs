using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proiectIS
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            var form1 = new Form2();
            //form2.Show();
            this.Hide();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }
    }
}
