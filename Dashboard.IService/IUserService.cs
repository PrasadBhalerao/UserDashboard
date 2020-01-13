using Dashboard.Persistence.Models;
using System;
using System.Collections.Generic;

namespace Dashboard.IService
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();

    }
}
