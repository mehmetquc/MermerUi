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

namespace MermerUi.Persistence.Features.YıldızUrun.Commands
{
    public class DeleteYıldızUrunHandler : IRequestHandler<DeleteYıldızUrunRequest, ServiceResponse<YıldızUrunDTO>>
    {
        private readonly IMapper mapper;
        private readonly MermerDbContext context;
        private readonly IConfiguration configuration;
        public DeleteYıldızUrunHandler(IMapper Mapper, MermerDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;

        }
        public async Task<ServiceResponse<YıldızUrunDTO>> Handle(DeleteYıldızUrunRequest request, CancellationToken cancellationToken)
        {

            var dbYıldızUrun = await context.YıldızUruns.FindAsync(request.Id, cancellationToken);

            if (dbYıldızUrun == null)
                throw new Exception("Yıldız Urun Bulunamadı");
            context.YıldızUruns.Remove(dbYıldızUrun);
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
