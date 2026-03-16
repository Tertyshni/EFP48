namespace EFP48.EFCore.Data.Entity
{
    public class Brand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}