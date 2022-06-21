using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser{DisplayName = "Bob", UserName= "bob", Email = "bob@test.com"},
                    new AppUser{DisplayName = "Tom", UserName= "tom", Email = "tom@test.com"},
                    new AppUser{DisplayName = "Jane", UserName= "jane", Email = "jane@test.com"},
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            }
            if (context.Cards.Any()) return;
            
            var activities = new List<Card>
            {
                new Card
                {
                    Number = "3759876543210001",
                    FirstName = "John",
                    LastName = "Doe",
                    ExpireMonth = 12,
                    ExpireYear = 2025,
                    Balance = 1000,
                },
                new Card
                {
                    Number = "3759876543210002",
                    FirstName = "Jane",
                    LastName = "Doe",
                    ExpireMonth = 12,
                    ExpireYear = 2024,
                    Balance = 1000,
                },
                new Card
                {
                    Number = "3759876543210003",
                    FirstName = "John",
                    LastName = "Wick",
                    ExpireMonth = 12,
                    ExpireYear = 2026,
                    Balance = 1000,
                },
                new Card
                {
                    Number = "3759876543210004",
                    FirstName = "Jane",
                    LastName = "Wick",
                    ExpireMonth = 12,
                    ExpireYear = 2027,
                    Balance = 1000,
                },
                new Card
                {
                    Number = "3759876543210005",
                    FirstName = "Ben",
                    LastName = "Foster",
                    ExpireMonth = 12,
                    ExpireYear = 2024,
                    Balance = 1000,
                },
            };

            await context.Cards.AddRangeAsync(activities);
            await context.SaveChangesAsync();
        }
    }
}