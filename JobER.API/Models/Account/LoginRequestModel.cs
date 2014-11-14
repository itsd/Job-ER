using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobER.API.Models.Account {
    public class LoginRequestModel {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}