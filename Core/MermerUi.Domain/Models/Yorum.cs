using MermerUi.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MermerUi.Domain.Models
{
    public class Yorum:BaseModel
    {
        public string Baslis { get; set; }
        public string Metim { get; set; }
   

    }
}
