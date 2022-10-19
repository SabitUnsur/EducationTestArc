using Core.Utilities.Results;
using Entities.Dtos;
using System.Threading.Tasks;

namespace Business.Adapters.PersonService
{
    public interface IPersonService
    {
        Task<bool> VerifyEmail(UserForAuth userForAuth);
    }
}