using Microsoft.AspNetCore.Mvc;
using Disseminar_Validacao.Models;
using Disseminar_Validacao.Services;
using Disseminar_Validacao.Models.Notification;

namespace Disseminar_Validacao.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, IUserService userService, INotificator notificator) : base(notificator)
        {
            _logger = logger;
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User model)
        {
            
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            _userService.AddUser(model);

            return View(model);
        }
}
