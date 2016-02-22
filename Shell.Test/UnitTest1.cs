//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Shell.Models.Repository;
//using Shell.DAL;
//using Shell.Models;

//namespace Shell.Test
//{
//    [TestClass]
//    public class UnitTest1
//    {
//        IOrganisationService _service;
//        [TestMethod]
//        public void CreateOrganisationReturnsValidId(IOrganisationService service)
//        {
//            _service = service;

//            Organisation o = new Organisation
//            {
//                Name = "TestOrg",
//            };
//            _service.Create(o);

//            Assert.AreNotEqual(0, o.Id);
//        }
//    }
//}
