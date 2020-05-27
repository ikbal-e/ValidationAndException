using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ValidationAndExceptionExamples.FluentValidation
{
    public class TimeOffRequestDto
    {
        public decimal UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
    }
}