
using COINEXEN.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COINEXEN.Identity
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public Gender Sex { get; set; }
        public string Birthday { get; set; }
        public double Bakiye { get; set; }
        public double HesapDeger { get; set; }

       


    }
    public enum Gender
    {
        Erkek,
        Kadın
    }

}