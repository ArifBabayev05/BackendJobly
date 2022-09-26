using System;
using Core.Utilities.Results;
using Entities.Models;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IImageService
    {
        IDataResult<Company> Get(int id);

        IDataResult<List<Company>> GetList();

        IResult Add(Company company);

        IResult Delele(int id);

        IResult Update(Company company, int id);
    }
}

