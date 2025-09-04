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
    public class UpdateUserRequest : IRequest<ServiceResponse<UserDTO>>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EMailAddress { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
