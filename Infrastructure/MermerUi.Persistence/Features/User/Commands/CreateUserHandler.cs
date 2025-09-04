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
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, ServiceResponse<UserDTO>>
    {
        private readonly IMapper mapper;
        private readonly MermerDbContext context;
        private readonly IConfiguration configuration;
        public CreateUserHandler(IMapper Mapper, MermerDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;

        }
        public async Task<ServiceResponse<UserDTO>> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var dbUser = await context.Users.FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

            if (dbUser != null)
                throw new Exception("Kullanıcı Zaten Mevcut");


            dbUser = mapper.Map<Domain.Models.User>(request);
            dbUser.CreateDate = DateTime.Now;
            await context.Users.AddAsync(dbUser);
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
