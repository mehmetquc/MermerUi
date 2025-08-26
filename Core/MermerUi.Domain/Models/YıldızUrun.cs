using MermerUi.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermerUi.Domain.Models
{
    public class YıldızUrun:BaseModel
    {
        public string Fotograf { get; set; }
        public string Baslik { get; set; }
        public string Metin { get; set; }
    }
}
