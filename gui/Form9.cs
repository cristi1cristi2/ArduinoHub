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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();

 
            string URL = "http://localhost:8080/getGrup/" + Utilizator.Instance.inv;
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
                Grup stuff = JsonConvert.DeserializeObject<Grup>(data);
                label2.Text = stuff.nume;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string URL1 = "http://localhost:8080/inv/" + "0" + "/" + Utilizator.Instance.nume;
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(URL1);
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
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            HttpWebRequest webRequest;
            string url = "http://localhost:8080/doneGrup/" + Utilizator.Instance.id + "/" + Utilizator.Instance.inv;
                   webRequest = (HttpWebRequest)WebRequest.Create(url);

            webRequest.Method = "PUT";
            webRequest.ContentType = "application/json";

            // Get the response.
            using (WebResponse response = webRequest.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader rdr = new StreamReader(responseStream, Encoding.UTF8);
                    string Json = rdr.ReadToEnd(); // response from server

                }
            }

            this.Hide();
            for (int i = 0; i < Utilizator.Instance.grupe.Count; i++)
            {
                if (Utilizator.Instance.grupe[i].id == Utilizator.Instance.inv) {
                    Utilizator.Instance.grupe.Remove(Utilizator.Instance.grupe[i]);
                }
            }
        }
    }
}
