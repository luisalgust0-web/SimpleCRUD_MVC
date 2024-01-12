using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Build.Framework;
using NuGet.Configuration;
using SimpleCRUD_MVC.Business.Models;
using System.Linq.Expressions;

namespace SimpleCRUD_MVC.Business.Services.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        public T Add(T entity);
        public T Add<Input>(Input input);
        public bool Update<Input>(Input input);
        public bool Delete(int id);
        public List<Output> GetAll<Output>(Expression<Func<T, object>> func);
        public List<Output> GetAll<Output>();
        public Output GetById<Output>(int id);
        public Output GetById<Output>(Expression<Func<T, bool>> Wherefunc, Expression<Func<T, object>> Includefunc);
    }
}
