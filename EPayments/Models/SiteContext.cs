namespace EPayments.Models
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;

    public class SiteContext : DbContext
    {       
        public SiteContext()
            : base("name=ModelEPayments")
        {
        }
       
         public virtual DbSet<Site> Sites { get; set; }
         //public virtual DbSet<User> Users { get; set; }
    }

    public class Site
    {
        public Guid Id { get; set; }

        [DisplayName("Сайт")]
        public string Name { get; set; }

        [DisplayName("URL")]
        [Required(ErrorMessage = "Не указан адрес")]
        [Url(ErrorMessage = "Некорректный URL")]
        public string URL { get; set; }

        [DisplayName("Состояние")]
        public int Status { get; set; }

        [DisplayName("Блокирован")]
        public bool IsBlocked { get; set; }
    }   
}