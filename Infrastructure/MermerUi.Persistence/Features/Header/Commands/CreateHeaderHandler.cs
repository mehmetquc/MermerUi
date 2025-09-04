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

namespace MermerUi.Persistence.Features.Header.Commands
{
    public class CreateHeaderHandler : IRequestHandler<CreateHeaderRequest, ServiceResponse<HeaderDTO>>
    {
        private readonly IMapper mapper;
        private readonly MermerDbContext context;
        private readonly IConfiguration configuration;
        public CreateHeaderHandler(IMapper Mapper, MermerDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;

        }
        public async Task<ServiceResponse<HeaderDTO>> Handle(CreateHeaderRequest request, CancellationToken cancellationToken)
        {
            var dbHeader = await context.Headers.FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

            if (dbHeader != null)
                throw new Exception("Header Zaten Mevcut");


            dbHeader = mapper.Map<Domain.Models.Header>(request);
            dbHeader.CreateDate = DateTime.Now;
            await context.Headers.AddAsync(dbHeader);
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
