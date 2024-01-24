using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VillaAPI.Models
{
    public class Villa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//de esa manera el id se asigna automaticamente
        public int Id { get; set; }

        public string Nombre { get; set; }

        public int Habitantes { get; set; }

        public string ImagenUrl { get; set; }

        public DateTime Acualizacion { get; set; }

        public DateTime Fecha { get; set; }
    }
}
