
using Core.Entities;
using Data.Repositores.Base;

namespace Data.Repositories.Abstract
{
    public interface IProductRepository : IBaseRepistory<Product>
    { 
        Task<Product>GetByNameAsync(string name);
    }
}
