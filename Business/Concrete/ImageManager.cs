using System;
using System.Collections.Generic;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Models;

namespace Business.Concrete
{
    public class ImageManager : IImageService
    {
        private readonly IImageDal _imageDal;

        public ImageManager(IImageDal imageDal)
        {
            _imageDal = imageDal;
        }

        public IResult Add(Company company)
        {
            throw new NotImplementedException();
        }

        public IResult Delele(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Company> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Company>> GetList()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Company company, int id)
        {
            throw new NotImplementedException();
        }
    }
}

