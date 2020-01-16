using Dashboard.IService;
using Dashboard.Persistence;
using Dashboard.Persistence.Models;
using Dashboard.Persistence.ValueObjects;
using Dashboard.Service.Test.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dashboard.Service.Test
{
    [TestClass]
    public class UserServiceTest
    {
        private IUserService _userService;
        private Mock<DashboardContext> _dashboardContext;


        [TestInitialize]
        public void Setup()
        {
            _dashboardContext = new Mock<DashboardContext>();
            _dashboardContext.Setup(x => x.SaveChanges()).Verifiable();
            CreateMockData(_dashboardContext);           

            _userService = new UserService(_dashboardContext.Object);
        }

        [TestMethod]
        public void GetUsers_WhenUsernameProvidedIsNull_ShouldFetchAllUsers()
        {
            var users = _userService.GetUsers(null);
            Assert.IsNotNull(users);
            Assert.IsTrue(users.Count() != 0);
        }

        [TestMethod]
        public void GetUsers_WhenUsernameProvidedIsNotNull_ShouldFilterUsers()
        {
            var allUsers = _userService.GetUsers(null);
            var usernameQuery = "User2";
            var filteredUsers = _userService.GetUsers(usernameQuery);
            Assert.IsNotNull(filteredUsers);
            Assert.IsTrue(filteredUsers.Count() != 0);
            Assert.IsTrue(filteredUsers.Count() != allUsers.Count());
            Assert.IsTrue(filteredUsers.All(x => x.Name.Contains(usernameQuery)));
        }

        [TestMethod]
        public void UpsertUser_WhenUserAlreadyExists_ShouldUpdateUser()
        {
            var usernameQuery = "User2";
            var filteredUsers = _userService.GetUsers(usernameQuery).ToList();
            var updatedName = "User2ModifiedName";
            filteredUsers[0].Name = updatedName;
            filteredUsers[0].Email = "User2@xyz.com";
            _userService.UpsertUser(filteredUsers[0]);

            var updatedUsers = _userService.GetUsers(updatedName).ToList();
            _dashboardContext.Verify(x => x.SaveChanges(), Times.Once); 
            Assert.IsNotNull(updatedUsers);
            Assert.IsTrue(updatedUsers.Count() == 1);
            Assert.IsTrue(updatedUsers[0].KeyID == filteredUsers[0].KeyID);
        }

        [TestMethod]
        public void UpsertUser_WhenUserDoesNotExists_ShouldAddUser()
        {
            var user = new UserVO()
            {
                KeyID = 0,
                Email = "abc@abc.com",
                MobileNumber = "9898989898",
                Name = "TestUser3",
                RoleId = 1,
                StatusId = 1
            };
            _userService.UpsertUser(user);

            var updatedUsers = _userService.GetUsers("TestUser3").ToList();
            _dashboardContext.Verify(x => x.SaveChanges(), Times.Once);
            Assert.IsNotNull(updatedUsers);
        }

        [TestMethod]
        public void DeleteUser_WhenKeyIDIsProvided_ShouldDeleteUser()
        {
            _userService.DeleteUser(1);

            var updatedUsers = _userService.GetUsers(null).ToList();
            _dashboardContext.Verify(x => x.SaveChanges(), Times.Once);
            Assert.IsNotNull(updatedUsers);
            //Assert.IsTrue(updatedUsers.Where(x => x.KeyID == 1).Count() == 0);
        }

        #region helpers
        private void CreateMockData(Mock<DashboardContext> dashboardContext)
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    KeyID = 1,
                    Name = "Admin",
                }
            };
            _dashboardContext.Setup(x => x.Roles).Returns(DbSetHelper.CreateDbSetMock(roles).Object);

            var statuses = new List<Status>()
            {
                new Status()
                {
                    KeyID = 1,
                    Name = "Active"
                }
            };
            _dashboardContext.Setup(x => x.Statuses).Returns(DbSetHelper.CreateDbSetMock(statuses).Object);


            var users = new List<User>()
            {
                new User()
                {
                    KeyID = 1,
                    Email = "abc@abc.com",
                    MobileNumber = "9898989898",
                    Name = "TestUser1",
                    RoleId = 1,
                    StatusId = 1
                },
                new User()
                {
                    KeyID = 2,
                    Email = "abc@abc.com",
                    MobileNumber = "9898989898",
                    Name = "TestUser2",
                    RoleId = 1,
                    StatusId = 1
                }
            };

            _dashboardContext.Setup(x => x.Users).Returns(DbSetHelper.CreateDbSetMock(users).Object);
        }

        #endregion helpers
    }
}
