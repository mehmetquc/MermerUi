using MermerUi.Domain.Mappings;
using MermerUi.Domain.Models;
using MermerUi.Domain.Models.BaseModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace MermerUi.Persistence.Contexts
{
    public class MermerDbContext : DbContext
    {
        public MermerDbContext(DbContextOptions<MermerDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Anasayfa> Anasayfas { get; set; }
        public virtual DbSet<Ayricaliklarimiz>Ayricaliklarimizs { get; set; }
        public virtual DbSet<DetaylıUrun>DetaylıUruns { get; set; }
        public virtual DbSet<Hakkimizda>Hakkimizdas { get; set; }
        public virtual DbSet<Header>Headers { get; set; }
        public virtual DbSet<Referans>  Referans { get; set; }
        public virtual DbSet<Urunlerimiz>Urunlerimizs  { get; set; }
        public virtual DbSet<YıldızUrun>YıldızUruns  { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Yorum> Yorums { get; set; }


        private void Seed(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<User>().HasData(new User
            {
                Id = Guid.Parse("822E044B-5656-4B44-AD0F-01D7761E2CBE"),
                CreateDate = DateTime.Now,
                CreatedUser = "Admin",
                EMailAddress = "mehmetq@gmail.com",
                Password = "251533",
                FirstName = "Süper",
                LastName = "Admin",
                IsActive = true,

            });
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = Guid.Parse("C326EE05-4878-4219-958D-AD3CAEFA4E11"),
                CreateDate = DateTime.Now,
                CreatedUser = "Admin",
                EMailAddress = "yasemekmermer@gmail.com.tr",
                Password = "131580",
                FirstName = "Yasemek",
                LastName = "Mermer",
                IsActive = true,

            });
        }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaseModel>().UseTpcMappingStrategy();
            modelBuilder.ApplyConfiguration(new AnasayfaMap());
            modelBuilder.ApplyConfiguration(new AyricaliklarimizMap());
            modelBuilder.ApplyConfiguration(new DetaylıUrunMap());
            modelBuilder.ApplyConfiguration(new HakkimizdaMap());
            modelBuilder.ApplyConfiguration(new HeaderMap());
            modelBuilder.ApplyConfiguration(new ReferansMap());
            modelBuilder.ApplyConfiguration(new UrunlerimizMap());          
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new YıldızUrunMap());
            modelBuilder.ApplyConfiguration(new YorumMap());
            Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }


        }
    }

