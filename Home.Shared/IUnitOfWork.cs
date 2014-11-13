using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Home.Shared {
    public interface IUnitOfWork : IDisposable {
        void Commit();
        void RollBack();
    }

    [Serializable]
    public class UnitOfWorkValidationException : Exception {

        public List<ValidationResult> ValidationResults { get; set; }

        public UnitOfWorkValidationException(IEnumerable<ValidationResult> validationResults) : base(validationResults.GetMessages()) {
            ValidationResults = validationResults.ToList();
            validationResults.ForEach(x => Debug.WriteLine(x.ErrorMessage));
        }
    }

    internal static class ValidationResultHelpers {

        internal static string GetMessage(this ValidationResult result) {
            return result == null ? string.Empty : (result.ErrorMessage + " - " +
                string.Join(", ", result.MemberNames ?? Enumerable.Empty<string>())
            ).Trim(' ', '-');
        }

        internal static string GetMessages(this IEnumerable<ValidationResult> results) {
            return results == null ? string.Empty :
                string.Join(";" + Environment.NewLine, results.Select(x => x.GetMessage()));
        }
    }
}
