using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.DAL.Interfaces
{
    public interface ICrudRepository<TKey, TEntity> : IReadRepository<TKey, TEntity>
    {
        Task<TEntity?> Insert(TEntity entity);
        Task<TEntity?> Update(TEntity entity, TKey id);
        Task<TEntity?> Delete(TKey id);
    }
}
