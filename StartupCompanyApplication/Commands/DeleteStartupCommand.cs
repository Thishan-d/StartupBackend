using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyApplication.Commands
{
    public class DeleteStartupCommand : IRequest
    {
        public int StartupCompanyId { get; set; }
    }

}
