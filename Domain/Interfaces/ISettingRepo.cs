using Caserita_Domain.Entities;

namespace Caserita_Domain.Interfaces
{
    public interface ISettingRepo
    {
        Task<Setting> CreateSetting(Setting user);
        Task<Setting?> GetSettingById(Guid id);
        Task<IEnumerable<Setting>> GetAllSettings();
        Task<Setting?> UpdateSetting(Setting user);
        Task<bool> DeleteSetting(Guid id);
    }
}
