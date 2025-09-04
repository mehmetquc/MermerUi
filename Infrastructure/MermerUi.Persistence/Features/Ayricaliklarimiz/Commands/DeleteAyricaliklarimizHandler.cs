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

namespace MermerUi.Persistence.Features.Ayricaliklarimiz.Commands
{
    public class DeleteAyricaliklarimizHandler : IRequestHandler<DeleteAyricaliklarimizRequest, ServiceResponse<AyricaliklarimizDTO>>
    {
        private readonly IMapper mapper;
        private readonly MermerDbContext context;
        private readonly IConfiguration configuration;
        public DeleteAyricaliklarimizHandler(IMapper Mapper, MermerDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;

        }
        public async Task<ServiceResponse<AyricaliklarimizDTO>> Handle(DeleteAyricaliklarimizRequest request, CancellationToken cancellationToken)
        {
            var dbAyricaliklarimiz = await context.Ayricaliklarimizs.FindAsync(request.Id, cancellationToken);

            if (dbAyricaliklarimiz == null)
                throw new Exception("Ayricaliklarimiz Bulunamadı");
            context.Ayricaliklarimizs.Remove(dbAyricaliklarimiz);
            int result = await context.SaveChangesAsync();
            if (result < 0)
                throw new Exception("Context Savechanges Not Failed");
            var response = mapper.Map<AyricaliklarimizDTO>(dbAyricaliklarimiz);
            return new ServiceResponse<AyricaliklarimizDTO>
            {
                Value = response
            };
        }
    }
}
