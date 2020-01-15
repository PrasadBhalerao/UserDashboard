using Dashboard.Persistence.Models;
using Dashboard.Persistence.ValueObjects;
using System;
using System.Collections.Generic;

namespace Dashboard.IService
{
    public interface IUserService
    {
        IEnumerable<UserVO> GetUsers(string username);

        void DeleteUser(int userId);

        void UpsertUser(User user);
    }
}
