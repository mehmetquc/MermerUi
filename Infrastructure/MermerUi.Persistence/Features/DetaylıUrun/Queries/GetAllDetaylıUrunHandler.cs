using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using MermerUi.Application.DTOs;
using MermerUi.Application.ResponseModels;
using MermerUi.Persistence.Contexts;
using MermerUi.Persistence.Features.Anasayfa.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermerUi.Persistence.Features.DetaylıUrun.Queries
{
    public class GetAllDetaylıUrunHandler : IRequestHandler<GetAllDetaylıUrunRequest, ServiceResponse<List<DetaylıUrunDTO>>>
    {
        private readonly IMapper mapper;
        private readonly MermerDbContext context;
        private readonly IConfiguration configuration;
        public GetAllDetaylıUrunHandler(IMapper Mapper, MermerDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;

        }
        public async Task<ServiceResponse<List<DetaylıUrunDTO>>> Handle(GetAllDetaylıUrunRequest request, CancellationToken cancellationToken)
        {
            var dbDetaylıUrun = await context.DetaylıUruns.AsNoTracking().ProjectTo<DetaylıUrunDTO>(mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            if (dbDetaylıUrun == null)
                return new ServiceResponse<List<DetaylıUrunDTO>>();
            return new ServiceResponse<List<DetaylıUrunDTO>>
            {
                Value = dbDetaylıUrun
            };
        }
    }
}
