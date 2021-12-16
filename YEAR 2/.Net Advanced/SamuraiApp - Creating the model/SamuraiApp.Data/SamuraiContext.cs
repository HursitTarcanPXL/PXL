﻿using Microsoft.EntityFrameworkCore;
using SamuraiApp.Domain;

namespace SamuraiApp.Data
{
  public class SamuraiContext : DbContext
  {
    public DbSet<Samurai> Samurais { get; set; }
    public DbSet<Quote> Quotes { get; set; }
    public DbSet<Clan> Clans { get; set; }
    public DbSet<Battle> Battles { get; set; }
   
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(
          "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = SamuraiAppData");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<SamuraiBattle>().HasKey(s => new { s.SamuraiId, s.BattleId });
      modelBuilder.Entity<Horse>().ToTable("Horses");
    }
  }
}