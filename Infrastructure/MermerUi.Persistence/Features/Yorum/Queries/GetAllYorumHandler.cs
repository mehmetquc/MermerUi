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
    public class GetAllYorumHandler : IRequestHandler<GetAllYorumRequest, ServiceResponse<List<YorumDTO>>>
    {
        private readonly IMapper mapper;
        private readonly MermerDbContext context;
        private readonly IConfiguration configuration;
        public GetAllYorumHandler(IMapper Mapper, MermerDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;

        }
        public async Task<ServiceResponse<List<YorumDTO>>> Handle(GetAllYorumRequest request, CancellationToken cancellationToken)
        {
            var dbYorum = await context.Yorums.AsNoTracking().ProjectTo<YorumDTO>(mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            if (dbYorum == null)
                return new ServiceResponse<List<YorumDTO>>();
            return new ServiceResponse<List<YorumDTO>>
            {
                Value = dbYorum
            };
        }
    }
}
