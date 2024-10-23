
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class HomeController : Controller
    {

        private Context _context;

        public HomeController()
        {
            _context = new Context();
        }

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

        public ActionResult Test()
        {

            return View();
        }

        [AllowAnonymous]
        public ActionResult HomePage()
        {
            // İçeriklerin toplam sayısını dinamik olarak veritabanından al
            var totalContentCount = _context.Contents.Count();

            // ViewBag ile View'a sayıyı gönder
            ViewBag.Entry = totalContentCount;

            // yazarlar toplam sayısını dinamik olarak veritabanından al
            var totalWriterCount = _context.Writers.Count();

            // ViewBag ile View'a sayıyı gönder
            ViewBag.Writer = totalWriterCount;

            // başlıklar toplam sayısını dinamik olarak veritabanından al
            var totalHeadingCount = _context.Headings.Count();

            // ViewBag ile View'a sayıyı gönder
            ViewBag.Heading = totalHeadingCount;

            if (Session["ViewCount"] == null)
            {
                Session["ViewCount"] = 1;
            }
            else
            {
                Session["ViewCount"] = (int)Session["ViewCount"] + 1;
            }

            ViewBag.TotalViews = Session["ViewCount"];

            return View();
        }
    }
}