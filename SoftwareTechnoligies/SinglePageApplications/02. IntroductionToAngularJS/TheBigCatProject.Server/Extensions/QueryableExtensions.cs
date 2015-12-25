namespace TheBigCatProject.Server.Extensions
{
    using System.Linq;
    using Models;
    public static class QueryableExtensions
    {
        public static IQueryable<CatRequestModel> ToFilterCats(this IQueryable<CatRequestModel> query, CatFilterModel filters)
        {
            if (filters == null)
            {
                return query;
            }

            if (!string.IsNullOrWhiteSpace(filters.Name))
            {
                query = query.Where(c => c.Name.ToLower().Contains(filters.Name.ToLower()));
            }

            if (filters.Age != null)
            {
                query = query.Where(c => c.Age == filters.Age);
            }

            if (filters.Breed != null)
            {
                query = query.Where(c => c.Breed == filters.Breed);
            }

            var skip = (filters.Page - 1) * 3;
            var tage = 3;

            query = query
                .OrderByDescending(c => c.Id)
                .Skip(skip)
                .Take(tage);

            return query;
        }
    }
}