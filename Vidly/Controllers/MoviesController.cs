using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() {Name = "Shrak!"};
            RandomMovieViewModel viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = new List<Customer>()
                {
                    new Customer() {id = 1, Name = "Anuj"},
                    new Customer() {id = 2, Name = "Bhavna"}
                }
            };

            return View(viewModel);
            //return Content("Hellow friend");
        }

        public ActionResult Edit(int id)
        {
            return Content("Id=" + id);
        }

        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(string.Format("year={0}, month={1}", year, month));
        }

        public ActionResult Index(int? pageIndex, string sortOrder)
        {
            if (!pageIndex.HasValue)
                pageIndex = 0;
            if (sortOrder.IsEmpty())
                sortOrder = "Name";

            return Content(string.Format("Page Index = {0} and Sort Order = {1}", pageIndex, sortOrder));
        }
    }
}