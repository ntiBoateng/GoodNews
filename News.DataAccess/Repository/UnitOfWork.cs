using News.DataAccess.Data;
using News.DataAccess.Repository.IRepository;
using News.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public ITopicRepository Topic { get; private set; }
        public IPostRepository Post { get; private set; }

        public UnitOfWork(ApplicationDbContext db) { 
            _db = db;
            Topic = new TopicRepository(_db);
            Post = new PostRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
