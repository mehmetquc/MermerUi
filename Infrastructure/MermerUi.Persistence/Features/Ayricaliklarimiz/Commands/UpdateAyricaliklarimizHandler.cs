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

namespace MermerUi.Persistence.Features.Ayricaliklarimiz.Commands
{
    public class UpdateAyricaliklarimizHandler : IRequestHandler<UpdateAyricaliklarimizRequest, ServiceResponse<AyricaliklarimizDTO>>
    {
        private readonly IMapper mapper;
        private readonly MermerDbContext context;
        private readonly IConfiguration configuration;
        public UpdateAyricaliklarimizHandler(IMapper Mapper, MermerDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;

        }
        public async Task<ServiceResponse<AyricaliklarimizDTO>> Handle(UpdateAyricaliklarimizRequest request, CancellationToken cancellationToken)
        {
            var dbAyricaliklarimiz = await context.Ayricaliklarimizs.FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

            if (dbAyricaliklarimiz == null)
                throw new Exception("Ayricaliklarimiz bulunamadı");


            mapper.Map(request, dbAyricaliklarimiz);

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
