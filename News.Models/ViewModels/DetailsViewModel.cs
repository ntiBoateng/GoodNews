using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Models.ViewModels
{
    public class DetailsViewModel
    {
        public Post Post { get; set; }
        public List<Post> Posts { get; set; }
        public Topic? Topic { get; set; }
    }
}
