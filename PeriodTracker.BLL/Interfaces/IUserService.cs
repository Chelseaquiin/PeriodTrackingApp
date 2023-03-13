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
        public Task<bool> LogInAsync(string email, string password);
        public string LogOut();
        public Task<UserVM> SignUpAsync(UserVM user);
    }
}
