using COINEXEN.Core.Entities;
using COINEXEN.Core.Entities.Identity;
using COINEXEN.Core.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace COINEXEN.Repository.Contexts
{
    public static class DataInitializer
    {
        public static void SeedDatas(this ModelBuilder modelBuilder)
        {
            string description = "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium??";
            int stock = 10000000;
            string photo = "photo.jpg";

            modelBuilder.Entity<Category>().HasData(
                 new() { Id = 1, Name = "Sanat", Description = description },
                new() { Id = 2, Name = "Spor", Description = description },
                new() { Id = 3, Name = "Teknoloji", Description = description },
                new() { Id = 4, Name = "Bilim", Description = description },
                new() { Id = 5, Name = "Ticaret", Description = description },
                new() { Id = 6, Name = "Müzik", Description = description },
                new() { Id = 7, Name = "Seyehat", Description = description }
                );


            modelBuilder.Entity<Coin>().HasData(
                 new { Id = 1, Name = "Acoin", Photo = photo, Description = description, Stock = stock, Price = 1.2, KısaKod = "A", CategoryId = 1, OldPrice = 0.0, },

                new { Id = 2, Name = "Bcoin", Photo = photo, Description = description, Stock = stock, Price = 1.9, KısaKod = "B", CategoryId = 2, OldPrice = 0.0 },
                new { Id = 3, Name = "Ccoin", Photo = photo, Description = description, Stock = stock, Price = 2.4, KısaKod = "C", CategoryId = 3, OldPrice = 0.0 },
                new { Id = 4, Name = "Dcoin", Photo = photo, Description = description, Stock = stock, Price = 5.4, KısaKod = "D", CategoryId = 1, OldPrice = 0.0 },
                new { Id = 5, Name = "Ecoin", Photo = photo, Description = description, Stock = stock, Price = 15.4, KısaKod = "E", CategoryId = 5, OldPrice = 0.0 },
                new { Id = 6, Name = "Fcoin", Photo = photo, Description = description, Stock = stock, Price = 6.4, KısaKod = "F", CategoryId = 6, OldPrice = 0.0 },
                new { Id = 7, Name = "Gcoin", Photo = photo, Description = description, Stock = stock, Price = 1.43, KısaKod = "G", CategoryId = 2, OldPrice = 0.0 },
                new { Id = 8, Name = "Hcoin", Photo = photo, Description = description, Stock = stock, Price = 1.55, KısaKod = "H", CategoryId = 1, OldPrice = 0.0 },
                new { Id = 9, Name = "Icoin", Photo = photo, Description = description, Stock = stock, Price = 1.98, KısaKod = "I", CategoryId = 6, OldPrice = 0.0 },
                new { Id = 10, Name = "Jcoin", Photo = photo, Description = description, Stock = stock, Price = 11.24, KısaKod = "J", CategoryId = 1, OldPrice = 0.0 },
                new { Id = 11, Name = "Kcoin", Photo = photo, Description = description, Stock = stock, Price = 1.24, KısaKod = "K", CategoryId = 2, OldPrice = 0.0 },
                new { Id = 12, Name = "Lcoin", Photo = photo, Description = description, Stock = stock, Price = 12.4, KısaKod = "L", CategoryId = 5, OldPrice = 0.0 },
                new { Id = 13, Name = "Mcoin", Photo = photo, Description = description, Stock = stock, Price = 31.4, KısaKod = "M", CategoryId = 5, OldPrice = 0.0 },
                new { Id = 14, Name = "Ncoin", Photo = photo, Description = description, Stock = stock, Price = 16.4, KısaKod = "N", CategoryId = 2, OldPrice = 0.0 },
                new { Id = 15, Name = "Ocoin", Photo = photo, Description = description, Stock = stock, Price = 1.94, KısaKod = "O", CategoryId = 3, OldPrice = 0.0 },
                new { Id = 16, Name = "Pcoin", Photo = photo, Description = description, Stock = stock, Price = 1.49, KısaKod = "P", CategoryId = 3, OldPrice = 0.0 },
                new { Id = 17, Name = "Rcoin", Photo = photo, Description = description, Stock = stock, Price = 1.4, KısaKod = "R", CategoryId = 4, OldPrice = 0.0 },
                new { Id = 18, Name = "Scoin", Photo = photo, Description = description, Stock = stock, Price = 31.4, KısaKod = "S", CategoryId = 3, OldPrice = 0.0 },
                new { Id = 19, Name = "Tcoin", Photo = photo, Description = description, Stock = stock, Price = 13.43, KısaKod = "T", CategoryId = 1, OldPrice = 0.0 },
                new { Id = 20, Name = "Ucoin", Photo = photo, Description = description, Stock = stock, Price = 15.4, KısaKod = "U", CategoryId = 1, OldPrice = 0.0 },
                new { Id = 21, Name = "Vcoin", Photo = photo, Description = description, Stock = stock, Price = 1.44, KısaKod = "V", CategoryId = 6, OldPrice = 0.0 },
                new { Id = 22, Name = "Ycoin", Photo = photo, Description = description, Stock = stock, Price = 1.4, KısaKod = "Y", CategoryId = 5, OldPrice = 0.0 },
                new { Id = 23, Name = "Zcoin", Photo = photo, Description = description, Stock = stock, Price = 1.4, KısaKod = "Z", CategoryId = 4, OldPrice = 0.0 }
                );
        }

        public static void SeedRoles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppRole>().HasData(
                new AppRole() { Id = 1, Name = "admin" },
                new AppRole() { Id = 2, Name = "user" }
                );
        }
        public static void SeedUsers(this ModelBuilder modelBuilder)
        {
            AppUser hasanavci = new() { Id = 1, Name = "Hasan", Surname = "Avcı", UserName = "hasanavci", Email = "hsnavci7@gmail.com", PhoneNumber = "5380614193", City = City.İstanbul, Birthday = "11/07/1999", Gender = Gender.Erkek };


            AppUser hasanavci1 = new() { Id = 2, Name = "Hasan1", Surname = "Avcı", UserName = "hasanavci1", Email = "hsnavci7@gmail.com", PhoneNumber = "5380614193", City = City.İstanbul, Birthday = "11/07/1999", Gender = Gender.Erkek };


            PasswordHasher<AppUser> ph = new PasswordHasher<AppUser>();
            hasanavci.PasswordHash = ph.HashPassword(hasanavci, "12345");
            hasanavci1.PasswordHash = ph.HashPassword(hasanavci1, "12345");

            modelBuilder.Entity<AppUser>().HasData(hasanavci, hasanavci1);


        }
    }
}
