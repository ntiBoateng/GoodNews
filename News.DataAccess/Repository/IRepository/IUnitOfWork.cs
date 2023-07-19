using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// use this interface to activate all other interfaces of models you
namespace News.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ITopicRepository Topic { get; }
        IPostRepository Post { get; }

        void Save();
    }
}
