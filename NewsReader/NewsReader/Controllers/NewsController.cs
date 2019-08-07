using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NewsReader.Models;

namespace NewsReader.Controllers
{
    public class NewsController : Controller
    {
        private Context db = new Context();

        // GET: News
        public ActionResult Index()
        {
            //var news = GetNews();
            //return View(news);
            var news = db.News.Include(n => n.Category).Include(n => n.Country);
            return View(news.ToList());
        }
        // GET: News/Top
        public ActionResult Top()
        {
            //var news = GetNews();
            //return View(news);
            var news = db.News.Include(n => n.Category).Include(n => n.Country);
            return View(news.ToList());
        }
        public ICollection<News> GetNews()
        {
            var numbers = getNumbers(db.News.Count());
            return db.News.Where(x => numbers.Contains(x.Id)).ToList();
        }
        private List<int> getNumbers(int length)
        {
            var list = new List<int>();
            var random = new Random();

            while (!(list.Count() < 3))
            {
                int n = random.Next(length);
                if (!list.Contains(n))
                    list.Add(n);
            }
            return list;
        }

        // GET: News/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // GET: News/Create
        public ActionResult Create()
        {
            ViewBag.IdCategory = new SelectList(db.Category, "Id", "Name");
            ViewBag.IdCountry = new SelectList(db.Country, "Id", "Name");
            return View();
        }

        // POST: News/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Content,Image,Published,IdCategory,IdCountry")] News news)
        {
            if (ModelState.IsValid)
            {
                db.News.Add(news);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCategory = new SelectList(db.Category, "Id", "Name", news.IdCategory);
            ViewBag.IdCountry = new SelectList(db.Country, "Id", "Name", news.IdCountry);
            return View(news);
        }

        // GET: News/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCategory = new SelectList(db.Category, "Id", "Name", news.IdCategory);
            ViewBag.IdCountry = new SelectList(db.Country, "Id", "Name", news.IdCountry);
            return View(news);
        }

        // POST: News/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Content,Image,Published,IdCategory,IdCountry")] News news)
        {
            if (ModelState.IsValid)
            {
                db.Entry(news).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCategory = new SelectList(db.Category, "Id", "Name", news.IdCategory);
            ViewBag.IdCountry = new SelectList(db.Country, "Id", "Name", news.IdCountry);
            return View(news);
        }

        // GET: News/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = db.News.Find(id);
            db.News.Remove(news);
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
