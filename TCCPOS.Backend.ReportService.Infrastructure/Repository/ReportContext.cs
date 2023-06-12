using Microsoft.EntityFrameworkCore;
using TCCPOS.Backend.ReportService.Entities;

namespace TCCPOS.Backend.ReportService.Infrastructure.Repository
{
    public partial class ReportContext : DbContext
    {
        public ReportContext()
        {
        }

        public ReportContext(DbContextOptions<ReportContext> options)
            : base(options)
        {
        }

        public virtual DbSet<branch> branch { get; set; } = null!;
        public virtual DbSet<brand> brand { get; set; } = null!;
        public virtual DbSet<coupon> coupon { get; set; } = null!;
        public virtual DbSet<coupontype> coupontype { get; set; } = null!;
        public virtual DbSet<currentversion> currentversion { get; set; } = null!;
        public virtual DbSet<customer> customer { get; set; } = null!;
        public virtual DbSet<customer_address> customer_address { get; set; } = null!;
        public virtual DbSet<districts> districts { get; set; } = null!;
        public virtual DbSet<dummy> dummy { get; set; } = null!;
        public virtual DbSet<fulltax> fulltax { get; set; } = null!;
        public virtual DbSet<fulltaxdetail> fulltaxdetail { get; set; } = null!;
        public virtual DbSet<geographies> geographies { get; set; } = null!;
        public virtual DbSet<grouppurchaseview> grouppurchaseview { get; set; } = null!;
        public virtual DbSet<merchant> merchant { get; set; } = null!;
        public virtual DbSet<payment> payment { get; set; } = null!;
        public virtual DbSet<payment_coupon> payment_coupon { get; set; } = null!;
        public virtual DbSet<payment_method> payment_method { get; set; } = null!;
        public virtual DbSet<payment_promptpay> payment_promptpay { get; set; } = null!;
        public virtual DbSet<posclient> posclient { get; set; } = null!;
        public virtual DbSet<possesssion> possesssion { get; set; } = null!;
        public virtual DbSet<prodcat> prodcat { get; set; } = null!;
        public virtual DbSet<prodcat_prodsubcat> prodcat_prodsubcat { get; set; } = null!;
        public virtual DbSet<prodgroup> prodgroup { get; set; } = null!;
        public virtual DbSet<prodgroup_prodcat> prodgroup_prodcat { get; set; } = null!;
        public virtual DbSet<prodsize> prodsize { get; set; } = null!;
        public virtual DbSet<prodsubcat> prodsubcat { get; set; } = null!;
        public virtual DbSet<produnit> produnit { get; set; } = null!;
        public virtual DbSet<promotion> promotion { get; set; } = null!;
        public virtual DbSet<promotion_applied_items_id> promotion_applied_items_id { get; set; } = null!;
        public virtual DbSet<promotiontype> promotiontype { get; set; } = null!;
        public virtual DbSet<provinces> provinces { get; set; } = null!;
        public virtual DbSet<saleitem> saleitem { get; set; } = null!;
        public virtual DbSet<saleitem_promotion_text> saleitem_promotion_text { get; set; } = null!;
        public virtual DbSet<saleorder> saleorder { get; set; } = null!;
        public virtual DbSet<sku> sku { get; set; } = null!;
        public virtual DbSet<sku_branch_price> sku_branch_price { get; set; } = null!;
        public virtual DbSet<sku_conversion> sku_conversion { get; set; } = null!;
        public virtual DbSet<sku_spliting_pack> sku_spliting_pack { get; set; } = null!;
        public virtual DbSet<subdistricts> subdistricts { get; set; } = null!;
        public virtual DbSet<testenum> testenum { get; set; } = null!;
        public virtual DbSet<useraccount> useraccount { get; set; } = null!;
        public virtual DbSet<useractivity> useractivity { get; set; } = null!;
        public virtual DbSet<userlogin> userlogin { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=backendposdev.mysql.database.azure.com;port=3306;userid=myadmin;password=tccposP@ssw0rd;database=backendposdata", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_as_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<branch>(entity =>
            {
                entity.Property(e => e.BranchID)
                    .HasMaxLength(36)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.AccountCode).HasMaxLength(255);

                entity.Property(e => e.AccountName).HasMaxLength(255);

                entity.Property(e => e.BranchAddress).HasMaxLength(255);

                entity.Property(e => e.BranchAddress1).HasMaxLength(255);

                entity.Property(e => e.BranchAddress2).HasMaxLength(255);

                entity.Property(e => e.BranchDistrict).HasMaxLength(30);

                entity.Property(e => e.BranchEmail).HasMaxLength(50);

                entity.Property(e => e.BranchName).HasMaxLength(50);

                entity.Property(e => e.BranchNo)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.BranchProvince).HasMaxLength(30);

