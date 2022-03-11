using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KazanSessionOne.Models
{
    public partial class Session1Context : DbContext
    {
        public Session1Context()
        {
        }

        public Session1Context(DbContextOptions<Session1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Asset> Assets { get; set; } = null!;
        public virtual DbSet<AssetGroup> AssetGroups { get; set; } = null!;
        public virtual DbSet<AssetPhoto> AssetPhotos { get; set; } = null!;
        public virtual DbSet<AssetTransferLog> AssetTransferLogs { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<DepartmentLocation> DepartmentLocations { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Image> Images { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=.;Database=Session1;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asset>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AssetGroupId).HasColumnName("AssetGroupID");

                entity.Property(e => e.AssetName).HasMaxLength(150);

                entity.Property(e => e.AssetSn)
                    .HasMaxLength(20)
                    .HasColumnName("AssetSN");

                entity.Property(e => e.DepartmentLocationId).HasColumnName("DepartmentLocationID");

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.WarrantyDate).HasColumnType("date");

                entity.HasOne(d => d.AssetGroup)
                    .WithMany(p => p.Assets)
                    .HasForeignKey(d => d.AssetGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Assets_AssetGroups");

                entity.HasOne(d => d.DepartmentLocation)
                    .WithMany(p => p.Assets)
                    .HasForeignKey(d => d.DepartmentLocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Assets_DepartmentLocations");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Assets)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Assets_Employees");
            });

            modelBuilder.Entity<AssetGroup>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<AssetPhoto>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AssetId).HasColumnName("AssetID");

                entity.Property(e => e.AssetPhoto1).HasColumnName("AssetPhoto");

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.AssetPhotos)
                    .HasForeignKey(d => d.AssetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AssetPhotos_Assets");
            });

            modelBuilder.Entity<AssetTransferLog>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AssetId).HasColumnName("AssetID");

                entity.Property(e => e.FromAssetSn)
                    .HasMaxLength(20)
                    .HasColumnName("FromAssetSN");

                entity.Property(e => e.FromDepartmentLocationId).HasColumnName("FromDepartmentLocationID");

                entity.Property(e => e.ToAssetSn)
                    .HasMaxLength(20)
                    .HasColumnName("ToAssetSN");

                entity.Property(e => e.ToDepartmentLocationId).HasColumnName("ToDepartmentLocationID");

                entity.Property(e => e.TransferDate).HasColumnType("date");

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.AssetTransferLogs)
                    .HasForeignKey(d => d.AssetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AssetTransfers_Assets");

                entity.HasOne(d => d.FromDepartmentLocation)
                    .WithMany(p => p.AssetTransferLogFromDepartmentLocations)
                    .HasForeignKey(d => d.FromDepartmentLocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AssetTransferLogs_DepartmentLocations");

                entity.HasOne(d => d.ToDepartmentLocation)
                    .WithMany(p => p.AssetTransferLogToDepartmentLocations)
                    .HasForeignKey(d => d.ToDepartmentLocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AssetTransferLogs_DepartmentLocations1");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<DepartmentLocation>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.DepartmentLocations)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DepartmentLocations_Departments");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.DepartmentLocations)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DepartmentLocations_Locations");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ContentType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
