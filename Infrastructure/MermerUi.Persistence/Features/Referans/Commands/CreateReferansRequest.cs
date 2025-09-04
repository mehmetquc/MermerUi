using MediatR;
using MermerUi.Application.DTOs;
using MermerUi.Application.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermerUi.Persistence.Features.Referans.Commands
{
    public class CreateReferansRequest:IRequest<ServiceResponse<ReferansDTO>>
    {
        public Guid Id { get; set; }
        public string Logo { get; set; }

    }
}
