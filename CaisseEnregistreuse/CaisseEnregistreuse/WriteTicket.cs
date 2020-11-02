using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace CaisseEnregistreuse
{
    public class WriteTicket
    {
        private Dictionary<string, double> dicarticle; 
        private Dictionary<string, double> panierpaye;
        private double prixpanier; 
        private StreamWriter writer;

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
                writer.WriteLine("le " + date.Day+"/"+date.Month+ "/" +date.Year+ "\n" + "à " + date.Hour+":"+date.Minute.ToString()+"\n");
                foreach (var kvp in panierpaye)
                {
                    double poidsunitart = dicarticle[kvp.Key];
                    double nbkgsaisis = kvp.Value / poidsunitart;
                    //ici, on ecrit dans la ligne Ssi on atteint pas 32 caractères, sinon on saute une ligne (format du ticket oblige)
                    foreach (var str in SplitEvery(("* "+kvp.Key + " - " + nbkgsaisis + "Kg : " + kvp.Value + " €"), 32))
                        writer.WriteLine(str);
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
                writer.WriteLine("le " + date.Day + "/" + date.Month + "/" + date.Year + "\n" + "à " + date.Hour + ":" + date.Minute + "\n");
                foreach (var kvp in panierpaye)
                {
                    double poidsunitart = dicarticle[kvp.Key];
                    double nbkgsaisis = kvp.Value / poidsunitart;
                    //ici, on ecrit dans la ligne Ssi on atteint pas 32 caractères, sinon on saute une ligne (format du ticket oblige)
                    foreach (var str in SplitEvery(("* "+kvp.Key + " - " + nbkgsaisis + "Kg : " + kvp.Value + " €"), 32))
                        writer.WriteLine(str);
                }
                writer.WriteLine("\nTOTAL TTC: " + prixpanier.ToString());
                writer.WriteLine("TVA: " + (prixpanier * 0.2).ToString());
                writer.WriteLine("\nMerci de votre visite et...\n... Gardez la pêche!");
                writer.WriteLine("--------------------------------");
            }
            System.Diagnostics.Process.Start(@"ticket.txt");
        }

        //les classes ci dessous gèrent le saut de ligne si on dépasse un certain nombre de carac chunkSize
        // interface publique (contrôle immédiat des arguments) 
        public IEnumerable<string> SplitEvery(string str, int chunkSize)
        {
            if (str == null)
                throw new ArgumentNullException("str");
            if (chunkSize <= 0)
                throw new ArgumentOutOfRangeException("chunkSize");

            // appel au bloc itérateur 
            return SplitEveryIterator(str, chunkSize);
        }
        // bloc itérateur privé (permet l'évaluation tardive) 
        private IEnumerable<string> SplitEveryIterator(string str, int chunkSize)
        {
            if (str.Length <= chunkSize)
                // si le texte est plus court que la taille demandée ; le renvoyer directement 
                yield return str;
            else
            {
                var chunkCount = str.Length / chunkSize; // nombre de morceaux 
                var remainingSize = str.Length % chunkSize; // taille du morceau final 

                for (var offset = 0; offset < chunkCount; ++offset)
                    yield return str.Substring(offset * chunkSize, chunkSize);

                // renvoyer le morceau final s'il existe 
                if (remainingSize != 0)
                    yield return str.Substring(chunkCount * chunkSize, remainingSize);
            }
        }
    }
}    
