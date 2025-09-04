using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermerUi.Application.ResponseModels
{
    public class ServiceResponse<T> : BaseResponse
    {
        public T Value { get; set; }
    }
}
