using System;
using System.Collections.Generic;
using BirthdayGreetings.Domain.Doors;
using BirthdayGreetings.Domain.Model;

namespace BirthdayGreetings.Domain.Usecases
{
    public class BirthdayMessagesService
    {
        private readonly IRepository<Employee> _employeesRepository;
        private readonly IBirthdaySender _birthdaySender;

        public BirthdayMessagesService(IRepository<Employee> employeesRepository, IBirthdaySender birthdaySender)
        {
            _employeesRepository = employeesRepository;
            _birthdaySender = birthdaySender;
        }

        public void SendGreetings(in DateTime today)
        {
            List<Employee> employees = _employeesRepository.ReadAll();
            Birthdays.Of(employees, today, ToBirthdayEmailMessage)
                .ForEach(_birthdaySender.Send);
        }

        private static BirthdayEmail ToBirthdayEmailMessage(Employee employee) => new BirthdayEmail(employee.EmailAddress, new BirthdayMessage(employee.Name));
    }
}