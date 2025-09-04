using MediatR;
using MermerUi.Application.DTOs;
using MermerUi.Application.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermerUi.Persistence.Features.YıldızUrun.Commands
{
    public class DeleteYıldızUrunRequest:IRequest<ServiceResponse<YıldızUrunDTO>>
    {
        public Guid Id { get; set; }
    }
}
