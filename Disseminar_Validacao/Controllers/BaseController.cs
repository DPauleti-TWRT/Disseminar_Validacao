using Disseminar_Validacao.Models.Notification;
using Microsoft.AspNetCore.Mvc;
namespace Disseminar_Validacao.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly INotificator _notificator;

        protected BaseController(INotificator notificator)
        {
            _notificator = notificator;
        }

        protected bool IsValidOperation()
        {
            if(!_notificator.HasNotification())
            {
                return true;
            }

            var notifications = _notificator.GetNotifications();
            notifications.ForEach(n => ViewData.ModelState.AddModelError(string.Empty, n.Message));

            return false;
        }
    }
}
