namespace Domain
{
    public class User
    {
        public string Name {  get; set; }
        public string Email { get; set; }
        public DateTime BirthDay { get; set; }
        public int SettingId { get; set; }
        public Genders Gender { get; set; }

        public enum Genders { Other, Male, Female,}

    }
}
