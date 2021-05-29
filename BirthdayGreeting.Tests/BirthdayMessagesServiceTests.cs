using System.Text;
using BirthdayGreetings.Domain.Doors;
using BirthdayGreetings.Domain.Model;
using BirthdayGreetings.Domain.Usecases;
using BirthdayGreetings.Doors.Email.Gmail;
using BirthdayGreetings.Doors.Repositories.Csv;
using BirthdayGreetings.Tests.Helpers;
using Moq;
using Xunit;

namespace BirthdayGreetings.Tests
{
    public class BirthdayMessagesServiceTests
    {
        [Fact]
        public void GIVEN_AListOfEmployees_ItSends_ABirthdayGreetingsMessage_OnlyToThose_ThatHaveTheiBirthday()
        {
            Mock<IEmailSender> senderSpy = new Mock<IEmailSender>();

            BirthdayMessagesService service = new BirthdayMessagesService(
                new CsvRepository(@"Resources\employees.txt"), 
                new GmailBirthdaySender(EmailAddress.Of("foobar@foobar.com"), new Credentials("foo", "bar"), senderSpy.Object));

            service.SendGreetings(TestEmployees.Mary.DateOfBirth);

            senderSpy.Verify(sender => sender.Send(It.IsAny<EmailServiceConfiguration>(), It.IsAny<string>(), TestEmployees.Mary.EmailAddress.Value, "Happy birthday dear Mary Ann"));
        }
    }
}
