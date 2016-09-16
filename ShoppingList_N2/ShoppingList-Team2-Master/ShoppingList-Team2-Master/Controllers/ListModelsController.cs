using Microsoft.AspNet.Identity;
using ShoppingList_Team2_Master.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ShoppingList_Team2_Master.Controllers
{ 
    
    public class ListModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ListModels
        public ActionResult Index()
        {
            return View(db.ListModels.ToList());
        }

        // GET: ListModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListModel listModel = db.ListModels.Single(li => li.ID == id); //.Find(id);

            // TODO: Move table from ListItems Index to List Details page & eliminate remove redirect
            if (listModel == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index", "ShoppingListItemModels", new {lId = id});
        }

        // GET: ListModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ListModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Color")] ListModel listModel)
        {
            if (ModelState.IsValid)
            {
                //Collin's code
                
                listModel.UserId = User.Identity.GetUserId();
                listModel.CreatedUtc = DateTime.UtcNow;
                listModel.ModifiedUtc = DateTime.UtcNow;
                db.ListModels.Add(listModel);      
                db.SaveChanges();             
                return RedirectToAction("Index");
            }

            return View(listModel);
        }

        // GET: ListModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListModel listModel = db.ListModels.Find(id);
            if (listModel == null)
            {
                return HttpNotFound();
            }
            return View(listModel);
        }

        // POST: ListModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Color")] ListModel listModel)
        {
            if (ModelState.IsValid)
            {
                //Collin's code
                listModel.UserId = User.Identity.GetUserId();
                listModel.ModifiedUtc = DateTime.UtcNow;
                db.Entry(listModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(listModel);
        }

        // GET: ListModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListModel listModel = db.ListModels.Find(id);
            if (listModel == null)
            {
                return HttpNotFound();
            }
            return View(listModel);
        }

        // POST: ListModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ListModel listModel = db.ListModels.Find(id);
            db.ListModels.Remove(listModel);
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
