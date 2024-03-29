﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.DAL.Interfaces
{
    public interface IReadRepository<Tkey, TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity?> GetById(Tkey id);
    }
}
