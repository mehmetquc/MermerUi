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

namespace MermerUi.Persistence.Features.Yorum.Commands
{
    public class CreateYorumHandler : IRequestHandler<CreateYorumRequest, ServiceResponse<YorumDTO>>
    {
        private readonly IMapper mapper;
        private readonly MermerDbContext context;
        private readonly IConfiguration configuration;
        public CreateYorumHandler(IMapper Mapper, MermerDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;

        }
        public async Task<ServiceResponse<YorumDTO>> Handle(CreateYorumRequest request, CancellationToken cancellationToken)
        {
            var dbYorum = await context.Yorums.FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

            if (dbYorum != null)
                throw new Exception("Yorum Zaten Mevcut");


            dbYorum = mapper.Map<Domain.Models.Yorum>(request);
            dbYorum.CreateDate = DateTime.Now;
            await context.Yorums.AddAsync(dbYorum);
            int result = await context.SaveChangesAsync();
            if (result < 0)
                throw new Exception("Context Savechanges Not Failed");
            var response = mapper.Map<YorumDTO>(dbYorum);
            return new ServiceResponse<YorumDTO>
            {
                Value = response
            };
        }
    }
}
