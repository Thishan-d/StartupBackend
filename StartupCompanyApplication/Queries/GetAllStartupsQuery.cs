using MediatR;
using StartupCompanyDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyApplication.Queries
{
    public class GetAllStartupsQuery : IRequest<List<StartupCompany>>
    {
    }
}
