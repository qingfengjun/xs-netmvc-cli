using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using xiaoshuai.Common;
using xiaoshuai.Services;
using xiaoshuai.ViewModel;

namespace xiaoshuai.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private ArticleService articleService = new ArticleService();

        public ActionResult Index()
        {
            var model = articleService.GetLatestArticle();
            return View(model);
        }

        public ActionResult Article(string id = "")
        {
            ArticleViewModel model = articleService.GetArticleByArticleId(id);
            return View(model);
        }

        public ActionResult List(string id = "", string subid = "")
        {
            var model = articleService.GetArticleDtoBySubCategoryId(id, subid);
            ViewBag.CategoryId = id;
            ViewBag.SubCategoryId = subid;
            return View(model);
        }

        public ActionResult ListCategory(string id = "", string subid = "")
        {
            var model = articleService.GetListCategoryById(id, subid);
            return PartialView("ListCategoryPartial", model);
        }

        public ActionResult Comment(string id)
        {
            var model = articleService.GetCommentByArticleId(id);
            return PartialView("ArticleComment", model);
        }
        public string AddComment(string id, string comment)
        {
            CommentViewModel model = new CommentViewModel();
            model.Comment = comment;
            model.CommentTime = DateTime.Now;
            model.ArticleId = id;
            string ip = IPHelper.GetIp();
            model.IPAdress = ip;
            model.Name = IPHelper.GetAddressByIp(ip);

            //发送邮件提醒
            
            MailDto dto = new MailDto();
            dto.Subject = string.Format("您的文章有新的评论，请注意查收！");
            dto.Body = string.Format(@"<a href='http://localhost:5823/Home/Article/{0}'>原文链接</a> {1}：{2}", id,model.Name, comment);
            
            MailHelper.Send(dto);

            return articleService.InsertComment(model).ToString();
        }
    }
}
