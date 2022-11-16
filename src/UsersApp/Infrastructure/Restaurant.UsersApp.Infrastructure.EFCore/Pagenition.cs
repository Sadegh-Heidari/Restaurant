namespace Restaurant.UsersApp.Infrastructure.EFCore
{
    public static class Pagenition
    {
        public static IQueryable<TSource> ToPaged<TSource>(this IQueryable<TSource> source, int page, int pagesize)
        {
            var skip = (page - 1) * pagesize;
            return source.Skip(skip).Take(pagesize);
        }
    }
}
