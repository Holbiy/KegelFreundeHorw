using KegelFreundeHorw.DataAccess;
using KegelFreundeHorw.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
namespace KegelFreundeHorw
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public virtual DbSet<Photography> PhotoGraphys { get; set; }
    }
}
