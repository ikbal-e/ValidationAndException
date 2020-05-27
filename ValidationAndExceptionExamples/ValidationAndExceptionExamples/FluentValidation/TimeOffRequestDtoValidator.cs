using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ValidationAndExceptionExamples.FluentValidation
{
    public class TimeOffRequestDtoValidator : AbstractValidator<TimeOffRequestDto>
    {
        public TimeOffRequestDtoValidator()
        {
            RuleFor(x => x.StartDate).LessThan(x => x.EndDate)
                .WithMessage("Start date cannot be greater than the end date");

            RuleFor(x => new { x.StartDate, x.EndDate }).Must(x => Max1Year(x.StartDate, x.EndDate))
                .WithMessage("Max time range is 365 days");

            RuleFor(x => x.Description).NotEmpty()
                .WithMessage("Description cannot be empty");
        }

        private bool Max1Year(DateTime start, DateTime end)
        {
            return (end.Subtract(start).TotalDays < 365) ? true : false;
        }
    }
}