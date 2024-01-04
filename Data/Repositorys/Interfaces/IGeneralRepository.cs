namespace SimpleCRUD_MVC.Data.Repositorys.Interfaces
{
    public interface IGeneralRepository<T> 
    {
        public bool Add(T entity);
        public bool Update(int id);
        public bool Delete(int id);
        public List<T> GetAll();
        public T GetById(int id);

    }
}
