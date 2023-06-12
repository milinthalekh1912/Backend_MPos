using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TCCPOS.Backend.SecurityService.Entities;

namespace TCCPOS.Backend.SecurityService.Infrastructure.Repository
{
    public partial class SecurityContext : DbContext
    {
        public SecurityContext()
        {
        }

        public SecurityContext(DbContextOptions<SecurityContext> options)
            : base(options)
        {
        }

        public virtual DbSet<branch> branch { get; set; } = null!;
        public virtual DbSet<currentversion> currentversion { get; set; } = null!;
        public virtual DbSet<customer> customer { get; set; } = null!;
        public virtual DbSet<customer_address> customer_address { get; set; } = null!;
        public virtual DbSet<merchant> merchant { get; set; } = null!;
        public virtual DbSet<payment> payment { get; set; } = null!;
        public virtual DbSet<posclient> posclient { get; set; } = null!;
        public virtual DbSet<saleitem> saleitem { get; set; } = null!;
        public virtual DbSet<saleorder> saleorder { get; set; } = null!;
        public virtual DbSet<sku> sku { get; set; } = null!;
        public virtual DbSet<sku_branch_price> sku_branch_price { get; set; } = null!;
        public virtual DbSet<third_party_login> third_party_login { get; set; } = null!;
        public virtual DbSet<useraccount> useraccount { get; set; } = null!;
        public virtual DbSet<useractivity> useractivity { get; set; } = null!;
        public virtual DbSet<userlogin> userlogin { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=127.0.0.1;port=3306;userid=root;password=root;database=backendmpos", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<branch>(entity =>
            {
                entity.UseCollation("utf8mb4_0900_as_ci");

                entity.Property(e => e.BranchID).HasMaxLength(36);

                entity.Property(e => e.AccountCode).HasMaxLength(255);

                entity.Property(e => e.AccountName).HasMaxLength(255);

                entity.Property(e => e.BranchAddress).HasMaxLength(255);

                entity.Property(e => e.BranchAddress2).HasMaxLength(255);

                entity.Property(e => e.BranchDistrict).HasMaxLength(30);

                entity.Property(e => e.BranchEmail).HasMaxLength(50);

                entity.Property(e => e.BranchName).HasMaxLength(50);

                entity.Property(e => e.BranchNo).HasMaxLength(10);

                entity.Property(e => e.BranchProvince).HasMaxLength(30);

                entity.Property(e => e.BranchSubdistrict).HasMaxLength(30);

                entity.Property(e => e.BranchZipcode).HasMaxLength(10);

                entity.Property(e => e.MerchantID).HasMaxLength(36);
            });

            modelBuilder.Entity<currentversion>(entity =>
            {
                entity.HasNoKey();

                entity.UseCollation("utf8mb4_0900_as_ci");
            });

            modelBuilder.Entity<customer>(entity =>
            {
                entity.Property(e => e.CustomerID).HasMaxLength(36);

                entity.Property(e => e.BranchID).HasMaxLength(36);

                entity.Property(e => e.BranchNo).HasMaxLength(5);

                entity.Property(e => e.CreateBy).HasMaxLength(255);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Fax).HasMaxLength(50);

                entity.Property(e => e.MerchantID).HasMaxLength(36);

                entity.Property(e => e.Mobile).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.TaxID).HasMaxLength(13);

                entity.Property(e => e.Tel).HasMaxLength(50);

