﻿using System;
using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Models;

namespace Business.Concrete
{
    public class CompanyManager : ICompanyService
    {
        private ICompanyDal _companyDal;

        public CompanyManager(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
        }

        public IDataResult<Company> Get(int id)
        {
            return new SuccessDataResult<Company>(_companyDal.Get(p => p.Id== id, includes: "Image"));
        }

        public IDataResult<List<Company>> GetList()
        {
            return new SuccessDataResult<List<Company>>(_companyDal.GetList(default, includes: "Image").ToList());
        }

        public IResult Add(Company company)
        {
            _companyDal.Add(company);
            return new SuccessResult(Messages.Add);
        }

        public IResult Delele(Company company)
        {
            _companyDal.Delete(company);
            return new SuccessResult(Messages.Delete);

        }

        public IResult Update(Company company)
        {
            _companyDal.Update(company);
            return new SuccessResult(Messages.Update);

        }


    }
}

