using MermerUi.Application.DTOs.BaseModelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermerUi.Application.DTOs
{
    public class UrunlerimizDTO:BaseModelDTO
    {
        public string Baslik { get; set; }

        public string Fotograf { get; set; }

        public string UrunAdi { get; set; }
    }
}
