using PeriodTracker.BLL.Interfaces;
using PeriodTracker.BLL.Model;
using PeriodTracker.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodTracker.BLL.Implementation
{
    public class UserService : IUserService
    {
        
        private readonly PeriodTrackerDbContext _context;
        public async Task<bool> LogInAsync(string email, string password)
        {
            return  _context.Users.Any(e => e.Email.ToLower() == email.ToLower() && e.Password == password);
            
        }

        public string LogOut()
        {
            throw new NotImplementedException();
        }

        public async Task<UserVM?> SignUpAsync(UserVM user)
        {
            if(user == null)
            {
                return null;
            }
            var newUser = new User
            {
                FirstName = user.Firstname,
                LastName = user.Lastname,
                Email = user.Email,
                Password = user.Password,
                DateCreated = DateTime.Now
            };

            await _context.Users.AddAsync(newUser);
            var isSaved = await _context.SaveChangesAsync();
            return isSaved > 1 ? user : null;

        }
    }
}
