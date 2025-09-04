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

namespace MermerUi.Persistence.Features.Hakkimizda.Queries
{
    public class GetAllHakkimizdaHandler : IRequestHandler<GetAllHakkimizdaRequest, ServiceResponse<List<HakkimizdaDTO>>>
    {
        private readonly IMapper mapper;
        private readonly MermerDbContext context;
        private readonly IConfiguration configuration;
        public GetAllHakkimizdaHandler(IMapper Mapper, MermerDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;

        }
        public async Task<ServiceResponse<List<HakkimizdaDTO>>> Handle(GetAllHakkimizdaRequest request, CancellationToken cancellationToken)
        {
            var dbHakkimizda = await context.Hakkimizdas.AsNoTracking().ProjectTo<HakkimizdaDTO>(mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            if (dbHakkimizda == null)
                return new ServiceResponse<List<HakkimizdaDTO>>();
            return new ServiceResponse<List<HakkimizdaDTO>>
            {
                Value = dbHakkimizda
            };
        }
    }
}
