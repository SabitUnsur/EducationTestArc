using Business.Adapters.PersonService;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Authorizations.Queries
{
    public class VerifyCidQuery : IRequest<IDataResult<bool>>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public class VerifyCidQueryHandler : IRequestHandler<VerifyCidQuery, IDataResult<bool>>
        {
            private readonly IPersonService _personService;

            public VerifyCidQueryHandler(IPersonService personService)
            {
                _personService = personService;
            }

            public async Task<IDataResult<bool>> Handle(VerifyCidQuery request, CancellationToken cancellationToken)
            {
                var result = await _personService.VerifyEmail(new UserForAuth()
                {
                    Name = request.Name,
                    Surname = request.Surname,
                    Email = request.Email
                });
                if (!result)
                {
                    return new ErrorDataResult<bool>(result, Messages.CouldNotBeVerifyCid);
                }

                return new SuccessDataResult<bool>(result, Messages.VerifyCid);
            }
        }
    }
}
