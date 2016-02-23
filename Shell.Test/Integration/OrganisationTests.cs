using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shell.Services;
using Shell.Models.Repository;
using Shell.Repository;
using Shell.Models;
using System.Collections.Generic;
using Shell.DAL;

namespace Shell.Test.Integration
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void OrganisationCreatedWithCorrectParams()
        {
            IOrganisationService service = GetOrganistionService();
            User testUser = new User
            {
                FirstName = "Ryan",
                LastName = "Reynolds",
                EmailAddress = "ryan@test.com",
                UserName = "ryan@test.com",
            };
            Organisation org = new Organisation
            {
                Name = "Test organisation",
                Users = new List<User> { testUser },
            };

            var orgId = service.Create(org);
            var insertedOrg = service.GetById(orgId);

            Assert.AreEqual(orgId, insertedOrg.Id);
            Assert.AreEqual(org.Name, insertedOrg.Name);
        }

        private IOrganisationService GetOrganistionService()
        {
            IOrganisationService service = new OrganisationService(new OrganisationRepository(new SqlConnectionFactory("Data Source = DESKTOP-CK761NH\\SQLEXPRESS; Initial Catalog = ShellDb; User ID = sa; Password = password; MultipleActiveResultSets = true")));
            return service;
        }
    }
}
