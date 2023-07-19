﻿using News.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DataAccess.Repository.IRepository
{
	public interface IPostRepository : IRepository<Post>
	{
		void Update(Post post);
	}
}
