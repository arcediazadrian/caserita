﻿using System.ComponentModel.DataAnnotations;

namespace Caserita_Domain.Entities
{
    public class Setting
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserSetting> UserSettings { get; set; }
    }
}
