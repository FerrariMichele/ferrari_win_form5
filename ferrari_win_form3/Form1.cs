using System;
using System.IO;
using System.Text;
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
            path = @"dati.csv";
            if (!File.Exists(path)) 
            { 
                File.Create(path);
            }
            Visualizza(path);
            recordLenght = 64;
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int posizione = Ricerca(textBoxNome.Text, path);
            if (posizione == -1)
            {
                Aggiunta(textBoxNome.Text, float.Parse(textBoxPrezzo.Text), path);
            }
            else
            {
                AumentaNumero(posizione, path, recordLenght);
            }
            listView1.Clear();
            Visualizza(path);
            PulisciTextBox();
        }
        private void buttonFind_Click(object sender, EventArgs e)
        {
            int posizione = Ricerca(textBoxNome.Text, path);
            if (posizione == -1)
            {
                MessageBox.Show("Elemento non presente!");
            }
            else
            {
                MessageBox.Show($"Elemento trovato in posizione {posizione}");
            }
            PulisciTextBox();
        }
        private void buttonMod_Click(object sender, EventArgs e)
        {
            int posizione = Ricerca(textBoxNome.Text, path);
            if (posizione == -1)
            {
                MessageBox.Show("Elemento non presente!");
            }
            else
            {
                Modifica(posizione, textBoxNewName.Text, float.Parse(textBoxNewPrice.Text), path, recordLenght);
            }
            listView1.Clear();
            Visualizza(path);
            PulisciTextBox();
        }
        private void buttonDel_Click(object sender, EventArgs e)
        {
            int posizione = Ricerca(textBoxNome.Text, path);
            if (posizione == -1)
            {
                MessageBox.Show("Elemento non presente!");
            }
            else
            {
                Cancellazione(posizione, path, recordLenght);
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
            int posizione = RicercaR(textBoxNome.Text, path);
            if (posizione == -1)
            {
                MessageBox.Show("Elemento non presente!");
            }
            else
            {
                Recupero(posizione, path, recordLenght);
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
            sw.WriteLine($"{nome};{prezzo};1;0;".PadRight(recordLenght - 2) + "##");
            sw.Close();
        }
        public int Ricerca(string nome, string filePath)
        {
            int riga = 0;
            using (StreamReader sr = File.OpenText(filePath))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    string[] dati = s.Split(';');
                    if(dati[3] == "0" && dati[0] == nome)
                    {
                        sr.Close();
                        return riga;
                    }
                    riga++;
                }
                sr.Close();
            }
            return -1;
        }
        public int RicercaR(string nome, string filePath)
        {
            int riga = 0;
            using (StreamReader sr = File.OpenText(filePath))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    string[] dati = s.Split(';');
                    if (dati[0] == nome)
                    {
                        sr.Close();
                        return riga;
                    }
                    riga++;
                }
                sr.Close();
            }
            return -1;
        }
        public product RicercaProdotto(int posizione, string filePath, int recordLenght)
        {
            product p;
            var file = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(file);
            file.Seek(recordLenght * posizione, SeekOrigin.Begin);
            byte[] br = reader.ReadBytes(recordLenght);
            string line = Encoding.ASCII.GetString(br, 0, br.Length);
            p = ProductSplitter(line);
            reader.Close();
            return p;
        }
        public void Modifica(int posizione, string nome, float prezzo, string filePath, int recordLenght)
        {
            product prod = RicercaProdotto(posizione, filePath, recordLenght);
            string line;
            var file = new FileStream(filePath, FileMode.Open, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(file);
            file.Seek(recordLenght * posizione, SeekOrigin.Begin);
            line = $"{nome};{prezzo};{prod.number};0;".PadRight(recordLenght);
            byte[] bytes = Encoding.UTF8.GetBytes(line);
            writer.Write(bytes);
            writer.Close();
            file.Close();
        }
        public void Cancellazione(int posizione, string filePath, int recordLenght)
        {
            product prod = RicercaProdotto(posizione, filePath, recordLenght);
            string line;
            var file = new FileStream(filePath, FileMode.Open, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(file);
            file.Seek(recordLenght * posizione, SeekOrigin.Begin);
            line = $"{prod.name};{prod.price};{prod.number};1;".PadRight(recordLenght);
            byte[] bytes = Encoding.UTF8.GetBytes(line);
            writer.Write(bytes, 0, bytes.Length);
            writer.Close();
            file.Close();
        }
        public void AumentaNumero(int posizione, string filePath, int recordLenght)
        {
            product prod = RicercaProdotto(posizione, filePath, recordLenght);
            string line;
            var file = new FileStream(filePath, FileMode.Open, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(file);
            file.Seek(recordLenght*posizione, SeekOrigin.Begin);
            line = $"{prod.name};{prod.price};{prod.number + 1};0;".PadRight(recordLenght);
            byte[] bytes = Encoding.UTF8.GetBytes(line);
            writer.Write(bytes);
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
                while (!sr.EndOfStream)
                {
                    s = sr.ReadLine();
                    string[] dati = s.Split(';');
                    if (dati[3] == "0")
                    {
                        float price = float.Parse(dati[1]);
                        ListViewItem newItem = new ListViewItem();
                        newItem.Text = dati[0];
                        newItem.SubItems.Add(price.ToString("0.00") + "€");
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
        public void Recupero(int posizione, string filePath, int recordLenght)
        {
            product prod = RicercaProdotto(posizione, filePath, recordLenght);
            string line;
            var file = new FileStream(filePath, FileMode.Open, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(file);
            file.Seek(recordLenght * posizione, SeekOrigin.Begin);
            line = $"{prod.name};{prod.price};{prod.number};0;".PadRight(recordLenght);
            byte[] bytes = Encoding.UTF8.GetBytes(line);
            writer.Write(bytes);
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