namespace TicketSystem.Models.Users
{
    using System;
    using System.Collections.Generic;

    using TicketSystem.Data.Models;
    using TicketSystem.Services.Mapping;

    public class UserDashboardViewModel : IMapFrom<ApplicationUser>
    {
        public string UserName { get; set; }

        public string PhoneNumber { get; set; }

        public int Credits { get; set; }

        public DateTime CreatedOn { get; set; }

        public IEnumerable<UserDashboardTransactionViewModel> Transactions { get; set; }
    }
}
