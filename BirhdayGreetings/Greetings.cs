using System;
using BirthdayGreetings.Domain.Model;
using BirthdayGreetings.Domain.Usecases;
using BirthdayGreetings.Doors.Email.Gmail;
using BirthdayGreetings.Doors.Repositories.Csv;

namespace BirthdayGreetings
{
    internal static class Greetings
    {
        public static void SendEmails(string filename, EmailAddress @from, Credentials credentials, DateTime today)
        {
            BirthdayMessagesService service = new BirthdayMessagesService(
                new CsvRepository(filename),
                new GmailBirthdaySender(@from, credentials));

            service.SendGreetings(today);
        }
    }
}