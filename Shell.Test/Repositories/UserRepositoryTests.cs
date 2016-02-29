using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shell.DAL;
using Shell.Identity;
using Shell.Models;
using Shell.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shell.Test.Repositories
{
    [TestClass]
    public class UserRepositoryTests
    {
        public IUserRepository _userRepo;
        public IBusinessRepository _orgRepo;
        CustomUserStore userStore;

        List<Business> businessList;
        List<User> userList;

        public UserRepositoryTests()
        {
            _userRepo = new UserRepository(new SqlConnectionFactory(ConfigurationManager.ConnectionStrings["Default"].ConnectionString));
            _orgRepo = new BusinessRepository(new SqlConnectionFactory(ConfigurationManager.ConnectionStrings["Default"].ConnectionString));
            userStore = new CustomUserStore();
        }

        [TestMethod]
        public async Task UserCanGetAllBusinesses()
        {
            await SetUpTests();

            var user = await userStore.FindByNameAsync(userList[1].EmailAddress);
            businessList.ForEach(bus => _orgRepo.AddUserToBusiness(user.Id, bus.Id, Role.Standard));
            var businesses = _userRepo.GetBusinesses(user.Id);

            Assert.AreEqual(businessList[0].Name, businesses[0].Name);
            Assert.AreEqual(businessList[0].Description, businesses[0].Description);
            Assert.AreEqual(businessList[0].Email, businesses[0].Email);
            Assert.AreEqual(businessList[0].Phone, businesses[0].Phone);

            Assert.AreEqual(businessList[1].Name, businesses[1].Name);
            Assert.AreEqual(businessList[1].Description, businesses[1].Description);
            Assert.AreEqual(businessList[1].Email, businesses[1].Email);
            Assert.AreEqual(businessList[1].Phone, businesses[1].Phone);

            Assert.AreEqual(businessList[2].Name, businesses[2].Name);
            Assert.AreEqual(businessList[2].Description, businesses[2].Description);
            Assert.AreEqual(businessList[2].Email, businesses[2].Email);
            Assert.AreEqual(businessList[2].Phone, businesses[2].Phone);

            await TearDownTests();
        }

        private async Task SetUpTests()
        {
            userList = new List<User>
            {
                new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Super",
                    LastName = "Man",
                    EmailAddress = "super@test.com",
                    UserName = "super@test.com"
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Spider",
                    LastName = "Dude",
                    EmailAddress = "spider@test.com",
                    UserName = "spider@test.com"
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Green",
                    LastName = "Lantern",
                    EmailAddress = "green@test.com",
                    UserName = "green@test.com"
                },
            };
            foreach (var user in userList)
            {
                await userStore.CreateAsync(user);
            }
            var adminUser = await userStore.FindByNameAsync(userList[0].EmailAddress);

            businessList = new List<Business>
            {
                new Business
                {
                    Name = "Random busines busines",
                    Description = "Description of business",
                    Email = "first@business.com",
                    Phone = "1234567",
                    Users = new List<User> { adminUser }
                },
                new Business
                {
                    Name = "Second busines",
                    Description = "Description of business",
                    Email = "second@business.com",
                    Phone = "123456",
                    Users = new List<User> { adminUser }
                },
                new Business
                {
                    Name = "Third busines",
                    Description = "Description of business",
                    Email = "third@business.com",
                    Phone = "123456",
                    Users = new List<User> { adminUser }
                }
            };
            businessList.ForEach(bus => _orgRepo.Insert(bus));
        }

        private async Task TearDownTests()
        {
            userList.ForEach(async user => await userStore.DeleteAsync(user));
            businessList.ForEach(bus => _orgRepo.Delete(bus.Id));
            userList = null;
            businessList = null;
        }

    }
}
