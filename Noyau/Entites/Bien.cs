using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noyau
{
    public partial class Bien
    {
        public Bien()
        {
            BienProprietes = new HashSet<BienPropriete>();
            Reservations = new HashSet<Reservation>();
            Commentaires = new HashSet<Commentaire>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime DateCreation { get; set; }
        public long Capacite  { get; set; }
        public float Prix { get; set; }
        public string Titre { get; set; }
        public string Adresse { get; set; }
        public string Localisation { get; set; }
        public string Couchage { get; set; }
        public string Superficie { get; set; }
        public string Equipements { get; set; }
        public string Image { get; set; }

        public string Statut { get; set; } 
        public bool? ListeNoire { get; set; } 
        
        public TypeBien TypeBien { get; set; }
        public Proprietaire Proprietaire { get; set; }
        public ICollection<BienPropriete> BienProprietes { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Commentaire> Commentaires { get; set; }
    }
}
