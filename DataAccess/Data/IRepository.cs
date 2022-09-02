using System;
using System.Collections.Generic;
using Entities.Concrete;
using Entities.Models;

namespace Core.Entities.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T:class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveAll();

        List<Vacancy> GetVacancies();
        List<Vacancy> GetVacanciesByCompany(int id);
        List<Vacancy> GetVacanciesByCategory(int id);
        List<Vacancy> GetVacanciesByCity(int id);


        List<Company> GetCompanies();
        Company GetCompanyById(int id);
        Vacancy GetVacancyById(int id);

    }
}

