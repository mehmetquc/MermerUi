using MermerUi.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermerUi.Domain.Models
{
    public class Yorum:BaseModel
    {
        public string Baslık { get; set; }
        public string Metin { get; set; }
        public ICollection<YorumAcilamasi> yorumAcilamasis { get; set; }
    }
}
