using Microsoft.EntityFrameworkCore;
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

        public virtual DbSet<branch_location> branch_location { get; set; } = null!;
        public virtual DbSet<document_type> document_type { get; set; } = null!;
        public virtual DbSet<goods_received> goods_received { get; set; } = null!;
        public virtual DbSet<goods_received_detail> goods_received_detail { get; set; } = null!;
        public virtual DbSet<inventory_config> inventory_config { get; set; } = null!;
        public virtual DbSet<mmdoc> mmdoc { get; set; } = null!;
        public virtual DbSet<mmitem> mmitem { get; set; } = null!;
        public virtual DbSet<mmstatus> mmstatus { get; set; } = null!;
        public virtual DbSet<movement_header> movement_header { get; set; } = null!;
        public virtual DbSet<movement_header_detail> movement_header_detail { get; set; } = null!;
        public virtual DbSet<physical_count> physical_count { get; set; } = null!;
        public virtual DbSet<physical_count_detail> physical_count_detail { get; set; } = null!;
        public virtual DbSet<reordering_point_report> reordering_point_report { get; set; } = null!;
        public virtual DbSet<sku_branch_inventory> sku_branch_inventory { get; set; } = null!;
        public virtual DbSet<sku_branch_inventory_config> sku_branch_inventory_config { get; set; } = null!;
        public virtual DbSet<supplier> supplier { get; set; } = null!;
        public virtual DbSet<supplier_address> supplier_address { get; set; } = null!;
        public virtual DbSet<supplier_branch> supplier_branch { get; set; } = null!;
        public virtual DbSet<supplier_sku> supplier_sku { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=backendposdev.mysql.database.azure.com;port=3306;userid=myadmin;password=tccposP@ssw0rd;database=backendposdata_inventory", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_as_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<branch_location>(entity =>
            {
                entity.Property(e => e.ID).HasMaxLength(36);

                entity.Property(e => e.BranchID).HasMaxLength(36);

                entity.Property(e => e.CreateBy).HasMaxLength(30);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.ParentID).HasMaxLength(36);

                entity.Property(e => e.Type).HasMaxLength(255);
            });

            modelBuilder.Entity<document_type>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DocumentName).HasMaxLength(255);
            });

            modelBuilder.Entity<goods_received>(entity =>
            {
                entity.HasKey(e => e.GoodsReceivedID)
                    .HasName("PRIMARY");

                entity.Property(e => e.GoodsReceivedID).HasMaxLength(36);

                entity.Property(e => e.AfterVat).HasPrecision(16, 4);

                entity.Property(e => e.BranchID).HasMaxLength(36);

                entity.Property(e => e.CreateBy).HasMaxLength(30);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DocDate).HasColumnType("datetime");

                entity.Property(e => e.InvoideNumber).HasMaxLength(255);

                entity.Property(e => e.MerchantID).HasMaxLength(36);

                entity.Property(e => e.Notes).HasMaxLength(255);

                entity.Property(e => e.ReceivedAt).HasColumnType("datetime");

                entity.Property(e => e.SupplierID).HasMaxLength(36);

                entity.Property(e => e.TotalPrice).HasPrecision(16, 4);

                entity.Property(e => e.Vat).HasPrecision(16, 4);
            });

            modelBuilder.Entity<goods_received_detail>(entity =>
            {
                entity.HasKey(e => e.GoodsReceivedDetailID)
                    .HasName("PRIMARY");

                entity.Property(e => e.GoodsReceivedDetailID).HasMaxLength(36);

                entity.Property(e => e.BranchLocationID).HasMaxLength(36);

                entity.Property(e => e.GoodsReceivedID).HasMaxLength(36);

                entity.Property(e => e.Quantity).HasPrecision(16, 4);

                entity.Property(e => e.SKUID).HasMaxLength(36);

                entity.Property(e => e.TotalPrice).HasPrecision(16, 4);

                entity.Property(e => e.UnitPrice).HasPrecision(16, 4);
            });

            modelBuilder.Entity<inventory_config>(entity =>
            {
                entity.HasKey(e => e.merchantID)
                    .HasName("PRIMARY");

                entity.Property(e => e.merchantID)
                    .HasMaxLength(36)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.running).HasMaxLength(5);
            });

            modelBuilder.Entity<mmdoc>(entity =>
            {
                entity.HasKey(e => new { e.MMDocNo, e.BranchID })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.Property(e => e.MMDocNo)
                    .HasMaxLength(36)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.BranchID).HasMaxLength(36);

                entity.Property(e => e.CreateBy).HasMaxLength(255);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<mmitem>(entity =>
            {
                entity.HasKey(e => e.mmitem1)
                    .HasName("PRIMARY");

                entity.Property(e => e.mmitem1)
                    .HasMaxLength(36)
                    .HasColumnName("mmitem")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.AfterQTY).HasPrecision(16, 4);

                entity.Property(e => e.BeforeQTY).HasPrecision(16, 4);

                entity.Property(e => e.CostPerQTY).HasPrecision(16, 4);

                entity.Property(e => e.LastInventoyValue).HasPrecision(16, 4);

                entity.Property(e => e.MovementQTY).HasPrecision(16, 4);

                entity.Property(e => e.SKUID).HasMaxLength(36);

                entity.Property(e => e.branch_location_id).HasMaxLength(36);

                entity.Property(e => e.mmdoc)
                    .HasMaxLength(36)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<mmstatus>(entity =>
            {
                entity.Property(e => e.MMStatusID).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(255);
            });

            modelBuilder.Entity<movement_header>(entity =>
            {
                entity.HasKey(e => e.movement_doc_no)
                    .HasName("PRIMARY");

                entity.Property(e => e.movement_doc_no)
                    .HasMaxLength(36)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.BranchID).HasMaxLength(36);

                entity.Property(e => e.CreateBy).HasMaxLength(255);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Location_des).HasMaxLength(36);

                entity.Property(e => e.Location_src).HasMaxLength(36);

                entity.Property(e => e.Note).HasMaxLength(255);
            });

            modelBuilder.Entity<movement_header_detail>(entity =>
            {
                entity.HasKey(e => e.movement_item_id)
                    .HasName("PRIMARY");

                entity.Property(e => e.movement_item_id)
                    .HasMaxLength(36)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.QtyAfter).HasPrecision(10);

                entity.Property(e => e.QtyBefore).HasPrecision(10);

                entity.Property(e => e.SKUID)
                    .HasMaxLength(36)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.movement_doc_no)
                    .HasMaxLength(36)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<physical_count>(entity =>
            {
                entity.HasKey(e => e.PhysicalCountID)
                    .HasName("PRIMARY");

                entity.Property(e => e.PhysicalCountID).HasMaxLength(36);

                entity.Property(e => e.BranchID).HasMaxLength(36);

                entity.Property(e => e.BranchLocationID).HasMaxLength(36);

                entity.Property(e => e.CountedEndDate).HasColumnType("datetime");

                entity.Property(e => e.CountedStartDate).HasColumnType("datetime");

                entity.Property(e => e.CreateBy).HasMaxLength(30);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(255);

                entity.Property(e => e.PhysicalCountNo).HasMaxLength(255);

                entity.Property(e => e.UpdateBy).HasMaxLength(30);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<physical_count_detail>(entity =>
            {
                entity.HasKey(e => e.PhysicalCountDetailID)
                    .HasName("PRIMARY");

                entity.Property(e => e.PhysicalCountDetailID).HasMaxLength(36);

                entity.Property(e => e.BeforeQTY).HasPrecision(16, 4);

                entity.Property(e => e.CreateBy).HasMaxLength(30);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.PhysicalCountID).HasMaxLength(36);

                entity.Property(e => e.Quantity).HasPrecision(16, 4);

                entity.Property(e => e.SKUID).HasMaxLength(36);

                entity.Property(e => e.UpdateBy).HasMaxLength(30);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<reordering_point_report>(entity =>
            {
                entity.HasKey(e => new { e.BranchID, e.SKUID })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.Property(e => e.BranchID).HasMaxLength(36);

                entity.Property(e => e.SKUID).HasMaxLength(36);

                entity.Property(e => e.AverageOutOfStockDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(36);
            });

            modelBuilder.Entity<sku_branch_inventory>(entity =>
            {
                entity.HasKey(e => new { e.SKUID, e.BranchID, e.branch_location_id })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.Property(e => e.SKUID).HasMaxLength(36);

                entity.Property(e => e.BranchID).HasMaxLength(36);

                entity.Property(e => e.branch_location_id).HasMaxLength(36);

                entity.Property(e => e.AccumValue).HasPrecision(10, 2);

                entity.Property(e => e.CurrentQTY).HasPrecision(10, 2);

                entity.Property(e => e.DeadStockQTY).HasPrecision(10, 2);

                entity.Property(e => e.LastCountDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<sku_branch_inventory_config>(entity =>
            {
                entity.HasKey(e => new { e.SKUID, e.BranchID })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.Property(e => e.SKUID)
                    .HasMaxLength(36)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.BranchID)
                    .HasMaxLength(36)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CreateBy).HasMaxLength(36);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.MaximumLowlevelQTY).HasPrecision(10, 2);

                entity.Property(e => e.NegativeQTY).HasPrecision(10, 2);

                entity.Property(e => e.TriggerLowlevelQTY).HasPrecision(10, 2);
            });

            modelBuilder.Entity<supplier>(entity =>
            {
                entity.HasIndex(e => e.Email, "i_supplier_email");

                entity.Property(e => e.SupplierID).HasMaxLength(36);

                entity.Property(e => e.BranchNo).HasMaxLength(10);

                entity.Property(e => e.ContactName).HasMaxLength(255);

                entity.Property(e => e.CreateBy).HasMaxLength(30);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Fax).HasMaxLength(30);

                entity.Property(e => e.Mobile).HasMaxLength(30);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.TaxID).HasMaxLength(20);

                entity.Property(e => e.Tel).HasMaxLength(30);

                entity.Property(e => e.UpdateBy).HasMaxLength(30);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<supplier_address>(entity =>
            {
                entity.HasKey(e => e.SupplierID)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.Province, "i_supplier_address_city");

                entity.Property(e => e.SupplierID).HasMaxLength(36);

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.Country)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'Thailand'");

                entity.Property(e => e.CreateBy).HasMaxLength(30);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.District).HasMaxLength(255);

                entity.Property(e => e.Subdistrict).HasMaxLength(255);

                entity.Property(e => e.UpdateBy).HasMaxLength(30);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.Zipcode).HasMaxLength(10);
            });

            modelBuilder.Entity<supplier_branch>(entity =>
            {
                entity.HasKey(e => new { e.SupplierID, e.BranchID })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.Property(e => e.SupplierID).HasMaxLength(36);

                entity.Property(e => e.BranchID).HasMaxLength(36);

                entity.Property(e => e.AddressInfo).HasMaxLength(255);

                entity.Property(e => e.District).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Province).HasMaxLength(100);

                entity.Property(e => e.Subdistrict).HasMaxLength(100);

                entity.Property(e => e.TaxID).HasMaxLength(20);

                entity.Property(e => e.Zipcode).HasMaxLength(100);
            });

            modelBuilder.Entity<supplier_sku>(entity =>
            {
                entity.HasKey(e => new { e.SupplierID, e.SKUID, e.BranchID })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.Property(e => e.SupplierID).HasMaxLength(36);

                entity.Property(e => e.SKUID).HasMaxLength(36);

                entity.Property(e => e.BranchID).HasMaxLength(36);

                entity.Property(e => e.IsActive).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
