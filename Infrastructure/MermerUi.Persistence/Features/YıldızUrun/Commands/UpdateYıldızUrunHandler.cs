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

namespace MermerUi.Persistence.Features.YıldızUrun.Commands
{
    public class UpdateYıldızUrunHandler : IRequestHandler<UpdateYıldızUrunRequest, ServiceResponse<YıldızUrunDTO>>
    {
        private readonly IMapper mapper;
        private readonly MermerDbContext context;
        private readonly IConfiguration configuration;
        public UpdateYıldızUrunHandler(IMapper Mapper, MermerDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;

        }
        public async Task<ServiceResponse<YıldızUrunDTO>> Handle(UpdateYıldızUrunRequest request, CancellationToken cancellationToken)
        {
            var dbYıldızUrun = await context.YıldızUruns.FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

            if (dbYıldızUrun == null)
                throw new Exception("Yıldız Urun bulunamadı");


            mapper.Map(request, dbYıldızUrun);

            int result = await context.SaveChangesAsync();

            if (result < 0)
                throw new Exception("Context Savechanges Not Failed");
            var response = mapper.Map<YıldızUrunDTO>(dbYıldızUrun);
            return new ServiceResponse<YıldızUrunDTO>
            {
                Value = response
            };
        }
    }
}
