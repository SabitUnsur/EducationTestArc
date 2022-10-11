using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Adapters.StudentService
{
    public interface IStudentService
    {
        IResult Add(Student student);
        IResult Delete(Student student);
        IResult Update(Student student);
        IDataResult<Student> GetById(int studentId);
        IDataResult<List<Student>> GetAll();
        IDataResult<List<Student>> GetAll(Student student);
    }
}
