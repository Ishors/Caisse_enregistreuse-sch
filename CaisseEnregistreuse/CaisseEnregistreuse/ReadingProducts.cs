using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CaisseEnregistreuse
{
    public class ReadingProducts
    {
        private string filepathFull; //chemin d'accès au fichier 
        StreamReader reader;
        private bool lecturefile;
        public bool Lecturefile { get => lecturefile; set => lecturefile = value; }
        public StreamReader Reader { get => reader; set => reader = value; }

        public ReadingProducts(string filepath) //constructeur avec le nom du ficher provenant de form1
        {
            //cherche le nom du fichier dans le dossier pour rentrer le chemin d'accés complet
            this.filepathFull = Path.GetFullPath(filepath);

            //ouvre fichier csv
            try
            {
                reader = new StreamReader(filepathFull);
            }
            catch (Exception)
            {
                MessageBox.Show("Veuillez d'abord choisir un fichier ");
            }
    
        }

        

        public Dictionary<string, double> createDictionaryProducts()
        {
            Dictionary<string, double> dicprodprice = new Dictionary<string, double>();
            if (reader != null)
            {
                while (!reader.EndOfStream)
                {
                    //lit chaque ligne et insère dans le dictionnaire <> Product,Price
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    dicprodprice.Add(values[0], double.Parse(values[1]));
                }
                reader.Close();
            }
            
            return dicprodprice;
        }
    }
}