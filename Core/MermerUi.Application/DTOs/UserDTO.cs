using MermerUi.Application.DTOs.BaseModelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermerUi.Application.DTOs
{
    public class UserDTO:BaseModelDTO
    {
        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String EMailAddress { get; set; }

        public String Password { get; set; }

        public bool IsActive { get; set; }

        public String FullName => $"{FirstName} {LastName}";
    }
}
