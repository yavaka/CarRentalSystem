using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalSystem.Application.Features.Identity.Commands
{
    public class LoginOutputModel
    {
        public LoginOutputModel(string token)
        {
            this.Token = token;
        }


        public string Token { get; }
    }
}
