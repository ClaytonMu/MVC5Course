using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController : BaseController
    {
        // GET: AR
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PartialTest()
        {
            return PartialView("Index");
        }

        public ActionResult FileTest(int? dl)
        {
            if (dl.HasValue && dl == 1)
            {
                return File(Server.MapPath("~/Image/Small-mario.png"), "image/png", "我的圖片.png");
            }
            else
            {
                return File(Server.MapPath("~/Image/Small-mario.png"), "image/png");
            }
        }

        public ActionResult JsonTest()
        {
            _repoProduct.UnitOfWork.Context.Configuration.LazyLoadingEnabled = false;
            var data = _repoProduct.Find(1);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}