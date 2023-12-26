using MediatR;
using StartupCompanyApplication.Commands;
using StartupCompanyDomain.Entities;
using StartupCompanyDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StartupCompanyApplication.CommandHandlers
{
    public class CreateStartupCommandHandler : IRequestHandler<CreateStartupCommand, int>
    {
        private readonly IStartupRepository _startupCompanyRepository;

        public CreateStartupCommandHandler(IStartupRepository startupRepository)
        {
            _startupCompanyRepository = startupRepository;
        }

        public async Task<int> Handle(CreateStartupCommand request, CancellationToken cancellationToken)
        {
            var newStartup = new StartupCompany
            {
                BusinessDomain = request.BusinessDomain,
                Description = request.Description,
                GrossSales = request.GrossSales,
                NetSales = request.NetSales,
                Website = request.Website,
                BusinessLocation = request.BusinessLocation,
                BusinessStartDate = request.BusinessStartDate,
                EmployeeCount = request.EmployeeCount,
                FounderName = request.FounderName
            };

            await _startupCompanyRepository.AddStartupCompaniesAsync(newStartup);
            return newStartup.StartupCompanyId;
        }
    }
}
