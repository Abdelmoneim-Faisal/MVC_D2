﻿// <auto-generated />
using System;
using MVC_D2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVC_D2.Migrations
{
    [DbContext(typeof(EmpContext))]
    partial class EmpContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MVC_D2.Models.Departments", b =>
                {
                    b.Property<int>("Dnum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Dnum"));

                    b.Property<string>("Dname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MGRSSN")
                        .HasColumnType("int");

                    b.Property<DateTime>("MGRStart_Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Dnum");

                    b.HasIndex("MGRSSN");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("MVC_D2.Models.Dependent", b =>
                {
                    b.Property<int>("ESSN")
                        .HasColumnType("int");

                    b.Property<string>("Dependent_name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("Bdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Sex")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ESSN", "Dependent_name");

                    b.ToTable("Dependants");
                });

            modelBuilder.Entity("MVC_D2.Models.Employee", b =>
                {
                    b.Property<int>("SSN")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SSN"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Bdate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Dno")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Salary")
                        .HasColumnType("money");

                    b.Property<string>("Sex")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Superssn")
                        .HasColumnType("int");

                    b.HasKey("SSN");

                    b.HasIndex("Dno");

                    b.HasIndex("Superssn");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("MVC_D2.Models.Project", b =>
                {
                    b.Property<int>("Pnumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Pnumber"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Dnum")
                        .HasColumnType("int");

                    b.Property<string>("Plocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Pnumber");

                    b.HasIndex("Dnum");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("MVC_D2.Models.WorksFor", b =>
                {
                    b.Property<int>("ESSn")
                        .HasColumnType("int");

                    b.Property<int>("Pno")
                        .HasColumnType("int");

                    b.Property<int>("Hours")
                        .HasColumnType("int");

                    b.HasKey("ESSn", "Pno");

                    b.HasIndex("Pno");

                    b.ToTable("WorksFor");
                });

            modelBuilder.Entity("MVC_D2.Models.Departments", b =>
                {
                    b.HasOne("MVC_D2.Models.Employee", "manager")
                        .WithMany()
                        .HasForeignKey("MGRSSN");

                    b.Navigation("manager");
                });

            modelBuilder.Entity("MVC_D2.Models.Dependent", b =>
                {
                    b.HasOne("MVC_D2.Models.Employee", "employee")
                        .WithMany("dependents")
                        .HasForeignKey("ESSN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("employee");
                });

            modelBuilder.Entity("MVC_D2.Models.Employee", b =>
                {
                    b.HasOne("MVC_D2.Models.Departments", "department")
                        .WithMany("Employees")
                        .HasForeignKey("Dno");

                    b.HasOne("MVC_D2.Models.Employee", "EmpSupervisor")
                        .WithMany("team")
                        .HasForeignKey("Superssn");

                    b.Navigation("EmpSupervisor");

                    b.Navigation("department");
                });

            modelBuilder.Entity("MVC_D2.Models.Project", b =>
                {
                    b.HasOne("MVC_D2.Models.Departments", "department")
                        .WithMany("Projects")
                        .HasForeignKey("Dnum");

                    b.Navigation("department");
                });

            modelBuilder.Entity("MVC_D2.Models.WorksFor", b =>
                {
                    b.HasOne("MVC_D2.Models.Employee", "employee")
                        .WithMany("empProjects")
                        .HasForeignKey("ESSn")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVC_D2.Models.Project", "project")
                        .WithMany("empProjects")
                        .HasForeignKey("Pno")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("employee");

                    b.Navigation("project");
                });

            modelBuilder.Entity("MVC_D2.Models.Departments", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("MVC_D2.Models.Employee", b =>
                {
                    b.Navigation("dependents");

                    b.Navigation("empProjects");

                    b.Navigation("team");
                });

            modelBuilder.Entity("MVC_D2.Models.Project", b =>
                {
                    b.Navigation("empProjects");
                });
#pragma warning restore 612, 618
        }
    }
}
