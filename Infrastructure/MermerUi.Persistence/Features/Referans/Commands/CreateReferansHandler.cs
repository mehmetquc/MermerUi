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

namespace MermerUi.Persistence.Features.Referans.Commands
{
    public class CreateReferansHandler : IRequestHandler<CreateReferansRequest, ServiceResponse<ReferansDTO>>
    {
        private readonly IMapper mapper;
        private readonly MermerDbContext context;
        private readonly IConfiguration configuration;
        public CreateReferansHandler(IMapper Mapper, MermerDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;

        }
        public async Task<ServiceResponse<ReferansDTO>> Handle(CreateReferansRequest request, CancellationToken cancellationToken)
        {
            var dbReferans = await context.Referans.FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

            if (dbReferans != null)
                throw new Exception("Referans Zaten Mevcut");


            dbReferans = mapper.Map<Domain.Models.Referans>(request);
            dbReferans.CreateDate = DateTime.Now;
            await context.Referans.AddAsync(dbReferans);
            int result = await context.SaveChangesAsync();
            if (result < 0)
                throw new Exception("Context Savechanges Not Failed");
            var response = mapper.Map<ReferansDTO>(dbReferans);
            return new ServiceResponse<ReferansDTO>
            {
                Value = response
            };
        }
    }
}
