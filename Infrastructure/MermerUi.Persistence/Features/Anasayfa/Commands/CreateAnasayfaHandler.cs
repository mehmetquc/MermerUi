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

namespace MermerUi.Persistence.Features.Anasayfa.Commands
{
    public class CreateAnasayfaHandler : IRequestHandler<CreateAnasayfaRequest, ServiceResponse<AnasayfaDTO>>
    {
        private readonly IMapper mapper;
        private readonly MermerDbContext context;
        private readonly IConfiguration configuration;
        public CreateAnasayfaHandler(IMapper Mapper, MermerDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;

        }
        public async Task<ServiceResponse<AnasayfaDTO>> Handle(CreateAnasayfaRequest request, CancellationToken cancellationToken)
        {
            var dbAnaSafya = await context.Anasayfas.FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

            if (dbAnaSafya != null)
                throw new Exception("Anasayfa Zaten Mevcut");


            dbAnaSafya = mapper.Map<Domain.Models.Anasayfa>(request);
            dbAnaSafya.CreateDate = DateTime.Now;
            await context.Anasayfas.AddAsync(dbAnaSafya);
            int result = await context.SaveChangesAsync();
            if (result < 0)
                throw new Exception("Context Savechanges Not Failed");
            var response = mapper.Map<AnasayfaDTO>(dbAnaSafya);
            return new ServiceResponse<AnasayfaDTO>
            {
                Value = response
            };
        }
    }
}
