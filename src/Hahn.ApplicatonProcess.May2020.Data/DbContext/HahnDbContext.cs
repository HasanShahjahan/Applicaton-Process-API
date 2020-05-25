using Hahn.ApplicatonProcess.May2020.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicatonProcess.May2020.Data.DbContext
{
    public class HahnDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public HahnDbContext(DbContextOptions<HahnDbContext> options) : base(options)
        {
        }
        public DbSet<Applicant> Applicants { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}