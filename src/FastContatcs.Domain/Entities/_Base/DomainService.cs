using FastContacts.Domain.Common.Notifier;
using FluentValidation.Results;

namespace FastContacts.Domain.Entities._Base
{
    public abstract class DomainService
    {
        protected readonly INotifier _notifier;

        protected DomainService(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected void NotifyDomainValidations(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
                _notifier.Handle(new Notification(error.ErrorMessage));
        }
    }
}
