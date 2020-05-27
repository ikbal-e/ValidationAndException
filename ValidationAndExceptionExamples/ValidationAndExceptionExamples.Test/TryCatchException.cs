using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidationAndExceptionExamples.TryCatchException;

namespace ValidationAndExceptionExamples.Test
{
    [TestClass]
    public class TryCatchException
    {
        [TestMethod]
        public void WithInvalidDate()
        {
            var request = new TimeOffRequestDto
            {
                Description = "The answer, my friend, is blowin' in the wind",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(-33)
            };

            Assert.ThrowsException<StartDateGreaterThanEndDateException>(() => Approve(request));
        }

        public void Approve(TimeOffRequestDto request)
        {
            if (request.Description is null) throw new ArgumentNullException(nameof(request.Description), "Description cannot be empty");
            if (request.StartDate > request.EndDate) throw new StartDateGreaterThanEndDateException("Start date cannot be greater than the end date");
        }

        [TestMethod]
        public void WithInvalidDescription()
        {
            var request = new TimeOffRequestDto
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(4)
            };

            try
            {
                Approve(request);
            }
            catch(ArgumentNullException exp)
            {
                Assert.IsTrue(exp.Message.Contains("Description cannot be empty"));
            }
        }
    }
}
