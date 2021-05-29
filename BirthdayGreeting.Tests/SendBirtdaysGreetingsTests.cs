using System.Collections.Generic;
using System.Text;
using BirthdayGreetings.Domain.Doors;
using BirthdayGreetings.Domain.Model;
using BirthdayGreetings.Doors.Email;
using BirthdayGreetings.Doors.Email.Gmail;
using Moq;
using Xunit;

namespace BirthdayGreetings.Tests
{
    public class SendBirtdaysGreetingsTests
    {
        [Fact]
        public void VerifyGmailServiceCreation()
        {
            string fromEmailAddress = "foo.bar@foobar.com";
            var emailToGreet = "luca.picci@gmail.com";
            BirthdayMessage message = new BirthdayMessage(new Name("Foo", "Bar"));
            BirthdayEmail email = new BirthdayEmail(EmailAddress.Of(emailToGreet), message);
            var credentials = new Credentials("foo", "bar");

            Mock<IEmailSender> serviceSpy = new Mock<IEmailSender>();

            new GmailBirthdaySender(EmailAddress.Of(fromEmailAddress), credentials, serviceSpy.Object).Send(email);

            var expectedConfiguration = new EmailServiceConfiguration
            {
                Ssl = true,
                Smtp = "smtp.gmail.com",
                Port = 587,
                Credentials = credentials
            };

            serviceSpy.Verify(sender => sender.Send(expectedConfiguration, fromEmailAddress, emailToGreet, "Happy birthday dear Foo Bar") );
        }
    }
}
