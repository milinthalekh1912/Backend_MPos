using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TCCPOS.Backend.InventoryService.Entities;

namespace TCCPOS.Backend.InventoryService.Infrastructure.Repository
{
    public partial class InventoryContext : DbContext
    {
        public InventoryContext()
        {
        }

        public InventoryContext(DbContextOptions<InventoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<category> category { get; set; } = null!;
        public virtual DbSet<deliverydetail> deliverydetail { get; set; } = null!;
        public virtual DbSet<deliverystatus> deliverystatus { get; set; } = null!;
        public virtual DbSet<employeelogin> employeelogin { get; set; } = null!;
        public virtual DbSet<employeetenant> employeetenant { get; set; } = null!;
        public virtual DbSet<merchant> merchant { get; set; } = null!;
        public virtual DbSet<merchantaddress> merchantaddress { get; set; } = null!;
        public virtual DbSet<merchantgroup> merchantgroup { get; set; } = null!;
        public virtual DbSet<order> order { get; set; } = null!;
        public virtual DbSet<orderdetail> orderdetail { get; set; } = null!;
        public virtual DbSet<paymentstatus> paymentstatus { get; set; } = null!;
        public virtual DbSet<point> point { get; set; } = null!;
        public virtual DbSet<pricetier> pricetier { get; set; } = null!;
        public virtual DbSet<pricetiergroup> pricetiergroup { get; set; } = null!;
        public virtual DbSet<promotion> promotion { get; set; } = null!;
        public virtual DbSet<rewardtarget> rewardtarget { get; set; } = null!;
        public virtual DbSet<sku> sku { get; set; } = null!;
        public virtual DbSet<supplier> supplier { get; set; } = null!;
        public virtual DbSet<unit> unit { get; set; } = null!;
        public virtual DbSet<user> user { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=mpostestdb.mysql.database.azure.com;port=3306;userid=myadmin;password=tccposP@ssw0rd;database=mpostest", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_as_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<category>(entity =>
            {
                entity.HasKey(e => e.category_id)
                    .HasName("PRIMARY");

                entity.UseCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.category_id).HasMaxLength(36);

                entity.Property(e => e.created_by).HasMaxLength(255);

                entity.Property(e => e.created_date).HasColumnType("datetime");

                entity.Property(e => e.description).HasMaxLength(255);

                entity.Property(e => e.en_name).HasMaxLength(255);

                entity.Property(e => e.image_url).HasColumnType("text");

                entity.Property(e => e.supplier_id).HasMaxLength(36);

                entity.Property(e => e.th_name).HasMaxLength(255);

                entity.Property(e => e.updated_by).HasMaxLength(255);

                entity.Property(e => e.updated_date).HasColumnType("datetime");
            });

            modelBuilder.Entity<deliverydetail>(entity =>
            {
                entity.HasKey(e => e.delivery_detail_id)
                    .HasName("PRIMARY");

                entity.UseCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.delivery_detail_id).HasMaxLength(36);

                entity.Property(e => e.due_date).HasColumnType("datetime");

                entity.Property(e => e.estimate_date).HasColumnType("datetime");

                entity.Property(e => e.note).HasMaxLength(100);

                entity.Property(e => e.order_id).HasMaxLength(36);
            });

