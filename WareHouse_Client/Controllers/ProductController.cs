using System.Web.Mvc;
using WareHouse_Client.Models;

namespace WareHouse_Client.Controllers
{
    public class ProductController : Controller
    {

        // GET: Product
        public ActionResult Index()
        {
            ProductServiceClient psc = new ProductServiceClient();
            ViewBag.ListProducts = psc.findAll();
            return View();
        }
    }
}