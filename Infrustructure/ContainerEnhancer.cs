using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public delegate TResult Fun<in T, out TResult>(T arg);
    
    public static class 
        ContainerEnhancer
    {
        public static IEnumerable<TResult>
            ForEach<TSource, TResult>(this IEnumerable<TSource> ts, Fun<TSource, TResult> iterator)
        {
            List<TResult> result = new List<TResult>();
            foreach (var e in ts)
            {
                var temp = iterator.Invoke(e);
                result.Add(temp);
            }
            return result;
        }

        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> ts,Fun<TSource,Boolean> predicate)
        {
            List<TSource> result = new List<TSource>();
            foreach(var e in ts)
                if (predicate.Invoke(e))
                    result.Add(e);
            return result;
        }

        public static List<T> ToList<T>(this IEnumerable<T> ts)
        {
            List<T> vs = new List<T>();
            foreach (var e in ts)
                vs.Add(e);
            return vs;
        }
    }
}
