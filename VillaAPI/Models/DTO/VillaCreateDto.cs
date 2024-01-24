using System.ComponentModel.DataAnnotations;

namespace VillaAPI.Models.DTO
{
    public class VillaCreateDto
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        public int Habitantes { get; set; }

        [Required]
        public string ImagenUrl { get; set; }
    }
}
