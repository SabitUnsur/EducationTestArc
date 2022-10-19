using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Dtos;
using System.Globalization;
using System.Threading.Tasks;

namespace Business.Adapters.PersonService
{
    public class PersonServiceManager : IPersonService
    {
        IUserRepository _userRepository;
        public PersonServiceManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> VerifyCid(UserForAuth userForAuth)
        {
            return await VerifyEmail(userForAuth);
        }
        public async Task<bool> VerifyEmail(UserForAuth userForAuth)
        {
            var isExist = _userRepository.GetMail(userForAuth.Email);
            if (isExist == null)
            {
                return false;
            }
            return true;
        }
    }
}