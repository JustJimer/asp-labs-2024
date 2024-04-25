using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LR12_Chupyna_ASP_402
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<UserDbContext>(options =>
                    options.UseSqlServer("YourConnectionString"))
                .BuildServiceProvider();

            using (var context = serviceProvider.GetService<UserDbContext>())
            {
                // Ensure the database is created
                context.Database.EnsureCreated();

                // Seed initial data
                SeedData(context);

                // Retrieve and display users from the database
                Console.WriteLine("Users from the database:");
                foreach (var user in context.Users)
                {
                    Console.WriteLine($"{user.FirstName} {user.LastName}, Age: {user.Age}");
                }
            }
        }

        static void SeedData(UserDbContext context)
        {
            // Add three users to the database
            context.Users.AddRange(
                new User { FirstName = "John", LastName = "Doe", Age = 30 },
                new User { FirstName = "Jane", LastName = "Smith", Age = 25 },
                new User { FirstName = "Alice", LastName = "Johnson", Age = 35 }
            );

            context.SaveChanges();
        }
    }
}
