using News.DataAccess.Data;
using News.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DataAccess.Repository
{
	public class TopicRepository : Repository<Topic>, IRepository.ITopicRepository
	{
		private readonly ApplicationDbContext _db;
		public TopicRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}


	}
}
