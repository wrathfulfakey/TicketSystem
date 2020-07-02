namespace TicketSystem.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using TicketSystem.Models.Users;
    using TicketSystem.Services.Data.Interfaces;

    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public IActionResult Dashboard(string username)
        {
            var viewModel = this.usersService.GetByUsername<UserDashboardViewModel>(username);
            
            if (viewModel == null)
            {
                return this.NotFound();
            }

            if (this.User.Identity.Name != viewModel.UserName)
            {
                viewModel.UserName = this.User.Identity.Name;

                return this.Unauthorized();
            }

            return this.View(viewModel);
        }
    }
}
