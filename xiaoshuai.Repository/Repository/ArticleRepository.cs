using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using xiaoshuai.Repository.DTO;
using xiaoshuai.Repository.Entity;

namespace xiaoshuai.Repository.Repository
{
    public class ArticleRepository
    {
        public int InsertArticle(ArticleEntity entity)
        {
            return EFHelper.Insert<ArticleEntity>(entity);
        }

        public int UpdateArticle(ArticleEntity entity)
        {
            return EFHelper.Update<ArticleEntity>(entity);
        }

        public int DeleteArticleById(int id)
        {
            return EFHelper.Delete<ArticleEntity>(x => x.Id == id);
        }

        public List<ArticleEntity> GetArticleBySubCategoryId(string subCategoryId)
        {
            return EFHelper.Query<ArticleEntity>(x => x.SubCategoryId == subCategoryId);
        }

        public ArticleEntity GetArticleById(int id)
        {
            return EFHelper.Query<ArticleEntity>(x => x.Id == id).FirstOrDefault();
        }

        public ArticleEntity GetArticleByArticleId(string articleId)
        {
            return EFHelper.Query<ArticleEntity>(x => x.ArticleId == articleId).FirstOrDefault();
        }

        public List<ArticleDto> GetArticleDtoBySubCategoryId(string categoryid, string subCategoryId)
        {
            if (string.IsNullOrWhiteSpace(categoryid))//不在所有的大类里面的文章
            {
                string sql = @"select [Id],[Title],[Description],[CreateTime],CategoryId,SubCategoryId,ArticleId  from [Article] 
                                where CategoryId not in( select CategoryId from [dbo].[pub_Category])  ";
                return EFHelper.SqlQuery<ArticleDto>(sql);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(subCategoryId))
                {
                    //未分类
                    string sql = @"select [Id],[Title],[Description],[CreateTime],CategoryId,SubCategoryId,ArticleId  from [Article] where CategoryId=@CategoryId
						   and SubCategoryId not in(select SubCategoryId from [dbo].[pub_SubCategory] where CategoryId=@CategoryId) ";
                    return EFHelper.SqlQuery<ArticleDto>(sql, new SqlParameter("@CategoryId", categoryid));
                }
                else
                {
                    string sql = @"select [Id],[Title],[Description],[CreateTime],CategoryId,SubCategoryId,ArticleId from [dbo].[Article]
                           where [SubCategoryId]=@SubCategoryId order by CreateTime desc";
                    return EFHelper.SqlQuery<ArticleDto>(sql, new SqlParameter("@SubCategoryId", subCategoryId));
                }
            }

        }

        public List<ArticleCommentEntity> GetCommentByArticleId(string ArticleId)
        {
            return EFHelper.Query<ArticleCommentEntity>(x => x.ArticleId == ArticleId).OrderBy(x => x.CommentTime).ToList();
        }

        public int InsertComment(ArticleCommentEntity entity)
        {
            return EFHelper.Insert<ArticleCommentEntity>(entity);
        }

        public List<ArticleDto> GetLatestArticle()
        {
            string sql = @"select top 10 [Id],[Title],[Description],[CreateTime],CategoryId,SubCategoryId,ArticleId  from [Article] 
                                order by  CreateTime desc  ";
            return EFHelper.SqlQuery<ArticleDto>(sql);
        }
    }
}
