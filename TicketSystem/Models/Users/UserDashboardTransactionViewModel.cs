namespace TicketSystem.Models.Users
{
    using System;
    using TicketSystem.Data.Models;
    using TicketSystem.Services.Mapping;

    public class UserDashboardTransactionViewModel : IMapFrom<Transaction>
    {
        public string SenderUserUserName { get; set; }

        public string ReceiverUserUserName { get; set; }

        public string Comment { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
