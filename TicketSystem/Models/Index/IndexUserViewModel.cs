namespace TicketSystem.Models.Index
{
    using TicketSystem.Data.Models;
    using TicketSystem.Services.Mapping;

    public class IndexUserViewModel : IMapFrom<ApplicationUser>
    {
        public string UserName { get; set; }

        public string PhoneNumber { get; set; }

        public int Credits { get; set; }
    }
}