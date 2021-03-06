﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using filedChallenge.Data;

namespace filedChallenge.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210225130821_listofpayment")]
    partial class listofpayment
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("filedChallenge.Entities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CardHolder")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreditCardNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaymentStateId")
                        .HasColumnType("int");

                    b.Property<string>("SecurityCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PaymentStateId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("filedChallenge.Entities.PaymentState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("PaymentStatus")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PaymentStates");
                });

            modelBuilder.Entity("filedChallenge.Entities.Payment", b =>
                {
                    b.HasOne("filedChallenge.Entities.PaymentState", "PaymentState")
                        .WithMany("Payment")
                        .HasForeignKey("PaymentStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentState");
                });

            modelBuilder.Entity("filedChallenge.Entities.PaymentState", b =>
                {
                    b.Navigation("Payment");
                });
#pragma warning restore 612, 618
        }
    }
}
