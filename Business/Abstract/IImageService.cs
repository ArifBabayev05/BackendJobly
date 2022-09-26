using System;
using Core.Utilities.Results;
using Entities.Models;
using System.Collections.Generic;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IImageService
    {
        IDataResult<Image> Get(int id);

        IDataResult<List<Image>> GetList();

        IResult Add(Image company);

        IResult Delele(int id);

        IResult Update(Image company, int id);
    }
}

