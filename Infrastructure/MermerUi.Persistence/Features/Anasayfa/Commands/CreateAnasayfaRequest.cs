using MediatR;
using MermerUi.Application.DTOs;
using MermerUi.Application.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MermerUi.Persistence.Features.Anasayfa.Commands
{
    public class CreateAnasayfaRequest:IRequest<ServiceResponse<AnasayfaDTO>>
    {
        public Guid Id { get; set; }
        public string Baslik { get; set; }
        public string Metin { get; set; }
        public string Fotograf { get; set; }
    }
}
