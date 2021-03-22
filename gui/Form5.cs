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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            textBox1.Text = Utilizator.Instance.username;
            textBox2.Text = Utilizator.Instance.email;
            textBox3.Text = Utilizator.Instance.nume;
            textBox4.Text = Utilizator.Instance.varsta.ToString();
            textBox5.Text = Utilizator.Instance.pass;
            textBox6.Text = Utilizator.Instance.pass;
            if (Utilizator.Instance.proiect != null)
            {
                label4.Text = Utilizator.Instance.proiect.nume;
                if (Utilizator.Instance.proiect.pret != 0)
                    label5.Text = "Proiect pentru concurs";
                else
                    label5.Text = "";
                richTextBox1.Text = Utilizator.Instance.proiect.descriere;
            }
            else {
                label4.Text = "Niciun proiect";
                label5.Text = "du-te la meniul principal pt a alege unul!";
            }

            if (Utilizator.Instance.admin == 0)
            {
                label3.Text = "";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
                Utilizator stuff;
                string URL = "http://localhost:8080/getByName/" + textBox1.Text;
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
                    stuff = JsonConvert.DeserializeObject<Utilizator>(data);

                }
                if (stuff != null && stuff.username.CompareTo(Utilizator.Instance.username)!=0)
                {
                    label2.Text = "Numele de utilizator a fost deja luat!";
                }
            else
            if (textBox5.Text.CompareTo(textBox6.Text) != 0)
            {
                textBox5.Text = "";
                textBox6.Text = "";
                label2.Text = "Parolele nu se potrivesc!";

            }
            else if (textBox5.TextLength < 5)
            {
                label2.Text = "Parola trebuie sa contina cel putin 5 caractere!";
            }
            else
            {
                Utilizator.Instance.username = textBox1.Text;
                Utilizator.Instance.email = textBox2.Text;
                Utilizator.Instance.nume = textBox3.Text;
                Utilizator.Instance.varsta = int.Parse(textBox4.Text);
                Utilizator.Instance.pass = textBox5.Text;

                HttpWebRequest webRequest;
                string url = "http://localhost:8080/editUtilizator/" + Utilizator.Instance.id.ToString() + "/";
                string requestParams = "{" + '"' + "username" + '"' + ":" + '"' + textBox1.Text + '"' + "," + '"' + "pass" + '"' + ":" + '"' + textBox5.Text + '"' + "," + '"' + "email" + '"' + ":" + '"' + textBox2.Text + '"' + "," + '"' + "joinDate" + '"' + ":" + "12" + "," + '"' + "nume" + '"' + ":" + '"' + textBox3.Text + '"' + "," + '"' + "varsta" + '"' + ":" + textBox4.Text + "," + '"' + "admin" + '"' + ":" + Utilizator.Instance.admin.ToString() + "}";
                Console.WriteLine(requestParams);
                webRequest = (HttpWebRequest)WebRequest.Create(url);

                webRequest.Method = "PUT";
                webRequest.ContentType = "application/json";

                byte[] byteArray = Encoding.UTF8.GetBytes(requestParams);
                webRequest.ContentLength = byteArray.Length;
                using (Stream requestStream = webRequest.GetRequestStream())
                {
                    requestStream.Write(byteArray, 0, byteArray.Length);
                }

                // Get the response.
                using (WebResponse response1 = webRequest.GetResponse())
                {
                    using (Stream responseStream = response1.GetResponseStream())
                    {
                        StreamReader rdr = new StreamReader(responseStream, Encoding.UTF8);
                        string Json = rdr.ReadToEnd(); // response from server

                    }
                }
                label2.Text = "Modificarile au fost salvate!";
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
            var menu = new Form2();
            //form2.Show();
            this.Hide();
            menu.Closed += (s, args) => this.Close();
            menu.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HttpWebRequest webRequest;
            string url = "http://localhost:8080/delUtilizator/" + Utilizator.Instance.id.ToString();
            string requestParams = "{" + '"' + "username" + '"' + ":" + '"' + textBox1.Text + '"' + "," + '"' + "pass" + '"' + ":" + '"' + textBox5.Text + '"' + "," + '"' + "email" + '"' + ":" + '"' + textBox2.Text + '"' + "," + '"' + "joinDate" + '"' + ":" + "12" + "," + '"' + "nume" + '"' + ":" + '"' + textBox3.Text + '"' + "," + '"' + "varsta" + '"' + ":" + textBox4.Text + "}";
            Console.WriteLine(requestParams);
            webRequest = (HttpWebRequest)WebRequest.Create(url);

            webRequest.Method = "DELETE";
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
            var login = new Form1();
            //form2.Show();
            this.Hide();
            login.Closed += (s, args) => this.Close();
            login.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            HttpWebRequest webRequest;
            string URL = "http://localhost:8080/doneProiect/" + Utilizator.Instance.id;
            webRequest = (HttpWebRequest)WebRequest.Create(URL);
            Console.WriteLine("{0}", URL);

            webRequest.Method = "PUT";
            webRequest.ContentType = "application/json";

            HttpWebResponse response = webRequest.GetResponse() as HttpWebResponse;
            Console.WriteLine("Hhhhhhh");
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                string data = reader.ReadToEnd();

                Utilizator.Instance.proiect = null;


            }
        }
    }
}
