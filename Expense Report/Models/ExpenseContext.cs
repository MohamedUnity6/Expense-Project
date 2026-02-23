using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Expense_Report.Models;

public partial class ExpenseContext : DbContext
{
    public ExpenseContext()
    {
    }

    public ExpenseContext(DbContextOptions<ExpenseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ExpenseReport> ExpenseReports { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Expense;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExpenseReport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__expense___3214EC072AD2F568");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
