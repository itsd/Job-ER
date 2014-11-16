using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JobER.Domain {
    [Serializable]
    public class JobErSession : IPrincipal {
        [Key]
        public string Token { get; set; }
        public int UserID { get; set; }
        public string Username { get; set; }
        public static JobErSession Current {
            get { return Thread.CurrentPrincipal as JobErSession; }
        }

        public static implicit operator JobErSession(User session) {
            return new JobErSession {
                UserID = session.ID,
                Username = session.Username,
                Token = string.Format("{0:N}{1:N}", Guid.NewGuid(), Guid.NewGuid())
            };
        }

        public IIdentity Identity {
            get { return _identity ?? (_identity = new JobErIdentity { IsAuthenticated = true, Name = Username }); }
        }private IIdentity _identity;

        public bool IsInRole(string role) {
            //TODO: Implement IsInRole Method
            throw new NotImplementedException();
        }
    }

    [Serializable]
    public class JobErIdentity : IIdentity {

        public string AuthenticationType {
            get { throw new NotImplementedException(); } //TODO: Implement AuthenticationType
        }

        public bool IsAuthenticated { get; internal set; }

        public string Name { get; internal set; }
    }
}
