using MermerUi.Application.DTOs.BaseModelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermerUi.Application.DTOs
{
    public class YıldızUrunDTO:BaseModelDTO
    {
        public string Fotograf { get; set; }
        public string Baslik { get; set; }
        public string Metin { get; set; }
    }
}
