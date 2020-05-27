using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace ValidationAndExceptionExamples.FluentValidation
{
    public static class FluentValidationExtensions
    {
        //Does the same thing with ToString() extension method
        public static string GetMessage(this ValidationResult validationResult, string seperator = ",")
        {
            return string.Join(seperator + " ", validationResult.Errors.Select(x => x.ErrorMessage));
        }
    }
}