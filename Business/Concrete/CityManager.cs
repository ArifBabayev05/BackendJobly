using System;
using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CityManager : ICityService
    {
        private readonly ICityDal _cityDal;

        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }

        public IDataResult<City> Get(int id)
        {
            return new SuccessDataResult<City>(_cityDal.Get(p => p.Id == id));
        }

        public IDataResult<List<City>> GetList()
        {
            return new SuccessDataResult<List<City>>(_cityDal.GetList().ToList());
        }

        public IResult Add(City city)
        {
            _cityDal.Add(city);
            return new SuccessResult(Messages.Add);
        }

        public IResult Delete(int id)
        {
            var data = _cityDal.Get(p => p.Id == id);
            _cityDal.Delete(data);
            return new SuccessResult(Messages.Delete);
        }

       
        public IResult Update(City city, int id)
        {
            var data = _cityDal.Get(p => p.Id == id);
            data.Name = city.Name;
            _cityDal.Update(city);
            return new SuccessResult(Messages.Update);
        }
    }
}

