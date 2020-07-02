namespace TicketSystem.Areas.Administration.ViewModels
{
    using System.Collections.Generic;

    public class AdminDashboardViewModel
    {
        public IEnumerable<AdminUsersViewModel> Users { get; set; }
    }
}
