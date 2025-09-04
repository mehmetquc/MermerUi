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

namespace MermerUi.Persistence.Features.Urunlerimiz.Queries
{
    public class GetAllUrunlerimizHandler : IRequestHandler<GetAllUrunlerimizRequest, ServiceResponse<List<UrunlerimizDTO>>>
    {
        private readonly IMapper mapper;
        private readonly MermerDbContext context;
        private readonly IConfiguration configuration;
        public GetAllUrunlerimizHandler(IMapper Mapper, MermerDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;

        }
        public async Task<ServiceResponse<List<UrunlerimizDTO>>> Handle(GetAllUrunlerimizRequest request, CancellationToken cancellationToken)
        {
            var dbUrunlerimiz = await context.Urunlerimizs.AsNoTracking().ProjectTo<UrunlerimizDTO>(mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            if (dbUrunlerimiz == null)
                return new ServiceResponse<List<UrunlerimizDTO>>();
            return new ServiceResponse<List<UrunlerimizDTO>>
            {
                Value = dbUrunlerimiz
            };
        }
    }
}
