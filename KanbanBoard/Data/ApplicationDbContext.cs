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

        //public DbSet<Board> Board { get; set; } //The board is unique and dosen't need to be in the database

        public DbSet<Item> Item { get; set; }


        //public static void Initialize_DbContext_in_Startup(IServiceProvider serviceProvider)

        //{

        //    //--------< Initialize_DbContext_byStartup() >--------

        //    //*Set global dbContext. Initialized in startup.configure

        //    IServiceScope serviceScope = serviceProvider.GetService<IServiceScopeFactory>().CreateScope();

        //    dbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

        //    //--------< Initialize_DbContext_in_Startup() >--------

        //}
    }
}
