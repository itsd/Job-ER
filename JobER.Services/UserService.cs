using JobER.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Home.Shared;
using JobER.Domain.Interfaces.Repositories;
using JobER.Domain;

namespace JobER.Services {
    public class UserService : IUserService {

        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) {
            _userRepository = userRepository.ScreamIfNull("userRepository");
        }

        public void Login(string username, string password) {

        }

        public void Add(User user) {
            _userRepository.Add(user);
        }

        public User Fetch(int id) {
            return _userRepository.Fetch(id);
        }
    }
}
