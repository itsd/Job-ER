using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Home.Shared;
using System.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;

namespace Home.Entity {
    public class HomeEntityContext : DbContext, IUnitOfWork, IServiceProvider {
        public HomeEntityContext() : base() { }
        public HomeEntityContext(DbConnection connection) : base(connection, true) { }
        public HomeEntityContext(string connectionString) : base(connectionString) { }

        public override int SaveChanges() {
            lock (new object()) {
                bool validateOnSave = this.Configuration.ValidateOnSaveEnabled;
                this.Configuration.ValidateOnSaveEnabled = false;

                if (validateOnSave) {
                    //validate entities with our own validation context
                    var validationResults = (
                        from entry in ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified)

                        let ctx = new ValidationContext(entry.Entity, this, null)
                        from validationResult in GetValidationResults(entry, ctx)

                        select validationResult
                    );

                    if (validationResults.Count() > 0) {
                        //throw exception if errors exist
                        throw new UnitOfWorkValidationException(validationResults);
                    }
                }

                int results = base.SaveChanges();
                this.Configuration.ValidateOnSaveEnabled = validateOnSave;

                return results;
            }
        }
        
        private IEnumerable<ValidationResult> GetValidationResults(DbEntityEntry entry, ValidationContext validationContext) {
            List<ValidationResult> results = new List<ValidationResult>();
            Validator.TryValidateObject(entry.Entity, validationContext, results, true);
            return results;
        }

        #region IUnitOfWork

        public void Commit() {
            this.SaveChanges();
        }
        
        public void RollBack() {
            //TODO: Implement RollBack Function
            throw new NotImplementedException();
        }

        #endregion

        #region IServiceProvider

        public object GetService(Type serviceType) {
            throw new NotImplementedException();
        }

        #endregion
    }
}
