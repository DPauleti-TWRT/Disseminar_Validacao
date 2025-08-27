using Disseminar_Validacao.Models.Notification;
using FluentValidation;
using FluentValidation.Results;

namespace Disseminar_Validacao.Services
{
    public abstract class BaseService
    {
        private readonly INotificator notificator;

        protected BaseService(INotificator notificator)
        {
           this.notificator = notificator;
        }

        protected void Notify(FluentValidation.Results.ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notify(error.ErrorMessage);
            }
        }
        public void Notify(string message)
        {
            notificator.Handle(new Notification(message));
        }
        protected bool ExecuteValidation<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : class
        {
            var validator = validation.Validate(entity);
            if (validator.IsValid) return true;
            Notify(validator);
            return false;
        }

    }
}
