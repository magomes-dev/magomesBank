﻿using MagomesBank.Domain.Models.Validacoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagomesBank.Domain.Interfaces
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        ResultadoValidacao Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        ResultadoValidacao Update(TEntity obj);
        ResultadoValidacao Remove(TEntity obj);
        void Dispose();
    }
}
