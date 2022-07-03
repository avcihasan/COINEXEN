using COINEXEN.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace COINEXEN.Models
{
    public class RegisterModel
    {
        [Required]
        [DisplayName("Adınız")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Soyadınız")]
        public string Surname { get; set; }

        [Required]
        [DisplayName("E-posta")]
        [EmailAddress(ErrorMessage ="Düzgün Eposta gir")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Kullanıcı Adınız")]
        public string UserName { get; set; }
        [Required]
        [DisplayName("Doğum Tarihiniz")]
        public string Birthday { get; set; }
        [Required]
        [DisplayName("Cinsiyetiniz")]
        public Gender Sex { get; set; }
        [Required]
        [DisplayName("Yaşadığınız Şehir")]
        public string City { get; set; }
        [Required]
        [DisplayName("Telefon Numaranız")]
        public string PhoneNumber { get; set; }
        [Required]
        [DisplayName("Şifre")]
        public string Password { get; set; }
        [Required]
        [DisplayName("Şifre Tekrar")]
        [Compare("Password",ErrorMessage ="Şifreleriniz Eşleşmiyor")]
        public string RePassword { get; set; }
    }
}