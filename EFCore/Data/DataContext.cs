using EFP48.EFCore.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFP48.EFCore.Data
{
    // Клас контексту даних, який містить набори сутностей

    /*
     Для створення міграції:
    1) У верхньому меню студії, знаходимо пункт Tools(інструменти)
    2) Знаходимо NuGet Package Manager -> відкриваємо Package Manager Console
    3) Прописуємо Add-Migration <тут ви вказуєте ім'я міграції> 
        (Ім'я може бути будь-яким, головне щоб воно відображало суть змін: додали нову сутність, видалили попали, додали поле, як коміти на гіт)
    4) Після успішного створення міграції(знаком успіху, студія Вас одразу перекидує на файл зі "свіжою" міграцією), її треба застосувати до БД.
    5) В тому ж PM Console прописуємо: Update-Database
    6) У якості успіху ви отримаєте повідомлення, що міграція була успішно застосована
     */
    public class DataContext : DbContext
    {
        // Щоб ваш Ентіті став таблицею необхідно створити DbSet<YourEntity>
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        // Конфігурація EntityFramework:
        // тут налаштовується підключення до БД
        // також є можливість налаштувати логування та безліч інших параметрів
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Кажемо EntityFramework що у якості провайдера БД 
            // використовуємо Microsoft SQL Server
            // налаштовуємо логування(тільки вивод SQL-запитів)
            optionsBuilder.UseSqlServer(
                @"Data Source=(LocalDB)\MSSQLLocalDB;
                Initial Catalog=efp481;
                Integrated Security=True");
            //.LogTo(Console.WriteLine, new[] { Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.CommandExecuted })
            //.EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedCategory(modelBuilder);
            SeedProducts(modelBuilder);
            //Необов'язково прописувати. Якщо EF бачить навігаційні властивості, і відповідні(ForeignKey Id's) він сам створить зовнішні ключі
            // Цей метод потрібен для більшого контролю, якщо ви самі хочете створити зв'язки
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .HasPrincipalKey(c => c.Id);
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Brand)
                .WithMany(b => b.Products)
                .HasForeignKey(p => p.BrandId)
                .HasPrincipalKey(b => b.Id);

        }

        




        #region seed
        private void SeedCategory(ModelBuilder builder)
        {
            var createdAt = new DateTime(2025, 1, 1);

            builder.Entity<Category>().HasData(
                new Category { Id = Guid.Parse("561AC3EA-6374-4B26-B422-4C619BDC26FA"), Name = "Smartphones", CreatedAt = createdAt },
                new Category { Id = Guid.Parse("34C0032D-9A67-40A8-B6C4-8C0D15B23650"), Name = "Computers", CreatedAt = createdAt },
                new Category { Id = Guid.Parse("89BD4978-0429-4913-8C74-843F24E35CB6"), Name = "Laptops", CreatedAt = createdAt },
                new Category { Id = Guid.Parse("8E1B8DE7-421B-4020-AC41-3E96B01BA8D3"), Name = "TV-sets", CreatedAt = createdAt },
                new Category { Id = Guid.Parse("4AF1CE03-B37C-40A5-8462-28494820F53F"), Name = "Monitors", CreatedAt = createdAt },
                new Category { Id = Guid.Parse("0D5D102D-E7B0-4A2E-A4FA-076DEB014547"), Name = "Mice", CreatedAt = createdAt },
                new Category { Id = Guid.Parse("6C179026-9A44-4ECA-B75A-811EBB8A577A"), Name = "Keyboards", CreatedAt = createdAt }
            );
        }


        private void SeedProducts(ModelBuilder builder)
        {
            builder.Entity<Product>().HasData(

                // Smartphones
                new Product { Id = Guid.Parse("A1111111-1111-4AAA-8AAA-111111111111"), CategoryId = Guid.Parse("561AC3EA-6374-4B26-B422-4C619BDC26FA"), Name = "iPhone 15", Price = 999.99, CreatedAt = new DateTime(2025, 1, 1) },
                new Product { Id = Guid.Parse("A1111111-1111-4AAA-8AAA-111111111112"), CategoryId = Guid.Parse("561AC3EA-6374-4B26-B422-4C619BDC26FA"), Name = "Samsung Galaxy S24", Price = 899.99, CreatedAt = new DateTime(2025, 1, 1) },
                new Product { Id = Guid.Parse("A1111111-1111-4AAA-8AAA-111111111113"), CategoryId = Guid.Parse("561AC3EA-6374-4B26-B422-4C619BDC26FA"), Name = "Google Pixel 8", Price = 799.99, CreatedAt = new DateTime(2025, 1, 1) },
                new Product { Id = Guid.Parse("A1111111-1111-4AAA-8AAA-111111111114"), CategoryId = Guid.Parse("561AC3EA-6374-4B26-B422-4C619BDC26FA"), Name = "Xiaomi 14", Price = 699.99, CreatedAt = new DateTime(2025, 1, 1) },
                new Product { Id = Guid.Parse("A1111111-1111-4AAA-8AAA-111111111115"), CategoryId = Guid.Parse("561AC3EA-6374-4B26-B422-4C619BDC26FA"), Name = "OnePlus 12", Price = 749.99, CreatedAt = new DateTime(2025, 1, 1) },

                // Computers
                new Product { Id = Guid.Parse("B2222222-2222-4BBB-8BBB-222222222221"), CategoryId = Guid.Parse("34C0032D-9A67-40A8-B6C4-8C0D15B23650"), Name = "Dell OptiPlex 7010", Price = 1200.00, CreatedAt = new DateTime(2025, 1, 1) },
                new Product { Id = Guid.Parse("B2222222-2222-4BBB-8BBB-222222222222"), CategoryId = Guid.Parse("34C0032D-9A67-40A8-B6C4-8C0D15B23650"), Name = "HP Pavilion Desktop", Price = 950.00, CreatedAt = new DateTime(2025, 1, 1) },
                new Product { Id = Guid.Parse("B2222222-2222-4BBB-8BBB-222222222223"), CategoryId = Guid.Parse("34C0032D-9A67-40A8-B6C4-8C0D15B23650"), Name = "Lenovo ThinkCentre", Price = 1100.00, CreatedAt = new DateTime(2025, 1, 1) },
                new Product { Id = Guid.Parse("B2222222-2222-4BBB-8BBB-222222222224"), CategoryId = Guid.Parse("34C0032D-9A67-40A8-B6C4-8C0D15B23650"), Name = "iMac 24", Price = 1800.00, CreatedAt = new DateTime(2025, 1, 1) },
                new Product { Id = Guid.Parse("B2222222-2222-4BBB-8BBB-222222222225"), CategoryId = Guid.Parse("34C0032D-9A67-40A8-B6C4-8C0D15B23650"), Name = "Asus ExpertCenter", Price = 1050.00, CreatedAt = new DateTime(2025, 1, 1) },

                // Laptops
                new Product { Id = Guid.Parse("C3333333-3333-4CCC-8CCC-333333333331"), CategoryId = Guid.Parse("89BD4978-0429-4913-8C74-843F24E35CB6"), Name = "MacBook Air M3", Price = 1500.00, CreatedAt = new DateTime(2025, 1, 1) },
                new Product { Id = Guid.Parse("C3333333-3333-4CCC-8CCC-333333333332"), CategoryId = Guid.Parse("89BD4978-0429-4913-8C74-843F24E35CB6"), Name = "Dell XPS 15", Price = 1700.00, CreatedAt = new DateTime(2025, 1, 1) },
                new Product { Id = Guid.Parse("C3333333-3333-4CCC-8CCC-333333333333"), CategoryId = Guid.Parse("89BD4978-0429-4913-8C74-843F24E35CB6"), Name = "HP Spectre x360", Price = 1600.00, CreatedAt = new DateTime(2025, 1, 1) },
                new Product { Id = Guid.Parse("C3333333-3333-4CCC-8CCC-333333333334"), CategoryId = Guid.Parse("89BD4978-0429-4913-8C74-843F24E35CB6"), Name = "Lenovo Legion 5", Price = 1400.00, CreatedAt = new DateTime(2025, 1, 1) },
                new Product { Id = Guid.Parse("C3333333-3333-4CCC-8CCC-333333333335"), CategoryId = Guid.Parse("89BD4978-0429-4913-8C74-843F24E35CB6"), Name = "Asus ROG Zephyrus", Price = 1900.00, CreatedAt = new DateTime(2025, 1, 1) },

                // TV-sets
                new Product { Id = Guid.Parse("D4444444-4444-4DDD-8DDD-444444444441"), CategoryId = Guid.Parse("8E1B8DE7-421B-4020-AC41-3E96B01BA8D3"), Name = "Samsung QLED 55", Price = 1300.00, CreatedAt = new DateTime(2025, 1, 1) },
                new Product { Id = Guid.Parse("D4444444-4444-4DDD-8DDD-444444444442"), CategoryId = Guid.Parse("8E1B8DE7-421B-4020-AC41-3E96B01BA8D3"), Name = "LG OLED C3", Price = 2100.00, CreatedAt = new DateTime(2025, 1, 1) },
                new Product { Id = Guid.Parse("D4444444-4444-4DDD-8DDD-444444444443"), CategoryId = Guid.Parse("8E1B8DE7-421B-4020-AC41-3E96B01BA8D3"), Name = "Sony Bravia XR", Price = 2000.00, CreatedAt = new DateTime(2025, 1, 1) },
                new Product { Id = Guid.Parse("D4444444-4444-4DDD-8DDD-444444444444"), CategoryId = Guid.Parse("8E1B8DE7-421B-4020-AC41-3E96B01BA8D3"), Name = "Philips Ambilight 65", Price = 1700.00, CreatedAt = new DateTime(2025, 1, 1) },
                new Product { Id = Guid.Parse("D4444444-4444-4DDD-8DDD-444444444445"), CategoryId = Guid.Parse("8E1B8DE7-421B-4020-AC41-3E96B01BA8D3"), Name = "TCL 4K UHD", Price = 900.00, CreatedAt = new DateTime(2025, 1, 1) },

                // Monitors
                new Product { Id = Guid.Parse("E5555555-5555-4EEE-8EEE-555555555551"), CategoryId = Guid.Parse("4AF1CE03-B37C-40A5-8462-28494820F53F"), Name = "Dell UltraSharp 27", Price = 600.00, CreatedAt = new DateTime(2025, 1, 1) },
                new Product { Id = Guid.Parse("E5555555-5555-4EEE-8EEE-555555555552"), CategoryId = Guid.Parse("4AF1CE03-B37C-40A5-8462-28494820F53F"), Name = "LG UltraGear 32", Price = 750.00, CreatedAt = new DateTime(2025, 1, 1) },
                new Product { Id = Guid.Parse("E5555555-5555-4EEE-8EEE-555555555553"), CategoryId = Guid.Parse("4AF1CE03-B37C-40A5-8462-28494820F53F"), Name = "Samsung Odyssey G7", Price = 800.00, CreatedAt = new DateTime(2025, 1, 1) },
                new Product { Id = Guid.Parse("E5555555-5555-4EEE-8EEE-555555555554"), CategoryId = Guid.Parse("4AF1CE03-B37C-40A5-8462-28494820F53F"), Name = "Asus ProArt Display", Price = 950.00, CreatedAt = new DateTime(2025, 1, 1) },
                new Product { Id = Guid.Parse("E5555555-5555-4EEE-8EEE-555555555555"), CategoryId = Guid.Parse("4AF1CE03-B37C-40A5-8462-28494820F53F"), Name = "Acer Predator XB", Price = 850.00, CreatedAt = new DateTime(2025, 1, 1) },

                // Mice
                new Product { Id = Guid.Parse("F6666666-6666-4FFF-8FFF-666666666661"), CategoryId = Guid.Parse("0D5D102D-E7B0-4A2E-A4FA-076DEB014547"), Name = "Logitech MX Master 3", Price = 120.00, CreatedAt = new DateTime(2025, 1, 1) },
                new Product { Id = Guid.Parse("F6666666-6666-4FFF-8FFF-666666666662"), CategoryId = Guid.Parse("0D5D102D-E7B0-4A2E-A4FA-076DEB014547"), Name = "Razer DeathAdder V3", Price = 99.99, CreatedAt = new DateTime(2025, 1, 1) },
                new Product { Id = Guid.Parse("F6666666-6666-4FFF-8FFF-666666666663"), CategoryId = Guid.Parse("0D5D102D-E7B0-4A2E-A4FA-076DEB014547"), Name = "SteelSeries Rival 5", Price = 79.99, CreatedAt = new DateTime(2025, 1, 1) },
                new Product { Id = Guid.Parse("F6666666-6666-4FFF-8FFF-666666666664"), CategoryId = Guid.Parse("0D5D102D-E7B0-4A2E-A4FA-076DEB014547"), Name = "HyperX Pulsefire", Price = 69.99, CreatedAt = new DateTime(2025, 1, 1) },
                new Product { Id = Guid.Parse("F6666666-6666-4FFF-8FFF-666666666665"), CategoryId = Guid.Parse("0D5D102D-E7B0-4A2E-A4FA-076DEB014547"), Name = "Corsair Dark Core", Price = 89.99, CreatedAt = new DateTime(2025, 1, 1) },

                // Keyboards
                new Product { Id = Guid.Parse("E7777777-7777-4AAA-8AAA-777777777771"), CategoryId = Guid.Parse("6C179026-9A44-4ECA-B75A-811EBB8A577A"), Name = "Logitech MX Keys", Price = 130.00, CreatedAt = new DateTime(2025, 1, 1) },
                new Product { Id = Guid.Parse("E7777777-7777-4AAA-8AAA-777777777772"), CategoryId = Guid.Parse("6C179026-9A44-4ECA-B75A-811EBB8A577A"), Name = "Razer BlackWidow V4", Price = 180.00, CreatedAt = new DateTime(2025, 1, 1) },
                new Product { Id = Guid.Parse("E7777777-7777-4AAA-8AAA-777777777773"), CategoryId = Guid.Parse("6C179026-9A44-4ECA-B75A-811EBB8A577A"), Name = "Corsair K95 RGB", Price = 200.00, CreatedAt = new DateTime(2025, 1, 1) },
                new Product { Id = Guid.Parse("E7777777-7777-4AAA-8AAA-777777777774"), CategoryId = Guid.Parse("6C179026-9A44-4ECA-B75A-811EBB8A577A"), Name = "SteelSeries Apex Pro", Price = 210.00, CreatedAt = new DateTime(2025, 1, 1) },
                new Product { Id = Guid.Parse("E7777777-7777-4AAA-8AAA-777777777775"), CategoryId = Guid.Parse("6C179026-9A44-4ECA-B75A-811EBB8A577A"), Name = "Keychron K8", Price = 110.00, CreatedAt = new DateTime(2025, 1, 1) }
            );
        }

     

        #endregion
    }
}
