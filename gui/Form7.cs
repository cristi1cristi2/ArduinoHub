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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            label1.Text = Proiect.Instance.nume;
            label2.Text = Proiect.Instance.descriere;
            if (Proiect.Instance.pret != 0)
                label3.Text = "CONCURS!";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            HttpWebRequest webRequest;
            string URL = "http://localhost:8080/likProiect/" + Proiect.Instance.id + "/" + Utilizator.Instance.id;
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
                Utilizator.Instance.proiect = Proiect.Instance;
            }




        }
    }
}
