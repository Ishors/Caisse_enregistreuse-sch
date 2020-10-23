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
        private System.IO.StreamWriter writer;
  
       

        public WriteTicket(Dictionary<string, double> panierencours,Dictionary<string,double> dicarticle)
        {
            this.panierpaye = panierencours;
            this.dicarticle = dicarticle; 
        }

        public void Writeinfile() {
            using (writer = new System.IO.StreamWriter(@"ticket.txt"))
            {
                foreach (var kvp in panierpaye)
                {
                    
                    //on récupère le poids unitaire de l'article pour afficher le total du poids saisie
                    //si un article est saisi plusieur fois, les poids s'additionnent
                    double poidsunitart = dicarticle[kvp.Key];
                    double nbkgsaisis = kvp.Value / poidsunitart;
                     
                    writer.WriteLine("___" + kvp.Key + " _____ " + nbkgsaisis + " Kg _____ " + +kvp.Value + " € ____");                                      
                }
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