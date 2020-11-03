using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace CaisseEnregistreuse
{
    public class Panier
    {
        private Boolean ok = false;
        private Dictionary<string,double> panierEnCours = new Dictionary<string, double>();
        private double prixPanier;
        private int inc; 


        public Dictionary<string, double> PanierEnCours { get => panierEnCours; set => panierEnCours = value; }
        public double PrixPanier { get => prixPanier; set => prixPanier = value; }
        public int Inc { get => inc; set => inc = value; }

        public Panier()
        {
        }

        public void open()
        {
            this.ok = true;
            panierEnCours.Clear();
        }

        public void valider(string produit, double prix)
        {
            if (produit != null)
            {
                this.PrixPanier = 0;
            }
            if (PanierEnCours.TryGetValue(produit, out var nimp) == false)
            {
                // On rentrent notre produit et sa quantité dans notre dictionary panierEnCours
                this.panierEnCours.Add(produit, prix);
            }else //si le produit a déjà été saisie, on addition le nouveau poids 
            {
                panierEnCours[produit] += prix; 
            }
                       
            // Et on additione le prix du produit à celui du panier
            foreach (var kvp in this.PanierEnCours)
            {
                this.PrixPanier += kvp.Value;
            }
        }

        public void vider(string dernierProduit)
        {
            // On soustrait le prix du dernier produit à celui du panier
            panierEnCours.TryGetValue(dernierProduit, out double dernierPrix);
            if (dernierPrix != 0)
            {
                this.PrixPanier -= dernierPrix;
            }
            
            panierEnCours.Remove(dernierProduit);
        }

        public void close()
        {
            this.ok = false;
        }
    }
}