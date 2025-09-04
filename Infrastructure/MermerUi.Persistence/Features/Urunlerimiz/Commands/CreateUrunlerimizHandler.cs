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

namespace MermerUi.Persistence.Features.Urunlerimiz.Commands
{
    public class CreateUrunlerimizHandler : IRequestHandler<CreateUrunlerimizRequest, ServiceResponse<UrunlerimizDTO>>
    {
        private readonly IMapper mapper;
        private readonly MermerDbContext context;
        private readonly IConfiguration configuration;
        public CreateUrunlerimizHandler(IMapper Mapper, MermerDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;

        }
        public async Task<ServiceResponse<UrunlerimizDTO>> Handle(CreateUrunlerimizRequest request, CancellationToken cancellationToken)
        {
            var dbUrunlerimiz = await context.Urunlerimizs.FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

            if (dbUrunlerimiz != null)
                throw new Exception("Urunlerimiz Zaten Mevcut");


            dbUrunlerimiz = mapper.Map<Domain.Models.Urunlerimiz>(request);
            dbUrunlerimiz.CreateDate = DateTime.Now;
            await context.Urunlerimizs.AddAsync(dbUrunlerimiz);
            int result = await context.SaveChangesAsync();
            if (result < 0)
                throw new Exception("Context Savechanges Not Failed");
            var response = mapper.Map<UrunlerimizDTO>(dbUrunlerimiz);
            return new ServiceResponse<UrunlerimizDTO>
            {
                Value = response
            };
        }
    }
}
