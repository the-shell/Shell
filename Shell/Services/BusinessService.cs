using Shell.Repository;
using Shell.Services;
using Shell.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shell.Models.Repository
{
    public class BusinessService : IBusinessService
    {
        private readonly IBusinessRepository _repository;

        public BusinessService(IBusinessRepository repository)
        {
            _repository = repository;
        }

        public int Create(Business model)
        {
            return _repository.Insert(model);
        }

        public Business GetById(int id)
        {
            var business = _repository.GetById(id);
            business.Users = _repository.GetUsers(id);
            return business;
        }

        public List<User> GetUsers(int id)
        {
            return _repository.GetUsers(id);
        }
    }
}