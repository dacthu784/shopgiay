using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace shop_giay.Data;

public partial class ShopGiayContext : DbContext
{
    public ShopGiayContext()
    {
    }

    public ShopGiayContext(DbContextOptions<ShopGiayContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Anh> Anhs { get; set; }

    public virtual DbSet<ChiTietDonNhap> ChiTietDonNhaps { get; set; }

    public virtual DbSet<ChiTietOrder> ChiTietOrders { get; set; }

    public virtual DbSet<DonNhapHangHoa> DonNhapHangHoas { get; set; }

    public virtual DbSet<HinhAnhUser> HinhAnhUsers { get; set; }

    public virtual DbSet<LoaiGiay> LoaiGiays { get; set; }

    public virtual DbSet<LoaiUser> LoaiUsers { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<SanPhamGiay> SanPhamGiays { get; set; }

    public virtual DbSet<TinhTrangDon> TinhTrangDons { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=MSI\\SQLEXPRESS;Initial Catalog=ShopGiay;Integrated Security=True;Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Anh>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Idsanpham).HasColumnName("idsanpham");
            entity.Property(e => e.Url)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("url");

            entity.HasOne(d => d.IdsanphamNavigation).WithMany(p => p.Anhs)
                .HasForeignKey(d => d.Idsanpham)
                .HasConstraintName("FK_Anhs_SanPhamGiay");
        });

        modelBuilder.Entity<ChiTietDonNhap>(entity =>
        {
            entity.HasKey(e => e.IdChiTietDonNhap);

            entity.ToTable("ChiTietDonNhap");

            entity.HasIndex(e => e.IdDonNhapHangHoa, "IX_ChiTietDonNhap_IdDonNhapHangHoa");

            entity.HasIndex(e => e.IdSanPham, "IX_ChiTietDonNhap_IdSanPham");

            entity.Property(e => e.IdChiTietDonNhap).ValueGeneratedNever();
            entity.Property(e => e.Vat).HasColumnName("VAT");

            entity.HasOne(d => d.IdDonNhapHangHoaNavigation).WithMany(p => p.ChiTietDonNhaps)
                .HasForeignKey(d => d.IdDonNhapHangHoa)
                .HasConstraintName("FK_ChiTietDonNhap_DonNhapHangHoa");

            entity.HasOne(d => d.IdSanPhamNavigation).WithMany(p => p.ChiTietDonNhaps)
                .HasForeignKey(d => d.IdSanPham)
                .HasConstraintName("FK_ChiTietDonNhap_Products");
        });

