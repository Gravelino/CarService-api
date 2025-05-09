﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Persistence.Data;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(CarServiceDbContext))]
    partial class CarServiceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Application.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("LastServiceDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Application.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Application.Models.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("FeedbackDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<int>("VisitId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("VisitId");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("Application.Models.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("ServiceId")
                        .HasColumnType("integer");

                    b.Property<int>("VisitId")
                        .HasColumnType("integer");

                    b.Property<int>("WorkerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.HasIndex("VisitId");

                    b.HasIndex("WorkerId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("Application.Models.JobSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("JobId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("WorkerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("JobId")
                        .IsUnique();

                    b.HasIndex("WorkerId");

                    b.ToTable("JobSchedules");
                });

            modelBuilder.Entity("Application.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("VisitId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("VisitId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Application.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("BasePrice")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Duration")
                        .HasColumnType("integer");

                    b.Property<int>("ServiceCategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ServiceCategoryId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("Application.Models.ServiceCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ServiceCategories");
                });

            modelBuilder.Entity("Application.Models.ServiceTool", b =>
                {
                    b.Property<int>("ServicesId")
                        .HasColumnType("integer");

                    b.Property<int>("ToolsId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ServicesId", "ToolsId");

                    b.HasIndex("ToolsId");

                    b.ToTable("ServiceTools");
                });

            modelBuilder.Entity("Application.Models.Tool", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SerialNumber")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Tools");
                });

            modelBuilder.Entity("Application.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("PaymentId")
                        .HasColumnType("integer");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("PaymentId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Application.Models.Visit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CarId")
                        .HasColumnType("integer");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("VisitEndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("VisitStartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Visits");
                });

            modelBuilder.Entity("Application.Models.Worker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Salary")
                        .HasColumnType("numeric");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("Application.Models.WorkerService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<int>("ServiceId")
                        .HasColumnType("integer");

                    b.Property<int>("WorkerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.HasIndex("WorkerId");

                    b.ToTable("WorkerServices");
                });

            modelBuilder.Entity("ServiceTool", b =>
                {
                    b.Property<int>("ServicesId")
                        .HasColumnType("integer");

                    b.Property<int>("ToolsId")
                        .HasColumnType("integer");

                    b.HasKey("ServicesId", "ToolsId");

                    b.HasIndex("ToolsId");

                    b.ToTable("ServiceTool");
                });

            modelBuilder.Entity("Application.Models.Car", b =>
                {
                    b.HasOne("Application.Models.Customer", "Customer")
                        .WithMany("Cars")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Application.Models.Feedback", b =>
                {
                    b.HasOne("Application.Models.Visit", "Visit")
                        .WithMany("Feedbacks")
                        .HasForeignKey("VisitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Visit");
                });

            modelBuilder.Entity("Application.Models.Job", b =>
                {
                    b.HasOne("Application.Models.Service", "Service")
                        .WithMany("Jobs")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Application.Models.Visit", "Visit")
                        .WithMany("Jobs")
                        .HasForeignKey("VisitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Application.Models.Worker", "Worker")
                        .WithMany()
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");

                    b.Navigation("Visit");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("Application.Models.JobSchedule", b =>
                {
                    b.HasOne("Application.Models.Job", "Job")
                        .WithOne("JobSchedule")
                        .HasForeignKey("Application.Models.JobSchedule", "JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Application.Models.Worker", "Worker")
                        .WithMany("JobSchedules")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("Application.Models.Payment", b =>
                {
                    b.HasOne("Application.Models.Visit", "Visit")
                        .WithMany("Payments")
                        .HasForeignKey("VisitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Visit");
                });

            modelBuilder.Entity("Application.Models.Service", b =>
                {
                    b.HasOne("Application.Models.ServiceCategory", "ServiceCategory")
                        .WithMany("Services")
                        .HasForeignKey("ServiceCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ServiceCategory");
                });

            modelBuilder.Entity("Application.Models.ServiceTool", b =>
                {
                    b.HasOne("Application.Models.Service", "Service")
                        .WithMany("ServiceTools")
                        .HasForeignKey("ServicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Application.Models.Tool", "Tool")
                        .WithMany("ServiceTools")
                        .HasForeignKey("ToolsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");

                    b.Navigation("Tool");
                });

            modelBuilder.Entity("Application.Models.Transaction", b =>
                {
                    b.HasOne("Application.Models.Payment", "Payment")
                        .WithMany()
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Payment");
                });

            modelBuilder.Entity("Application.Models.Visit", b =>
                {
                    b.HasOne("Application.Models.Car", "Car")
                        .WithMany("Visits")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Application.Models.Customer", "Customer")
                        .WithMany("Visits")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Application.Models.WorkerService", b =>
                {
                    b.HasOne("Application.Models.Service", "Service")
                        .WithMany("WorkerServices")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Application.Models.Worker", "Worker")
                        .WithMany("WorkerServices")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("ServiceTool", b =>
                {
                    b.HasOne("Application.Models.Service", null)
                        .WithMany()
                        .HasForeignKey("ServicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Application.Models.Tool", null)
                        .WithMany()
                        .HasForeignKey("ToolsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Application.Models.Car", b =>
                {
                    b.Navigation("Visits");
                });

            modelBuilder.Entity("Application.Models.Customer", b =>
                {
                    b.Navigation("Cars");

                    b.Navigation("Visits");
                });

            modelBuilder.Entity("Application.Models.Job", b =>
                {
                    b.Navigation("JobSchedule");
                });

            modelBuilder.Entity("Application.Models.Service", b =>
                {
                    b.Navigation("Jobs");

                    b.Navigation("ServiceTools");

                    b.Navigation("WorkerServices");
                });

            modelBuilder.Entity("Application.Models.ServiceCategory", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("Application.Models.Tool", b =>
                {
                    b.Navigation("ServiceTools");
                });

            modelBuilder.Entity("Application.Models.Visit", b =>
                {
                    b.Navigation("Feedbacks");

                    b.Navigation("Jobs");

                    b.Navigation("Payments");
                });

            modelBuilder.Entity("Application.Models.Worker", b =>
                {
                    b.Navigation("JobSchedules");

                    b.Navigation("WorkerServices");
                });
#pragma warning restore 612, 618
        }
    }
}
