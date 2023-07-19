using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Models
{
	public class Post
	{
		[Key]
        public int Id { get; set; }

		[Required]
		public string Title { get; set; }
		[Required]
		public string ShortDescription { get; set; }
		[Required]
		public string Description { get; set; }

		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyy-MM-dd}", ApplyFormatInEditMode =true)]
		public DateTime Created { get; set; }

		public bool IsFeatured { get; set; } = false;
		[ValidateNever]
		public String ImageUrl { get; set; }

		public int TopicId { get; set; }
		[ForeignKey("TopicId")]
		[ValidateNever]
		public Topic Topic { get; set; }


        public Post()
        {
            Created = DateTime.Now;
        }

    }

	
}
