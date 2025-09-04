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

namespace MermerUi.Persistence.Features.Ayricaliklarimiz.Queries
{
    public class GetByIdAyricaliklarimizHandler : IRequestHandler<GetByIdAyricaliklarimizRequest, ServiceResponse<AyricaliklarimizDTO>>
    {
        private readonly IMapper mapper;
        private readonly MermerDbContext context;
        private readonly IConfiguration configuration;
        public GetByIdAyricaliklarimizHandler(IMapper Mapper, MermerDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;

        }
        public async Task<ServiceResponse<AyricaliklarimizDTO>> Handle(GetByIdAyricaliklarimizRequest request, CancellationToken cancellationToken)
        {
            var dbAnasayfa = await context.Ayricaliklarimizs.AsNoTracking().ProjectTo<AyricaliklarimizDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);
            if (dbAnasayfa == null)
                return new ServiceResponse<AyricaliklarimizDTO>();
            return new ServiceResponse<AyricaliklarimizDTO>
            {
                Value = dbAnasayfa
            };
        }
    }
}
