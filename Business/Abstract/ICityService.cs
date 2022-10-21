using System;
using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICityService
    {
        IDataResult<City> Get(int id);

        IDataResult<List<City>> GetList();

        IResult Add(City category);

        IResult Delete(int id);

        IResult Update(City category, int id);
    }
}

