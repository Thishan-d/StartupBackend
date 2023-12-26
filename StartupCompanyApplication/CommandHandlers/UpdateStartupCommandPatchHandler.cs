using MediatR;
using StartupCompanyApplication.Commands;
using StartupCompanyDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StartupCompanyApplication.CommandHandlers
{
    public class UpdateStartupCommandPatchHandler : IRequestHandler<UpdateStartupCommandPatch>
    {
        private readonly IStartupRepository _startupCompanyRepository;

        public UpdateStartupCommandPatchHandler(IStartupRepository startupRepository)
        {
            _startupCompanyRepository = startupRepository;
        }

        public async Task<Unit> Handle(UpdateStartupCommandPatch request, CancellationToken cancellationToken)
        {
            var existingStartup = await _startupCompanyRepository.GetStartupCompanyByidAsync(request.StartupCompanyId);

            if (existingStartup != null)
            {
                if (request.BusinessDomain != null)
                    existingStartup.BusinessDomain = request.BusinessDomain;
                if (request.Description != null)
                    existingStartup.Description = request.Description;

                existingStartup.GrossSales = request.GrossSales ?? existingStartup.GrossSales;
                existingStartup.NetSales = request.NetSales ?? existingStartup.NetSales;
                existingStartup.EmployeeCount = request.EmployeeCount ?? existingStartup.EmployeeCount;

                if (request.Website != null)
                    existingStartup.Website = request.Website;
                if (request.BusinessLocation != null)
                    existingStartup.BusinessLocation = request.BusinessLocation;
                if (request.FounderName != null)
                    existingStartup.FounderName = request.FounderName;

                existingStartup.BusinessStartDate = request.BusinessStartDate ?? existingStartup.BusinessStartDate;

                await _startupCompanyRepository.UpdateAsync(existingStartup);
                return Unit.Value;
            }
            else
            {
                throw new Exception("Entity not found!");
            }

        }
    }

}
