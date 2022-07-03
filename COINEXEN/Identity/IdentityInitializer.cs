using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace COINEXEN.Identity
{
    public class IdentityInitializer : DropCreateDatabaseIfModelChanges<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {

            if (!context.Roles.Any(i=> i.Name=="admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager =new RoleManager<IdentityRole>(store);

                var role = new ApplicationRole (){ Name = "admin", Description = "admin rolü" };
                manager.Create(role);
            }



            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);

                var role = new ApplicationRole() { Name = "user", Description = "user rolü" };
                manager.Create(role);
            }



            if (!context.Users.Any(i => i.UserName == "hasanavci"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                var user = new ApplicationUser() { Name = "Hasan", Surname = "Avcı", UserName = "hasanavci", Email = "hsnavci7@gmail.com", PhoneNumber = "5380614193", City = "istanbul", Birthday = "11/07/1999", Sex = Gender.Erkek, Bakiye =1000,HesapDeger=0 };
             
                manager.Create(user,"1234567");
                manager.AddToRole(user.Id, "admin");
                manager.AddToRole(user.Id, "user");
            }


            if (!context.Users.Any(i => i.UserName == "hasanavci1"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                var user = new ApplicationUser() { Name = "Hasan1", Surname = "Avcı", UserName = "hasanavci1", Email = "hsnavci7@gmail.com", PhoneNumber = "5380614193", City = "istanbul", Birthday = "11/07/1999", Sex = Gender.Erkek, Bakiye = 1000, HesapDeger = 0 };


                manager.Create(user, "1234567");
        ;
                manager.AddToRole(user.Id, "user");
            }

            base.Seed(context); 
        }
    }
}