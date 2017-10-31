using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xiaoshuai.Common;
using xiaoshuai.Repository.DTO;
using xiaoshuai.Repository.Entity;
using xiaoshuai.Repository.Repository;
using xiaoshuai.ViewModel;

namespace xiaoshuai.Services
{
    public class ArticleService
    {
        private ArticleRepository articleRepository = new ArticleRepository();
        private CategoryRepository categoryRepository = new CategoryRepository();

        public bool EditArticle(ArticleViewModel model)
        {
            ArticleEntity entity = AutoMapHelper.ToEntity<ArticleViewModel, ArticleEntity>(model);
            if (entity.Id == 0)
            {
                entity.ArticleId = IDHelper.Create("A");
                articleRepository.InsertArticle(entity);
            }
            else
            {
                var last = articleRepository.GetArticleById(entity.Id);
                entity.CreateTime = last.CreateTime;
                entity.ArticleId = last.ArticleId;
                articleRepository.UpdateArticle(entity);
            }
            return true;
        }

        public int DeleteArticleById(int id)
        {
            return articleRepository.DeleteArticleById(id);
        }

        public List<ArticleViewModel> GetArticleBySubCategoryId(string subCategoryId)
        {
            var result = articleRepository.GetArticleBySubCategoryId(subCategoryId);
            return AutoMapHelper.ToList<ArticleEntity, ArticleViewModel>(result);
        }

        public ArticleViewModel GetArticleById(int id)
        {
            var result = articleRepository.GetArticleById(id);
            return AutoMapHelper.ToEntity<ArticleEntity, ArticleViewModel>(result);
        }

        public ArticleViewModel GetArticleByArticleId(string articleId)
        {
            var result = articleRepository.GetArticleByArticleId(articleId);
            return AutoMapHelper.ToEntity<ArticleEntity, ArticleViewModel>(result);
        }
        public List<ArticleDtoViewModel> GetArticleDtoBySubCategoryId(string categoryId, string subCategoryId)
        {
            var result = articleRepository.GetArticleDtoBySubCategoryId(categoryId, subCategoryId);
            return AutoMapHelper.ToList<ArticleDto, ArticleDtoViewModel>(result);
        }

        public List<CommentViewModel> GetCommentByArticleId(string ArticleId)
        {
            var result = articleRepository.GetCommentByArticleId(ArticleId);
            return AutoMapHelper.ToList<ArticleCommentEntity, CommentViewModel>(result);
        }
        public int InsertComment(CommentViewModel model)
        {
            ArticleCommentEntity entity = AutoMapHelper.ToEntity<CommentViewModel, ArticleCommentEntity>(model);
            return articleRepository.InsertComment(entity);
        }

        public List<ArticleDtoViewModel> GetLatestArticle()
        {
            var result = articleRepository.GetLatestArticle();
            return AutoMapHelper.ToList<ArticleDto, ArticleDtoViewModel>(result);
        }
        public ListCategoryViewModel GetListCategoryById(string id, string subid)
        {
            var result = categoryRepository.GetListCategoryById(id, subid);
            return AutoMapHelper.ToEntity<ListCategoryDto, ListCategoryViewModel>(result);
        }
    }
}
