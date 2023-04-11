using ProjectCRUDCodeFirstApproach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectCRUDCodeFirstApproach.Controllers
{
    public class AjaxController : Controller
    {
        // GET: Ajax
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetTodos()
        {
            ServiceContext dbContext = new ServiceContext();
            var todos = dbContext.Todos.ToList();
            return Json(todos, JsonRequestBehavior.AllowGet);
        }
    }
}