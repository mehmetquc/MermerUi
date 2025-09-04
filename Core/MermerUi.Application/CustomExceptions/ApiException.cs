using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermerUi.Application.CustomExceptions
{
    public class ApiException:Exception
    {
        public ApiException(string Message, Exception InnerException) : base(Message, InnerException)
        {

        }
        public ApiException(string Message) : base(Message)
        {

        }
    }
}
