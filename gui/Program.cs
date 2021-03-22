using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
namespace proiectIS
{
    
        // public int proiect { get; set; }
        public sealed class Utilizator
        {
            private static Utilizator instance = null;
            private Utilizator(){ }
            public long id { get; set; }
            public string username { get; set; }
            public string pass { get; set; }
            public string email { get; set; }
            public int joinDate { get; set; }
            public string nume { get; set; }
            public int varsta { get; set; }
            public int admin { get; set; }
            public Proiect proiect { get; set; }
            public List<Grup> grupe { get; set; }
        public int inv { get; set; }
        public static Utilizator Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new Utilizator();
                    }
                    return instance;
                }
            }
        }

    public sealed class Proiect
    {
        private static Proiect instance = null;

        private Proiect()
        {
        }
        public long id { get; set; }
        public string nume { get; set; }
        public string descriere { get; set; }
        public string email { get; set; }
        public int pret { get; set; }
        public static Proiect Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Proiect();
                }
                return instance;
            }
        }
    }

    public sealed class Comp
    {
        private static Comp instance = null;

        private Comp()
        {
        }
        public long id { get; set; }
        public string nume { get; set; }
        public string descriere { get; set; }
        public int pret { get; set; }
        public int cantitate { get; set; }
        public static Comp Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Comp();
                }
                return instance;
            }
        }
    }
    public sealed class Grup
    {
        private static Grup instance = null;

        private Grup()
        {
        }
        public long id { get; set; }
        public string nume { get; set; }
        public string descriere { get; set; }
        public int nrPers { get; set; }
        public Proiect proiect { get; set; }
        public List<Utilizator> utilizatori { get; set; }
        public static Grup Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Grup();
                }
                return instance;
            }
        }
    }

    static class Program
    {
        static HttpClient client = new HttpClient();

        [STAThread]
        static void Main()
        {
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            Console.WriteLine("hello");
        }
    }
}
