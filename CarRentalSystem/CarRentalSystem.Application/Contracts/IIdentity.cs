using CarRentalSystem.Application.Features.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Application.Contracts
{
    public interface IIdentity
    {
        Task<Result> Register(UserInputModel userInput);
     
        Task<Result<LoginOutputModel>> Login(UserInputModel userInput);
    }
}
