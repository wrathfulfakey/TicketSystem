using Microsoft.AspNetCore.Mvc;
using TicketSystem.Areas.Administration.ViewModels;
using TicketSystem.Services.Data.Interfaces;

namespace TicketSystem.Areas.Administration.Controllers
{
    public class DashboardController : AdministrationController
    {
        private readonly IUsersService usersService;

        public DashboardController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public IActionResult Dashboard()
        {
            var viewModel = new AdminDashboardViewModel
            {
                Users = this.usersService.GetAll<AdminUsersViewModel>(),
            };

            if (viewModel == null)
            {
                return this.View();
            }

            return this.View(viewModel);
        }
    }
}
