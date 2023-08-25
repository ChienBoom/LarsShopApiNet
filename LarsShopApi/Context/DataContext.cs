using LarsShopApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System;

namespace LarsShopApi.Context
{
	public class DataContext: DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options) { }
		public DbSet<Bank> Bank { get; set; }
		public DbSet<Category> Category { get; set; }
		public DbSet<Color> Color { get; set; }
		public DbSet<Comment> Comment { get; set; }
		public DbSet<Order> Order { get; set; }
		public DbSet<OrderDetail> OrderDetail { get; set; }
		public DbSet<Product> Product { get; set; }
		public DbSet<ProductDetail> ProductDetail { get; set; }
		public DbSet<Publish> Publish { get; set; }
		public DbSet<Shipment> Shipment { get; set; }
		public DbSet<ShipmentDetail> ShipmentDetail { get; set; }
		public DbSet<Shipper> Shipper { get; set; }
		public DbSet<Size> Size { get; set; }
		public DbSet<User> User { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Order>()
			.HasOne(p => p.OrderDetail)
			.WithOne(a => a.Order)
			.HasForeignKey<Order>(a => a.OrderDetailId); // Tên của khóa ngoại trên entity Order

			modelBuilder.Entity<OrderDetail>()
			.HasOne(p => p.Shipper)
			.WithOne(a => a.OrderDetail)
			.HasForeignKey<OrderDetail>(a => a.ShipperId);

			modelBuilder.Entity<Shipment>()
			.HasOne(p => p.ShipmentDetail)
			.WithOne(a => a.Shipment)
			.HasForeignKey<Shipment>(a => a.ShipmentDetailId);
		}
	}
}
