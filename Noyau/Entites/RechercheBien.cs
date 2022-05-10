using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noyau
{
    public partial class RechercheBien
    { 
        public int? PrixMin { get; set; }
        public int? PrixMax { get; set; }
        public string Type { get; set; }
        //public TypeBien TypeBien { get; set; }
    }
}
