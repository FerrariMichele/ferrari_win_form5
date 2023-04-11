using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ferrari_win_form3
{
    public partial class Form1 : Form
    {
        #region dichiarazioni
        readonly string path;
        readonly int recordLenght;
        public struct product
        {
            public string name;
            public float price;
            public int number;
            public int cancelled;
        }
        #endregion
        #region funzioni evento
        public Form1()
        {
            InitializeComponent();
            path = @"dati.txt";
            if (!File.Exists(path)) 
            { 
                File.Create(path);
            }
            Visualizza(path);
            recordLenght = 64;
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string ser = Ricerca(textBoxNome.Text, path);
            if (ser == "")
            {
                Aggiunta(textBoxNome.Text, float.Parse(textBoxPrezzo.Text), path);
            }
            else
            {
                AumentaNumero(ser, path, recordLenght);
            }
            listView1.Clear();
            Visualizza(path);
            PulisciTextBox();
        }
        private void buttonFind_Click(object sender, EventArgs e)
        {
            string ser = Ricerca(textBoxNome.Text, path);
            if (ser == "")
            {
                MessageBox.Show("Elemento non presente!");
            }
            else
            {
                MessageBox.Show($"Elemento trovato");
            }
            PulisciTextBox();
        }
        private void buttonMod_Click(object sender, EventArgs e)
        {
            string ser = Ricerca(textBoxNome.Text, path);
            if (ser == "")
            {
                MessageBox.Show("Elemento non presente!");
            }
            else
            {
                //Modifica(pos, textBoxNewName.Text, float.Parse(textBoxNewPrice.Text), path);
            }
            listView1.Clear();
            Visualizza(path);
            PulisciTextBox();
        }
        private void buttonDel_Click(object sender, EventArgs e)
        {
            string ser = Ricerca(textBoxNome.Text, path);
            if (ser == "")
            {
                MessageBox.Show("Elemento non presente!");
            }
            else
            {
                Cancellazione(ser, path, recordLenght);
            }
            listView1.Clear();
            Visualizza(path);
            PulisciTextBox();
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            var savefile = MessageBox.Show("Mantenere la lista?", "Salvataggio lista", MessageBoxButtons.YesNo);
            if (savefile == DialogResult.No)
            {
                File.Delete(path);
            }
            Application.Exit();
        }
        private void buttonRec_Click(object sender, EventArgs e)
        {
            string ser = RicercaR(textBoxNome.Text, path);
            if (ser == "")
            {
                MessageBox.Show("Elemento non presente!");
            }
            else
            {
                Recupero(ser, path, recordLenght);
            }
            listView1.Clear();
            Visualizza(path);
            PulisciTextBox();
        }
        private void buttonComp_Click(object sender, EventArgs e)
        {
            Ricompattazione(path);
        }
        #endregion
        #region funzioni di servizio
        public void Aggiunta(string nome, float prezzo, string filePath) 
        {
            var oStream = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Read);
            StreamWriter sw = new StreamWriter(oStream);
            sw.WriteLine($"{nome};{prezzo.ToString("0.00")};1;0;".PadRight(recordLenght - 4) + "##");
            sw.Close();
        }
        public string Ricerca(string nome, string filePath)
        {
            using (StreamReader sr = File.OpenText(filePath))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    string[] dati = s.Split(';');
                    if(dati[3] == "0" && dati[0] == nome)
                    {
                        sr.Close();
                        return s;
                    }
                }
                sr.Close();
            }
            return "";
        }
        public string RicercaR(string nome, string filePath)
        {
            using (StreamReader sr = File.OpenText(filePath))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    string[] dati = s.Split(';');
                    if (dati[0] == nome)
                    {
                        sr.Close();
                        return s;
                    }
                }
                sr.Close();
            }
            return "";
        }
        public void Modifica(string ricerca, string nome, float prezzo, string filePath, int recordLenght)
        {
            product prod, ser;
            ser = ProductSplitter(ricerca);
            string line;
            var file = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite);
            BinaryReader reader = new BinaryReader(file);
            BinaryWriter writer = new BinaryWriter(file);
            file.Seek(0, SeekOrigin.Begin);
            while (file.Position < file.Length)
            {
                byte[] br = reader.ReadBytes(recordLenght);
                line = Encoding.ASCII.GetString(br, 0, br.Length);
                prod = ProductSplitter(line);
                if (prod.name == ser.name)
                {
                    line = $"{nome};{prezzo};{prod.number};0;".PadRight(recordLenght - 4) + "##";
                    file.Seek(-recordLenght, SeekOrigin.Current);
                    writer.Write(line);
                }
            }
            reader.Close();
            writer.Close();
            file.Close();
        }
        public void Cancellazione(string ricerca, string filePath, int recordLenght)
        {
            product prod, ser;
            ser = ProductSplitter(ricerca);
            string line;
            var file = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite);
            BinaryReader reader = new BinaryReader(file);
            BinaryWriter writer = new BinaryWriter(file);
            file.Seek(0, SeekOrigin.Begin);
            while (file.Position < file.Length)
            {
                byte[] br = reader.ReadBytes(recordLenght);
                line = Encoding.ASCII.GetString(br, 0, br.Length);
                prod = ProductSplitter(line);
                if (prod.name == ser.name)
                {
                    line = $"{prod.name};{prod.price};{prod.number};1;".PadRight(recordLenght - 4) + "##";
                    file.Seek(-recordLenght, SeekOrigin.Current);
                    writer.Write(line);
                }
            }
            reader.Close();
            writer.Close();
            file.Close();
        }
        public void AumentaNumero(string ricerca, string filePath, int recordLenght)
        {
            product prod, ser;
            ser = ProductSplitter(ricerca);
            string line;
            var file = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite);
            BinaryReader reader = new BinaryReader(file);
            BinaryWriter writer = new BinaryWriter(file);
            file.Seek(0, SeekOrigin.Begin);
            while (file.Position < file.Length)
            {
                byte[] br = reader.ReadBytes(recordLenght);
                line = Encoding.ASCII.GetString(br, 0, br.Length);
                prod = ProductSplitter(line);
                if (prod.name == ser.name)
                {
                    line = $"{prod.name};{prod.price};{prod.number + 1};0;".PadRight(recordLenght - 4) + "##";
                    file.Seek(-recordLenght, SeekOrigin.Current);
                    writer.Write(line);
                }
            }
            reader.Close();
            writer.Close();
            file.Close();
        }
        public void Visualizza(string filePath) 
        {
            using (StreamReader sr = File.OpenText(filePath))
            {
                string s;
                listView1.View = View.Details;
                listView1.Columns.Add("Nome", 108, HorizontalAlignment.Left);
                listView1.Columns.Add("Prezzo", 108, HorizontalAlignment.Left);
                listView1.Columns.Add("Quantità", 104, HorizontalAlignment.Left);
                listView1.GridLines = true;
                while ((s = sr.ReadLine()) != null)
                {
                    string[] dati = s.Split(';');
                    if (dati[3] == "0")
                    {
                        ListViewItem newItem = new ListViewItem();
                        newItem.Text = dati[0];
                        newItem.SubItems.Add(dati[1]);
                        newItem.SubItems.Add(dati[2]);
                        listView1.Items.Add(newItem);
                    }
                }
                sr.Close();
            }
        }
        public void PulisciTextBox()
        {
            textBoxNome.Text = string.Empty;
            textBoxPrezzo.Text = string.Empty;
            textBoxNewName.Text = string.Empty;
            textBoxNewPrice.Text = string.Empty;
        }
        public void Ricompattazione(string filePath) 
        {
            using (StreamReader sr = File.OpenText(filePath))
            {
                string s;
                using (StreamWriter sw = new StreamWriter("tlist.csv", append: true))
                {
                    while ((s = sr.ReadLine()) != null)
                    {
                        string[] dati = s.Split(';');
                        if (dati[3] == "0")
                        {
                                sw.WriteLine(s);
                        }
                    }
                    sw.Close();
                }
                sr.Close();
            }
            File.Delete(filePath);
            File.Move("tlist.csv", filePath);
            File.Delete("tlist.csv");
        }
        public void Recupero(string ricerca, string filePath, int recordLenght)
        {
            product prod, ser;
            ser = ProductSplitter(ricerca);
            string line;
            var file = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite);
            BinaryReader reader = new BinaryReader(file);
            BinaryWriter writer = new BinaryWriter(file);
            file.Seek(0, SeekOrigin.Begin);
            while (file.Position < file.Length)
            {
                byte[] br = reader.ReadBytes(recordLenght);
                line = Encoding.ASCII.GetString(br, 0, br.Length);
                prod = ProductSplitter(line);
                if (prod.name == ser.name)
                {
                    line = $"{prod.name};{prod.price};{prod.number};0;".PadRight(recordLenght - 4) + "##";
                    file.Seek(-recordLenght, SeekOrigin.Current);
                    writer.Write(line);
                }
            }
            reader.Close();
            writer.Close();
            file.Close();
        }
        public product ProductSplitter(string s)
        {
            product prod;
            string[] dati = s.Split(';');
            prod.name = dati[0];
            prod.price = float.Parse(dati[1]);
            prod.number = int.Parse(dati[2]);
            prod.cancelled = int.Parse(dati[3]);
            return prod;
        }
        #endregion
    }
}