using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodeFirstMVC_6B.Models;

namespace CodeFirstMVC_6B.Controllers
{
    public class StudentCoursesController : Controller
    {
        private StudentDBContext db = new StudentDBContext();

        // GET: /StudentCourses/
        public ActionResult Index()
        {
            var studentcourses = db.StudentCourses.Include(s => s.CourseObj).Include(s => s.StudentObj);
            return View(studentcourses.ToList());
        }

        // GET: /StudentCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCourses studentcourses = db.StudentCourses.Find(id);
            if (studentcourses == null)
            {
                return HttpNotFound();
            }
            return View(studentcourses);
        }

        // GET: /StudentCourses/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "ID", "Code");
            ViewBag.StudentID = new SelectList(db.Students, "ID", "Name");
            return View();
        }

        // POST: /StudentCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,StudentID,CourseID,AssignedOn")] StudentCourses studentcourses)
        {
            if (ModelState.IsValid)
            {
                db.StudentCourses.Add(studentcourses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "ID", "Code", studentcourses.CourseID);
            ViewBag.StudentID = new SelectList(db.Students, "ID", "Name", studentcourses.StudentID);
            return View(studentcourses);
        }

        // GET: /StudentCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCourses studentcourses = db.StudentCourses.Find(id);
            if (studentcourses == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "ID", "Code", studentcourses.CourseID);
            ViewBag.StudentID = new SelectList(db.Students, "ID", "Name", studentcourses.StudentID);
            return View(studentcourses);
        }

        // POST: /StudentCourses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,StudentID,CourseID,AssignedOn")] StudentCourses studentcourses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentcourses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "ID", "Code", studentcourses.CourseID);
            ViewBag.StudentID = new SelectList(db.Students, "ID", "Name", studentcourses.StudentID);
            return View(studentcourses);
        }

        // GET: /StudentCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCourses studentcourses = db.StudentCourses.Find(id);
            if (studentcourses == null)
            {
                return HttpNotFound();
            }
            return View(studentcourses);
        }

        // POST: /StudentCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentCourses studentcourses = db.StudentCourses.Find(id);
            db.StudentCourses.Remove(studentcourses);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
