using System;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Mime;
using System.Web.Mvc;
using MvcMate.Web.Mvc;
using Nsk.Web.OnlineStore.Models.Home;
using Nsk.Web.OnlineStore.WorkerServices;

namespace Nsk.Web.OnlineStore.Controllers
{
	public class HomeController : Controller
	{
        public IHomeControllerWorkerServices WorkerService { get; private set; }

		public HomeController(IHomeControllerWorkerServices svc)
		{
            Contract.Requires<ArgumentNullException>(svc != null, "svc");
            Contract.Ensures(this.WorkerService==svc);

			this.WorkerService = svc;
		}	

		public ActionResult Index()
		{
            var model = this.WorkerService.GetIndexViewModel();

			return View(model);
		}

		[ChildActionOnly]
		[OutputCache(Duration = 60)]
		public PartialViewResult RenderProductCategories()
		{
			var model = new ProductCategoriesViewModel();
			model.Categories = this.WorkerService.GetAllProductCategories();
			return PartialView("ProductCategories", model);
		}

		[ChildActionOnly]
		[OutputCache(Duration = 60)]
		public PartialViewResult RenderBestSellingProductCategories()
		{
			var model = new ProductCategoriesViewModel();
			model.Categories = this.WorkerService.GetBestSellingProductCategories();
			return PartialView ("ProductCategories", model);
		}

		[HttpGet]
		[OutputCache(Duration = 60, VaryByParam = "categoryId")]
		public ActionResult CategoryThumbnail(int? categoryId)
		{
			if (!categoryId.HasValue)
			{
				return new EmptyResult();
			}
			else
			{
				try
				{
					Image image = this.WorkerService.GetThumbnailForCategoryId(categoryId.Value);
                    return this.Image(image, "image/jpeg", new Size(image.Width / 3, image.Height / 3));
                    //return new ImageResult(image, MediaTypeNames.Image.Jpeg, new Size(image.Width / 3, image.Height / 3));
				}
				catch
				{
					return new EmptyResult ();
				}
			}
		}

		public ActionResult ProductCategory(int? id)
		{
			if(!id.HasValue)
            {
				return View("Index");
            }
			return View();
		}

        [HttpGet]
        public ActionResult Register()
        {
            var model = new RegisterViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                return Redirect("/");
            }

        }

        [HttpGet]
        public ActionResult ValidateUniqueUserName(string UserName)
        {
            bool userAlreadyExists = this.WorkerService.UserNameIsAlreadyUsed(UserName);
            return Json(!userAlreadyExists, JsonRequestBehavior.AllowGet);
        }
	}
}