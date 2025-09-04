using MediatR;
using MermerUi.Application.DTOs;
using MermerUi.Application.ResponseModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermerUi.Persistence.Features.User.Commands
{
    public class CreateUserRequest : IRequest<ServiceResponse<UserDTO>>
    {
        public Guid Id { get; set; }
        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String EMailAddress { get; set; }

        public String Password { get; set; }

        public bool IsActive { get; set; }

        public String FullName => $"{FirstName} {LastName}";
    }
}
