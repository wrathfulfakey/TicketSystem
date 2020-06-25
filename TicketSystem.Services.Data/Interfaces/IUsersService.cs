namespace TicketSystem.Services.Data.Interfaces
{
    using System.Collections.Generic;

    public interface IUsersService
    {
        T GetByUsername<T>(string username);

        ICollection<T> GetAll<T>();
    }
}
