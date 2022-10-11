using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Adapters.InstructorService
{
    public interface IInstructorService
    {
        IResult Add(Instructor instructor);
    }
}
