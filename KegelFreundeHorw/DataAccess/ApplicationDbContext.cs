using KegelFreundeHorw.DataAccess;
using KegelFreundeHorw.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using KegelFreundeHorw.Models.Domain;

namespace KegelFreundeHorw
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public virtual DbSet<Photography> PhotoGraphys { get; set; }
        public virtual DbSet<Member> Members { get; set; }
    }
}
