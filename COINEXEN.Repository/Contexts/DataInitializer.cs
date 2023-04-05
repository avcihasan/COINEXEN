using COINEXEN.Core.Entities;
using COINEXEN.Core.Entities.Identity;
using COINEXEN.Core.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace COINEXEN.Repository.Contexts
{
    public static class DataInitializer
    {
        //public static void SeedDatas(this ModelBuilder modelBuilder)
        //{
        //    string description = "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium??";
        //    int stock = 10000000;
        //    string photo = "photo.jpg";

        //    modelBuilder.Entity<Category>().HasData(
        //         new() { Id = 1, Name = "Sanat", Description = description },
        //        new() { Id = 2, Name = "Spor", Description = description }
        //        );


        //    modelBuilder.Entity<Coin>().HasData(
        //         new { Id =1, Name = "Acoin", Photo = photo, Description = description, Stock = stock, Price = 1.2, KısaKod = "A", CategoryId = 1, OldPrice = 0.0, },
        //        new { Id = 2, Name = "Bcoin", Photo = photo, Description = description, Stock = stock, Price = 1.9, KısaKod = "B", CategoryId = 1, OldPrice = 0.0 },
        //        new { Id = 3, Name = "Ccoin", Photo = photo, Description = description, Stock = stock, Price = 2.4, KısaKod = "C", CategoryId = 2, OldPrice = 0.0 }
        //        );
        //}

        //public static void SeedRoles(this ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<AppRole>().HasData(
        //        new AppRole() { Id = 1, Name = "admin" },
        //        new AppRole() { Id = 2, Name = "user" }
        //        ); ;
        //}
        //public static void SeedUsers(this ModelBuilder modelBuilder)
        //{
        //    AppUser hasanavci = new() { Id = 1, Name = "Hasan", Surname = "Avcı", UserName = "hasanavci", Email = "hsnavci7@gmail.com", PhoneNumber = "5380614193", City = City.İstanbul, Birthday = "11/07/1999", Gender = Gender.Erkek };


        //    AppUser hasanavci1 = new() { Id = 2, Name = "Hasan1", Surname = "Avcı", UserName = "hasanavci1", Email = "hsnavci7@gmail.com", PhoneNumber = "5380614193", City = City.İstanbul, Birthday = "11/07/1999", Gender = Gender.Erkek };


        //    PasswordHasher<AppUser> ph = new PasswordHasher<AppUser>();
        //    hasanavci.PasswordHash = ph.HashPassword(hasanavci, "12345");
        //    hasanavci1.PasswordHash = ph.HashPassword(hasanavci1, "12345");

        //    modelBuilder.Entity<AppUser>().HasData(hasanavci, hasanavci1);


        //}
    }
}
