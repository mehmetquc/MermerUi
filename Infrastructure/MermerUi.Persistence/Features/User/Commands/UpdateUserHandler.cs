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

namespace MermerUi.Persistence.Features.User.Commands
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, ServiceResponse<UserDTO>>
    {

        private readonly IMapper mapper;
        private readonly MermerDbContext context;
        private readonly IConfiguration configuration;
        public UpdateUserHandler(IMapper Mapper, MermerDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;

        }
        public async Task<ServiceResponse<UserDTO>> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var dbUser = await context.Users.FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

            if (dbUser == null)
                throw new Exception("Kullanıcı bulunamadı");


            mapper.Map(request, dbUser);

            int result = await context.SaveChangesAsync();

            if (result < 0)
                throw new Exception("Context Savechanges Not Failed");
            var response = mapper.Map<UserDTO>(dbUser);
            return new ServiceResponse<UserDTO>
            {
                Value = response
            };
        }
    }
}
