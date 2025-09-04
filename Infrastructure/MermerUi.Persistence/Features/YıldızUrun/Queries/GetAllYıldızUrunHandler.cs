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

namespace MermerUi.Persistence.Features.YıldızUrun.Queries
{
    public class GetAllYıldızUrunHandler : IRequestHandler<GetAllYıldızUrunRequest, ServiceResponse<List<YıldızUrunDTO>>>
    {
        private readonly IMapper mapper;
        private readonly MermerDbContext context;
        private readonly IConfiguration configuration;
        public GetAllYıldızUrunHandler(IMapper Mapper, MermerDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;

        }
        public async Task<ServiceResponse<List<YıldızUrunDTO>>> Handle(GetAllYıldızUrunRequest request, CancellationToken cancellationToken)
        {
            var dbYıldızUrun = await context.YıldızUruns.AsNoTracking().ProjectTo<YıldızUrunDTO>(mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            if (dbYıldızUrun == null)
                return new ServiceResponse<List<YıldızUrunDTO>>();
            return new ServiceResponse<List<YıldızUrunDTO>>
            {
                Value = dbYıldızUrun
            };
        }
    }
}
