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

namespace MermerUi.Persistence.Features.Header.Commands
{
    public class UpdateHeaderHandler : IRequestHandler<UpdateHeaderRequest, ServiceResponse<HeaderDTO>>
    {
        private readonly IMapper mapper;
        private readonly MermerDbContext context;
        private readonly IConfiguration configuration;
        public UpdateHeaderHandler(IMapper Mapper, MermerDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;

        }
        public async Task<ServiceResponse<HeaderDTO>> Handle(UpdateHeaderRequest request, CancellationToken cancellationToken)
        {
            var dbHeader = await context.Headers.FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

            if (dbHeader == null)
                throw new Exception("Header bulunamadı");


            mapper.Map(request, dbHeader);

            int result = await context.SaveChangesAsync();

            if (result < 0)
                throw new Exception("Context Savechanges Not Failed");
            var response = mapper.Map<HeaderDTO>(dbHeader);
            return new ServiceResponse<HeaderDTO>
            {
                Value = response
            };
        }
    }
}
