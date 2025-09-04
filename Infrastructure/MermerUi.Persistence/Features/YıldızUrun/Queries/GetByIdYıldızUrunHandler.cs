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
    public class GetByIdYıldızUrunHandler : IRequestHandler<GetByIdYıldızUrunRequest, ServiceResponse<YıldızUrunDTO>>
    {
        private readonly IMapper mapper;
        private readonly MermerDbContext context;
        private readonly IConfiguration configuration;
        public GetByIdYıldızUrunHandler(IMapper Mapper, MermerDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;

        }
        public async Task<ServiceResponse<YıldızUrunDTO>> Handle(GetByIdYıldızUrunRequest request, CancellationToken cancellationToken)
        {
            var dbYıldızUrun = await context.YıldızUruns.AsNoTracking().ProjectTo<YıldızUrunDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);
            if (dbYıldızUrun == null)
                return new ServiceResponse<YıldızUrunDTO>();
            return new ServiceResponse<YıldızUrunDTO>
            {
                Value = dbYıldızUrun
            };
        }
    }
}
