using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermerUi.Persistence.Contexts
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MermerDbContext>
    {
        public MermerDbContext CreateDbContext(string[] args)
        {
            ConfigurationManager configurationManager = new ConfigurationManager();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/MermerUi.Server"));
            configurationManager.AddJsonFile("appsettings.json");
            var builder = new DbContextOptionsBuilder<MermerDbContext>();
            //var dbDataSource = new NpgsqlDataSourceBuilder(configurationManager.GetConnectionString("PostgreSql"));
            builder.UseSqlServer(configurationManager.GetConnectionString("Mssql"));
            return new MermerDbContext(builder.Options);
        }
    }
}
