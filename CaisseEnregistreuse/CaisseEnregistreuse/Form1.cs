using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
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
        private Dictionary<string, double> dicarticlesaisis; //dictionnaire des articles validé + prix
        private WriteTicket writeticket; 
        

        //Ascesseurs 
        public List<string> DernierProduit { get => dernierProduit; set => dernierProduit = value; }
        public string Produit { get => produit; set => produit = value; }
        public Dictionary<string, double> Dicarticlesaisis { get => dicarticlesaisis; set => dicarticlesaisis = value; }

        public Form1()
        {
            InitializeComponent();
            // Initialisation de notre liste de dernierProduit
            dernierProduit = new List<string>();
            dicarticlesaisis = new Dictionary<string, double>();
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

        //Fonction qui affiche le panier dans les texts boxs
        //Appelée à chaque validation article
        private void AfficherListe()
        {
            //on vide les texts boxs précédente pour les re-remplir avec le nouveau dictionnaire
            //comme ça on gère aussi le vidage
            flowLayoutPanel2.Controls.Clear();

            foreach (var kvp in panier.PanierEnCours)
            {
                Label tb = new Label();
                //on récupère le poids unitaire de l'article pour afficher le total du poids saisie
                //si un article est saisi plusieur fois, les poids s'additionnent
                double poidsunitart = dicProdPrice[kvp.Key];
                double nbkgsaisis = kvp.Value / poidsunitart;
                tb.Text = "-" +kvp.Key+ " " + nbkgsaisis + " Kg : " + +kvp.Value + " € ";
                tb.AutoSize = true;
                tb.Font = new Font("Arial", 13);
                flowLayoutPanel2.Controls.Add(tb);
            }
        }

        private void button_valider_Click(object sender, EventArgs e)
        {
            // Le prix est enregistré et bloqué et on modifie le dictionnaire du panier
            try
            {
                poids = Double.Parse(textBox_poids.Text);
                //si produit n'est pas nul
                if (poids * prixKg <= 0)
                {
                    MessageBox.Show("Poids invalide");
                }
                else
                {
                    panier.valider(produit, poids * prixKg);
                    this.AfficherListe();
                    // On récupère le dernier produit entré pour pouvoir supprimer le dernier article si besoin
                    dernierProduit.Add(produit);
                    // On modifie l'affichage de notre prix total du panier
                    textBox_prixPanier.Text = panier.PrixPanier.ToString();
                }                
            }
            catch (System.Exception)
            {
                //si produit null, on affiche MsgBox
                if (produit == null)
                {
                    MessageBox.Show("Veuillez entrer un produit");
                }
                else if (produit.Equals("") == false)
                {
                    MessageBox.Show("Veuillez entrer un poids pour " + produit);
                }
            }
            // On réinitialise nos variables
            produit = null;
            poids = 0;
            if (panier.PanierEnCours.Count() > 0)
            {
                button_paiement.Enabled = true;
                //initialisation de la classe WriteTicket qui prendra le nouveau ticket
                writeticket = new WriteTicket(panier.PanierEnCours, dicProdPrice, panier.PrixPanier);
            }
            // Décolore le bouton qui a été coloré lors du clic (et tous les autres d'ailleurs)
            this.colorBlack();
            flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; 
        }

        private void button_panier_Click(object sender, EventArgs e)
        {
            // Réinitialisation de l'interface
            textBox_poids.Text = "";
            textBox_prixPanier.Text = "";
            this.colorBlack();
            produit = null;
            
            //vide l'affichage des articles saisie
            flowLayoutPanel2.Controls.Clear(); 

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
            
            label2.Enabled = true;
            textBox_prixPanier.Enabled = true;
            flowLayoutPanel2.Enabled = true;
          
            panier.Inc = 1;
            //initialisation de la classe WriteTicket qui prendra le nouveau ticket
            writeticket = new WriteTicket(panier.PanierEnCours, dicProdPrice, panier.PrixPanier);
        }

        private void button_vider_Click(object sender, EventArgs e)
        {
            // On ne supprime le dernier article que si il y a déjà des articles dans le panier
            if(dernierProduit.Count > 0)
            {
                panier.vider(dernierProduit[dernierProduit.Count - 1]);
                dernierProduit.RemoveAt(dernierProduit.Count - 1);
                textBox_prixPanier.Text = panier.PrixPanier.ToString();
                this.AfficherListe(); 

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
            produit = null;
            if (panier.PanierEnCours.Count() == 0)
            {
                button_paiement.Enabled = false;   
            }
            else
            {
                //initialisation de la classe WriteTicket qui prendra le panier en cours et les articles dispo
                writeticket = new WriteTicket(panier.PanierEnCours, dicProdPrice, panier.PrixPanier);
            }
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
                listButton.Last().Text = kvp.Key + "\n" + kvp.Value.ToString() +" (€/kg)";
                listButton.Last().AutoSize = true;
                listButton.Last().Padding = new Padding(15);
                // On ajoute ici le bouton au flowLayoutPanel dédié
                flowLayoutPanel1.Controls.Add(listButton.Last());
                // On lie le bouton à sa méthode b_Click
                listButton.Last().Click += new System.EventHandler(b_Click);
                // Les boutons de ce panel apparaissent inactifs
                listButton.Last().Enabled = false;
            }
            // Débloquage du bouton panier
            if (rp.Reader != null)
            {
                button_panier.Enabled = true;
            }
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
            flowLayoutPanel2.Controls.Clear();
        }
        
        private void b_Click(object sender, EventArgs e)
        {
            // Ici on récupère le nom du produit et son prix au kg
            string[] substring = (sender as Button).Text.Split('\n');
            produit = substring[0];

            string[] substring2 = substring[1].Split('('); 
            prixKg = Double.Parse(substring2[0]);
            // On recolore tous les autres boutons articles en noir
            this.colorBlack();
           
            // Puis on colore le bouton sélectionné en rouge
            Color orange = Color.Orange;
            (sender as Button).ForeColor = orange;
        }

        private void button_fichier_Click(object sender, EventArgs e)
        {
            // Si on appui sur fichier, on ouvre fenetre dialogue
            openFileDialog1.ShowDialog();
            // Bloquage des autres boutons si activés
            if (listButton !=null && listButton.Any())
            {
                for (int i = 0; i < listButton.Count(); i++)
                {
                    listButton[i].Enabled = false;
                }
            }
            button_panier.Enabled = false;
            label1.Enabled = false;
            textBox_poids.Enabled = false;
            textBox_poids.Text = "";
            button_valider.Enabled = false;
            button_vider.Enabled = false;
            button_paiement.Enabled = false;
            label2.Enabled = false;
            textBox_prixPanier.Enabled = false;
            textBox_prixPanier.Text = "";
            flowLayoutPanel2.Controls.Clear();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            // Ouverture de l'excel 
            System.Diagnostics.Process.Start(openFileDialog1.FileName);
            // Débloquage du bouton actualiser une fois le fichier choisi et modifié
            actualise.Enabled = true;
        }

        private void button_paiement_Click(object sender, EventArgs e)
        {
            writeticket.Writeinfile();
            if (listButton != null && listButton.Any())
            {
                for (int i = 0; i < listButton.Count(); i++)
                {
                    listButton[i].Enabled = false;
                }
            }
            label1.Enabled = false;
            textBox_poids.Enabled = false;
            textBox_poids.Text = "";
            button_valider.Enabled = false;
            button_vider.Enabled = false;
            button_paiement.Enabled = false;
            label2.Enabled = false;
            textBox_prixPanier.Enabled = false;
            textBox_prixPanier.Text = "";
            flowLayoutPanel2.Controls.Clear();
        }

        private void lastTicket_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(@"ticket.txt");
            }
            catch (Exception)
            {
                MessageBox.Show("Aucun ticket disponible");
            }
            
        }

        private void allTickets_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(@"ticketregister.txt");
            }
            catch (Exception)
            {
                MessageBox.Show("Aucun ticket disponible");
            }
        }
    }
}
