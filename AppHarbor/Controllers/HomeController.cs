using System.Web.Mvc;
using AppHarbor.Models;
using MongoDB.Driver;

namespace AppHarbor.Controllers
{
	public class HomeController : BaseController
	{
		private readonly MongoCollection<Thingy> _collection;

		public HomeController()
		{
			_collection = Database.GetCollection<Thingy>("Thingies");
		}

		public ActionResult Index()
		{
			return View(_collection.FindAll());
		}

		public ActionResult New()
		{
			return View();
		}

		public ActionResult Create(Thingy thingy)
		{
			_collection.Insert(thingy);
			return RedirectToAction("Index");
		}
	}
}
