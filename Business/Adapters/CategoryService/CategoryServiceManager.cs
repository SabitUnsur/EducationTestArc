using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Adapters.CategoryService
{
    public class CategoryServiceManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryServiceManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Delete(Category category)
        {
            //_categoryDal.Delete(category);
            //return new Result(true,"Kategori silindi.");
            throw new NotImplementedException();
        }
        public IDataResult<List<Category>> GetAll()
        {
            //return _categoryDal.GetAll();
            throw new NotImplementedException();
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            //return _categoryDal.Get(c => c.Id == categoryId);
            throw new NotImplementedException();
        }

        public IResult Add(Category category)
        {
            //_categoryDal.Add(category);
            //return new Result(true,"Kategori eklendi.");
            throw new NotImplementedException();
        }

        public IResult Update(Category category)
        {
            //_categoryDal.Update(category);
            //return new Result(true,"Kategori güncellendi.");
            throw new NotImplementedException();
        }



        // BUSINESS RULES ICIN AYRILMISTIR // 


    }
}

