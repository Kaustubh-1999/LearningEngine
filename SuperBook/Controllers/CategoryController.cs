using Azure.Identity;
using Microsoft.AspNetCore.Mvc;
using SuperBook.Data;
using SuperBook.Models;

namespace SuperBook.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
    
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;  
            return View(objCategoryList);
        }

        //Get
        public IActionResult Create()
        {       
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]  
        public IActionResult Create(Category obj)
        {
            // Adding the custom error 
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DispalyOrder cannot exactly match the name.");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created sucessfully";
                return RedirectToAction("Index");
            }
            return View(obj);   
        }

		// TODO: Add Edit-update and Delete function.
		//Get
		public IActionResult Edit(int? id)
		{
            if(id==null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.ID==id);
			//var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.ID == id);

			if (categoryFromDb == null) {

                return NotFound();
            }

			return View(categoryFromDb);
		}

      
		//Post
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Category obj)
		{
			// Adding the custom error 
			if (obj.Name == obj.DisplayOrder.ToString())
			{
				ModelState.AddModelError("name", "The DispalyOrder cannot exactly match the name.");
			}

			if (ModelState.IsValid)
			{
				_db.Categories.Update(obj);
				_db.SaveChanges();
                TempData["success"] = "Category updated sucessfully";
                return RedirectToAction("Index");
			}
			return View(obj);
		}

        //Get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.ID==id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.ID == id);

            if (categoryFromDb == null)
            {

                return NotFound();
            }

            return View(categoryFromDb);
        }


        //Post
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            // Adding the custom error
            var obj = _db.Categories.Find(id);  

            if(obj == null)
            {
                return NotFound();  
            }
            
               _db.Categories.Remove(obj);
               _db.SaveChanges();
                TempData["success"] = "Category removed sucessfully";
            return RedirectToAction("Index");
                 
        }
    }
}
