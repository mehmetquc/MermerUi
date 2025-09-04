using MermerUi.Application.DTOs.BaseModelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermerUi.Application.DTOs
{
    public class AnasayfaDTO:BaseModelDTO
    {
        public string Baslik { get; set; }
        public string Metin { get; set; }
        public string Fotograf { get; set; }
    }
}
