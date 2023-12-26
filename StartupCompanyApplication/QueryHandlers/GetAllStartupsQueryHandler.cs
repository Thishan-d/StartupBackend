using MediatR;
using StartupCompanyApplication.Queries;
using StartupCompanyDomain.Entities;
using StartupCompanyDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StartupCompanyApplication.QueryHandlers
{
    public class GetAllStartupsQueryHandler : IRequestHandler<GetAllStartupsQuery, List<StartupCompany>>
    {
        private readonly IStartupRepository _startupRepository;

        public GetAllStartupsQueryHandler(IStartupRepository startupRepository)
        {
            _startupRepository = startupRepository;
        }

        public async Task<List<StartupCompany>> Handle(GetAllStartupsQuery request, CancellationToken cancellationToken)
        {
            return await _startupRepository.GetAllStartupCompaniesAsync();
        }
    }
}
