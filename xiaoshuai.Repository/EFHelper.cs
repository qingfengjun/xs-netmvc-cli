using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace xiaoshuai.Repository
{
    public class EFHelper
    {
        /// <summary>
        /// 新增一条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        public static int Insert<T>(T model) where T : class
        {
            DataContext dbContext = (DataContext)DBFactory.CreateDbContext;
            dbContext.Entry<T>(model).State = EntityState.Added;
            return dbContext.SaveChanges();
        }

        /// <summary>
        /// 修改一条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        public static int Update<T>(T model) where T : class
        {
            DataContext dbContext = (DataContext)DBFactory.CreateDbContext;
            dbContext.Entry<T>(model).State = EntityState.Modified;
            return dbContext.SaveChanges();
        }

        /// <summary>
        /// 按照条件删除数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        public static int Delete<T>(Expression<Func<T, bool>> expression) where T : class
        {
            DataContext dbContext = (DataContext)DBFactory.CreateDbContext;
            var result = dbContext.Set<T>().Where(expression);
            foreach (T entity in result)
            {
                dbContext.Entry<T>(entity).State = EntityState.Deleted;
            }
            return dbContext.SaveChanges();
        }

        public static List<T> Query<T>(Expression<Func<T, bool>> expression) where T : class
        {
            DataContext dbContext = (DataContext)DBFactory.CreateDbContext;
            return dbContext.Set<T>().Where(expression).AsNoTracking().ToList<T>();
        }

        public static List<T> Query<T>() where T : class
        {
            DataContext dbContext = (DataContext)DBFactory.CreateDbContext;
            return dbContext.Set<T>().AsNoTracking().ToList<T>();
        }

        public static List<T> SqlQuery<T>(string sql) where T : class
        {
            DataContext dbContext = (DataContext)DBFactory.CreateDbContext;
            return dbContext.Database.SqlQuery<T>(sql).ToList<T>();
        }

        public static List<T> SqlQuery<T>(string sql, params SqlParameter[] para) where T : class
        {
            DataContext dbContext = (DataContext)DBFactory.CreateDbContext;
            return dbContext.Database.SqlQuery<T>(sql, para).ToList<T>();
        }
    }
}
