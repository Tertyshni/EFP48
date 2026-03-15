using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFP48.EFCore.Data.Entity
{
    [Table("my_categories")]
    public class Category
    {
        [Key] 
        public Guid Id { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; } = String.Empty;

        [Column(TypeName = "varchar(MAX)")]
        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        // navigation props
        public List<Product>? Products { get; set; }

    }
}
