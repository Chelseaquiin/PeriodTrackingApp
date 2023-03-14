using Microsoft.EntityFrameworkCore;
using PeriodTracker.BLL.Interfaces;
using PeriodTracker.BLL.Model;
using PeriodTracker.DAL.Models;

namespace PeriodTracker.BLL.Implementation
{
    public class UserService : IUserService
    {

        private readonly PeriodTrackerDbContext _context;
        public UserService(PeriodTrackerDbContext context)
        {
            _context = context;
        }
        public async Task<Response<UserVM>> LogInAsync(string email, string password)
        {
            
            var user = await _context.Users.FirstOrDefaultAsync(e => e.Email.ToLower() == email.ToLower() && e.Password == password);
            if (user is not null)
            {
                return new Response<UserVM>
                {
                    Message = "LogIn successful",
                    IsSuccessful = true,
                    Result = new UserVM
                    {
                        Firstname = user.FirstName,
                        Lastname = user.LastName,
                        Email = email,
                        Password = password,
                        UserName = user.UserName,
                    }
                };
            }
            else
            {
                return new Response<UserVM>
                { 
                    Message = "Email or password incorrect",
                    IsSuccessful = false
                };
            }

        }

        public string LogOut()
        {
            throw new NotImplementedException();
        }

        public async Task<Response<UserVM>> SignUpAsync(UserVM user)
        {
            if (user is null)
            {
                return new Response<UserVM>
                {
                    Message = "Invalid User Input",
                    IsSuccessful = false,
                };
            }
            try
            {
                if (await _context.Users.AnyAsync(u => u.Email.ToLower() == user.Email.ToLower()))
                {
                    return new Response<UserVM>
                    {
                        Message = "User already exists",
                        IsSuccessful = false,
                    }; 
                }

                var newUser = new User
                {
                    FirstName = user.Firstname,
                    LastName = user.Lastname,
                    Email = user.Email,
                    UserName = user.UserName,
                    Password = user.Password,
                    DateCreated = DateTime.Now
                };

                await _context.Users.AddAsync(newUser);
                var saveResult = await _context.SaveChangesAsync();
                var result = new Response<UserVM>
                {
                    Message = "Successful",
                    IsSuccessful = true,
                    Result = user
                };
                return saveResult > 0 ? result : new Response<UserVM>
                {
                    Message = "There is an issue with your sign up",
                    IsSuccessful = false,
                    Result = user
                }; ;
            }
            catch (Exception e)
            {

               return new Response<UserVM>
                {
                    Message = e.Message,
                    IsSuccessful = false,
                    Result = user
                };
            }


        }
    }
}
