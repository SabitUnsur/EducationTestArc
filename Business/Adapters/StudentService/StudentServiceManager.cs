﻿using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Adapters.StudentService
{
    public class StudentServiceManager : IStudentService
    {
        IStudentDal _studentDal;
        public StudentServiceManager(IStudentDal studentDal)
        {
            _studentDal = studentDal;
        }

        public IResult Add(Student student)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Student student)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Student>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Student>> GetAll(Student student)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Student> GetById(int studentId)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Student student)
        {
            throw new NotImplementedException();
        }
    }
}

