using System.ComponentModel.DataAnnotations;

namespace BirthdayGreetings.Doors.Repositories.Entity.Entities
{
    class BirthdayMessageEntity
    {
        [Key]
        private int Id { get; set; }

        [Required]
        private string Firstname { get; set; }

        [Required]
        private string Lastname { get; set; }
    }
}
