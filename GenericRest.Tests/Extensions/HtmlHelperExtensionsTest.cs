using System.Web.Mvc;
using System.Web.Routing;
using GenericRest.Extensions;
using MbUnit.Framework;
using TemplateProject.Tests.Web.Mvc;

namespace GenericRest.Tests.Extensions
{
    [TestFixture]
    public class HtmlHelperExtensionsTest
    {
        [FixtureSetUp]
        public void FixtureSetUp()
        {
            RouteTable.Routes.Clear();
            RouteRegistry.RegisterRoutes(RouteTable.Routes);
        }

        [Test]
        public void ActionLinkArea_Routes_To_Area()
        {
            //Arrange
            HtmlHelper helper = MvcHelper.GetHtmlHelper();

            //Act
            var linkage = helper.ActionLink<TestController>(c => c.Tester(), "test link", new {cif="00000000"});

            //Assert
            Assert.AreEqual("<a href=\"/00000000/Test/Tester\">test link</a>", linkage.ToString());
        }

        [Test]
        public void ActionLinkArea_HtmlAttributes_Routes_To_Area()
        {
            //Arrange
            HtmlHelper helper = MvcHelper.GetHtmlHelper();

            //Act
            var linkage = helper.ActionLink<TestController>(c => c.Tester(), "test link", new {cif="00000000"}, new { coolness = "11" });

            //Assert
            Assert.AreEqual("<a coolness=\"11\" href=\"/00000000/Test/Tester\">test link</a>", linkage.ToString());
        }

        private class TestController : Controller
        {
            public ActionResult Tester()
            {
                return null;
            }
        }
    }
}
