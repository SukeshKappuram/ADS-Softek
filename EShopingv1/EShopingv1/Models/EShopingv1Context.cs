using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EShopingv1.Models
{
    public class EShopingv1Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public EShopingv1Context() : base("name=EShopingv1Context")
        {
        }

        public System.Data.Entity.DbSet<EShopingv1.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<EShopingv1.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<EShopingv1.Models.ProductDetails> ProductDetails { get; set; }

        public System.Data.Entity.DbSet<EShopingv1.Models.SpecialOffer> SpecialOffers { get; set; }

        public System.Data.Entity.DbSet<EShopingv1.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<EShopingv1.Models.Role> Rolls { get; set; }

        public System.Data.Entity.DbSet<EShopingv1.Models.ShippingAddress> ShippingAddresses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductDetails>().Property(t => t.SerialNumber)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EShopingv1Context>());
        }

        public System.Data.Entity.DbSet<EShopingv1.Models.Cart> Carts { get; set; }

    }
}
