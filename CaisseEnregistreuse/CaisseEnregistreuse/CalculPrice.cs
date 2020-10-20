using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaisseEnregistreuse
{
    public class CalculPrice
    {
        public CalculPrice()
        {

        }

        public double calculerPrixTotal()
        {
            Panier panier = new Panier();
            foreach (var kvp in panier.PanierEnCours)
            {
                panier.PrixPanier += kvp.Value;
            }
            
            return panier.PrixPanier;
        }
    }
}