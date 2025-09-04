using MediatR;
using MermerUi.Application.DTOs;
using MermerUi.Application.ResponseModels;
using MermerUi.Persistence.Features.Referans.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermerUi.Persistence.Features.Urunlerimiz.Commands
{
    public class DeleteUrunlerimizRequest:IRequest<ServiceResponse<UrunlerimizDTO>>
    {
        public Guid Id { get; set; }
    }
}
