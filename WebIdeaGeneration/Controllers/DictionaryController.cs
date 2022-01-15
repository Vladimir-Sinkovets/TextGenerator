using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebIdeaGeneration.DataBase;
using WebIdeaGeneration.Models;

namespace WebIdeaGeneration.Controllers
{
    public class DictionaryController : Controller
    {
        public IRepository<TextItem, int> TextItems { get; set; }

        public DictionaryController(IRepository<TextItem, int> textItems)
        {
            TextItems = textItems;
        }
    }
}
