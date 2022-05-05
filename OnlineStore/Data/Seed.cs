using System;
using OnlineStore.Services;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Models.Database;

namespace OnlineStore.Data
{
    public class Seed
    {
        public void SeedData(ModelBuilder builder)
        {
            //CREATE USER ROLES
            var simpleRole = new UserRole() { Id = 1, Name = "SimpleUser" };
            var adminRole = new UserRole() { Id = 2, Name = "Administrator" };
            var moderRole = new UserRole() { Id = 3, Name = "Moderator" };

            //CREATE CATEGORIES
            var ski = new Category() { Id = 1, Name = "Ski" };
            var equipment = new Category() { Id = 2, Name = "Equipment" };
            var boots = new Category() { Id = 3, Name = "Boots" };

            //CREATE IMAGES
            var worldCupSki = new Image() { Id = 1, Path = "worldcupSki.png" };
            var raceSkiHelmet = new Image() { Id = 2, Path = "raceSkiHelmet.jpg" };
            var raptorWcr120SkiBoot = new Image() { Id = 3, Path = "raptorWcr120SkiBoot.jpg" };
            var rebelsSunJacketMen = new Image() { Id = 4, Path = "rebelsSunJacketMen.jpg" };
            var infinityJacketWomen = new Image() { Id = 5, Path = "infinityJacketWomen.jpg" };

            //CREATE USERS
            //password for the user = 12345678
            //role - simple user
            var user1 = new User()
            {
                Id = 1,
                CreationTime = DateTime.Now,
                Name = "Vasil",
                Surname = "Vasilev",
                Email = "vaskov@gmail.com",
                PasswordHash = PasswordConverter.Hash("12345678"),
                RoleId = 1,
                Address = ""
            };
            //password = qwerty12
            //role = administrator
            var user2 = new User()
            {
                Id = 2,
                CreationTime = DateTime.Now,
                Name = "Georgi",
                Surname = "Georgiev",
                Email = "georgig@gmail.com",
                PasswordHash = PasswordConverter.Hash("qwerty12"),
                RoleId = 3,
                Address = ""
            };
            //password = 87654321
            //role - moderator
            var user3 = new User()
            {
                Id = 3,
                CreationTime = DateTime.Now,
                Name = "Eli",
                Surname = "Dosseva",
                Email = "elidos01@gmail.com",
                PasswordHash = PasswordConverter.Hash("87654321"),
                RoleId = 2,
                Address = ""
            };

            //CREATE PRODUCTS
            var product1 = new Product()
            {
                Id = 1,
                CreatorUserId = 3,
                CategoryId = 1,
                Producer = "Head",
                Model = "WORLDCUP REBELS E-SPEED SKI",
                Price = 760.00M,
                Description = "The Worldcup Rebels e-Speed features the same sidecut and EMC technology as its big brother, the e-Speed Pro. Being more forgiving, it's the perfect ski for all-day carving.",
                ImageId = 1,
                CreationTime = DateTime.Now,
                CommentsEnabled = true
            };
            var product2 = new Product()
            {
                Id = 2,
                CreatorUserId = 3,
                CategoryId = 1,
                Producer = "Head",
                Model = "DOWNFORCE MIPS RACE SKI HELMET",
                Price = 650.00M,
                Description = "An aerodynamic racing helmet with MIPS designed for competitive racing. The modular system of the DOWNFORCE makes it suitable for all alpine race disciplines.",
                ImageId = 2,
                CreationTime = DateTime.Now,
                CommentsEnabled = true
            };
            var product3 = new Product()
            {
                Id = 3,
                CreatorUserId = 3,
                CategoryId = 3,
                Producer = "Head",
                Model = "RAPTOR WCR 120 RACE BOOT\"",
                Price = 800.00M,
                Description = "Thanks to an innovative use of new thermoplastic, the Raptor WCR 120 has a new level of absorption capabilities combined with high performance and a customizable fit.",
                ImageId = 3,
                CreationTime = DateTime.Now,
                CommentsEnabled = true
            };
            var product4 = new Product()
            {
                Id = 4,
                CreatorUserId = 3,
                CategoryId = 2,
                Producer = "Head",
                Model = "REBELS SUN JACKET MEN\" red/black",
                Price = 650.00M,
                Description = "A moto-inspired look comes with warmth and comfort in the REBELS SUN JACKET MEN, which mixes an edgy aesthetic with state-of-the-art PrimaLoft® insulation.",
                ImageId = 4,
                CreationTime = DateTime.Now,
                CommentsEnabled = true
            };
            var product5 = new Product()
            {
                Id = 5,
                CreatorUserId = 3,
                CategoryId = 2,
                Producer = "LG",
                Model = "INFINITY JACKET WOMEN\"pink/white",
                Price = 450.00M,
                Description = "The color-block design enhances the modern, athletic style of the INFINITY JACKET WOMEN, which is padded with state-of-the-art PrimaLoft® insulation.",
                ImageId = 5,
                CreationTime = DateTime.Now,
                CommentsEnabled = true
            };

            builder.Entity<UserRole>().HasData(adminRole, moderRole, simpleRole);
            builder.Entity<Image>().HasData(worldCupSki, raceSkiHelmet, raptorWcr120SkiBoot, rebelsSunJacketMen, infinityJacketWomen);
            builder.Entity<Category>().HasData(ski, equipment, boots);
            builder.Entity<User>().HasData(user1, user2, user3);
            builder.Entity<Product>().HasData(product1, product2, product3, product4, product5);

        }
    }
}
