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
    public class UpdateAnasayfaHandler : IRequestHandler<UpdateAnasayfaRequest, ServiceResponse<AnasayfaDTO>>
    {
        private readonly IMapper mapper;
        private readonly MermerDbContext context;
        private readonly IConfiguration configuration;
        public UpdateAnasayfaHandler(IMapper Mapper, MermerDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;

        }
        public async Task<ServiceResponse<AnasayfaDTO>> Handle(UpdateAnasayfaRequest request, CancellationToken cancellationToken)
        {
            var dbAnasayfa = await context.Anasayfas.FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

            if (dbAnasayfa == null)
                throw new Exception("Anasayfa bulunamadı");


            mapper.Map(request, dbAnasayfa);

            int result = await context.SaveChangesAsync();

            if (result < 0)
                throw new Exception("Context Savechanges Not Failed");
            var response = mapper.Map<AnasayfaDTO>(dbAnasayfa);
            return new ServiceResponse<AnasayfaDTO>
            {
                Value = response
            };
        }
    }
}
