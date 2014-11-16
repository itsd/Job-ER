using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobER.API.Models.User {
    public class UserModel {
        public string Username { get; set; }
        public string Fullname { get; set; }

        public static implicit operator UserModel(JobER.Domain.User user) {
            return new UserModel {
                Username = user.Username,
                Fullname = string.Format("{0} {1}", user.Firstname, user.Lastname)
            };
        }
    }
}