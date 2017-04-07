using EshoppingV2._0.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EshoppingV2._0.Startup))]
namespace EshoppingV2._0
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesAndAdmin();
        }

        private void createRolesAndAdmin() {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var adminRole = new IdentityRole();
            adminRole.Name = "Admin";
            roleManager.Create(adminRole);

            var sellerRole = new IdentityRole();
            sellerRole.Name = "Seller";
            roleManager.Create(sellerRole);

            var role = new IdentityRole();
            role.Name = "Customer";
            roleManager.Create(role);

            // Creating Admin

            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var user = new ApplicationUser();
            user.UserName = "iamsukesh@gmail.com";
            user.Email = "iamsukesh@gmail.com";

            string userPWD = "S@A201704";

            var chkUser = UserManager.Create(user, userPWD);

            //Add default User to Role Admin    
            if (chkUser.Succeeded)
            {
                var result1 = UserManager.AddToRole(user.Id, "Admin");
            }    
        } 
    }
}
