using System.ComponentModel.DataAnnotations;

namespace VillaAPI.Models.DTO
{
    public class VillaDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Nombre { get; set; }

        public int Habitantes { get; set; }

        public string ImagenUrl { get; set; }
    }
}
