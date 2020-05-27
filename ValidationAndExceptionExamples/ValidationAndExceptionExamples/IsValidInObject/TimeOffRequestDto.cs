using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ValidationAndExceptionExamples.IsValidInObject
{
    public class TimeOffRequestDto
    {
        public decimal UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }

        public IReadOnlyList<string> IsValid()
        {
            var errors = new List<string>();

            if (StartDate > EndDate)
                errors.Add("Start date cannot be greater than the end date");

            if (EndDate.Subtract(StartDate).TotalDays < 365)
                errors.Add("Max time range is 365 days");

            if (string.IsNullOrEmpty(Description))
                errors.Add("Description cannot be empty");            

            return errors;
        }
    }
}