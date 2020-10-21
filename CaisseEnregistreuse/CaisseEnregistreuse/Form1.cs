using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaisseEnregistreuse
{
    public partial class Form1 : Form
    {
        Panier panier;
        string legume;
        double poids;
        CalculPrice calcul;
        string dernierLegume;
        private ReadingProducts rp; //Objet de la classe Reading Poducts
        private Dictionary<string, double> dicProdPrice; 

        public string DernierLegume { get => dernierLegume; set => dernierLegume = value; }

        public Form1()
        {
            InitializeComponent();
            panier = new Panier();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_valider_Click(object sender, EventArgs e)
        {
            // Le prix est enregistré et bloqué et on modifie le dictionnaire du panier
            // Attention il faut qu'on fasse gaffe aux exceptions
            poids = Double.Parse(textBox_poids.Text);
            panier.valider(legume, poids);
            dernierLegume = legume;
            // On modifie l'affichage de notre prix total du panier
            textBox_prixPanier.Text = calcul.calculerPrixTotal().ToString();

            // On réinitialise nos variables au cas où
            legume = "";
            poids = 0;
        }

        private void button_panier_Click(object sender, EventArgs e)
        {
            panier.open();
            panier = new Panier();
        }

        private void button_vider_Click(object sender, EventArgs e)
        {
            panier.PanierEnCours.Remove(dernierLegume);
        }

        private void actualise_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear(); 
            rp = new ReadingProducts(openFileDialog1.FileName);
            //dicProdPrice dictionnaire Products_Price prends "Produit","prix" 
            this.dicProdPrice = rp.createDictionaryProducts();
            List<Button> listebutton = new List<Button>();
            foreach (var kvp in dicProdPrice)
            {
                Button b = new Button();
                b.Text = kvp.Key + "\n" + kvp.Value.ToString();
                b.AutoSize=true; 
                flowLayoutPanel1.Controls.Add(b);
            }
        }

        private void button_fichier_Click(object sender, EventArgs e)
        {
            //si on appui sur fichier, on ouvre fenetre dialogue
            //retourne un openFileDialog1.FileName
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            //ouverture de l'excel 
            System.Diagnostics.Process.Start(openFileDialog1.FileName);
        }
    }
}
