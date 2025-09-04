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
    public class GetByIdHakkimizdaHandler : IRequestHandler<GetByIdHakkimizdaRequest, ServiceResponse<HakkimizdaDTO>>
    {
        private readonly IMapper mapper;
        private readonly MermerDbContext context;
        private readonly IConfiguration configuration;
        public GetByIdHakkimizdaHandler(IMapper Mapper, MermerDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;

        }
        public async Task<ServiceResponse<HakkimizdaDTO>> Handle(GetByIdHakkimizdaRequest request, CancellationToken cancellationToken)
        {
            var dbHakkimizda = await context.Hakkimizdas.AsNoTracking().ProjectTo<HakkimizdaDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);
            if (dbHakkimizda == null)
                return new ServiceResponse<HakkimizdaDTO>();
            return new ServiceResponse<HakkimizdaDTO>
            {
                Value = dbHakkimizda
            };
        }
    }
}
