using MediatR;
using MermerUi.Application.DTOs;
using MermerUi.Application.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MermerUi.Persistence.Features.Header.Commands
{
    public class CreateHeaderRequest:IRequest<ServiceResponse<HeaderDTO>>
    {
        public  Guid Id { get; set; }
        public string Logo { get; set; }

    }
}
