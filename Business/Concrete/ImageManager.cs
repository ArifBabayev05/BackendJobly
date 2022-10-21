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
    public class ImageManager : IImageService
    {
        private readonly IImageDal _imageDal;

        public ImageManager(IImageDal imageDal)
        {
            _imageDal = imageDal;
        }

        public IDataResult<Image> Get(int id)
        {
            return new SuccessDataResult<Image>(_imageDal.Get(p => p.Id == id));
        }

        public IDataResult<List<Image>> GetList()
        {
            return new SuccessDataResult<List<Image>>(_imageDal.GetList().ToList());
        }

        public IResult Add(Image city)
        {

            _imageDal.Add(city);
            return new SuccessResult(Messages.Add);
        }

        public IResult Update(Image image, int id)
        {
            var data = _imageDal.Get(p => p.Id == id);
            data.Name = image.Name;
            _imageDal.Update(image);
            return new SuccessResult(Messages.Update);
        }

        public IResult Delele(int id)
        {
            var data = _imageDal.Get(p => p.Id == id);
            _imageDal.Delete(data);
            return new SuccessResult(Messages.Delete);
        }
    }
}

