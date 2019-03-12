using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EPayments.Models
{
    public class AuthContext : IdentityDbContext<ApplicationUser>
    {
        public AuthContext() : base("IdentityDb") { }

        public static AuthContext Create()
        {
            return new AuthContext();
        }
    }

    public class ApplicationUser : IdentityUser
    {
        //[DisplayName("Логин")]
        //[Required(ErrorMessage = "Не указан логин")]
        //public string Id { get; set; }

        //[DisplayName("Роль")]
        //public int Role { get; set; }

        //[DisplayName("Пароль")]
        //[Required(ErrorMessage = "Не указан пароль")]
        //public string Password { get; set; }
    }

    public class LoginModel
    {
        [DisplayName("Логин")]
        [Required(ErrorMessage = "Не указан логин")]
        public string Email { get; set; }

        [DisplayName("Пароль")]
        [Required(ErrorMessage = "Не указан пароль")]  
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}