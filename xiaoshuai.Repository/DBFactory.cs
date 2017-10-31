using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace xiaoshuai.Repository
{
    /// <summary>
    /// DbContext保证线程内唯一
    /// </summary>
    public static class DBFactory
    {
        public static DbContext CreateDbContext { get { return GetcurrentDbContect(); } }
        private static DbContext GetcurrentDbContect()
        {
            DbContext db = (DbContext)CallContext.GetData("DbContext");
            if (db == null)
            {
                db = new DataContext();
                CallContext.SetData("DbContext", db);
            }
            return db;
        }
    }
}
