namespace Gathering.Data.Design;

using Gathering.Data.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// This is an ef core migration class-only, use your local dev to build the migrations.
public class MigrationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

        optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=WT.GatheringService;Integrated Security=True;multipleactiveresultsets=True;App=Apply");

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}

