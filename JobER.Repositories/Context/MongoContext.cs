using JobER.Domain;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JobER.Repositories.Context {
    public class MongoContext {

        private class ConnectionInfo {
            internal string Name { get; set; }
            internal string Server { get; set; }
            internal string Database { get; set; }
        }
        private static object _initLock = new object();
        private static bool _indexesInitialised = false;
        private static IEnumerable<ConnectionInfo> _connections;

        static MongoContext() {
            if (_connections == null) {
                lock (_initLock) {
                    _connections = (
                        from setting in ConfigurationManager.ConnectionStrings.Cast<ConnectionStringSettings>()

                        let connStr = setting.ConnectionString
                        where connStr.StartsWith("mongodb://", StringComparison.InvariantCultureIgnoreCase)

                        let url = MongoUrl.Create(connStr)
                        let server = "mongodb://" + url.Server.Host + ":" + url.Server.Port

                        select new ConnectionInfo {
                            Name = setting.Name,
                            Server = server,
                            Database = url.DatabaseName,
                        }
                    );
                }
            }

            var mappings = (
                from type in typeof(MongoContext).Assembly.GetTypes()
                let mapInfo = type.GetMethod("Map", BindingFlags.Static | BindingFlags.NonPublic)
                where mapInfo != null
                select mapInfo
            );

            foreach (var mapping in mappings) {
                mapping.Invoke(null, new object[0]);
            }
        }

        public MongoContext() {
            if (!_indexesInitialised) {
                _indexesInitialised = true;
                Sessions.CreateIndex(IndexKeys.Ascending("UserID"));
            }
        }

        private MongoDatabase GetDatabase(string name = null) {
            var info = _connections.First(x => name == null || x.Name == name);
            return new MongoClient(info.Server).GetServer().GetDatabase(info.Database);
        }

        #region Collections

        public MongoCollection<JobErSession> Sessions {
            get { return GetDatabase().GetCollection<JobErSession>("Sessions"); }
        }

        #endregion
    }
}
