using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TekupMiniProject.Models.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private IList<User> Users;

        public UserRepository()
        {
            this.Users = new List<User>()
            {
                new User
                {
                    Id =1,
                    Email = "test@test.com",
                    Password = "123456",
                    Role = "Admin"
                },
                 new User
                 {
                    Id =2,
                    Email = "test1@test.com",
                    Password = "123456",
                    Role = "Admin"
                 },
                  new User
                  {
                    Id =2,
                    Email = "test2@test.com",
                    Password = "123456",
                    Role = "Admin"
                  },

            };
        }

        public void Inscription(User element)
        {
            Users.Add(element);
        }

        public User Authentication(User element)
        {
            return Users.Single(b => b.Password == element.Password && b.Email == element.Email);
        }
    }
}
