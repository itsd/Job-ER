using JobER.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Home.Shared;
using JobER.Domain.Interfaces.Repositories;
using JobER.Domain;
using JobER.Domain.Exceptions;
using System.Threading;

namespace JobER.Services {
    public class UserService : IUserService {

        private IUserRepository _userRepository;
        private ISessionRepository _sessionRepository;

        public UserService(IUserRepository userRepository, ISessionRepository sessionRepository) {
            _userRepository = userRepository.ScreamIfNull("userRepository");
            _sessionRepository = sessionRepository.ScreamIfNull("sessionRepository");
        }

        #region PrivateMethods

        private bool EmailIsValid(string email) {
            return email.IsValidEmailAddress();
        }

        private bool PasswordIsValid(string password) {
            return password.Length >= 6;
        }

        private string EncryptPassword(string password) {
            return password.ToMD5Hash();
        }

        #endregion

        public JobErSession Login(string username, string password) {
            username = username.ToLower();
            password = EncryptPassword(password);

            var user = _userRepository.Fetch(username, password);
            if (user == null) throw new LoginFailedException();

            var session = (JobErSession)user;
            _sessionRepository.Save(session);
            Thread.CurrentPrincipal = session;
            return session;
        }

        public void Save(User user) {
            _userRepository.Save(user);
        }

        public User Fetch(int id) {
            return _userRepository.Fetch(id);
        }

        public User Register(string username, string password, string firstname, string lastname, string email) {
            username = username.ToLower();
            email = email.Trim().ToLower();

            if (!EmailIsValid(email)) throw new InvalidEmailException();

            if (!PasswordIsValid(password)) throw new InvalidPasswordException();

            if (!_userRepository.EmailIsUnique(0, email)) throw new DuplicateEmailException();

            if (!_userRepository.UsernameIsUnique(0, username)) throw new DuplicateUsernameException();

            var user = new User {
                Username = username,
                Password = EncryptPassword(password),
                Email = email,
                Firstname = firstname,
                Lastname = lastname
            };

            _userRepository.Save(user);

            return user;
        }

    }
}
