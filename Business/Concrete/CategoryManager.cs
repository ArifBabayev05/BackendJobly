using System;
using System.Collections.Generic;
using Business.Abstract;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IDataResult<List<Category>> GetList()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetList().ToList());
        }
    }
}

