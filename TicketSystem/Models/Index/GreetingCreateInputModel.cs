namespace TicketSystem.Models.Index
{
    using System.ComponentModel.DataAnnotations;

    using TicketSystem.Data.Models;
    using TicketSystem.Services.Mapping;

    public class GreetingCreateInputModel : IMapFrom<Transaction>
    {
        [Display(Name = "Sender Username")]
        public string SenderUser { get; set; }

        [Display(Name = "Receiver Username")]
        public string ReceiverUser { get; set; }

        [Display(Name = "Receiver Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Greeting content")]
        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string Comment { get; set; }
    }
}
