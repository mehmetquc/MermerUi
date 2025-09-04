using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using MermerUi.Application.DTOs;
using MermerUi.Application.ResponseModels;
using MermerUi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermerUi.Persistence.Features.Yorum.Queries
{
    public class GetByIdYorumHanler : IRequestHandler<GetByIdYorumRequest, ServiceResponse<YorumDTO>>
    {
        private readonly IMapper mapper;
        private readonly MermerDbContext context;
        private readonly IConfiguration configuration;
        public GetByIdYorumHanler(IMapper Mapper, MermerDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;

        }
        public async Task<ServiceResponse<YorumDTO>> Handle(GetByIdYorumRequest request, CancellationToken cancellationToken)
        {
            var dbYorum = await context.Yorums.AsNoTracking().ProjectTo<YorumDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);
            if (dbYorum == null)
                return new ServiceResponse<YorumDTO>();
            return new ServiceResponse<YorumDTO>
            {
                Value = dbYorum
            };
        }
    }
}
