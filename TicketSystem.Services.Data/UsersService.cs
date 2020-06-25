namespace TicketSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using TicketSystem.Data.Common.Repositories;
    using TicketSystem.Data.Models;
    using TicketSystem.Services.Data.Interfaces;
    using TicketSystem.Services.Mapping;

    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public UsersService(IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public ICollection<T> GetAll<T>()
        {
            IQueryable<ApplicationUser> query = this.usersRepository
                  .AllAsNoTrackingWithDeleted()
                  .Where(x => x.CreatedOn >= DateTime.UtcNow.AddDays(-30))
                  .OrderByDescending(x => x.CreatedOn);

            return query.To<T>().ToList();
        }

        public T GetByUsername<T>(string username)
        {
            var user = this.usersRepository.All()
                   .Where(x => x.UserName == username)
                   .To<T>()
                   .FirstOrDefault();

            return user;
        }
    }
}
