using MediatR;
using MermerUi.Application.DTOs;
using MermerUi.Application.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermerUi.Persistence.Features.DetaylıUrun.Commands
{
    public class UpdateDetaylıUrunRequest:IRequest<ServiceResponse<DetaylıUrunDTO>>
    {
        public  Guid Id { get; set; }
        public string Baslık { get; set; }
        public string UrunAcıklamaBaslıgı { get; set; }
        public string urunMetni { get; set; }
        public string Detay1 { get; set; }
        public string Detay2 { get; set; }
        public string Detay3 { get; set; }
        public string? Detay4 { get; set; }
        public string? Detay5 { get; set; }
    }
}
