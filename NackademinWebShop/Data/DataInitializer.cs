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
            AddNewProduct(applicationDbContext, "Huawei Mate 20 X EVR-L29", "En stor telefon", "Mobile", 5049.99m, "Huawei Mate 20 X EVR-L29\\Huawei-Mate-20X-5G.jpg");
            AddNewProduct(applicationDbContext, "OnePlus Nord", "En liten telefon", "Mobile", 2459.99m, "OnePlus Nord\\OnePlus Nord N100.jpg");
            AddNewProduct(applicationDbContext, "OnePlus Nord N100", "En SKIT STOR telefon", "Mobile", 8756.99m, "OnePlus Nord N100\\OnePlus-Nord 5G.jpg");
            AddNewProduct(applicationDbContext, "OnePlus 7T", "En stor telefonasdfasdfasdfasdfasfd", "Mobile", 9678.99m, "OnePlus 7T\\OnePlus 7T.jpg");
            AddNewProduct(applicationDbContext, "Xiaomi Poco X3", "En stor telefon asdf asdf asdf asdf ", "Mobile", 15049.99m, "Xiaomi Poco X3\\Xiaomi Poco X3.jpg"); //USB Flash drives
            AddNewProduct(applicationDbContext, "Kingston DataTraveler G3", "En stor telefon asdf asdf asdf asdf ", "USB Flash drives", 99, "Kingston DataTraveler G3\\Kingston DataTraveler G3.jpg"); //USB Flash drives
            AddNewProduct(applicationDbContext, "SanDisk UltraFit", "En stor telefon asdf asdf asdf asdf ", "USB Flash drives", 99, "SanDisk UltraFit\\SanDisk UltraFit.jpg"); //USB Flash drives
        }

        private static void AddNewProduct(ApplicationDbContext applicationDbContext, string name, string description, string categoryName, decimal price, string filePath)
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
                    Price = price,
                    ProductPicture = filePath,

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
            AddNewRole(roleManager, "User");
        }

        private static void AddNewRole(RoleManager<IdentityRole> roleManager, string roleName)
        {
            if (roleManager.RoleExistsAsync(roleName).Result) return;
            IdentityRole role = new IdentityRole { Name = roleName };
            IdentityResult roleResult = roleManager.CreateAsync(role).Result;
        }
    }
}
