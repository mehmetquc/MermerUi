using MediatR;
using MermerUi.Application.DTOs;
using MermerUi.Application.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermerUi.Persistence.Features.Yorum.Commands
{
    public class UpdateYorumRequest:IRequest<ServiceResponse<YorumDTO>>
    {
        public Guid Id { get; set; }
        public string Baslis { get; set; }
        public string Metim { get; set; }
    }
}
