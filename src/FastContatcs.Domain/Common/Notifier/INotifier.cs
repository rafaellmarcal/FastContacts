using System.Collections.Generic;

namespace FastContacts.Domain.Common.Notifier
{
    public interface INotifier
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notificacao);
    }
}
