using System;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using GenericRest.Models;
using MvpRestApiLib;

namespace GenericRest.Controllers
{
    public class DogsController : Controller
    {
        [HttpGet]
        public ActionResult Index(int? id)
        {
            if(id.HasValue)
            {
                var dog = DogDB.Dogs.SingleOrDefault(x => x.ID == id);
                if(dog == null)
                    return new HttpNotFoundResult("Dog not found!");
                return new JsonResult2
                {
                    Data = dog, 
                    ContentEncoding = Encoding.UTF8,
                    ContentType = HttpContext.Request.ContentType
                };
            }
            return new JsonResult2
            {
                Data = DogDB.Dogs,
                ContentEncoding = Encoding.UTF8,
                ContentType = HttpContext.Request.ContentType
            };
        }

        [HttpGet]
        public ActionResult Breeds()
        {
            var breeds = Enum.GetValues(typeof (Breed));
            var breedStrings = (from object breed in breeds select breed.ToString()).ToList();
            return new JsonResult2
            {
                Data = breedStrings,
                ContentEncoding = Encoding.UTF8,
                ContentType = HttpContext.Request.ContentType
            };
        }

        [HttpGet]
        public ActionResult DogsByOwner()
        {
            var ownerDogs = DogDB.Dogs.Where(d => d.Owner == CustomerIdentityField).ToList();
            return new JsonResult2
            {
                Data = ownerDogs,
                ContentEncoding = Encoding.UTF8,
                ContentType = HttpContext.Request.ContentType
            };
        }

        [AcceptVerbs(HttpVerbs.Post | HttpVerbs.Put)]
        public ActionResult Save(Dog dog)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(dog.Owner))
                    dog.Owner = CustomerIdentityField;
                var addedDog = DogDB.AddOrUpdateDog(dog);
                return new JsonResult2
                {
                    Data = addedDog,
                    ContentEncoding = Encoding.UTF8,
                    ContentType = HttpContext.Request.ContentType
                };
            }
            return new HttpStatusCodeResult(400, "Invalid Dog");
        }

        [AcceptVerbs(HttpVerbs.Delete)]
        public ActionResult Delete(int id)
        {
            DogDB.RemoveDog(id);
            return new JsonResult2
            {
                Data = string.Format("Dog #{0} was successfully deleted!", id),
                ContentEncoding = Encoding.UTF8,
                ContentType = HttpContext.Request.ContentType
            };
        }

        private string CustomerIdentityField
        {
            get { return RouteData.Values["cif"].ToString(); }
        }
    }
}
