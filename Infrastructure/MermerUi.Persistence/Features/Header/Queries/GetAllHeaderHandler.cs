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
    public class GetAllHeaderHandler : IRequestHandler<GetAllHeaderRequest, ServiceResponse<List<HeaderDTO>>>
    {
        private readonly IMapper mapper;
        private readonly MermerDbContext context;
        private readonly IConfiguration configuration;
        public GetAllHeaderHandler(IMapper Mapper, MermerDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;

        }
        public async Task<ServiceResponse<List<HeaderDTO>>> Handle(GetAllHeaderRequest request, CancellationToken cancellationToken)
        {
            var dbHeader = await context.Headers.AsNoTracking().ProjectTo<HeaderDTO>(mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            if (dbHeader == null)
                return new ServiceResponse<List<HeaderDTO>>();
            return new ServiceResponse<List<HeaderDTO>>
            {
                Value = dbHeader
            };
        }
    }
}
