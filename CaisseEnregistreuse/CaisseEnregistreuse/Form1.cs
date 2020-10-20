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

namespace CaisseEnregistreuse
{
    public partial class Form1 : Form
    {
        ReadingProducts rp; //Objet de la classe Reading Poducts
        AddButton addbutton; 

        public Form1()
        {
            InitializeComponent();
            addbutton = new AddButton();
        }

        




        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_paiement_Click(object sender, EventArgs e)
        {
           
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            //ouverture de l'excel 
            System.Diagnostics.Process.Start(openFileDialog1.FileName);
        }

        private void button_fichier_Click(object sender, EventArgs e)
        {
            //si on appui sur fichier, on ouvre fenetre dialogue
            //retourne un openFileDialog1.FileName
            openFileDialog1.ShowDialog(); 
        }

        private void actualise_Click(object sender, EventArgs e)
        {
            rp = new ReadingProducts(openFileDialog1.FileName);
            //dicProdPrice dictionnaire Products_Price prends "Produit","prix" 
            Dictionary<string, double> dicProdPrice = rp.createDictionaryProducts();

         
            foreach (var kvp in dicProdPrice)
            {
                Button b = new Button();
                b.Text = kvp.Key + "\n" + kvp.Value.ToString();
                flowLayoutPanel1.Controls.Add(b);
            }
        }
    }
}
