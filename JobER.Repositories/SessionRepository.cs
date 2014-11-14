using JobER.Domain;
using JobER.Domain.Interfaces.Repositories;
using JobER.Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Home.Shared;
using MongoDB.Driver.Builders;
using MongoDB.Driver;

namespace JobER.Repositories {
    public class SessionRepository : ISessionRepository {
        private MongoContext _mongoContext;

        public SessionRepository(MongoContext mongoContext) {
            _mongoContext = mongoContext.ScreamIfNull("mongoContext");
        }

        public JobErSession Fetch(string token) {
            return _mongoContext.Sessions.FindOne(Query.EQ("_id", token));
        }

        public void Save(JobErSession session) {
            _mongoContext.Sessions.Save(session, WriteConcern.Unacknowledged);
        }

        public void Delete(string token) {
            _mongoContext.Sessions.Remove(
                Query.EQ("_id", token),
                WriteConcern.Unacknowledged
            );
        }

        public void UpdateLastAccess(string token) {
            _mongoContext.Sessions.Update(
                Query.EQ("_id", token),
                Update.Combine(
                    Update.Set("LastAccess", DateTime.UtcNow)
                ),
                WriteConcern.Unacknowledged);
        }
    }
}
