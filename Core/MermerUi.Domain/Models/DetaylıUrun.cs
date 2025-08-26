using MermerUi.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermerUi.Domain.Models
{
    public class DetaylıUrun:BaseModel
    {
        public string Baslık { get; set; }
        public string UrunAcıklamaBaslıgı { get; set; }
        public string urunMetni { get; set; }
        public string Detay1 { get; set; }
        public string Detay2 { get; set; }
        public string Detay3 { get; set; }
        public string? Detay4 { get; set; }
        public string? Detay5 { get; set; }

    }
}
