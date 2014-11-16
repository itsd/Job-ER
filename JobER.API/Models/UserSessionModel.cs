using JobER.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobER.API.Models {
    public class UserSessionModel {
        public int ID { get; set; }
        public string Token { get; set; }
        public string Username { get; set; }

        public static implicit operator UserSessionModel(JobErSession session) {
            return new UserSessionModel {
                ID = session.UserID,
                Username = session.Username,
                Token = session.Token
            };
        }
    }
}