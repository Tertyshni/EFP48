namespace EFP48.EFCore.Data.Entity
{

    // Це клас сутність, тут описуємо поля майбутньої таблиці
    public class Product
    {
        // Автоматично визначається як первинний ключ
        public Guid Id { get; set; }
        public Guid? CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;

        // Якщо ви створюєте поле як Nullable-тип,
        // EF створить поле у таблиці яке може містити NULL-значення
        public string? Description { get; set; }
        public double Price { get; set; }
        public DateTime CreatedAt { get; set; }

        // Якщо ви створюєте поле як Nullable-тип,
        // EF створить поле у таблиці яке може містити NULL-значення
        public DateTime? DeletedAt { get; set; }

        // navigation props
        public Category? Category { get; set; }

        public Guid? BrandId { get; set; }
        public Brand? Brand { get; set; }

        // Вам ніхто не забороняє створювати свої методи
        public override string ToString()
        {
            return $"ID: {Id} - Name: {Name}";
        }
    }
}
