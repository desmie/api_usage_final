using Microsoft.EntityFrameworkCore;
using API_Usage.Models;

namespace API_Usage.DataAccess
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Company> Companies { get; set; }
    public DbSet<Equity> Equities { get; set; }
    public DbSet<SectorPerformance_Model> SectorPerform { get; set; }
    public DbSet<Dividend_Model> Dividend { get; set; }
    public DbSet<News_Model> News { get; set; }
    public DbSet<Infocus_Model> InFocus { get; set; }
    public DbSet<Gainers_Model> Gainers { get; set; }
    public DbSet<Historical_Summary> History { get; set; }
    }
}