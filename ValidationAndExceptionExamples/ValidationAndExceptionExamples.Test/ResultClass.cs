using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidationAndExceptionExamples.ResultClass;

namespace ValidationAndExceptionExamples.Test
{
    [TestClass]
    public class ResultClass
    {
        [TestMethod]
        public void WithValidObject()
        {
            var request = new TimeOffRequestDto
            {
                Description = "Example",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(3)
            };

            Assert.IsTrue(Approve(request).Success);
        }

        [TestMethod]
        public void WithInvalidDescription()
        {
            var request = new TimeOffRequestDto
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(3)
            };

            var requestReponse = Approve(request);

            Assert.IsTrue(requestReponse.Failure);
            Assert.AreEqual("Description cannot be empty", requestReponse.Error);
        }

        public Result Approve(TimeOffRequestDto request)
        {
            if (request.Description == null) return Result.Fail("Description cannot be empty");
            if (request.StartDate > request.EndDate) return Result.Fail("Start date cannot be greater than the end date");

            return Result.Ok();
        }

        [TestMethod]
        public void GenericWithInvalidDescription()
        {
            var request = new TimeOffRequestDto
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(3)
            };

            var reponse = ApproveWithGenericResult(request);

            Assert.IsTrue(reponse.Failure);
            Assert.AreEqual("Description cannot be empty", reponse.Error);
        }

        [TestMethod]
        public void GenericResultWithValidObject()
        {
            var request = new TimeOffRequestDto
            {
                Description = "Example text",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(3)
            };

            var reponse = ApproveWithGenericResult(request);
            
            Assert.IsTrue(reponse.Success);
            Assert.AreEqual(request.Description, reponse.Value.Description);
            Assert.AreEqual(null, reponse.Error);
        }

        public Result<TimeOffRequestDto> ApproveWithGenericResult(TimeOffRequestDto request)
        {
            if (request.Description == null) return Result<TimeOffRequestDto>.Fail(request, "Description cannot be empty");
            if (request.StartDate > request.EndDate) return Result<TimeOffRequestDto>.Fail(request, "Start date cannot be greater than the end date");

            return Result<TimeOffRequestDto>.Ok(request);
        }
    }
}
