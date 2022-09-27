using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcWebUI.Models
{
    public class LoginModel
    {

        [Required]
        [DisplayName("Kullanıcı Adı:")]
        public string UserName { get; set; }

        [Required]
        [DisplayName("Şifre:")]
        public string Password { get; set; }

        
        [DisplayName("Beni hatırla:")]
        public bool RememberMe { get; set; }

    }
}