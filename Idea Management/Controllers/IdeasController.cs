using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Idea_Management.Models;

namespace Idea_Management.Controllers
{
    public class IdeasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Ideas
        public ActionResult Index()
        {

            return View(db.Ideas.ToList());
        }

        // GET: Ideas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ideas ideas = db.Ideas.Find(id);
            if (ideas == null)
            {
                return HttpNotFound();
            }
            return View(ideas);
        }
        public ActionResult Posts(int? ideaId)
        {
            if (ideaId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var post = db.post.Where(p => p.IdeaId == ideaId).ToList();
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
            
        }

        // GET: Ideas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ideas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Description,Deadline1,Deadline2")] Ideas ideas)
        {
            if (ModelState.IsValid)
            {
                db.Ideas.Add(ideas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ideas);
        }

        // GET: Ideas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ideas ideas = db.Ideas.Find(id);
            if (ideas == null)
            {
                return HttpNotFound();
            }
            return View(ideas);
        }

        // POST: Ideas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrators")]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,Deadline1,Deadline2")] Ideas ideas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ideas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ideas);
        }

        // GET: Ideas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ideas ideas = db.Ideas.Find(id);
            if (ideas == null)
            {
                return HttpNotFound();
            }
            return View(ideas);
        }

        // POST: Ideas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ideas ideas = db.Ideas.Find(id);
            db.Ideas.Remove(ideas);
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
