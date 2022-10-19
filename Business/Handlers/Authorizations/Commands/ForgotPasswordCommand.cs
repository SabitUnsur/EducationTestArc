using Business.BusinessAspects;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Toolkit;
using DataAccess.Abstract;
using MediatR;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Business.Handlers.Authorizations.Commands
{
    public class ForgotPasswordCommand : IRequest<IResult>
    {
       // public string TcKimlikNo { get; set; }
        public string Email { get; set; }

        public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, IResult>
        {
            private readonly IUserRepository _userRepository;

            public ForgotPasswordCommandHandler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            /// <summary>
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>

            // TC KİMLİKSİZ YENİLEME İCİN
            //var user = await _userRepository.GetAsync(u => u.UserId >0);
            //[SecuredOperation(Priority = 1)]
            [CacheRemoveAspect()]
            [LogAspect(typeof(FileLogger))]
            public async Task<IResult> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
            {
                var user = await _userRepository.GetAsync(u => u.Email == (request.Email));

                if (user == null)
                {
                    return new ErrorResult(Messages.InvalidCode);
                }

                var generatedPassword = RandomPassword.CreateRandomPassword(14);
                HashingHelper.CreatePasswordHash(generatedPassword, out var passwordSalt, out var passwordHash);
                user.PasswordSalt = passwordSalt;
                user.PasswordHash = passwordHash;
                _userRepository.Update(user);



             

                await _userRepository.SaveChangesAsync();

                return new SuccessResult(Messages.SendPassword +" " +  Messages.NewPassword + " " + generatedPassword);
            }
        }
    }
}