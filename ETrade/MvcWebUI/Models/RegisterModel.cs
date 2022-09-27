using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcWebUI.Models
{
    public class RegisterModel
    {
        [Required]
        [DisplayName("Ad:")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Soyad:")]
        public string SurName { get; set; }

        [Required]
        [DisplayName("Kullanıcı Adı:")]
        public string UserName { get; set; }

        [Required]
        [DisplayName("E-mail:")]
        [EmailAddress(ErrorMessage ="Lütfen doğru bir e-mail adresi giriniz.")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Şifre:")]
        public string Password { get; set; }

        [Required]
        [DisplayName("Şifre Tekrarı:")]
        [Compare("Password",ErrorMessage ="Şifreler aynı değil.")]
        public string RePassword { get; set; }
    }
}