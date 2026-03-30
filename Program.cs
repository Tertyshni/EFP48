using Dapper;
using EFP48.DapperCore.Entity;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace EFP48
{
    public class Program
    {


        public static async Task Main(string[] args)
        {
            // TODO: Відокремити логіку створення таблиць та данних в окремі методи
            string connectionString = @"
Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ukraine\Desktop\EFP48-master\db_dapper.mdf;Integrated Security=True
";
            using IDbConnection connection = new SqlConnection(connectionString);

            string query = @"
DROP TABLE IF EXISTS Users;
CREATE TABLE Users
(
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Surname NVARCHAR(255) NOT NULL,
    Age INT NOT NULL
);
";
            //connection.Execute(query);

            var users = new List<User>
            {
                new User{ Id = Guid.NewGuid(), Name="Tom", Surname= "Due", Age= 25},
                new User{ Id = Guid.NewGuid(), Name="Alex", Surname="Jackson", Age= 25},
                new User{ Id = Guid.NewGuid(), Name="Bill", Surname="White", Age= 25},
            };

            query = @"INSERT INTO Users(Id, Name, Surname, Age) VALUES(@Id, @Name, @Surname, @Age)";
            //connection.Execute(query, users);

            query = @"SELECT * FROM Users as u ORDER BY u.Age DESC";

            var q_users = connection.Query<User>(query).ToList();

            if (q_users != null)
            {
                foreach (var item in q_users)
                {
                    Console.WriteLine(item);
                }
            }

            Guid searchId = Guid.Parse("53650437-bf01-459f-88ac-4da60f0e00ff");


            query = @"SELECT u.Name, u.Surname FROM Users as u WHERE u.Id = @Id";
            var user = connection.QueryFirstOrDefault<UserCard>(query, new { Id = searchId });



            if (user != null) Console.WriteLine(user);

            query = @"
DROP TABLE IF EXISTS Posts;
CREATE TABLE Posts
(
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    UserId UNIQUEIDENTIFIER NOT NULL,
    Title NVARCHAR(200),
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    DeletedAt DATETIME DEFAULT NULL,
    CONSTRAINT fk_post_user FOREIGN KEY (UserId) REFERENCES Users(Id)
);
";

            //connection.Execute(query);

            query = @"INSERT INTO Posts(UserId, Title) VALUES(@UserId, @Title)";

            var list = new[]
            {
                new {UserId = Guid.Parse("53650437-bf01-459f-88ac-4da60f0e00ff"), Title= "Oh this a great day"},
                new {UserId = Guid.Parse("ccfca5d4-9084-4edf-9e1f-17bb36f23b81"), Title= "Hello world"}

            }.ToList();

            //connection.Execute(query, list);

            // використовуємо тільки якщо не використовуємо using. Connection це некерованний ресурс.
            //connection.Close();

            query = @"
SELECT u.Id, u.Name, u.Surname, u.Age,p.Title
FrOm Users u
JOIN Posts p ON u.Id = p.UserId;
";

            var result = connection.Query<User, Post, Post>(
                query,
                (user, post) =>
                {
                    post.User = user;
                    return post;
                }, splitOn: "Title");

            Console.WriteLine("Count: {0}", result.Count());

            foreach (var item in result)
            {
                Console.WriteLine(item.Title);
                Console.WriteLine(item.User);
            }

            query = @"
SELECT (u.Name+' '+u.Surname) as FullName, COUNT(p.Id) as PostCount 
FROM Users u
LEFT JOIN Posts p ON u.Id = p.UserId
GROUP BY u.Name, u.Surname
";

            var postCount_result = connection.Query<UserPostCount>(query).ToList();

            foreach (var item in postCount_result)
            {
                Console.WriteLine($"{item.FullName}-> posts: {item.PostCount}");
            }

            var context = new DapperContext("your_connection_string");

            var userRepo = new UserRepository(context);
            var postRepo = new PostRepository(context);


            var users1 = await userRepo.GetAllAsync();

            foreach (var user1 in users)
            {
                Console.WriteLine(user.Name);
            }

            query = @"
SELECT TABLE TABLE IF EXISTS Comment;
CREATE TABLE Comment
(
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    UserId UNIQUEIDENTIFIER NOT NULL,
    PostId UNIQUEIDENTIFIER NOT NULL,
    Content NVARCHAR(500) NOT NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    DeletedAt DATETIME DEFAULT NULL,
    CONSTRAINT fk_comment_user FOREIGN KEY (UserId) REFERENCES Users(Id),
    CONSTRAINT fk_comment_post FOREIGN KEY (PostId) REFERENCES Posts(Id)
);
";

            var comment = new
            {
                UserId = Guid.Parse("53650437-bf01-459f-88ac-4da60f0e00ff"),
                PostId = Guid.Parse("some_post_id"),
                Content = "This is a comment"
            };
            //connection.Execute(query, comment);

            query = @"
SELECT TABLE TABLE IF EXISTS CommentLike;
CREATE TABLE CommentLike
(
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    UserId UNIQUEIDENTIFIER NOT NULL,
    CommentId UNIQUEIDENTIFIER NOT NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    DeletedAt DATETIME DEFAULT NULL,
    CONSTRAINT fk_commentlike_user FOREIGN KEY (UserId) REFERENCES Users(Id),
    CONSTRAINT fk_commentlike_comment FOREIGN KEY (CommentId) REFERENCES Comment(Id)
);
";
            //connection.Execute(query);
            var commentLike = new
            {
                UserId = Guid.Parse("53650437-bf01-459f-88ac-4da60f0e00ff"),
                CommentId = Guid.Parse("some_comment_id")
            };

            query = @"
SELECT TABLE TABLE IF EXISTS PostLike;
CREATE TABLE CommentLike
(
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    UserId UNIQUEIDENTIFIER NOT NULL,
    PostId UNIQUEIDENTIFIER NOT NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    DeletedAt DATETIME DEFAULT NULL,
    CONSTRAINT fk_postlike_user FOREIGN KEY (UserId) REFERENCES Users(Id),
    CONSTRAINT fk_postlike_post FOREIGN KEY (PostId) REFERENCES Posts(Id)
);
";
            //connection.Execute(query);
            var postLike = new
            {
                UserId = Guid.Parse("53650437-bf01-459f-88ac-4da60f0e00ff"),
                PostId = Guid.Parse("some_post_id")
            };

            var topComments = context.
                .Select(p => new
                {
                    PostTitle = p.Title,
                    TopComment = p.Comments
                        .OrderByDescending(c => c.Likes.Count)
                        .Select(c => new
                        {
                            c.Text,
                            Likes = c.Likes.Count
                        })
                        .FirstOrDefault()
                })
                .ToList();

            Console.WriteLine(" ТОП коментарі:");
            foreach (var item in topComments)
            {
                Console.WriteLine($"Post: {item.PostTitle}");
                Console.WriteLine($" Top comment: {item.TopComment?.Text} (Likes: {item.TopComment?.Likes})\n");
            }


            var commentCounts = context.Posts
                .Select(p => new
                {
                    PostTitle = p.Title,
                    Count = p.Comments.Count()
                })
                .ToList();

            Console.WriteLine("🔹 Кількість коментарів:");
            foreach (var item in commentCounts)
            {
                Console.WriteLine($"{item.PostTitle}: {item.Count}");
            }


            var topUser = context.Users
                .Select(u => new
                {
                    Name = u.Name,
                    Likes = u.Comments.SelectMany(c => c.Likes).Count()
                })
                .OrderByDescending(x => x.Likes)
                .FirstOrDefault();

            Console.WriteLine("\n🔹 ТОП користувач:");
            Console.WriteLine($"{topUser.Name} - {topUser.Likes} лайків");

        }

    }


        /*
         1) В БД додайте до кожного користувача ще по декілька постів

         2) В програмі, поверніть для кожного користувача самий останній пост
         
         */
 }

    class UserPostCount
    {
        public string FullName { get; set; }
        public int PostCount { get; set; }
    }

    class UserCard
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public override string ToString()
        {
            return $@"
----------------------
Name -> {Name}
Surname -> {Surname}
----------------------
";
        }
    }

