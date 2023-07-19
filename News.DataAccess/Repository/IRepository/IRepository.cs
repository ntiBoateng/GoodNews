using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace News.DataAccess.Repository.IRepository
{
	public interface IRepository<T> where T : class
	{
		IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);

		T Get(Expression<Func<T, bool>> filter, string? includeProperties=null);

		void AddItem(T item);

		void DeleteItem(T item);

		void DeleteManyItem(IEnumerable<T> items);
	}
}
