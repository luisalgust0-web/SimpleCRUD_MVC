namespace SimpleCRUD_MVC.Data.Repositorys.Interfaces
{
    public interface IGeneralRepository<T> 
    {
        public bool Add(T entity);
        public bool Update(T entity);
        public bool Delete(int id);
        public List<T> GetAll();
        public T GetById(int id);

    }
}
