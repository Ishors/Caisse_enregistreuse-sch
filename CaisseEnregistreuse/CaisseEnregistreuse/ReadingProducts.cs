using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CaisseEnregistreuse
{
    public class ReadingProducts
    {
        private string filepathFull; //chemin d'accès au fichier 
        StreamReader reader;
        private bool lecturefile;
        public bool Lecturefile { get => lecturefile; set => lecturefile = value; }

        public ReadingProducts(string filepath) //constructeur avec le nom du ficher provenant de form1
        {
            //cherche le nom du fichier dans le dossier pour rentrer le chemin d'accés complet
            this.filepathFull = Path.GetFullPath(filepath);

            //ouvre fichier csv
            try
            {
                reader = new StreamReader(filepathFull);
            }
            catch (FileNotFoundException)
            {
                System.Windows.Forms.MessageBox.Show("Veuillez d'abord choisir un fichier ");
            }
             
        }

        

        public Dictionary<string, double> createDictionaryProducts()
        {
            Dictionary<string, double> dicprodprice = new Dictionary<string, double>();
            while (!reader.EndOfStream)
                {
                    //lit chaque ligne et insère dans le dictionnaire <> Product,Price
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    dicprodprice.Add(values[0], double.Parse(values[1]));
                }


            
            
            reader.Close();
            return dicprodprice;
        }
    }
}