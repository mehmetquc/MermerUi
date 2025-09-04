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

namespace MermerUi.Persistence.Features.DetaylıUrun.Queries
{
    public class GetByIdDetaylıUrunHandler : IRequestHandler<GetByIdDetaylıUrunRequest, ServiceResponse<DetaylıUrunDTO>>
    {
        private readonly IMapper mapper;
        private readonly MermerDbContext context;
        private readonly IConfiguration configuration;
        public GetByIdDetaylıUrunHandler(IMapper Mapper, MermerDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;

        }
        public async Task<ServiceResponse<DetaylıUrunDTO>> Handle(GetByIdDetaylıUrunRequest request, CancellationToken cancellationToken)
        {
            var dbDetaylıUrun = await context.DetaylıUruns.AsNoTracking().ProjectTo<DetaylıUrunDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);
            if (dbDetaylıUrun == null)
                return new ServiceResponse<DetaylıUrunDTO>();
            return new ServiceResponse<DetaylıUrunDTO>
            {
                Value = dbDetaylıUrun
            };
        }
    }
}
