namespace TicketSystem.Areas.Administration.ViewModels
{
    using System.Collections.Generic;

    using TicketSystem.Data.Models;
    using TicketSystem.Services.Mapping;

    public class AdminUsersViewModel : IMapFrom<ApplicationUser>
    {
        public string UserName { get; set; }

        public string PhoneNumber { get; set; }

        public int Credits { get; set; }

        public IEnumerable<AdminTransactionViewModel> Transactions { get; set; }
    }
}
