using System.ComponentModel.DataAnnotations;

namespace Caserita_Domain.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public ICollection<UserSetting>? UserSettings { get; set; }
    }
}
