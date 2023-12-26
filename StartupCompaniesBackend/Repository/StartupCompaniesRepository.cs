using Microsoft.EntityFrameworkCore;
using StartupCompanyDomain.Entities;
using StartupCompanyDomain.Interfaces;
using StartupCompanyInfrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartupCompanyInfrastructure.Repository
{
    public class StartupCompaniesRepository : IStartupRepository
    {
        private readonly List<StartupCompany> _startups = new List<StartupCompany>();

        private readonly ApplicationDbContext _dbContext;

        public StartupCompaniesRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddStartupCompaniesAsync(StartupCompany entity)
        {
            _dbContext.StartupCompanies.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.StartupCompanyId;
        }

        public async Task UpdateAsync(StartupCompany entity)
        {
            _dbContext.StartupCompanies.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public void DeleteStartup(StartupCompany entity)
        {
            if (entity != null)
            {
                _dbContext.StartupCompanies.Remove(entity);
                _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<StartupCompany>> GetAllStartupCompaniesAsync()
        {
            var result = await _dbContext.StartupCompanies.ToListAsync();
            return result;
        }

        public async Task<StartupCompany> GetStartupCompanyByidAsync(int startupCompanyId)
        {
            var result = await _dbContext.StartupCompanies.FirstOrDefaultAsync(s => s.StartupCompanyId == startupCompanyId);
            return result;
        }
    }
}
