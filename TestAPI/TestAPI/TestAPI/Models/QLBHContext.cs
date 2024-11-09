using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TestAPI.Models
{
    public partial class QLBHContext : DbContext
    {
        public QLBHContext()
        {
        }

        public QLBHContext(DbContextOptions<QLBHContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ctdh> Ctdhs { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=QLBH;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Ctdh>(entity =>
            {
                entity.HasKey(e => new { e.MaSp, e.MaDh })
                    .HasName("PK__CTDH__2557507A143B2BAE");

                entity.ToTable("CTDH");

                entity.Property(e => e.MaSp).HasColumnName("MaSP");

                entity.Property(e => e.MaDh).HasColumnName("MaDH");

                entity.Property(e => e.GiaBan).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.HasOne(d => d.MaDhNavigation)
                    .WithMany(p => p.Ctdhs)
                    .HasForeignKey(d => d.MaDh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CTDH_DonHang");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.Ctdhs)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CTDH_SanPham");
            });

            modelBuilder.Entity<DonHang>(entity =>
            {
                entity.HasKey(e => e.MaDh)
                    .HasName("PK__DonHang__2725866160A325E0");

                entity.ToTable("DonHang");

                entity.Property(e => e.MaDh).HasColumnName("MaDH");

                entity.Property(e => e.MaNv).HasColumnName("MaNV");

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.DonHangs)
                    .HasForeignKey(d => d.MaNv)
                    .HasConstraintName("FK_DonHang_NhanVien");
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.MaNv)
                    .HasName("PK__NhanVien__2725D70AB1558EB9");

                entity.ToTable("NhanVien");

                entity.Property(e => e.MaNv).HasColumnName("MaNV");

                entity.Property(e => e.TenNv)
                    .HasMaxLength(20)
                    .HasColumnName("TenNV");
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.MaSp)
                    .HasName("PK__SanPham__2725081CFE68A564");

                entity.ToTable("SanPham");

                entity.Property(e => e.MaSp).HasColumnName("MaSP");

                entity.Property(e => e.GiaMua).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.TenSp)
                    .HasMaxLength(20)
                    .HasColumnName("tenSP");
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.HasKey(e => e.TenDn)
                    .HasName("PK__TaiKhoan__4CF96559697EB0A9");

                entity.ToTable("TaiKhoan");

                entity.Property(e => e.TenDn)
                    .HasMaxLength(20)
                    .HasColumnName("TenDN");

                entity.Property(e => e.MaNv).HasColumnName("MaNV");

                entity.Property(e => e.MatKhau).HasMaxLength(20);

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.TaiKhoans)
                    .HasForeignKey(d => d.MaNv)
                    .HasConstraintName("FK_TaiKhoan_NhanVien");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
