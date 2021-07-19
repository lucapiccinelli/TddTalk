using System;
using BirthdayGreetings.Domain.Model;

namespace BirthdayGreetings
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Greetings.SendEmails(
                @"Resources\employees.txt", 
                EmailAddress.Of("foobar@foobar.com"), 
                new Credentials("foo", "bar"), 
                DateTime.Now);
        }
    }
}
