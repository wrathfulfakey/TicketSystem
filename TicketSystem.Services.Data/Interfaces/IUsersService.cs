namespace TicketSystem.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUsersService
    {
        T GetByUsername<T>(string username);

        ICollection<T> GetAll<T>();

        Task SendGreeting(string senderUsername, string receiverUsername, string content);
    }
}
