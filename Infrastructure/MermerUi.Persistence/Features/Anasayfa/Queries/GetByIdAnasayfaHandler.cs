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
    public class GetByIdAnasayfaHandler : IRequestHandler<GetByIdAnasayfaRequest, ServiceResponse<AnasayfaDTO>>
    {
        private readonly IMapper mapper;
        private readonly MermerDbContext context;
        private readonly IConfiguration configuration;
        public GetByIdAnasayfaHandler(IMapper Mapper, MermerDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;

        }
        public async Task<ServiceResponse<AnasayfaDTO>> Handle(GetByIdAnasayfaRequest request, CancellationToken cancellationToken)
        {
            var dbAnasayfa = await context.Anasayfas.AsNoTracking().ProjectTo<AnasayfaDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);
            if (dbAnasayfa == null)
                return new ServiceResponse<AnasayfaDTO>();
            return new ServiceResponse<AnasayfaDTO>
            {
                Value = dbAnasayfa
            };
        }
    }
}
