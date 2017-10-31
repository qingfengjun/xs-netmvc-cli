using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using xiaoshuai.Repository.Entity;

namespace xiaoshuai.Repository
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("DbCon")
        {
        }
        public DbSet<ArticleEntity> Article_DbSet { get; set; }
        public DbSet<pub_CategoryEntity> pub_Category_DbSet { get; set; }
        public DbSet<pub_SubCategoryEntity> pub_SubCategory_DbSet { get; set; }
        public DbSet<ArticleCommentEntity> ArticleCommentEntity_DbSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();//移除复数表名的契约
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();//防止黑幕交易 要不然每次都要访问 EdmMetadata这个表
        }
    }
}
