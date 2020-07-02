namespace TicketSystem.Areas.Administration.ViewModels
{
    using System;

    using TicketSystem.Data.Models;
    using TicketSystem.Services.Mapping;

    public class AdminTransactionViewModel : IMapFrom<Transaction>
    {
        public string SenderUserUserName { get; set; }

        public string ReceiverUserUserName { get; set; }

        public string Comment { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}