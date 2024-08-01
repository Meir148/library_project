using library_pr;
using library_project.DAL;
using library_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace library_project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult library_view()
        {
            return View();
        }

        public IActionResult shelf(int id)
        {
            ViewBag.id = id;
            return View();
        }




        public IActionResult book(int id)
        {
            ViewBag.id = id;
            return View(new book());
        }
        //public IActionResult AllBooks()
        //{
        //    List<book> AllBooks = Data.Get.books.ToList();

        //    return View(AllBooks);
        //}
        public IActionResult AllBooks(int id)
        {
            IEnumerable<shelf>  AllBooks = Data.Get.shelves.Include(s => s.books).ToList().Where(s => s.Id == id);
            ViewBag.id = id;
            //if(shelf == null)
            //{
            //    return RedirectToAction("shelf");
            //}

            return View(AllBooks);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddBook(book Book)
        {
            shelf? booksFromDb = Data.Get.shelves.FirstOrDefault(bc => bc.Id == Book.bkid);
            Book.Shelf = booksFromDb;
            Data.Get.books.Add(Book);
            Data.Get.SaveChanges();

            return RedirectToAction("AllBooks");
        }






        [HttpPost, ValidateAntiForgeryToken]
            public IActionResult AddBooks(book books)
            {
            Data.Get.books.Add(books);
            Data.Get.SaveChanges();

            return RedirectToAction("AllBooks");
        }




        public IActionResult createBookcase()
        {
            return View(new Bookcase());
        }

        public IActionResult AllBookcases()
        {
            List<Bookcase> AllBookcases = Data.Get.Bookcases.ToList();

            return View(AllBookcases);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddBookcase(Bookcase bookcase)
        {
            Data.Get.Bookcases.Add(bookcase);  
            Data.Get.SaveChanges(); 

            return RedirectToAction("AllBookcases"); 
        }


        public IActionResult CreateNewShelf(int id)
        {
            ViewBag.id = id;
            return View(new shelf());
        }

        public IActionResult AllShelves(int id)
        {
            IEnumerable<shelf> AllShelves = Data.Get.shelves.Include(s => s.bookcase).ToList().Where(s => s.bookcase.Id == id);
            ViewBag.id = id;
            //if(shelf == null)
            //{
            //    return RedirectToAction("shelf");
            //}

            return View(AllShelves);
        }



        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddShelf(shelf Shelf)
        {
            Bookcase? bookcaseFromDb = Data.Get.Bookcases.FirstOrDefault(bc => bc.Id == Shelf.bcid);
            Shelf.bookcase = bookcaseFromDb;
            Data.Get.shelves.Add(Shelf);
            Data.Get.SaveChanges();

            return RedirectToAction("shelf");
        }





        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
