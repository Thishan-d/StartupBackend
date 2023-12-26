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
    public class DeleteStartupCommandHandler : IRequestHandler<DeleteStartupCommand>
    {
        private readonly IStartupRepository _startupCompanyRepository;
        public DeleteStartupCommandHandler(IStartupRepository startupRepository)
        {
            _startupCompanyRepository = startupRepository;
        }

        public async Task<Unit> Handle(DeleteStartupCommand request, CancellationToken cancellationToken)
        {
            var existingStartup = await _startupCompanyRepository.GetStartupCompanyByidAsync(request.StartupCompanyId);

            if (existingStartup != null)
            {
                 _startupCompanyRepository.DeleteStartup(existingStartup);
                return Unit.Value;
            }
            else
            {
                throw new Exception("Entity not found!");
            }

        }


    }
}
