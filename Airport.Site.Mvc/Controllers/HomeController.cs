using System.Web.Mvc;
using Airport.Db.Tools.Repository;

namespace Airport.Site.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly CustomerRepository _cr = new CustomerRepository();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}