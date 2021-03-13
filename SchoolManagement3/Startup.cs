using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using SchoolManagement3.Models;
using System;

[assembly: OwinStartupAttribute(typeof(SchoolManagement3.Startup))]
namespace SchoolManagement3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        public void createRolesandUsers()
        {
            // Este codigo creara los roles de usuarios en la db.

           var context = new ApplicationDbContext();

           var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
           var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            /* Crea un usuario y lo a;ade a la tabla intermedia
            var user = new ApplicationUser
            {
                UserName = "admin",
                Email = "adming@dfz.com",
                BirthDate = DateTime.Now
            };

            var password = "password";

            var usr = userManager.Create(user, password);

            if (usr.Succeeded)
            {
                var result = userManager.AddToRole(user.Id, "Admin");
            }
            */

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

            }

            if (!roleManager.RoleExists("Teacher")){
                var role = new IdentityRole();
                role.Name = "Teacher";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Supervisor"))
            {
                var role = new IdentityRole();
                role.Name = "Supervisor";
                roleManager.Create(role);
            }
        }
    }
}