            modelBuilder.Entity<deliverystatus>(entity =>
            {
                entity.HasNoKey();

                entity.HasComment("ตารางไว้เก็บคำอธิบาย status ของ delivery")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.status_description).HasMaxLength(100);
            });

            modelBuilder.Entity<employeelogin>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PRIMARY");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Username)
                    .HasMaxLength(25)
                    .HasDefaultValueSql("''")
                    .UseCollation("utf8mb4_unicode_ci")
                    .HasCharSet("utf8mb4");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(25)
                    .UseCollation("utf8mb4_unicode_ci")
                    .HasCharSet("utf8mb4");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .UseCollation("utf8mb4_unicode_ci")
                    .HasCharSet("utf8mb4");
            });

            modelBuilder.Entity<employeetenant>(entity =>
            {
                entity.HasKey(e => e.TanantID)
                    .HasName("PRIMARY");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.AgentName).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<merchant>(entity =>
            {
                entity.HasKey(e => e.merchant_id)
                    .HasName("PRIMARY");

                entity.UseCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.merchant_id).HasMaxLength(36);

                entity.Property(e => e.created_by).HasMaxLength(255);

                entity.Property(e => e.created_date).HasColumnType("datetime");

                entity.Property(e => e.merchant_group_id).HasMaxLength(36);

                entity.Property(e => e.merchant_name).HasMaxLength(36);

                entity.Property(e => e.price_tier_id)
                    .HasMaxLength(36)
                    .HasDefaultValueSql("'DEFAULT'");

                entity.Property(e => e.updated_by).HasMaxLength(255);

                entity.Property(e => e.updated_date).HasColumnType("datetime");
            });

            modelBuilder.Entity<merchantaddress>(entity =>
            {
                entity.HasKey(e => e.address_id)
                    .HasName("PRIMARY");

                entity.UseCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.address_id).HasMaxLength(36);

                entity.Property(e => e.address1).HasMaxLength(255);

                entity.Property(e => e.address2).HasMaxLength(255);

                entity.Property(e => e.address3).HasMaxLength(255);

                entity.Property(e => e.address_title).HasMaxLength(255);

                entity.Property(e => e.created_by).HasMaxLength(255);

                entity.Property(e => e.created_date).HasColumnType("datetime");

                entity.Property(e => e.merchant_id).HasMaxLength(36);

                entity.Property(e => e.phone_number).HasMaxLength(10);

                entity.Property(e => e.updated_by).HasMaxLength(255);

                entity.Property(e => e.updated_date).HasColumnType("datetime");

                entity.Property(e => e.zipcode).HasMaxLength(5);
            });

            modelBuilder.Entity<merchantgroup>(entity =>
            {
                entity.HasKey(e => e.merchant_group_id)
                    .HasName("PRIMARY");

                entity.UseCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.merchant_group_id).HasMaxLength(36);

                entity.Property(e => e.created_by).HasMaxLength(255);

                entity.Property(e => e.created_date).HasColumnType("datetime");

                entity.Property(e => e.group_name).HasMaxLength(255);

                entity.Property(e => e.updated_by).HasMaxLength(255);

                entity.Property(e => e.updated_date).HasColumnType("datetime");
            });

            modelBuilder.Entity<order>(entity =>
            {
                entity.HasKey(e => e.order_id)
                    .HasName("PRIMARY");

                entity.UseCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.order_id).HasMaxLength(36);

                entity.Property(e => e.address_id).HasMaxLength(36);

                entity.Property(e => e.coupon_id).HasMaxLength(36);

                entity.Property(e => e.created_by).HasMaxLength(255);

                entity.Property(e => e.created_date).HasColumnType("datetime");

                entity.Property(e => e.delivery_detail_id).HasMaxLength(36);

                entity.Property(e => e.merchant_id).HasMaxLength(36);

                entity.Property(e => e.order_no).HasMaxLength(45);

                entity.Property(e => e.supplier_id).HasMaxLength(36);

                entity.Property(e => e.updated_by).HasMaxLength(255);

                entity.Property(e => e.updated_date).HasColumnType("datetime");

                entity.Property(e => e.user_id).HasMaxLength(36);
            });

            modelBuilder.Entity<orderdetail>(entity =>
            {
                entity.HasKey(e => e.order_item_id)
                    .HasName("PRIMARY");

                entity.UseCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.order_item_id).HasMaxLength(36);

                entity.Property(e => e.created_by).HasMaxLength(255);

                entity.Property(e => e.created_date).HasColumnType("datetime");

                entity.Property(e => e.order_id).HasMaxLength(36);

                entity.Property(e => e.promotion_id).HasMaxLength(36);

                entity.Property(e => e.sku_id).HasMaxLength(36);

                entity.Property(e => e.title).HasMaxLength(255);

                entity.Property(e => e.updated_by).HasMaxLength(255);

                entity.Property(e => e.updated_date).HasColumnType("datetime");
            });

            modelBuilder.Entity<paymentstatus>(entity =>
            {
                entity.HasKey(e => e.payment_status_id)
                    .HasName("PRIMARY");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.status_description).HasMaxLength(255);
            });

            modelBuilder.Entity<point>(entity =>
            {
                entity.HasKey(e => e.point1)
                    .HasName("PRIMARY");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.point1)
                    .ValueGeneratedNever()
                    .HasColumnName("point");

                entity.Property(e => e.created_by).HasMaxLength(36);

                entity.Property(e => e.created_date).HasColumnType("datetime");

                entity.Property(e => e.exp_date).HasColumnType("datetime");

                entity.Property(e => e.shop_id).HasMaxLength(36);
            });

            modelBuilder.Entity<pricetier>(entity =>
            {
                entity.HasKey(e => new { e.price_tier_group_id, e.sku_id })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.UseCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.price_tier_group_id).HasMaxLength(36);

                entity.Property(e => e.sku_id).HasMaxLength(36);

                entity.Property(e => e.created_by).HasMaxLength(255);

                entity.Property(e => e.created_date).HasColumnType("datetime");

                entity.Property(e => e.updated_by).HasMaxLength(255);

                entity.Property(e => e.updated_date).HasColumnType("datetime");
            });

            modelBuilder.Entity<pricetiergroup>(entity =>
            {
                entity.UseCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.id).HasMaxLength(36);

                entity.Property(e => e.created_by).HasMaxLength(255);

                entity.Property(e => e.created_date).HasColumnType("datetime");

                entity.Property(e => e.description).HasMaxLength(255);

                entity.Property(e => e.price_tier_title).HasMaxLength(36);

                entity.Property(e => e.supplier_id).HasMaxLength(36);

                entity.Property(e => e.updated_by).HasMaxLength(255);

                entity.Property(e => e.updated_date).HasColumnType("datetime");
            });

            modelBuilder.Entity<promotion>(entity =>
            {
                entity.HasKey(e => e.promotion_id)
                    .HasName("PRIMARY");

                entity.UseCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.promotion_id).HasMaxLength(36);

                entity.Property(e => e.conditions).HasColumnType("text");

                entity.Property(e => e.created_by).HasMaxLength(255);

                entity.Property(e => e.created_date).HasColumnType("datetime");

                entity.Property(e => e.description).HasMaxLength(1024);

                entity.Property(e => e.end_date).HasColumnType("datetime");

                entity.Property(e => e.start_date).HasColumnType("datetime");

                entity.Property(e => e.supplier_id).HasMaxLength(36);

                entity.Property(e => e.updated_by).HasMaxLength(255);

                entity.Property(e => e.updated_date).HasColumnType("datetime");
            });

            modelBuilder.Entity<rewardtarget>(entity =>
            {
                entity.HasKey(e => new { e.reward_id, e.shop_group_id, e.sku_id })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.UseCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.reward_id).HasMaxLength(36);

                entity.Property(e => e.shop_group_id).HasMaxLength(36);

                entity.Property(e => e.sku_id).HasMaxLength(36);

                entity.Property(e => e.created_by).HasMaxLength(255);

                entity.Property(e => e.created_date).HasColumnType("datetime");

                entity.Property(e => e.end_date).HasColumnType("datetime");

                entity.Property(e => e.reward).HasMaxLength(100);

                entity.Property(e => e.start_date).HasColumnType("datetime");

                entity.Property(e => e.updated_by).HasMaxLength(255);

                entity.Property(e => e.updated_date).HasColumnType("datetime");
            });

            modelBuilder.Entity<sku>(entity =>
            {
                entity.HasKey(e => e.sku_id)
                    .HasName("PRIMARY");

                entity.UseCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.sku_id).HasMaxLength(36);

                entity.Property(e => e.alias_title).HasMaxLength(100);

                entity.Property(e => e.barcode).HasMaxLength(36);

                entity.Property(e => e.barcode_url).HasMaxLength(100);

                entity.Property(e => e.category_id).HasMaxLength(100);

                entity.Property(e => e.created_by).HasMaxLength(255);

                entity.Property(e => e.created_date).HasColumnType("datetime");

                entity.Property(e => e.image_url).HasMaxLength(100);

                entity.Property(e => e.supplier_id).HasMaxLength(100);

                entity.Property(e => e.title).HasMaxLength(100);

                entity.Property(e => e.unit_id).HasMaxLength(36);

                entity.Property(e => e.updated_by).HasMaxLength(255);

                entity.Property(e => e.updated_date).HasColumnType("datetime");
            });

            modelBuilder.Entity<supplier>(entity =>
            {
                entity.HasKey(e => e.supplier_id)
                    .HasName("PRIMARY");

                entity.UseCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.supplier_id).HasMaxLength(36);

                entity.Property(e => e.DocNo).HasMaxLength(6);

                entity.Property(e => e.created_by).HasMaxLength(255);

                entity.Property(e => e.created_date).HasColumnType("datetime");

                entity.Property(e => e.supplier_image).HasColumnType("text");

                entity.Property(e => e.supplier_name).HasMaxLength(36);

                entity.Property(e => e.updated_by).HasMaxLength(255);

                entity.Property(e => e.updated_date).HasColumnType("datetime");
            });

            modelBuilder.Entity<unit>(entity =>
            {
                entity.HasKey(e => e.unit_id)
                    .HasName("PRIMARY");

                entity.UseCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.unit_id).HasMaxLength(36);

                entity.Property(e => e.created_by).HasMaxLength(255);

                entity.Property(e => e.created_date).HasColumnType("datetime");

                entity.Property(e => e.unit1).HasColumnName("unit");

                entity.Property(e => e.unit_name).HasMaxLength(255);

                entity.Property(e => e.updated_by).HasMaxLength(255);

                entity.Property(e => e.updated_date).HasColumnType("datetime");
            });

            modelBuilder.Entity<user>(entity =>
            {
                entity.UseCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.id).HasMaxLength(36);

                entity.Property(e => e.authtype).HasMaxLength(1);

                entity.Property(e => e.created_by).HasMaxLength(255);

                entity.Property(e => e.created_date).HasColumnType("datetime");

                entity.Property(e => e.line_sub_Id).HasMaxLength(36);

                entity.Property(e => e.password).HasMaxLength(36);

                entity.Property(e => e.shop_id).HasMaxLength(36);

                entity.Property(e => e.updated_by).HasMaxLength(255);

                entity.Property(e => e.updated_date).HasColumnType("datetime");

                entity.Property(e => e.username).HasMaxLength(36);

                entity.Property(e => e.usertype).HasMaxLength(36);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
