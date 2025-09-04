using MediatR;
using MermerUi.Application.DTOs;
using MermerUi.Application.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermerUi.Persistence.Features.Ayricaliklarimiz.Commands
{
    public class UpdateAyricaliklarimizRequest : IRequest<ServiceResponse<AyricaliklarimizDTO>>
    {
        public Guid Id { get; set; }
        public string Ikon { get; set; }

        public string Metin { get; set; }
    }
}
