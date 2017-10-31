using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using xiaoshuai.Services;
using xiaoshuai.ViewModel;

namespace xiaoshuai.Web.Controllers
{
    public class ManageController : Controller
    {
        private ManageService service = new ManageService();
        private ArticleService articleService = new ArticleService();
        //
        // GET: /Manage/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryConfig()
        {
            List<CategoryViewModel> model = service.GetCategory();
            return View(model);
        }

        public ActionResult EditCategory(CategoryViewModel model)
        {
            service.EditCategory(model);
            return RedirectToAction("CategoryConfig", "Manage");
        }

        public ActionResult DeleteCategory(string id)
        {
            service.DeleteCategory(id);
            return RedirectToAction("CategoryConfig", "Manage");
        }

        public ActionResult SubCategoryConfig(string id)
        {
            var model = service.GetSubCategoryByCategoryId(id);
            ViewBag.CategoryId = id;
            return View(model);
        }

        public ActionResult EditSubCategory(string SubCategoryName, string SubCategoryId, string SubCategoryRemark, string CategoryId, int id)
        {
            SubCategoryViewModel model = new SubCategoryViewModel();
            model.Id = id;
            model.SubCategoryId = SubCategoryId;
            model.CategoryId = CategoryId;
            model.SubCategoryName = SubCategoryName;
            model.SubCategoryRemark = SubCategoryRemark;
            service.EditSubCategory(model);
            return RedirectToAction("SubCategoryConfig", "Manage", new { id = CategoryId });
        }

        public ActionResult DeleteSubCategory(int id, string categoryId)
        {
            service.DeleteSubCategory(id);
            return RedirectToAction("SubCategoryConfig", "Manage", new { id = categoryId });
        }

        public ActionResult EditArticle(int id = 0)
        {
            ArticleViewModel model = new ArticleViewModel();
            model.IsTop = 0;
            if (id != 0)
            {
                model = articleService.GetArticleById(id);
                model.Content = model.Content.Replace('\'', '\"');
                model.Content = model.Content.Replace("\r\n", "");
            }
            return View(model);
        }

        [ValidateInput(false)]
        public ActionResult ArticlePublish(int id, string ArticleTitle, string Content, string Remark, string CategoryId = "", string SubCategoryId = "", int isTop = 0)
        {
            ArticleViewModel model = new ArticleViewModel();
            model.Id = id;
            model.CategoryId = CategoryId;
            model.SubCategoryId = SubCategoryId;
            model.Title = string.IsNullOrWhiteSpace(ArticleTitle) ? DateTime.Now.ToString("yyy-MM-dd HH:ss") : ArticleTitle;
            model.Content = string.IsNullOrWhiteSpace(Content) ? "无语！！" : Content;
            model.Description = Remark;
            model.CreateTime = DateTime.Now;
            model.IsTop = isTop;
            model.UpdateTime = DateTime.Now;
            articleService.EditArticle(model);

            return RedirectToAction("CategoryArticle", "Manage", new { id = CategoryId, subId = SubCategoryId });
        }

        public ActionResult CategoryArticle(string id = "", string subId = "")
        {
            var model = articleService.GetArticleDtoBySubCategoryId(id, subId);
            return View(model);
        }

        public ActionResult PartialCategory(string id = "", string subId = "")
        {
            var model = service.GetCategoryComboxData(id, subId);
            return PartialView("PartialCategory", model);
        }

        public ActionResult DeleteArticle(int id, string categoryId, string subCategoryId)
        {
            articleService.DeleteArticleById(id);
            return RedirectToAction("CategoryArticle", "Manage", new { id = categoryId, subId = subCategoryId });
        }
        public ActionResult ArticleHelp()
        {
            return View();
        }

    }
}
