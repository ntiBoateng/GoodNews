using News.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using News.DataAccess.Repository.IRepository;
using News.Models.ViewModels;

namespace GoodNewsApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
           
            List<Topic> topics = _unitOfWork.Topic.GetAll().ToList();
            List<Post> posts = _unitOfWork.Post.GetAll(includeProperties: "Topic").ToList();

            var vModel = new PostTopicViewModel
            {
                Topics = topics,
                Posts = posts
            };

            return View(vModel);
        }

        public IActionResult Details(int id)
        {
            Post postFromDb = _unitOfWork.Post.Get(u => u.Id == id, includeProperties: "Topic");
            List<Post> relatedPosts = _unitOfWork.Post.GetAll(u =>u.Topic.Name == postFromDb.Topic.Name, includeProperties: "Topic").ToList();

            var detailPosts = new DetailsViewModel
            {
                Post = postFromDb,
                Posts = relatedPosts
            };
            return View(detailPosts);
        }

        public IActionResult Topic(int id)
        {
            Topic topic = _unitOfWork.Topic.Get(u => u.Id == id);
            List<Post> postByTopic = _unitOfWork.Post.GetAll(u => u.Topic.Name == topic.Name, includeProperties: "Topic").ToList();
            var detailTopics = new DetailsViewModel
            {
                Posts = postByTopic,
                Topic = topic
            };
            return View(detailTopics);
        }

        //controller for privacy page
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}