using StartupCompanyDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyDomain.Interfaces
{
        public interface IStartupRepository
        {
            Task<int> AddStartupCompaniesAsync(StartupCompany entity);
            Task UpdateAsync(StartupCompany entity);
            void DeleteStartup(StartupCompany entity);
            Task<List<StartupCompany>> GetAllStartupCompaniesAsync();
            Task<StartupCompany> GetStartupCompanyByidAsync(int id);
    }
    
}
