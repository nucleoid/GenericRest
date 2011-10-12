
using System.Web.Mvc;
using System.Web.Routing;
using GenericRest.Controllers;
using MbUnit.Framework;
using MvcContrib.TestHelper;

namespace GenericRest.Tests
{
    [TestFixture]
    public class RouteRegistryTest
    {
        [FixtureSetUp]
        public void FixtureSetUp()
        {
            RouteTable.Routes.Clear();
            RouteRegistry.RegisterRoutes(RouteTable.Routes);
        }

        [Test]
        [Row("~/0000000000/Dogs")]
        [Row("~/0000000000/Dogs/Index")]
        public void Get_List_Action_Routes_Routed(string route)
        {
            //Assert
            route.WithMethod(HttpVerbs.Get).ShouldMapTo<DogsController>(x => x.Index(null));
        }

        [Test]
        [Row("~/asdfgh1234/Dogs/5", "5", "asdfgh1234")]
        [Row("~/0000000000/Dogs/600", "600", "0000000000")]
        public void Get_Single_Routes_Routed(string route, string id, string cif)
        {
            //Act
            var data = route.WithMethod(HttpVerbs.Get).Values;

            //Assert
            Assert.AreEqual("Dogs", data["controller"]);
            Assert.AreEqual("Index", data["action"]);
            Assert.AreEqual(id, data["id"]);
            Assert.AreEqual(cif, data["cif"]);
        }

        [Test]
        public void Post_Route_Routed()
        {
            //Act
            var data = "~/0000000000/Dogs".WithMethod(HttpVerbs.Post).Values;

            //Assert
            Assert.AreEqual("Dogs", data["controller"]);
            Assert.AreEqual("Save", data["action"]);
        }

        [Test]
        public void Put_Route_Routed()
        {
            //Act
            var data = "~/0000000000/Dogs/5".WithMethod(HttpVerbs.Put).Values;

            //Assert
            Assert.AreEqual("Dogs", data["controller"]);
            Assert.AreEqual("Save", data["action"]);
            Assert.AreEqual("5", data["id"]);
        }

        [Test]
        public void Delete_Route_Routed()
        {
            //Act
            var data = "~/0000000000/Dogs/5".WithMethod(HttpVerbs.Delete).Values;

            //Assert
            Assert.AreEqual("Dogs", data["controller"]);
            Assert.AreEqual("Delete", data["action"]);
            Assert.AreEqual("5", data["id"]);
        }

        [Test]
        [Row("~/0000000000/Index")]
        [Row("~/0000000000/default")]
        [Row("~/0000000000/About")]
        public void Invalid_Controller_Routes_Not_Routed(string route)
        {
            //Act
            var data = route.WithMethod(HttpVerbs.Get).Values;

            //Assert
            Assert.AreNotEqual("Home", data["controller"]);
        }
    }
}
