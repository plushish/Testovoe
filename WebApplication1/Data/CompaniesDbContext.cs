using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data;

public partial class CompaniesDbContext : DbContext
{
    public CompaniesDbContext()
    {
    }

    public CompaniesDbContext(DbContextOptions<CompaniesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //    => optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=DB;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Companie__3214EC07DB7CBA1B");

            entity.HasIndex(e => e.NameFull, "UQ__Companie__AB0F8EF5703FEEDA").IsUnique();

            entity.HasIndex(e => e.Ogrn, "UQ__Companie__ADEA7DF8115A984A").IsUnique();

            entity.HasIndex(e => e.Inn, "UQ__Companie__C490CCF5E79C83AD").IsUnique();

            entity.Property(e => e.Inn).HasColumnName("Inn")
                .HasMaxLength(12)
                .IsFixedLength(); ;
            entity.Property(e => e.NameFull)
                .HasMaxLength(30)
                .IsFixedLength();
            entity.Property(e => e.NameShort)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.Ogrn)
                .HasMaxLength(15)
                .IsFixedLength()
                .HasColumnName("Ogrn");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
//using WebApplication1.Models;
//using Microsoft.EntityFrameworkCore;

//namespace WebApplication1.Data
//{
//    public class CompaniesDBContext : DbContext
//    {
//        public CompaniesDBContext(DbContextOptions<CompaniesDBContext> options) : base(options)
//        {
//        }

//        public DbSet<BD> BD { get; set; }
//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<BD>().ToTable("Companies");
//        }
//    }
//}