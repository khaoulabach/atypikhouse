using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noyau
{
    public partial class BienPropriete
    {
        public BienPropriete()
        { 

        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        //public int IdBien { get; set; }
        //public int IdPropriete { get; set; } 
          

        public Bien Bien { get; set; }
        public Propriete Propriete { get; set; }
    }
}
