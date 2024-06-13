﻿// <auto-generated />
using System;
using LegendMotor.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LegendMotor.Dal.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240613060200_ninth")]
    partial class ninth
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("LegendMotor.Domain.Models.Area", b =>
                {
                    b.Property<string>("AreaCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("AreaCode");

                    b.ToTable("Area");
                });

            modelBuilder.Entity("LegendMotor.Domain.Models.BinLocation", b =>
                {
                    b.Property<string>("BinLocationCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("isActive")
                        .HasColumnType("INTEGER");

                    b.HasKey("BinLocationCode");

                    b.ToTable("BinLocation");
                });

            modelBuilder.Entity("LegendMotor.Domain.Models.BinLocationSpare", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("BinLocationCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("DL")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ROL")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Reserved")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SpareId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Stock")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("BinLocationSpare");
                });

            modelBuilder.Entity("LegendMotor.Domain.Models.BinLocationStaff", b =>
                {
                    b.Property<string>("BinLocationCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("StaffId")
                        .HasColumnType("TEXT");

                    b.HasKey("BinLocationCode", "StaffId");

                    b.ToTable("BinLocationStaff");
                });

            modelBuilder.Entity("LegendMotor.Domain.Models.Dealer", b =>
                {
                    b.Property<string>("DealerCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Fax")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telex")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("DealerCode");

                    b.ToTable("Dealer");
                });

            modelBuilder.Entity("LegendMotor.Domain.Models.IncomingOrder", b =>
                {
                    b.Property<string>("OrderId")
                        .HasColumnType("TEXT");

                    b.Property<string>("DealerCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DeliveryAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("InvoiceAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("InvoiceId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("InvoiceName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OrderHeaderId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Remark")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("staffId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("OrderId");

                    b.ToTable("IncomingOrder");
                });

            modelBuilder.Entity("LegendMotor.Domain.Models.OrderHeader", b =>
                {
                    b.Property<string>("OrderHeaderId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("OrderHeaderId");

                    b.ToTable("OrderHeader");
                });

            modelBuilder.Entity("LegendMotor.Domain.Models.Position", b =>
                {
                    b.Property<string>("PositionCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PositionCode");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("LegendMotor.Domain.Models.Spare", b =>
                {
                    b.Property<string>("SpareId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("TEXT");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Price")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("Url")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<int>("Weight")
                        .HasColumnType("INTEGER");

                    b.HasKey("SpareId");

                    b.ToTable("Spare");
                });

            modelBuilder.Entity("LegendMotor.Domain.Models.SparePrice", b =>
                {
                    b.Property<string>("SpareID")
                        .HasColumnType("TEXT");

                    b.Property<string>("SupplierCode")
                        .HasColumnType("TEXT");

                    b.Property<double>("PurchasingPrice")
                        .HasColumnType("REAL");

                    b.HasKey("SpareID", "SupplierCode");

                    b.ToTable("SparePrice");
                });

            modelBuilder.Entity("LegendMotor.Domain.Models.Staff", b =>
                {
                    b.Property<string>("StaffId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AreaCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LastLoginDateTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("LoginFailedCounter")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PositionCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("TEXT");

                    b.HasKey("StaffId");

                    b.HasIndex("Email", "Name")
                        .IsUnique();

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("LegendMotor.Domain.Models.Supplier", b =>
                {
                    b.Property<string>("SupplierCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("SupplierCode");

                    b.ToTable("Supplier");
                });
#pragma warning restore 612, 618
        }
    }
}
