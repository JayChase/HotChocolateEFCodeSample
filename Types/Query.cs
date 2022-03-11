using HotChocolate.Data;
using CodeSample.Data;

namespace CodeSample.Types
{
    public class Query
    {

        [UseTestDbContext]
        [UsePaging]
        [UseProjection]
        [UseFiltering(typeof(Thing))]
        [UseSorting(typeof(Thing))]
        public IQueryable<Thing> Things([ScopedService] TestDbContext context)
        {
            return context.Things.AsQueryable();
        }

    }
}

