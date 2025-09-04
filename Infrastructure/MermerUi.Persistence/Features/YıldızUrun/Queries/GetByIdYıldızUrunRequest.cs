using MediatR;
using MermerUi.Application.DTOs;
using MermerUi.Application.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermerUi.Persistence.Features.YıldızUrun.Queries
{
    public class GetByIdYıldızUrunRequest:IRequest<ServiceResponse<YıldızUrunDTO>>
    {
        public Guid Id { get; set; }
    }
}
