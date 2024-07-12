using Caserita_Domain.Entities;
using Caserita_Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Caserita_Data.Repos
{
    public class SettingRepo : ISettingRepo
    {
        private readonly CaseritaDbContext _dbContext;

        public SettingRepo(CaseritaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Setting> CreateSetting(Setting setting)
        {
            _dbContext.Settings.Add(setting);
            await _dbContext.SaveChangesAsync();
            return setting;
        }

        public async Task<Setting?> GetSettingById(Guid id)
        {
            return await _dbContext.Settings.FindAsync(id);
        }

        public async Task<IEnumerable<Setting>> GetAllSettings()
        {
            return await _dbContext.Settings.ToListAsync();
        }

        public async Task<Setting?> UpdateSetting(Setting setting)
        {
            var settingToUpdate = await _dbContext.Settings.FindAsync(setting.Id);

            if (settingToUpdate == null) return null;

            _dbContext.Entry(settingToUpdate).CurrentValues.SetValues(setting);
            await _dbContext.SaveChangesAsync();

            return setting;
        }

        public async Task<bool> DeleteSetting(Guid id)
        {
            var setting = await _dbContext.Settings.FindAsync(id);
            if (setting == null)
            {
                return false;
            }

            _dbContext.Settings.Remove(setting);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
