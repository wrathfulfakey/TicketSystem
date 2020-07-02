namespace TicketSystem.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using TicketSystem.Models;
    using TicketSystem.Models.Index;
    using TicketSystem.Services.Data.Interfaces;

    public class HomeController : Controller
    {
        private readonly IUsersService usersService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(
            IUsersService usersService,
            ILogger<HomeController> logger)
        {
            this.usersService = usersService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel
            {
                Users = this.usersService.GetAll<IndexUserViewModel>(),
            };

            if (viewModel == null)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult SendGreeting(string senderUsername, string receiverUsername, string phoneNumber)
        {
            var viewModel = new GreetingCreateInputModel
            {
                SenderUser = senderUsername,
                ReceiverUser = receiverUsername,
                PhoneNumber = phoneNumber,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SendGreeting(GreetingCreateInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.usersService.SendGreeting(input.SenderUser, input.ReceiverUser, input.Comment);

            return this.RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
