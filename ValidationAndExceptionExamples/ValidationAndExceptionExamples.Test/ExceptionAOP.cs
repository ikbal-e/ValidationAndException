using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidationAndExceptionExamples.ExceptionAOP;

namespace ValidationAndExceptionExamples.Test
{
    [TestClass]
    public class ExceptionAOP
    {
        [TestMethod]
        public void ExceptionAOPTestWithInvalidObject()
        {
            var request = new TimeOffRequestDto
            {
                Description = "Lorem ipsum cogito ergo sum and other stuff",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(-3)
            };

            Assert.IsFalse(Approve(request));

            //This assert will fail
            //Assert.ThrowsException<StartDateGreaterThanEndDateException>(() => Approve(request));
        }

        [TimeOffRequestExceptionAspect]
        public bool Approve(TimeOffRequestDto request)
        {
            if (request.StartDate > request.EndDate) throw new StartDateGreaterThanEndDateException("Start date cannot be greater than end date");

            return true;
        }

        [TestMethod]
        public void ExceptionAOPTestWithValidObject()
        {
            var request = new TimeOffRequestDto
            {
                Description = "Legit description",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(5)
            };

            Assert.IsTrue(Approve(request));
        }
    }
}
