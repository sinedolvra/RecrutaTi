using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using RecrutaTi.Domain.Entities;

namespace RecrutaTi.Repository
{
    public class CompanyRepository : IRepository<Company>
    {
        public AppDbContext _Context { get; set; }

        public CompanyRepository(AppDbContext context)
        {
            _Context = context;
        }
        
        public Company GetById(string id)
        {
            return _Context.Companies.FirstOrDefault(x => x.Id == id);
        }

        public IList<Company> GetAll()
        {
            return _Context.Companies.ToList();
        }

        public IQueryable<Company> Query(Expression<Func<Company, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Save(Company company)
        {
            _Context.Companies.Add(company);
            _Context.SaveChanges();
        }

        public void Remove(Company entity)
        {
            throw new NotImplementedException();
        }
    }
}