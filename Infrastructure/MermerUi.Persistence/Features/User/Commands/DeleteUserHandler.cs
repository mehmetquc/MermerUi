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

namespace MermerUi.Persistence.Features.User.Commands
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, ServiceResponse<UserDTO>>
    {
        private readonly IMapper mapper;
        private readonly MermerDbContext context;
        private readonly IConfiguration configuration;
        public DeleteUserHandler(IMapper Mapper, MermerDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;

        }
        public async Task<ServiceResponse<UserDTO>> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            var dbUser = await context.Users.FindAsync(request.Id, cancellationToken);

            if (dbUser == null)
                throw new Exception("Kullanıcı Bulunamadı");
            context.Users.Remove(dbUser);
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
