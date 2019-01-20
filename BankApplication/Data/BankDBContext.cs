using BankApplication.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApplication.Data
{
    public class BankDBContext : DbContext
    {
        public BankDBContext(DbContextOptions<BankDBContext> options)
    : base(options)
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Session> Session { get; set; }
    }
}
