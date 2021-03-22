using Newtonsoft.Json;
using System;
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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Utilizator stuff;
            string URL = "http://localhost:8080/getByName/"+textBox1.Text;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.ContentType = "application/json; charset=utf-8";
            //request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes("username:password"));
            //request.PreAuthenticate = true;
            HttpWebResponse response1 = request.GetResponse() as HttpWebResponse;
            Console.WriteLine("Hhhhhhh");
            using (Stream responseStream = response1.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                Console.WriteLine("Daaaaaa");
                string data = reader.ReadToEnd();
                 stuff = JsonConvert.DeserializeObject<Utilizator>(data);

            }
            if (stuff !=null)
            {
                label1.Text = "Numele de utilizator a fost deja luat!";
            }else
            if (textBox1.TextLength==0 || textBox2.TextLength == 0 || textBox3.TextLength == 0 || textBox4.TextLength == 0)
            { label1.Text = "nu au fost introduse toate datele!"; } else
            if (textBox3.Text.CompareTo( textBox4.Text)!=0)
            {
                textBox3.Text = "";
                textBox4.Text = "";
                label1.Text = "Parolele nu se potrivesc!";

            }
            else if (textBox3.TextLength < 5)
            {
                label1.Text = "Parola trebuie sa contina cel putin 5 caractere!";
            }
            else
            {
                HttpWebRequest webRequest;

                string requestParams = "{" + '"' + "username" + '"' + ":" + '"' + textBox1.Text + '"' + "," + '"' + "pass" + '"' + ":" + '"' + textBox3.Text + '"' + "," + '"' +"email" + '"' + ":" + '"' + textBox2.Text + '"'+ "," +'"' +"joinDate"+'"'+":" +"12"+"}";
                Console.WriteLine(requestParams);
                webRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8080/addutilizator");

                webRequest.Method = "POST";
                webRequest.ContentType = "application/json";

                byte[] byteArray = Encoding.UTF8.GetBytes(requestParams);
                webRequest.ContentLength = byteArray.Length;
                using (Stream requestStream = webRequest.GetRequestStream())
                {
                    requestStream.Write(byteArray, 0, byteArray.Length);
                }

                // Get the response.
                using (WebResponse response = webRequest.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        StreamReader rdr = new StreamReader(responseStream, Encoding.UTF8);
                        string Json = rdr.ReadToEnd(); // response from server

                    }
                }

                label1.Text = "cont creat!";
                var login = new Form1();
                //form2.Show();
                this.Hide();
                login.Closed += (s, args) => this.Close();
                login.Show();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Text = "";

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label1.Text = "";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label1.Text = "";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            label1.Text = "";
        }

        private void label2_Click(object sender, EventArgs e)
        {
            var login = new Form1();
            //form2.Show();
            this.Hide();
            login.Closed += (s, args) => this.Close();
            login.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
