using CarRentalSystem.Application.Features.Identity;
using CarRentalSystem.Application.Features.Identity.Commands;
using System.Threading.Tasks;

namespace CarRentalSystem.Application.Contracts
{
    public interface IIdentity
    {
        Task<Result> Register(UserInputModel userInput);
     
        Task<Result<LoginOutputModel>> Login(UserInputModel userInput);
    }
}
