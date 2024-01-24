using System.ComponentModel.DataAnnotations;

namespace VillaAPI.Models.DTO
{
    public class VillaUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public int Habitantes { get; set; }

        [Required]
        public string ImagenUrl { get; set; }

        [Required]
        public DateTime Acualizacion { get; set; } = DateTime.Now;
    }
}
