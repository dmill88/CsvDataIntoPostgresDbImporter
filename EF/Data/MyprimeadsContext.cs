﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EF.Models;

namespace EF.Data
{
    public partial class MyprimeadsContext : DbContext
    {
        public MyprimeadsContext()
        {
        }

        public MyprimeadsContext(DbContextOptions<MyprimeadsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ImportReportKeywordDaily> ImportReportKeywordDaily { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImportReportKeywordDaily>(entity =>
            {
                entity.ToTable("import_report_keyword_daily");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.AdGroupName)
                    .IsRequired()
                    .HasColumnName("ad_group_name")
                    .HasMaxLength(200);

                entity.Property(e => e.CampaignName)
                    .IsRequired()
                    .HasColumnName("campaign_name")
                    .HasMaxLength(300);

                entity.Property(e => e.Clicks).HasColumnName("clicks");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Days7ConversionRate)
                    .HasColumnName("days_7_conversion_rate")
                    .HasColumnType("money");

                entity.Property(e => e.Days7OtherSkuSale)
                    .HasColumnName("days_7_other_sku_sale")
                    .HasColumnType("money");

                entity.Property(e => e.Days7OtherSkuUnits).HasColumnName("days_7_other_sku_units");

                entity.Property(e => e.Days7SameSkuSale)
                    .HasColumnName("days_7_same_sku_sale")
                    .HasColumnType("money");

                entity.Property(e => e.Days7SameSkuUnits).HasColumnName("days_7_same_sku_units");

                entity.Property(e => e.Days7TotalOrders).HasColumnName("days_7_total_orders");

                entity.Property(e => e.Days7TotalSales)
                    .HasColumnName("days_7_total_sales")
                    .HasColumnType("money");

                entity.Property(e => e.Days7TotalUnits).HasColumnName("days_7_total_units");

                entity.Property(e => e.Impressions).HasColumnName("impressions");

                entity.Property(e => e.Keyword)
                    .IsRequired()
                    .HasColumnName("keyword")
                    .HasMaxLength(400);

                entity.Property(e => e.Spend)
                    .HasColumnName("spend")
                    .HasColumnType("money");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}