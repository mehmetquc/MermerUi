using MediatR;
using MermerUi.Application.DTOs;
using MermerUi.Application.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermerUi.Persistence.Features.Urunlerimiz.Commands
{
    public class CreateUrunlerimizRequest:IRequest<ServiceResponse<UrunlerimizDTO>>
    {
        public Guid Id { get; set; }
        public string Baslik { get; set; }

        public string Fotograf { get; set; }

        public string UrunAdi { get; set; }
    }
}
