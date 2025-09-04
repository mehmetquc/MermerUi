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

namespace MermerUi.Persistence.Features.Anasayfa.Commands
{
    public class DeleteAnasayfaHandler : IRequestHandler<DeleteAnasayfaRequest, ServiceResponse<AnasayfaDTO>>
    {
        private readonly IMapper mapper;
        private readonly MermerDbContext context;
        private readonly IConfiguration configuration;
        public DeleteAnasayfaHandler(IMapper Mapper, MermerDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;

        }
        public async Task<ServiceResponse<AnasayfaDTO>> Handle(DeleteAnasayfaRequest request, CancellationToken cancellationToken)
        {
            var dbAnaSayfa = await context.Anasayfas.FindAsync(request.Id, cancellationToken);

            if (dbAnaSayfa == null)
                throw new Exception("AnaSayfa Bulunamadı");
            context.Anasayfas.Remove(dbAnaSayfa);
            int result = await context.SaveChangesAsync();
            if (result < 0)
                throw new Exception("Context Savechanges Not Failed");
            var response = mapper.Map<AnasayfaDTO>(dbAnaSayfa);
            return new ServiceResponse<AnasayfaDTO>
            {
                Value = response
            };
        }
    }
}
