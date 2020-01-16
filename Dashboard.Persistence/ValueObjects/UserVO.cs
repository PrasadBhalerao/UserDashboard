using Dashboard.Persistence.Models;

namespace Dashboard.Persistence.ValueObjects
{
    public class UserVO : User
    {
        public string StatusName { get; set; }
        public string RoleName { get; set; }
    }
}
