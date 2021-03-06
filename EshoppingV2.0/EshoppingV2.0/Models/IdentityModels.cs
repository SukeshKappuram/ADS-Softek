﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace EshoppingV2._0.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationRole : IdentityRole { 
        
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<EshoppingV2._0.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<EshoppingV2._0.Models.Seller> ApplicationUsers { get; set; }

        public System.Data.Entity.DbSet<EshoppingV2._0.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<EshoppingV2._0.Models.ProductDetails> ProductDetails { get; set; }

        public System.Data.Entity.DbSet<EshoppingV2._0.Models.Cart> Carts { get; set; }

        public System.Data.Entity.DbSet<EshoppingV2._0.Models.CartItem> CartItems { get; set; }

        public System.Data.Entity.DbSet<EshoppingV2._0.Models.ShippingAddress> ShippingAddresses { get; set; }

        public System.Data.Entity.DbSet<EshoppingV2._0.Models.SalesOrder> SalesOrders { get; set; }
        public System.Data.Entity.DbSet<EshoppingV2._0.Models.OrderDetails> OrderDetails { get; set; }

        public System.Data.Entity.DbSet<EshoppingV2._0.Models.SalesTransaction> SalesTransactions { get; set; }
        public System.Data.Entity.DbSet<EshoppingV2._0.Models.SpecialOffer> SpecialOffers { get; set; }

        
    }
}