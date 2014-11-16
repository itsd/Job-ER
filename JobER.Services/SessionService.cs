using JobER.Domain;
using JobER.Domain.Interfaces.Repositories;
using JobER.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Home.Shared;
using JobER.Domain.Exceptions;
using System.Threading;

namespace JobER.Services {
    public class SessionService : ISessionService {

        private ISessionRepository _sessionRepository;
        private IUserRepository _userRepository;

        public SessionService(ISessionRepository sessionRepository, IUserRepository userRepository) {
            _sessionRepository = sessionRepository.ScreamIfNull("sessionRepository");
            _userRepository = userRepository.ScreamIfNull("userRepository");
        }

        public JobErSession Login(string username, string password) {
            password = password.ToMD5Hash();
            var user = _userRepository.Fetch(username, password);
            if (user == null) throw new LoginFailedException();

            var session = (JobErSession)user;
            _sessionRepository.Save(session);
            Thread.CurrentPrincipal = session;
            return session;
        }

        public JobErSession ValidateToken(string token) {
            var session = _sessionRepository.Fetch(token);
            if (session == null) throw new InvalidSessionTokenException();

            _sessionRepository.UpdateLastAccess(token);
            Thread.CurrentPrincipal = session;
            return session;
        }

        public void Logout(string token) {
            _sessionRepository.Delete(token);
        }
    }
}