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

namespace MermerUi.Persistence.Features.Header.Queries
{
    public class GetByıdHeaderHandler : IRequestHandler<GetByIdHeaderRequest, ServiceResponse<HeaderDTO>>
    {
        private readonly IMapper mapper;
        private readonly MermerDbContext context;
        private readonly IConfiguration configuration;
        public GetByıdHeaderHandler(IMapper Mapper, MermerDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;

        }
        public async Task<ServiceResponse<HeaderDTO>> Handle(GetByIdHeaderRequest request, CancellationToken cancellationToken)
        {
            var dbHeader = await context.Headers.AsNoTracking().ProjectTo<HeaderDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);
            if (dbHeader == null)
                return new ServiceResponse<HeaderDTO>();
            return new ServiceResponse<HeaderDTO>
            {
                Value = dbHeader
            };
        }
    }
}
