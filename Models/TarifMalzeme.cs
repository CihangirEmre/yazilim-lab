using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesApp.Models
{
    public class TarifMalzeme
    {
        public int TarifID { get; set; }
        public Tarif Tarif { get; set; }

        public int MalzemeID { get; set; }
        public Malzeme Malzeme { get; set; }

        public float MalzemeMiktar { get; set; }
    }
}
