using SimpleCRUD_MVC.Data.Repositorys.Interfaces;

namespace SimpleCRUD_MVC.Data.Repositorys
{
    public class GeneralRepository<T> : IGeneralRepository<T> where T : class
    {
        private readonly SimpleCRUD_MVCContext _context;

        public GeneralRepository(SimpleCRUD_MVCContext context)
        {
            _context = context;
        }

        public bool Add(T entity)
        {
            _context.Set<T>().Add(entity);            
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            T entity = _context.Find<T>(id);
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public List<T> GetAll()
        {
            List<T> list = _context.Set<T>().ToList();
            return list;
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public bool Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
            return true;
        }
    }
}
