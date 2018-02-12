using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShiDo.DAL;
using ShiDo.Models.Gallery;

namespace ShiDo.Areas.Admin.Controllers
{
    public class PictureController : Controller
    {
        private ShiDoDbContext db = new ShiDoDbContext();

        // GET: Admin/Picture
        public ActionResult Index()
        {
            var pictures = db.Pictures.Include(p => p.Gallery);
            return View(pictures.ToList());
        }

        // GET: Admin/Picture/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = db.Pictures.Find(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            return View(picture);
        }

        // GET: Admin/Picture/Create
        public ActionResult Create()
        {
            ViewBag.GalleryId = new SelectList(db.Galleries, "GalleryId", "GalleryName");
            return View();
        }

        // POST: Admin/Picture/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Picture picture, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    picture.Image = new byte[file.ContentLength];
                    file.InputStream.Read(picture.Image, 0, file.ContentLength);
                }
                db.Pictures.Add(picture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GalleryId = new SelectList(db.Galleries, "GalleryId", "GalleryName", picture.GalleryId);
            return View(picture);
        }

        // GET: Admin/Picture/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = db.Pictures.Find(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            ViewBag.GalleryId = new SelectList(db.Galleries, "GalleryId", "GalleryName", picture.GalleryId);
            return View(picture);
        }

        // POST: Admin/Picture/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PictureId,Image,Name,GalleryId")] Picture picture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(picture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GalleryId = new SelectList(db.Galleries, "GalleryId", "GalleryName", picture.GalleryId);
            return View(picture);
        }

        // GET: Admin/Picture/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = db.Pictures.Find(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            return View(picture);
        }

        // POST: Admin/Picture/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Picture picture = db.Pictures.Find(id);
            db.Pictures.Remove(picture);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Show(int? id)
        {
            var image = db.Pictures.Find(id);
            byte[] picture = image.Image;
            return File(picture, "image/png");
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
