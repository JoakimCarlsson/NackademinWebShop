using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NackademinWebShop.Models;

namespace NackademinWebShop.Data
{
    public class DataInitializer
    {
        public static void SeedData(ApplicationDbContext applicationDbContext, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            applicationDbContext.Database.Migrate();
            SeedRoles(roleManager);
            SeedUsers(userManager);
            SeedCategories(applicationDbContext);
            SeedProducts(applicationDbContext);
        }

        private static void SeedProducts(ApplicationDbContext applicationDbContext)
        {
            AddNewProduct(applicationDbContext, "Huawei Mate 20 X", "En stor telefon", "Mobile", 5049.99m);
        }

        private static void AddNewProduct(ApplicationDbContext applicationDbContext, string name, string description, string categoryName, decimal price)
        {
            Product product = applicationDbContext.Products.FirstOrDefault(p => p.Name == name);
            if (product == null)
            {
                Category category = applicationDbContext.Categories.FirstOrDefault(c => c.Name == categoryName);
                if (category == null)
                    return;

                applicationDbContext.Products.Add(new Product
                {
                    Category = category,
                    Description = description,
                    Name = name,
                    Price = price
                });

                applicationDbContext.SaveChanges();
            }
        }

        private static void SeedCategories(ApplicationDbContext applicationDbContext)
        {
            AddNewCategory(applicationDbContext, "Mobile");
            AddNewCategory(applicationDbContext, "USB Flash drives");
            AddNewCategory(applicationDbContext, "Headphones");
        }

        private static void AddNewCategory(ApplicationDbContext applicationDbContext, string name)
        {
            Category category = applicationDbContext.Categories.FirstOrDefault(c => c.Name == name);
            if (category != null) return;
            applicationDbContext.Categories.Add(new Category { Name = name });
            applicationDbContext.SaveChanges();
        }

        private static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            AddNewUser(userManager, "stefan.holmberg@systementor.se", "Hejsan123#", "Administrator");
            AddNewUser(userManager, "stefan.holmbergmanager@systementor.se", "Hejsan123#", "Product Manager");
        }

        private static void AddNewUser(UserManager<IdentityUser> userManager, string email, string password, string role)
        {
            if (userManager.FindByEmailAsync(email).Result != null) return;

            IdentityUser user = new IdentityUser { UserName = email, Email = email, EmailConfirmed = true};
            IdentityResult result = userManager.CreateAsync(user, password).Result;

            if (result.Succeeded)
                userManager.AddToRoleAsync(user, role).Wait();
        }

        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            AddNewRole(roleManager, "Administrator");
            AddNewRole(roleManager, "Product Manager");
        }

        private static void AddNewRole(RoleManager<IdentityRole> roleManager, string roleName)
        {
            if (roleManager.RoleExistsAsync(roleName).Result) return;
            IdentityRole role = new IdentityRole { Name = roleName };
            IdentityResult roleResult = roleManager.CreateAsync(role).Result;
        }
    }
}
