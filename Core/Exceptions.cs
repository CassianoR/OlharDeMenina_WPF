using System.Data.Entity.Validation;
using System.Linq;

namespace LojaOlharDeMenina_WPF.Core
{
    public class Exceptions
    {
        public Exceptions()
        {
        }

        public string concatenaExceptions(DbEntityValidationException ex)
        {
            var errorMessages = ex.EntityValidationErrors
                                    .SelectMany(x => x.ValidationErrors)
                                    .Select(x => x.ErrorMessage);
            var fullErrorMessage = string.Join("\n", errorMessages);
            var exceptionMessage = string.Concat(fullErrorMessage);
            return exceptionMessage;
        }
    }
}