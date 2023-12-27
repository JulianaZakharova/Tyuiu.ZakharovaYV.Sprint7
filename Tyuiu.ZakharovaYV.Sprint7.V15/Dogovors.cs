using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tyuiu.ZakharovaYV.Sprint7.V15
{
    public class Dogovors
    {
        public int Shifr_Dogovora { get; set; }
        public string Name_Organizacii { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public int Summa_Dogovora { get; set; }
        public string Srok_rabot_po_dogovoru { get; set; }

        public Dogovors()
        {

        }
        public Dogovors(int number, string nameOrganiz, string adress, string phone, int summDog, string term)
        {
            Shifr_Dogovora = number;
            Name_Organizacii = nameOrganiz;
            Adress = adress;
            Phone = phone;
            Summa_Dogovora = summDog;
            Srok_rabot_po_dogovoru = term;
        }
    }
}
