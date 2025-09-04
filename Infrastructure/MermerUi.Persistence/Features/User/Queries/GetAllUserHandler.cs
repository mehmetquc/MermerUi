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

namespace MermerUi.Persistence.Features.User.Queries
{
    public class GetAllUserHandler : IRequestHandler<GetAllUserRequest, ServiceResponse<List<UserDTO>>>
    {
        private readonly IMapper mapper;
        private readonly MermerDbContext context;
        private readonly IConfiguration configuration;
        public GetAllUserHandler(IMapper Mapper, MermerDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;

        }
        public async Task<ServiceResponse<List<UserDTO>>> Handle(GetAllUserRequest request, CancellationToken cancellationToken)
        {
            var dbUser = await context.Users.AsNoTracking().ProjectTo<UserDTO>(mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            if (dbUser == null)
                return new ServiceResponse<List<UserDTO>>();
            return new ServiceResponse<List<UserDTO>>
            {
                Value = dbUser
            };
        }
    }
}
