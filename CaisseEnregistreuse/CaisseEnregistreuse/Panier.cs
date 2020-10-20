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

        public Dictionary<string, double> PanierEnCours { get => panierEnCours; set => panierEnCours = value; }
        public double PrixPanier { get => prixPanier; set => prixPanier = value; }

        public Panier()
        {

        }


        public void open()
        {
            this.ok = true;
            panierEnCours.Clear();
        }

        public void valider(string legume, double poids)
        {
            //On rentrent notre légume et sa quantité dans notre dictionary panierEnCours
            this.panierEnCours.Add(legume, poids);
      }
        public void close()
        {
            this.ok = false;
        }
    }
}