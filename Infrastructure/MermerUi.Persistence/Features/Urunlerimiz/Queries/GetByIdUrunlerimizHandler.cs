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
    public class GetByIdUrunlerimizHandler : IRequestHandler<GetByIdUrunlerimizRequest, ServiceResponse<UrunlerimizDTO>>
    {
        private readonly IMapper mapper;
        private readonly MermerDbContext context;
        private readonly IConfiguration configuration;
        public GetByIdUrunlerimizHandler(IMapper Mapper, MermerDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;

        }
        public async Task<ServiceResponse<UrunlerimizDTO>> Handle(GetByIdUrunlerimizRequest request, CancellationToken cancellationToken)
        {
            var dbUrunlerimiz = await context.Urunlerimizs.AsNoTracking().ProjectTo<UrunlerimizDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);
            if (dbUrunlerimiz == null)
                return new ServiceResponse<UrunlerimizDTO>();
            return new ServiceResponse<UrunlerimizDTO>
            {
                Value = dbUrunlerimiz
            };
        }
    }
}
