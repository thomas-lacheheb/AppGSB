using System;
using System.Collections.Generic;
using System.Text;

namespace AppGSB.ClassesMetier
{
    public class QteComposantParMedicament
    {
        public int IdMedicament { get; set; }
        public int IdComposant { get; set; }
        public string LibelleComposant { get; set; }
        public int QteComposant { get; set; }
    }
}
