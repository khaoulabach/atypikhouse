using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noyau
{
    public partial class TypeBien
    {
        public TypeBien()
        {
            Proprietes = new HashSet<Propriete>();
            Biens = new HashSet<Bien>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public string DescriptionAbrege { get; set; }
         
        public ICollection<Propriete> Proprietes { get; set; }
        public ICollection<Bien> Biens { get; set; }

    }
}
