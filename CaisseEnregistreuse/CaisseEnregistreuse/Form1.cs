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
    }
}
