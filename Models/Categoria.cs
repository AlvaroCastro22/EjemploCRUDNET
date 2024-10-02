using System.ComponentModel.DataAnnotations;

namespace WebAppBD.Models
{
    public class Categoria
    {
        [Key]
        public int Categoria_Id { get; set; }
        [Required]
        public string? Nombre { get; set; }
    }
}
