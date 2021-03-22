using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SimpleHttp;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.InteropServices;

namespace proiectIS
{
   

    public partial class Form1 : Form
    {
        private readonly string cout;

        public Form1()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AllocConsole();
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();


        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            label1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string URL = "http://localhost:8080/utilizator";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.ContentType = "application/json; charset=utf-8";
            //request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes("username:password"));
            //request.PreAuthenticate = true;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Console.WriteLine("Hhhhhhh");
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                Console.WriteLine("Daaaaaa");
                string data = reader.ReadToEnd();
                List<Utilizator> stuff = JsonConvert.DeserializeObject<List<Utilizator>>(data);

                string userlog = textBox1.Text;
                string passlog = textBox2.Text;
                Console.WriteLine("{0}\n{1}\n", userlog, passlog);
                for (int i = 0; i < stuff.Count; i++)
                    if (Equals(userlog, stuff[i].username) && Equals(passlog, stuff[i].pass))
                    {
                        Utilizator.Instance.username = stuff[i].username;
                        Utilizator.Instance.email = stuff[i].email;
                        Utilizator.Instance.nume = stuff[i].nume;
                        Utilizator.Instance.varsta = stuff[i].varsta;
                        Utilizator.Instance.pass = stuff[i].pass;
                        Utilizator.Instance.id = stuff[i].id;
                        Utilizator.Instance.admin = stuff[i].admin;
                        Utilizator.Instance.inv = stuff[i].inv;
                        if (stuff[i].proiect != null)
                        {
                            Utilizator.Instance.proiect = stuff[i].proiect;
                            Console.WriteLine("0000000 {0}\n", Utilizator.Instance.proiect.id);
                        }
                        if (stuff[i].grupe != null)
                        {
                            Utilizator.Instance.grupe = stuff[i].grupe;
                        }
                        label1.Text = "TE-AI LOGAT";
                        var form2 = new Form2();
                        //form2.Show();
                        this.Hide();
                        form2.Closed += (s, args) => this.Close();
                        form2.Show();
                    }
                    else
                    {
                        label1.Text = "Utilizator sau parola incorecte!";

                    }
           
            
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
           

        }
       

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label1.Text = "";
        }

        private void changeBGImageToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Image myimage = new Bitmap(@"D:\login.png");
            this.BackgroundImage = myimage;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var register = new Form3();
            //form2.Show();
            this.Hide();
            register.Closed += (s, args) => this.Close();
            register.Show();
        }
    }
}
