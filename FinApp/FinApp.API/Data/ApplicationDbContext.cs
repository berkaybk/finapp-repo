using FinApp.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FinApp.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
            
        }

        public DbSet<Agreement> Agreements { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<RiskAnalysis> RiskAnalyses { get; set; }
        public DbSet<FinancialStatement> FinancialStatements { get; set; }
    }
}
