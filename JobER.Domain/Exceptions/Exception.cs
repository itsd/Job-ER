using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobER.Domain.Exceptions {
    public class LoginFailedException : Exception { }
    public class InvalidSessionTokenException : Exception { }
    public class InvalidEmailException : Exception { }
    public class InvalidPasswordException : Exception { }
    public class DuplicateEmailException : Exception { }
    public class DuplicateUsernameException : Exception { }
}
