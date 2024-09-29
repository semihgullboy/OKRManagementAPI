using Microsoft.EntityFrameworkCore;
using TekhnelogosOkr.Entity.Concrete;
using TekhnelogosOkr.Entity.Concrete.TekhnelogosOkr.Entity.Concrete;

namespace TekhnelogosOkr.DataAccess.Concrete.Context
{
    public class TekhnelogosOkrContext : DbContext
    {
        public TekhnelogosOkrContext()
        { }

        public TekhnelogosOkrContext(DbContextOptions<TekhnelogosOkrContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<CompanyObjective> CompanyObjectives { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<OkrObjective> OkrObjectives { get; set; }
        public DbSet<CompanyObjectiveOkrObjective> CompanyObjectiveOkrObjectives { get; set; }
        public DbSet<KeyResult> KeyResults { get; set; }
        public DbSet<OkrObjectiveUser> OkrObjectiveUsers { get; set; }
        public DbSet<Suggestion> Suggestions { get; set; }
        public DbSet<OkrObjectiveTransaction> OkrObjectiveTransactions { get; set; }
        public DbSet<KeyResultOkrObjective> KeyResultOkrObjectives {get; set; }
        public DbSet<KeyResultTransaction> KeyResultTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>().HasData(
                new Status { Id = 1, StatusName = "Devam Ediyor" },
                new Status { Id = 2, StatusName = "Tamamlandı" },
                new Status { Id = 3, StatusName = "Vazgeçildi" }
            );  
        }
    }
}