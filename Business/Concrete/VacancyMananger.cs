using System;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using DataAccess.Abstract;
using System.Linq;

namespace Business.Concrete
{
    public class VacancyManager : IVacancyService
    {
        private IVacancyDal _vacancyDal;

        public VacancyManager(IVacancyDal vacancyDal)
        {
            _vacancyDal = vacancyDal;
        }

        public IDataResult<Vacancy> Get(int id)
        {
            return new SuccessDataResult<Vacancy>(_vacancyDal.Get(p => p.Id == id, includes: new string[] { "Company.Image", "Category", "City" }));
        }

        public IDataResult<List<Vacancy>> GetList()
        {
            return new SuccessDataResult<List<Vacancy>>(_vacancyDal.GetList(default, includes: new string[] { "Company.Image", "Category", "City" }).ToList());
        }

        public IDataResult<List<Vacancy>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Vacancy>>(_vacancyDal.GetList(p => p.CategoryId == categoryId, includes: new string[] { "Company.Image", "Category", "City" }).ToList());
        }

        public IDataResult<List<Vacancy>> GetListByCompany(int companyId)
        {
            return new SuccessDataResult<List<Vacancy>>(_vacancyDal.GetList(p => p.CompanyId == companyId, includes: new string[] { "Company.Image", "Category", "City" }).ToList());
        }

        public IResult Add(Vacancy vacancy)
        {
            _vacancyDal.Add(vacancy);
            return new SuccessResult(Messages.Add);
        }

        public IResult Delele(int id)
        {
            var data = _vacancyDal.Get(p=>p.Id == id, includes: new string[] { "Company.Image", "Category", "City" });
            _vacancyDal.Delete(data);
            return new SuccessResult(Messages.Delete);

        }

        public IResult Update(Vacancy vacancy,int id)
        {
            var data = _vacancyDal.Get(p => p.Id == id, includes: new string[] { "Company.Image", "Category", "City" });
            data.Name = vacancy.Name;
            data.CategoryId = vacancy.CategoryId;
            data.CityId = vacancy.CityId;
            data.CompanyId = vacancy.CompanyId;
            data.CreatedDate = vacancy.CreatedDate;
            data.Deadline = vacancy.Deadline;
            data.Salary = vacancy.Salary;
            data.TypeOfwork = vacancy.TypeOfwork;
            data.Tələblər = vacancy.Tələblər;
            data.VəzifəÖhdəlikləri = vacancy.VəzifəÖhdəlikləri;

            _vacancyDal.Update(vacancy);
            return new SuccessResult(Messages.Update);

        }

    }
}

