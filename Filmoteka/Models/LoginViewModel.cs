using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;


namespace Filmoteka.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage ="Neplatná emailová adresa")]
        public string email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Heslo")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}