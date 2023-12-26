using MediatR;
using StartupCompanyDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyApplication.Queries
{
    public class GetStartupByidQuery : IRequest<StartupCompany>
    {
        public int StartupCompanyId { get; set; }
    }
}
