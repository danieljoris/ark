using Ark.Core.Data;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ark.Core.Messages
{
    public abstract class CommandHandler
    {
        protected ValidationResult ValidationResult;

        protected CommandHandler()
        {
            ValidationResult = new ValidationResult();
        }

        protected void AddError(string message)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, message));
        }

        protected void AddError(string property, string message)
        {
            ValidationResult.Errors.Add(new ValidationFailure(property, message));
        }

        protected void AddError(string property, string message, object attemptedValue)
        {
            ValidationResult.Errors.Add(new ValidationFailure(property, message, attemptedValue));
        }

        public async Task<ValidationResult> PersistData(IUnitOfWork uow)
        {
            if (!await uow.Commit()) AddError("Houve um erro ao persistir os dados.");

            return ValidationResult;
        }
    }
}
