using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noyau
{
    public partial class Propriete
    {
        public Propriete()
        { 

        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }  
        public string IndObligatoire { get; set; }

        public int? TypeBienId { get; set; }

        public TypeBien TypeBien { get; set; } 
        public ICollection<BienPropriete> BienProprietes { get; set; }

    }
}
