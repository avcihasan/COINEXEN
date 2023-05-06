using COINEXEN.Core.Entities;
using COINEXEN.Core.Repositories;
using COINEXEN.Core.Services;
using COINEXEN.Core.UnitOfWorks;
using COINEXEN.Repository.Contexts;
using Microsoft.EntityFrameworkCore;

namespace COINEXEN.Service.Services
{
    public class GenericService<T> : IGenericService<T> where T : BaseEntity
    {
        readonly IGenericRepository<T> _repository;
        protected readonly IUnitOfWork _unitOfWork;

        public GenericService(IGenericRepository<T> repo, IUnitOfWork unitOfWork)
        {
            _repository = repo;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateAsync(T entity)
        {
            bool result =await _repository.CreateAsync(entity);
            if (result)
                await _unitOfWork.CommitAsync();
            return result;
        }

        public async Task<bool> RemoveByIdAsync(int id)
        {
            bool result = await _repository.RemoveByIdAsync(id);
            if(result)
                await _unitOfWork.CommitAsync();
            return result;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            bool result =  _repository.Update(entity);
            if (result)
                await _unitOfWork.CommitAsync();
            return result;
        }
    }
}
