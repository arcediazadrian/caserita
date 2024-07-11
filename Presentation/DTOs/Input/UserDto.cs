namespace Caserita_Presentation.DTOs.Input
{
    public class UserDto
    {
        public Guid? Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? Age { get; set; }
        public IEnumerable<Guid>? SettingIds { get; set; }
    }
}
