namespace PokedexApi.Domain.Entities
{
    //The main data model
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Height { get; set; } = string.Empty;
        public string Weight { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Abilities { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}
