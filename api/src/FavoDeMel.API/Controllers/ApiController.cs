using FavoDeMel.Domain.Notifications;
using FavoDeMel.Domain.UoW;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FavoDeMel.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ApiController : ControllerBase
    {
        private readonly DomainNotificationHandler _notifications;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="notifications"></param>
        /// <param name="unitOfWork"></param>
        protected ApiController(
            INotificationHandler<DomainNotification> notifications,
            IUnitOfWork unitOfWork)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 
        /// </summary>
        protected IEnumerable<DomainNotification> Notifications => _notifications.GetNotifications();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected bool IsValidOperation()
        {
            return (_notifications.HasNotifications() is not true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected new IActionResult Response(object result = null)
        {
            if (IsValidOperation())
            {
                return Ok(result);
            }

            var erros = _notifications.GetNotifications().Select(n => n);
            var returnErros = new List<Flunt.Notifications.Notification>();

            foreach (var item in erros)
            {
                returnErros.AddRange(item.Erros.ToList());
            }

            return BadRequest(returnErros);
        }
    }
}