                entity.Property(e => e.BranchSubdistrict).HasMaxLength(30);

                entity.Property(e => e.BranchZipcode).HasMaxLength(10);

                entity.Property(e => e.MerchantID).HasMaxLength(36);
            });

            modelBuilder.Entity<brand>(entity =>
            {
                entity.HasIndex(e => e.TH_Brand, "UK_brand_TH_Brand")
                    .IsUnique();

                entity.Property(e => e.EN_Brand).HasMaxLength(255);
            });

            modelBuilder.Entity<coupon>(entity =>
            {
                entity.HasKey(e => e.CouponCode)
                    .HasName("PRIMARY");

                entity.Property(e => e.CouponCode)
                    .HasMaxLength(36)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.UseDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<coupontype>(entity =>
            {
                entity.HasKey(e => e.ConponType)
                    .HasName("PRIMARY");

                entity.Property(e => e.Discount).HasPrecision(16, 4);

                entity.Property(e => e.SKUID).HasMaxLength(36);
            });

            modelBuilder.Entity<currentversion>(entity =>
            {
                entity.HasKey(e => e.MajorVersion)
                    .HasName("PRIMARY");

                entity.Property(e => e.MajorVersion).ValueGeneratedNever();
            });

            modelBuilder.Entity<customer>(entity =>
            {
                entity.Property(e => e.CustomerID).HasMaxLength(36);

                entity.Property(e => e.BranchID).HasMaxLength(36);

                entity.Property(e => e.BranchNo).HasMaxLength(10);

                entity.Property(e => e.CreateBy).HasMaxLength(30);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(30);

                entity.Property(e => e.Fax).HasMaxLength(30);

                entity.Property(e => e.MerchantID).HasMaxLength(36);

                entity.Property(e => e.Mobile).HasMaxLength(30);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.TaxID).HasMaxLength(20);

                entity.Property(e => e.Tel).HasMaxLength(30);

                entity.Property(e => e.UpdateBy).HasMaxLength(30);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<customer_address>(entity =>
            {
                entity.HasKey(e => e.CustomerID)
                    .HasName("PRIMARY");

                entity.Property(e => e.CustomerID).HasMaxLength(36);

                entity.Property(e => e.Address1).HasMaxLength(255);

                entity.Property(e => e.Address2).HasMaxLength(255);

                entity.Property(e => e.CreateBy).HasMaxLength(30);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.District).HasMaxLength(255);

                entity.Property(e => e.Province).HasMaxLength(255);

                entity.Property(e => e.Subdistrict).HasMaxLength(255);

                entity.Property(e => e.UpdateBy).HasMaxLength(30);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.Zipcode).HasMaxLength(10);
            });

            modelBuilder.Entity<districts>(entity =>
            {
                entity.Property(e => e.code).HasMaxLength(4);

                entity.Property(e => e.name_en).HasMaxLength(150);

                entity.Property(e => e.name_th).HasMaxLength(150);
            });

            modelBuilder.Entity<dummy>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.name).HasColumnType("text");
            });

            modelBuilder.Entity<fulltax>(entity =>
            {
                entity.Property(e => e.FullTaxID).HasMaxLength(36);

                entity.Property(e => e.BranchID).HasMaxLength(36);

                entity.Property(e => e.BranchName).HasMaxLength(255);

                entity.Property(e => e.BranchNo).HasMaxLength(10);

                entity.Property(e => e.CreateBy).HasMaxLength(30);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CustomerBranchNo).HasMaxLength(10);

                entity.Property(e => e.CustomerID).HasMaxLength(36);

                entity.Property(e => e.CustomerName).HasMaxLength(255);

                entity.Property(e => e.CustomerTaxID).HasMaxLength(20);

                entity.Property(e => e.FullReceiptNo).HasMaxLength(16);

                entity.Property(e => e.MerchantID).HasMaxLength(36);

                entity.Property(e => e.RDNumber).HasMaxLength(36);

                entity.Property(e => e.ReceiptNo).HasMaxLength(16);

                entity.Property(e => e.SaleOrderID).HasMaxLength(36);
            });

            modelBuilder.Entity<fulltaxdetail>(entity =>
            {
                entity.HasKey(e => e.FullTaxID)
                    .HasName("PRIMARY");

                entity.Property(e => e.FullTaxID).HasMaxLength(36);

                entity.Property(e => e.BranchAddress1).HasMaxLength(255);

                entity.Property(e => e.BranchAddress2).HasMaxLength(255);

                entity.Property(e => e.BranchDistrict).HasMaxLength(50);

                entity.Property(e => e.BranchProvince).HasMaxLength(50);

                entity.Property(e => e.BranchSubdistrict).HasMaxLength(50);

                entity.Property(e => e.BranchZipcode).HasMaxLength(10);

                entity.Property(e => e.CreateBy).HasMaxLength(30);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CustomerAddress1).HasMaxLength(255);

                entity.Property(e => e.CustomerAddress2).HasMaxLength(255);

                entity.Property(e => e.CustomerDistrict).HasMaxLength(50);

                entity.Property(e => e.CustomerProvince).HasMaxLength(50);

                entity.Property(e => e.CustomerSubdistrict).HasMaxLength(50);

                entity.Property(e => e.CustomerZipcode).HasMaxLength(10);

                entity.Property(e => e.Reason).HasMaxLength(255);
            });

            modelBuilder.Entity<geographies>(entity =>
            {
                entity.Property(e => e.name).HasMaxLength(255);
            });

            modelBuilder.Entity<grouppurchaseview>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("grouppurchaseview");

                entity.Property(e => e.Amount).HasPrecision(38, 4);

                entity.Property(e => e.BranchName).HasMaxLength(50);

                entity.Property(e => e.MerchantName).HasMaxLength(255);

                entity.Property(e => e.POSClientID)
                    .HasMaxLength(36)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.PaymentMethod)
                    .HasMaxLength(4)
                    .HasDefaultValueSql("''")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.PaymentName)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<merchant>(entity =>
            {
                entity.Property(e => e.MerchantID)
                    .HasMaxLength(36)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.MerchantAddress).HasMaxLength(255);

                entity.Property(e => e.MerchantName).HasMaxLength(255);

                entity.Property(e => e.MerchantTel).HasMaxLength(50);

                entity.Property(e => e.TaxID).HasMaxLength(20);
            });

            modelBuilder.Entity<payment>(entity =>
            {
                entity.Property(e => e.PaymentID)
                    .HasMaxLength(36)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Amount).HasPrecision(16, 4);

                entity.Property(e => e.AmountRecieve).HasPrecision(16, 4);

                entity.Property(e => e.CreateBy).HasMaxLength(36);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.POSClientID)
                    .HasMaxLength(36)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.POSSessionID).HasMaxLength(255);

                entity.Property(e => e.SaleOrderID)
                    .HasMaxLength(36)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.VoidBy).HasMaxLength(36);

                entity.Property(e => e.VoidDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<payment_coupon>(entity =>
            {
                entity.HasKey(e => new { e.PaymentID, e.CounponCode, e.CouponFrom })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.HasIndex(e => e.CounponCode, "UK_payment_coupon_CounponCode")
                    .IsUnique();

                entity.Property(e => e.PaymentID)
                    .HasMaxLength(36)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CounponCode)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CouponFrom)
                    .HasMaxLength(36)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Amount).HasPrecision(16, 4);

                entity.Property(e => e.CreateBy).HasMaxLength(36);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Percent).HasPrecision(16, 4);

                entity.Property(e => e.SKUID).HasMaxLength(36);
            });

            modelBuilder.Entity<payment_method>(entity =>
            {
                entity.HasKey(e => e.PaymentMethodID)
                    .HasName("PRIMARY");

                entity.Property(e => e.PaymentMethodID).ValueGeneratedNever();

                entity.Property(e => e.PaymentName).HasMaxLength(255);
            });

            modelBuilder.Entity<payment_promptpay>(entity =>
            {
                entity.HasKey(e => e.PaymentID)
                    .HasName("PRIMARY");

                entity.Property(e => e.PaymentID)
                    .HasMaxLength(36)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Amount).HasPrecision(16, 4);

                entity.Property(e => e.BankAccount).HasMaxLength(20);

                entity.Property(e => e.Ref1).HasMaxLength(20);

                entity.Property(e => e.Ref2).HasMaxLength(20);
            });

            modelBuilder.Entity<posclient>(entity =>
            {
                entity.HasIndex(e => e.BranchID, "FK_posclient_branch_BranchID");

                entity.HasIndex(e => e.MerchantID, "FK_posclient_merchant_MerchantID");

                entity.Property(e => e.POSClientID)
                    .HasMaxLength(36)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.BranchID).HasMaxLength(36);

                entity.Property(e => e.FRPOSRunning)
                    .HasMaxLength(5)
                    .HasDefaultValueSql("'000'");

                entity.Property(e => e.MerchantID).HasMaxLength(36);

                entity.Property(e => e.POSRunning)
                    .HasMaxLength(5)
                    .HasDefaultValueSql("'000'");

                entity.Property(e => e.RDNumber).HasMaxLength(36);

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.posclient)
                    .HasForeignKey(d => d.BranchID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Merchant)
                    .WithMany(p => p.posclient)
                    .HasForeignKey(d => d.MerchantID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<possesssion>(entity =>
            {
                entity.HasKey(e => e.POSSessionID)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.POSClientID, "FK_possesssion_posclient_POSClientID");

                entity.Property(e => e.POSSessionID)
                    .HasMaxLength(36)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CashAmount).HasPrecision(16, 4);

                entity.Property(e => e.CreateBy).HasMaxLength(36);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Deposit).HasPrecision(16, 4);

                entity.Property(e => e.EndCashAmount).HasPrecision(16, 4);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.POSClientID)
                    .HasMaxLength(36)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Withdrawal).HasPrecision(16, 4);

                entity.HasOne(d => d.POSClient)
                    .WithMany(p => p.possesssion)
                    .HasForeignKey(d => d.POSClientID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<prodcat>(entity =>
            {
                entity.Property(e => e.EN_Name).HasMaxLength(255);

                entity.Property(e => e.TH_Name).HasMaxLength(255);
            });

            modelBuilder.Entity<prodcat_prodsubcat>(entity =>
            {
                entity.HasKey(e => new { e.ProdCatID, e.ProdSubCatID })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
            });

            modelBuilder.Entity<prodgroup>(entity =>
            {
                entity.Property(e => e.EN_Name).HasMaxLength(255);

                entity.Property(e => e.TH_Name).HasMaxLength(255);
            });

            modelBuilder.Entity<prodgroup_prodcat>(entity =>
            {
                entity.HasKey(e => new { e.ProdGroupID, e.ProdCatID })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
            });

            modelBuilder.Entity<prodsize>(entity =>
            {
                entity.Property(e => e.ProductSize).HasMaxLength(255);
            });

            modelBuilder.Entity<prodsubcat>(entity =>
            {
                entity.Property(e => e.ProdSubCatID).ValueGeneratedNever();

                entity.Property(e => e.EN_Name).HasMaxLength(255);

                entity.Property(e => e.TH_Name).HasMaxLength(255);
            });

            modelBuilder.Entity<produnit>(entity =>
            {
                entity.Property(e => e.Produnit1)
                    .HasMaxLength(255)
                    .HasColumnName("Produnit");
            });

            modelBuilder.Entity<promotion>(entity =>
            {
                entity.Property(e => e.Conditions).HasColumnType("json");

                entity.Property(e => e.Description).HasMaxLength(1024);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<promotion_applied_items_id>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.SkuId).HasMaxLength(36);
            });

            modelBuilder.Entity<promotiontype>(entity =>
            {
                entity.HasKey(e => e.PromotionType1)
                    .HasName("PRIMARY");

                entity.Property(e => e.PromotionType1).HasColumnName("PromotionType");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.ParameterFormat).HasMaxLength(255);
            });

            modelBuilder.Entity<provinces>(entity =>
            {
                entity.Property(e => e.code).HasMaxLength(2);

                entity.Property(e => e.name_en).HasMaxLength(150);

                entity.Property(e => e.name_th).HasMaxLength(150);
            });

            modelBuilder.Entity<saleitem>(entity =>
            {
                entity.Property(e => e.SaleItemID).HasMaxLength(36);

                entity.Property(e => e.AfterVatSale).HasPrecision(16, 4);

                entity.Property(e => e.BeforeVatSale).HasPrecision(16, 4);

                entity.Property(e => e.BranchID).HasMaxLength(36);

                entity.Property(e => e.CompCode).HasMaxLength(36);

                entity.Property(e => e.CreateBy).HasMaxLength(36);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.FullPrice).HasPrecision(16, 4);

                entity.Property(e => e.POSClientID).HasMaxLength(36);

                entity.Property(e => e.Price).HasPrecision(16, 4);

                entity.Property(e => e.Quantity).HasPrecision(16, 4);

                entity.Property(e => e.SKUID).HasMaxLength(36);

                entity.Property(e => e.SaleOrderID).HasMaxLength(36);

                entity.Property(e => e.VoidBy).HasMaxLength(36);

                entity.Property(e => e.VoidDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<saleitem_promotion_text>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.PromotionText).HasMaxLength(255);

                entity.Property(e => e.SaleItemID).HasMaxLength(36);
            });

            modelBuilder.Entity<saleorder>(entity =>
            {
                entity.HasComment("Sale Order");

                entity.Property(e => e.SaleOrderID).HasMaxLength(36);

                entity.Property(e => e.BeforeVATSale).HasPrecision(16, 4);

                entity.Property(e => e.BranchID).HasMaxLength(36);

                entity.Property(e => e.CreateBy).HasMaxLength(36);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DocNo).HasMaxLength(16);

                entity.Property(e => e.MemberID).HasMaxLength(36);

                entity.Property(e => e.MerchantID).HasMaxLength(36);

                entity.Property(e => e.POSClientID).HasMaxLength(36);

                entity.Property(e => e.POSSessionID)
                    .HasMaxLength(36)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.TotalDiscount).HasColumnType("decimal(16,4) unsigned zerofill");

                entity.Property(e => e.TotalSale).HasPrecision(16, 4);

                entity.Property(e => e.VATSale).HasPrecision(16, 4);

                entity.Property(e => e.VoidBy).HasMaxLength(36);

                entity.Property(e => e.VoidDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<sku>(entity =>
            {
                entity.HasIndex(e => new { e.BarcodePOS, e.MerchantID }, "UK_sku_BarcodePOS_MerchantID")
                    .IsUnique();

                entity.Property(e => e.SKUID)
                    .HasMaxLength(36)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.BarcodePOS).HasMaxLength(20);

                entity.Property(e => e.CreateBy).HasMaxLength(36);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.IsVat).HasDefaultValueSql("'1'");

                entity.Property(e => e.MapSKU).HasMaxLength(36);

                entity.Property(e => e.MerchantID).HasMaxLength(36);

                entity.Property(e => e.PackSize).HasMaxLength(255);

                entity.Property(e => e.ProductName).HasMaxLength(255);
            });

            modelBuilder.Entity<sku_branch_price>(entity =>
            {
                entity.HasKey(e => new { e.SKUID, e.MerchantID, e.BranchID })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.Property(e => e.SKUID)
                    .HasMaxLength(36)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.MerchantID)
                    .HasMaxLength(36)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.BranchID)
                    .HasMaxLength(36)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Price).HasPrecision(16, 4);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<sku_conversion>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.QTY_RATIO).HasPrecision(16, 4);

                entity.Property(e => e.SKUID).HasMaxLength(36);

                entity.Property(e => e.SUB_SKUID).HasMaxLength(36);
            });

            modelBuilder.Entity<sku_spliting_pack>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.SKUID).HasMaxLength(255);
            });

            modelBuilder.Entity<subdistricts>(entity =>
            {
                entity.Property(e => e.id).HasMaxLength(6);

                entity.Property(e => e.name_en).HasMaxLength(150);

                entity.Property(e => e.name_th).HasMaxLength(150);
            });

            modelBuilder.Entity<testenum>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Packtype).HasColumnType("enum('single','pack','carton','')");
            });

            modelBuilder.Entity<useraccount>(entity =>
            {
                entity.HasKey(e => e.UserID)
                    .HasName("PRIMARY");

                entity.Property(e => e.UserID)
                    .HasMaxLength(36)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.AuthType).HasMaxLength(1);

                entity.Property(e => e.CreateBy).HasMaxLength(36);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.FailedCount).HasDefaultValueSql("'0'");

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

                entity.Property(e => e.Activity).HasMaxLength(255);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Note1).HasMaxLength(255);

                entity.Property(e => e.POSClientID).HasMaxLength(36);

                entity.Property(e => e.POSSessionID).HasMaxLength(36);

                entity.Property(e => e.UserID).HasMaxLength(36);
            });

            modelBuilder.Entity<userlogin>(entity =>
            {
                entity.HasKey(e => new { e.UserID, e.POSClientID })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.HasComment("ผูก User กับ POSClient เข้าด้วยกัน, User นี้ใช้ POSClient ไหนได้บ้าง");

                entity.HasIndex(e => e.POSClientID, "FK_userlogin_posclient_POSClientID");

                entity.Property(e => e.UserID)
                    .HasMaxLength(36)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.POSClientID)
                    .HasMaxLength(36)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LastLogin).HasColumnType("datetime");

                entity.Property(e => e.LastLogout).HasColumnType("datetime");

                entity.Property(e => e.Version).HasMaxLength(255);

                entity.HasOne(d => d.POSClient)
                    .WithMany(p => p.userlogin)
                    .HasForeignKey(d => d.POSClientID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.userlogin)
                    .HasForeignKey(d => d.UserID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
