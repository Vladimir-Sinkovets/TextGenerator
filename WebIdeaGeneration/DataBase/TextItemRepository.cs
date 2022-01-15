using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebIdeaGeneration.Models;

namespace WebIdeaGeneration.DataBase
{
    public class TextItemRepository : IRepository<TextItem, int>
    {
        public ApplicationDbContext Context { get; set; }

        public TextItemRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public void Add(TextItem entity) => Context.TextItems.Add(entity);

        public IEnumerable<TextItem> GetAll() => Context.TextItems.ToList();

        public TextItem GetById(int id) => Context.TextItems.ElementAt(id);

        public void Remove(int id)
        {
            var item = Context.TextItems.FirstOrDefault(t => t.Id == id);
            if (item != null)
                Context.TextItems.Remove(item);
        }
        public void SaveChanges() => Context.SaveChanges();
    }
}
