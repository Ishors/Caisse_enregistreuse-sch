using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaisseEnregistreuse
{
    public class WriteTicket
    {
        private Dictionary<string, double> dicarticle; 
        private Dictionary<string, double> panierpaye;
        private double prixpanier; 
        private System.IO.StreamWriter writer;

        public WriteTicket(Dictionary<string, double> panierencours,Dictionary<string,double> dicarticle,double prixpanier)
        {
            this.panierpaye = panierencours;
            this.dicarticle = dicarticle;
            this.prixpanier = prixpanier; 
        }

        public void Writeinfile() {
            var date = DateTime.Now;
            using (writer = new System.IO.StreamWriter(@"ticket.txt"))
            {
                //on récupère le poids unitaire de l'article pour afficher le total du poids saisie
                //si un article est saisi plusieur fois, les poids s'additionnent
                
                writer.WriteLine("--------------------------------");
                writer.WriteLine("Primeur de la côte\nAvenue de beaurivage\n64200 Biarritz \n");
                writer.WriteLine("le " + date.Day+"/"+date.Month+ "/" +date.Year+ "\n" + "à " + date.Hour+":"+date.Minute+"\n");
                foreach (var kvp in panierpaye)
                {
                    double poidsunitart = dicarticle[kvp.Key];
                    double nbkgsaisis = kvp.Value / poidsunitart;
                    writer.WriteLine(kvp.Key +" - "+nbkgsaisis+ "Kg : "+kvp.Value+ " €");                    
                }
                writer.WriteLine("\nTOTAL TTC: "+prixpanier.ToString());
                writer.WriteLine("TVA: " + (prixpanier * 0.2).ToString()); 
                writer.WriteLine("\nMerci de votre visite et...\n... Gardez la pêche!");
                writer.WriteLine("--------------------------------");
            }
            using (writer = new System.IO.StreamWriter(@"ticketregister.txt", true))
            {
                //on récupère le poids unitaire de l'article pour afficher le total du poids saisie
                //si un article est saisi plusieur fois, les poids s'additionnent

                writer.WriteLine("--------------------------------");
                writer.WriteLine("Primeur de la côte\nAvenue de beaurivage\n64200 Biarritz \n");
                writer.WriteLine("le " + date.Day + date.Month + date.Year + "\n" + "à " + date.Hour + ":" + date.Minute + "\n");
                foreach (var kvp in panierpaye)
                {
                    double poidsunitart = dicarticle[kvp.Key];
                    double nbkgsaisis = kvp.Value / poidsunitart;
                    writer.WriteLine(kvp.Key + " - " + nbkgsaisis + "Kg : " + kvp.Value + " €");
                }
                writer.WriteLine("\nTOTAL TTC: " + prixpanier.ToString());
                writer.WriteLine("TVA: " + (prixpanier * 0.2).ToString());
                writer.WriteLine("\nMerci de votre visite et...\n... Gardez la pêche!");
                writer.WriteLine("--------------------------------");
            }
        }

        public void ViderTickets()
        {
            using (writer = new System.IO.StreamWriter(@"ticket.txt", true))
            {
              
            }
        }
    }    
}