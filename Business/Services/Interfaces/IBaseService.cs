using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Build.Framework;
using NuGet.Configuration;

namespace SimpleCRUD_MVC.Business.Services.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        public T Add(T entity);
        public T Add<Input>(Input input);
        public bool Update<Input>(Input input);
        public bool Delete(int id);
        public List<Output> GetAll<Output>();
        public Output GetById<Output>(int id);
    }
}
