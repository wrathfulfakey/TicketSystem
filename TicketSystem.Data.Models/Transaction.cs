namespace TicketSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using TicketSystem.Data.Common.Models;

    public class Transaction : BaseDeletableModel<int>
    {
        public string SenderUserId { get; set; }

        public virtual ApplicationUser SenderUser { get; set; }

        public string ReceiverUserId { get; set; }

        public virtual ApplicationUser ReceiverUser { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string Comment { get; set; }

    }
}
