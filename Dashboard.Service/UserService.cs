using Dashboard.IService;
using Dashboard.Persistence;
using Dashboard.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dashboard.Service
{
    public class UserService : IUserService
    {
        private readonly DashboardContext _dashboardContext;
        public UserService(DashboardContext dashboardContext)
        {
            this._dashboardContext = dashboardContext;
        }

        public IEnumerable<User> GetUsers()
        {
            return _dashboardContext.Users.ToList();
        }
    }
}
