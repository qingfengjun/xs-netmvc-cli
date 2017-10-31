using AutoMapper;
using System.Collections.Generic;

namespace xiaoshuai.Common
{
    public class AutoMapHelper
    {
        /// <summary>
        /// 把一个List转换为另外一个list
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static List<TDestination> ToList<TSource, TDestination>(List<TSource> source)
        {
            Mapper.CreateMap<TSource, TDestination>();
            List<TDestination> result = Mapper.Map<List<TSource>, List<TDestination>>(source);
            return result;
        }

        /// <summary>
        /// 实体之间相互转换
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static TDestination ToEntity<TSource, TDestination>(TSource source)
        {
            Mapper.CreateMap<TSource, TDestination>();
            TDestination result = Mapper.Map<TSource, TDestination>(source);
            return result;
        }
    }
}
