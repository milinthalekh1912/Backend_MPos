using System;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;

namespace TCCPOS.Backend.SecurityService.Application.Feature.CreateUser.Command.CreateUser
{
    public class RegisterCommand : IRequest<RegisterResult>
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
