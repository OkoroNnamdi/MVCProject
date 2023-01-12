using BullkBookWeb.Data;
using BullkBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BullkBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext db;
        public CategoryController(ApplicationDbContext applicationDbContext)
        {
            db = applicationDbContext;
        }
        public IActionResult Index()
        {
          IEnumerable<Category>   categoryList = db.Categories.ToList();
            return View(categoryList);
        }
        //Get
        public IActionResult Create()
        {
           
            return View();
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category cat)
        {
            if (cat.Name == cat.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The display order cannot exactly match the name");
            }
            if (ModelState.IsValid)
            {
                db.Categories.Add(cat);
                db.SaveChanges();
                TempData["Sucess"] = "Category created Sucessful";
                return RedirectToAction("Index");
            }
            return View(cat);
        }
        //Get
        public IActionResult Edit (int?id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            // var category = db.Categories.FirstOrDefault(c => c.Id == id);
            var categoryFromDb = db.Categories.Find(id);
            if(categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category cat)
        {
            if (cat.Name == cat.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The display order cannot exactly match the name");
            }
            if (ModelState.IsValid)
            {
                db.Categories.Update(cat);
                db.SaveChanges();
                TempData["Sucess"] = "Category Edited Sucessful";
                return RedirectToAction("Index");
            }
            return View(cat);
        }
        //Get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            // var category = db.Categories.FirstOrDefault(c => c.Id == id);
            var categoryFromDb = db.Categories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //post
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int?id)
        {
           var categoryFromDb = db.Categories.Find(id);

            if (categoryFromDb ==null)
            {
                return NotFound();
            }
            
             db.Categories.Remove(categoryFromDb );
             db.SaveChanges();
            TempData["Sucess"] = "Category Deleted Sucessful";
            return RedirectToAction("Index");
            
            
        }
    }
}
