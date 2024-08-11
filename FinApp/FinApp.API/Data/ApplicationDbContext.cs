using FinApp.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FinApp.API.Data {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) {

        }

        public DbSet<Agreement> Agreements { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<RiskAnalysis> RiskAnalyses { get; set; }
        public DbSet<FinancialStatement> FinancialStatements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            var riskLevels = new List<RiskLevel>() {
                new RiskLevel() {
                    Id=Guid.Parse("9c3a85c1-09bb-4742-9d05-e4e1d6db7dd3"),
                    Name="Low"
                },
                new RiskLevel() {
                    Id=Guid.Parse("f2ea49ae-1384-4f24-a0fb-6aac27ae76fb"),
                    Name="Medium"
                },
                new RiskLevel() {
                    Id=Guid.Parse("0b427ccc-94cd-47ed-b1e1-a2324c0ba332"),
                    Name="High"
                }
            };

            //Seed risk levels
            modelBuilder.Entity<RiskLevel>().HasData(riskLevels);
        }
    }
}
