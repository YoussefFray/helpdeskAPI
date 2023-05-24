using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Models;

public partial class HelpDeskContext : DbContext
{
    public HelpDeskContext()
    {
    }

    public HelpDeskContext(DbContextOptions<HelpDeskContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ActionCorrective> ActionCorrectives { get; set; }

    public virtual DbSet<Complaint> Complaints { get; set; }

    public virtual DbSet<Technician> Technicians { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:HelpDesk");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActionCorrective>(entity =>
        {
            entity.HasKey(e => e.ActionId).HasName("PK__ActionCo__A119639211A36DFE");

            entity.Property(e => e.ActionId).ValueGeneratedNever();

            entity.HasOne(d => d.Complaint).WithMany(p => p.ActionCorrectives).HasConstraintName("FK__ActionCor__Compl__3E52440B");

            entity.HasOne(d => d.Technician).WithMany(p => p.ActionCorrectives).HasConstraintName("FK__ActionCor__Techn__3F466844");
        });

        modelBuilder.Entity<Complaint>(entity =>
        {
            entity.HasKey(e => e.ComplaintId).HasName("PK__Complain__0C536DA653105E67");

            entity.Property(e => e.ComplaintId).ValueGeneratedNever();

            entity.HasOne(d => d.User).WithMany(p => p.Complaints).HasConstraintName("FK__Complaint__User___398D8EEE");
        });

        modelBuilder.Entity<Technician>(entity =>
        {
            entity.HasKey(e => e.TechnicianId).HasName("PK__Technici__E704242349AC8349");

            entity.Property(e => e.TechnicianId).ValueGeneratedNever();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__206D91904F403043");

            entity.Property(e => e.UserId).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
