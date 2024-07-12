using Caserita_Domain.Entities;
using Caserita_Domain.Interfaces;

namespace Caserita_Business.Services
{
    public class SettingService : ISettingService
    {
        private readonly ISettingRepo _settingRepo;

        public SettingService(ISettingRepo settingRepo)
        {
            _settingRepo = settingRepo;
        }

        public async Task<Setting> CreateSetting(Setting setting)
        {
            return await _settingRepo.CreateSetting(setting);
        }

        public async Task<Setting?> GetSettingById(Guid id)
        {
            return await _settingRepo.GetSettingById(id);
        }

        public async Task<IEnumerable<Setting>> GetAllSettings()
        {
            return await _settingRepo.GetAllSettings();
        }

        public async Task<Setting?> UpdateSetting(Setting setting)
        {
            return await _settingRepo.UpdateSetting(setting);
        }

        public async Task<bool> DeleteSetting(Guid id)
        {
            return await _settingRepo.DeleteSetting(id);
        }
    }
}
