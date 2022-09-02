using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Entities.Data
{
    public class EntityRepository : IRepository
    {
        private JoblyContext _context;

        public EntityRepository(JoblyContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public List<Company> GetCompanies()
        {
            var company = _context.Companies.Include(c=>c.Image).ToList();
            return company;
        }

        public Company GetCompanyById(int id)
        {
            var city = _context.Companies.Include(c => c.Image).FirstOrDefault();
            return city;
        }

        public Vacancy GetVacancyById(int id)
        {
            var vacancy = _context.Vacancies.FirstOrDefault(n => n.Id == id);
            return vacancy;
        }

        public List<Vacancy> GetVacanciesByCity(int id)
        {
            var vacancy = _context.Vacancies.Where(p => p.CityId == id).ToList();
            return vacancy;
        }

        public List<Vacancy> GetVacancies()
        {
            throw new NotImplementedException();
        }

        public List<Vacancy> GetVacanciesByCategory(int id)
        {
            throw new NotImplementedException();
        }


        public List<Vacancy> GetVacanciesByCompany(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
    }
}

