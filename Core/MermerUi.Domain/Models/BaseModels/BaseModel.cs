using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermerUi.Domain.Models.BaseModels
{
    public abstract class BaseModel
    {
        public Guid Id { get; set; }
        public string CreatedUser { get; set; }
        public DateTime CreateDate { get; set; }
        public string? UpdatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? Decription { get; set; }
    }
}
