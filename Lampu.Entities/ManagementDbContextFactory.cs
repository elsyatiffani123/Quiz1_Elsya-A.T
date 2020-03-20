using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lampu.Entities
{
    public class ManagementDbContextFactory : IDesignTimeDbContextFactory<ManagementDbContext>
    {
        public ManagementDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ManagementDbContext>();
            builder.UseSqlite("Data Source=reference.db");
            return new ManagementDbContext(builder.Options);
        }
    }
}
