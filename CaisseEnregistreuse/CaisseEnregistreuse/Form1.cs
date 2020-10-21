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
        private Panier panier; // Objet de la classe panier 
        private string produit; // Variable de stockage du produit sélectionné
        private double poids; // Variable de stockage du poids entré
        private List<string> dernierProduit; // Liste permettant de retrouver le dernier produit entré
        private double prixKg; // Variable de stockage du prix au kg du produit sélectionnée
        private ReadingProducts rp; // Objet de la classe Reading Poducts
        private Dictionary<string, double> dicProdPrice; // Dictionnaire de stockage après lecture du fichier csv
        private List<Button> listButton; // Liste des boutons créés à partir du fichier csv et du dictionnaire précédent

        public List<string> DernierProduit { get => dernierProduit; set => dernierProduit = value; }

        public Form1()
        {
            InitializeComponent();
            // Initialisation de notre liste de dernierProduit
            dernierProduit = new List<string>();
        }

        // Cette méthode permet de recolorer en noir 
        // tous les boutons créés à partir du fichier csv 
        public void colorBlack()
        {
            Color black = Color.Black;
            for (int i = 0; i < listButton.Count(); i++)
            {
                listButton[i].ForeColor = black;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button_valider_Click(object sender, EventArgs e)
        {
            // Le prix est enregistré et bloqué et on modifie le dictionnaire du panier
            try
            {
                poids = Double.Parse(textBox_poids.Text);
                panier.valider(produit, poids * prixKg);
                // On récupère le dernier produit entré pour pouvoir supprimer le dernier article si besoin
                dernierProduit.Add(produit);
                // On modifie l'affichage de notre prix total du panier
                textBox_prixPanier.Text = panier.PrixPanier.ToString();
            }
            catch (System.FormatException)
            {
                if (produit.Equals(""))
                {
                    MessageBox.Show("Veuillez entrer un produit");
                }
                else if (produit.Equals("") == false)
                {
                    MessageBox.Show("Veuillez entrer un poids pour " + produit);
                }
            }
            // On réinitialise nos variables
            produit = "";
            poids = 0;
            // Décolore le bouton qui a été coloré lors du clic (et tous les autres d'ailleurs)
            this.colorBlack();
        }

        private void button_panier_Click(object sender, EventArgs e)
        {
            // Réinitialisation de l'interface
            produit = "";
            textBox_poids.Text = "";
            textBox_prixPanier.Text = "";
            this.colorBlack();

            // Création du panier
            panier = new Panier();
            panier.open();

            // Débloquage de certains boutons
            for (int i = 0; i < listButton.Count(); i ++)
            {
                listButton[i].Enabled = true;
            }
            label1.Enabled = true;
            textBox_poids.Enabled = true;
            button_valider.Enabled = true;
            button_vider.Enabled = true;
            button_paiement.Enabled = true;
            label2.Enabled = true;
            textBox_prixPanier.Enabled = true;
        }

        private void button_vider_Click(object sender, EventArgs e)
        {
            // On ne supprime le dernier article que si il y a déjà des articles dans le panier
            if(dernierProduit.Count > 0)
            {
                panier.vider(dernierProduit[dernierProduit.Count - 1]);
                dernierProduit.RemoveAt(dernierProduit.Count - 1);
                textBox_prixPanier.Text = panier.PrixPanier.ToString();
                // Décolore le bouton qui a été coloré lors du clic (et tout les autres d'ailleurs)
                Color black = Color.Black;
                for (int i = 0; i < listButton.Count(); i++)
                {
                    listButton[i].ForeColor = black;
                }
            }
            else
            {
                MessageBox.Show("Aucun produit dans le panier");
            }
            produit = "";
            this.colorBlack();
        }

        private void actualise_Click(object sender, EventArgs e)
        {
            // Création d'un flowLayoutPanel dans lequel on va afficher futurs boutons
            flowLayoutPanel1.Controls.Clear();
            // Appel à la classe ReadingProducts qui lit dans notre fichier csv
            rp = new ReadingProducts(openFileDialog1.FileName);
            // dicProdPrice dictionnaire Products_Price prend "Produit","prix" 
            this.dicProdPrice = rp.createDictionaryProducts();
            // Avec les données maintenant enregistrées dans dicProdPrice,
            // on créer des boutons
            listButton = new List<Button>();
            foreach (var kvp in dicProdPrice)
            {
                // Chaque bouton est ajouté à notre listButton
                listButton.Add(new Button());
                // Le Text de chaque bouton est composé du nom du produit ainsi que de son prix au kg
                listButton.Last().Text = kvp.Key + "\n" + kvp.Value.ToString();
                listButton.Last().AutoSize = true;
                // On ajoute ici le bouton au flowLayoutPanel dédié
                flowLayoutPanel1.Controls.Add(listButton.Last());
                // On lie le bouton à sa méthode b_Click
                listButton.Last().Click += new System.EventHandler(b_Click);
                // Les boutons de ce panel apparaissent inactifs
                listButton.Last().Enabled = false;
            }
            // Débloquage du bouton panier
            button_panier.Enabled = true;
            // Bloquage des autres boutons si activés
            label1.Enabled = false;
            textBox_poids.Enabled = false;
            textBox_poids.Text = "";
            button_valider.Enabled = false;
            button_vider.Enabled = false;
            button_paiement.Enabled = false;
            label2.Enabled = false;
            textBox_prixPanier.Enabled = false;
            textBox_prixPanier.Text = "";

        }
        
        private void b_Click(object sender, EventArgs e)
        {
            // Ici on récupère le nom du produit et son prix au kg
            string[] substring = (sender as Button).Text.Split('\n');
            produit = substring[0];
            prixKg = Double.Parse(substring[1]);
            // On recolore tous les autres boutons articles en noir
            this.colorBlack();
            // Puis on colore le bouton sélectionné en rouge
            Color red = Color.Red;
            (sender as Button).ForeColor = red;


        }

        private void button_fichier_Click(object sender, EventArgs e)
        {
            // Si on appui sur fichier, on ouvre fenetre dialogue
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            // Ouverture de l'excel 
            System.Diagnostics.Process.Start(openFileDialog1.FileName);
            // Débloquage du bouton actualiser une fois le fichier choisi et modifié
            actualise.Enabled = true;
        }
    }
}
