using MediatR;
using MermerUi.Application.DTOs;
using MermerUi.Application.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermerUi.Persistence.Features.Hakkimizda.Commands
{
    public class UpdateHakkimizdaRequets : IRequest<ServiceResponse<HakkimizdaDTO>>
    {
        public Guid Id { get; set; }
        public string Baslik { get; set; }

        public string Metin { get; set; }

        public string Fotograf { get; set; }
    }
}
