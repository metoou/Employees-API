﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OTS.DataAccess;

namespace OTS.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OTS.Core.Domain.Entities.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("da36b1a5-6a04-4b08-a766-ecf55ce477f2"),
                            Name = "Отдел разработки",
                            Salary = 100000.0
                        },
                        new
                        {
                            Id = new Guid("10ee75ce-151b-4640-998e-a509fbe57ec3"),
                            Name = "Отдел продаж",
                            Salary = 90000.0
                        },
                        new
                        {
                            Id = new Guid("14f01451-5aeb-486b-95ab-0e2c692acd8a"),
                            Name = "Отдел тестирования",
                            Salary = 70000.0
                        },
                        new
                        {
                            Id = new Guid("d029e569-26f1-41ad-a60a-a94490341ed6"),
                            Name = "Отдел внедрения",
                            Salary = 80000.0
                        },
                        new
                        {
                            Id = new Guid("38eca135-c3b8-46bd-a58d-c367a5984853"),
                            Name = "Отдел исследований",
                            Salary = 100000.0
                        });
                });

            modelBuilder.Entity("OTS.Core.Domain.Entities.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = new Guid("06d5dc01-15bb-411f-8777-214984d65e70"),
                            DepartmentId = new Guid("da36b1a5-6a04-4b08-a766-ecf55ce477f2"),
                            Name = "Петров Иван Федорович",
                            Salary = 120000.0
                        },
                        new
                        {
                            Id = new Guid("2da2ac2d-cf04-4904-9c2d-1f691837c18b"),
                            DepartmentId = new Guid("10ee75ce-151b-4640-998e-a509fbe57ec3"),
                            Name = "Веретенникова Елизавета Петровна",
                            Salary = 80000.0
                        },
                        new
                        {
                            Id = new Guid("9ca6f0e5-47de-4cb1-b056-e6db57c6d51a"),
                            DepartmentId = new Guid("14f01451-5aeb-486b-95ab-0e2c692acd8a"),
                            Name = "Черепанов Александр Сергеевич",
                            Salary = 80000.0
                        },
                        new
                        {
                            Id = new Guid("32f8a811-6a86-463b-8772-a5a7f91d733f"),
                            DepartmentId = new Guid("d029e569-26f1-41ad-a60a-a94490341ed6"),
                            Name = "Лебедева Евгения Александровна",
                            Salary = 80000.0
                        },
                        new
                        {
                            Id = new Guid("58816b97-9a46-4800-bedc-6b273fb40c82"),
                            DepartmentId = new Guid("38eca135-c3b8-46bd-a58d-c367a5984853"),
                            Name = "Белоусов Сергей Петрович",
                            Salary = 80000.0
                        });
                });

            modelBuilder.Entity("OTS.Core.Domain.Entities.Employee", b =>
                {
                    b.HasOne("OTS.Core.Domain.Entities.Department", null)
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId");
                });

            modelBuilder.Entity("OTS.Core.Domain.Entities.Department", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
