using Lista_Price.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Lista_Price.Data.Repository
{
    public class UserRepository
    {
        private readonly AplicationContext _context;
        public UserRepository(AplicationContext context) 
            {
                _context = context;
            }

        public User? Authenticate(string email, string password)
        {
            User? userToAuthenticate = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            return userToAuthenticate;
        }

    }
}
