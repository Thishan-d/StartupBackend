using MediatR;
using System;

namespace StartupCompanyApplication.Commands
{
    public class UpdateStartupCommandPatch : IRequest
    {
        public int StartupCompanyId { get; set; }
        public string BusinessDomain { get; set; }
        public string Description { get; set; }
        public decimal? GrossSales { get; set; }
        public decimal? NetSales { get; set; }
        public string Website { get; set; }
        public string BusinessLocation { get; set; }
        public DateTime? BusinessStartDate { get; set; }
        public int? EmployeeCount { get; set; }
        public string FounderName { get; set; }
    }
}
