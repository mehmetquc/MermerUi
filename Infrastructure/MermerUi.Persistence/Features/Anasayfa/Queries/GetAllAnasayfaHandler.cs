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

namespace MermerUi.Persistence.Features.Anasayfa.Queries
{
    public class GetAllAnasayfaHandler : IRequestHandler<GetAllAnasayfaRequest, ServiceResponse<List<AnasayfaDTO>>>
    {
        private readonly IMapper mapper;
        private readonly MermerDbContext context;
        private readonly IConfiguration configuration;
        public GetAllAnasayfaHandler(IMapper Mapper, MermerDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;

        }

        public async Task<ServiceResponse<List<AnasayfaDTO>>> Handle(GetAllAnasayfaRequest request, CancellationToken cancellationToken)
        {
            var dbAnasayfa = await context.Anasayfas.AsNoTracking().ProjectTo<AnasayfaDTO>(mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            if (dbAnasayfa == null)
                return new ServiceResponse<List<AnasayfaDTO>>();
            return new ServiceResponse<List<AnasayfaDTO>>
            {
                Value = dbAnasayfa
            };
        }
    }
}
