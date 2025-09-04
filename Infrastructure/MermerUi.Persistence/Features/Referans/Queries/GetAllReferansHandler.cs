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

namespace MermerUi.Persistence.Features.Referans.Queries
{
    public class GetAllReferansHandler : IRequestHandler<GetAllReferansRequest, ServiceResponse<List<ReferansDTO>>>
    {
        private readonly IMapper mapper;
        private readonly MermerDbContext context;
        private readonly IConfiguration configuration;
        public GetAllReferansHandler(IMapper Mapper, MermerDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;

        }

        public async Task<ServiceResponse<List<ReferansDTO>>> Handle(GetAllReferansRequest request, CancellationToken cancellationToken)
        {

            var dbReferans = await context.Referans.AsNoTracking().ProjectTo<ReferansDTO>(mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            if (dbReferans == null)
                return new ServiceResponse<List<ReferansDTO>>();
            return new ServiceResponse<List<ReferansDTO>>
            {
                Value = dbReferans
            };
        }
    }
}
