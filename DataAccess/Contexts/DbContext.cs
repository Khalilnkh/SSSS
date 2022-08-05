using Core.Entities;
using Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contexts
{
    static class DbContext
    {
        static DbContext()
        {
            Owners = new List<Owner>();
            DrugStores = new List<DrugStore>();
            DrugGists = new List<DrugGist>();
            Drugs = new List<Drug>();
            Admins = new List<Admin>();


            string password1 = "Xeyrulla555";
            var hashedPassword1 = PasswordHasher.Encrypt(password1);
            Admin admin1 = new Admin("admin", hashedPassword1);
            Admins.Add(admin1);

            string password2 = "Xeyrulla555";
            var hashedPassword2 = PasswordHasher.Encrypt(password2);
            Admin admin2 = new Admin("admin1", hashedPassword2);
            Admins.Add(admin2);
        }
        public static List<Owner> Owners { get; set; }
        public static List<DrugStore> DrugStores { get; set; }
        public static List<DrugGist> DrugGists { get; set; }
        public static List<Drug> Drugs { get; set; }
        public static List<Admin> Admins { get; set; }


    }
}
