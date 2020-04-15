﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MysqlService;

namespace MysqlService.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20200414175512_v2")]
    partial class v2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Entities.Blacklist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Createtime");

                    b.Property<string>("Ip");

                    b.HasKey("Id");

                    b.ToTable("Blacklists");

                    b.HasData(
                        new { Id = 1, Createtime = new DateTime(2020, 4, 15, 1, 53, 11, 496, DateTimeKind.Local), Ip = "192.168.1.100" },
                        new { Id = 2, Createtime = new DateTime(2020, 4, 15, 1, 52, 11, 496, DateTimeKind.Local), Ip = "192.168.1.101" }
                    );
                });

            modelBuilder.Entity("Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("UserName");

                    b.HasKey("UserId");

                    b.ToTable("Uesrs");

                    b.HasData(
                        new { UserId = 1, Name = "张三", Password = "123456", UserName = "zs" },
                        new { UserId = 2, Name = "李四", Password = "123456", UserName = "ls" }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}
