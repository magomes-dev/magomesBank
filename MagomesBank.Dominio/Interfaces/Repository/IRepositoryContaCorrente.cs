﻿using MagomesBank.Domain.Interfaces;
using MagomesBank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagomesBank.Domain.Interfaces
{
    public interface IRepositoryContaCorrente : IRepositoryBase<ContaCorrente>
    {
        ContaCorrente GetByUsuario(int UsuarioId);
    }
}
