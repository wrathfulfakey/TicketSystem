namespace TicketSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TicketSystem.Data.Common.Repositories;
    using TicketSystem.Data.Models;
    using TicketSystem.Services.Data.Interfaces;
    using TicketSystem.Services.Mapping;

    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly IDeletableEntityRepository<Transaction> transactionsRepository;

        public UsersService(
            IDeletableEntityRepository<ApplicationUser> usersRepository,
            IDeletableEntityRepository<Transaction> transactionsRepository)
        {
            this.usersRepository = usersRepository;
            this.transactionsRepository = transactionsRepository;
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

        public async Task SendGreeting(string senderUsername, string receiverUsername, string content)
        {
            var sender = this.usersRepository.All()
                .Where(x => x.UserName == senderUsername)
                .FirstOrDefault();

            var receiver = this.usersRepository.All()
                .Where(x => x.UserName == receiverUsername)
                .FirstOrDefault();

            if (sender == null ||
                receiver == null)
            {
                return;
            }

            var transaction = new Transaction
            {
                Comment = content,
                SenderUserId = sender.Id,
                ReceiverUserId = receiver.Id,
            };

            if (sender.Credits < 10)
            {
                return;
            }
            else
            {
                sender.Credits -= 10;
                receiver.Credits += 10;

                await transactionsRepository.AddAsync(transaction);
                await transactionsRepository.SaveChangesAsync();
                return;
            }
        }
    }
}
