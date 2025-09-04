using MermerUi.Application.DTOs.BaseModelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermerUi.Application.DTOs
{
    public class DetaylıUrunDTO:BaseModelDTO
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
