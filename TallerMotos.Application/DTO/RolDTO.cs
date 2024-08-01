using System.ComponentModel.DataAnnotations;

namespace TallerMotos.Application.DTO
{
    public record RolDTO
    {
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = null!;

    }
}
