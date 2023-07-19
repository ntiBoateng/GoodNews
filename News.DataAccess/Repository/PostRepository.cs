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
	public class PostRepository : Repository<Post>, IPostRepository
	{
		private readonly ApplicationDbContext _db;

        public PostRepository(ApplicationDbContext db) : base(db)
        {
			_db = db; 
        }

        public void Update(Post post)
		{
			_db.Posts.Update(post);
		}

		public void Save()
		{

		}
	}
}
