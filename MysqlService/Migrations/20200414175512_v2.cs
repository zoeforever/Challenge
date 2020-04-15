using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MysqlService.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blacklists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ip = table.Column<string>(nullable: true),
                    Createtime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blacklists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uesrs",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uesrs", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Blacklists",
                columns: new[] { "Id", "Createtime", "Ip" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 4, 15, 1, 53, 11, 496, DateTimeKind.Local), "192.168.1.100" },
                    { 2, new DateTime(2020, 4, 15, 1, 52, 11, 496, DateTimeKind.Local), "192.168.1.101" }
                });

            migrationBuilder.InsertData(
                table: "Uesrs",
                columns: new[] { "UserId", "Name", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, "张三", "123456", "zs" },
                    { 2, "李四", "123456", "ls" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blacklists");

            migrationBuilder.DropTable(
                name: "Uesrs");
        }
    }
}
