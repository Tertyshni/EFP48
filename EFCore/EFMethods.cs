using AutoMapper;
using EFP48.EFCore.Data.Entity;
using EFP48.EFCore.Data.Model;
using EFP48.EFCore.Data.Profiles;
using EFP48.EFCore.Data.Profiles.ProductProfiles;
using EFP48.EFCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFP48.EFCore
{
    public class EFMethods
    {
        /*
         * Для роботи з EF необхідно встановити наступні інструменти:
         * Microsoft.EntityFrameworkCore - основне ядро, сам фреймворк
         * Microsoft.EntityFrameworkCore.Tools - набір інструментів для PackageManager Console
         * Microsoft.EntityFrameworkCore.Design - dotnet-ef CLI
         * Microsoft.EntityFrameworkCore.SqlServer - драйвер для MSSQL
         * Якщо працюєте з MySql: замість SqlServer ставимо Pomelo.EntityFrameworkCore.MySql драйвер для MySQL
         * 
         * для коректної роботи версії цих пакетів мають бути однаковими, і відповідати номеру версії .NET
         * якщо .NET 9-ї версії, відповідно версії цих пакетів мають бути 9-ю версією.
         
         */

        public static void OldMain(string[] args)
        {

            DataContext _dataContext = new();

            // СР: Вивести категорію так само у профілі, вивести наступну інформацію: назва категорії, кількість продуктів в категорії. 7хв


            var result = _dataContext.Products
                .GroupBy(p => p.Category.Name)
                .Select(g => new
                {
                    Category = g.Key,
                    Count = g.Count(),
                    MaxPrice = g.Max(p=>p.Price)
                })
                .ToList();

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            using (var context = new DataContext())
            {

                var brands = context.Products
                    .GroupBy(p => p.Brand.Name)
                    .Select(g => new
                    {
                        Brand = g.Key,
                        ProductCount = g.Count()
                    })
                    .ToList();

                foreach (var b in brands)
                {
                    Console.WriteLine($"{b.Brand} - {b.ProductCount}");
                }


                var avgPrice = context.Products
                    .GroupBy(p => p.Category.Name)
                    .Select(g => new
                    {
                        Category = g.Key,
                        AvgPrice = g.Average(p => p.Price)
                    })
                    .ToList();

                foreach (var c in avgPrice)
                {
                    Console.WriteLine($"{c.Category} - {c.AvgPrice}");
                }



                foreach (var p in context.Products
                    .OrderBy(p => p.Brand.Name)
                    .ToList())
                {
                    Console.WriteLine($"{p.Name} {p.Brand.Name} {p.Price}");
                }
            }

            var products = _dataContext.Products;
            foreach (var product in products) 
            {
                product.DeletedAt = DateTime.UtcNow;
            }

            var deletedProducts = _dataContext.Products
                .Where(p => p.DeletedAt != null)
                .ToList();

            _dataContext.SaveChanges();



            /*
             SELECT * -- all data
             SELECT Name Price -- part of data
             */

            #region Select with AutoMapper
            /*
            var expression = new MapperConfigurationExpression();
            expression.AddProfile(new MappingProfile());
            var config = new MapperConfiguration(expression, new LoggerFactory());

            IMapper mapper = config.CreateMapper();

            var products = _dataContext.Products.Include(p=>p.Category).ToList();

            var productMap = mapper.Map<List<ProductCardProfile>>(products);

            foreach (var item in productMap)
            {
                Console.WriteLine(item);
            }
            */
            #endregion

            #region Default Select
            /*
            // Select to anonymous product
            var products = _dataContext.Products.Select(p => new
            {
                id = p.Id,
                name = p.Name
            }).ToList();

            foreach (var item in products)
            {
                Console.WriteLine(item);
            }

            // Select to mapping
            List<ProductCardModel> productCards = _dataContext.Products
                .Select(p => new ProductCardModel
                {
                    Name = p.Name,
                    Price = p.Price,
                    CategoryName= p.Category!=null? p.Category.Name : "no-category"
                }).ToList();

            foreach (var item in productCards)
            {
                Console.WriteLine(item);
            }
            */
            #endregion

            #region AsNoTracking
            /*
            Product? product = _dataContext.Products.AsNoTracking().First();
            Console.WriteLine(product);


            product.Name = $"[CHANGED]${product.Name}";
            _dataContext.SaveChanges();
            */
            #endregion

            #region CRUD

            /*
            // ### (CREATE) ADD new record. Ми додаємо новий продукт

            //// IQueryable
            //_dataContext
            //    .Products
            //    .Add(new()
            //    {
            //        Id = Guid.NewGuid(),
            //        CategoryId= Guid.Parse("34c0032d-9a67-40a8-b6c4-8c0d15b23650"),
            //        Name = "Product",
            //        Price = 300.0,
            //        Description = "descr",
            //        CreatedAt = DateTime.Now,
            //    });
            //_dataContext.SaveChanges();

            //## (READ) Get product with specified ID.
            Product? searchedProduct = _dataContext.Products.FirstOrDefault(p => p.Id == Guid.Parse("c32f3166-cc41-4e74-b18b-17705c71ee32"));

            //## (UPDATE) Update some attributes of product.
            if (searchedProduct != null)
            {
                //searchedProduct.Name = "Lenovo ThinkCenter i7 DDR38GB";
                //_dataContext.SaveChanges();

                //## (DELETE) Delete this product
                //## Soft delete
                //searchedProduct.DeletedAt = DateTime.Now;
                //_dataContext.SaveChanges();




                //## Hard delete
                _dataContext.Products.Remove(searchedProduct);
                _dataContext.SaveChanges();
            }
            */
            #endregion

            #region Include
            /*
            // Include - дозволяє включити пов'зані сутності. В нашому прикладі, разом з категоріями, будуть підвантажуватися
            // продукти відповідно конкретній категорії.
            IQueryable<Category> query = _dataContext
                .Categories
                .Include(c => c
                .Products
                .Where(p=>p.DeletedAt == null)
                .OrderBy(p => p.Name));
            var categories = query.ToList();
            foreach (var category in categories)
            {
                Console.WriteLine($"CategoryID: {category.Id}, CategoryName: ${category.Name}\n");
                if (category.Products is not null)
                {
                    Console.WriteLine("------------------------------------");
                    foreach (var product in category.Products)
                    {
                        Console.WriteLine(product);
                    }
                    Console.WriteLine("------------------------------------");
                }
            }
            */
            #endregion
        }
    }
}
