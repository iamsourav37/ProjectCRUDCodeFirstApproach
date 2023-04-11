using ProjectCRUDCodeFirstApproach.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectCRUDCodeFirstApproach.Controllers
{
    public class TodoController : Controller
    {
        private ServiceContext dbContext;

        public TodoController()
        {
            dbContext = new ServiceContext();
        }

        public ActionResult Index()
        {
            var todoList = dbContext.Todos.ToList();
            return View(todoList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Todo todo)
        {

            if (ModelState.IsValid)
            {
                dbContext.Todos.Add(todo);
                dbContext.SaveChanges();
            }
            else
            {
                Debug.Write(todo.ToString());
                return View();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var todoData = dbContext.Todos.Find(id);
            return View(todoData);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "CreatedAt, UpdatedAt")] Todo todo)
        {
            if (ModelState.IsValid)
            {
                var data = dbContext.Todos.Find(todo.Id);
                data.Title = todo.Title;
                data.Description = todo.Description;
                data.UpdatedAt = DateTime.Now;
                dbContext.SaveChanges();
            }
            else
            {
                Debug.Write(todo.ToString());
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {

            var todoData = dbContext.Todos.Find(id);
            dbContext.Todos.Remove(todoData);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult MyAction(string param1, string param2)
        {
            // do something with the parameters
            Debug.WriteLine($"Param1 : {param1}. Param2 : {param2}");
            return Json(new { result = "success" }, JsonRequestBehavior.AllowGet);
        }

    }
}