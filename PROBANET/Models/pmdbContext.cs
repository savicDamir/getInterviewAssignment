using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PROBANET.Models
{
    public partial class pmdbContext : DbContext
    {
        public pmdbContext()
        {
        }

        public pmdbContext(DbContextOptions<pmdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;database=pmdb;user=root;password=1234", Microsoft.EntityFrameworkCore.ServerVersion.FromString("8.0.22-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("project");

                entity.HasIndex(e => e.Code, "code")
                    .IsUnique();

                entity.HasIndex(e => e.ManId, "id_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnType("varchar(10)")
                    .HasColumnName("code")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ManId).HasColumnName("manId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasColumnName("name")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Man)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.ManId)
                    .HasConstraintName("id");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("task");

                entity.HasIndex(e => e.Assigned, "devId_idx");

                entity.HasIndex(e => e.ProId, "proId_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Assigned).HasColumnName("assigned");

                entity.Property(e => e.Deadline)
                    .HasColumnType("date")
                    .HasColumnName("deadline");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasColumnName("description")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Progress).HasColumnName("progress");

                entity.Property(e => e.ProId).IsRequired().HasColumnName("proId");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnType("enum('new','in progress','finished')")
                    .HasColumnName("status")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.AssignedNavigation)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.Assigned)
                    .HasConstraintName("devId");

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.ProId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("proId");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.Username, "username")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(25)")
                    .HasColumnName("email")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(25)")
                    .HasColumnName("name")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("varchar(25)")
                    .HasColumnName("password")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasColumnType("enum('Administrator','Project Manager','Developer')")
                    .HasColumnName("role")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnType("varchar(25)")
                    .HasColumnName("surname")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnType("varchar(25)")
                    .HasColumnName("username")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
