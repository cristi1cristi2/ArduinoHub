using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proiectIS
{
    public partial class Form2 : Form
    {
        bool mail = false;

        public Form2()
        {

            InitializeComponent();
            if (Utilizator.Instance.inv != 0)
            {
                Console.WriteLine("invite!");
                var calculatoare = new Form9();
                //form2.Show();
                calculatoare.Show();

            }
            else
            {
                Console.WriteLine("noooooooo invite!");
            }
            string URL = "http://localhost:8080/proiect";
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
                List<Proiect> stuff = JsonConvert.DeserializeObject<List<Proiect>>(data);
                if (stuff != null)
                {
                    for (int i = 0; i < stuff.Count; i++)
                    {
                        Console.WriteLine("{0}", stuff[i].pret);
                        if (stuff[i].pret == 1)
                            listBox1.Items.Add(stuff[i].nume);
                    }
                }

                label7.Text = Utilizator.Instance.username;
                if (Utilizator.Instance.admin == 0)
                {
                    label8.Text = "";
                    button2.Hide();
                }
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            PictureBox pb1 = new PictureBox();
            pb1.ImageLocation = "";
            pb1.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            string URL = "http://localhost:8080/comp";
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
                List<Comp> stuff = JsonConvert.DeserializeObject<List<Comp>>(data);
                if (stuff != null)
                {
                    for (int i = 0; i < stuff.Count; i++)
                    {
                        Console.WriteLine("{0}", stuff[i].pret);
                       
                            listBox2.Items.Add(stuff[i].nume);
                    }
                    
                }
                label10.Text = "S-au gasit " + stuff.Count.ToString() + " componente.";
            }
        }
            private void label2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            string URL = "http://localhost:8080/proiect";
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
                List<Proiect> stuff = JsonConvert.DeserializeObject<List<Proiect>>(data);
                if (stuff != null)
                {
                    for (int i = 0; i < stuff.Count; i++)
                    {
                        Console.WriteLine("{0}", stuff[i].pret);

                        listBox2.Items.Add(stuff[i].nume);
                    }

                }
                label10.Text = "S-au gasit " + stuff.Count.ToString() + " proiecte.";
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            string URL = "http://localhost:8080/grup";
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
                List<Grup> stuff = JsonConvert.DeserializeObject<List<Grup>>(data);
                if (stuff != null)
                {
                    for (int i = 0; i < stuff.Count; i++)
                    {
                        Console.WriteLine("{0}", stuff[i].nume);

                        listBox2.Items.Add(stuff[i].nume);
                    }

                }
                label10.Text = "S-au gasit " + stuff.Count.ToString() + " grupuri.";
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            var calculatoare = new Form4();
            //form2.Show();
            this.Hide();
            calculatoare.Closed += (s, args) => this.Close();
            calculatoare.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            var form1 = new Form10();
            //form2.Show();
            this.Hide();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            var form1 = new Form1();
            //form2.Show();
            this.Hide();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;

            listBox2.Items.Clear();
            string URL = "http://localhost:8080/getByName/"+textBox1.Text;
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
                Utilizator stuff = JsonConvert.DeserializeObject<Utilizator>(data);
                if (stuff != null)
                { listBox2.Items.Add(stuff.nume);
                count++;
            }
            }

             URL = "http://localhost:8080/getProiectBy/" + textBox1.Text;
             request = (HttpWebRequest)WebRequest.Create(URL);
            request.ContentType = "application/json; charset=utf-8";
            //request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes("username:password"));
            //request.PreAuthenticate = true;
             response = request.GetResponse() as HttpWebResponse;
            Console.WriteLine("Hhhhhhh");
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                Console.WriteLine("Daaaaaa");
                string data = reader.ReadToEnd();
                Proiect stuff = JsonConvert.DeserializeObject<Proiect>(data);
                if (stuff != null)
                { listBox2.Items.Add(stuff.nume);
                count++;
            }
            }

            URL = "http://localhost:8080/getCompBy/" + textBox1.Text;
            request = (HttpWebRequest)WebRequest.Create(URL);
            request.ContentType = "application/json; charset=utf-8";
            //request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes("username:password"));
            //request.PreAuthenticate = true;
            response = request.GetResponse() as HttpWebResponse;
            Console.WriteLine("Hhhhhhh");
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                Console.WriteLine("Daaaaaa");
                string data = reader.ReadToEnd();
                Comp stuff = JsonConvert.DeserializeObject<Comp>(data);
                if (stuff != null)
                {
                    listBox2.Items.Add(stuff.nume);
                    count++;
                }
            }
            label10.Text = "S-au gasit " + count + " cautari.";
        }

        private void label7_Click(object sender, EventArgs e)
        {
            var date = new Form5();
            //form2.Show();
            this.Hide();
            date.Closed += (s, args) => this.Close();
            date.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var adm = new Form6();
            adm.Show();
        }


        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            string text = listBox1.GetItemText(listBox1.SelectedItem);
            string URL = "http://localhost:8080/getProiectBy/" + text;
            Console.WriteLine("{0}", URL);
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
                Proiect stuff = JsonConvert.DeserializeObject<Proiect>(data);
                Proiect.Instance.nume = stuff.nume;
                Proiect.Instance.pret = stuff.pret;
                Proiect.Instance.descriere = stuff.descriere;
                Proiect.Instance.id = stuff.id;
            }
            var date = new Form7();
            //form2.Show();
            date.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            string text = listBox2.GetItemText(listBox2.SelectedItem);
            string URL = "http://localhost:8080/getProiectBy/"+text;
            Console.WriteLine("{0}", URL);
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
                Proiect stuff = JsonConvert.DeserializeObject<Proiect>(data);
                Proiect.Instance.nume = stuff.nume;
                Proiect.Instance.pret = stuff.pret;
                Proiect.Instance.descriere = stuff.descriere;
                Proiect.Instance.id = stuff.id;
            }
            var date = new Form7();
            //form2.Show();
            date.Show();

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var date = new Form8();
            //form2.Show();
            date.Show();
        }
    }
}
