using System.Collections.Generic;

namespace Cookies_Authentication.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public IEnumerable<Users> GetUsers()
        {
            return new List<Users>() { new Users { Id = 101, UserName = "gyan", Name = "Anet", Email = "gyan@test.com", Password = "test123" } };
        }
    }
}
