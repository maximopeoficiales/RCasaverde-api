using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace backend.Models
{
    public partial class dbContext : DbContext
    {
        public dbContext()
        {
        }

        public dbContext(DbContextOptions<dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Coupon> Coupons { get; set; }
        public virtual DbSet<DocumentType> DocumentTypes { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<OrderHistory> OrderHistories { get; set; }
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Soat> Soats { get; set; }
        public virtual DbSet<SoatStatus> SoatStatuses { get; set; }
        public virtual DbSet<TechnicalReview> TechnicalReviews { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserCoupon> UserCoupons { get; set; }
        public virtual DbSet<UserReview> UserReviews { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;database=restaurant_casaverde;user=root;password=rpi75695118@192.168.1.200;treattinyasboolean=true", Microsoft.EntityFrameworkCore.ServerVersion.FromString("10.4.15-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("active");

                entity.Property(e => e.ImgUrl)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasColumnName("img_url")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_spanish_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasColumnName("name")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_spanish_ci");
            });

            modelBuilder.Entity<Coupon>(entity =>
            {
                entity.ToTable("Coupon");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("amount");
            });

            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.ToTable("Document_Type");

                entity.HasIndex(e => e.Type, "type_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasColumnName("type")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_spanish_ci");
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.ToTable("Ingredient");

                entity.HasIndex(e => e.Name, "name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasColumnName("name")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_spanish_ci");

                entity.Property(e => e.StockKg)
                    .HasPrecision(5, 2)
                    .HasColumnName("stock_kg");

                entity.Property(e => e.StockKgMin)
                    .HasPrecision(4, 2)
                    .HasColumnName("stock_kg_min");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.HasIndex(e => e.IdDocumentType, "fk_Order_Document_Type1_idx");

                entity.HasIndex(e => e.IdOrderStatus, "fk_Order_Order_Status1_idx");

                entity.HasIndex(e => e.IdPaymentType, "fk_Order_Payment_Type1_idx");

                entity.HasIndex(e => e.IdClient, "fk_Pedido_Cliente_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.DeliverDate)
                    .HasColumnType("datetime")
                    .HasColumnName("deliver_date");

                entity.Property(e => e.IdClient)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("idClient");

                entity.Property(e => e.IdDocumentType)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("idDocumentType");

                entity.Property(e => e.IdOrderStatus)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("idOrderStatus");

                entity.Property(e => e.IdPaymentType)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("idPaymentType");

                entity.Property(e => e.Latitude)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasColumnName("latitude")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_spanish_ci");

                entity.Property(e => e.Longitude)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasColumnName("longitude")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_spanish_ci");

                entity.Property(e => e.Message)
                    .HasColumnType("varchar(150)")
                    .HasColumnName("message")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_spanish_ci");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("order_date");

                entity.Property(e => e.Reference)
                    .HasColumnType("varchar(60)")
                    .HasColumnName("reference")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_spanish_ci");

                entity.Property(e => e.ShippingAddress)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("shipping_address")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_spanish_ci");

                entity.Property(e => e.Total)
                    .HasPrecision(7, 2)
                    .HasColumnName("total");

                entity.Property(e => e.Zipcode)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("zipcode");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Pedido_Cliente");

                entity.HasOne(d => d.IdDocumentTypeNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdDocumentType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Order_Document_Type1");

                entity.HasOne(d => d.IdOrderStatusNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdOrderStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Order_Order_Status1");

                entity.HasOne(d => d.IdPaymentTypeNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdPaymentType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Order_Payment_Type1");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.IdProduct, e.IdOrder })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("Order_detail");

                entity.HasIndex(e => e.IdOrder, "fk_Pedido_has_Producto_Pedido1_idx");

                entity.HasIndex(e => e.IdProduct, "fk_Pedido_has_Producto_Producto1_idx");

                entity.Property(e => e.IdProduct)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("idProduct");

                entity.Property(e => e.IdOrder)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("idOrder");

                entity.Property(e => e.Quantity)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("quantity");

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.IdOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Pedido_has_Producto_Pedido1");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Pedido_has_Producto_Producto1");
            });

            modelBuilder.Entity<OrderHistory>(entity =>
            {
                entity.HasKey(e => new { e.IdCourier, e.IdOrder, e.IdVehicle })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("Order_History");

                entity.HasIndex(e => e.IdCourier, "fk_Courier_has_Order_Courier1_idx");

                entity.HasIndex(e => e.IdOrder, "fk_Courier_has_Order_Order1_idx");

                entity.HasIndex(e => e.IdVehicle, "fk_Courier_has_Order_Vehicle1_idx");

                entity.Property(e => e.IdCourier)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("idCourier");

                entity.Property(e => e.IdOrder)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("idOrder");

                entity.Property(e => e.IdVehicle)
                    .HasColumnType("varchar(10)")
                    .HasColumnName("idVehicle")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_spanish_ci");

                entity.Property(e => e.TimeElapsed)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("time_elapsed");

                entity.HasOne(d => d.courier)
                    .WithMany(p => p.OrderHistories)
                    .HasForeignKey(d => d.IdCourier)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Courier_has_Order_Courier1");

                entity.HasOne(d => d.order)
                    .WithMany(p => p.OrderHistories)
                    .HasForeignKey(d => d.IdOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Courier_has_Order_Order1");

                entity.HasOne(d => d.vehicle)
                    .WithMany(p => p.OrderHistories)
                    .HasForeignKey(d => d.IdVehicle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Courier_has_Order_Vehicle1");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.ToTable("Order_Status");

                entity.HasIndex(e => e.Status, "status_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasColumnName("status")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_spanish_ci");
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.ToTable("Payment_Type");

                entity.HasIndex(e => e.Type, "type_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasColumnName("type")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_spanish_ci");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.HasIndex(e => e.IdCategory, "fk_Producto_Categoria1_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasColumnName("active")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_spanish_ci");

                entity.Property(e => e.DescriptionLong)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("description_long")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_spanish_ci");

                entity.Property(e => e.DescriptionShort)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasColumnName("description_short")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_spanish_ci");

                entity.Property(e => e.IdCategory)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("idCategory");

                entity.Property(e => e.ImgUrl)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasColumnName("img_url")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_spanish_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(25)")
                    .HasColumnName("name")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_spanish_ci");

                entity.Property(e => e.Price)
                    .HasPrecision(5, 2)
                    .HasColumnName("price");

                entity.Property(e => e.SellPrice)
                    .HasPrecision(5, 2)
                    .HasColumnName("sell_price");

                entity.Property(e => e.Stars)
                    .HasColumnType("int(11)")
                    .HasColumnName("stars");

                entity.Property(e => e.Stock)
                    .HasColumnType("int(11)")
                    .HasColumnName("stock");

                entity.Property(e => e.StockMin)
                    .HasColumnType("int(11)")
                    .HasColumnName("stock_min");

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Producto_Categoria1");
            });

            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.ToTable("Product_Images");

                entity.HasIndex(e => e.IdProduct, "fk_Product_Images_Product1_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.IdProduct)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("idProduct");

                entity.Property(e => e.ImgUrl)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("img_url")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_spanish_ci");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.ProductImages)
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Product_Images_Product1");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.HasKey(e => new { e.IdProduct, e.IdIngredient })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("Recipe");

                entity.HasIndex(e => e.IdIngredient, "fk_Producto_has_Ingredientes_Ingredientes1_idx");

                entity.HasIndex(e => e.IdProduct, "fk_Producto_has_Ingredientes_Producto1_idx");

                entity.HasIndex(e => e.Name, "name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdProduct)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("idProduct");

                entity.Property(e => e.IdIngredient)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("idIngredient");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasColumnName("name")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_spanish_ci");

                entity.Property(e => e.QuantityKg)
                    .HasPrecision(4, 2)
                    .HasColumnName("quantity_kg");

                entity.HasOne(d => d.IdIngredientNavigation)
                    .WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.IdIngredient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Producto_has_Ingredientes_Ingredientes1");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Producto_has_Ingredientes_Producto1");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Role1)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasColumnName("role")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_spanish_ci");
            });

            modelBuilder.Entity<Soat>(entity =>
            {
                entity.ToTable("Soat");

                entity.HasIndex(e => e.DocumentUrl, "document_url_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdStatus, "fk_Soat_Soat_status1_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.DocumentUrl)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasColumnName("document_url")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_spanish_ci");

                entity.Property(e => e.DueDate)
                    .HasColumnType("date")
                    .HasColumnName("due_date");

                entity.Property(e => e.IdStatus)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("idStatus");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.Soats)
                    .HasForeignKey(d => d.IdStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Soat_Soat_status1");
            });

            modelBuilder.Entity<SoatStatus>(entity =>
            {
                entity.ToTable("Soat_Status");

                entity.HasIndex(e => e.Status, "status_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasColumnName("status")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_spanish_ci");
            });

            modelBuilder.Entity<TechnicalReview>(entity =>
            {
                entity.ToTable("Technical_Review");

                entity.HasIndex(e => e.IdVehicle, "fk_Technical Review_Vehicle1_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasColumnName("description")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_spanish_ci");

                entity.Property(e => e.DocumentUrl)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("document_url")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_spanish_ci");

                entity.Property(e => e.IdVehicle)
                    .IsRequired()
                    .HasColumnType("varchar(10)")
                    .HasColumnName("idVehicle")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_spanish_ci");

                entity.HasOne(d => d.IdVehicleNavigation)
                    .WithMany(p => p.TechnicalReviews)
                    .HasForeignKey(d => d.IdVehicle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Technical Review_Vehicle1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.Phone, "celular_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "email_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdRole, "fk_User_Role1_idx");

                entity.HasIndex(e => e.Username, "username_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("active");

                entity.Property(e => e.ClientAddress)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasColumnName("client_address")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_spanish_ci");

                entity.Property(e => e.Email)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("email")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_spanish_ci");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnType("varchar(35)")
                    .HasColumnName("firstname")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_spanish_ci");

                entity.Property(e => e.IdRole)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("idRole");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnType("varchar(35)")
                    .HasColumnName("lastname")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_spanish_ci");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasColumnName("password")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_spanish_ci");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnType("char(9)")
                    .HasColumnName("phone")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_spanish_ci");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasColumnName("username")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_spanish_ci");

                entity.Property(e => e.Zipcode)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("zipcode");

                entity.HasOne(d => d.role)
                    .WithMany(p => p.users)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_User_Role1");
            });

            modelBuilder.Entity<UserCoupon>(entity =>
            {
                entity.HasKey(e => new { e.IdClient, e.IdCoupon })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("User_Coupons");

                entity.HasIndex(e => e.IdClient, "fk_Cliente_has_Cupon_Cliente1_idx");

                entity.HasIndex(e => e.IdCoupon, "fk_Cliente_has_Cupon_Cupon1_idx");

                entity.Property(e => e.IdClient)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("idClient");

                entity.Property(e => e.IdCoupon)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("idCoupon");

                entity.Property(e => e.Used)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("used");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.UserCoupons)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Cliente_has_Cupon_Cliente1");

                entity.HasOne(d => d.IdCouponNavigation)
                    .WithMany(p => p.UserCoupons)
                    .HasForeignKey(d => d.IdCoupon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Cliente_has_Cupon_Cupon1");
            });

            modelBuilder.Entity<UserReview>(entity =>
            {
                entity.HasKey(e => new { e.IdUser, e.IdProduct })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("User_review");

                entity.HasIndex(e => e.IdUser, "fk_Client_has_Product_Client1_idx");

                entity.HasIndex(e => e.IdProduct, "fk_Client_has_Product_Product1_idx");

                entity.Property(e => e.IdUser)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("idUser");

                entity.Property(e => e.IdProduct)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("idProduct");

                entity.Property(e => e.Stars)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("stars");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.UserReviews)
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Client_has_Product_Product1");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.UserReviews)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Client_has_Product_Client1");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("Vehicle");

                entity.HasIndex(e => e.IdSoat, "fk_Vehicle_Soat1_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("varchar(10)")
                    .HasColumnName("id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_spanish_ci");

                entity.Property(e => e.Brand)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasColumnName("brand")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_spanish_ci");

                entity.Property(e => e.IdSoat)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("idSoat");

                entity.Property(e => e.ModelName)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasColumnName("model_name")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_spanish_ci");

                entity.HasOne(d => d.IdSoatNavigation)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.IdSoat)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Vehicle_Soat1");
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.ToTable("Staff");

                entity.HasIndex(e => e.Address, "address_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Dni, "dni_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdRole, "fk_Staff_Role1_idx");

                entity.HasIndex(e => e.Phone, "phone_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "username_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("active");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("varchar(150)")
                    .HasColumnName("address")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_spanish_ci");

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasColumnType("char(8)")
                    .HasColumnName("dni")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_spanish_ci");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasColumnName("email")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_spanish_ci");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasColumnName("firstname")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_spanish_ci");

                entity.Property(e => e.IdRole)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("idRole");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasColumnName("lastname")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_spanish_ci");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasColumnName("password")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_spanish_ci");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnType("char(9)")
                    .HasColumnName("phone")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_spanish_ci");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasColumnName("username")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_spanish_ci");

                entity.HasOne(d => d.role)
                    .WithMany(p => p.staff)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Staff_Role1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
