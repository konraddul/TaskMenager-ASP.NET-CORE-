using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskMenager.Models;
using TaskMenager.Repositories;

namespace TaskMenager.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskRepository _taskRepositury;
        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepositury = taskRepository;
        }
        // GET: Task
        public ActionResult Index()
        {
            return View(_taskRepositury.GetAllActive());
        }

        // GET: Task/Details/5
        public ActionResult Details(int id)
        {
            return View(_taskRepositury.Get(id));
        }

        // GET: Task/Create
        public ActionResult Create()
        {
            return View(new TaskModel());
        }

        // POST: Task/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskModel taskModel)
        {
            _taskRepositury.Add(taskModel); 
            return RedirectToAction(nameof(Index));
        }

        // GET: Task/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_taskRepositury.Get(id));
        }

        // POST: Task/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TaskModel taskModel)
        {
            _taskRepositury.Update(id, taskModel);
            return RedirectToAction(nameof(Index));
        }

        // GET: Task/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_taskRepositury.Get(id));
        }

        // POST: Task/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TaskModel taskModel)
        {

            _taskRepositury.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        //Get: Task/Done/5
        public ActionResult Done(int id)
        {
            TaskModel task = _taskRepositury.Get(id);
            task.Done = true;
            _taskRepositury.Update(id, task);
            return RedirectToAction(nameof(Index));
        }
    }
}
