using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OTS.DataAccess.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "Salary" },
                values: new object[,]
                {
                    { new Guid("da36b1a5-6a04-4b08-a766-ecf55ce477f2"), "Отдел разработки", 100000.0 },
                    { new Guid("10ee75ce-151b-4640-998e-a509fbe57ec3"), "Отдел продаж", 90000.0 },
                    { new Guid("14f01451-5aeb-486b-95ab-0e2c692acd8a"), "Отдел тестирования", 70000.0 },
                    { new Guid("d029e569-26f1-41ad-a60a-a94490341ed6"), "Отдел внедрения", 80000.0 },
                    { new Guid("38eca135-c3b8-46bd-a58d-c367a5984853"), "Отдел исследований", 100000.0 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "DepartmentId", "Name", "Salary" },
                values: new object[,]
                {
                    { new Guid("06d5dc01-15bb-411f-8777-214984d65e70"), new Guid("da36b1a5-6a04-4b08-a766-ecf55ce477f2"), "Петров Иван Федорович", 120000.0 },
                    { new Guid("2da2ac2d-cf04-4904-9c2d-1f691837c18b"), new Guid("10ee75ce-151b-4640-998e-a509fbe57ec3"), "Веретенникова Елизавета Петровна", 80000.0 },
                    { new Guid("9ca6f0e5-47de-4cb1-b056-e6db57c6d51a"), new Guid("14f01451-5aeb-486b-95ab-0e2c692acd8a"), "Черепанов Александр Сергеевич", 80000.0 },
                    { new Guid("32f8a811-6a86-463b-8772-a5a7f91d733f"), new Guid("d029e569-26f1-41ad-a60a-a94490341ed6"), "Лебедева Евгения Александровна", 80000.0 },
                    { new Guid("58816b97-9a46-4800-bedc-6b273fb40c82"), new Guid("38eca135-c3b8-46bd-a58d-c367a5984853"), "Белоусов Сергей Петрович", 80000.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_DepartmentId",
                table: "Students",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
