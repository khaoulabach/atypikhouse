using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noyau
{
    public partial class ReservationDto
    {
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; } 
        public int? BienId { get; set; }
        public int? InternauteId { get; set; }
    }
}
