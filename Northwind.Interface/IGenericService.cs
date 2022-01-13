using Northwind.Entity.Base;
using Northwind.Entity.IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Interface
{
    public interface IGenericService<T, TDto> where T : EntityBase where TDto : DtoBase
    {
        IResponse<List<TDto>> GetAll();
        IResponse<List<TDto>> GetAll(Expression<Func<T, bool>> expression);
        IResponse<TDto> Find(int id);
        IQueryable<T> GetIQueryable();
        IResponse<TDto> Add(TDto item, bool saveChanges);
        Task<TDto> AddAsync(TDto item);
        TDto Update(TDto item);
        Task<TDto> UpdateAsync();
        IResponse<bool> DeleteById(int id, bool saveChanges);
        Task<bool> DeleteByIdAsync(int id);
        bool Delete(TDto item);
        Task<bool> DeleteAsync(TDto item);
        void Save();
    }
}
