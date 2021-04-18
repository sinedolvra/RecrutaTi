using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using RecrutaTi.Domain.Entities;

namespace RecrutaTi.Repository
{
    public class JobRepository : IRepository<Job>
    {
        public AppDbContext _Context { get; set; }

        public JobRepository(AppDbContext context)
        {
            _Context = context;
        }
        
        public Job GetById(string id)
        {
            return _Context.Jobs.FirstOrDefault(x => x.Id == id);
        }

        public IList<Job> GetAll()
        {
            return _Context.Jobs.ToList();
        }

        public IQueryable<Job> Query(Expression<Func<Job, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Save(Job job)
        {
            _Context.Add(job);
            _Context.SaveChanges();
        }

        public void Remove(Job job)
        {
            throw new NotImplementedException();
        }
    }
}