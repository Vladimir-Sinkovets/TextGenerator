using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebIdeaGeneration.Models;

namespace WebIdeaGeneration.DataBase
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<TextItem> TextItems { get; set; }

        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
