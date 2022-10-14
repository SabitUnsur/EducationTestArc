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
        public string TcKimlikNo { get; set; }
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
            /// 
            // HATA ALINDIGI ICIN CIKARILDI [SecuredOperation(Priority = 1)]
            // TC KİMLİKSİZ YENİLEME İCİN
            //var user = await _userRepository.GetAsync(u => u.UserId >0);
            [CacheRemoveAspect()]
            [LogAspect(typeof(FileLogger))]
            public async Task<IResult> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
            {
                var user = await _userRepository.GetAsync(u => u.CitizenId == Convert.ToInt64(request.TcKimlikNo));

                if (user == null)
                {
                    return new ErrorResult(Messages.WrongCitizenId);
                }

                else
                {
                    //string resetToken = await _userRepository.GeneratePasswordResetTokenAsync(user);

                    MailMessage mail = new MailMessage();
                    mail.IsBodyHtml = true;
                    mail.To.Add(user.Email);
                    mail.From = new MailAddress("sabitemir23@gmail.com", "Şifre Güncelleme", System.Text.Encoding.UTF8);
                    mail.Subject = "Şifre Güncelleme Talebi";
                    mail.IsBodyHtml = true;
                    SmtpClient smp = new SmtpClient();
                    smp.Credentials = new NetworkCredential("sabitemir23@gmail.com", "sabit123");
                    smp.Port = 587;
                    smp.Host = "smtp.gmail.com";
                    smp.EnableSsl = true;
                    var generatedPassword = RandomPassword.CreateRandomPassword(14);
                    HashingHelper.CreatePasswordHash(generatedPassword, out var passwordSalt, out var passwordHash);

                    _userRepository.Update(user);

                    return new SuccessResult(Messages.SendPassword + " " + Messages.NewPassword + " " + generatedPassword);
                    smp.Send(mail);

                   
                }

               
            }
        }
    }
}