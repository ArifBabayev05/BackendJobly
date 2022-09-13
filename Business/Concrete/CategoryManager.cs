using System;
using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.Models;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult(Messages.Add);
        }

        public IResult Delete(int id)
        {
            var data = _categoryDal.Get(p => p.Id == id);
            _categoryDal.Delete(data);
            return new SuccessResult(Messages.Delete);
        }

        public IDataResult<List<Category>> GetList()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetList().ToList());
        }

        public IResult Update(Category category,int id)
        {
            var data = _categoryDal.Get(p => p.Id == id);
            data.Name = category.Name;
            _categoryDal.Update(category);
            return new SuccessResult(Messages.Update);
        }
    }
}

