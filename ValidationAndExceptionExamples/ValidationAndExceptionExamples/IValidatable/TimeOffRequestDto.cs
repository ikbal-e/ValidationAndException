using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ValidationAndExceptionExamples.IValidatable
{
    public class TimeOffRequestDto : IValidatableObject
    {
        public decimal UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Required]
        public string Description { get; set; }      

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (StartDate > EndDate) 
                results.Add(new ValidationResult("Start date cannot be greater than the end date"));

            if (EndDate.Subtract(StartDate).TotalDays < 365) 
                results.Add(new ValidationResult("Max time range is 365 days"));

            return results;
        }
    }
}