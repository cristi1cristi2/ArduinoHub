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
    public partial class Form8 : Form
    {
        long idg, idg2;
        public Form8()
        {
            
            InitializeComponent();
            for (int i = 0; i < Utilizator.Instance.grupe.Count; i++) {
                listBox1.Items.Add(Utilizator.Instance.grupe[i].nume);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < Utilizator.Instance.grupe.Count; i++)
            {
                if (Utilizator.Instance.grupe[i].nume.CompareTo(listBox1.GetItemText(listBox1.SelectedItem)) == 0) {
                    idg = Utilizator.Instance.grupe[i].id;
                    label1.Text = Utilizator.Instance.grupe[i].nume;
                    label2.Text = Utilizator.Instance.grupe[i].descriere;

                   
                        
                    }

                }
            string URL = "http://localhost:8080/getGrup/" + idg;
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
                Console.WriteLine("{0}\n", data);
                Grup stuff = JsonConvert.DeserializeObject<Grup>(data);
                if (stuff != null)
                {
                    label3.Text =  stuff.utilizatori.Count.ToString();

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            long idu=0;
            int ok=0;
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
                Utilizator stuff = JsonConvert.DeserializeObject<Utilizator>(data);
                if (stuff != null)
                {  idu = stuff.id;
                ok = 1; 
                
                }
                else
                    ok = 0;
            }

            if (ok == 1)
            {
                HttpWebRequest webRequest;
                string URL1 = "http://localhost:8080/linkUtilizator/" + idu + "/" + idg;
                webRequest = (HttpWebRequest)WebRequest.Create(URL1);
                Console.WriteLine("{0}", URL1);

                webRequest.Method = "PUT";
                webRequest.ContentType = "application/json";

                HttpWebResponse response1 = webRequest.GetResponse() as HttpWebResponse;
                Console.WriteLine("Hhhhhhh");
                using (Stream responseStream = response1.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    string data = reader.ReadToEnd();
                }

                 
                 URL1 = "http://localhost:8080/inv/" + idg + "/" + textBox1.Text;
                webRequest = (HttpWebRequest)WebRequest.Create(URL1);
                Console.WriteLine("{0}", URL1);

                webRequest.Method = "PUT";
                webRequest.ContentType = "application/json";

                 response1 = webRequest.GetResponse() as HttpWebResponse;
                Console.WriteLine("Hhhhhhh");
                using (Stream responseStream = response1.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    string data = reader.ReadToEnd();
                }
                label4.Text = "cerere trimisa catre " + textBox1.Text;
            }
            else
            {
                label4.Text = textBox1.Text + " nu exista!";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HttpWebRequest webRequest;

            string requestParams = "{" + '"' + "nume" + '"' + ":" + '"' + textBox2.Text + '"' + "," + '"' + "descriere" + '"' + ":" + '"' + textBox3.Text + '"' + "," + '"' + "nrPers" + '"' + ":"  + "0" + "}";
            Console.WriteLine(requestParams);
            webRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8080/addgrup");

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
                   Grup stuff =  JsonConvert.DeserializeObject<Grup>(Json);
                    Utilizator.Instance.grupe.Add(stuff);
                }
            }

           string URL1 = "http://localhost:8080/getGrupBy/" + textBox2.Text;
            HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(URL1);
            request1.ContentType = "application/json; charset=utf-8";
            //request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes("username:password"));
            //request.PreAuthenticate = true;
            HttpWebResponse response1 = request1.GetResponse() as HttpWebResponse;
            Console.WriteLine("Hhhhhhh");
            using (Stream responseStream = response1.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                Console.WriteLine("Daaaaaa");
                string data = reader.ReadToEnd();
                Proiect stuff = JsonConvert.DeserializeObject<Proiect>(data);
                if (stuff != null)
                    idg2 = stuff.id;
            }
            string URL2 = "http://localhost:8080/linkUtilizator/" + Utilizator.Instance.id+ "/" + idg2;
            webRequest = (HttpWebRequest)WebRequest.Create(URL2);
            Console.WriteLine("{0}", URL2);

            webRequest.Method = "PUT";
            webRequest.ContentType = "application/json";

            HttpWebResponse response2 = webRequest.GetResponse() as HttpWebResponse;
            Console.WriteLine("Hhhhhhh");
            using (Stream responseStream = response2.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                string data = reader.ReadToEnd();
            }
        }
    }
}
