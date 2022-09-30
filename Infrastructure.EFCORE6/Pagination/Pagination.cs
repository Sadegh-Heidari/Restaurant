namespace Resturan.Infrastructure.EFCORE6.Pagination
{
    public static class Pagination
    {

        public static IQueryable<TSource> ToPaged<TSource>(this IQueryable<TSource> source,int page,int pagesize)
        {
            var skip = (page - 1) * pagesize;
            return source.Skip(skip).Take(pagesize);
        }

    }
}