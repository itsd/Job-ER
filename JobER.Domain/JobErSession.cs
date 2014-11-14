using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JobER.Domain {
    [Serializable]
    public class JobErSession : IPrincipal {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
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
            get { throw new NotImplementedException(); }
        }

        public bool IsInRole(string role) {
            throw new NotImplementedException();
        }
    }

    [Serializable]
    public class JobErIdentity : IIdentity {

        public string AuthenticationType {
            get { throw new NotImplementedException(); }
        }

        public bool IsAuthenticated {
            get { throw new NotImplementedException(); }
        }

        public string Name {
            get { throw new NotImplementedException(); }
        }
    }
}
