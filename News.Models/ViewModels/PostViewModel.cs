using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Models.ViewModels
{
	public class PostViewModel
	{
		public Post Post { get; set; }
		[ValidateNever]
		 public IEnumerable<SelectListItem> TopicList { get; set; }
	}
}
