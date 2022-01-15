using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebIdeaGeneration.DataBase;
using WebIdeaGeneration.Models;

namespace WebIdeaGeneration.Controllers
{
    public class HomeController : Controller
    {
        public IRepository<TextItem, int> TextItems { get; set; }
        public HomeController(ApplicationDbContext context, IRepository<TextItem, int> textItemsRepository)
        {
            TextItems = textItemsRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult IdeaMatrix(int vert, int horiz, string[] categories)
        {
            IEnumerable<string> allCategories = TextItems
                .GetAll()
                .Select(w => w.Dictionary)
                .Distinct();
            IEnumerable<TextItem> categoriesTextItems = TextItems
                .GetAll()
                .Where(w => categories.Any(c => c == w.Dictionary));

            List<TextItem> textItems = new List<TextItem>();
            int textItemsCount = vert * horiz;
            Random random = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < textItemsCount; i++)
            {
                textItems.Add(categoriesTextItems
                    .ElementAt(random.Next(0, categoriesTextItems.Count() - 1)));
            }
            return View(new IdeaMatrixViewModel() {
                Horiz = horiz,
                Vert = vert,
                TextItems = textItems,
                AllCategories = allCategories.ToList(),
                CategoriesOnView = categories.ToList(),
            });
        }
    }
}