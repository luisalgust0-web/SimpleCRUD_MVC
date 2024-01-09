using AutoMapper;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using SimpleCRUD_MVC.Business.Services.Interfaces;
using SimpleCRUD_MVC.Data;
using System.Linq.Expressions;

namespace SimpleCRUD_MVC.Business.Services.Base
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly SimpleCRUD_MVCContext _context;
        private readonly IMapper _mapper;

        public BaseService(IMapper mapper, SimpleCRUD_MVCContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public virtual T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public virtual T Add<Input>(Input input)
        {
            T entity = _mapper.Map<T>(input);
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            T entity = _context.Set<T>().Find(id);
            _context.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public List<Output> GetAll<Output>(Expression<Func<T, object>> func)
        {
            List<T> listEntitys = _context.Set<T>().Include(func).ToList();
            return _mapper.Map<List<Output>>(listEntitys);
        }

        public List<Output> GetAll<Output>()
        {
            List<T> listEntitys = _context.Set<T>().ToList();
            return _mapper.Map<List<Output>>(listEntitys);
        }

        public Output GetById<Output>(int id)
        {
            T entity = _context.Set<T>().Find(id);
            return _mapper.Map<Output>(entity);
        }

        public bool Update<Input>(Input input)
        {
            T entity = _mapper.Map<T>(input);
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
            return true;
        }
    }
}
