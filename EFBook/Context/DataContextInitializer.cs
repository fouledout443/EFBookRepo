using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Security;


    public class DataContextInitializer:DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            WebSecurity.Register("Demo", "123456", "demo@demo.com", true, "Demo", "Demo");
            Roles.CreateRole("Admin");
            Roles.AddUserToRole("Demo", "Admin");

        }
        //{
        //    WebSecurity.InitializeDatabaseConnection("DefaultConnection",
        //          "UserProfile", "UserId", "UserName", autoCreateTables: true);
        //    //var roles = Roles.Provider;
        //    //var membership = Membership.Provider;

        //    if (!Roles.RoleExists("Admin"))
        //    {
        //        Roles.CreateRole("Admin");
        //    }
        //    if (Membership.GetUser("test", false) == null)
        //    {
        //        //Membership.CreateUserAndAccount("test", "test");
        //        WebSecurity.CreateUserAndAccount("test", "test");
        //    }
        //    if (!Roles.GetRolesForUser("test").Contains("Admin"))
        //    {
        //        Roles.AddUsersToRoles(new[] { "test" }, new[] { "admin" });
        //    }
        //}
    }