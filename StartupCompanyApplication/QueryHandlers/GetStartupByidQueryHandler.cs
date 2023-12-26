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
    class GetStartupByidQueryHandler :IRequestHandler<GetStartupByidQuery, StartupCompany>
    {
        private readonly IStartupRepository _startupRepository;

        public GetStartupByidQueryHandler(IStartupRepository startupRepository)
        {
            _startupRepository = startupRepository;
        }

        public async Task<StartupCompany> Handle(GetStartupByidQuery request, CancellationToken cancellationToken)
        {
            return await _startupRepository.GetStartupCompanyByidAsync(request.StartupCompanyId);
        }
    }
}
