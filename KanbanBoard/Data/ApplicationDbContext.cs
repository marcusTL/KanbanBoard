using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using KanbanBoard.Models;
using Microsoft.Extensions.DependencyInjection;

namespace KanbanBoard.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public static ApplicationDbContext dbContext = null;

        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Item { get; set; }


        
    }
}
