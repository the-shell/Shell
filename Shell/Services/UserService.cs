using Microsoft.AspNet.Identity;
using Shell.Models;
using Shell.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shell.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IUserStore<User> _userStore;

        public UserService(IUserRepository userRepository, IUserStore<User> userStore)
        {
            _userRepository = userRepository;
            _userStore = userStore;
        }

        ///<Summary>
        ///Gets a list of all a users businesses given the users Id
        ///<Summary>
        public List<Business> GetBusinesses(Guid userId)
        {
            return _userRepository.GetBusinesses(userId);
        }
    }
}