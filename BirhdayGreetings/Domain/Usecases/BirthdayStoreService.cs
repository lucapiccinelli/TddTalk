using System;
using System.Collections.Generic;
using BirthdayGreetings.Domain.Doors;
using BirthdayGreetings.Domain.Model;
using BirthdayGreetings.Doors.Repositories;
using BirthdayGreetings.Doors.Repositories.Csv;
using BirthdayGreetings.Doors.Repositories.SqlLite;

namespace BirthdayGreetings.Domain.Usecases
{
    public class BirthdayStoreService
    {
        private readonly IRepository<Employee> _employeesRepository;
        private readonly IRepository<BirthdayMessage> _messagesRepository;

        public BirthdayStoreService(IRepository<Employee> employeesRepository) : this(employeesRepository, new InMemoryBirthdayMessagesRepository())
        {
        }

        public BirthdayStoreService(IRepository<Employee> employeesRepository, IRepository<BirthdayMessage> messagesRepository)
        {
            _employeesRepository = employeesRepository;
            _messagesRepository = messagesRepository;
        }

        public List<BirthdayMessage> CreateMessages(DateTime today)
        {
            List<Employee> employees = _employeesRepository.ReadAll();
            return Birthdays.Of(employees, today);
        }

        public void SaveMessages(DateTime today)
        {
            CreateMessages(today)
                .ForEach(_messagesRepository.New);
        }

        public List<BirthdayMessage> FetchSavedMessages()
        {
            return _messagesRepository.ReadAll();
        }
    }
}