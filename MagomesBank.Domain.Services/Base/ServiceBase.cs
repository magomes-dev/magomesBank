using MagomesBank.Domain.Interfaces;
using MagomesBank.Domain.Models.Validacoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagomesBank.Domain.Services
{
    public abstract class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;
        private ResultadoValidacao ResultadoValidacao;

        public ServiceBase(IRepositoryBase<TEntity> Repository)
        {
            _repository = Repository;
        }
        public virtual ResultadoValidacao Add(TEntity obj)
        {
            _repository.Add(obj);
            return ResultadoValidacao;
        }
        public virtual TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }
        public virtual IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }
        public virtual ResultadoValidacao Update(TEntity obj)
        {
            _repository.Update(obj);

            return ResultadoValidacao;
        }
        public virtual ResultadoValidacao Remove(TEntity obj)
        {
            _repository.Remove(obj);

            return ResultadoValidacao;
        }

        public virtual void Dispose()
        {
            _repository.Dispose();
        }
    }
}
