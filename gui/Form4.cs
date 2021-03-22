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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float vs, r1, r2, vout;
            if (textBox1.TextLength == 0)
                vs = 0;
            else
             vs = float.Parse(textBox1.Text);
            if (textBox2.TextLength == 0)
                r1 = 0;
            else
                r1 = float.Parse(textBox2.Text);
            if (textBox3.TextLength == 0)
                r2 = 0;
            else
                r2 = float.Parse(textBox3.Text);

            if (textBox4.TextLength == 0)
                vout = 0;
            else
                vout = float.Parse(textBox4.Text);
            

            if (textBox1.TextLength == 0) {

                vs = (vout * (r1 + r2)) / r2;
                label1.Text = "s-a calculat Vin";
            }
            if (textBox2.TextLength == 0) { 
            r1 =( r2 * (vs - vout))/ vout;
                label1.Text = "s-a calculat R2";
            }
            if (textBox3.TextLength == 0)
            {
                r2 = vout * r1 / (vs - vout);
                label1.Text = "s-a calculat R2";
            }
            if (textBox4.TextLength == 0)
            {
                vout = vs * r2 / (r1 + r2);
                label1.Text = "s-a calculat Vout";
            }
            textBox1.Text = vs.ToString();
            textBox2.Text = r1.ToString();
            textBox3.Text = r2.ToString();
            textBox4.Text = vout.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            float p, u, i, r;
            if (textBox5.TextLength == 0)
                u = 0;
            else
                u = float.Parse(textBox5.Text);
            if (textBox6.TextLength == 0)
                r = 0;
            else
                r = float.Parse(textBox6.Text);
            if (textBox7.TextLength == 0)
                i = 0;
            else
                i = float.Parse(textBox7.Text);

            if (textBox8.TextLength == 0)
                p = 0;
            else
                p = float.Parse(textBox8.Text);

            if (u != 0 && i != 0) {
                p = u * i;
                r = u / i;
                label1.Text = "s-a calculat P si R";
            }else
            if (u != 0 && r != 0)
            {
                i = u * r;
                p = u * i;
                label1.Text = "s-a calculat I si P";

            }else
            if (u != 0 && p != 0)
            {
                i = p * u;
                r = u / i;
                label1.Text = "s-a calculat I si R";

            }else
            if (r != 0 && i != 0)
            {
                u = r * i;
                p = u * i;
                label1.Text = "s-a calculat P si U";

            }else
            if (r != 0 && p != 0)
            {
                double pla = p / r;
                i = Convert.ToSingle( Math.Sqrt(pla));
                u = i * r;
                label1.Text = "s-a calculat U si I";

            }
            textBox5.Text = u.ToString();
            textBox6.Text = r.ToString();
            textBox7.Text = i.ToString();
            textBox8.Text = p.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var main = new Form2();
            //form2.Show();
            this.Hide();
            main.Closed += (s, args) => this.Close();
            main.Show();
        }


        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            var main = new Form2();
            //form2.Show();
            this.Hide();
            main.Closed += (s, args) => this.Close();
            main.Show();
        }
    }
}
