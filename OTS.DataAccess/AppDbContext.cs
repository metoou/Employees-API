using Microsoft.EntityFrameworkCore;
using OTS.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OTS.DataAccess
{
    public class AppDbContext
        : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);


            modelbuilder.Entity<Department>().HasData(new Department
            {
                Id = new Guid("da36b1a5-6a04-4b08-a766-ecf55ce477f2"),
                Name = "Отдел разработки",
                Salary = 100000.0
            });

            modelbuilder.Entity<Department>().HasData(new Department
            {
                Id = new Guid("10ee75ce-151b-4640-998e-a509fbe57ec3"),
                Name = "Отдел продаж",
                Salary = 90000.0
            });

            modelbuilder.Entity<Department>().HasData(new Department
            {
                Id = new Guid("14f01451-5aeb-486b-95ab-0e2c692acd8a"),
                Name = "Отдел тестирования",
                Salary = 70000.0
            });

            modelbuilder.Entity<Department>().HasData(new Department
            {
                Id = new Guid("d029e569-26f1-41ad-a60a-a94490341ed6"),
                Name = "Отдел внедрения",
                Salary = 80000.0
            });

            modelbuilder.Entity<Department>().HasData(new Department
            {
                Id = new Guid("38eca135-c3b8-46bd-a58d-c367a5984853"),
                Name = "Отдел исследований",
                Salary = 100000.0
            });

            modelbuilder.Entity<Employee>().HasData(new Employee
            {
                Id = new Guid("06d5dc01-15bb-411f-8777-214984d65e70"),
                Name = "Петров Иван Федорович",
                Salary = 120000.0,
                DepartmentId = new Guid("da36b1a5-6a04-4b08-a766-ecf55ce477f2")
            });

            modelbuilder.Entity<Employee>().HasData(new Employee
            {
                Id = new Guid("2da2ac2d-cf04-4904-9c2d-1f691837c18b"),
                Name = "Веретенникова Елизавета Петровна",
                Salary = 80000.0,
                DepartmentId = new Guid("10ee75ce-151b-4640-998e-a509fbe57ec3")
            });

            modelbuilder.Entity<Employee>().HasData(new Employee
            {
                Id = new Guid("9ca6f0e5-47de-4cb1-b056-e6db57c6d51a"),
                Name = "Черепанов Александр Сергеевич",
                Salary = 80000.0,
                DepartmentId = new Guid("14f01451-5aeb-486b-95ab-0e2c692acd8a")
            });

            modelbuilder.Entity<Employee>().HasData(new Employee
            {
                Id = new Guid("32f8a811-6a86-463b-8772-a5a7f91d733f"),
                Name = "Лебедева Евгения Александровна",
                Salary = 80000.0,
                DepartmentId = new Guid("d029e569-26f1-41ad-a60a-a94490341ed6")
            });

            modelbuilder.Entity<Employee>().HasData(new Employee
            {
                Id = new Guid("58816b97-9a46-4800-bedc-6b273fb40c82"),
                Name = "Белоусов Сергей Петрович",
                Salary = 80000.0,
                DepartmentId = new Guid("38eca135-c3b8-46bd-a58d-c367a5984853")
            });

        }
    }
}
