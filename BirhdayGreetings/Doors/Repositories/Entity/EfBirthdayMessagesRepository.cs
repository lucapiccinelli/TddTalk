using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BirthdayGreetings.Domain.Doors;
using BirthdayGreetings.Domain.Model;
using BirthdayGreetings.Doors.Repositories.Entity.Entities;

namespace BirthdayGreetings.Doors.Repositories.Entity
{
    public class EfBirthdayMessagesRepository : IRepository<BirthdayMessage>
    {
        private readonly BirthdayDbContext _dbContext = new BirthdayDbContext();
        
        public List<BirthdayMessage> ReadAll()
        {
            return _dbContext.BirthdayMessages
                .Select(entity => new BirthdayMessage(new Name(entity.Firstname, entity.Lastname)))
                .ToList();
        }

        public void New(BirthdayMessage message)
        {
            _dbContext.BirthdayMessages.Add(new BirthdayMessageEntity()
            {
                Firstname = message.Name.Firstname,
                Lastname = message.Name.Lastname
            });
            _dbContext.SaveChanges();
        }
    }
}
