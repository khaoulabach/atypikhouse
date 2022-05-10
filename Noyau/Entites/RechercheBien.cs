using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noyau
{
    public partial class RechercheBien
    { 
        public float PrixMin { get; set; }
        public float PrixMax { get; set; }
        public string Type { get; set; }
        //public TypeBien TypeBien { get; set; }
    }
}
