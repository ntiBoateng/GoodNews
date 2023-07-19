using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using News.DataAccess.Repository;
using News.DataAccess.Repository.IRepository;
using News.Models;
using News.Models.ViewModels;

namespace GoodNewsApp.Controllers
{
	public class PostController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IWebHostEnvironment _webHostEnvironment;

        public PostController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
			_webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
		{
			List<Post> posts = _unitOfWork.Post.GetAll(includeProperties: "Topic").ToList();
			return View(posts);
		}

		public IActionResult Create(int? id)
		{
			PostViewModel postVm = new()
			{
				TopicList = _unitOfWork.Topic.GetAll().Select(u => new SelectListItem
				{
					Text = u.Name,
					Value = u.Id.ToString(),
				}),
				Post = new Post()
			};

			if(id == null || id ==0)
			{
				return View(postVm);
			}
			else
			{
				postVm.Post = _unitOfWork.Post.Get(u => u.Id == id);
				return View(postVm);
			}
		}


		[HttpPost]
		public IActionResult Create(PostViewModel productVm, IFormFile? file)
		{
			if (ModelState.IsValid)
			{
				string webRootPath = _webHostEnvironment.WebRootPath;
				if (file != null)
				{
					string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
					string productPath = Path.Combine(webRootPath, @"images\posts");

					// this is when updating a product, if the user chooses a new image, we will delete the old image and replace it with the nnew image!
					if (!string.IsNullOrEmpty(productVm.Post.ImageUrl))
					{
						// delete the old img
						var oldImagePath = Path.Combine(webRootPath, productVm.Post.ImageUrl.TrimStart('\\'));
						if (System.IO.File.Exists(oldImagePath))
						{
							System.IO.File.Delete(oldImagePath);
						}
					}

					using (var fileStream = new FileStream(Path.Combine(productPath, filename), FileMode.Create))
					{
						file.CopyTo(fileStream);
					}
					productVm.Post.ImageUrl = @"\images\posts\" + filename;
				}
				if (productVm.Post.Id == 0)
				{
					_unitOfWork.Post.AddItem(productVm.Post);
				}
				else
				{
					_unitOfWork.Post.Update(productVm.Post);
				}
				_unitOfWork.Save();
				if (productVm.Post.Id == 0)
				{
					TempData["success"] = $"Product {productVm.Post.Title} has been created successfully!";
				}
				else
				{
					TempData["success"] = $"Product {productVm.Post.Title} has been updated successfully!";
				}
				return RedirectToAction("Index");
			}
			else
			{
				productVm.TopicList = _unitOfWork.Topic.GetAll().Select(u => new SelectListItem
				{
					Text = u.Name,
					Value = u.Id.ToString()
				});
			}

			return View(productVm);
		}

		#region API CALLS
		[HttpGet]
		public IActionResult GetAllItems()
		{
			List<Post> posts = _unitOfWork.Post.GetAll(includeProperties: "Topic").ToList();
			return Json(new {data = posts});
		}


		public void Deletes(int id)
		{
			Post obj = _unitOfWork.Post.Get(u =>u.Id == id);
			_unitOfWork.Post.DeleteItem(obj);

		}
		#endregion

	}
}


