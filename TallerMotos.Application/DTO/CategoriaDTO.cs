namespace TallerMotos.Application.DTO
{
    public record CategoriaDTO
    {
        public int ID { get; set; }

        public string Nombre { get; set; } = null!;
    }
}
