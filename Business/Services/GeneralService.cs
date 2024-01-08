using AutoMapper;
using Microsoft.AspNetCore.Components.Forms;
using SimpleCRUD_MVC.Business.Services.Interfaces;
using SimpleCRUD_MVC.Data.Repositorys;
using SimpleCRUD_MVC.Data.Repositorys.Interfaces;

namespace SimpleCRUD_MVC.Business.Services
{
    public class GeneralService<T> : IGeneralService<T> where T : class
    {
        private readonly IGeneralRepository<T> _generalRepository;
        private readonly IMapper _mapper;

        public GeneralService(IGeneralRepository<T> generalRepository, IMapper mapper)
        {
            _generalRepository = generalRepository;
            _mapper = mapper;
        }

        public bool Add<Input>(Input input)
        {
            T entity = _mapper.Map<T>(input);
            return _generalRepository.Add(entity);
        }

        public bool Delete(int id)
        {
            return _generalRepository.Delete(id);
        }

        public List<Output> GetAll<Output>()
        {
            List<T> listEntitys = _generalRepository.GetAll();
            return _mapper.Map<List<Output>>(listEntitys);
        }

        public Output GetById<Output>(int id)
        {
            T entity = _generalRepository.GetById(id);
            return _mapper.Map<Output>(entity);
        }

        public bool Update<Input>(Input input)
        {
            T entity = _mapper.Map<T>(input);
            return _generalRepository.Update(entity);
        }
    }
}
