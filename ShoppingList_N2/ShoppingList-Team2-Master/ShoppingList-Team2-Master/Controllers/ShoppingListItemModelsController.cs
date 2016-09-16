using ShoppingList_Team2_Master.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ShoppingList_Team2_Master.Controllers
{
    public class ShoppingListItemModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ShoppingListItemModels
        public ActionResult Index(int? lId)
        {
            if (lId == null)
            {
                ViewBag.ListId = 0;
            }
            else
            {
                ViewBag.ListId = lId;
            }
            var shoppingListItemModels = db.ShoppingListItemModels.Include(s => s.List);
            return View(shoppingListItemModels.ToList());
        }

        // GET: ShoppingListItemModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingListItemModel shoppingListItemModel = db.ShoppingListItemModels.Find(id);
            if (shoppingListItemModel == null)
            {
                return HttpNotFound();
            }
            return View(shoppingListItemModel);
        }

        // GET: ShoppingListItemModels/Create
        public ActionResult Create(int? ListId)
        {
            //ViewBag.ListId = new SelectList(db.ListModels, "ID", "UserId");

            return View();
        }

        // POST: ShoppingListItemModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ListId,Name,IsChecked,Purchased,Priority,Note")] ShoppingListItemModel shoppingListItemModel, int? ListId)
        {
            shoppingListItemModel.ListId = ListId ?? 0;    
            shoppingListItemModel.CreatedUtc = DateTime.UtcNow;
            if (ModelState.IsValid)
            {
                ViewBag.ListId = shoppingListItemModel.ListId;
                db.ShoppingListItemModels.Add(shoppingListItemModel);
                db.SaveChanges();

                // TODO: Redirect to list details page after other refactoring
                return RedirectToAction("Index", new { lId = ListId });
            }

            ViewBag.ListId = new SelectList(db.ListModels, "ID", "UserId", shoppingListItemModel.ListId);
            return View(shoppingListItemModel);
        }

        // GET: ShoppingListItemModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingListItemModel shoppingListItemModel = db.ShoppingListItemModels.Find(id);
            if (shoppingListItemModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.ListId = new SelectList(db.ListModels, "ID", "UserId", shoppingListItemModel.ListId);
            return View(shoppingListItemModel);
        }

        // POST: ShoppingListItemModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ListId,Name,IsChecked,Purchased,Priority,Note")] ShoppingListItemModel shoppingListItemModel)
        {           
            shoppingListItemModel.CreatedUtc = DateTime.UtcNow;
            if (ModelState.IsValid)
            {
                db.Entry(shoppingListItemModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ListId = new SelectList(db.ListModels, "ID", "UserId", shoppingListItemModel.ListId);
            return View(shoppingListItemModel);
        }

        // GET: ShoppingListItemModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingListItemModel shoppingListItemModel = db.ShoppingListItemModels.Find(id);
            if (shoppingListItemModel == null)
            {
                return HttpNotFound();
            }
            return View(shoppingListItemModel);
        }

        // POST: ShoppingListItemModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShoppingListItemModel shoppingListItemModel = db.ShoppingListItemModels.Find(id);
            db.ShoppingListItemModels.Remove(shoppingListItemModel);
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
