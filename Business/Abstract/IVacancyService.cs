using System;
using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IVacancyService
    {
        IDataResult<Vacancy> Get(int id);

        IDataResult<List<Vacancy>> GetList();

        IDataResult<List<Vacancy>> GetListByCategory(int categoryId);

        IDataResult<List<Vacancy>> GetListByCompany(int companyId);

        IResult Add(Vacancy vacancy);

        IResult Delele(int id);

        IResult Update(Vacancy vacancy,int id);
    }
}

