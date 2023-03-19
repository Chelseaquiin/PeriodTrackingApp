using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeriodTracker.BLL.Model;


namespace PeriodTracker.BLL.Interfaces
{
    public interface IUserService
    {
        //public Task<Response<UserVM>> GetUser(int Id);
        public Task<Response<UserVM>> LogInAsync(string email, string password);
        public string LogOut();
        public Task<Response<UserVM>> SignUpAsync(UserVM user);
    }
}
