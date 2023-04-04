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
    public class postsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: posts
        public ActionResult Index(int ideaId)
        {
            var post = db.post.Where(p => p.IdeaId == ideaId).ToList();
           
            return View(post);
        }

        // GET: posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            post post = db.post.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: posts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "post_id,post_text,post_date,post_like,post_dislike")] post post)
        {
            if (ModelState.IsValid)
            {
                post.post_like = 0;
                post.post_dislike = 0;
                post.post_date = DateTime.Now;
                db.post.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(post);
        }
        public ActionResult Like (int id)
        {
            post update = db.post.ToList().Find(u => u.post_id == id);
            update.post_like += 1;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Dislike(int id)
        {
            post update = db.post.ToList().Find(u => u.post_id == id);
            update.post_like -= 1;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            post post = db.post.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "post_id,post_text,post_date,post_like,post_dislike")] post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            post post = db.post.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            post post = db.post.Find(id);
            db.post.Remove(post);
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
