namespace Caserita_Presentation.DTOs.Output
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public IEnumerable<SettingDto> Settings { get; set; } = [];
    }
}
