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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Net.HttpWebRequest webRequest;

            string requestParams = "{" + '"' + "nume" + '"' + ":" + '"' + textBox1.Text + '"' + "," + '"' + "descriere" + '"' + ":" + '"' + richTextBox1.Text + '"' + "," + '"' + "pret" + '"' + ":"  + textBox2.Text + "}";
            Console.WriteLine(requestParams);
            webRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8080/addproiect");

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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Net.HttpWebRequest webRequest;

            string requestParams = "{" + '"' + "nume" + '"' + ":" + '"' + textBox3.Text + '"' + "," + '"' + "descriere" + '"' + ":" + '"' + richTextBox2.Text + '"' + "," + '"' + "cantitate" + '"' + ":" + textBox4.Text + "," + '"' + "pret" + '"' + ":" + textBox4.Text + "}";
            Console.WriteLine(requestParams);
            webRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8080/addcomp");

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
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            HttpWebRequest webRequest;
            string url = "http://localhost:8080/delproiect/" + textBox6.Text;
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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HttpWebRequest webRequest;
            string url = "http://localhost:8080/delComp/" + textBox7.Text;
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
        }
    }
}
