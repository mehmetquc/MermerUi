using AutoMapper;
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

namespace MermerUi.Persistence.Features.DetaylıUrun.Commands
{
    public class UpdateDetaylıUrunHandler : IRequestHandler<UpdateDetaylıUrunRequest, ServiceResponse<DetaylıUrunDTO>>
    {
        private readonly IMapper mapper;
        private readonly MermerDbContext context;
        private readonly IConfiguration configuration;
        public UpdateDetaylıUrunHandler(IMapper Mapper, MermerDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;

        }
        public async Task<ServiceResponse<DetaylıUrunDTO>> Handle(UpdateDetaylıUrunRequest request, CancellationToken cancellationToken)
        {
            var dbDetaylıUrun = await context.DetaylıUruns.FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

            if (dbDetaylıUrun == null)
                throw new Exception("Detaylı Urun bulunamadı");


            mapper.Map(request, dbDetaylıUrun);

            int result = await context.SaveChangesAsync();

            if (result < 0)
                throw new Exception("Context Savechanges Not Failed");
            var response = mapper.Map<DetaylıUrunDTO>(dbDetaylıUrun);
            return new ServiceResponse<DetaylıUrunDTO>
            {
                Value = response
            };
        }
    }
}
