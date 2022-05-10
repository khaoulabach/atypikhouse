using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noyau
{
    public partial class Proprietaire
    {
        public Proprietaire()
        {
            Biens = new HashSet<Bien>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateCreation { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Statut { get; set; } 
        public bool? ListeNoire { get; set; }

        public ICollection<Bien> Biens { get; set; }
    }
}
