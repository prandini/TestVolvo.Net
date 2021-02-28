using App.Volvo.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Volvo.Site.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly INotifier _notifier;

        public BaseController(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected bool OperacaoValida()
        {
            return !_notifier.HasNotification();
        }
    }
}
