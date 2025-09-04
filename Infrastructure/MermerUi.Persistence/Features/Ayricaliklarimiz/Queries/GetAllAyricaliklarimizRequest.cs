using MediatR;
using MermerUi.Application.DTOs;
using MermerUi.Application.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermerUi.Persistence.Features.Ayricaliklarimiz.Queries
{
    public class GetAllAyricaliklarimizRequest : IRequest<ServiceResponse<List<AyricaliklarimizDTO>>>
    {

    }
}
