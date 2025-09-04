using AutoMapper;
using MediatR;
using MermerUi.Application.DTOs;
using MermerUi.Application.ResponseModels;
using MermerUi.Persistence.Contexts;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermerUi.Persistence.Features.DetaylıUrun.Commands
{
    public class DeleteDetaylıUrunHandler : IRequestHandler<DeleteDetaylıUrunRequest, ServiceResponse<DetaylıUrunDTO>>
    {
        private readonly IMapper mapper;
        private readonly MermerDbContext context;
        private readonly IConfiguration configuration;
        public DeleteDetaylıUrunHandler(IMapper Mapper, MermerDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;

        }
        public async Task<ServiceResponse<DetaylıUrunDTO>> Handle(DeleteDetaylıUrunRequest request, CancellationToken cancellationToken)
        {
            var dbDetaylıUrun = await context.DetaylıUruns.FindAsync(request.Id, cancellationToken);

            if (dbDetaylıUrun == null)
                throw new Exception("Detaylı Urun Bulunamadı");
            context.DetaylıUruns.Remove(dbDetaylıUrun);
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
