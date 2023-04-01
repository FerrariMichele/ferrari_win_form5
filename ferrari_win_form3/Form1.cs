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
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int pos = Ricerca(textBoxNome.Text, path);
            if (pos == -1)
            {
                Aggiunta(textBoxNome.Text, float.Parse(textBoxPrezzo.Text), path);
            }
            else
            {
                AumentaNumero(textBoxNome.Text, path);
            }
            listView1.Clear();
            Visualizza(path);
            PulisciTextBox();
        }
        private void buttonFind_Click(object sender, EventArgs e)
        {
            int pos = Ricerca(textBoxNome.Text, path);
            if (pos == -1)
            {
                MessageBox.Show("Elemento non presente!");
            }
            else
            {
                MessageBox.Show($"Elemento {textBoxNome.Text} trovato in posizione {pos}");
            }
            PulisciTextBox();
        }
        private void buttonMod_Click(object sender, EventArgs e)
        {
            int pos = Ricerca(textBoxNome.Text, path);
            if (pos == -1)
            {
                MessageBox.Show("Elemento non presente!");
            }
            else
            {
                Modifica(pos, textBoxNewName.Text, float.Parse(textBoxNewPrice.Text), path);
            }
            listView1.Clear();
            Visualizza(path);
            PulisciTextBox();
        }
        private void buttonDel_Click(object sender, EventArgs e)
        {
            int pos = Ricerca(textBoxNome.Text, path);
            if (pos == -1)
            {
                MessageBox.Show("Elemento non presente!");
            }
            else
            {
                Cancellazione(textBoxNome.Text, path);
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
            int pos = RicercaR(textBoxNome.Text, path);
            if (pos == -1)
            {
                MessageBox.Show("Elemento non presente!");
            }
            else
            {
                Recupero(textBoxNome.Text, path);
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
            sw.WriteLine($"{nome};{prezzo.ToString("0.00")};1;0");
            sw.Close();
        }
        public int Ricerca(string nome, string filePath)
        {
            int posizione = -1;
            using (StreamReader sr = File.OpenText(filePath))
            {
                string s;
                int riga = 0;
                while ((s = sr.ReadLine()) != null)
                {
                    string[] dati = s.Split(';');
                    if(dati[3] == "0")
                    {
                        riga++;
                        if (dati[0] == nome)
                        {
                            posizione = riga;
                            break;
                        }
                    }
                }
            }
            return posizione;
        }
        public int RicercaR(string nome, string filePath)
        {
            int posizione = -1;
            using (StreamReader sr = File.OpenText(filePath))
            {
                string s;
                int riga = 0;
                while ((s = sr.ReadLine()) != null)
                {
                    string[] dati = s.Split(';');
                    riga++;
                    if (dati[0] == nome)
                    {
                        posizione = riga;
                        break;
                    }
                }
            }
            return posizione;
        }
        public void Modifica(int posizione, string nome, float prezzo, string filePath)
        {
            var oStream = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Read);
            StreamWriter sw = new StreamWriter(oStream);
            oStream.Seek(posizione, SeekOrigin.Current);
            sw.WriteLine($"{nome};{prezzo.ToString("0.00")};1;0");
            sw.Close();
        }
        public void Cancellazione(string nome, string filePath)
        {
            using (StreamReader sr = File.OpenText(filePath))
            {
                string s;
                using (StreamWriter sw = new StreamWriter("tlist.csv", append: true))
                {
                    while ((s = sr.ReadLine()) != null)
                    {
                        string[] dati = s.Split(';');
                        if (nome != dati[0])
                        {
                            sw.WriteLine(s);
                        }
                        else
                        {
                            sw.WriteLine($"{dati[0]};{dati[1]};{dati[2]};1");
                        }
                    }
                }
            }
            File.Delete(filePath);
            File.Move("tlist.csv", filePath);
            File.Delete("tlist.csv");
        }
        public void AumentaNumero(string nome, string filePath)
        {
            using (StreamReader sr = File.OpenText(filePath))
            {
                string s;
                using (StreamWriter sw = new StreamWriter("tlist.csv", append: true))
                {
                    while ((s = sr.ReadLine()) != null)
                    {
                        string[] dati = s.Split(';');
                        if (nome != dati[0])
                        {
                            sw.WriteLine(s);
                        }
                        else
                        {
                            int numero = int.Parse(dati[2]);
                            numero++;
                            sw.WriteLine($"{dati[0]};{dati[1]};{numero};0");
                        }
                    }
                }
            }
            File.Delete(filePath);
            File.Move("tlist.csv", filePath);
            File.Delete("tlist.csv");
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
                        //listView1.Items.Add($"Nome: {dati[0]}; Prezzo: {dati[1]}; Quantità: {dati[2]};");
                        ListViewItem newItem = new ListViewItem();
                        newItem.Text = dati[0];
                        newItem.SubItems.Add(dati[1]);
                        newItem.SubItems.Add(dati[2]);
                        listView1.Items.Add(newItem);
                    }
                }
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
                }
            }
            File.Delete(filePath);
            File.Move("tlist.csv", filePath);
            File.Delete("tlist.csv");
        }
        public void Recupero(string nome, string filePath)
        {
            using (StreamReader sr = File.OpenText(filePath))
            {
                string s;
                using (StreamWriter sw = new StreamWriter("tlist.csv", append: true))
                {
                    while ((s = sr.ReadLine()) != null)
                    {
                        string[] dati = s.Split(';');
                        if (nome != dati[0])
                        {
                            sw.WriteLine(s);
                        }
                        else
                        {
                            sw.WriteLine($"{dati[0]};{dati[1]};{dati[2]};0");
                        }
                    }
                }
            }
            File.Delete(filePath);
            File.Move("tlist.csv", filePath);
            File.Delete("tlist.csv");
        }
        #endregion
    }
}