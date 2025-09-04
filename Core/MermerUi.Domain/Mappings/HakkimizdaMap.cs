using MermerUi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermerUi.Domain.Mappings
{
    public class HakkimizdaMap : IEntityTypeConfiguration<Hakkimizda>
    {
        public void Configure(EntityTypeBuilder<Hakkimizda> builder)
        {
            
        }
    }
}
