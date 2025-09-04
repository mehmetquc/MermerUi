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

namespace MermerUi.Persistence.Features.Hakkimizda.Commands
{
    public class CreateHakkimizdaHandler : IRequestHandler<CreateHakkimizdaRequest, ServiceResponse<HakkimizdaDTO>>
    {
        private readonly IMapper mapper;
        private readonly MermerDbContext context;
        private readonly IConfiguration configuration;
        public CreateHakkimizdaHandler(IMapper Mapper, MermerDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;

        }
        public async Task<ServiceResponse<HakkimizdaDTO>> Handle(CreateHakkimizdaRequest request, CancellationToken cancellationToken)
        {
            var dbHakkimizda = await context.Hakkimizdas.FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

            if (dbHakkimizda != null)
                throw new Exception("Hakkimizda Zaten Mevcut");


            dbHakkimizda = mapper.Map<Domain.Models.Hakkimizda>(request);
            dbHakkimizda.CreateDate = DateTime.Now;
            await context.Hakkimizdas.AddAsync(dbHakkimizda);
            int result = await context.SaveChangesAsync();
            if (result < 0)
                throw new Exception("Context Savechanges Not Failed");
            var response = mapper.Map<HakkimizdaDTO>(dbHakkimizda);
            return new ServiceResponse<HakkimizdaDTO>
            {
                Value = response
            };
        }
    }
}
