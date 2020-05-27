using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ValidationAndExceptionExamples.DataAnnotation
{
    public class TimeOffRequestDto
    {
        [Required]
        public decimal UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [MinLength(10, ErrorMessage = "Description must have at least 10 character")]
        public string Description { get; set; }

        //TODO add custom attributes
    }
}