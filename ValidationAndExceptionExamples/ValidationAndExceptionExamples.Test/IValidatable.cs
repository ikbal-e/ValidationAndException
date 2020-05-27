using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidationAndExceptionExamples.IValidatable;

namespace ValidationAndExceptionExamples.Test
{
    [TestClass]
    public class IValidatable
    {
        [TestMethod]
        public void WithInvalidObject()
        {
            var request = new TimeOffRequestDto
            {
                Description = "Example text",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(-5)
            };

            ValidationContext vcx = new ValidationContext(request);
            var results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(request, vcx, results, true);
            
            Assert.IsFalse(isValid);

            Assert.IsTrue(results.Select(x => x.ErrorMessage).Contains("Start date cannot be greater than the end date"));
        }

        [TestMethod]
        public void WithNullDescription()
        {
            // Priority = [Required] -> Other attributes -> IValidatableObject Implementation

            var request = new TimeOffRequestDto
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(-5)
            };

            ValidationContext vcx = new ValidationContext(request);
            var results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(request, vcx, results, true);

            Assert.IsFalse(isValid);

            Assert.IsTrue(results.Count == 1);

            Assert.IsFalse(results.Select(x => x.ErrorMessage).Contains("Start date cannot be greater than the end date"));

            //Assert.IsTrue(results.Select(x => x.ErrorMessage).Contains("Description is required.")); //Error message depends on local language
        }
    }
}
