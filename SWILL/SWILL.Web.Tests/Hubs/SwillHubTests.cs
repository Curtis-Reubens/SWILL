using System;
using FakeItEasy;
using NUnit.Framework;
using SWILL.Web.Hubs;
using SWILL.Web.Services;

namespace SWILL.Web.Tests.Hubs
{
    [TestFixture]
    public class SwillHubTests
    {
        [Test]
        public void GetLunchDetails_QueriesTheLunchApp_ForTheCorrectDate()
        {
            //Create a SwillHub which uses a fake LunchService.
            var fakeService = A.Fake<LunchService>();
            var queryDate = new DateTime(2015, 03, 15);
            var swillHub = new SwillHub(fakeService);

            //Call GetLunchDetails on our SwillHub, with a specific date requested.
            swillHub.GetLunchDetails(queryDate);

            //Check that the SwillHub passes the correct date through to our fake LunchService.
            A.CallTo(() => fakeService.GetServiceDetails(queryDate))
             .MustHaveHappened(Repeated.Exactly.Once);
        }
    }
}
