using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noyau
{
    public partial class Commentaire
    {
        public Commentaire()
        { 

        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DateCreation { get; set; }



        public Bien Bien { get; set; } 
        public Internaute Internaute { get; set; }

    }
}
