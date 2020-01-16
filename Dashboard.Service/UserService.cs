using Dashboard.IService;
using Dashboard.Persistence;
using Dashboard.Persistence.Models;
using Dashboard.Persistence.ValueObjects;
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

        public IEnumerable<UserVO> GetUsers(string username)
        {
            return _dashboardContext.Users
                .Where(x => username == null || x.Name.Contains(username))
                .Select(x => new UserVO()
                {
                    Email = x.Email,
                    KeyID = x.KeyID,
                    MobileNumber = x.MobileNumber,
                    Name = x.Name,
                    RoleId = x.RoleId,
                    RoleName = x.Role != null ? x.Role.Name : "",
                    StatusId = x.StatusId,
                    StatusName = x.Status != null ? x.Status.Name : ""
                }).ToList();
        }

        public void DeleteUser(int userId)
        {
            var user = _dashboardContext.Users.Single(x => x.KeyID == userId);
            _dashboardContext.Users.Remove(user);
            _dashboardContext.SaveChanges();
        }

        public void UpsertUser(User user)
        {
            if (user == null)
                return;

            User dbUser;
            if (user.KeyID == 0)
            {
                dbUser = new User();
            }
            else
            {
                dbUser = _dashboardContext.Users.Single(x => x.KeyID == user.KeyID);
            }
            MapUser(dbUser, user);
            if (user.KeyID == 0)
            {
                _dashboardContext.Users.Add(dbUser);
            }
            _dashboardContext.SaveChanges();
        }

        private void MapUser(User dbUser, User user)
        {
            dbUser.Name = user.Name;
            dbUser.MobileNumber = user.MobileNumber;
            dbUser.Email = user.Email;
            dbUser.RoleId = user.RoleId;
            dbUser.StatusId = user.StatusId;
        }
    }
}
