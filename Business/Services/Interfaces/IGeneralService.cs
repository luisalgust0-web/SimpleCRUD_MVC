using Microsoft.AspNetCore.Components.Forms;

namespace SimpleCRUD_MVC.Business.Services.Interfaces
{
    public interface IGeneralService<T> where T : class
    {
        public bool Add<Input>(Input input);
        public bool Update<Input>(Input input);
        public bool Delete(int id);
        public List<Output> GetAll<Output>();
        public Output GetById<Output>(int id);
    }
}
