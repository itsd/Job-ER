using JobER.Domain;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobER.Repositories.Mappings {
    internal static class SessionMappings {
        internal static void Initialize() {
            BsonClassMap.RegisterClassMap<JobErSession>(cm => {
                cm.AutoMap();
                cm.SetIgnoreExtraElements(true);
                cm.SetIgnoreExtraElementsIsInherited(true);

                cm.SetIdMember(cm.MapProperty(x => x.Token));
                cm.IdMemberMap.SetIdGenerator(new StringObjectIdGenerator());
            });
        }
    }
}
