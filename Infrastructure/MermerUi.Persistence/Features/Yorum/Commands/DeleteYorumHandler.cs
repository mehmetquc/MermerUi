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

namespace MermerUi.Persistence.Features.Yorum.Commands
{
    public class DeleteYorumHandler : IRequestHandler<DeleteYorumRequest, ServiceResponse<YorumDTO>>
    {
        private readonly IMapper mapper;
        private readonly MermerDbContext context;
        private readonly IConfiguration configuration;
        public DeleteYorumHandler(IMapper Mapper, MermerDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;

        }
        public async Task<ServiceResponse<YorumDTO>> Handle(DeleteYorumRequest request, CancellationToken cancellationToken)
        {
            var dbYorum = await context.Yorums.FindAsync(request.Id, cancellationToken);

            if (dbYorum == null)
                throw new Exception("Yorum Bulunamadı");
            context.Yorums.Remove(dbYorum);
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
