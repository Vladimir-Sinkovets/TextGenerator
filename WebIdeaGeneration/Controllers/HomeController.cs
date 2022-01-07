using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebIdeaGeneration.Models;

namespace WebIdeaGeneration.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<Word> _words;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _words = new List<Word>()
            {
                new Word() { Text = "Слово", Category = "1"},
                new Word() { Text = "Язык", Category = "1"},
                new Word() { Text = "Книга", Category = "1"},
                new Word() { Text = "Стол", Category = "1"},
                new Word() { Text = "Стул", Category = "1"},
                new Word() { Text = "Неизвестность", Category = "1"},
                new Word() { Text = "Кружка", Category = "1"},
                new Word() { Text = "Мышь", Category = "1"},
                new Word() { Text = "Бег", Category = "1"},
                new Word() { Text = "Игра", Category = "1"},
                new Word() { Text = "Картина", Category = "1"},
                new Word() { Text = "Дева", Category = "1"},
                new Word() { Text = "Мужчина", Category = "1"},
                new Word() { Text = "Сыр", Category = "1"},
                new Word() { Text = "Глаза", Category = "1"},
                new Word() { Text = "Убийца", Category = "1"},
                new Word() { Text = "Скорость", Category = "1"},
                new Word() { Text = "Неопределенность", Category = "1"},
                new Word() { Text = "Палка", Category = "1"},
                new Word() { Text = "Оружие", Category = "1"},
                new Word() { Text = "Сила", Category = "1"},
                new Word() { Text = "Интеллект", Category = "1"},
                new Word() { Text = "Карта", Category = "1"},
                new Word() { Text = "База", Category = "1"},
                new Word() { Text = "Знание", Category = "1"},
                new Word() { Text = "Граф", Category = "1"},
                new Word() { Text = "Стройка", Category = "1"},
            };
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IdeaMatrix(int vert, int horiz, string[] categories)
        {
            IEnumerable<string> allCategories = _words
                .Select(w => w.Category)
                .Distinct();
            IEnumerable<Word> categoriesWords = _words
                .Where(w => categories.Any(c => c == w.Category));

            List<Word> words = new List<Word>();
            int wordsCount = vert * horiz;
            Random random = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < wordsCount; i++)
            {
                words.Add(categoriesWords
                    .ElementAt(random.Next(0, categoriesWords.Count() - 1)));
            }
            return View(new IdeaMatrixViewModel() {
                Horiz = horiz,
                Vert = vert,
                Words = words,
                AllCategories = allCategories.ToList(),
                CategoriesOnView = categories.ToList(),
            });
        }
    }
}