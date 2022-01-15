using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebIdeaGeneration.Models
{
    public class IdeaMatrixViewModel
    {
        public List<TextItem> TextItems { get; set; }
        public List<string> AllCategories { get; set; }
        public List<string> CategoriesOnView { get; set; }
        public int Vert { get; set; }
        public int Horiz { get; set; }
    }
}