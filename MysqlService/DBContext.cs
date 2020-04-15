using Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace MysqlService
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
       : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySql("Data Source=.;Initial Catalog=challenge;User Id=sa;Password=123456;");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Name = "张三", Password = "123456", UserName = "zs" },
                new User { UserId = 2, Name = "李四", Password = "123456", UserName = "ls" }
            );

            modelBuilder.Entity<Blacklist>().HasData(
                new Blacklist { Id = 1, Ip = "192.168.1.100", Createtime = DateTime.Now.AddMinutes(-2) },
                new Blacklist { Id = 2, Ip = "192.168.1.101", Createtime = DateTime.Now.AddMinutes(-3) }
            );
        }
        public DbSet<User> Uesrs { get; set; }
        public DbSet<Blacklist> Blacklists { get; set; }

    }
}
