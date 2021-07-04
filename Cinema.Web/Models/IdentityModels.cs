﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Cinema.Web.Models
{
    public class ApplicationUser : IdentityUser
    {
     
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
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
        


        public System.Data.Entity.DbSet<Cinema.Web.Models.MovieModel> MovieModels { get; set; }

        public System.Data.Entity.DbSet<Cinema.Web.Models.TicketModel> TicketModels { get; set; }

        public System.Data.Entity.DbSet<Cinema.Web.Models.GenreModel> GenreModels { get; set; }

        public System.Data.Entity.DbSet<Cinema.Web.Models.ShoppingCart> ShoppingCarts { get; set; }

        public System.Data.Entity.DbSet<Cinema.Web.Models.UserRoles> UserRoles { get; set; }

    }
}