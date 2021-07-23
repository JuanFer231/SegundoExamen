using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Examen_ll.Models;

namespace Examen_ll.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Examen_ll.Models.TareaCategoria> TareaCategoria { get; set; }
        public DbSet<Examen_ll.Models.Tareas> Tareas { get; set; }
        
    }
}