                entity.Property(e => e.UpdateBy).HasMaxLength(255);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<customer_address>(entity =>
            {
                entity.HasKey(e => e.CustomerAddressID)
                    .HasName("PRIMARY");

                entity.Property(e => e.CustomerAddressID).HasMaxLength(36);

                entity.Property(e => e.Address1).HasMaxLength(255);

                entity.Property(e => e.Address2).HasMaxLength(255);

                entity.Property(e => e.CreateBy).HasMaxLength(255);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CustomerID).HasMaxLength(36);

                entity.Property(e => e.District).HasMaxLength(255);

                entity.Property(e => e.Province).HasMaxLength(255);

                entity.Property(e => e.Subdistrict).HasMaxLength(255);

                entity.Property(e => e.UpdateBy).HasMaxLength(255);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.Zipcode).HasMaxLength(5);
            });

            modelBuilder.Entity<merchant>(entity =>
            {
                entity.UseCollation("utf8mb4_0900_as_ci");

                entity.Property(e => e.MerchantID).HasMaxLength(36);

                entity.Property(e => e.MerchantAddress).HasMaxLength(255);

                entity.Property(e => e.MerchantName).HasMaxLength(255);

                entity.Property(e => e.MerchantTel).HasMaxLength(50);

                entity.Property(e => e.TaxID).HasMaxLength(20);
            });

            modelBuilder.Entity<payment>(entity =>
            {
                entity.HasNoKey();

                entity.UseCollation("utf8mb4_0900_as_ci");

                entity.Property(e => e.Amount).HasPrecision(16, 4);

                entity.Property(e => e.AmountRecieve).HasPrecision(16, 4);

                entity.Property(e => e.BranchID).HasMaxLength(36);

                entity.Property(e => e.CreateBy).HasMaxLength(36);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.MerchantID).HasMaxLength(36);

                entity.Property(e => e.POSClientID).HasMaxLength(36);

                entity.Property(e => e.PaymentID).HasMaxLength(36);

                entity.Property(e => e.SaleOrderID).HasMaxLength(36);

                entity.Property(e => e.VoidBy).HasMaxLength(36);

                entity.Property(e => e.VoidDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<posclient>(entity =>
            {
                entity.UseCollation("utf8mb4_0900_as_ci");

                entity.Property(e => e.POSClientID).HasMaxLength(36);

                entity.Property(e => e.BranchID).HasMaxLength(36);

                entity.Property(e => e.CustomerID).HasMaxLength(36);

                entity.Property(e => e.FRPOSRunning).HasMaxLength(5);

                entity.Property(e => e.MerchantID).HasMaxLength(36);

                entity.Property(e => e.POSRunning).HasMaxLength(5);

                entity.Property(e => e.RDNumber).HasMaxLength(36);
            });

            modelBuilder.Entity<saleitem>(entity =>
            {
                entity.HasNoKey();

                entity.UseCollation("utf8mb4_0900_as_ci");

                entity.Property(e => e.AfterVat).HasPrecision(16, 4);

                entity.Property(e => e.AliasTitle).HasMaxLength(255);

                entity.Property(e => e.Barcode).HasMaxLength(36);

                entity.Property(e => e.BeforeVat).HasPrecision(16, 4);

                entity.Property(e => e.BranchID).HasMaxLength(36);

                entity.Property(e => e.CompCode).HasMaxLength(36);

                entity.Property(e => e.CreateBy).HasMaxLength(36);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.FullPrice).HasPrecision(16, 4);

                entity.Property(e => e.MerchantID).HasMaxLength(36);

                entity.Property(e => e.POSClientID).HasMaxLength(36);

                entity.Property(e => e.Price).HasPrecision(16, 4);

                entity.Property(e => e.Quantity).HasPrecision(16, 4);

                entity.Property(e => e.SKUID).HasMaxLength(36);

                entity.Property(e => e.SaleItemID).HasMaxLength(36);

                entity.Property(e => e.SaleOrderID).HasMaxLength(36);

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.Property(e => e.VoidBy).HasMaxLength(36);

                entity.Property(e => e.VoidDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<saleorder>(entity =>
            {
                entity.HasNoKey();

                entity.UseCollation("utf8mb4_0900_as_ci");

                entity.Property(e => e.BeforeVAT).HasPrecision(16, 4);

                entity.Property(e => e.BranchID).HasMaxLength(36);

                entity.Property(e => e.CreateBy).HasMaxLength(36);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DocNo).HasMaxLength(16);

                entity.Property(e => e.MemberID).HasMaxLength(36);

                entity.Property(e => e.MerchantID).HasMaxLength(36);

                entity.Property(e => e.POSClientID).HasMaxLength(36);

                entity.Property(e => e.POSSessionID).HasMaxLength(36);

                entity.Property(e => e.SaleOrderID).HasMaxLength(36);

                entity.Property(e => e.TotalDiscount).HasColumnType("decimal(10,0) unsigned");

                entity.Property(e => e.TotalSale).HasPrecision(16, 4);

                entity.Property(e => e.VATSale).HasPrecision(16, 4);

                entity.Property(e => e.VoidBy).HasMaxLength(36);

                entity.Property(e => e.VoidDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<sku>(entity =>
            {
                entity.HasNoKey();

                entity.UseCollation("utf8mb4_0900_as_ci");

                entity.Property(e => e.AliasTitle).HasMaxLength(255);

                entity.Property(e => e.Barcode).HasMaxLength(20);

                entity.Property(e => e.CreateBy).HasMaxLength(36);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.MapSKU).HasMaxLength(36);

                entity.Property(e => e.MerchantID).HasMaxLength(36);

                entity.Property(e => e.PackSize).HasMaxLength(255);

                entity.Property(e => e.SKUID).HasMaxLength(36);

                entity.Property(e => e.Title).HasMaxLength(255);
            });

            modelBuilder.Entity<sku_branch_price>(entity =>
            {
                entity.HasKey(e => new { e.SKUID, e.MerchantID, e.BranchID })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.UseCollation("utf8mb4_0900_as_ci");

                entity.Property(e => e.SKUID).HasMaxLength(36);

                entity.Property(e => e.MerchantID).HasMaxLength(36);

                entity.Property(e => e.BranchID).HasMaxLength(36);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Price).HasPrecision(16, 4);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<third_party_login>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CreateBy).HasMaxLength(255);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.LoginID).HasMaxLength(36);

                entity.Property(e => e.ProviderName).HasMaxLength(255);

                entity.Property(e => e.UserID).HasMaxLength(36);
            });

            modelBuilder.Entity<useraccount>(entity =>
            {
                entity.HasKey(e => e.UserID)
                    .HasName("PRIMARY");

                entity.UseCollation("utf8mb4_0900_as_ci");

                entity.Property(e => e.UserID).HasMaxLength(36);

                entity.Property(e => e.AuthType).HasMaxLength(1);

                entity.Property(e => e.CreateBy).HasMaxLength(36);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.LastLogin).HasColumnType("datetime");

                entity.Property(e => e.Login).HasMaxLength(255);

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.UpdateBy).HasMaxLength(36);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserType).HasMaxLength(1);
            });

            modelBuilder.Entity<useractivity>(entity =>
            {
                entity.HasKey(e => e.UAID)
                    .HasName("PRIMARY");

                entity.UseCollation("utf8mb4_0900_as_ci");

                entity.Property(e => e.Activity).HasMaxLength(255);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Note1).HasMaxLength(255);

                entity.Property(e => e.POSClientID).HasMaxLength(36);

                entity.Property(e => e.POSSessionID).HasMaxLength(36);

                entity.Property(e => e.UserID).HasMaxLength(36);
            });

            modelBuilder.Entity<userlogin>(entity =>
            {
                entity.HasKey(e => e.UserID)
                    .HasName("PRIMARY");

                entity.UseCollation("utf8mb4_0900_as_ci");

                entity.Property(e => e.UserID).HasMaxLength(36);

                entity.Property(e => e.LastLogin).HasColumnType("datetime");

                entity.Property(e => e.LastLogout).HasColumnType("datetime");

                entity.Property(e => e.POSClientID).HasMaxLength(36);

                entity.Property(e => e.Version).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
