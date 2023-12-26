using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StartupCompanyApplication.Commands
{
    public class CreateStartupCommand : IRequest<int>, IValidatableObject
    {
        [Required(ErrorMessage = "Business domain is required.")]
        public string BusinessDomain { get; set; }
        public string Description { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Gross sales must be greater than or equal to 0.")]

        //before deductions
        public decimal GrossSales { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Net sales must be greater than or equal to 0.")]

        //after deductions
        public decimal NetSales { get; set; }
        public string Website { get; set; }

        [Required(ErrorMessage = "Business Location is required.")]
        public string BusinessLocation { get; set; }

        [Required(ErrorMessage = "Business start date is required.")]
        public DateTime BusinessStartDate { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Employee count must be greater than 0.")]
        public int EmployeeCount { get; set; }
        [Required(ErrorMessage = "Founder name is required.")]
        public string FounderName { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (GrossSales < NetSales)
            {
                yield return new ValidationResult("Gross sales must be greater than net sales.", new[] { nameof(GrossSales), nameof(NetSales) });
            }

            yield break;
        }
    }
}
