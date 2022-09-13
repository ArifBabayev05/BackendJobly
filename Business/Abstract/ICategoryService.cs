using System;
using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using Entities.Models;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<Category> Get(int id);

        IDataResult<List<Category>> GetList();

        IResult Add(Category category);
        IResult Delete(int id);

        IResult Update(Category category,int id);

    }
}

