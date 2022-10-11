using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Adapters.CourseService
{
    public class CourseServiceManager : ICourseService
    {
        ICourseDal _courseDal;

        public CourseServiceManager(ICourseDal courseDal)
        {
            _courseDal = courseDal;
        }

        public IResult Add(Course course)
        {
            //_courseDal.Add(course);
            throw new NotImplementedException();
        }

        public IResult Delete(Course course)
        {
            //_courseDal.Delete(course);
            throw new NotImplementedException();
        }

        public IDataResult<List<Course>> GetAll()
        {
            //return new DataResult<List<Course>>(true,_courseDal.GetAll(),"Kurslar listelendi.");
            throw new NotImplementedException();
        }

        public IDataResult<Course> GetById(int courseId)
        {
            //return _courseDal.Get(c => c.Id == courseId);
            throw new NotImplementedException();
        }

        public IResult Update(Course course)
        {
            //_courseDal.Update(course);
            throw new NotImplementedException();
        }
    }
}
