using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shell.Repository;
using Shell.Models;
using System.Collections.Generic;
using System;
using Shell.DAL;
using System.Configuration;
using Moq;
using Shell.Identity;
using System.Threading.Tasks;

namespace Shell.Test.Repositories
{
    [TestClass]
    public class BusinessRepositoryTests
    {
        public IBusinessRepository _orgRepo;
        CustomUserStore userStore;

        List<Business> businessList;
        List<User> userList;

        public BusinessRepositoryTests()
        {
            _orgRepo = new BusinessRepository(new SqlConnectionFactory(ConfigurationManager.ConnectionStrings["Default"].ConnectionString));
            userStore = new CustomUserStore();
        }

        [TestMethod]
        public async Task CreatedOrganisationHasCorrectDetails()
        {
            await SetUpTests();

            var insertedBusiness = _orgRepo.GetById(businessList[0].Id);

            Assert.IsNotNull(insertedBusiness);
            Assert.IsNotNull(insertedBusiness.Id);
            Assert.AreEqual(insertedBusiness.Name, businessList[0].Name);
            Assert.AreEqual(insertedBusiness.Description, businessList[0].Description);
            Assert.AreEqual(insertedBusiness.Email, businessList[0].Email);
            Assert.AreEqual(insertedBusiness.Phone, businessList[0].Phone);

            await TearDownTests();
        }

        [TestMethod]
        public async Task CreatedOrganisationWithCorrectAdminUser()
        {
            await SetUpTests();

            var users = _orgRepo.GetUsers(businessList[0].Id);

            Assert.AreEqual(userList[0].FirstName, users[0].FirstName);
            Assert.AreEqual(userList[0].LastName, users[0].LastName);
            Assert.AreEqual(userList[0].EmailAddress, users[0].EmailAddress);

            await TearDownTests();
        }

        [TestMethod]
        public async Task UsersAreAddedToOrganisationCorrectly()
        {
            await SetUpTests();

            _orgRepo.AddUserToBusiness(userList[1].Id, businessList[0].Id, Models.Role.Standard);
            _orgRepo.AddUserToBusiness(userList[2].Id, businessList[0].Id, Models.Role.Standard);

            var insertedUsers = _orgRepo.GetUsers(businessList[0].Id);

            Assert.AreEqual(3, insertedUsers.Count);
            Assert.AreEqual(userList[0].FirstName, insertedUsers[0].FirstName);
            Assert.AreEqual(userList[0].LastName, insertedUsers[0].LastName);
            Assert.AreEqual(userList[0].EmailAddress, insertedUsers[0].EmailAddress);
            Assert.AreEqual(userList[1].FirstName, insertedUsers[1].FirstName);
            Assert.AreEqual(userList[1].LastName, insertedUsers[1].LastName);
            Assert.AreEqual(userList[1].EmailAddress, insertedUsers[1].EmailAddress);
            Assert.AreEqual(userList[2].FirstName, insertedUsers[2].FirstName);
            Assert.AreEqual(userList[2].LastName, insertedUsers[2].LastName);
            Assert.AreEqual(userList[2].EmailAddress, insertedUsers[2].EmailAddress);

            await TearDownTests();
        }

        [TestMethod]
        public void CanDeleteBusiness()
        {
            var adminUser = new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Ryan",
                LastName = "Reynolds",
                EmailAddress = "ryan@test.com",
                UserName = "ryan@test.com"
            };
            var business = new Business
            {
                Name = "Green lanterns busines",
                Description = "Description of business",
                Email = "first@business.com",
                Phone = "123456",
                Users = new List<User> { adminUser }
            };

            var businessId = _orgRepo.Insert(business);

            Assert.IsNotNull(businessId);

            _orgRepo.Delete(businessId);

            Assert.IsNull(_orgRepo.GetById(businessId));
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
