//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace Shell.Models.Repository
//{
//    public class OrganisationService : IOrganisationService
//    {
//        private readonly IRepository<Organisation> _repository;

//        public OrganisationService(IRepository<Organisation> repository)
//        {
//            if (repository == null)
//                throw new ArgumentNullException("repo");

//            _repository = repository;
//        }

//        public int Create(Organisation organisation)
//        {
//            organisation.DateCreated = DateTime.Now;
//            _repository.Insert(organisation);
//            return organisation.Id;
//        }

//        public IEnumerable<Organisation> GetLatestOrganisations()
//        {
//            //Todo make return latest
//            return _repository.Get(o => o.Id != 0).OrderByDescending(d => d.DateCreated).Take(10);
//        }
//    }
//}