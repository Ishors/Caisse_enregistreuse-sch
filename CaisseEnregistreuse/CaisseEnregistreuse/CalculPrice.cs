using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaisseEnregistreuse
{
    public class CalculPrice : Panier
    {
        public CalculPrice()
        {

        }

        public double calculerPrixTotal()
        {
            foreach (var kvp in this.PanierEnCours)
            {
                this.PrixPanier += kvp.Value;
            }
            
            return this.PrixPanier;
        }
    }
}