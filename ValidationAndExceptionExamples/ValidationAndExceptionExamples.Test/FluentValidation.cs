using System;
using System.Linq;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidationAndExceptionExamples.FluentValidation;

namespace ValidationAndExceptionExamples.Test
{
    [TestClass]
    public class FluentValidation
    {
        [TestMethod]
        public void WithValidObject()
        {
            var request = new TimeOffRequestDto
            {
                Description = "I have Vietnam flashbacks",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(3)
            };

            var requestValidator = new TimeOffRequestDtoValidator();
            var validatorResult = requestValidator.Validate(request);

            Assert.IsTrue(validatorResult.IsValid);
        }

        [TestMethod]
        public void WithInvalidObject()
        {
            var request = new TimeOffRequestDto
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(-5)
            };

            var timeOffValidator = new TimeOffRequestDtoValidator();
            var validatorResult = timeOffValidator.Validate(request);

            Assert.IsFalse(validatorResult.IsValid);

            var errorMessages = validatorResult.Errors.Select(x => x.ErrorMessage);

            Assert.IsFalse(errorMessages.Contains("Max time range is 365 days"));

            Assert.IsTrue(errorMessages.Contains("Description cannot be empty"));
            Assert.IsTrue(errorMessages.Contains("Start date cannot be greater than the end date"));
        }

        [TestMethod]
        public void FluentValidationWithToString()
        {
            var request = new TimeOffRequestDto
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(-22)
            };

            var timeOffValidator = new TimeOffRequestDtoValidator();
            var validatorResult = timeOffValidator.Validate(request);

            var errorMessage = validatorResult.ToString(", ");

            Assert.AreEqual("Start date cannot be greater than the end date, Description cannot be empty", errorMessage);
        }

    }
}
