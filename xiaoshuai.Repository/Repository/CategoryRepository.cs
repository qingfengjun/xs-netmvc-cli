using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using xiaoshuai.Repository.DTO;
using xiaoshuai.Repository.Entity;

namespace xiaoshuai.Repository.Repository
{
    public class CategoryRepository
    {
        public pub_CategoryEntity GetCategoryById(int id)
        {
            return EFHelper.Query<pub_CategoryEntity>(x => x.Id == id).First();
        }

        public int InsertCategory(pub_CategoryEntity entity)
        {
            return EFHelper.Insert<pub_CategoryEntity>(entity);
        }

        public int UpdateCategory(pub_CategoryEntity entity)
        {
            return EFHelper.Update<pub_CategoryEntity>(entity);
        }

        public int DeleteCategoryById(string categoryId)
        {
            int effect = 0;
            effect += EFHelper.Delete<pub_CategoryEntity>(x => x.CategoryId == categoryId);
            effect += EFHelper.Delete<pub_SubCategoryEntity>(x => x.CategoryId == categoryId);
            return effect;
        }

        public List<pub_CategoryEntity> GetCategory()
        {
            return EFHelper.Query<pub_CategoryEntity>().OrderBy(x => x.SortId).ToList();
        }

        public List<pub_SubCategoryEntity> GetSubCategoryByCategoryId(string categoryId)
        {
            return EFHelper.Query<pub_SubCategoryEntity>(x => x.CategoryId == categoryId);
        }
        public int InsertSubCategory(pub_SubCategoryEntity entity)
        {
            return EFHelper.Insert<pub_SubCategoryEntity>(entity);
        }

        public int UpdateSubCategory(pub_SubCategoryEntity entity)
        {
            return EFHelper.Update<pub_SubCategoryEntity>(entity);
        }

        public int DeleteSubCategoryById(int id)
        {
            return EFHelper.Delete<pub_SubCategoryEntity>(x => x.Id == id);
        }

        public List<SubCategoryDto> GetSubCategoryWithArticleNum()
        {
            string sql = @"select SubCategoryId,[CategoryId],[SubCategoryName],
                            (select count(1) from [dbo].[Article] where [SubCategoryId]=sub.[SubCategoryId]) ArticleNum,
                            (select isnull(MAX(ArticleId),'') from [dbo].[Article] where [SubCategoryId]=sub.[SubCategoryId]) ArticleId
                            from [pub_SubCategory] sub";
            return EFHelper.SqlQuery<SubCategoryDto>(sql);
        }

        /// <summary>
        /// 未分类的文章
        /// </summary>
        /// <returns></returns>
        public List<SubCategoryDto> GetCategoryWithArticleNum()
        {
            string sql = @"select ''SubCategoryId,[CategoryId],'未分类'[SubCategoryName],
                        (select count(1) from [Article] where [CategoryId]=c.CategoryId and SubCategoryId not in(select SubCategoryId from pub_SubCategory where CategoryId=c.CategoryId) )ArticleNum
                        from [dbo].[pub_Category] c";
            return EFHelper.SqlQuery<SubCategoryDto>(sql);
        }

        public ListCategoryDto GetListCategoryById(string id, string subid)
        {
            string sql = string.Empty;
            if (string.IsNullOrWhiteSpace(subid))
            {
                sql = @"select [CategoryName],[CategoryRemark] from [dbo].[pub_Category]
                        wehre [CategoryId]=@Id";
            }
            else
            {
                sql = @"select c.[CategoryName]+'/'+s.[SubCategoryName] [CategoryName],
                        s.[SubCategoryRemark] [CategoryRemark]
                         from [dbo].[pub_SubCategory] s
                        join [pub_Category]  c on c.[CategoryId]=s.[CategoryId]
                        where s.SubCategoryId=@subId";
            }
            SqlParameter[] paras = { new SqlParameter("@Id", SqlDbType.NVarChar) { Value = id }, new SqlParameter("@subId", SqlDbType.NVarChar) { Value = subid } };
            return EFHelper.SqlQuery<ListCategoryDto>(sql, paras).FirstOrDefault();
        }

    }
}