        modelBuilder.Entity<ChiTietOrder>(entity =>
        {
            entity.HasKey(e => new { e.IdOrder, e.IdSanPham }).HasName("PK__OrderDet__08D097C1775FA1F0");

            entity.HasIndex(e => e.IdSanPham, "IX_ChiTietOrders_IdSanPham");

            entity.Property(e => e.Gia).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Idloai).HasColumnName("idloai");
            entity.Property(e => e.Ratting)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Review)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.ChiTietOrders)
                .HasForeignKey(d => d.IdOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__Order__4D94879B");

            entity.HasOne(d => d.IdSanPhamNavigation).WithMany(p => p.ChiTietOrders)
                .HasForeignKey(d => d.IdSanPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__Produ__4E88ABD4");

            entity.HasOne(d => d.IdloaiNavigation).WithMany(p => p.ChiTietOrders)
                .HasForeignKey(d => d.Idloai)
                .HasConstraintName("FK_ChiTietOrders_LoaiGiay");
        });

        modelBuilder.Entity<DonNhapHangHoa>(entity =>
        {
            entity.HasKey(e => e.IdDonNhap);

            entity.ToTable("DonNhapHangHoa");

            entity.HasIndex(e => e.IdNhaCungCap, "IX_DonNhapHangHoa_IdNhaCungCap");

            entity.HasIndex(e => e.IdTinhTrangDon, "IX_DonNhapHangHoa_IdTinhTrangDon");

            entity.Property(e => e.IdDonNhap).ValueGeneratedNever();
            entity.Property(e => e.NgayTaoDon).HasColumnType("date");

            entity.HasOne(d => d.IdNhaCungCapNavigation).WithMany(p => p.DonNhapHangHoas)
                .HasForeignKey(d => d.IdNhaCungCap)
                .HasConstraintName("FK_DonNhapHangHoa_NhaCungCap");

            entity.HasOne(d => d.IdTinhTrangDonNavigation).WithMany(p => p.DonNhapHangHoas)
                .HasForeignKey(d => d.IdTinhTrangDon)
                .HasConstraintName("FK_DonNhapHangHoa_TinhTrangDon");
        });

        modelBuilder.Entity<HinhAnhUser>(entity =>
        {
            entity.HasKey(e => e.IdHinhNguoiDung);

            entity.ToTable("HinhAnhUser");

            entity.Property(e => e.Iduser).HasColumnName("iduser");
            entity.Property(e => e.Isavarta).HasColumnName("isavarta");
            entity.Property(e => e.Urlimage)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("urlimage");

            entity.HasOne(d => d.IduserNavigation).WithMany(p => p.HinhAnhUsers)
                .HasForeignKey(d => d.Iduser)
                .HasConstraintName("FK_HinhAnhUser_Users1");
        });

        modelBuilder.Entity<LoaiGiay>(entity =>
        {
            entity.HasKey(e => e.IdLoaiGiay).HasName("PK__Categori__19093A2BCDB887AC");

            entity.ToTable("LoaiGiay");

            entity.Property(e => e.IdLoaiGiay).ValueGeneratedNever();
            entity.Property(e => e.MaLoaiGiay).HasMaxLength(100);
            entity.Property(e => e.TenLoaiGiay).HasMaxLength(10);
        });

        modelBuilder.Entity<LoaiUser>(entity =>
        {
            entity.HasKey(e => e.IdLoaiUser).HasName("PK_AdminActions");

            entity.Property(e => e.IdLoaiUser).ValueGeneratedNever();
            entity.Property(e => e.MaLoai)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TenLoai).HasMaxLength(50);
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.IdMessage).HasName("PK__Messages__C87C037CBA3A1542");

            entity.HasIndex(e => e.IdUser, "IX_Messages_IdUser");

            entity.Property(e => e.IdMessage).ValueGeneratedNever();
            entity.Property(e => e.DauThoiGian).HasColumnType("datetime");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Messages)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__Messages__UserID__160F4887");
        });

        modelBuilder.Entity<NhaCungCap>(entity =>
        {
            entity.HasKey(e => e.IdNhaCungCap);

            entity.ToTable("NhaCungCap");

            entity.Property(e => e.DiaChi).HasMaxLength(250);
            entity.Property(e => e.DienThoai)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TenNhaCungCap).HasMaxLength(250);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdOrder).HasName("PK__Orders__C3905BAF92E7B157");

            entity.HasIndex(e => e.IdUser, "IX_Orders_IdUser");

            entity.Property(e => e.IdOrder).ValueGeneratedNever();
            entity.Property(e => e.NgayOrder).HasColumnType("date");
            entity.Property(e => e.TongTien).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__Orders__UserID__4AB81AF0");
        });

        modelBuilder.Entity<SanPhamGiay>(entity =>
        {
            entity.HasKey(e => e.IdSanPham).HasName("PK__Products__B40CC6EDD6F49FBE");

            entity.ToTable("SanPhamGiay");

            entity.HasIndex(e => e.IdLoaiGiay, "IX_SanPhamGiay_IdLoaiGiay");

            entity.Property(e => e.IdSanPham).ValueGeneratedNever();
            entity.Property(e => e.Gia).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.GiamGia).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.MoTa).HasColumnType("text");
            entity.Property(e => e.TenSanPham)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdLoaiGiayNavigation).WithMany(p => p.SanPhamGiays)
                .HasForeignKey(d => d.IdLoaiGiay)
                .HasConstraintName("FK__Products__Catego__47DBAE45");
        });

        modelBuilder.Entity<TinhTrangDon>(entity =>
        {
            entity.HasKey(e => e.IdTinhTrangDon);

            entity.ToTable("TinhTrangDon");

            entity.Property(e => e.IdTinhTrangDon).ValueGeneratedNever();
            entity.Property(e => e.MaTinhTrang)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TenTinhTrang).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__Users__1788CCACEB6055B4");

            entity.HasIndex(e => e.IdLoaiUsers, "IX_Users_IdLoaiUsers");

            entity.Property(e => e.IdUser).ValueGeneratedNever();
            entity.Property(e => e.DiaChi)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IdLoaiUsers).HasDefaultValueSql("('User')");
            entity.Property(e => e.NgaySua).HasColumnType("date");
            entity.Property(e => e.NgayTao).HasColumnType("date");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TenUser)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdLoaiUsersNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdLoaiUsers)
                .HasConstraintName("FK__Users__LoaiUsers");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
